using Common.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        List<T> GetAll(T entity);
        List<T> GetByCondition(T entity);
        List<T> GetByCondition(T entity, string condition, List<SqlParameter> parameters);
        List<IDomainObj> GetAllJoin(T entity);
        void Update(T entity);
        void Delete(T entity);

        void OpenConnection();
        void CloseConnection();
        void BeginTransaction();
        void Commit();
        void Rollback();

    }
}
