using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using VooAzureStreamFacade;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointstopController : ApiController
    {
        // GET: api/Amsppointstop
        public string Get([FromUri] StopAMSConfigParams configParams)
        {
         return "value";
        }

        // GET: api/Amsppointstop/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointstop
        public void Post(string value)
        {
            var data = JsonConvert.DeserializeObject<StopAMSConfigParams>(value);
            var ppoint = VooAzureStreamFacade.VooAzureStreamFacade.Stop(data);
        }

        // PUT: api/Amsppointstop/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointstop/5
        public void Delete(int id)
        {
        }
    }
}
