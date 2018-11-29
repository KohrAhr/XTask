using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib.System;

namespace Tests.Lib.System
{
    /// <summary>
    ///     Read more at: https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-2000-server/bb726984(v=technet.10)
    /// </summary>
    [TestClass]
    public class GetUsername
    {
        [TestMethod]
        public void UserNameCannotBeEmpty()
        {
            Assert.AreNotEqual("", UserFunctions.GetUsername());
        }

        [TestMethod]
        public void UserNameCannotBeNull()
        {
            Assert.AreNotEqual(null, UserFunctions.GetUsername());
        }

        [TestMethod]
        public void UserNameMaxLength()
        {
            Assert.IsTrue(UserFunctions.GetUsername().Length < 16);
        }

        [TestMethod]
        public void UserNameMinLength()
        {
            Assert.IsTrue(UserFunctions.GetUsername().Length > 0);
        }

        [TestMethod]
        public void UserNameCannotContainSpecialChars()
        {
            string result = UserFunctions.GetUsername();
            Assert.IsFalse(result.Contains("\""));
            Assert.IsFalse(result.Contains("/"));
            Assert.IsFalse(result.Contains(@"\"));
            Assert.IsFalse(result.Contains("["));
            Assert.IsFalse(result.Contains("]"));
            Assert.IsFalse(result.Contains(":"));
            Assert.IsFalse(result.Contains(";"));
            Assert.IsFalse(result.Contains("|"));
            Assert.IsFalse(result.Contains("="));
            Assert.IsFalse(result.Contains(","));
            Assert.IsFalse(result.Contains("+"));
            Assert.IsFalse(result.Contains("*"));
            Assert.IsFalse(result.Contains("?"));
            Assert.IsFalse(result.Contains("<"));
            Assert.IsFalse(result.Contains(">"));
        }
    }
}
