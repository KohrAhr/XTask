using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib.System;

namespace Tests.Lib.System
{
    [TestClass]
    public class GetFQDN
    {
        [TestMethod]
        public void FqdnCannotBeEmpty()
        {
            Assert.AreNotEqual("", UserFunctions.GetFQDN());
        }

        [TestMethod]
        public void FqdnCannotBeNull()
        {
            Assert.AreNotEqual(null, UserFunctions.GetFQDN());
        }

        [TestMethod]
        public void FqdnMinLength()
        {
            Assert.IsTrue(UserFunctions.GetFQDN().Length > 0);
        }

        [TestMethod]
        public void FqdnCannotStartWithDot()
        {
            Assert.IsFalse(UserFunctions.GetFQDN().StartsWith("."));
        }

        [TestMethod]
        public void FqdnCannotContainSpecialChars()
        {
            string result = UserFunctions.GetFQDN();
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

            Assert.IsFalse(result.Contains("\""));
            Assert.IsFalse(result.Contains("/"));
            Assert.IsFalse(result.Contains("["));
            Assert.IsFalse(result.Contains("]"));
            Assert.IsFalse(result.Contains(";"));
            Assert.IsFalse(result.Contains("|"));
            Assert.IsFalse(result.Contains("="));
            Assert.IsFalse(result.Contains("+"));
            Assert.IsFalse(result.Contains("*"));
            Assert.IsFalse(result.Contains("?"));
            Assert.IsFalse(result.Contains("<"));
            Assert.IsFalse(result.Contains(">"));
        }

    }
}
