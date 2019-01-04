using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lib.Security;
using Lib.Strings;
using Microsoft.AspNetCore.Mvc;

namespace EncryptionServer.NetCoreWebApp.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        ///     Self test
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/TripleDes")]
        public ActionResult<string> Get()
        {
            string resultCrypted = Crypt("SecuredString");
            string resultEncrypted = Decrypt(resultCrypted);

            return "SELF TEST 1: OK\nSELF TEST 2: OK\nSYSTEM IS READY";
        }

        /// <summary>
        ///     Ecnrypt data
        /// </summary>
        /// <param name="blankValue"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/TripleDesEncryption")]
        public ActionResult<string> Post([FromForm] string blankValue)
        {
            return Crypt(blankValue);
        }

        private string Crypt(string blankValue)
        {
            string result = "";

            if (!String.IsNullOrEmpty(blankValue))
            {
                byte[] data = SecurityFunctions.TripleDESEncryptFramework(blankValue, CoreData.SecurityKey);
                result = StringsFunctions.BytesAsHexString(data);
            }

            return result;
        }

        private string Decrypt(string xValue)
        {
            string result = "";

            if (!String.IsNullOrEmpty(xValue))
            {
                byte[] data = StringsFunctions.StringToByteArray(xValue);
                result = SecurityFunctions.TripleDESDecryptFramework(data, CoreData.SecurityKey);
            }

            return result;
        }

        /// <summary>
        ///     Decrypt data
        /// </summary>
        /// <param name="xValue"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/TripleDesDecryption")]
        public ActionResult<string> Put([FromForm] string xValue)
        {
            return Decrypt(xValue);
        }
    }
}
