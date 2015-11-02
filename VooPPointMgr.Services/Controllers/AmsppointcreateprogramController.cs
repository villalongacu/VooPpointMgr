using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using VooAzureStreamFacade;
using VooPPointMgr.BLL;
using VooPPointMgr.DataL;


namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointcreateprogramController : ApiController
    {
        // GET: api/Amsppointcreateprogram
        public string Get([FromUri] CreateProgramAMSConfigParams configParams)
        {
            return "value";
        }

        // GET: api/Amsppointcreateprogram/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointcreateprogram
        public void Post(string value)
        {
            var data = JsonConvert.DeserializeObject<CreateProgramAMSConfigParams>(value);
            var ppoint = VooAzureStreamFacade.VooAzureStreamFacade.CreateProgram(data);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);

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
