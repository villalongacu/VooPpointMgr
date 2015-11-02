using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VooAzureStreamFacade;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointstartchannelController : ApiController
    {
        // GET: api/Amsppointstartchannel
        public string Get(string id)
        {
          
            return " value";
        }
        // GET: api/Amsppointstartchannel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointstartchannel
        public void Post([FromBody]string value)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.StartChannel(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // PUT: api/Amsppointstartchannel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointstartchannel/5
        public void Delete(int id)
        {
        }
    }
}
