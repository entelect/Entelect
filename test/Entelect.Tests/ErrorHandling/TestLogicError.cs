using Entelect.ErrorHandling;

namespace Entelect.Tests.ErrorHandling
{
    public class TestLogicError : LogicError
    {
        public TestLogicError()
        {
        }

        public TestLogicError(string message) 
            : base(message)
        {
        }
    }
}