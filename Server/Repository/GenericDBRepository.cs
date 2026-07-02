using Common.Domain;
using DBBroker;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Server.Repository
{
    public class GenericDBRepository : IRepository<IDomainObj>
    {
        protected readonly Broker broker;

        public GenericDBRepository()
        {
            broker = new Broker();
        }

        public void OpenConnection() => broker.OpenConnection();
        public void CloseConnection() => broker.CloseConnection();
        public void BeginTransaction() => broker.BeginTransaction();
        public void Commit() => broker.Commit();
        public void Rollback() => broker.Rollback();
        public void InsertInto(IDomainObj entity) => broker.Insert(entity);
        public long InsertIntoOutput(IDomainObj entity) => broker.InsertOutput(entity);
        public List<IDomainObj> GetAll(IDomainObj entity) => broker.ReadAll(entity);
        public List<IDomainObj> GetAllByCondition(IDomainObj entity) => broker.ReadAllByCondition(entity);
        public void Update(IDomainObj entity) => broker.Update(entity);
        public void Delete(IDomainObj entity) => broker.Delete(entity);
    }
}
