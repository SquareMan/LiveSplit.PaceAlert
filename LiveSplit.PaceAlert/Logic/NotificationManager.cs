using System;
using System.Text;
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

        private void LiveSplitState_OnStart(object sender, EventArgs e)
        {
        }

        private void LiveSplitState_OnSplit(object sender, EventArgs e)
        {
            var activeSettings = _settings.GetActiveSettings(_state);

            foreach (var setting in activeSettings)
            {
                if (_state.CurrentSplitIndex != setting.SelectedSplit + 1)
                    continue;
                
                var split = _state.Run[setting.SelectedSplit];
                var delta = (split.SplitTime - split.PersonalBestSplitTime)[setting.Comparison];

                if (!delta.HasValue) continue;
                
                var deltaValue = delta.Value;
                var deltaTarget = setting.Ahead
                    ? setting.DeltaTarget.Negate()
                    : setting.DeltaTarget;

                if (!(deltaValue.TotalSeconds < deltaTarget.TotalSeconds))
                    continue;
                
                StringBuilder messageStringBuilder = new StringBuilder();
                string[] substrings = setting.MessageTemplate.Split('$');
                foreach (var substring in substrings)
                {
                    //Parse message variables
                    if (substring.StartsWith("delta"))
                    {
                        string time = ToDeltaFormat(deltaValue);
                        char negative = deltaValue.TotalMilliseconds < 0 ? '-' : '+';
                        messageStringBuilder.Append(negative + time);
                        messageStringBuilder.Append(substring.Substring("delta".Length));
                    }
                    else if (substring.StartsWith("split"))
                    {
                        messageStringBuilder.Append(split.Name);
                        messageStringBuilder.Append(substring.Substring("split".Length));
                    }
                    else
                    {
                        messageStringBuilder.Append(substring);
                    }
                }

                var messageString = messageStringBuilder.ToString();
                if (messageString != string.Empty)
                {
                    PaceBot.SendMessage(messageString);
                }
            }
        }

        private string ToDeltaFormat(TimeSpan t)
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