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
    public class AmsppointstartlsController : ApiController
    {
        // GET: api/Amsppointstartls

        public string Get([FromUri] StartLSAMSConfigParams configParams)
        {
            return "value";
        } 
        // GET: api/Amsppointstartls/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointstartls
        public void Post([FromBody]string value)
        {
            var data = JsonConvert.DeserializeObject<StartLSAMSConfigParams>(value);
            var ppoint = VooAzureStreamFacade.VooAzureStreamFacade.StartLiveStreaming(data);
        }

        // PUT: api/Amsppointstartls/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointstartls/5
        public void Delete(int id)
        {
        }
    }
}
