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

        public string InsertColumns => "naziv";
        public string InsertValues => $"'{Naziv}'";
        public string PrimaryKeyClause => "";
        public string WhereClause { get => $" id = {Id}"; set { } }
        public string UpdateSetClause => "";
        
        public List<IDomainObj> VratiListuSvi(SqlDataReader reader)
        {
            List<IDomainObj> izvori = new List<IDomainObj>();

            while (reader.Read())
            {
                IzvorOcene io = new IzvorOcene
                {
                    Id = Convert.ToInt64(reader["id"]),
                    Naziv = reader["naziv"].ToString().Trim(),
                };
                izvori.Add(io);
            }
            return izvori;
        }

        public string SelectColumns => "*";
        public string JoinClause => "";

        public override string ToString()
        {
            return Naziv;
        }
    }
}
