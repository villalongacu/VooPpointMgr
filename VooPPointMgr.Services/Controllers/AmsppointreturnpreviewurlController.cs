﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VooPPointMgr.Services.Controllers
{
    public class AmsppointreturnpreviewurlController : ApiController
    {
        // GET: api/Amsppointreturnpreviewurl
        public string Get(string value)
        {
            var result = VooAzureStreamFacade.VooAzureStreamFacade.ReturnPreviewURL(value);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
            return result;
        }

   
        // POST: api/Amsppointreturnpreviewurl
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Amsppointreturnpreviewurl/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Amsppointreturnpreviewurl/5
        public void Delete(int id)
        {
        }
    }
}
