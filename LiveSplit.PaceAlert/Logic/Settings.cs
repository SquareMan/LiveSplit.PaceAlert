using System;
using LiveSplit.Model;

namespace LiveSplit.PaceAlert.Logic
{
    public static class Settings
    {
        public static int SelectedSplit = -1;
        public static TimeSpan DeltaTarget = TimeSpan.Zero;
        public static bool Ahead = true;
        public static TimingMethod Comparison = TimingMethod.RealTime;
    }
}