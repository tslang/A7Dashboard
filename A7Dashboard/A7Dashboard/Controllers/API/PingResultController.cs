using A7Dashboard.Domain.Models;
using A7Dashboard.Domain.Repositories;
using A7Dashboard.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestSharp;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace A7Dashboard.Controllers.API
{
    public class PingResultController : ApiController
    {
        //private IPingResultRepository _repo = new PingResultRepository();
        private Monitor _monitor;
        private PingResultRepository _repo;
       

        public PingResultController()
        {
            _monitor = new Monitor();
            _repo = new PingResultRepository();
        }



        //GET: api/PingResult
        public IEnumerable<PingResult> Get()
        {
            return _repo.GetAllPingResults();
        }

        // GET: api/PingResult/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //POST: api/PingResult
        [HttpPost]
        public void Post(IRestResponse<PingResult> pingResult)
        {
            _repo.AddResult(pingResult);
        }

        // PUT: api/PingResult/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/PingResult/5
        //public void Delete(int id)
        //{
        //}
    }
}
