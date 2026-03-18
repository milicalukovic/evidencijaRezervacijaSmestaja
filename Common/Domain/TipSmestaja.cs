using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class TipSmestaja : IDomainObj
    {

        public long Id { get; set; }
        public string Naziv { get; set; }
        public string TableName => "TipSmestaja";

        public string KeyWhereClause => "id=@id";

        public List<SqlParameter> GetKeyParameters() => new()
        {
            new SqlParameter("@id", Id)
        };

        public string InsertColumns => "naziv";

        public string InsertParameters => "@naziv";

        public string UpdateSetClause => "naziv=@naziv";
        public List<SqlParameter> GetInsertParameters() => new()
        {
            new SqlParameter("@naziv",Naziv)
        };

        public List<SqlParameter> GetUpdateParameters()
        {
            return GetInsertParameters();
        }

        public List<IDomainObj> GetReaderList(SqlDataReader reader)
        {
            List<IDomainObj> tipovi = new List<IDomainObj>();

            while (reader.Read())
            {
                TipSmestaja s = new TipSmestaja
                {
                    Id = (long)reader["id"],
                    Naziv = (string)reader["naziv"],
                };
                tipovi.Add(s);
            }

            return tipovi;
        }

        public (string WhereClause, List<SqlParameter> Parameters) GetSearchCondition()
        {
            throw new NotImplementedException();
        }

        public string SelectColumns => "*";
        public string JoinClause => TableName; 
    }
}
