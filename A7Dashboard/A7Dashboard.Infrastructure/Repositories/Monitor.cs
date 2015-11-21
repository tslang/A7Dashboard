using A7Dashboard.Domain.Models;
using A7Dashboard.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace A7Dashboard.Infrastructure.Repositories
{
    public class Monitor
    {
        //private Ping ping;
        private PingResultRepository _repo;
        private ApplicationRepository _appRepo;
        private ApplicationData _appData;

        public Application Application { get; set; }
        public IList<PingResult> Results { get; set; }



        public Monitor()
        {
            _repo = new PingResultRepository();
            _appRepo = new ApplicationRepository();
            _appData = new ApplicationData();

        }

        //public void SendPing()
        //{
        //    var target = _appData.GetApplications();
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

        //public bool SendPing()
        //{
        //    bool result = false;
        //    var target = _appRepo.GetTargets();
        //    foreach (var targs in target)
        //    {
        //        try
        //        {
        //            ping = new Ping();
        //            PingReply pingResult = ping.Send(targs.Address, targs.Timeout);
        //            PingResult res = new PingResult(pingResult);
        //            if (res != null)
        //            {
        //                _repo.AddResult(res);
        //            }
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }
        //    return result;
        //}

        public string SendPing()
        {
            var target = _appRepo.GetTargets();
            foreach (var targs in target)
            {
                var client = new RestClient(targs.Address);
                var request = new RestRequest(targs.Address2);
                request.Method = Method.GET;
                request.RequestFormat = DataFormat.Json;

                var response = client.Execute<PingResult>(request);
                if (response != null)
                {
                    _repo.AddResult(response);
                }

            }
            //var client = new RestClient("http://espn.go.com"); 

            //var request = new RestRequest("/nfl/");
            //request.Method = Method.GET;
            //request.RequestFormat = DataFormat.Xml;

            //var response = client.Execute<PingResult>(request);
            //if (response != null)
            //{
            //    _repo.AddResult(response);
            //}

            return "awesome";
        }


    }
}
