using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
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
        public void Post([FromBody] string value)
        {
            var data = JsonConvert.DeserializeObject<tppoint>(value);
            var ppoint = BLLPpoint.CreatePPoint(data);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);
           
        }

        // PUT: api/createpp/5
        public void Put([FromBody] string value)
        {
            var data = JsonConvert.DeserializeObject<tppoint>(value);
            var ppoint = BLLPpoint.UpdatePPoint(data);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);
           
        }

        // DELETE: api/createpp/5
        public HttpResponseMessage Delete(int id)
        {
            BLLPpoint.DeletePPoint(id.ToString());
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}
