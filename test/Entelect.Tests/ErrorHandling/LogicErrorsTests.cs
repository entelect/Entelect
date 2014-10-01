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
    }
}