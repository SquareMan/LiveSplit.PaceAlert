using System.Diagnostics;
using System.Linq;
using LiveSplit.PaceAlert.Logic;
using LiveSplit.UI;

namespace LiveSplit.PaceAlert.Api
{
    public static class Api
    {
        /// <param name="layout">The layout to search</param>
        /// <returns>Reference to a PaceAlert component in a layout or null if none exists</returns>
        public static PaceAlertComponent GetComponent(ILayout layout)
        {
            return layout.Components.FirstOrDefault(component => component is PaceAlertComponent) as PaceAlertComponent;
        }

        /// <summary>
        /// Registers a custom trigger type. If a trigger with the same tag has already been registered no changes will
        /// be made.
        /// </summary>
        /// <param name="trigger">Trigger Type to add.</param>
        /// <returns>Whether the trigger was successfully added.</returns>
        public static bool AddTrigger(ITrigger trigger)
        {
            return NotificationManager.AddTrigger(trigger);
        }

        /// <summary>
        /// Registers a custom condition type. If a condition with the same tag has already been registered no changes
        /// will be made.
        /// </summary>
        /// <param name="condition">Condition Type to add</param>
        /// <returns>Whether the condition was successfully added.</returns>
        public static bool AddCondition(ICondition condition)
        {
            return NotificationManager.AddCondition(condition);
        }

        /// <summary>
        /// Register a custom variable. If a variable with the same keyword has already been registered no changes will
        /// be made.
        /// </summary>
        /// <param name="variable">Variable to register.</param>
        /// <returns>Whether the variable was successfully added.</returns>
        public static bool AddVariable(IVariable variable)
        {
            return NotificationManager.AddVariable(variable);
        }
    }
}