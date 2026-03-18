using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class IzvorOcene : IDomainObj
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public string TableName => "IzvorOcene";

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
            List<IDomainObj> izvori = new List<IDomainObj>();

            while (reader.Read())
            {
                IzvorOcene io = new IzvorOcene
                {
                    Id = (long)reader["id"],
                    Naziv = (string)reader["naziv"],
                };
                izvori.Add(io);
            }

            return izvori;
        }

        public (string WhereClause, List<SqlParameter> Parameters) GetSearchCondition()
        {
            throw new NotImplementedException();
        }

        public string SelectColumns => "*";
        public string JoinClause => TableName;
    }
}
