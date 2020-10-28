using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using LiveSplit.Model;
using LiveSplit.PaceAlert.Discord;

namespace LiveSplit.PaceAlert.Logic
{
    public class NotificationManager
    {
        private LiveSplitState _state;
        private ComponentSettings _settings;
        
        public NotificationManager(LiveSplitState state, ComponentSettings settings)
        {
            _state = state;
            _settings = settings;

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
                        return ToDeltaFormat(deltaValue) + (deltaValue.TotalMilliseconds < 0 ? '-' : '+');
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

        private static string ToDeltaFormat(TimeSpan t)
        {
            if (t.Hours != 0)
            {
                return t.ToString(@"h\:mm\:ss\.ff");
            }

            if (t.Minutes != 0)
            {
                return t.ToString(@"m\:ss\.ff");
            }
            
            return t.ToString(@"s\.ff");
        }
    }
}