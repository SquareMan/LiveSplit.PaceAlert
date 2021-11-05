using System.Collections.Generic;
using LiveSplit.Model;

namespace LiveSplit.PaceAlert.Logic
{
    public class ComponentSettings
    {
        public int MessageDelay;

        // Dictionary of settings for each splits file, keyed on file path
        public readonly Dictionary<string, List<NotificationSettings>> SettingsDictionary;

        public ComponentSettings()
        {
            MessageDelay = 2000;
            SettingsDictionary = new Dictionary<string, List<NotificationSettings>>();
        }

        public List<NotificationSettings> GetActiveSettings(LiveSplitState state)
        {
            if (state.Run.FilePath == null) return null;
            return SettingsDictionary.TryGetValue(state.Run.FilePath, out var value) ? value : null;
        }
    }
}