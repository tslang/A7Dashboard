using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using A7Dashboard.Domain.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

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

        public void SendNotification()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<PingResultHub>();
            context.Clients.All.addPingResultToPage();
        }



    }
}