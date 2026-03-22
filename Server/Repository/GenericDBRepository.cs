using Common.Domain;
using DBBroker;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Server.Repository
{
    public class GenericDBRepository : IRepository<IDomainObj>
    {
        private Broker broker = new DBBroker.Broker();

        public void BeginTransaction()
        {
            broker.BeginTransaction();
        }

        public void CloseConnection()
        {
            broker.CloseConnection();
        }

        public void Commit()
        {
            broker.Commit();
        }
        public void OpenConnection()
        {
            broker.OpenConnection();
        }

        public void Rollback()
        {
            broker.Rollback();
        }
        public void InsertInto(IDomainObj entity)
        {
            SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText = $"INSERT INTO {entity.TableName} ( {entity.InsertColumns} ) VALUES ( {entity.InsertValues} )";
            Debug.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public long InsertIntoOutput(IDomainObj entity)
        {
            SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText = $"INSERT INTO {entity.TableName} ( {entity.InsertColumns} ) " +
                $"OUTPUT INSERTED.id VALUES ( {entity.InsertValues} )";
            Debug.WriteLine(cmd.CommandText);
            object result = cmd.ExecuteScalar();
            cmd.Dispose();
            return Convert.ToInt64(result);
        }

        public List<IDomainObj> GetAll(IDomainObj entity)
        {
            SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText = $"SELECT {entity.SelectColumns} FROM {entity.TableName}  {entity.JoinClause}";
            Debug.WriteLine(cmd.CommandText);
            using SqlDataReader reader = cmd.ExecuteReader();
            List<IDomainObj>  lista  = entity.VratiListuSvi(reader);
            cmd.Dispose();
            return lista;
        }

        public List<IDomainObj> GetAllByCondition(IDomainObj entity)
        {
            SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText = $"SELECT {entity.SelectColumns} FROM {entity.TableName} {entity.JoinClause} WHERE {entity.WhereClause}";
            Debug.WriteLine(cmd.CommandText);
            using SqlDataReader reader = cmd.ExecuteReader();
            List<IDomainObj> lista = entity.VratiListuSvi(reader);
            cmd.Dispose();
            return lista;
        }

        public void Update(IDomainObj entity)
        {
            SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText =
                $"UPDATE {entity.TableName} SET {entity.UpdateSetClause} WHERE {entity.PrimaryKeyClause}";

            Debug.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void Delete(IDomainObj entity)
        {
            SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText = $"DELETE FROM {entity.TableName} WHERE {entity.PrimaryKeyClause}";
            Debug.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

    }
}
