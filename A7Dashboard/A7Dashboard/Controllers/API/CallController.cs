using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestSharp;
using A7Dashboard.Domain.Models;

namespace A7Dashboard.Controllers.API
{
    public class CallController : ApiController
    {
        private RestClient _client;

        public CallController()
        {
            _client = new RestClient("https://api.github.com");
        }

        public string GetCall()
        {
            var request = new RestRequest("/users/tslang/repos");
            request.Method = Method.GET;
            request.RequestFormat = DataFormat.Json;

            var response = _client.Execute(request);
            return response.Content;
        }






















        // GET: api/Call
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Call/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Call
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT: api/Call/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/Call/5
        //public void Delete(int id)
        //{
        //}
    }
}
