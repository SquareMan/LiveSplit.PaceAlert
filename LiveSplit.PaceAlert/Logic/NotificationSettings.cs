using System;
using LiveSplit.Model;

namespace LiveSplit.PaceAlert.Logic
{
    public class NotificationSettings
    {
        public NotificationType Type;
        public int SelectedSplit;
        public TimeSpan DeltaTarget;
        public bool Ahead;
        public TimingMethod TimingMethod;
        public string MessageTemplate;

        public NotificationSettings()
        {
            Type = NotificationType.Delta;
            SelectedSplit = -1;
            DeltaTarget = TimeSpan.Zero;
            Ahead = true;
            TimingMethod = TimingMethod.RealTime;
            MessageTemplate = string.Empty;
        }
    }
}