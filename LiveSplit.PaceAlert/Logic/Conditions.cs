using LiveSplit.PaceAlert.Api;

namespace LiveSplit.PaceAlert.Logic
{
    public static class Conditions
    {
        public class CurrentTime : ICondition
        {
            public string GetTag() => "PaceAlert.CurrentTime";
            public string GetTitle() => "Current Time";
            public bool Evaluate(NotificationManager.NotificationStats stats) =>
                stats.State.CurrentTime[stats.Settings.TimingMethod] < stats.TargetTime;
        }

        public class Delta : ICondition
        {
            public string GetTag() => "PaceAlert.Delta";
            public string GetTitle() => "Delta";
            public bool Evaluate(NotificationManager.NotificationStats stats) => stats.DeltaValue < stats.TargetTime;
        }

        public class BestPossibleTime : ICondition
        {
            public string GetTag() => "PaceAlert.BestPossibleTime";
            public string GetTitle() => "Best Possible Time";
            public bool Evaluate(NotificationManager.NotificationStats stats) =>
                stats.BestPossibleTime < stats.TargetTime;
        }
    }
}