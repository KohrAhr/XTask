using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib.Security;

namespace Tests.Lib.Security
{
    [TestClass]
    public class TrypleDesDecrypt
    {
        [TestMethod]
        public void Decrypt1()
        {
            string result = SecurityFunctions.TripleDESDecryptFramework(
                UnitTestData.CONST_TEST_BYTE1, 
                UnitTestData.CONST_VALID_KEY1
            );
            Assert.AreEqual(result, UnitTestData.CONST_TEST_STRING1);
        }

        [TestMethod]
        public void Decrypt2()
        {
            string result = SecurityFunctions.TripleDESDecryptFramework(
                UnitTestData.CONST_TEST_BYTE2,
                UnitTestData.CONST_VALID_KEY1
            );
            Assert.AreEqual(result, UnitTestData.CONST_TEST_STRING2);
        }

        [TestMethod]
        public void Decrypt3()
        {
            string result = SecurityFunctions.TripleDESDecryptFramework(
                UnitTestData.CONST_TEST_BYTE3,
                UnitTestData.CONST_VALID_KEY2
            );
            Assert.AreEqual(result, UnitTestData.CONST_TEST_STRING3);
        }

        [TestMethod]
        public void Decrypt4()
        {
            string result = SecurityFunctions.TripleDESDecryptFramework(
                UnitTestData.CONST_TEST_BYTE4,
                UnitTestData.CONST_VALID_KEY2
            );
            Assert.AreEqual(result, UnitTestData.CONST_TEST_STRING4);
        }
    }
}
