using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Hangfire;
using A7Dashboard.Infrastructure.Repositories;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(A7Dashboard.Startup))]

namespace A7Dashboard
{
    public partial class Startup
    {
        private Monitor _mono = new Monitor();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

            app.MapSignalR(new HubConfiguration());
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate(() => _mono.SendPing(), Cron.Minutely());

        }
    }
}
