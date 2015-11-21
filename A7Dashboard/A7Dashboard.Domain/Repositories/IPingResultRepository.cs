using A7Dashboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace A7Dashboard.Domain.Repositories
{
    public interface IPingResultRepository
    {
        void AddResult(IRestResponse<PingResult> result);
        IEnumerable<PingResult> GetAllPingResults();
    }
}
