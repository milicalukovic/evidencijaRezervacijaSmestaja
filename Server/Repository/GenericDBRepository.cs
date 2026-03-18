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
        public void Add(IDomainObj obj)
        {
            using SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText =
                $"INSERT INTO {obj.TableName} ({obj.InsertColumns}) VALUES ({obj.InsertParameters})";
            cmd.Parameters.AddRange(obj.GetInsertParameters().ToArray());
            cmd.ExecuteNonQuery();
        }
        public List<IDomainObj> GetAll(IDomainObj obj)
        {
            using SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {obj.TableName}";
            using SqlDataReader reader = cmd.ExecuteReader();
            return obj.GetReaderList(reader);
        }
        //klijent ne šalje whereClause string, nego šalje kriterijum (objekat), a server (SO) iz toga sklapa WHERE + parametre
        public List<IDomainObj> GetByCondition(IDomainObj entity)
        {
            var (where, parameters) = entity.GetSearchCondition(); // ako domen ne podrzava ovu pretragu, baciće exception

            using SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {entity.TableName} WHERE {where}";
            cmd.Parameters.AddRange(parameters.ToArray());

            using SqlDataReader reader = cmd.ExecuteReader();
            return entity.GetReaderList(reader);
        }

        public List<IDomainObj> GetByCondition(IDomainObj entity, string whereClause, List<SqlParameter> parameters)
        {
            using SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {entity.TableName} WHERE {whereClause}";
            if (parameters != null && parameters.Count > 0)
                cmd.Parameters.AddRange(parameters.ToArray());

            using SqlDataReader reader = cmd.ExecuteReader();
            return entity.GetReaderList(reader);
        }
        public List<IDomainObj> GetAllJoin(IDomainObj obj)
        {
            using SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText = $"SELECT {obj.SelectColumns} FROM {obj.JoinClause}";
            using SqlDataReader reader = cmd.ExecuteReader();
            return obj.GetReaderList(reader);
        }

        public void Update(IDomainObj obj)
        {
            using SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText =
                $"UPDATE {obj.TableName} SET {obj.UpdateSetClause} WHERE {obj.KeyWhereClause}";

            cmd.Parameters.AddRange(obj.GetUpdateParameters().ToArray());
            cmd.Parameters.AddRange(obj.GetKeyParameters().ToArray());

            cmd.ExecuteNonQuery();
        }

        public void Delete(IDomainObj obj)
        {
            using SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText = $"DELETE FROM {obj.TableName} WHERE {obj.KeyWhereClause}";
            cmd.Parameters.AddRange(obj.GetKeyParameters().ToArray());
            cmd.ExecuteNonQuery();
        }
        public IDomainObj? GetByKey(IDomainObj obj)
        {
            using SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {obj.TableName} WHERE {obj.KeyWhereClause}";
            cmd.Parameters.AddRange(obj.GetKeyParameters().ToArray());

            using SqlDataReader reader = cmd.ExecuteReader();
            return obj.GetReaderList(reader).FirstOrDefault();
        }
        //kada nam je potrebno da zapamtimo Id koji server sam generise
        public long AddReturnId(IDomainObj obj)
        {
            using SqlCommand cmd = broker.CreateCommand();
            cmd.CommandText =
                $"INSERT INTO {obj.TableName} ({obj.InsertColumns}) " +
                $"OUTPUT INSERTED.id " +
                $"VALUES ({obj.InsertParameters})";
                                //output inserted.id = Posle INSERT-a, vrati mi vrednost
                                //kolone id tog reda koji je upravo ubačen

            cmd.Parameters.AddRange(obj.GetInsertParameters().ToArray());
            return (long)cmd.ExecuteScalar(); //izvršava SQL i uzima prvu kolonu iz prvog reda rezultata tj. inserted.id

        }

    }
}
