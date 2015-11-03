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
   
        // GET: api/Amsppointreturnmainurls/5
        public string [] Get(string value)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.ReturnMainStreamingURLs(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);

            return result.Select(i => i.ToString()).ToArray();
          
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
