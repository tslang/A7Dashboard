using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using A7Dashboard.Domain.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace A7Dashboard
{
    public class RestSharp
    {
        //private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public IEnumerable<Call> SendCall()
        {
            var client = new RestClient("https://api.github.com/users/tslang/repos");
            var request = new RestRequest(Method.GET);             
            var response = client.Execute<List<Call>>(request);
           
            return response.Data;
                     
        }

    }
}