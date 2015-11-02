using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VooPPointMgr.BLL;

namespace VooPPointMgr.Services.Controllers
{
    public class ppointstoplsController : ApiController
    {
        // GET: api/ppointstop
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ppointstop/5
      
        public HttpResponseMessage Get(int id)
        {
            var pp = BLLPpoint.GetPPoint(id.ToString());
            var result = BLLPublishingPoint._StopLiveSource_PublishingPoint(pp.IIS_NAME);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        // POST: api/ppointstop
        public void Post([FromBody]string value)
        {
            var result = BLLPublishingPoint._StopLiveSource_PublishingPoint(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
        }
        // PUT: api/ppointstop/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ppointstop/5
        public void Delete(int id)
        {
        }
    }
}
