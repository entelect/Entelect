namespace Entelect.ErrorHandling
{
    /// <summary>
    /// Error to use when the supplied argument was null
    /// </summary>
    public class ArgumentNullError : LogicError
    {
        /// <summary>
        /// Error to use when the supplied argument was null
        /// </summary>
        /// <param name="parameterName">The name of the parameter that was supplied which was null</param>
        public ArgumentNullError(string parameterName)
            : base(string.Format("{0} cannot be null.", parameterName))
        {
        }
    }
}