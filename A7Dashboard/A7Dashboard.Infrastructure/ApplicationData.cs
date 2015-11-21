using A7Dashboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A7Dashboard.Infrastructure
{
    public class ApplicationData
    {
        public ApplicationData()
        {

        }

        public IList<Application> GetApplications()
        {
            var apps = new List<Application>
            {
                new Application
                {
                    ApplicationID = 1,
                    Name = "Google",
                    Address = "www.google.com",
                    Timeout = 500,
                    Interval = 600
                },
                new Application
                {
                    ApplicationID = 2,
                    Name = "Covers",
                    Address = "www.covers.com",
                    Timeout = 500,
                    Interval = 600
                }
            };
            return apps;
        }

    }
}
