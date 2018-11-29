using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Lib.Security
{
    public static class UnitTestData
    {
        public const string CONST_VALID_KEY1 = "123456789012345678901234";
        public const string CONST_VALID_KEY2 = "ABCDEF0000ABCDEF00000**!";

        public const string CONST_INVALID_KEY1 = "123456789012345678901234A";
        public const string CONST_INVALID_KEY2 = "12345678901234567890123";
        public const string CONST_INVALID_KEY3 = "X";
        public const string CONST_INVALID_KEY4 = "4";

        public const string CONST_TEST_STRING1 = "test";
        public const string CONST_TEST_STRING2 = "*7y2h3rlzkj";
        public const string CONST_TEST_STRING3 = "Hack The Planet!";
        public const string CONST_TEST_STRING4 = " ";

        public static readonly byte[] CONST_TEST_BYTE1 = 
        {
            54, 45, 129, 138, 29, 231, 9, 69
        };
        public static readonly byte[] CONST_TEST_BYTE2 = 
        {
            230, 51, 1, 107, 239, 146, 224, 82, 109, 200, 113, 42, 173, 59, 34, 60
        };
        public static readonly byte[] CONST_TEST_BYTE3 = 
        {
            155, 86, 73, 208, 185, 134, 108, 190, 133, 155, 212, 247, 88, 75, 179, 143, 254, 142, 12, 38, 12, 146, 223, 131
        };
        public static readonly byte[] CONST_TEST_BYTE4 = 
        {
            95, 195, 144, 106, 133, 5, 219, 105
        };
    }
}
