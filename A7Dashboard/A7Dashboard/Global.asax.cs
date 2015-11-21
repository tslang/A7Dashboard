﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace A7Dashboard
{
    public class WebApiApplication : System.Web.HttpApplication
    {

        string con = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SqlDependency.Start(con);       
        }

        protected void Application_End()
        {
            SqlDependency.Stop(con);
        }

    }
}

// Application_Init()
// Application_Start()
// Session_Start()
// Application_Error()
// Session_End()
// Application_End()
