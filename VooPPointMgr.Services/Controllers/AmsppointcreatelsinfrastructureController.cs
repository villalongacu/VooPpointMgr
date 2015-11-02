using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using VooAzureStreamFacade;
using VooPPointMgr.DataL;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointcreatelsinfrastructureController : ApiController
    {
        // GET: api/Amsppointcreatelsinfrastructure

        public string Get([FromUri] StartAMSConfigParams configParams)
        {
            return "value";
        }

        // GET: api/Amsppointcreatelsinfrastructure/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointcreatelsinfrastructure
        public void Post([FromBody]string value)
        {
            var data = JsonConvert.DeserializeObject<StartAMSConfigParams>(value);
            var result = VooAzureStreamFacade.VooAzureStreamFacade.CreateLiveStreamingInfrastructure(data);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT: api/Amsppointcreatelsinfrastructure/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointcreatelsinfrastructure/5
        public void Delete(int id)
        {
        }
    }
}
