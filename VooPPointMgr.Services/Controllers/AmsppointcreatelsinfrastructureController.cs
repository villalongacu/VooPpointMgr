using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VooAzureStreamFacade;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointcreatelsinfrastructureController : ApiController
    {
        // GET: api/Amsppointcreatelsinfrastructure

        public HttpResponseMessage Get([FromUri] StartAMSConfigParams configParams)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.CreateLiveStreamingInfrastructure(configParams);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        // GET: api/Amsppointcreatelsinfrastructure/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointcreatelsinfrastructure
        public void Post([FromBody]string value)
        {
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
