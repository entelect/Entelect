using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
            var logicException = new LogicException(logicError, Message);
            CollectionAssert.IsNotEmpty(logicException.Errors);
            CollectionAssert.Contains(logicException.Errors, logicError);
            StringAssert.Contains(Message, logicException.Message);
        }

        [Test]
        public void AbilityToCreateLogicExptionWithLogicErrorAndMessageInError()
        {
            var logicError = new TestLogicError(Message);
            var logicException = new LogicException(logicError);
            CollectionAssert.IsNotEmpty(logicException.Errors);
            CollectionAssert.Contains(logicException.Errors, logicError);
            StringAssert.Contains(Message, logicException.Message);
        }

        [Test]
        public void AbilityToCreateLogicExptionWithLogicErrorAndMessageAndInnerException()
        {
            var logicError = new TestLogicError();
            var logicException = new LogicException(logicError, Message, _exption);
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
            var logicException = new LogicException(logicErrors, Message);
            CollectionAssert.IsEmpty(logicException.Errors);
            StringAssert.Contains(Message,logicException.Message);
        }

        [Test]
        public void AbilityToCreateLogicExptionWithLogicErrorsAndInnerException()
        {
            var logicError = new TestLogicError();
            var logicException = new LogicException(logicError, innerException: _exption);
            CollectionAssert.IsNotEmpty(logicException.Errors);
            CollectionAssert.Contains(logicException.Errors, logicError);
            Assert.NotNull(logicException.InnerException);
            Assert.AreEqual(logicException.InnerException, _exption);
        }

        [Test]
        public void SerializationIncludesMessage()
        {
            var logicError = new TestLogicError(Message);
            var logicException = new LogicException(logicError);
            var serializationInfo = new SerializationInfo(typeof (LogicException), new FormatterConverter());
            logicException.GetObjectData(serializationInfo, new StreamingContext());
            var serialisationMessage = (string)serializationInfo.GetValue("Message", typeof(string));
            StringAssert.Contains(Message, serialisationMessage);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SerializationThrowsExceptionIfInfoNull()
        {
            var logicError = new TestLogicError(Message);
            var logicException = new LogicException(logicError);
// ReSharper disable once AssignNullToNotNullAttribute want to force an exception for the test
            logicException.GetObjectData(null, new StreamingContext());
        }

        [Test]
        public void AbilityToCreateLogicExptionWithIEnumerableLogicError()
        {
            const string message1 = "Message 1";
            var error1 = new TestLogicError(message1);
            const string message2 = "Message 2";
            var error2 = new TestLogicError(message2);
            IEnumerable<LogicError> logicError = new List<LogicError> {error1, error2};
            var logicException = new LogicException(logicError);
            CollectionAssert.IsNotEmpty(logicException.Errors);
            CollectionAssert.Contains(logicException.Errors, error1);
            CollectionAssert.Contains(logicException.Errors, error2);
        }

        [Test]
        public void AbilityToCreateLogicExptionWithSerialisationInfo()
        {
            var logicErrors = new LogicErrors(new TestLogicError("Testing!"));
            new SerializableLogicExcpetion(logicErrors, "More Testing");
        }
    }
}