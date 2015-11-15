using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A7Dashboard.Infrastructure.Domain
{
    interface IDataMapper<T> where T : class
    {
        T FindById(object id);
        IEnumerable<T> FindAll();
        void Insert(T item);
        void Update(T item);
        void Delete(object id);
    }
}
