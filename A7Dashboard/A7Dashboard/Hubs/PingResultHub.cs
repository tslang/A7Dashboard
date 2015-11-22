using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using A7Dashboard.Domain.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using A7Dashboard.Infrastructure.Repositories;

namespace A7Dashboard.Hubs
{
    public class PingResultHub : Hub
    {
        internal SqlConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        public void SendNotification(PingResult result)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<PingResultHub>();
            context.Clients.All.addPingResultToPage(result);
        }

    }
}












//public void RegisterPingResults()
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
//        }

//    }
//}


//private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
//{
//    if (e.Type == SqlNotificationType.Change)
//    {
//        var context = GlobalHost.ConnectionManager.GetHubContext<PingResultHub>();
//        PingResultRepository repo = new PingResultRepository();
//        var res = repo.GetPingResults();
//        context.Clients.All.addPingResultToPage();
//    }

//    RegisterPingResults();
//}


//public void SendNotification(PingResult _result)
//{
//    IHubContext context = GlobalHost.ConnectionManager.GetHubContext<PingResultHub>();
//    context.Clients.All.addPingResultToPage(_result);
//}