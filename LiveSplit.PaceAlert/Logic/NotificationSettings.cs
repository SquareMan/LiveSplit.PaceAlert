using System;
using LiveSplit.Model;

namespace LiveSplit.PaceAlert.Logic
{
    public class NotificationSettings
    {
        public TimeSpan DeltaTarget;
        public string MessageTemplate;
        public int SelectedSplit;
        public TimingMethod TimingMethod;
        public NotificationType Type;
        public bool TakeScreenshot;

        public NotificationSettings()
        {
            DeltaTarget = TimeSpan.Zero;
            MessageTemplate = string.Empty;
            SelectedSplit = -1;
            TimingMethod = TimingMethod.RealTime;
            Type = NotificationType.Delta;
            TakeScreenshot = false;
        }
    }
}