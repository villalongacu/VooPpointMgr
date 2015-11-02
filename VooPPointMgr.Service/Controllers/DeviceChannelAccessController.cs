using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VooPPointMgr.BLL;

namespace VooPPointMgr.Service.Controllers
{
     [EnableCors(origins: "http://localhost:5446", headers: "*", methods: "*")]
    public class DeviceChannelAccessController : ApiController
    {
        // GET api/ppoint/5
        [Route("api/deviceaccess/{id?}")]
        public HttpResponseMessage GetAllChannels(int iddevice)
        {
            var channels = BLLDeviceChannelAccess.GetAllChannelsByDevice(iddevice.ToString());
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, channels);
            return response;
        }

    
        // POST api/devicechannelaccess
        public void Post([FromBody]string value)
        {
        }

        // PUT api/devicechannelaccess/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/devicechannelaccess/5
        public void Delete(int id)
        {
        }
    }
}
