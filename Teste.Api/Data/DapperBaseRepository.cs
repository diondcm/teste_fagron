using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Api.Data
{
    public class DapperBaseRepository<T>
    {
        protected IDbConnection Connection { get; set; }
        public  DapperBaseRepository(IDbConnection conn)
        {
            Connection = conn;
        }
        public List<T> Query<T>(string query, object parameters = null)
        {
            try
            {
                return Connection.Query<T>(query, parameters).ToList();
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
        }

        public T QuerySingle<T>(string query, object parameters = null)
        {
            try
            {
                return Connection.QuerySingle<T>(query, parameters);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public T QueryFirst<T>(string query, object parameters = null)
        {
            try
            {
                return Connection.QueryFirst<T>(query, parameters);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
    }
}
