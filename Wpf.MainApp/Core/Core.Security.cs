using Lib.Security;
using Lib.Strings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Wpf.GridView.Functions;

namespace Wpf.GridView.Core
{
    public static class SecurityCore
    {
        const string CONST_SERVER_ERROR = "<Remote Server Error>";

        public async static Task<string> GetEncryptedData(string data)
        {
            string result;

            if (CoreData.RemoteEncryptionServerType == CoreData.RemoteEncryptionServerTypes.rtBuildInLocalMustBeRemovedBeforeRelease)
            {
                byte[] resultAsBytes = SecurityFunctions.TripleDESEncryptFramework(data, CoreData.EncryptionKey);

                result = StringsFunctions.BytesAsHexString(resultAsBytes, " ");
            }
            else
            if (CoreData.RemoteEncryptionServerType == CoreData.RemoteEncryptionServerTypes.rtHttpGet)
            {
                throw new NotImplementedException(nameof(GetEncryptedData));
                //result = string.Empty;
                //try
                //{
                //    result = await new InetFunctions().GetRequest(String.Format(CoreData.RemoteEncyptionServer, data));
                //}
                //catch (Exception)
                //{
                //    result = CONST_SERVER_ERROR;
                //}
            }
            else
            if (CoreData.RemoteEncryptionServerType == CoreData.RemoteEncryptionServerTypes.rtHttpPost)
            {
                result = string.Empty;
                try
                {
                    result = await new InetFunctions().PostRequest(
                        CoreData.RemoteEncryptionServer, 
                        new Dictionary<string, string>()
                        {
                            { "value", data }
                        }
                    );

                    result += "!";
                }
#pragma warning disable 168
                catch (Exception ex)
#pragma warning restore 168
                {
                    result = CONST_SERVER_ERROR;
                }
            }
            else
            {
                throw new NotImplementedException(nameof(GetEncryptedData));
            }

            return result;
        }
    }
}
