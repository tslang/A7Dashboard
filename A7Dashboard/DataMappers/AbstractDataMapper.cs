//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Dapper;

//namespace A7Dashboard.Infrastructure.DataMappers
//{
//    public abstract class AbstractDataMapper<T>
    //{
        //    protected abstract string TableName { get; }

        //    protected IDbConnection Connection
        //    {
        //        get
        //        {
        //            return
        //                new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        //        }
        //    }

        //    public virtual T FindSingle(string query, dynamic param)
        //    {
        //        dynamic item = null;

        //        using (IDbConnection cn = Connection)
        //        {
        //            cn.Open();
        //            var result = cn.Query(query, (object)param).SingleOrDefault();

        //            if (result != null)
        //            {
        //                item = Mapper(result);
        //            }
        //        }
        //        return item;
        //    }

        //    public virtual IEnumerable<T> FindAll()
        //    {
        //        var items = new List<T>();

        //        using (IDbConnection cn = Connection)
        //        {
        //            cn.Open();
        //            var results = cn.Query("SELECT * FROM " + TableName).ToList();

        //            for (int i = 0; i < results.Count(); i++)
        //            {
        //                items.Add(Map(results.ElementAt(i)));
        //            }
        //        }

        //        return items;
        //    }
//    }
//}
