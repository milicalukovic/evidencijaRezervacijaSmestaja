using Common.Domain.Enums;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
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
        public DateOnly Mesec { get;  set; } = new DateOnly();
        public decimal SezonskiKoeficijentCene {  get; set; } 
        public decimal ProcenatAvansa { get; set; }


        //evidencija čuva stanje u trenutku kreiranja, ne zavisi od budućih promena smeštaja
        public decimal OsnovnaCenaPoOsobi
        {
            get; set;
            //get => SmestajnaJedinica?.CenaPoOsobi ?? 0;
            //set { } 
        }
        public VrstaUsluge OsnovnaVrstaUsluge
        {
            get; set;
            //get => SmestajnaJedinica?.OsnovnaVrstaUsluge ?? VrstaUsluge.Nocenje;
            //set { } 
        }
        public decimal PovecanjeCenePoUsluzi
        {
            get; set;
            //get => SmestajnaJedinica?.PovecanjeCenePoUsluzi ?? 0;
            //set { } 
        }
        public decimal UkupanIznos => StavkeEvidencije?.Sum(s => s.IznosRezervacije) ?? 0;
           // set { } ne ucitava se iz baze pa mu ne postavljamo novu vrednost u vratiSvi
        public Vlasnik Vlasnik { get; set; } = new Vlasnik();
        public SmestajnaJedinica SmestajnaJedinica { get; set; } = new SmestajnaJedinica();

        public List<StavkaEvidencije> StavkeEvidencije { get; set; } = new List<StavkaEvidencije>();


        public string TableName => "EvidencijaRez";
        public string InsertColumns => "mesec, sezonskiKoeficijentCene, procenatAvansa, osnovnaCenaPoOsobi, " +
            "osnovnaVrstaUsluge, PovecanjeCenePoUsluzi, idVlasnik, idSmestajnaJedinica";
        public string InsertValues => $"'{Mesec:yyyy-MM-dd}', {SezonskiKoeficijentCene.ToString(CultureInfo.InvariantCulture)}, " +
            $"{ProcenatAvansa.ToString(CultureInfo.InvariantCulture)}, {OsnovnaCenaPoOsobi.ToString(CultureInfo.InvariantCulture)}, " +
            $"{(int)OsnovnaVrstaUsluge}, {PovecanjeCenePoUsluzi.ToString(CultureInfo.InvariantCulture)}, " +
            $" {Vlasnik.Id}, {SmestajnaJedinica.Id}";
        public string PrimaryKeyClause => $"id = {Id}";

        public bool Validacija { get; set; }
        public string WhereClause { 
            get 
            {
                if (Validacija)
                {
                    return $" idVlasnik = {Vlasnik.Id} " +
                        $"AND idSmestajnaJedinica = {SmestajnaJedinica.Id} " +
                        $"AND mesec = '{Mesec:yyyy-MM-dd}'  ";
                }
                String uslovi = $" e.idVlasnik = {Vlasnik.Id} "; //ucitavanje svih u tabelu
                //kriterijumi pretrage
                if(Mesec != default)
                {
                    uslovi += $" AND e.mesec = '{Mesec:yyyy-MM-dd}' ";
                }

                if (!SmestajnaJedinica.Naziv.IsNullOrEmpty())
                {
                    uslovi += $" AND sj.naziv = '{SmestajnaJedinica.Naziv}' ";
                }
                if (StavkeEvidencije != null && StavkeEvidencije.Count > 0)
                {
                    var stavka = StavkeEvidencije.First();

                    if (stavka.Korisnik != null && !string.IsNullOrEmpty(stavka.Korisnik.BrLicneKarte))
                    {
                        uslovi += $" AND k.brLicneKarte = '{stavka.Korisnik.BrLicneKarte}' ";
                    }
                }
                //izabrana 
                if (Id != 0) 
                {
                    uslovi += $" AND e.id = {Id} ";
                }
                return uslovi;
            } 
            set { } }
        public string UpdateSetClause => $"mesec = '{Mesec:yyyy-MM-dd}', " +
                                         $"sezonskiKoeficijentCene = {SezonskiKoeficijentCene.ToString(CultureInfo.InvariantCulture)}, "+
                                         $"procenatAvansa = {ProcenatAvansa.ToString(CultureInfo.InvariantCulture)}, "+
                                         $"osnovnaCenaPoOsobi = {OsnovnaCenaPoOsobi.ToString(CultureInfo.InvariantCulture)}, " +
                                         $"osnovnaVrstaUsluge = {(int)OsnovnaVrstaUsluge}, "+
                                         $"PovecanjeCenePoUsluzi = {PovecanjeCenePoUsluzi.ToString(CultureInfo.InvariantCulture)}, "+
                                         $"idVlasnik = {Vlasnik.Id}, "+
                                         $"idSmestajnaJedinica = {SmestajnaJedinica.Id}";


        public List<IDomainObj> VratiListuSvi(SqlDataReader reader)
        {
            List<IDomainObj> evidencije = new List<IDomainObj>();
            while (reader.Read())
            {
                EvidencijaRez evidencija = new EvidencijaRez
                {
                    Id = (long)reader["idEvidencije"],
                    Mesec = DateOnly.FromDateTime((DateTime)reader["mesec"]),
                    SezonskiKoeficijentCene = (decimal)reader["sezonskiKoeficijentCene"],
                    ProcenatAvansa = (decimal)reader["procenatAvansa"],
                    //
                    OsnovnaVrstaUsluge = (VrstaUsluge)(int)reader["osnovnaVrstaUsluge"],
                    OsnovnaCenaPoOsobi = (decimal)reader["osnovnaCenaPoOsobi"],
                    PovecanjeCenePoUsluzi = (decimal)reader["povecanjeCenePoUsluzi"],
                    //
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
                        Naziv = reader["smestajNaziv"].ToString().Trim(),
                        OsnovnaVrstaUsluge = (VrstaUsluge)(int)reader["smestajOsnovnaVrstaUsluge"],
                        CenaPoOsobi = (decimal)reader["smestajCenaPoOsobi"],
                        PovecanjeCenePoUsluzi = (decimal)reader["smestajPovecanjeCenePoUsluzi"],
                        Vlasnik = reader["korisnickoIme"].ToString().Trim(), //povezala sa vlasnik tabelom???
                        Tip = new TipSmestaja()
                        {
                            Id = (long)reader["idTip"],
                            Naziv = reader["nazivTip"].ToString().Trim(),
                            MinKapacitet = (decimal)reader["minKapacitet"],
                            MaxKapacitet = (decimal)reader["maxKapacitet"]
                        }

                    },
                    StavkeEvidencije = new List<StavkaEvidencije>(),
                };
                evidencije.Add(evidencija);
            }
            return evidencije;
        }

        //JOIN (e + v + sj + ts)
        public string SelectColumns =>
            " distinct e.id AS idEvidencije, e.mesec, e.sezonskiKoeficijentCene, e.procenatAvansa, " +
            "e.osnovnaCenaPoOsobi, e.osnovnaVrstaUsluge, e.povecanjeCenePoUsluzi, " +
            "v.id AS idVlasnik, v.ime AS ime, v.prezime AS prezime, v.korisnickoIme AS korisnickoIme, v.lozinka AS lozinka, " +
            "sj.id AS idSmestajnaJedinica, sj.naziv AS smestajNaziv, sj.cenaPoOsobi AS smestajCenaPoOsobi, sj.osnovnaVrstaUsluge AS smestajOsnovnaVrstaUsluge, " +
            "sj.povecanjeCenePoUsluzi AS smestajPovecanjeCenePoUsluzi, ts.id AS idTip, ts.naziv AS nazivTip, ts.minKapacitet AS minKapacitet, ts.maxKapacitet AS maxKapacitet";

        public string JoinClause =>
            " e " +
            "JOIN Vlasnik v ON v.id = e.idVlasnik " +
            "JOIN SmestajnaJedinica sj ON sj.id = e.idSmestajnaJedinica " +
            "JOIN TipSmestaja ts ON ts.id = sj.idTip "+  
            //da bi mogao da nam vrati i tek kreiranu evidenciju koja nema stavke
            "LEFT JOIN StavkaEvidencije se ON se.idEvidencije = e.id "+
            "LEFT JOIN Korisnik k ON k.id = se.idKorisnik";

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is EvidencijaRez))
                return false;

            EvidencijaRez druga = (EvidencijaRez)obj;

            return this.Id == druga.Id;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
