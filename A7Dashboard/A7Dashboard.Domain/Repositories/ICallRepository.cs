﻿using A7Dashboard.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A7Dashboard.Domain.Repositories
{
    public interface ICallRepository
    {
        IEnumerable<Call> GetAll();
        Call Find(int id);
        void Remove(int id);

        void Save(Call call);

    }
}
