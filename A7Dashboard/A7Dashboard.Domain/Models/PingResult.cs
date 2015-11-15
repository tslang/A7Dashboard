using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Collections;

namespace A7Dashboard.Domain.Models
{
    public class PingResult
    {
        private int roundtripTime;
        public int RoundtripTime { get { return roundtripTime; } }
        private string status;
        public string Status { get { return status; } }


        public PingResult(long roundtripTime, string status, int applicationID)
        {
            this.status = status;
            this.roundtripTime = (int)roundtripTime;
        }

        public PingResult(PingReply reply)
        {
            this.status = reply.Status.ToString();
            this.roundtripTime = (int)reply.RoundtripTime;
        }



    //public int PingResultId { get; set; }
    //public DateTime PingDate { get; set; }
    //public int Timeout { get; set; }



}
}