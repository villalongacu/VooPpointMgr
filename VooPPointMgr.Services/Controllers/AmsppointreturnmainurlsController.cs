using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointreturnmainurlsController : ApiController
    {
        // GET: api/Amsppointreturnmainurls
        public HttpResponseMessage Get(string id)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.ReturnMainStreamingURLs(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        // GET: api/Amsppointreturnmainurls/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointreturnmainurls
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Amsppointreturnmainurls/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointreturnmainurls/5
        public void Delete(int id)
        {
        }
    }
}
