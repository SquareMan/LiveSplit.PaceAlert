using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using LiveSplit.Model;
using LiveSplit.PaceAlert.Discord;
using LiveSplit.TimeFormatters;

namespace LiveSplit.PaceAlert.Logic
{
    public class NotificationManager : IDisposable
    {
        private static ITimeFormatter _deltaTimeFormatter;
        private static ITimeFormatter _timeFormatter;
        private readonly ComponentSettings _settings;
        private readonly LiveSplitState _state;
        private CancellationTokenSource _cancellationTokenSource;

        public NotificationManager(LiveSplitState state, ComponentSettings settings)
        {
            _state = state;
            _settings = settings;
            _cancellationTokenSource = new CancellationTokenSource();
            
            // TODO: This should be an instance variable but SendMessageFormatted needs to be static right now.
            _deltaTimeFormatter = new DeltaTimeFormatter();
            _timeFormatter = new RegularTimeFormatter();

            state.OnSplit += LiveSplitState_OnSplit;
            state.OnUndoSplit += LiveSplitState_OnUndoSplit;
            state.OnReset += LiveSplitState_OnReset;
        }

        public void Dispose()
        {
            _state.OnSplit -= LiveSplitState_OnSplit;
            _state.OnUndoSplit -= LiveSplitState_OnUndoSplit;
            _state.OnReset -= LiveSplitState_OnReset;
            _cancellationTokenSource?.Dispose();
        }

        private void LiveSplitState_OnSplit(object sender, EventArgs e)
        {
            if (_cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = new CancellationTokenSource();
            }
            
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
                            _state.Run[notificationSettings.SelectedSplit], _settings.MessageDelay, _cancellationTokenSource.Token);
                        break;
                }
            }
        }

        private void LiveSplitState_OnUndoSplit(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private void LiveSplitState_OnReset(object sender, TimerPhase value)
        {
            _cancellationTokenSource.Cancel();
        }

        public static void SendMessageFormatted(LiveSplitState state, NotificationSettings notificationSettings,
            TimeSpan? deltaValue, TimeSpan? bestPossibleTime, ISegment split, int delay, CancellationToken cancellationToken)
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
                PaceBot.SendMessage(messageString, delay, cancellationToken);
            }
        }
    }
}