using Common.Domain;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Security.Principal;

namespace DBBroker
{
    public class Broker
    {
        private DbConnection connection;
        public Broker()
        {
            connection = new DbConnection();
        }
        public void OpenConnection() => connection.OpenConnection();
        public void CloseConnection() => connection.CloseConnection();
        public void BeginTransaction() => connection.BeginTransaction();
        public void Commit() => connection.Commit();
        public void Rollback() => connection.Rollback();
        public SqlCommand CreateCommand()
        {
            return connection.CreateCommand();
        }

        public void Insert(IDomainObj entity)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText =
                $"INSERT INTO {entity.TableName} ( {entity.InsertColumns} ) VALUES ( {entity.InsertValues} )";
            cmd.CommandTimeout = 120; // povećaj timeout da bi se obradile sporije operacije
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public long InsertOutput(IDomainObj entity)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText =
                $"INSERT INTO {entity.TableName} ( {entity.InsertColumns} ) " +
                $"OUTPUT INSERTED.id VALUES ( {entity.InsertValues} )";
            cmd.CommandTimeout = 120;

            object result = cmd.ExecuteScalar();
            cmd.Dispose();

            return Convert.ToInt64(result);
        }
        public List<IDomainObj> ReadAll(IDomainObj entity)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText =
                $"SELECT {entity.SelectColumns} FROM {entity.TableName} {entity.JoinClause}";
            cmd.CommandTimeout = 120; 

            using SqlDataReader reader = cmd.ExecuteReader();
            List<IDomainObj> list = entity.VratiListuSvi(reader);

            cmd.Dispose();
            return list;
        }
        public List<IDomainObj> ReadAllByCondition(IDomainObj entity)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText =
                $"SELECT {entity.SelectColumns} FROM {entity.TableName} {entity.JoinClause} " +
                $"WHERE {entity.WhereClause}";
            cmd.CommandTimeout = 120;
            using SqlDataReader reader = cmd.ExecuteReader();
            List<IDomainObj> list = entity.VratiListuSvi(reader);

            cmd.Dispose();
            return list;
        }
        public void Update(IDomainObj entity)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText =
                $"UPDATE {entity.TableName} SET {entity.UpdateSetClause} WHERE {entity.PrimaryKeyClause}";
            cmd.CommandTimeout = 120;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        public void Delete(IDomainObj entity)
        {
            SqlCommand cmd = CreateCommand();
            cmd.CommandText =
                $"DELETE FROM {entity.TableName} WHERE {entity.PrimaryKeyClause}";
            cmd.CommandTimeout = 120;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }
}

