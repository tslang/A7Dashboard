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
using RestSharp;

namespace A7Dashboard.Infrastructure.Repositories
{
    public class ApplicationRepository
    {
        internal SqlConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        public ApplicationRepository()
        {

        }

        public IEnumerable<Application> GetTargets()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                var targets = cn.Query<Application>("SELECT * FROM Application").ToList();
                return targets;
            }
        }





    }
}
