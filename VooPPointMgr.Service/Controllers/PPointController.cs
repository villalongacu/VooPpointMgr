using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VooPPointMgr.Data;
using VooPPointMgr.BLL;

namespace VooPPointMgr.Service.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PPointController : ApiController
    {
        // GET api/ppoint
        /*        [Route("api/ptemployees")]
                public HttpResponseMessage Get()
                {
                  var ppoints = bllppoint.GetPPoints();
               
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoints);
                    return response;
                }
    */
        // GET api/ppoint/5
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

