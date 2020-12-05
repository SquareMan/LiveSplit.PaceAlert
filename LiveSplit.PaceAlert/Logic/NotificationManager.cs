using System;
using System.Linq;
using System.Text.RegularExpressions;
using LiveSplit.Model;
using LiveSplit.PaceAlert.Discord;
using LiveSplit.TimeFormatters;

namespace LiveSplit.PaceAlert.Logic
{
    public class NotificationManager
    {
        private static ITimeFormatter _deltaTimeFormatter;
        private static ITimeFormatter _timeFormatter;
        private readonly ComponentSettings _settings;
        private readonly LiveSplitState _state;

        public NotificationManager(LiveSplitState state, ComponentSettings settings)
        {
            _state = state;
            _settings = settings;

            // TODO: This should be an instance variable but SendMessageFormatted needs to be static right now.
            _deltaTimeFormatter = new DeltaTimeFormatter();
            _timeFormatter = new RegularTimeFormatter();

            state.OnSplit += LiveSplitState_OnSplit;
        }

        public void Dispose()
        {
            _state.OnSplit -= LiveSplitState_OnSplit;
        }

        public static void SendMessageFormatted(LiveSplitState state, NotificationSettings notificationSettings,
            TimeSpan? deltaValue, TimeSpan? bestPossibleTime, ISegment split)
        {
            // Matches all occurrences of text surrounded with "$(" and ")" and replaces it if it's a valid variable
            var messageString = Regex.Replace(notificationSettings.MessageTemplate, @"\$\([^)]+\)", match =>
            {
                switch (match.Value)
                {
                    case "$(delta)":
                        return _deltaTimeFormatter.Format(deltaValue);
                    case "$(bpt)":
                        return _deltaTimeFormatter.Format(bestPossibleTime);
                    case "$(split)":
                        return split.Name;
                    case "$(time)":
                        return _timeFormatter.Format(state.CurrentTime[notificationSettings.TimingMethod]);
                    default:
                        return match.Value;
                }
            });

            if (messageString != string.Empty)
            {
                PaceBot.SendMessage(messageString);
            }
        }

        private void LiveSplitState_OnSplit(object sender, EventArgs e)
        {
            var activeSettingsList = _settings.GetActiveSettings(_state);

            foreach (var notificationSettings in activeSettingsList)
            {
                if (_state.CurrentSplitIndex != notificationSettings.SelectedSplit + 1)
                    continue;

                var pbDelta = LiveSplitStateHelper.GetLastDelta(_state, notificationSettings.SelectedSplit,
                    "Personal Best", notificationSettings.TimingMethod);
                var bestPossibleTime =
                    LiveSplitStateHelper.GetLastDelta(_state, notificationSettings.SelectedSplit, "Best Segments",
                        notificationSettings.TimingMethod) +
                    _state.Run.Last().Comparisons["Best Segments"][notificationSettings.TimingMethod];

                var deltaTarget = notificationSettings.Ahead
                    ? notificationSettings.DeltaTarget.Negate()
                    : notificationSettings.DeltaTarget;

                switch (notificationSettings.Type)
                {
                    case NotificationType.Time when _state.CurrentTime[notificationSettings.TimingMethod] < deltaTarget:
                    case NotificationType.Delta when pbDelta < deltaTarget:
                    case NotificationType.BestPossibleTime when bestPossibleTime < deltaTarget:
                        SendMessageFormatted(_state, notificationSettings, pbDelta, bestPossibleTime,
                            _state.Run[notificationSettings.SelectedSplit]);
                        break;
                }
            }
        }
    }
}