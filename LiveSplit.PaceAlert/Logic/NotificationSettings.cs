using System;
using LiveSplit.Model;

namespace LiveSplit.PaceAlert.Logic
{
    public class NotificationSettings
    {
        public int SelectedSplit;
        public TimeSpan DeltaTarget;
        public bool Ahead;
        public TimingMethod Comparison;
        public string MessageTemplate;

        public NotificationSettings()
        {
            SelectedSplit = -1;
            DeltaTarget = TimeSpan.Zero;
            Ahead = true;
            Comparison = TimingMethod.RealTime;
            MessageTemplate = string.Empty;
        }
    }
}