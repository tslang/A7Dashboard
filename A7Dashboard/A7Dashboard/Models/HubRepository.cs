using A7Dashboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;
using A7Dashboard.Hubs;

namespace A7Dashboard.Models
{
    public class HubRepository
    {
        private PingResultHub _hub = new PingResultHub();
        internal SqlConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        public IEnumerable<PingResult> GetAllPingResults()
        {
            List<PingResult> _result = new List<PingResult>();
            using (SqlConnection cn = Connection)
            {
                var query = "SELECT * FROM [dbo].[PingResult]";
                cn.Open();
                using (SqlCommand command = new SqlCommand(query, cn))
                {
                    command.Notification = null;
                    DataTable dt = new DataTable();
                    SqlDependency dependency = new SqlDependency(command);

                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (cn.State == ConnectionState.Closed)
                        cn.Open();

                    SqlDependency.Start(cn.ConnectionString);
                    var reader = command.ExecuteReader();
                    dt.Load(reader);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            _result.Add(new PingResult
                            {
                                StatusCode = Int32.Parse(dt.Rows[i]["StatusCode"].ToString()),
                                StatusDescription = dt.Rows[i]["StatusDescription"].ToString(),
                                Server = dt.Rows[i]["Server"].ToString(),
                                ResponseUri = dt.Rows[i]["ResponseUri"].ToString(),
                                ResponseStatus = dt.Rows[i]["ResponseStatus"].ToString()
                            });

                        }
                    }

                }
                return _result;
            }
        }

        #region dependency_OnChange
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                _hub.SendNotification();
            }
        }
        #endregion
    }
}