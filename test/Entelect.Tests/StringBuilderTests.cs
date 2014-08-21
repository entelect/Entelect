using System;
using System.Text;
using NUnit.Framework;
using Entelect.Extensions;
namespace Entelect.Tests
{
    [TestFixture]
    public class StringBuilderTests
    {
        [Test]
        public void AddingIntAndNewline()
        {
            var sb = new StringBuilder();
            sb.AppendLineFormat("SomeStuff{0}", 1);
            Assert.AreEqual(string.Format("SomeStuff1{0}", Environment.NewLine), sb.ToString());
        }
         
    }
}