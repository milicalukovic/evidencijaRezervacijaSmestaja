using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class StavkaEvidencije : IDomainObj
    {
        public EvidencijaRez Evidencija {  get; set; } = new EvidencijaRez();
        public long Rb {  get; set; }
        public int DanDolaska { get; set; }
        public int DanOdlaska { get; set; }
        public Korisnik Korisnik { get; set; } = new Korisnik();
        public int BrDana => DanOdlaska - DanDolaska;
        public int BrOsoba { get; set;}
        public double Iznos => BrDana * BrOsoba * Evidencija.CenaPoOsobi;

        public string TableName => "StavkaEvidencije";

        public string KeyWhereClause => "idEvidencije=@idEvidencije AND rb=@rb";

        public List<SqlParameter> GetKeyParameters() => new()
        {
            new SqlParameter("@idEvidencije", Evidencija.Id),
            new SqlParameter("@rb", Rb)
        };
        public string InsertColumns => "idEvidencije, rb, danDolaska, danOdlaska, idKorisnik, brOsoba";

        public string InsertParameters => "@idEvidencije, @rb, @danDolaska, @danOdlaska, @idKorisnik, @brOsoba";

        public string UpdateSetClause => "danDolaska=@danDolaska, danOdlaska=@danOdlaska, idKorisnik=@idKorisnik, brOsoba=@brOsoba";

        public List<SqlParameter> GetInsertParameters() => new()
        {
            new SqlParameter("@idEvidencije", Evidencija.Id),
            new SqlParameter("@rb", Rb),
            new SqlParameter("@danDolaska", DanDolaska),
            new SqlParameter("@danOdlaska", DanOdlaska),
            new SqlParameter("@idKorisnik", Korisnik.Id),
            new SqlParameter("@brOsoba", BrOsoba),
        };

        public List<SqlParameter> GetUpdateParameters()
                => new()
                {
                    new SqlParameter("@danDolaska", DanDolaska),
                    new SqlParameter("@danOdlaska", DanOdlaska),
                    new SqlParameter("@idKorisnik", Korisnik.Id),
                    new SqlParameter("@brOsoba", BrOsoba),

                };

        public List<IDomainObj> GetReaderList(SqlDataReader reader)
        {
            List<IDomainObj> stavke = new List<IDomainObj>();

            while (reader.Read())
            {
                StavkaEvidencije s = new StavkaEvidencije
                {
                    Evidencija = new EvidencijaRez
                    {
                        Id = (long)reader["idEvidencije"],
                        // ako dolazi iz JOIN upita:
                        Mesec = reader.ColumnsContains("e_mesec") ? Convert.ToDateTime(reader["e_mesec"]) : default
                    },
                    Rb = (long)reader["rb"],
                    DanDolaska = (int)reader["danDolaska"],
                    DanOdlaska = (int)reader["danOdlaska"],
                    Korisnik = new Korisnik
                    {
                        Id = (long)reader["idKorisnik"],
                        // ako dolazi iz JOIN upita:
                        Ime = reader.ColumnsContains("k_ime") ? reader["k_ime"]?.ToString() ?? "" : "",
                        Prezime = reader.ColumnsContains("k_prezime") ? reader["k_prezime"]?.ToString() ?? "" : "",
                        BrLicneKarte = reader.ColumnsContains("k_brLicneKarte") ? reader["k_brLicneKarte"]?.ToString() ?? "" : "",
                        BrTel = reader.ColumnsContains("k_brTel") ? reader["k_brTel"]?.ToString() ?? "" : ""
                    },
                    BrOsoba = (int)reader["brOsoba"]

                };
                stavke.Add(s);            
            }
            return stavke;
        }

        public (string WhereClause, List<SqlParameter> Parameters) GetSearchCondition()
        {
            throw new NotImplementedException();
        }

        public string SelectColumns =>
            "s.idEvidencije, s.rb, s.danDolaska, s.danOdlaska, s.idKorisnik, s.brOsoba, " +
            "k.ime AS k_ime, k.prezime AS k_prezime, k.brLicneKarte AS k_brLicneKarte, k.brTel AS k_brTel, " +
            "e.mesec AS e_mesec";

        public string JoinClause =>
            "StavkaEvidencije s " +
            "JOIN Korisnik k ON k.id = s.idKorisnik " +
            "JOIN EvidencijaRez e ON e.id = s.idEvidencije";
    }
}
