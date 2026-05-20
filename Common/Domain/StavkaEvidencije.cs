using Common.Domain.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class StavkaEvidencije : IDomainObj
    {
        public EvidencijaRez Evidencija {  get; set; }
        public long Rb {  get; set; } //postavljamo na serveru kada menjamo evidenciju u odnosu na trenutni br stavki
        public StatusStavke StatusStavke { get; set; }
        //pamti stvarni period rezervacije
        public DateOnly Dolazak { get; set; }
        public DateOnly Odlazak { get; set; }
        public Korisnik Korisnik { get; set; } = new Korisnik();
        //broj dana koji pripada trenutnoj eviddenciji (do 1. narednog meseca)
        public int BrDana { get; set; }
        public decimal BrOsoba { get; set;}
        public VrstaUsluge VrstaUsluge { get; set; }

        public decimal IznosUsluge { get; set; }
        public decimal IznosRezervacije { get; set; }
        public decimal IznosAvansa { get; set; }
        
        public Boolean UplacenAvans { get; set; }

        public string TableName => "StavkaEvidencije";
        public string InsertColumns => " idEvidencije, rb, dolazak, odlazak, brDana, brOsoba, " +
                                        " idKorisnik, vrstaUsluge, uplacenAvans, iznosUsluge, iznosRezervacije, iznosAvansa ";
        public string InsertValues => $" {Evidencija?.Id}, {Rb}, '{Dolazak:yyyy-MM-dd}', '{Odlazak:yyyy-MM-dd}', {BrDana}, " +
                                $"{BrOsoba.ToString(CultureInfo.InvariantCulture)}, {Korisnik?.Id}, " +
                                $" {(int)VrstaUsluge}, {(UplacenAvans ? 1 : 0)}, "+
                                $"{IznosUsluge.ToString(CultureInfo.InvariantCulture)}, " +
                                $"{IznosRezervacije.ToString(CultureInfo.InvariantCulture)}, " +
                                $"{IznosAvansa.ToString(CultureInfo.InvariantCulture)}";
        public string PrimaryKeyClause => $"idEvidencije = {Evidencija?.Id} AND rb = {Rb} ";
        public string WhereClause { get => $" s.idEvidencije = {Evidencija?.Id}"; set { } }
        public string UpdateSetClause =>$"dolazak = '{Dolazak:yyyy-MM-dd}', " +
                                        $"odlazak = '{Odlazak:yyyy-MM-dd}', " +
                                        $"brDana = {BrDana}, " +
                                        $"brOsoba = {BrOsoba.ToString(CultureInfo.InvariantCulture)}, " +
                                        $"idKorisnik = {Korisnik?.Id}, " +
                                        $"vrstaUsluge = {(int)VrstaUsluge}, " +
                                        $"uplacenAvans = {(UplacenAvans ? 1 : 0)}, "+
                                        $"iznosUsluge = {IznosUsluge.ToString(CultureInfo.InvariantCulture)}, " +
                                        $"iznosRezervacije = {IznosRezervacije.ToString(CultureInfo.InvariantCulture)}, " +
                                        $"iznosAvansa = {IznosAvansa.ToString(CultureInfo.InvariantCulture)}";

        public List<IDomainObj> VratiListuSvi(SqlDataReader reader)
        {
            List<IDomainObj> stavke = new List<IDomainObj>();

            while (reader.Read())
            {
                StavkaEvidencije s = new StavkaEvidencije
                {
                    Evidencija = new EvidencijaRez
                    {
                        Id = (long)reader["idEvidencije"],
                        SezonskiKoeficijentCene = (decimal)reader["sezonskiKoeficijentCene"],
                        ProcenatAvansa = (decimal)reader["procenatAvansa"],
                        OsnovnaVrstaUsluge = (VrstaUsluge)(int)reader["osnovnaVrstaUsluge"],
                        OsnovnaCenaPoOsobi = (decimal)reader["osnovnaCenaPoOsobi"],
                        PovecanjeCenePoUsluzi = (decimal)reader["PovecanjeCenePoUsluzi"],
                    },
                    Rb = (long)reader["rb"],
                    Dolazak = DateOnly.FromDateTime((DateTime)reader["dolazak"]),
                    Odlazak = DateOnly.FromDateTime((DateTime)reader["odlazak"]),
                    BrDana = (int)reader["brDana"],
                    BrOsoba = (decimal)reader["brOsoba"],
                    VrstaUsluge = (VrstaUsluge)(int)reader["vrstaUsluge"],
                    UplacenAvans = (Boolean)reader["uplacenAvans"],
                    IznosUsluge = (decimal)reader["iznosUsluge"],
                    IznosRezervacije = (decimal)reader["iznosRezervacije"],
                    IznosAvansa = (decimal)reader["iznosAvansa"],
                    Korisnik = new Korisnik
                    {
                        Id = (long)reader["idKorisnik"],
                        Ime = reader["ime"].ToString().Trim(),
                        Prezime = reader["prezime"].ToString().Trim(),
                        BrLicneKarte = reader["brLicneKarte"].ToString().Trim(),
                        Email = reader["email"] == DBNull.Value ? "-" : reader["email"].ToString().Trim(),
                        BrTel = reader["brTel"] == DBNull.Value ? "-" : reader["brTel"].ToString().Trim(),
                    },


                };
                stavke.Add(s);            
            }
            return stavke;
        }

        public string SelectColumns =>
            "s.idEvidencije, s.rb, s.dolazak, s.odlazak, s.brDana, s.brOsoba, s.idKorisnik," +
            " s.vrstaUsluge, s.uplacenAvans, s.iznosUsluge, s.iznosRezervacije, s.iznosAvansa, " +
            " k.ime , k.prezime, k.brLicneKarte, k.email, k.brTel, " +
            " e.sezonskiKoeficijentCene, e.procenatAvansa, e.osnovnaVrstaUsluge, e.osnovnaCenaPoOsobi, e.PovecanjeCenePoUsluzi";

        public string JoinClause =>
            " s " +
            "JOIN Korisnik k ON k.id = s.idKorisnik " +
            "JOIN EvidencijaRez e ON e.id = s.idEvidencije";

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is StavkaEvidencije))
                return false;

            StavkaEvidencije druga = (StavkaEvidencije)obj;

            return this.Rb == druga.Rb &&
                   this.Evidencija.Id == druga.Evidencija.Id;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Rb, Evidencija.Id);
        }


        public void IzracunajIznose()
        {
            if (Evidencija == null) return;

            IznosUsluge =
                (Evidencija.OsnovnaCenaPoOsobi +
                Evidencija.PovecanjeCenePoUsluzi *
                ((int)VrstaUsluge - (int)Evidencija.OsnovnaVrstaUsluge))
                * Evidencija.SezonskiKoeficijentCene;

            IznosRezervacije = BrDana * BrOsoba * IznosUsluge;

            IznosAvansa = IznosRezervacije * Evidencija.ProcenatAvansa;
        }
    }
}
