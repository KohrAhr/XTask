using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EncryptionServer.NetCoreWebApp.Functions;
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
            const string CONST_VALUE = "SecuredString";
            const string CONST_VALUE_CRYPTED = "2B4551AEBE18C1CD6FF0001B2CED5BB0";

            string resultCrypted = new Core().Crypt(CONST_VALUE);
            bool result1 = resultCrypted == CONST_VALUE_CRYPTED;
            string resultEncrypted = new Core().Decrypt(resultCrypted);
            bool result2 = resultEncrypted == CONST_VALUE;

            return 
                "SELF TEST 1: " + result1.ToString() + 
                "\nSELF TEST 2: " + result2.ToString() + 
                (result1 && result2 ? "\nSYSTEM IS READY" : "SYSTEM IS FAILED");
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
            return new Core().Crypt(blankValue);
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
            return new Core().Decrypt(xValue);
        }
    }
}
