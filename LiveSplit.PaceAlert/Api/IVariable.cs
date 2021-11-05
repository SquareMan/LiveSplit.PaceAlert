using LiveSplit.PaceAlert.Logic;

namespace LiveSplit.PaceAlert.Api
{
    /// <summary>
    /// Represents a unique Variable. A Variable in a message template is evaluated and replaced before sending the
    /// message.
    /// </summary>
    public interface IVariable
    {
        /// <returns>The keyword for this variable. The user will surround the keyword with $() in a message template to
        /// evaluate this variable. 
        /// </returns>
        string GetKeyword();

        /// <summary>
        /// Evaluate and return the text to replace this variable with
        /// </summary>
        /// <param name="stats"></param>
        /// <returns>Text to replace this variable with</returns>
        string Evaluate(NotificationManager.NotificationStats stats);
    }
}