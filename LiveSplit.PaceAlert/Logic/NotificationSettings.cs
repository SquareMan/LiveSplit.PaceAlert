using System;
using LiveSplit.Model;

namespace LiveSplit.PaceAlert.Logic
{
    public class NotificationSettings
    {
        public TimeSpan DeltaTarget;
        public string MessageTemplate;
        // Used for serialization only, required since settings for every file must be loaded to ensure they aren't lost
        public int SelectedSplitIndex;
        public TimingMethod TimingMethod;
        public NotificationType Type;
        public bool TakeScreenshot;
        public ISegment SelectedSegment;

        public NotificationSettings()
        {
            DeltaTarget = TimeSpan.Zero;
            MessageTemplate = string.Empty;
            SelectedSplitIndex = -1;
            TimingMethod = TimingMethod.RealTime;
            Type = NotificationType.Delta;
            TakeScreenshot = false;
        }
    }
}