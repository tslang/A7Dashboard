using A7Dashboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using A7Dashboard.Hubs;
using Microsoft.AspNet.SignalR;
using A7Dashboard.Infrastructure.Repositories;

namespace A7Dashboard.Models
{
    public class PingResultHubUtility
    {
        private PingResultHub _hub = new PingResultHub();
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        #region RegisterNotification()
        public void RegisterNotification()
        {
            string query = @"SELECT * FROM [dbo].[PingResult]";

            SqlDependency.Start(connectionString);
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, cn))
                {
                    cn.Open();
                    var dependency = new SqlDependency(command);

                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                    }
                }
            }
        }
        #endregion


        #region _dependency_OnChange()
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<PingResultHub>();
                PingResultRepository repo = new PingResultRepository();
                var res = repo.GetAllPingResults();
                context.Clients.All.addPingResultToPage(res);
            }

            RegisterNotification();


        }
        #endregion




        //#region IEnumerable<PingResult RegisterPingResults()
        //public IEnumerable<PingResult> RegisterPingResults()
        //{
        //    List<PingResult> _result = new List<PingResult>();
        //    using (SqlConnection cn = Connection)
        //    {
        //        var query = "SELECT * FROM [dbo].[PingResult]";
        //        cn.Open();
        //        using (SqlCommand command = new SqlCommand(query, cn))
        //        {
        //            command.Notification = null;
        //            DataTable dt = new DataTable();
        //            SqlDependency dependency = new SqlDependency(command);

        //            dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

        //            if (cn.State == ConnectionState.Closed)
        //                cn.Open();

        //            SqlDependency.Start(cn.ConnectionString);
        //            var reader = command.ExecuteReader();
        //            dt.Load(reader);
        //            if (dt.Rows.Count > 0)
        //            {
        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    _result.Add(new PingResult
        //                    {
        //                        StatusCode = Int32.Parse(dt.Rows[i]["StatusCode"].ToString()),
        //                        StatusDescription = dt.Rows[i]["StatusDescription"].ToString(),
        //                        Server = dt.Rows[i]["Server"].ToString(),
        //                        ResponseUri = dt.Rows[i]["ResponseUri"].ToString(),
        //                        ResponseStatus = dt.Rows[i]["ResponseStatus"].ToString()
        //                    });

        //                }
        //            }
        //            return _result;
        //        }

        //    }
        //}
        //#endregion




    }
}