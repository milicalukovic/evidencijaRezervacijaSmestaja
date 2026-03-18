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

        public string KeyWhereClause => "id=@id";

        public List<SqlParameter> GetKeyParameters() => new()
        {
            new SqlParameter("@id", Id)
        };

        public string InsertColumns => "ime, prezime, korisnickoIme, lozinka";

        public string InsertParameters => "@ime, @prezime, @korisnickoIme, @lozinka";

        public string UpdateSetClause => "ime=@ime, prezime=@prezime, korisnickoIme=@korisnickoIme, lozinka=@lozinka";

        public List<SqlParameter> GetInsertParameters() => new()
        {
            new SqlParameter("@ime", Ime),
            new SqlParameter("@prezime", Prezime),
            new SqlParameter("@korisnickoIme", KorisnickoIme),
            new SqlParameter("@lozinka", Lozinka)
        };

        public List<SqlParameter> GetUpdateParameters()
        {
            var p = GetInsertParameters();
            //p.Add(new SqlParameter("@id", Id));
            // Generički repo će dodati i Key parametre posebno
            return p;
        }

        public List<IDomainObj> GetReaderList(SqlDataReader reader)
        {
            List<IDomainObj> vlasnici = new List<IDomainObj>();

            while (reader.Read())
            {

                Vlasnik vl = new Vlasnik
                {
                    Id = (long)reader["id"],
                    Ime = (string)reader["ime"],
                    Prezime = (string)reader["prezime"],
                    KorisnickoIme = (string)reader["korisnickoIme"],
                    Lozinka = (string)reader["lozinka"]
                };
                vlasnici.Add(vl);
            }

            return vlasnici;
        }

        public (string WhereClause, List<SqlParameter> Parameters) GetSearchCondition()
        {
            // login scenario: trazimo po korisnickom imenu i lozinci
            return (
                "korisnickoIme=@korisnickoIme AND lozinka=@lozinka",
                new List<SqlParameter>
                {
                    new SqlParameter("@korisnickoIme", KorisnickoIme),
                    new SqlParameter("@lozinka", Lozinka)
                }
            );
        }

        // JOIN (nema join, ali generički repo hoće FROM deo)
        public string SelectColumns => "*";
        public string JoinClause => TableName; 


    }
}
