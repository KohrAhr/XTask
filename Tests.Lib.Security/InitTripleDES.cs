using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib.Security;
using System.Security.Cryptography;
using Lib.Strings;

namespace Tests.Lib.Security
{
    [TestClass]
    public class InitTripleDES
    {
        [TestMethod]
        public void TestConstructor_ValidKey1()
        {
            TripleDES result = SecurityFunctions.InitTripleDES(StringsFunctions.StringToUtf8Bytes(UnitTestData.CONST_VALID_KEY1));

            Assert.AreNotEqual(result, null);
        }

        [TestMethod]
        public void TestConstructor_ValidKey2()
        {
            TripleDES result = SecurityFunctions.InitTripleDES(StringsFunctions.StringToUtf8Bytes(UnitTestData.CONST_VALID_KEY2));

            Assert.AreNotEqual(result, null);
        }

        [TestMethod]
        public void TestConstructor_NotValidKey1()
        {
            try
            {
                TripleDES result = SecurityFunctions.InitTripleDES(StringsFunctions.StringToUtf8Bytes(UnitTestData.CONST_INVALID_KEY1));

                Assert.Fail();
            }
            catch (CryptographicException)
            {

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestConstructor_NotValidKey2()
        {
            try
            {
                TripleDES result = SecurityFunctions.InitTripleDES(StringsFunctions.StringToUtf8Bytes(UnitTestData.CONST_INVALID_KEY2));

                Assert.Fail();
            }
            catch (CryptographicException)
            {

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestConstructor_NotValidKey3()
        {
            try
            {
                TripleDES result = SecurityFunctions.InitTripleDES(StringsFunctions.StringToUtf8Bytes(UnitTestData.CONST_INVALID_KEY3));

                Assert.Fail();
            }
            catch (CryptographicException)
            {

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestConstructor_NotValidKey4()
        {
            try
            {
                TripleDES result = SecurityFunctions.InitTripleDES(StringsFunctions.StringToUtf8Bytes(UnitTestData.CONST_INVALID_KEY4));

                Assert.Fail();
            }
            catch (CryptographicException)
            {

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
