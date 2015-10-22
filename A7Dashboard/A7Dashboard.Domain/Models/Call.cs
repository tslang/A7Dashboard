using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp.Deserializers;

namespace A7Dashboard.Domain.Models
{
    public class Call
    {
        //public string ResponseUrl { get; set; }
        //public int StatusCode { get; set; }
        [DeserializeAs(Name = "@statusDescription")]
        public string StatusDescription { get; set; }

        [DeserializeAs(Name = "@dateCreated")]
        public DateTime DateCreated { get; set; }


    }
}