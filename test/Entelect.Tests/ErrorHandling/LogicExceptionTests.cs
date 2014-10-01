using System;
using Entelect.ErrorHandling;
using NUnit.Framework;

namespace Entelect.Tests.ErrorHandling
{
    [TestFixture]
    public class LogicExceptionTests
    {
        const string Message = "This is a message";
        private readonly Exception _exption = new Exception("Test Exception");
        [Test]
        public void AbilityToCreateLogicExptionWithLogicError()
        {
            var logicError = new TestLogicError();
            var logicException = new LogicException(logicError);
            CollectionAssert.IsNotEmpty(logicException.Errors);
            CollectionAssert.Contains(logicException.Errors,logicError);
        }

        [Test]
        public void AbilityToCreateLogicExptionWithLogicErrorAndDirectMessage()
        {
            var logicError = new TestLogicError();
            var logicException = new LogicException(Message, logicError);
            CollectionAssert.IsNotEmpty(logicException.Errors);
            CollectionAssert.Contains(logicException.Errors, logicError);
            StringAssert.Contains(logicException.Message, Message);
        }

        [Test]
        public void AbilityToCreateLogicExptionWithLogicErrorAndMessageInError()
        {
            var logicError = new TestLogicError(Message);
            var logicException = new LogicException(string.Empty, logicError);
            CollectionAssert.IsNotEmpty(logicException.Errors);
            CollectionAssert.Contains(logicException.Errors, logicError);
            StringAssert.Contains(logicException.Message, Message);
        }

        [Test]
        public void AbilityToCreateLogicExptionWithLogicErrorAndMessageAndInnerException()
        {
            var logicError = new TestLogicError();
            var logicException = new LogicException(Message, logicError, _exption);
            CollectionAssert.IsNotEmpty(logicException.Errors);
            CollectionAssert.Contains(logicException.Errors, logicError);
            Assert.NotNull(logicException.InnerException);
            Assert.AreEqual(logicException.InnerException, _exption);
        }

        [Test]
        public void AbilityToCreateLogicExptionWithLogicErrors()
        {
            var logicErrors = new LogicErrors();
            var logicException = new LogicException(logicErrors);
            CollectionAssert.IsEmpty(logicException.Errors);
        }

        [Test]
        public void AbilityToCreateLogicExptionWithLogicErrorsAndMessage()
        {
            var logicErrors = new LogicErrors();
            var logicException = new LogicException(Message, logicErrors);
            CollectionAssert.IsEmpty(logicException.Errors);
            StringAssert.Contains(Message,logicException.Message);
        }

        [Test]
        public void AbilityToCreateLogicExptionWithLogicErrorsAndInnerException()
        {
            var logicError = new TestLogicError();
            var logicException = new LogicException(logicError, _exption);
            CollectionAssert.IsNotEmpty(logicException.Errors);
            CollectionAssert.Contains(logicException.Errors, logicError);
            Assert.NotNull(logicException.InnerException);
            Assert.AreEqual(logicException.InnerException, _exption);
        }
    }
}