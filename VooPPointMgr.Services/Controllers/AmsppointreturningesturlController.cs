using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VooPPointMgr.BLL;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointreturningesturlController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.ReturnIngestURL(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
        // GET: api/Amsppointreturningesturl/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointreturningesturl
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Amsppointreturningesturl/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointreturningesturl/5
        public void Delete(int id)
        {
        }
    }
}
