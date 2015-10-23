using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp.Deserializers;
using System.ComponentModel.DataAnnotations;

namespace A7Dashboard.Domain.Models
{
    public class Call
    {
        [Key]
        [DeserializeAs(Name = "@callId")]
        public int Id { get; set; }

        [DeserializeAs(Name = "@status")]
        public int Status { get; set; }

        [DeserializeAs(Name = "@responseUri")]
        public string ResponseUri { get; set; }

        [DeserializeAs(Name = "@date")]
        public DateTime DateCreated { get; set; }


    }
}