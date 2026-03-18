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
        public string BrLicneKarte { get; set; }
        public string BrTel { get; set; }

        public string TableName => "Korisnik";
        public string KeyWhereClause => "id=@id";

        public List<SqlParameter> GetKeyParameters() => new()
        {
            new SqlParameter("@id", Id)
        };

        public string InsertColumns => "ime, prezime, brLicneKarte, brTel";

        public string InsertParameters => "@ime, @prezime, @brLicneKarte, @brTel";

        public string UpdateSetClause => "ime=@ime, prezime=@prezime, brLicneKarte=@brLicneKarte, brTel=@brTel";
        public List<SqlParameter> GetInsertParameters() => new()
        {
            new SqlParameter("@ime", Ime),
            new SqlParameter("@prezime", Prezime),
            new SqlParameter("@brLicneKarte",BrLicneKarte) ,
            new SqlParameter("@brTel",BrTel)
        };

        public List<SqlParameter> GetUpdateParameters()
        {
            return GetInsertParameters();
        }

        public List<IDomainObj> GetReaderList(SqlDataReader reader)
        {
            List<IDomainObj> korisnici = new List<IDomainObj>();

            while (reader.Read())
            {

                Korisnik korisnik = new Korisnik
                {
                    Id = (long)reader["id"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    BrLicneKarte = (string)reader["brLicneKarte"],
                    BrTel = (string)reader["brTel"]
                };
                korisnici.Add(korisnik);
            }

            return korisnici;
        }

        public (string WhereClause, List<SqlParameter> Parameters) GetSearchCondition()
        {
            throw new NotImplementedException();
        }


        // da generički repo može da pozove GetAllJoin bez pucanja:
        public string SelectColumns => "k.id, k.ime, k.prezime, k.brLicneKarte, k.brTel";
        public string JoinClause => "Korisnik k";
    }
}
