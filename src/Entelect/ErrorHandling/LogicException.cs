using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Entelect.ErrorHandling
{
    /*todo rk, refactor these consturcotrs to use optional paramaters instead*/
    /* do we need to have the message param? */
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
        /// <param name="message">The message to display to the user</param>
        /// <param name="error">The error that caused the exception</param>
        public LogicException(string message, LogicError error)
            : base(message)
        {
            Errors = new LogicErrors {error};
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            /* todo rk, implement this correctly */
            base.GetObjectData(info, context);
        }

        /// <summary>
        /// Creates an instance of a logic exception.
        /// A logic exception is a way to interrupt the program flow that has failed due to one or more <see cref="T:Entelect.ErrorHandling.LogicError"/>
        /// </summary>
        /// <param name="message">The message to display to the user</param>
        /// <param name="error">The error that caused the exception</param>
        /// <param name="inner">The inner exception</param>
        public LogicException(string message, LogicError error, Exception inner)
            : base(message, inner)
        {
            Errors = new LogicErrors {error};
        }

        /// <summary>
        /// Creates an instance of a logic exception.
        /// A logic exception is a way to interrupt the program flow that has failed due to one or more <see cref="T:Entelect.ErrorHandling.LogicError"/>
        /// </summary>
        /// <param name="error">The error that caused the exception</param>
        public LogicException(LogicError error)
            : this(string.Empty, error)
        {

        }

        /// <summary>
        /// Creates an instance of a logic exception.
        /// A logic exception is a way to interrupt the program flow that has failed due to one or more <see cref="T:Entelect.ErrorHandling.LogicError"/>
        /// </summary>
        /// <param name="error">The error that caused the exception</param>
        /// <param name="inner">The inner exception</param>
        public LogicException(LogicError error, Exception inner)
            : this(string.Empty, error, inner)
        {

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
        /// Creates an instance of a logic exception.
        /// A logic exception is a way to interrupt the program flow that has failed due to one or more <see cref="T:Entelect.ErrorHandling.LogicError"/>
        /// </summary>
        /// <param name="message">The message to display to the user</param>
        /// <param name="errors">The collection of errors that caused this exception</param>
        public LogicException(string message, LogicErrors errors)
            : base(message)
        {
            Errors = errors;
        }
        /// <summary>
        /// Creates an instance of a logic exception.
        /// A logic exception is a way to interrupt the program flow that has failed due to one or more <see cref="T:Entelect.ErrorHandling.LogicError"/>
        /// </summary>
        /// <param name="errors">The collection of errors that caused this exception</param>
        public LogicException(LogicErrors errors)
            : this(errors.GetCombinedMessages(), errors)
        {
           
        }

        public override string Message
        {
            get
            {
                var currentMessage = base.Message;
                if (!string.IsNullOrWhiteSpace(currentMessage))
                {
                    return currentMessage;
                }
                if (Errors.Count == 0)
                {
                    return string.Empty;
                }
                if (Errors.Count == 1)
                {
                    return Errors.First().Message;
                }
                var stringBuilder = new StringBuilder();
                for (int index = 0; index < Errors.Count; index++)
                {
                    var logicError = Errors[index];
                    stringBuilder.AppendFormat("Error #{0}: {1}\r\n", index + 1, logicError.Message);
                }
                return stringBuilder.ToString();
            }
        }

        /// <summary>
        /// The collection of errors that caused this exception
        /// </summary>
        public LogicErrors Errors { get; set; }
    }
}
