using A7Dashboard.Domain.Models;
using Pinger.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace A7Dashboard.Infrastructure.Repositories
{
    public class Monitor
    {
        private Ping ping;
        private PingResultRepository _repo;
        private ApplicationRepository _appRepo;

        public Monitor()
        {
            _repo = new PingResultRepository();
            _appRepo = new ApplicationRepository();  
        }

        //public void SendPing()
        //{
        //    var target = _appRepo.GetTargets();
        //    foreach (var targs in target)
        //    {
        //        ping = new Ping();
        //        PingReply pingResult = ping.Send(targs.Address, targs.Timeout);
        //        PingResult res = new PingResult(pingResult);
        //        if (res != null)
        //        {
        //            _repo.AddResult(res);
        //        }          
        //    }
        //}

        public PingResult SendPing()
        {
            ping = new Ping();
            PingReply pingResult = ping.Send("www.google.com", 5000);
            PingResult res = new PingResult(pingResult);
            if (res != null)
            {
                _repo.AddResult(res);
            }
            return res;

        }
    }
}
