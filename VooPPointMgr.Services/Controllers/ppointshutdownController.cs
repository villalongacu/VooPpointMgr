using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VooPPointMgr.BLL;

namespace VooPPointMgr.Services.Controllers
{
    public class ppointshutdownController : ApiController
    {
        // GET: api/ppointshutdown
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ppointshutdown/5
      
        public string Get(int id)
        {
          /*   var pp = BLLPpoint.GetPPoint(id.ToString());
            var result = BLLPublishingPoint._ShutdownPublishingPoint(pp.IIS_NAME);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response; */
            return "";
        }

        // POST: api/ppointrestart
        public void Post([FromBody]string value)
        {
            var result = BLLPublishingPoint._ShutdownPublishingPoint(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
        }
        // PUT: api/ppointshutdown/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ppointshutdown/5
        public void Delete(int id)
        {
        }
    }
}
