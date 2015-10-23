using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using A7Dashboard.Domain.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;


namespace A7Dashboard
{
    public class RestSharp
    {
        public int Id { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string ResponseUri { get; set; }
    }
}



















//var result2 = GetClientResponse();
//if (result2 == 200)
//{
//    var client = new RestClient("http://localhost:51004");
//    var request = new RestRequest("api/Call");
//    request.Method = Method.PUT;
//    request.RequestFormat = DataFormat.Json;
//    request.AddBody(call);

//    var response = client.Execute<Call>(request);

//    if (response.StatusCode != HttpStatusCode.Created)
//        throw new Exception(response.ErrorMessage);
//}
//else
//{
//    throw new NotImplementedException()
//}


//if (statusCode >= 100 && statusCode < 400)
//{
//    return true;
//}
//else if (statusCode >= 500 && statusCode <= 510)
//{
//    return false;
//}
//return false;