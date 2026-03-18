using Common.Domain.enums;
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
        public decimal BrOsoba { get; set;}
        public VrstaUsluge VrstaUsluge { get; set; }
        public decimal KoeficijentUsluge => 1 + Evidencija.ProcenatPovecanjaPoUsluzi  * ((int)VrstaUsluge - (int)Evidencija.OsnovnaVrstaUsluge);
        public decimal Iznos => BrDana * BrOsoba * Evidencija.OsnovnaCenaPoOsobi * KoeficijentUsluge * Evidencija.SezonskiKoeficijentCene;
        public decimal IznosAvansa =>  Iznos * Evidencija.ProcenatAvansa ;

        public Boolean UplacenAvans;

        public string TableName => "StavkaEvidencije";
        public string InsertColumns => "idEvidencije, rb, danDolaska, danOdlaska, brDana, brOsoba, idKorisnik," +
                                         " vrstaUsluge, koeficijentUsluge, iznos, iznosAvansa, uplacenAvans";
        public string InsertValues => $"'{Evidencija?.Id}', '{Rb}', '{DanDolaska}', '{DanOdlaska}', '{BrDana}', '{BrOsoba}', '{Korisnik?.Id}', " +
            $"                          '{(int)VrstaUsluge}', '{KoeficijentUsluge}', '{Iznos}', '{IznosAvansa}', '{UplacenAvans}'";
        public string PrimaryKeyClause => $"idEvidencije = '{Evidencija.Id}' AND rb = '{Rb}' ";
        public string WhereClause { get => $" s.idEvidencije = '{Evidencija.Id}'"; set { } }
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
                        Id = (long)reader["idEvidencija"],
                        SezonskiKoeficijentCene = (decimal)reader["e.sezonskiKoeficijentCene"],
                        ProcenatAvansa = (decimal)reader["e.procenatAvansa"],
                        OsnovnaVrstaUsluge = (VrstaUsluge)(int)reader["e.osnovnaVrstaUsluge"],
                        OsnovnaCenaPoOsobi = (decimal)reader["e.osnovnaCenaPoOsobi"],
                        ProcenatPovecanjaPoUsluzi = (decimal)reader["e.procenatPovecanjaPoUsluzi"],
                    },
                    Rb = (long)reader["rb"],
                    DanDolaska = (int)reader["danDolaska"],
                    DanOdlaska = (int)reader["danOdlaska"],
                    BrOsoba = (decimal)reader["brOsoba"],
                    VrstaUsluge = (VrstaUsluge)(int)reader["vrstaUsluge"],
                    UplacenAvans = (Boolean)reader["uplacenAvans"],
                    Korisnik = new Korisnik
                    {
                        Id = (long)reader["idKorisnik"],
                        Ime = reader["k.ime"].ToString().Trim(),
                        Prezime = reader["k.prezime"].ToString().Trim(),
                        BrLicneKarte = reader["k.brLicneKarte"].ToString().Trim(),
                        Email = reader["k.email"] == DBNull.Value ? "-" : reader["email"].ToString().Trim(),
                        BrTel = reader["k.brTel"] == DBNull.Value ? "-" : reader["brTel"].ToString().Trim(),
                    },
                    

                };
                stavke.Add(s);            
            }
            return stavke;
        }

        public string SelectColumns =>
            "s.idEvidencije, s.rb, s.danDolaska, s.danOdlaska, s.brDana, s.brOsoba, s.idKorisnik," +
            " s.vrstaUsluge, s.koeficijentUsluge, s.iznos, s.iznosAvansa, s.uplacenAvans"+
            " k.ime , k.prezime, k.brLicneKarte, k.email, k.brTel, " +
            " e.sezonskiKoeficijentCene, e.procenatAvansa, e.osnovnaCenaPoOsobi, e.osnovnaVrstaUsluge, e.procenatPovecanjaPoUsluzi";

        public string JoinClause =>
            " s " +
            "JOIN Korisnik k ON k.id = s.idKorisnik " +
            "JOIN EvidencijaRez e ON e.id = s.idEvidencije";

    }
}
