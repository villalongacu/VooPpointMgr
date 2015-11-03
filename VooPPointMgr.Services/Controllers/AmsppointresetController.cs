using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VooAzureStreamFacade;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointresetController : ApiController
    {
        // GET: api/Amsppointreset
        public HttpResponseMessage Get(string id)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.ResetChannel(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        // GET: api/Amsppointreset/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointreset
        public void Post(string value)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.ResetChannel(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
          
        }

        // PUT: api/Amsppointreset/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointreset/5
        public void Delete(int id)
        {
        }
    }
}
