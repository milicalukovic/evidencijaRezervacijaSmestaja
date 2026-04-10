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
        public int DanDolaska { get; set; }
        public int DanOdlaska { get; set; }
        public Korisnik Korisnik { get; set; } = new Korisnik();
        public int BrDana { get; set; }
            //=> DanOdlaska - DanDolaska, ali  kada prelazi u drugi mesec => brDana = DanOdlaska - DanDolaska + 1
        public decimal BrOsoba { get; set;}
        public VrstaUsluge VrstaUsluge { get; set; }

        //iznose ne cuvamo u bazi jer svaki put na osnovu vrednosti iz baze racunamo njihovu vrednost
        public decimal IznosUsluge => Evidencija == null ? 0 : (Evidencija.OsnovnaCenaPoOsobi +Evidencija.PovecanjeCenePoUsluzi * 
                                    ((int)VrstaUsluge - (int)Evidencija.OsnovnaVrstaUsluge))*
                                    Evidencija.SezonskiKoeficijentCene;
        public decimal IznosRezervacije => BrDana * BrOsoba * IznosUsluge ;
        public decimal IznosAvansa => Evidencija == null ? 0 : IznosRezervacije * Evidencija.ProcenatAvansa ;

        public Boolean UplacenAvans { get; set; }

        public string TableName => "StavkaEvidencije";
        public string InsertColumns => " idEvidencije, rb, danDolaska, danOdlaska, brDana, brOsoba, " +
                                        " idKorisnik, vrstaUsluge, uplacenAvans";
        public string InsertValues => $" {Evidencija.Id}, {Rb}, {DanDolaska}, {DanOdlaska}, {BrDana}, " +
                                $"{BrOsoba.ToString(CultureInfo.InvariantCulture)}, {Korisnik?.Id}, " +
                                $" {(int)VrstaUsluge}, {(UplacenAvans ? 1 : 0)}";
        public string PrimaryKeyClause => $"idEvidencije = {Evidencija.Id} AND rb = {Rb} ";
        public string WhereClause { get => $" s.idEvidencije = {Evidencija.Id}"; set { } }
        public string UpdateSetClause => "";

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
                    DanDolaska = (int)reader["danDolaska"],
                    DanOdlaska = (int)reader["danOdlaska"],
                    BrDana = (int)reader["brDana"],
                    BrOsoba = (decimal)reader["brOsoba"],
                    VrstaUsluge = (VrstaUsluge)(int)reader["vrstaUsluge"],
                    UplacenAvans = (Boolean)reader["uplacenAvans"],
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
            "s.idEvidencije, s.rb, s.danDolaska, s.danOdlaska, s.brDana, s.brOsoba, s.idKorisnik," +
            " s.vrstaUsluge, s.uplacenAvans, " +
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
    }
}
