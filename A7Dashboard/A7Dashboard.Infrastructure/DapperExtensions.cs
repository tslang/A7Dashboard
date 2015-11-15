using Dapper;
using RepoWrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A7Dashboard.Infrastructure
{
    public static class DapperExtensions
    {
        public static TEntity Insert<TEntity>(this IDbConnection cn, string tableName, dynamic param)
        {
            IEnumerable<TEntity> result = SqlMapper.Query<TEntity>(cn, DynamicQuery.GetInsertQuery(tableName, param), param);
            return result.First();
        }

        public static void Update(this IDbConnection cn, string tableName, dynamic param)
        {
            SqlMapper.Execute(cn, DynamicQuery.GetUpdateQuery(tableName, param), param);
        }
    }
}
