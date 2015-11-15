//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Linq.Expressions;
//using Dapper;
//using RepoWrapper;
//using A7Dashboard.Domain.Repositories;
//using A7Dashboard.Infrastructure;

//namespace A7Dashboard.Infrastructure.Repositories
//{

//    public abstract class Repository<T> : IRepository<T> where T : class
//    {
//        private readonly string _tableName;

//        internal IDbConnection Connection
//        {
//            get
//            {
//                return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
//            }
//        }

//        /// <summary>
//        /// Initializes a new instance of the <see cref="Repository{T}" /> class.
//        /// </summary>
//        /// <param name="tableName">Name of the table.</param>
//        public Repository(string tableName)
//        {
//            _tableName = tableName;
//        }

//        /// <summary>
//        /// Mapping the object to the insert/update columns.
//        /// </summary>
//        /// <param name="item">The item.</param>
//        /// <returns>The parameters with values.</returns>
//        /// <remarks>In the default case, we take the object as is with no custom mapping.</remarks>
//        internal virtual dynamic Mapping(T item)
//        {
//            return item;
//        }

//        #region Add
//        /// Adds the specified item.
//        /// <param name="item">The item.</param>
//        public virtual void Add(T item)
//        {
//            using (IDbConnection cn = Connection)
//            {
//                var parameters = (object)Mapping(item);
//                cn.Open();
//                //item. = cn.Insert<Guid>(_tableName, parameters);
//            }
//        }
//        #endregion

//        #region Update()
//        /// Updates the specified item.
//        /// <param name="item">The item.</param>
//        public virtual void Update(T item)
//        {
//            using (IDbConnection cn = Connection)
//            {
//                var parameters = (object)Mapping(item);
//                cn.Open();
//                cn.Update(_tableName, parameters);
//            }
//        }
//        #endregion

//        #region Remove()
//        /// Removes the specified item.
//        /// <param name="item">The item.</param>
//        public virtual void Remove(T item)
//        {
//            using (IDbConnection cn = Connection)
//            {
//                cn.Open();
//                //cn.Execute("DELETE FROM " + _tableName + " WHERE ID=@ID", new { Id = item.ID });
//            }
//        }
//        #endregion

//        #region FindById
//        /// Finds by ID.
//        /// <param name="id">The id.</param>
//        /// <returns></returns>
//        public virtual T FindByID(object id)
//        {
//            T item = default(T);

//            using (IDbConnection cn = Connection)
//            {
//                cn.Open();
//                item = cn.Query<T>("SELECT * FROM " + _tableName + " WHERE ID=@ID", new { ID = id }).SingleOrDefault();
//            }

//            return item;
//        }
//        #endregion

//        #region Find(Expression)
//        /// Finds the specified predicate.
//        /// <param name="predicate">The predicate.</param>
//        /// <returns>A list of items</returns>
//        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
//        {
//            IEnumerable<T> items = null;

//            // extract the dynamic sql query and parameters from predicate
//            QueryResult result = DynamicQuery.GetDynamicQuery(_tableName, predicate);

//            using (IDbConnection cn = Connection)
//            {
//                cn.Open();
//                items = cn.Query<T>(result.Sql, (object)result.Param);
//            }

//            return items;
//        }
//        #endregion

//        #region GetAll()
//        public virtual IEnumerable<T> GetAll()
//        {
//            IEnumerable<T> items = null;

//            using (IDbConnection cn = Connection)
//            {
//                cn.Open();
//                items = cn.Query<T>("SELECT * FROM " + _tableName);
//            }

//            return items;
//        }
//        #endregion
//    }
//}

