using System;
using System.Windows.Forms;
using LiveSplit.PaceAlert.Api;
using LiveSplit.TimeFormatters;

namespace LiveSplit.PaceAlert.Logic
{
    public class Variables
    {
        private static readonly ITimeFormatter _deltaTimeFormatter = new DeltaTimeFormatter();
        private static readonly ITimeFormatter _timeFormatter = new RegularTimeFormatter();

        public class Delta : IVariable
        {
            public string GetKeyword() => "delta";

            public string Evaluate(NotificationManager.NotificationStats stats) =>
                _deltaTimeFormatter.Format(stats.DeltaValue);
        }

        public class BestPossibleTime : IVariable
        {
            public string GetKeyword() => "bpt";

            public string Evaluate(NotificationManager.NotificationStats stats) =>
                _timeFormatter.Format(stats.BestPossibleTime);
        }

        public class Split : IVariable
        {
            public string GetKeyword() => "split";
            public string Evaluate(NotificationManager.NotificationStats stats) => stats.Settings.SelectedSegment.Name;
        }

        public class CurrentTime : IVariable
        {
            public string GetKeyword() => "time";

            public string Evaluate(NotificationManager.NotificationStats stats) =>
                _timeFormatter.Format(stats.State.CurrentTime[stats.Settings.TimingMethod]);
        }
    }
}