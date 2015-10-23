using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using A7Dashboard.Domain.Models;

namespace ConsoleApp
{
    class Program
    {
        private RestSharp result = new RestSharp();
        static void Main(string[] args)
        {
            var result = new RestSharp();
            result.GetClientResponse();

        }
 
    }

}

















//var client = new RestClient("http://www.google.com");

//var request = new RestRequest();
//request.Method = Method.HEAD;
//request.Timeout = 5000;

//var response = client.Execute(request);
//int statusCode = (int)response.StatusCode;

//if (statusCode >= 100 && statusCode < 400)
//{
//    Console.WriteLine("{0}", response.StatusCode);
//}
//else
//{
//    Console.WriteLine("Error");
//}