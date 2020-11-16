using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using KenticoCommunity.UpsertAlternativeForms.Helpers;


namespace UpsertAlternativeForms.Tests.Helpers
{
    class AlternativeFormNameHelperTests
    {
        [TestCase("Custom.Type.Update", "Custom.Type", "Update")]
        [TestCase("a.b.c", "a.b", "c")]
        [TestCase("b.c", "b", "c")]
        public void ParseAlternativeFormFullName_Returns_Expected_Result(string altnernativeFormFullName, string expectedClassName, string expectedFormName)
        {
            var result = AlternativeFormNameHelper.ParseAlternativeFormFullName(altnernativeFormFullName);
            Assert.AreEqual(expectedClassName, result.ClassName);
            Assert.AreEqual(expectedFormName, result.FormName);
        }

        [Test]
        public void ParseAlternativeFormFullName_ShouldThrow_ArgumentException_If_Empty()
        {
            Assert.That(() => AlternativeFormNameHelper.ParseAlternativeFormFullName(string.Empty), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ParseAlternativeFormFullName_ShouldThrow_ArgumentException_If_No_Delimiter()
        {
            Assert.That(() => AlternativeFormNameHelper.ParseAlternativeFormFullName("ab"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ParseAlternativeFormFullName_ShouldThrow_ArgumentNullException()
        {
            Assert.That(() => AlternativeFormNameHelper.ParseAlternativeFormFullName(null), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase("Custom.Type.Update", true)]
        [TestCase("Custom.Type.Insert", true)]
        [TestCase("Custom.Type.NewCulture", true)]
        [TestCase("custom.type.update", true)]
        [TestCase("custom.type.insert", true)]
        [TestCase("custom.type.newculture", true)]
        [TestCase("Type.Update", true)]
        [TestCase("Type.Insert", true)]
        [TestCase("Type.NewCulture", true)]
        [TestCase("Custom.Type.Upsert", false)]
        [TestCase("Custom.Type.upsert", false)]
        [TestCase("Custom.Type.Subscribe", false)]
        [TestCase("Custom.Type.Unknown", false)]
        public void IsBuiltInPageTypeFormName_Returns_Expected_Result(string altnernativeFormFullName, bool expectedResult)
        {
            var result = AlternativeFormNameHelper.IsBuiltInPageTypeFormName(altnernativeFormFullName);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IsBuiltInPageTypeFormName_ShouldThrow_ArgumentException()
        {
            Assert.That(() => AlternativeFormNameHelper.IsBuiltInPageTypeFormName(string.Empty), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void IsBuiltInPageTypeFormName_ShouldThrow_ArgumentNullException()
        {
            Assert.That(() => AlternativeFormNameHelper.IsBuiltInPageTypeFormName(null), Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase("Custom.Type.Update", "Custom.Type.Upsert")]
        [TestCase("Custom.Type.Insert", "Custom.Type.Upsert")]
        [TestCase("Custom.Type.NewCulture", "Custom.Type.Upsert")]
        [TestCase("custom.type.update", "custom.type.Upsert")]
        [TestCase("custom.type.insert", "custom.type.Upsert")]
        [TestCase("custom.type.newculture", "custom.type.Upsert")]
        [TestCase("Type.Update", "Type.Upsert")]
        [TestCase("Type.Insert", "Type.Upsert")]
        [TestCase("Type.NewCulture", "Type.Upsert")]
        [TestCase("Custom.Type.Upsert", "Custom.Type.Upsert")]
        [TestCase("Custom.Type.upsert", "Custom.Type.Upsert")]
        [TestCase("Custom.Type.Subscribe", "Custom.Type.Upsert")]
        [TestCase("Custom.Type.Unknown", "Custom.Type.Upsert")]
        public void CreateUpsertFullName_Returns_Expected_Result(string altnernativeFormFullName, string expectedResult)
        {
            var result = AlternativeFormNameHelper.CreateUpsertFullName(altnernativeFormFullName);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CreateUpsertFullName_ShouldThrow_ArgumentException()
        {
            Assert.That(() => AlternativeFormNameHelper.CreateUpsertFullName(string.Empty), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void CreateUpsertFullName_ShouldThrow_ArgumentNullException()
        {
            Assert.That(() => AlternativeFormNameHelper.CreateUpsertFullName(null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
