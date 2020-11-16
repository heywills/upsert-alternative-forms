using NUnit.Framework;
using System;
using KenticoCommunity.UpsertAlternativeForms.Helpers;

namespace KenticoCommunity.UpsertAlternativeForms.Tests.Helpers
{
    [TestFixture]
    public class GuardTests
    {
        [TestCase("hi", "name")]
        [TestCase("hi", null)]
        [TestCase("", "name")]
        [TestCase(typeof(Object), "name")]
        public void ArgumentNotNull_ShouldSucceed(object value, string name)
        {
            Guard.ArgumentNotNull(value, name);
        }

        [Test]
        public void ArgumentNotNull_ShouldThrow_ArgumentNullException()
        {
            Assert.That(() => Guard.ArgumentNotNull(null, "name"), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase("hi", "name")]
        [TestCase("hi", null)]
        [TestCase("a", "name")]
        public void ArgumentNotNullOrEmpty_ShouldSucceed(string value, string name)
        {
            Guard.ArgumentNotNullOrEmpty(value, name);
        }

        [Test]
        public void ArgumentNotNullOrEmpty_ShouldThrow_ArgumentException()
        {
            Assert.That(() => Guard.ArgumentNotNullOrEmpty(string.Empty, "name"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ArgumentNotNullOrEmpty_ShouldThrow_ArgumentNullException()
        {
            Assert.That(() => Guard.ArgumentNotNullOrEmpty(null, "name"), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
