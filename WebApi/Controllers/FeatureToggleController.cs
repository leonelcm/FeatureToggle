using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class FeatureToggleController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok( new { Enabled = true });
        }
    }
}
