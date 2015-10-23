using A7Dashboard.Domain.Models;
using A7Dashboard.Domain.Repositories;
using A7Dashboard.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestSharp;

namespace A7Dashboard.Controllers.API
{
    public class CallController : ApiController
    {
        private IRestSharpRepository _rs;
        private ICallRepository _repo;

        public CallController()
        {
            _rs = new RestSharpRepository();
            _repo = new CallRepository();
        }

        #region GetClientResponse
        public IEnumerable<Call> GetClientResponse()
        {
            return _rs.GetClientResponse();
        }
        #endregion

        #region AddClientResponse
        // POST: api/Call
        [HttpPost, Route("AddClientResponse")]
        public void AddClientResponse(Call call)
        {
            if (ModelState.IsValid)
            {
                _rs.AddClientResponse(call);
               
            }
            //return Ok();
        }
        #endregion

        //#region GetAll
        // GET: api/values
        //[Route("api/Call/GetAll")]
        //public IEnumerable<Call> GetAll()
        //{
        //    return _repo.GetAll();

        //}
        //#endregion

        #region GetCallByID
        // GET: api/Call/5
        public Call Get(int id)
        {
            return null;
        }
        #endregion

        #region PUT
        // PUT: api/Call/5
        public void Put(int id, [FromBody]string value)
        {
        }
        #endregion

        #region DELETE
        // DELETE: api/Call/5
        public void Delete(int id)
        {
        }
        #endregion

    }
}
