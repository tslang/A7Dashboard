using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using A7Dashboard.Domain.Models;
using A7Dashboard.Infrastructure.Repositories;

namespace A7Dashboard.Controllers.API
{
    public class ApplicationController : ApiController
    {
        private ApplicationRepository _repo = new ApplicationRepository();

        // GET: api/Application
        public IEnumerable<Application> Get()
        {
            var targets = _repo.GetTargets();
            return targets;
        }

        // GET: api/Application/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Application
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Application/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Application/5
        public void Delete(int id)
        {
        }
    }
}
