using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Korisnik : IDomainObj
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrLicnogDokumenta { get; set; }
        public string Email { get; set; }
        public string BrTel { get; set; }

        public string TableName => "Korisnik";
        public string InsertColumns => "ime, prezime, brLicnogDokumenta, email, brTel";
        // InsertColumns name updated to brLicnogDokumenta to match DB column rename
        public string InsertValues => $"'{Ime}', '{Prezime}', '{BrLicnogDokumenta}', '{Email}', '{BrTel}'";
        public string PrimaryKeyClause => $"id = {Id}";
        public string WhereClause { get;  set ; }
        public string UpdateSetClause => "";
 
        public List<IDomainObj> VratiListuSvi(SqlDataReader reader)
        {
            List<IDomainObj> korisnici = new List<IDomainObj>();

            while (reader.Read())
            {

                Korisnik korisnik = new Korisnik
                {
                    Id = (long)reader["id"],
                    Ime = reader["ime"].ToString().Trim(),
                    Prezime = reader["prezime"].ToString().Trim(),
                    BrLicnogDokumenta = reader["brLicnogDokumenta"].ToString().Trim(),
                    Email = reader["email"] == DBNull.Value ? null : reader["email"].ToString().Trim(),
                    BrTel = reader["brTel"] == DBNull.Value ? null : reader["brTel"].ToString().Trim(),
                };
                korisnici.Add(korisnik);
            }

            return korisnici;
        }

        // da generički repo može da pozove GetAllJoin bez pucanja:
        public string SelectColumns => "*";
        public string JoinClause => "";

        }
}
