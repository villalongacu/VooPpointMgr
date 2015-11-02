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
    public class CreatechannelppointController : ApiController
    {
        // GET: api/Createchannelppoint
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Createchannelppoint/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Createchannelppoint
        public void Post([FromBody]string value)
        {
            var data = JsonConvert.DeserializeObject<tchannel_ppoint>(value);
            var ppoint = BLLChannelPPoint.CreateChannelPPointAccess(data);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, ppoint);
           
        }

        // PUT: api/Createchannelppoint/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Createchannelppoint/5
        public void Delete(int id)
        {
        }
    }
}
