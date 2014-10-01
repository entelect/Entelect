namespace Entelect.ErrorHandling
{
    /// <summary>
    /// Logic errors are represents errors that can safely be displayed to the user.
    /// This is so that they know why something has gone wrong, instead of seeing a general error page and can possibly correct themselves.
    /// You can also use logic errors to validate multiple aspects of a class, 
    /// collect all the validation errors and return them at once instead of throwing a single exception for each
    /// </summary>
    public abstract class LogicError
    {
        /// <summary>
        /// Creates an instance of the logic error class.
        /// Logic errors are represents errors that can safely be displayed to the user.
        /// This is so that they know why something has gone wrong, instead of seeing a general error page and can possibly correct themselves.
        /// You can also use logic errors to validate multiple aspects of a class, 
        /// collect all the validation errors and return them at once instead of throwing a single exception for each
        /// </summary>
        protected LogicError()
            : this(null)
        {
                
        }

        /// <summary>
        /// Creates an instance of the logic error class.
        /// Logic errors are represents errors that can safely be displayed to the user.
        /// This is so that they know why something has gone wrong, instead of seeing a general error page and can possibly correct themselves.
        /// You can also use logic errors to validate multiple aspects of a class, 
        /// collect all the validation errors and return them at once instead of throwing a single exception for each
        /// </summary>
        /// <param name="message">The message to display to the end user of the system</param>
        protected LogicError(string message)
        {
            Message = message; 
        }

        /// <summary>
        /// The message to display to the end user of the system
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Creates an instance of the <see cref="T:Entelect.ErrorHandling.LogicException"/> class with this logic error contained in it and throws it as an exception.
        /// </summary>
        public void Throw()
        {
            throw AsException();
        }

        /// <summary>
        /// Creates an instance of the <see cref="T:Entelect.ErrorHandling.LogicException"/> class with this logic error contained in it
        /// </summary>
        /// <returns>An instance of the <see cref="T:Entelect.ErrorHandling.LogicException"/> class</returns>
        public LogicException AsException()
        {
            return new LogicException(this);
        }
    }
    
}
