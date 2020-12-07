using System;
using System.Reflection;
using LiveSplit.Model;
using LiveSplit.PaceAlert.Logic;
using LiveSplit.UI.Components;

[assembly: ComponentFactory(typeof(PaceAlertFactory))]

namespace LiveSplit.PaceAlert.Logic
{
    public class PaceAlertFactory : IComponentFactory
    {
        public const string PaceAlertName = "Pace Alert";
        
        public IComponent Create(LiveSplitState state) => new PaceAlertComponent(state);

        public string ComponentName => PaceAlertName;
        public string Description => "Small Discord Bot that can send alerts when a specified pace is reached.";
        public ComponentCategory Category => ComponentCategory.Other;

        public string UpdateName => $"{ComponentName} v{Version.ToString(3)}";
        public string UpdateURL => "https://raw.githubusercontent.com/SquareMan/LiveSplit.PaceAlert/master/LiveSplit.PaceAlert/";
        public string XMLURL => UpdateURL + "Components/Updates.xml";
        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    }
}