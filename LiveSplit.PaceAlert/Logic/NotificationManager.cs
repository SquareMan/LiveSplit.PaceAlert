using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        private static event EventHandler OnNextUpdate;

        private static Dictionary<NotificationType, Func<NotificationStats,bool>> _notificationPredicates = new Dictionary<NotificationType, Func<NotificationStats, bool>>
        {
            {NotificationType.BestPossibleTime, stats => stats.BestPossibleTime < stats.TargetTime},
            {NotificationType.Delta, stats => stats.DeltaValue < stats.TargetTime},
            {NotificationType.Time, stats => stats.State.CurrentTime[stats.Settings.TimingMethod] < stats.TargetTime}
        };
        
        internal static Dictionary<string,Func<NotificationStats,string>> _variableFuncs = new Dictionary<string, Func<NotificationStats,string>>
        {
            {"$(delta)", stats => _deltaTimeFormatter.Format(stats.DeltaValue)},
            {"$(bpt)", stats => _timeFormatter.Format(stats.BestPossibleTime)},
            {"$(split)", stats => stats.Split.Name},
            {"$(time)", stats => _timeFormatter.Format(stats.State.CurrentTime[stats.Settings.TimingMethod])}
        };

        static NotificationManager()
        {
            // TODO: This should be an instance variable but SendMessageFormatted needs to be static right now.
            _deltaTimeFormatter = new DeltaTimeFormatter();
            _timeFormatter = new RegularTimeFormatter();
        }

        public static void SendMessageFormatted(NotificationStats stats, int delay, CancellationToken cancellationToken)
        {
            // Matches all occurrences of text surrounded with "$(" and ")" and replaces it if it's a valid variable
            var messageString = Regex.Replace(stats.Settings.MessageTemplate, @"\$\([^)]+\)", match =>
            {
                _variableFuncs.TryGetValue(match.Value, out var func);
                return func?.Invoke(stats) ?? match.Value;
            });

            if (messageString != string.Empty)
            {
                OnNextUpdate += (sender, args) =>
                {
                    string path = null;
                    if (stats.Settings.TakeScreenshot)
                    {
                        var screenshot = MakeScreenShot(stats.State);
                        path = "tmp.png";
                        screenshot?.Save(path);
                    }

                    PaceBot.SendMessage(messageString, path, delay, cancellationToken);
                };
            }
        }

        private static Image MakeScreenShot(LiveSplitState state, bool transparent = false)
        {
            // TODO: Probably reimplement this MakeScreenShot function instead of using reflection.
            var timerForm = state.Form;
            Image m = timerForm.GetType()
                .GetMethod("MakeScreenShot", BindingFlags.NonPublic | BindingFlags.Instance)?
                .Invoke(timerForm, new object[] {false}) as Image;
            return m;
        }

        private readonly ComponentSettings _settings;
        private readonly LiveSplitState _state;
        private CancellationTokenSource _cancellationTokenSource;

        public NotificationManager(LiveSplitState state, ComponentSettings settings)
        {
            _state = state;
            _settings = settings;
            _cancellationTokenSource = new CancellationTokenSource();
            
            state.OnSplit += LiveSplitState_OnSplit;
            state.OnUndoSplit += LiveSplitState_OnUndoSplit;
            state.OnReset += LiveSplitState_OnReset;
        }

        public void Dispose()
        {
            _state.OnSplit -= LiveSplitState_OnSplit;
            _state.OnUndoSplit -= LiveSplitState_OnUndoSplit;
            _state.OnReset -= LiveSplitState_OnReset;
            _cancellationTokenSource.Dispose();
        }

        public void Update()
        {
            // TODO: Really starting to abuse static members here, fix before 1.0! (Maybe singleton pattern?)
            OnNextUpdate?.Invoke(this, null);
            OnNextUpdate = null;
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
                
                NotificationStats stats = new NotificationStats(_state, notificationSettings);

                if (_notificationPredicates[notificationSettings.Type].Invoke(stats))
                {
                    SendMessageFormatted(stats, _settings.MessageDelay, _cancellationTokenSource.Token);
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

        public struct NotificationStats
        {
            public LiveSplitState State {get;}
            public NotificationSettings Settings { get; }
            
            public TimeSpan TargetTime => Settings.Ahead ? Settings.DeltaTarget.Negate() : Settings.DeltaTarget;

            private TimeSpan? _deltaValue;
            public TimeSpan? DeltaValue
            {
                get
                {
                    if (_deltaValue == null)
                    {
                        _deltaValue = LiveSplitStateHelper.GetLastDelta(State,
                            Settings.SelectedSplit, "Personal Best", Settings.TimingMethod);
                    }
                    return _deltaValue;
                }
            }

            private TimeSpan? _bestPossibleTime;
            public TimeSpan? BestPossibleTime
            {
                get
                {
                    if (_bestPossibleTime == null)
                    {
                        _bestPossibleTime =
                            LiveSplitStateHelper.GetLastDelta(State, Settings.SelectedSplit, "Best Segments",
                                Settings.TimingMethod) +
                            State.Run.Last().Comparisons["Best Segments"][Settings.TimingMethod];
                    }
                    return _bestPossibleTime;
                }
            }

            public ISegment Split => State.Run[Settings.SelectedSplit];

            public NotificationStats(LiveSplitState state, NotificationSettings settings)
            {
                State = state;
                Settings = settings;
                _deltaValue = null;
                _bestPossibleTime = null;
            }
        }
    }
}