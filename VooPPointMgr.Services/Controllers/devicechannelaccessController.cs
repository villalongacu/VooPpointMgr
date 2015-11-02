using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VooPPointMgr.BLL;

namespace VooPPointMgr.Services.Controllers
{
    public class devicechannelaccessController : ApiController
    {
        // GET api/devicechannelaccess/5

        public HttpResponseMessage Get(int id)
        {
            var channels = BLLDeviceChannelAccess.GetAllChannelsByDevice(id.ToString());
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, channels);
            return response;
        }

     
        // POST: api/devicechannelaccess
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/devicechannelaccess/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/devicechannelaccess/5
        public void Delete(int id)
        {
        }
    }
}
