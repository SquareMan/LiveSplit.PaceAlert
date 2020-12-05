using System.Collections.Generic;
using LiveSplit.Model;

namespace LiveSplit.PaceAlert.Logic
{
    public class ComponentSettings
    {
        // Dictionary of settings for each splits file, keyed on file path
        public Dictionary<string, List<NotificationSettings>> SettingsDictionary =
            new Dictionary<string, List<NotificationSettings>>();

        public ComponentSettings()
        {
            SettingsDictionary = new Dictionary<string, List<NotificationSettings>>();
        }

        public List<NotificationSettings> GetActiveSettings(LiveSplitState state)
        {
            if (state.Run.FilePath == null) return null;
            return SettingsDictionary.TryGetValue(state.Run.FilePath, out var value) ? value : null;
        }
    }
}