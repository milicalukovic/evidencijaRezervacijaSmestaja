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
        public decimal MinKapacitet { get; set; }
        public decimal MaxKapacitet { get; set; }

        public string TableName => "TipSmestaja";
        public string InsertColumns => "naziv, minKapacitet, maxKapacitet";
        public string InsertValues => $"'{Naziv}', {MinKapacitet}, {MaxKapacitet}";
        public string PrimaryKeyClause => "";
        public string WhereClause { get ; set ; }
        public string UpdateSetClause => "";

        public List<IDomainObj> VratiListuSvi(SqlDataReader reader)
        {
            List<IDomainObj> tipovi = new List<IDomainObj>();

            while (reader.Read())
            {
                TipSmestaja s = new TipSmestaja
                {
                    Id = (long)reader["id"],
                    Naziv = reader["naziv"].ToString().Trim(),
                    MinKapacitet = (decimal)reader["minKapacitet"],
                    MaxKapacitet = (decimal)reader["maxKapacitet"]
                };
                tipovi.Add(s);
            }

            return tipovi;
        }
        public string SelectColumns => "*";
        public string JoinClause => "";

        public override string ToString()
        {
            return Naziv;
        }

     }
}
