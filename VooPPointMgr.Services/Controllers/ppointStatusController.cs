using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VooPPointMgr.BLL;

namespace VooPPointMgr.Services.Controllers
{
    public class ppointStatusController : ApiController
    {
        // GET: api/ppointStatus
        public HttpResponseMessage Get(string id)
        {
            var result = BLLPpoint.GetPPointStatus(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        // GET: api/ppointStatus/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ppointStatus
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ppointStatus/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ppointStatus/5
        public void Delete(int id)
        {
        }
    }
}
