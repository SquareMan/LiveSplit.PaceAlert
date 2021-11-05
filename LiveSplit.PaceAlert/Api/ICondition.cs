using LiveSplit.PaceAlert.Logic;

namespace LiveSplit.PaceAlert.Api
{
    /// <summary>
    /// Represents a unique Condition Type. A notification has 0 or more conditions attached that will be evaluated when
    /// it's trigger is triggered.
    /// </summary>
    public interface ICondition
    {
        /// <summary>
        /// Returns the tag used to serialize this condition in the user's settings. A tag should be unique to avoid
        /// any potential conflicts between two plugins. A suggestion for a tag name would be your condition prefaced by
        /// your component name (e.g. PaceAlert.CurrentTime)
        /// </summary>
        /// <returns>Tag used for serialization</returns>
        string GetTag();
        
        /// <returns>A string to be displayed in the UI for this condition type.</returns>
        string GetTitle();

        /// <summary>
        /// Evaluate if this condition has been met.
        /// </summary>
        /// <param name="stats"></param>
        /// <returns>Bool representing if this condition is met.</returns>
        bool Evaluate(NotificationManager.NotificationStats stats);
    }
}