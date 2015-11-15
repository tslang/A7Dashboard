using A7Dashboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A7Dashboard.Domain.Repositories
{
    public interface IPingResultRepository
    {
        void AddResult(PingResult result);
        PingResult GetResults();
    }
}
