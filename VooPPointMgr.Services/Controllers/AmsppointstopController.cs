using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VooAzureStreamFacade;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointstopController : ApiController
    {
        // GET: api/Amsppointstop
        public HttpResponseMessage Get([FromUri] StopAMSConfigParams configParams)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.Stop(configParams);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        // GET: api/Amsppointstop/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointstop
        public void Post([FromBody]string value)
        {
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
