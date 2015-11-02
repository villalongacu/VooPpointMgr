using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VooPPointMgr.BLL;
using VooPPointMgr.DataL;

namespace VooPPointMgr.Services.Controllers
{
    public class ppointController : ApiController
    {
      
        // GET: api/createpp/5
        public  HttpResponseMessage Get(int id)
        {
            var ppoint = BLLPpoint.GetPPoint(id.ToString());
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);
            return response;
        }


        public HttpResponseMessage Get(string id)
        {
            var ppoint = BLLPpoint.SearchPPointByName(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);
            return response;
        }

        //GetAvailablePPoint
        public HttpResponseMessage Get()
        {
            var ppoint = BLLPpoint.GetAvailablePPoint();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);
            return response;
        }
        // POST: api/createpp
        public HttpResponseMessage Post([FromUri] tppoint e)
        {
            var ppoint = BLLPpoint.CreatePPoint(e);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);
            return response;
        }

        // PUT: api/createpp/5
        public HttpResponseMessage Put([FromUri] tppoint e)
        {
            var ppoint = BLLPpoint.UpdatePPoint(e);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);
            return response;
        }

        // DELETE: api/createpp/5
        public HttpResponseMessage Delete([FromUri] tppoint e)
        {
            BLLPpoint.DeletePPoint(e.ID_PPOINT.ToString());
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
