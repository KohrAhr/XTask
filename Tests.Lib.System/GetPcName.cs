using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib.System;

namespace Tests.Lib.System
{
    /// <summary>
    ///     Read more at: https://support.microsoft.com/en-us/help/909264/naming-conventions-in-active-directory-for-computers-domains-sites-and
    /// </summary>
    [TestClass]
    public class GetPcName
    {
        [TestMethod]
        public void PcNameCannotBeEmpty()
        {
            Assert.AreNotEqual("", UserFunctions.GetPcName());
        }

        [TestMethod]
        public void PcNameCannotBeNull()
        {
            Assert.AreNotEqual(null, UserFunctions.GetPcName());
        }

        [TestMethod]
        public void PcNameMaxLength()
        {
            Assert.IsTrue(UserFunctions.GetPcName().Length < 16);
        }

        [TestMethod]
        public void PcNameMinLength()
        {
            Assert.IsTrue(UserFunctions.GetPcName().Length > 0);
        }

        [TestMethod]
        public void PcNameCannotStartWithDot()
        {
            Assert.IsFalse(UserFunctions.GetPcName().StartsWith("."));
        }

        [TestMethod]
        public void PcNameCannotContainSpecialChars()
        {
            string result = UserFunctions.GetPcName();
            Assert.IsFalse(result.Contains(","));
            Assert.IsFalse(result.Contains("~"));
            Assert.IsFalse(result.Contains(":"));
            Assert.IsFalse(result.Contains("!"));
            Assert.IsFalse(result.Contains("@"));
            Assert.IsFalse(result.Contains("#"));
            Assert.IsFalse(result.Contains("$"));
            Assert.IsFalse(result.Contains("%"));
            Assert.IsFalse(result.Contains("^"));
            Assert.IsFalse(result.Contains("&"));
            Assert.IsFalse(result.Contains("'"));
            Assert.IsFalse(result.Contains("."));
            Assert.IsFalse(result.Contains(")"));
            Assert.IsFalse(result.Contains("("));
            Assert.IsFalse(result.Contains(" "));
            Assert.IsFalse(result.Contains("_"));
        }
    }
}
