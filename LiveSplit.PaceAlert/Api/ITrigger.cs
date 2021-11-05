namespace LiveSplit.PaceAlert.Api
{
    /// <summary>
    /// Represents a unique Trigger type. A trigger is a discrete event (such as splitting) that causes a notification's
    /// conditions to be evaluated.
    /// </summary>
    public interface ITrigger
    {
        /// <summary>
        /// Returns the tag used to serialize this trigger in the user's settings. A tag should be unique to avoid
        /// any potential conflicts between two plugins. A suggestion for a tag name would be your trigger prefaced by
        /// your component name (e.g. PaceAlert.Split)
        /// </summary>
        /// <returns>Tag used for serialization</returns>
        string GetTag();
        
        /// <returns>A string to be displayed in the UI for this trigger type.</returns>
        string GetTitle();
    }
}