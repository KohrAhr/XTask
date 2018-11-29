using System;
using Lib.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Lib.Security
{
    [TestClass]
    public class TrypleDesEncrypt
    {
        [TestMethod]
        public void Encrypt1()
        {
            byte[] result = SecurityFunctions.TripleDESEncryptFramework(
                UnitTestData.CONST_TEST_STRING1, 
                UnitTestData.CONST_VALID_KEY1
            );
            CollectionAssert.AreEqual(result, UnitTestData.CONST_TEST_BYTE1);
        }

        [TestMethod]
        public void Encrypt2()
        {
            byte[] result = SecurityFunctions.TripleDESEncryptFramework(
                UnitTestData.CONST_TEST_STRING2,
                UnitTestData.CONST_VALID_KEY1
            );
            CollectionAssert.AreEqual(result, UnitTestData.CONST_TEST_BYTE2);
        }

        [TestMethod]
        public void Encrypt3()
        {
            byte[] result = SecurityFunctions.TripleDESEncryptFramework(
                UnitTestData.CONST_TEST_STRING3,
                UnitTestData.CONST_VALID_KEY2
            );
            CollectionAssert.AreEqual(result, UnitTestData.CONST_TEST_BYTE3);
        }

        [TestMethod]
        public void Encrypt4()
        {
            byte[] result = SecurityFunctions.TripleDESEncryptFramework(
                UnitTestData.CONST_TEST_STRING4,
                UnitTestData.CONST_VALID_KEY2
            );
            CollectionAssert.AreEqual(result, UnitTestData.CONST_TEST_BYTE4);
        }
    }
}
