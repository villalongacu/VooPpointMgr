using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using VooAzureStreamFacade;
using VooPPointMgr.BLL;

namespace VooPPointMgr.Services.Controllers
{
    public class ppointrestartController : ApiController
    {
        // GET: api/ppointrestart
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /*
        public  HttpResponseMessage Get(string aPublishingPointName)
        {
          
        }
        */
        // GET: api/ppointrestart/5
        [HttpGet]
        public string Get(int id)
        {
            /*
            var pp = BLLPpoint.GetPPoint(id.ToString());
            var result = BLLPublishingPoint._RestartPublishingPoint(pp.IIS_NAME);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;*/
            return "value";
        }

      
        // POST: api/ppointrestart
        public void Post(string value)
        {
            var result = BLLPublishingPoint._RestartPublishingPoint(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT: api/ppointrestart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ppointrestart/5
        public void Delete(int id)
        {
        }
    }
}
