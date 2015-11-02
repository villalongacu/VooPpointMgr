using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using VooAzureStreamFacade;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointstartController : ApiController
    {

        // uri: /api/courses
      
        // GET: api/Amsppointstart
       
        public string Get([FromUri] StartAMSConfigParams configParams)
        {
            return "value";
        }
            
        // GET: api/Amsppointstart/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Amsppointstart
        public void Post(string value)
        {
            var data = JsonConvert.DeserializeObject<StartAMSConfigParams>(value);
            var ppoint = VooAzureStreamFacade.VooAzureStreamFacade.Start(data);
        }

        // PUT: api/Amsppointstart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointstart/5
        public void Delete(int id)
        {
        }
    }
}
