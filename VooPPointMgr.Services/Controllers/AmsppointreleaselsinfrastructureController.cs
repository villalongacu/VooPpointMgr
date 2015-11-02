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
    public class AmsppointreleaselsinfrastructureController : ApiController
    {
        // GET: api/Amsppointreleaselsinfrastructure
        public string Get([FromUri] StopAMSConfigParams configParams)
        {
            return "value";
        }

        // GET: api/Amsppointreleaselsinfrastructure/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointreleaselsinfrastructure
        public void Post([FromBody]string value)
        {
            var data = JsonConvert.DeserializeObject<StopAMSConfigParams>(value);
            var ppoint = VooAzureStreamFacade.VooAzureStreamFacade.ReleaseLiveStreamingInfrastructure(data);
        }

        // PUT: api/Amsppointreleaselsinfrastructure/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointreleaselsinfrastructure/5
        public void Delete(int id)
        {
        }
    }
}
