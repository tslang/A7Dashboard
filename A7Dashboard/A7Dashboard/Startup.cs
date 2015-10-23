using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Hangfire;
using A7Dashboard.Domain.Repositories;
using A7Dashboard.Infrastructure.Repositories;

[assembly: OwinStartup(typeof(A7Dashboard.Startup))]

namespace A7Dashboard
{
    public partial class Startup
    {
        private IRestSharpRepository _rs = new RestSharpRepository();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate(() => _rs.GetClientResponse(), Cron.Minutely());

        }
    }
}
