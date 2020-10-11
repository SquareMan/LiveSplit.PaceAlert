using System;
using System.Collections.Generic;
using LiveSplit.Model;

namespace LiveSplit.PaceAlert.Logic
{
    public static class Settings
    {
        // Dictionary of settings for each splits file, keyed on file path
        public static Dictionary<string, NotificationSettings> SettingsDictionary = new Dictionary<string, NotificationSettings>();

        public static NotificationSettings GetActiveSettings(LiveSplitState state)
        {
            return SettingsDictionary.TryGetValue(state.Run.FilePath, out var value) ? value : null;
        }
    }
}