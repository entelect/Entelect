using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Entelect.ErrorHandling
{
    /// <summary>
    /// A logic exception is a way to interrupt the program flow that has failed due to one or more <see cref="T:Entelect.ErrorHandling.LogicError"/>
    /// </summary>
    [Serializable]
    public class LogicException : Exception
    {
        /// <summary>
        /// Creates an instance of a logic exception.
        /// A logic exception is a way to interrupt the program flow that has failed due to one or more <see cref="T:Entelect.ErrorHandling.LogicError"/>
        /// </summary>
        /// <param name="error">The error that caused the exception</param>
        /// <param name="additionalMessage">Any additional information to display about the exception</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public LogicException(LogicError error, string additionalMessage = null, Exception innerException = null)
            : this(new LogicErrors(error), additionalMessage, innerException)
        {

        }

        /// <summary>
        /// Creates an instance of a logic exception.
        /// A logic exception is a way to interrupt the program flow that has failed due to one or more <see cref="T:Entelect.ErrorHandling.LogicError"/>
        /// </summary>
        /// <param name="errors">The collection of errors that caused this exception</param>
        /// <param name="additionalMessage">Any additional information to display about the exception</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public LogicException(IEnumerable<LogicError> errors, string additionalMessage = null, Exception innerException = null)
            : this(new LogicErrors(errors), additionalMessage, innerException)
        {
            
        }

        /// <summary>
        /// Creates an instance of a logic exception.
        /// A logic exception is a way to interrupt the program flow that has failed due to one or more <see cref="T:Entelect.ErrorHandling.LogicError"/>
        /// </summary>
        /// <param name="errors">The collection of errors that caused this exception</param>
        /// <param name="additionalMessage">Any additional information to display about the exception</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public LogicException(LogicErrors errors, string additionalMessage = null, Exception innerException = null)
            : base(GetAllMessages(additionalMessage, errors), innerException)
        {
            Errors = errors;
            AdditionalMessage = additionalMessage;
        }

        /// <summary>
        /// Creates an instance of a logic exception.
        /// A logic exception is a way to interrupt the program flow that has failed due to one or more <see cref="T:Entelect.ErrorHandling.LogicError"/>
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown. </param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination. </param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected LogicException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Errors = new LogicErrors();
        }

        /// <summary>
        /// Sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is a null reference.</exception>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue("Errors", Errors);
            info.AddValue("AdditionalMessage", AdditionalMessage);
            base.GetObjectData(info, context);
        }

        public override string Message
        {
            get { return GetAllMessages(AdditionalMessage, Errors); }
        }

        /// <summary>
        /// Combines the AdditionalMessage and the messages within all the Errors into one display string with newline characters
        /// </summary>
        /// <param name="message"></param>
        /// <param name="logicErrors"></param>
        /// <returns></returns>
        protected static string GetAllMessages(string message, LogicErrors logicErrors)
        {
            var stringBuilder = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(message))
            {
                stringBuilder.AppendLine(message);
            }
            stringBuilder.Append(logicErrors.GetCombinedMessages());
            return stringBuilder.ToString();
        }

        /// <summary>
        /// The collection of errors that caused this exception
        /// </summary>
        public LogicErrors Errors { get; set; }

        /// <summary>
        /// Any additional information to display about the exception
        /// </summary>
        public string AdditionalMessage { get; set; }
    }
}
