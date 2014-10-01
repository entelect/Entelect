using System.Runtime.InteropServices;
using Entelect.ErrorHandling;
using NUnit.Framework;

namespace Entelect.Tests.ErrorHandling
{
    [TestFixture]
    public class ArgumentNullErrorTests
    {
        private const string paramName = "Potato";

        [Test]
        public void CanCreateArgumentNullError()
        {
            var argumentNullError = new ArgumentNullError(paramName);
            StringAssert.Contains(paramName, argumentNullError.Message);
        }
    }
}