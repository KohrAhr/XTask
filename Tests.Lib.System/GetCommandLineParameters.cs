using System;
using System.Windows;
using System.Collections.Generic;
using Lib.System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Lib.System
{
    [TestClass]
    public class GetCommandLineParameters
    {
        [TestMethod]
        public void TestWithNull()
        {
            string[] request = null;

            Dictionary<string, string> result = CommandLineFunctions.GetCommandLineParameters(request);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestWithoutParameter()
        {
            string[] request = new string[]
            {
                ""
            };

            Dictionary<string, string> result = CommandLineFunctions.GetCommandLineParameters(request);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestWithOneBadParameter()
        {
            string[] request = new string[]
            {
                "1212"
            };

            Dictionary<string, string> result = CommandLineFunctions.GetCommandLineParameters(request);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestWithOtherBadParameter()
        {
            string[] request = new string[]
            {
                "=1212"
            };

            Dictionary<string, string> result;
            result = CommandLineFunctions.GetCommandLineParameters(request);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestWithOneBadAndOneGoodParameter()
        {
            string[] request = new string[]
            {
                "1212",
                "x=x"
            };

            Dictionary<string, string> expectedResult = new Dictionary<string, string>()
            {
                { "x", "x" }
            };

            Dictionary<string, string> result;
            result = CommandLineFunctions.GetCommandLineParameters(request);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestWithThreeBadParameters()
        {
            string[] request = new string[]
            {
                "1212",
                "847tyhperuogij",
                "9w874r78u8ijogrek",
            };

            Dictionary<string, string> result;
            result = CommandLineFunctions.GetCommandLineParameters(request);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestWithFourGoodParameters()
        {
            string[] request = new string[]
            {
                "1=1212",
                "222=847tyhperuogij",
                "iwrjiowjrtw==9w874r78u8ijogrek",
                "test=key1=z1=z2",
            };

            Dictionary<string, string> expectedResult = new Dictionary<string, string>()
            {
                { "1", "1212" },
                { "222", "847tyhperuogij" },
                { "iwrjiowjrtw", "=9w874r78u8ijogrek" },
                { "test", "key1=z1=z2" }
            };

            Dictionary<string, string> result = CommandLineFunctions.GetCommandLineParameters(request);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestWithKeyNameWithSpace()
        {
            string[] request = new string[]
            {
                "1 =1212",
                "222 =847tyhperuogij",
                "    iwrjiowjrtw ==9w874r78u8ijogrek",
                " test =key1=z1=z2",
            };

            Dictionary<string, string> expectedResult = new Dictionary<string, string>()
            {
                { "1", "1212" },
                { "222", "847tyhperuogij" },
                { "iwrjiowjrtw", "=9w874r78u8ijogrek" },
                { "test", "key1=z1=z2" }
            };

            Dictionary<string, string> result = CommandLineFunctions.GetCommandLineParameters(request);

            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestWithStrangKeyNames()
        {
            string[] request = new string[]
            {
                "&^*^%=!@#@#!",
                "!======"
            };

            Dictionary<string, string> expectedResult = new Dictionary<string, string>()
            {
                { "&^*^%", "!@#@#!" },
                { "!", "=====" }
            };

            Dictionary<string, string> result = CommandLineFunctions.GetCommandLineParameters(request);

            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}
