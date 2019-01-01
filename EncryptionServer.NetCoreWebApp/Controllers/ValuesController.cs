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
    [Route("api/TripleDesEncryptionAsText")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // POST api/TripleDesEncryption
        [HttpPost]
        public ActionResult<string> Post([FromForm] string value)
        {
            // Size: should be 24*8 = 192 bites
            string key = CoreData.SecurityKey;

            byte[] resultAsBytes = SecurityFunctions.TripleDESEncryptFramework(value, key);

            return StringsFunctions.BytesAsHexString(resultAsBytes);
        }
    }
}
