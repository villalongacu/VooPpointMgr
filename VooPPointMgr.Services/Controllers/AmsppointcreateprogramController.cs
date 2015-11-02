using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VooAzureStreamFacade;


namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointcreateprogramController : ApiController
    {
        // GET: api/Amsppointcreateprogram
        public HttpResponseMessage Get(CreateProgramAMSConfigParams configParams)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.CreateProgram(configParams);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return response;
        }

        // GET: api/Amsppointcreateprogram/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointcreateprogram
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Amsppointcreateprogram/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointcreateprogram/5
        public void Delete(int id)
        {
        }
    }
}
