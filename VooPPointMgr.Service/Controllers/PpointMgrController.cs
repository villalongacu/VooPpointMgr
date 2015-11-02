using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VooPPointMgr.BLL;
using VooPPointMgr.Data;

namespace VooPPointMgr.Service.Controllers
{
      [EnableCors(origins: "http://localhost:5446/", headers: "*", methods: "*")]
      public class PpointMgrController : ApiController
    {
          [HttpGet]
          public HttpResponseMessage GetMessagesForApp(string id)
          {
            var ppoint = BLLPpoint.GetPPoint(id.ToString());
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);
            return response;
        }

          // GET: api/PpointMgr
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [Route("api/ppoint/{id?}")]
        public HttpResponseMessage Get(int id)
        {

            var ppoint = BLLPpoint.GetPPoint(id.ToString());
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);
            return response;
        }

        [Route("api/ppoint/{name:alpha}")]
        public HttpResponseMessage Get(string name)
        {
            var ppoint = BLLPpoint.SearchPPointByName(name);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);
            return response;
        }

        [Route("api/ppoint")]
        public HttpResponseMessage Post(tppoint e)
        {
            var ppoint = BLLPpoint.CreatePPoint(e);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);
            return response;
        }
        [HttpPost]
        public HttpResponseMessage PostShutDownPublishingPoint(string aPublishingPointName)
        {
            var result = BLLPublishingPoint._ShutdownPublishingPoint(aPublishingPointName);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [Route("api/ppoint/restart")]
        public HttpResponseMessage PostRestartPublishingPoint(string aPublishingPointName)
        {
            var result = BLLPublishingPoint._RestartPublishingPoint(aPublishingPointName);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [Route("api/ppoint/stopls")]
        public HttpResponseMessage PostStopLiveSource(string aPublishingPointName)
        {
            var result = BLLPublishingPoint._StopLiveSource_PublishingPoint(aPublishingPointName);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        [Route("api/ppoint")]
        public HttpResponseMessage Put(tppoint e)
        {
            var ppoint = BLLPpoint.UpdatePPoint(e);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);
            return response;
        }

        [Route("api/ppoint")]
        public HttpResponseMessage Delete(tppoint e)
        {
            BLLPpoint.DeletePPoint(e.ID_PPOINT.ToString());
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
      
    }
}
