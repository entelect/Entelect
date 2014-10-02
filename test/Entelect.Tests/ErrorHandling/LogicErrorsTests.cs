using System.Collections.Generic;
using Entelect.ErrorHandling;
using NUnit.Framework;

namespace Entelect.Tests.ErrorHandling
{
    [TestFixture]
    public class LogicErrorsTests
    {
        [Test]
        public void CanCreate()
        {
            var logicErrors = new LogicErrors();
            Assert.NotNull(logicErrors);
            CollectionAssert.IsEmpty(logicErrors);
            Assert.False(logicErrors.HasErrors);
        }

        [Test]
        public void CanCreateWithLogicError()
        {
            var testLogicError = new TestLogicError();
            var logicErrors = new LogicErrors(testLogicError);
            Assert.NotNull(logicErrors);
            CollectionAssert.IsNotEmpty(logicErrors);
            CollectionAssert.Contains(logicErrors, testLogicError);
            Assert.True(logicErrors.HasErrors);
        }

        [Test]
        public void CanCreateWithMultipleLogicError()
        {
            var testLogicError = new TestLogicError();
            var secondTestLogicError = new TestLogicError();
            var logicErrors = new LogicErrors(new[] {testLogicError, secondTestLogicError});
            Assert.NotNull(logicErrors);
            CollectionAssert.IsNotEmpty(logicErrors);
            CollectionAssert.Contains(logicErrors, testLogicError);
            CollectionAssert.Contains(logicErrors, secondTestLogicError);
            Assert.True(logicErrors.HasErrors);
        }

        [Test]
        public void CanCreateWithIEnumerableLogicError()
        {
            var testLogicError = new TestLogicError();
            var secondTestLogicError = new TestLogicError();
            IEnumerable<LogicError> errors = new[] {testLogicError, secondTestLogicError};
            var logicErrors = new LogicErrors(errors);
            Assert.NotNull(logicErrors);
            CollectionAssert.IsNotEmpty(logicErrors);
            CollectionAssert.Contains(logicErrors, testLogicError);
            CollectionAssert.Contains(logicErrors, secondTestLogicError);
            Assert.True(logicErrors.HasErrors);
        }

        [Test]
        public void AbilityToAddMultipleLogicErrorsAtOnceAfterConstructionWhenEmpty()
        {
            var testLogicError = new TestLogicError();
            var secondTestLogicError = new TestLogicError();
            var logicErrors = new LogicErrors();
            logicErrors.AddRange(new[] { testLogicError, secondTestLogicError });
            Assert.NotNull(logicErrors);
            CollectionAssert.IsNotEmpty(logicErrors);
            CollectionAssert.Contains(logicErrors, testLogicError);
            CollectionAssert.Contains(logicErrors, secondTestLogicError);
            Assert.True(logicErrors.HasErrors);
        }

        [Test]
        public void AbilityToAddMultipleLogicErrorsAtOnceAfterConstructionWhenNotEmpty()
        {
            var testLogicError = new TestLogicError();
            var secondTestLogicError = new TestLogicError();
            var logicErrors = new LogicErrors(testLogicError);
            logicErrors.AddRange(new[] { secondTestLogicError });
            Assert.NotNull(logicErrors);
            CollectionAssert.IsNotEmpty(logicErrors);
            CollectionAssert.Contains(logicErrors, testLogicError);
            CollectionAssert.Contains(logicErrors, secondTestLogicError);
            Assert.True(logicErrors.HasErrors);
        }

        [Test]
        [ExpectedException(typeof(LogicException))]
        public void ThrowExceptionIfErrors()
        {
            var testLogicError = new TestLogicError();
            var logicErrors = new LogicErrors(testLogicError);
            logicErrors.ThrowExceptionIfErrors();
        }
        [Test]
        public void GetCombinedMessagesWithMultipleMessages()
        {
            const string message1 = "Message 1";
            var testLogicError1 = new TestLogicError(message1);
            const string message2 = "Message 2";
            var testLogicError2 = new TestLogicError(message2);
            var logicErrors = new LogicErrors(new[] {testLogicError1, testLogicError2});
            var combinedMessage = logicErrors.GetCombinedMessages();
            StringAssert.Contains(message1, combinedMessage);
            StringAssert.Contains(message2, combinedMessage);
        }
    }
}