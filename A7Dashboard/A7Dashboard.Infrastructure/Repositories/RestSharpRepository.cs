using A7Dashboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using A7Dashboard.Domain.Repositories;

namespace A7Dashboard.Infrastructure.Repositories
{
    public class RestSharpRepository : IRestSharpRepository
    {
        #region GetClientResponse
        public IEnumerable<Call> GetClientResponse()
        {
            var client = new RestClient("https://api.github.com/users");
            var request = new RestRequest();
            request.Method = Method.GET;
            request.Timeout = 5000;

            var response = client.Execute<List<Call>>(request);
            //int statusCode = (int)response.StatusCode;

            return response.Data;
        }
        #endregion

        #region AddClientResponse
        public void AddClientResponse(Call call)
        {
            var result2 = GetClientResponse();
            if (result2 != null)
            {
                using (SqlConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    _db.Open();

                    string query = "INSERT INTO [dbo].[Call] ([Status], [ResponseUri], [DateCreated]) VALUES (@Status, @ResponseUri, @DateCreated)";
                    _db.Execute(query,
                        new
                        {
                            call.Status,
                            call.ResponseUri,
                            call.DateCreated
                        });

                    _db.Close();
                }
            }
        }
        #endregion

    }
}
