using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VooPPointMgr.BLL;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointreturningesturlController : ApiController
    {
        public string Get(string value)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.ReturnIngestURL(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return result;
        }
/*
        public string Get()
        {
            return "value1";
        }
*/
    
        // POST: api/Amsppointreturningesturl
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Amsppointreturningesturl/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointreturningesturl/5
        public void Delete(int id)
        {
        }
    }
}
