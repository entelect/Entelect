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

        [Test]
        public void AddingIntIntAndNewline()
        {
            var sb = new StringBuilder();
            sb.AppendLineFormat("SomeStuff{0}{1}", 1, 2);
            Assert.AreEqual(string.Format("SomeStuff12{0}", Environment.NewLine), sb.ToString());
        }

        [Test]
        public void AddingIntIntIntAndNewline()
        {
            var sb = new StringBuilder();
            sb.AppendLineFormat("SomeStuff{0}{1}{2}", 1, 2, 3);
            Assert.AreEqual(string.Format("SomeStuff123{0}", Environment.NewLine), sb.ToString());
        }

        [Test]
        public void AddingIntIntIntIntAndNewline()
        {
            var sb = new StringBuilder();
            sb.AppendLineFormat("SomeStuff{0}{1}{2}{3}", 1, 2, 3, 4);
            Assert.AreEqual(string.Format("SomeStuff1234{0}", Environment.NewLine), sb.ToString());
        }
    }
}