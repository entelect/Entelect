using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Entelect.ErrorHandling
{
    /// <summary>
    /// A collection of <see cref="T:Entelect.ErrorHandling.LogicError"/>
    /// Contains a set of helper methods that makes working with multiple logic errors easier.
    /// </summary>
    public class LogicErrors : Collection<LogicError>
    {
        /// <summary>
        /// Checks if the current collection has any items
        /// </summary>
        public bool HasErrors
        {
            get { return Count > 0; }
        }

        /// <summary>
        /// Throws a LogicException with all errors in this list.
        /// Will NOT throw an exception if there are no errors (duh!)
        /// </summary>
        public void ThrowExceptionIfErrors()
        {
            if (HasErrors)
                throw new LogicException(this);
        }

        /// <summary>
        /// Returns a list of all the error messages in all logic errors. 
        /// </summary>
        /// <returns></returns>
        public string GetCombinedMessages()
        {
            var builder = new StringBuilder();
            foreach (var error in this)
            {
                builder.AppendLine(error.Message ?? error.ToString());
            }
            return builder.ToString();
        }

        /// <summary>
        /// Adds the supplied logic errors to the collection
        /// </summary>
        /// <param name="errors"></param>
        public void AddRange(IEnumerable<LogicError> errors)
        {
            foreach (var logicError in errors)
            {
                Add(logicError);
            }
        }

    }
}