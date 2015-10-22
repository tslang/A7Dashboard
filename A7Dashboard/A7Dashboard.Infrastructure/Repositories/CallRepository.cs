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



namespace A7Dashboard.Infrastructure.Repositories
{
    public class CallRepository : ICallRepository
    {
        //private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //SqlConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());

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

        public Call AddCall(Call call)
        {
            using (SqlConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                _db.Open();

                string query = "INSERT INTO [dbo].[Call] ([StatusDescription], [DateCreated]) VALUES (@StatusDescription,@DateCreated)";
                _db.Execute(query,
                    new
                    {
                        call.StatusDescription,
                        call.DateCreated
                    });

                _db.Close();
            }

            return call;
        }






        public Call Find(int id)
        {
            throw new NotImplementedException();
        }



        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Call call)
        {
            throw new NotImplementedException();
        }

        public Call Update(Call call)
        {
            throw new NotImplementedException();
        }
    }
}