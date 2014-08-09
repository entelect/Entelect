using NUnit.Framework;

namespace Entelect.Tests
{
    [TestFixture]
    public class BasicTest
    {
         [Test]
         public void OneEqualsOne()
         {
             Assert.AreEqual(1, 1);
         }
    }
}