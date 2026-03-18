using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class EvidencijaRez : IDomainObj
    {
        public long Id { get; set; }
        public DateTime Mesec { get;  set; }
        public double CenaPoOsobi 
        {
            get => SmestajnaJedinica?.CenaPoOsobi ?? 0;
            set { } // čuva se u bazi, ali u domenu se izvlači iz SmestajnaJedinica
        }
        public double UkupanIznos 
        {
            get => StavkeEvidencije.Sum(s => s.Iznos);
            set { }
        }
        public Vlasnik Vlasnik { get; set; } = new Vlasnik();
        public SmestajnaJedinica SmestajnaJedinica { get; set; } = new SmestajnaJedinica();

        private List<StavkaEvidencije> stavke = new List<StavkaEvidencije>();
        public List<StavkaEvidencije> StavkeEvidencije { get => stavke; set => stavke = value; }


        public string TableName => "EvidencijaRez";

        public string KeyWhereClause => "id=@id";

        public List<SqlParameter> GetKeyParameters() => new()
        {
            new SqlParameter("@id", Id)
        };

        public string InsertColumns => "mesec, idVlasnik, idSmestajnaJedinica";

        public string InsertParameters => "@mesec, @idVlasnik, @idSmestajnaJedinica";

        public string UpdateSetClause => "mesec=@mesec, idVlasnik=@idVlasnik, idSmestajnaJedinica=@idSmestajnaJedinica";

        public List<SqlParameter> GetInsertParameters() => new ()
        {
            new SqlParameter("@mesec", Mesec),
            new SqlParameter("@idVlasnik", Vlasnik.Id),
            new SqlParameter("@idSmestajnaJedinica", SmestajnaJedinica.Id)
        };

        public List<SqlParameter> GetUpdateParameters()
        {
            return GetInsertParameters();
        }
        public List<IDomainObj> GetReaderList(SqlDataReader reader)
        {
            List<IDomainObj> evidencije = new List<IDomainObj>();
            while (reader.Read())
            {
                EvidencijaRez evidencija = new EvidencijaRez
                {
                    // ako je JOIN: čita e_id, e_cenaPoOsobi...
                    // ako nije JOIN: čita id, cenaPoOsobi...
                    Id = reader.ColumnsContains("e_id") ? (long)reader["e_id"] : (long)reader["id"],
                    Mesec = (DateTime)reader["mesec"],
                    Vlasnik = new Vlasnik
                    {
                        Id = (long)reader["idVlasnik"],
                        Ime = reader.ColumnsContains("v_ime") ? reader["v_ime"]?.ToString() ?? "" : "",
                        Prezime = reader.ColumnsContains("v_prezime") ? reader["v_prezime"]?.ToString() ?? "" : "",
                        KorisnickoIme = reader.ColumnsContains("v_korisnickoIme") ? reader["v_korisnickoIme"]?.ToString() ?? "" : ""

                    },
                    SmestajnaJedinica = new SmestajnaJedinica
                    {
                        Id = (long)reader["idSmestajnaJedinica"],
                        Naziv = reader.ColumnsContains("sj_naziv") ? reader["sj_naziv"]?.ToString() ?? "" : "",
                        Kapacitet = reader.ColumnsContains("sj_kapacitet") ? Convert.ToInt32(reader["sj_kapacitet"]) : 0,
                        CenaPoOsobi = reader.ColumnsContains("sj_cenaPoOsobi") ? Convert.ToDouble(reader["sj_cenaPoOsobi"]) : 0,
                        MinOsoba = reader.ColumnsContains("sj_minOsoba") ? Convert.ToInt32(reader["sj_minOsoba"]) : 0,
                        Tip = new TipSmestaja
                        {
                            Id = reader.ColumnsContains("idTip") ? (long)reader["idTip"] : 0,
                            Naziv = reader.ColumnsContains("ts_naziv") ? reader["ts_naziv"]?.ToString() ?? "" : ""
                        }
                    }
                };
                evidencije.Add(evidencija);
            }
            return evidencije;
        }

        public (string WhereClause, List<SqlParameter> Parameters) GetSearchCondition()
        {
            throw new NotImplementedException();
        }

        //JOIN (e + v + sj + ts)
        public string SelectColumns =>
            "e.id AS e_id, e.mesec, e.cenaPoOsobi AS e_cenaPoOsobi, e.idVlasnik, e.idSmestajnaJedinica, " +
            "v.ime AS v_ime, v.prezime AS v_prezime, v.korisnickoIme AS v_korisnickoIme, " +
            "sj.naziv AS sj_naziv, sj.kapacitet AS sj_kapacitet, sj.cenaPoOsobi AS sj_cenaPoOsobi, sj.minOsoba AS sj_minOsoba, sj.idTip, " +
            "ts.naziv AS ts_naziv";

        public string JoinClause =>
            "EvidencijaRez e " +
            "JOIN Vlasnik v ON v.id = e.idVlasnik " +
            "JOIN SmestajnaJedinica sj ON sj.id = e.idSmestajnaJedinica " +
            "JOIN TipSmestaja ts ON ts.id = sj.idTip";
    }
}
