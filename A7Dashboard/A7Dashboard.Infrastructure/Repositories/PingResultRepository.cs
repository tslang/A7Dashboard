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

namespace Pinger.Repositories
{
    public class PingResultRepository : IPingResultRepository
    {
        private ApplicationRepository _app = new ApplicationRepository();
        public virtual List<PingResult> Results { get; private set; }
        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        public PingResultRepository()
        {

        }


        public PingResult GetResults()
        {
            return null;
        }

        public void AddResult(PingResult result)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                const string query = "INSERT INTO [dbo].[PingResult]([RoundtripTime], [Status]) VALUES (@RoundtripTime,@Status)";
                cn.Execute(query,
                    new
                    {
                        RoundtripTime = result.RoundtripTime,
                        Status = result.Status,
                    });
                cn.Close();
            }
        }
    }
}
