using System;
using Entelect.ErrorHandling;
using NUnit.Framework;

namespace Entelect.Tests.ErrorHandling
{
    [TestFixture]
    public class LogicErrorTests
    {
        const string Message = "This is a message";

        [Test]
        public void CanCreateEmptyLogicError()
        {
            var testLogicError = new TestLogicError();
            Assert.True(string.IsNullOrWhiteSpace(testLogicError.Message));
        }
        [Test]
        public void CanCreateLogicErrorWithMessage()
        {
            var testLogicError = new TestLogicError("This is a message");
            StringAssert.Contains(Message, testLogicError.Message);
        }

        [Test]
        public void CanCreateException()
        {
            var testLogicErrorException = new TestLogicError().AsException();
            Assert.True(testLogicErrorException != null);
        }
        [Test]
        public void CanCreateExceptionWhenMessageSet()
        {
            var testLogicErrorException = new TestLogicError(Message).AsException();
            Assert.True(testLogicErrorException != null);
        }

        [Test]
        [ExpectedException(typeof(LogicException))]
        public void CanBeThrownAsException()
        {
            new TestLogicError().Throw();
        }
        [Test]
        [ExpectedException(typeof(LogicException))]
        public void CanBeThrownAsExceptionWhenMessageSet()
        {
            new TestLogicError(Message).Throw();
        }
    }
}