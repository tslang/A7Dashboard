//using A7Dashboard.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Dapper;
//using A7Dashboard.Domain.Repositories;
//using A7Dashboard.Infrastructure.Repositories;
//using RestSharp;


//namespace A7Dashboard.Infrastructure.Repositories
//{
//    public sealed class ResultRepository : Repository<Result>, IPingResultRepository
//    {
//        public ResultRepository() 
//            : base("PingResult")
//        {

//        }

//        public IRepository<Result> Repo
//        {
//            get { return this; }
//        }

//        #region Mapping
//        internal override dynamic Mapping(Result item)
//        {
//            return new
//            {
//                Status = item.Status,
//                RoundtripTime = item.RoundtripTime
//            };
//        }
//        #endregion

//        #region GetAll()
//        public override IEnumerable<Result> GetAll()
//        {
//            using (IDbConnection cn = Connection)
//            {
//                cn.Open();
//                var result = cn.Query<Result>("SELECT * FROM PingResult").ToList();
//                return result;
//            }
//        }
//        #endregion

//        //#region FindById
//        //public override Result FindByID(object id)
//        //{
//        //    Result item = null;

//        //    using (IDbConnection cn = Connection)
//        //    {
//        //        cn.Open();
//        //        var result = cn.Query("SELECT * FROM PingResult WHERE ID=@ID", new {ID = id}).SingleOrDefault();
                
//        //        if (result != null)
//        //        {
  
//        //        }
//        //    }

//        //    return item;
//        //}
//        //#endregion



//    }
//}


