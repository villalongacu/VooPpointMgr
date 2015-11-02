using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VooAzureStreamFacade;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointstartController : ApiController
    {

        // uri: /api/courses
      
        // GET: api/Amsppointstart
       
        public HttpResponseMessage Get([FromUri] StartAMSConfigParams configParams)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.Start(configParams);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }
            
        // GET: api/Amsppointstart/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointstart
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Amsppointstart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointstart/5
        public void Delete(int id)
        {
        }
    }
}
