using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using A7Dashboard.Domain.Models;

namespace ConsoleApp
{
    class RestSharp
    {
        public RestSharp()
        {

        }

        public void GetClientResponse()
        {
            var client = new RestClient("https://api.github.com/users/tslang/repos");

            var request = new RestRequest();
            request.Method = Method.GET;
            request.Timeout = 5000;
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);
            int statusCode = (int)response.StatusCode;          

            Console.WriteLine(statusCode);
            Console.Read();
        }

        public void AddClientResponse(Call call)
        {
            var client = new RestClient("http://localhost:51004");
            var request = new RestRequest("api/Call");
            request.Method = Method.POST;
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute<Call>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(response.Data.Status);
            }
            else
            {
                Console.WriteLine("Error");
            }
            Console.Read();
        }




    }
}
