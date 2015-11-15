using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A7Dashboard.Infrastructure.Mapper
{
    public interface IMapper
    {
        TItem Map<TDomain, TItem>(TDomain domain) where TItem : class;
    }
}
