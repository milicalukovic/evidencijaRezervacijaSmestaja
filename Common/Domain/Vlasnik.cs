using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Vlasnik : IDomainObj
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public string TableName => "Vlasnik";
        public string InsertColumns => "ime, prezime, korisnickoIme, lozinka";
        public string InsertValues => $"'{Ime}', '{Prezime}', '{KorisnickoIme}', '{Lozinka}'";
        public string PrimaryKeyClause => "";
        public string WhereClause { get => $" korisnickoIme = '{KorisnickoIme}' AND lozinka = '{Lozinka}'"; set { } }
        public string UpdateSetClause => "";

        public List<IDomainObj> VratiListuSvi(SqlDataReader reader)
        {
            List<IDomainObj> vlasnici = new List<IDomainObj>();

            while (reader.Read())
            {
                Vlasnik vl = new Vlasnik
                {
                    Id = Convert.ToInt64(reader["id"]),
                    Ime = reader["ime"].ToString().Trim(),
                    Prezime = reader["prezime"].ToString().Trim(),
                    KorisnickoIme = reader["korisnickoIme"].ToString().Trim(),
                    Lozinka = reader["lozinka"].ToString().Trim(),
                };
                vlasnici.Add(vl);
            }
            return vlasnici;
        }


        // JOIN (nema join)
        public string SelectColumns => " * ";
        public string JoinClause => "";

       }
}
