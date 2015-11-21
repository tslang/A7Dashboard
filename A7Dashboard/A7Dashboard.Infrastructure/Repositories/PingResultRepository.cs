﻿using A7Dashboard.Domain.Models;
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

        #region dependency_OnChange
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type == SqlNotificationType.Change)
            {
                GetAllPingResults();
            }
        }
        #endregion


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



        //public IEnumerable<PingResult> GetResults()
        //{   
        //    using (SqlConnection cn = Connection)
        //    {
        //        cn.Open();
        //        var results = cn.Query<PingResult>("SELECT * FROM PingResult").ToList();
        //        return results;
        //    }
        //}


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


