using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointgetlivethumbnailurlController : ApiController
    {
        // GET: api/Amsppointgetlivethumbnailurl
        public HttpResponseMessage Get(string id)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.GetLivePreviewThumbnailUri(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        // GET: api/Amsppointgetlivethumbnailurl/5
        public string Get(int id)
        {
            return "value";
        }

        public string Get()
        {
            return "value";
        }

        // POST: api/Amsppointgetlivethumbnailurl
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Amsppointgetlivethumbnailurl/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointgetlivethumbnailurl/5
        public void Delete(int id)
        {
        }
    }
}
