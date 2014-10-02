using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        /// A collection of <see cref="T:Entelect.ErrorHandling.LogicError"/>
        /// Contains a set of helper methods that makes working with multiple logic errors easier.
        /// </summary>
        public LogicErrors()
        {
        }

        /// <summary>
        /// A collection of <see cref="T:Entelect.ErrorHandling.LogicError"/>
        /// Contains a set of helper methods that makes working with multiple logic errors easier.
        /// </summary>
        /// <param name="list">The collection of <see cref="T:Entelect.ErrorHandling.LogicError"/> to be contained in the list</param>
        public LogicErrors(IList<LogicError> list) 
            : base(list)
        {
        }

        /// <summary>
        /// A collection of <see cref="T:Entelect.ErrorHandling.LogicError"/>
        /// Contains a set of helper methods that makes working with multiple logic errors easier.
        /// </summary>
        /// <param name="list">The collection of <see cref="T:Entelect.ErrorHandling.LogicError"/> to be contained in the list</param>
        public LogicErrors(IEnumerable<LogicError> list)
            : base(list.ToList())
        {
        }

        /// <summary>
        /// A collection of <see cref="T:Entelect.ErrorHandling.LogicError"/>
        /// Contains a set of helper methods that makes working with multiple logic errors easier.
        /// </summary>
        /// <param name="error">The initial error to include in the collection</param>
        public LogicErrors(LogicError error)
            : base(new Collection<LogicError> {error})
        {

        }

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
            if (Count == 0)
            {
                return string.Empty;
            }
            if (Count == 1)
            {
                return this.First().Message;
            }
            var stringBuilder = new StringBuilder();
            for (var index = 0; index < Count; index++)
            {
                var logicError = this[index];
                if (!string.IsNullOrWhiteSpace(logicError.Message))
                {
                    stringBuilder.AppendFormat("Error #{0}: {1}{2}", index + 1, logicError.Message, Environment.NewLine);
                }
                else
                {
                    stringBuilder.AppendFormat("Error #{0}: {1}{2}", index + 1, logicError.GetType().Name, Environment.NewLine);
                }
            }
            return stringBuilder.ToString();
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