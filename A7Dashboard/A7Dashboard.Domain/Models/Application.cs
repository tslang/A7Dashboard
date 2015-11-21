using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace A7Dashboard.Domain.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int Timeout { get; set; }
        public int Interval { get; set; }

        public Application()
        {

        }


        public Application(int id, string name, string address, string address2, int timeout, int interval)
        {
            this.ApplicationID = id;
            this.Name = name;
            this.Address = address;
            this.Address2 = address2;
            this.Timeout = timeout;
            this.Interval = interval;
        }

    }
}
