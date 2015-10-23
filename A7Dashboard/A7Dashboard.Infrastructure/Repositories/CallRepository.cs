using A7Dashboard.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using A7Dashboard.Domain.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using RestSharp;
using System.Net;

namespace A7Dashboard.Infrastructure.Repositories
{
    public class CallRepository : ICallRepository
    {
        //private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);


        #region GetAll
        public IEnumerable<Call> GetAll()
        {
            using (SqlConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                _db.Open();
                var results = _db.Query<Call>("SELECT * FROM Call").ToList();
                _db.Close();
                return results;
            }

        }
        #endregion

        #region Find
        public Call Find(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Remove
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Save
        public void Save(Call call)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
