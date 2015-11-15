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
        public string Name { get; private set; }
        public string Address { get; private set; }
        public int Timeout { get; private set; }
        public int Interval { get; private set; }  
        //public virtual IList<PingResult> PingResults { get; set; } 

        //public virtual List<PingResult> PingResults { get; set; }


        public Application(System.String name, System.String address, int timeout, int interval)
        {
            this.Name = name;
            this.Address = address;
            this.Timeout = timeout;
            this.Interval = interval;
        }

    }
}
