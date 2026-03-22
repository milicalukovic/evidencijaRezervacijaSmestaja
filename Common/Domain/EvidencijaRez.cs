using Common.Domain.enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class EvidencijaRez : IDomainObj
    {
        public long Id { get; set; }
        public DateOnly Mesec { get;  set; }
        public decimal SezonskiKoeficijentCene {  get; set; }
        public decimal ProcenatAvansa {  get; set; }
        public decimal OsnovnaCenaPoOsobi
        {
            get => SmestajnaJedinica?.CenaPoOsobi ?? 0;
            set { } // čuva se u bazi, ali u domenu se izvlači iz SmestajnaJedinica
        }
        public VrstaUsluge OsnovnaVrstaUsluge
        {
            get => SmestajnaJedinica?.OsnovnaVrstaUsluge ?? 0;
            set { } 
        }
        public decimal PovecanjeCenePoUsluzi
        {
            get => SmestajnaJedinica?.PovecanjeCenePoUsluzi ?? 0;
            set { } 
        }
        public decimal UkupanIznos 
        {
            get => StavkeEvidencije.Sum(s => s.IznosRezervacije);
            set { }
        }
        public Vlasnik Vlasnik { get; set; } = new Vlasnik();
        public SmestajnaJedinica SmestajnaJedinica { get; set; } = new SmestajnaJedinica();

        private List<StavkaEvidencije> stavke = new List<StavkaEvidencije>();
        public List<StavkaEvidencije> StavkeEvidencije { get => stavke; set => stavke = value; }


        public string TableName => "EvidencijaRez";
        public string InsertColumns => "mesec, sezonskiKoeficijentCene, procenatAvansa, osnovnaCenaPoOsobi, " +
            "osnovnaVrstaUsluge, PovecanjeCenePoUsluzi, ukupanIznos, idVlasnik, idSmestajnaJedinica";
        public string InsertValues => $"'{Mesec}', {SezonskiKoeficijentCene.ToString(CultureInfo.InvariantCulture)}, " +
            $"{ProcenatAvansa.ToString(CultureInfo.InvariantCulture)}, {OsnovnaCenaPoOsobi.ToString(CultureInfo.InvariantCulture)}, " +
            $"{(int)OsnovnaVrstaUsluge}, {PovecanjeCenePoUsluzi.ToString(CultureInfo.InvariantCulture)}, " +
            $"{UkupanIznos.ToString(CultureInfo.InvariantCulture)}, {Vlasnik.Id}, {SmestajnaJedinica.Id}";
        public string PrimaryKeyClause => $"id = {Id}";
        public string WhereClause { get; set; }
        public string UpdateSetClause => $"mesec = '{Mesec}', "+
                                         $"sezonskiKoeficijentCene = {SezonskiKoeficijentCene.ToString(CultureInfo.InvariantCulture)}, "+
                                         $"procenatAvansa = {ProcenatAvansa.ToString(CultureInfo.InvariantCulture)}, "+
                                         $"osnovnaCenaPoOsobi = {OsnovnaCenaPoOsobi.ToString(CultureInfo.InvariantCulture)}, " +
                                         $"osnovnaVrstaUsluge = {(int)OsnovnaVrstaUsluge}, "+
                                         $"PovecanjeCenePoUsluzi = {PovecanjeCenePoUsluzi.ToString(CultureInfo.InvariantCulture)}, "+
                                         $"ukupanIznos = {UkupanIznos.ToString(CultureInfo.InvariantCulture)}, "+
                                         $"idVlasnik = {Vlasnik.Id}, "+
                                         $"idSmestajnaJedinica = {SmestajnaJedinica.Id}";


        public List<IDomainObj> VratiListuSvi(SqlDataReader reader)
        {
            List<IDomainObj> evidencije = new List<IDomainObj>();
            while (reader.Read())
            {
                EvidencijaRez evidencija = new EvidencijaRez
                {
                    Id = (long)reader["idEvidencija"],
                    Mesec = (DateOnly)reader["mesec"],
                    SezonskiKoeficijentCene = (decimal)reader["sezonskiKoeficijentCene"],
                    ProcenatAvansa = (decimal)reader["procenatAvansa"],
                    OsnovnaVrstaUsluge = (VrstaUsluge)(int)reader["e.osnovnaVrstaUsluge"],
                    OsnovnaCenaPoOsobi = (decimal)reader["e.osnovnaCenaPoOsobi"],
                    PovecanjeCenePoUsluzi = (decimal)reader["e.PovecanjeCenePoUsluzi"],
                    UkupanIznos = (decimal)reader["ukupanIznos"],
                    Vlasnik = new Vlasnik
                    {
                        Id = Convert.ToInt64(reader["idVlasnik"]),
                        Ime = reader["ime"].ToString().Trim(),
                        Prezime = reader["prezime"].ToString().Trim(),
                        KorisnickoIme = reader["korisnickoIme"].ToString().Trim(),
                        Lozinka = reader["lozinka"].ToString().Trim(),
                    },
                    SmestajnaJedinica = new SmestajnaJedinica
                    {
                        Id = (long)reader["idSmestajnaJedinica"],
                        Naziv = reader["nazivSmestaj"].ToString().Trim(),
                        OsnovnaVrstaUsluge = (VrstaUsluge)(int)reader["sj.osnovnaVrstaUsluge"],
                        CenaPoOsobi = (decimal)reader["sj.cenaPoOsobi"],
                        PovecanjeCenePoUsluzi = (decimal)reader["sj.PovecanjeCenePoUsluzi"],
                        Vlasnik = reader["korisnickoIme"].ToString().Trim(), //povezala sa vlasnik tabelom???
                        Tip = new TipSmestaja()
                        {
                            Id = (long)reader["idTip"],
                            Naziv = reader["nazivTip"].ToString().Trim(),
                            MinKapacitet = (decimal)reader["minKapacitet"],
                            MaxKapacitet = (decimal)reader["maxKapacitet"]
                        }

                    },
                };
                evidencije.Add(evidencija);
            }
            return evidencije;
        }

        //JOIN (e + v + sj + ts)
        public string SelectColumns =>
            " distinct e.id AS idEvidencije, e.mesec, e.sezonskiKoeficijentCene, e.procenatAvansa, " +
            "e.osnovnaCenaPoOsobi, e.osnovnaVrstaUsluge, e.PovecanjeCenePoUsluzi, e.ukupanIznos, " +
            "v.id = idVlasnik, v.ime AS ime, v.prezime AS prezime, v.korisnickoIme AS korisnickoIme, v.lozinka AS lozinka, " +
            "sj.id = idSmestajnaJedinica, sj.naziv AS nazivSmestaj, sj.cenaPoOsobi, sj.osnovnaVrstaUsluge, sj.PovecanjeCenePoUsluzi, " +
            "ts.id = idTip, ts.naziv AS nazivTip, ts.minKapacitet AS minKapacitet, ts.maxKapacitet AS maxKapacitet";

        public string JoinClause =>
            " e " +
            "JOIN Vlasnik v ON v.id = e.idVlasnik " +
            "JOIN SmestajnaJedinica sj ON sj.id = e.idSmestajnaJedinica " +
            "JOIN TipSmestaja ts ON ts.id = sj.idTip"+
            "JOIN StavkaEvidencije se ON se.idEvidencije = e.id"+
            "JOIN Korisnik k ON k.id = se.idKorisnik";

    }
}
