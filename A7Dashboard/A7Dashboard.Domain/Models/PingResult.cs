using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using RestSharp;

namespace A7Dashboard.Domain.Models
{
    public class PingResult
    {
        //private int statusCode;
        //public int StatusCode { get { return statusCode; } set { } }
        //private string statusDescription;
        //public string StatusDescription { get { return statusDescription; } set { } }
        //private string server;
        //public string Server { get { return server; } set { } }
        //private string responseUri;
        //public string ResponseUri { get { return responseUri; } set { } }
        //private string responseStatus;
        //public string ResponseStatus { get { return responseStatus; } set { } }

        public int PingResultId { get; set; }
        [Display(Name = "Status Code")]
        public int StatusCode { get; set; }

        [Display(Name ="Status Description")]
        public string StatusDescription { get; set; }

        [Display(Name = "Server")]
        public string Server { get; set; }

        [Display(Name ="Response Url")]
        public string ResponseUri { get; set; }

        [Display(Name = "Response Status")]
        public string ResponseStatus { get; set; }

        [Display(Name ="Created")]
        public DateTime DateCreated { get; set; }





        public PingResult()
        {

        }


        public PingResult(int pingResultId, int statusCode, string statusDescription, string server, Uri responseUri, ResponseStatus responseStatus, DateTime dateCreated)
        {
            this.PingResultId = pingResultId;
            this.StatusCode = statusCode;
            this.StatusDescription = statusDescription;
            this.Server = server;
            this.ResponseUri = responseUri.ToString();
            this.ResponseStatus = responseStatus.ToString();
            this.DateCreated = dateCreated;
        }

        public PingResult(IRestResponse response)
        {
            this.StatusCode = (int)response.StatusCode;
            this.StatusDescription = response.StatusDescription;
            this.Server = response.Server;
            this.ResponseUri = response.ResponseUri.ToString();
            this.ResponseStatus = response.ResponseStatus.ToString(); 
        }



        //public int PingResultID { get; set; }
        //private int roundtripTime;
        //public int RoundtripTime { get { return roundtripTime; } }
        //private string status;
        //public string Status { get { return status; } }
        //public int ApplicationID { get; set; }


        //public PingResult()
        //{

        //}

        //public PingResult(int pingId, long roundtripTime, string status, int applicationId)
        //{
        //    this.PingResultID = pingId;
        //    this.status = status;
        //    this.roundtripTime = (int)roundtripTime;
        //    this.ApplicationID = applicationId;
        //}

        //public PingResult(long roundtripTime, string status, int applicationId)
        //{
        //    this.roundtripTime = (int)roundtripTime;
        //    this.status = status;
        //    this.ApplicationID = applicationId;
        //}


        //public PingResult(PingReply reply)
        //{
        //    this.status = reply.Status.ToString();
        //    this.roundtripTime = (int)reply.RoundtripTime;
        //}





    }
}