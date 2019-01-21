using Lib.Security;
using Lib.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptionServer.NetCoreWebApp.Functions
{
    public class Core
    {
        public string Crypt(string blankValue)
        {
            string result = "";

            if (!String.IsNullOrEmpty(blankValue))
            {
                byte[] data = SecurityFunctions.TripleDESEncryptFramework(blankValue, CoreData.SecurityKey);
                result = StringsFunctions.BytesAsHexString(data);
            }

            return result;
        }

        public string Decrypt(string xValue)
        {
            string result = "";

            if (!String.IsNullOrEmpty(xValue))
            {
                byte[] data = StringsFunctions.StringToByteArray(xValue);
                result = SecurityFunctions.TripleDESDecryptFramework(data, CoreData.SecurityKey);
            }

            return result;
        }

    }
}
