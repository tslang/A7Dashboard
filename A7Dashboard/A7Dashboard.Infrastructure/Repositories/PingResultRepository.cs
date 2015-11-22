using A7Dashboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Net.NetworkInformation;
using A7Dashboard.Domain.Repositories;
using A7Dashboard.Infrastructure.Repositories;
using RestSharp;


namespace A7Dashboard.Infrastructure.Repositories
{
    public class PingResultRepository : IPingResultRepository
    {
        internal SqlConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }


        public IEnumerable<PingResult> GetAllPingResults()
        {
            using (SqlConnection cn = Connection)
            {
                cn.Open();
                var results = cn.Query<PingResult>("SELECT * FROM PingResult").ToList();
                return results;
            }
        }


        public void AddResult(IRestResponse<PingResult> result)
        {
            using (SqlConnection cn = Connection)
            {
                cn.Open();
                const string query = "INSERT INTO [dbo].[PingResult]([StatusCode],[StatusDescription],[Server],[ResponseUri],[ResponseStatus]) VALUES (@StatusCode,@StatusDescription,@Server,@ResponseUri,@ResponseStatus)";
                cn.Execute(query,
                    new
                    {
                        StatusCode = result.StatusCode,
                        StatusDescription = result.StatusDescription,
                        Server = result.Server,
                        ResponseUri = result.ResponseUri.OriginalString,
                        ResponseStatus = result.ResponseStatus
                    });
                cn.Close();
            }
        }
    }
}


//    


