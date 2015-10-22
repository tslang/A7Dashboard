using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestSharp;

namespace A7Dashboard.Controllers.API
{
    public class MonitorController : ApiController
    {
        private RestClient _client;

        public MonitorController()
        {
            _client = new RestClient();
        }

        // GET: api/Monitor
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Monitor/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Monitor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Monitor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Monitor/5
        public void Delete(int id)
        {
        }
    }
}
