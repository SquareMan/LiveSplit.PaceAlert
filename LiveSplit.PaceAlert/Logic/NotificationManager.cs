using System;
using System.Text.RegularExpressions;
using LiveSplit.Model;
using LiveSplit.PaceAlert.Discord;
using LiveSplit.TimeFormatters;

namespace LiveSplit.PaceAlert.Logic
{
    public class NotificationManager
    {
        private static ITimeFormatter _timeFormatter;
        private LiveSplitState _state;
        private ComponentSettings _settings;
        
        public NotificationManager(LiveSplitState state, ComponentSettings settings)
        {
            _state = state;
            _settings = settings;
            
            // TODO: This should be an instance variable but SendMessageFormatted needs to be static right now.
            _timeFormatter = new DeltaTimeFormatter();

            state.OnStart += LiveSplitState_OnStart;
            state.OnSplit += LiveSplitState_OnSplit;
        }

        public void Dispose()
        {
            _state.OnStart -= LiveSplitState_OnStart;
            _state.OnSplit -= LiveSplitState_OnSplit;
        }

        public static void SendMessageFormatted(NotificationSettings notificationSettings, TimeSpan deltaValue, ISegment split)
        {
            // Matches all occurrences of text surrounded with "$(" and ")" and replaces it if it's a valid variable
            var messageString = Regex.Replace(notificationSettings.MessageTemplate, @"\$\([^)]+\)", match =>
            {
                switch (match.Value)
                {
                    case "$(delta)":
                        return _timeFormatter.Format(deltaValue);
                    case "$(split)":
                        return split.Name;
                    default:
                        return match.Value;
                }
            });
            
            if (messageString != string.Empty)
            {
                PaceBot.SendMessage(messageString);
            }
        }

        private void LiveSplitState_OnStart(object sender, EventArgs e)
        {
        }

        private void LiveSplitState_OnSplit(object sender, EventArgs e)
        {
            var activeSettingsList = _settings.GetActiveSettings(_state);

            foreach (var notificationSettings in activeSettingsList)
            {
                if (_state.CurrentSplitIndex != notificationSettings.SelectedSplit + 1)
                    continue;
                
                var split = _state.Run[notificationSettings.SelectedSplit];
                var delta = (split.SplitTime - split.PersonalBestSplitTime)[notificationSettings.Comparison];

                if (!delta.HasValue) 
                    continue;
                
                var deltaValue = delta.Value;
                var deltaTarget = notificationSettings.Ahead
                    ? notificationSettings.DeltaTarget.Negate()
                    : notificationSettings.DeltaTarget;

                if (!(deltaValue.TotalSeconds < deltaTarget.TotalSeconds))
                    continue;
                
                SendMessageFormatted(notificationSettings, deltaValue, split);
            }
        }
    }
}