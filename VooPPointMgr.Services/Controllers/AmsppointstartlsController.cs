using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VooAzureStreamFacade;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointstartlsController : ApiController
    {
        // GET: api/Amsppointstartls

        public HttpResponseMessage Get([FromUri] StartLSAMSConfigParams configParams)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.StartLiveStreaming(configParams);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        } 
        // GET: api/Amsppointstartls/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointstartls
        public void Post([FromBody]string value)
        {
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
