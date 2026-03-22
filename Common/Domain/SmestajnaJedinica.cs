using Common.Domain.enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class SmestajnaJedinica : IDomainObj
    {
        public long Id { get; set; }  //properties da bi bili vidljivi na serveru kada se objekat serijalizuje
        public string Naziv {  get; set; }
        public VrstaUsluge OsnovnaVrstaUsluge { get; set;}
        public decimal CenaPoOsobi {  get; set; }
        public decimal PovecanjeCenePoUsluzi { get; set; }
        public String Vlasnik {  get; set; }

        public TipSmestaja Tip { get; set; } = new TipSmestaja();

        public string TableName =>"SmestajnaJedinica";
        public string InsertColumns => "naziv, osnovnaVrstaUsluge, cenaPoOsobi, PovecanjeCenePoUsluzi, Vlasnik, idTip";
        public string InsertValues => $"'{Naziv}', {(int)OsnovnaVrstaUsluge}," +
            $" {CenaPoOsobi.ToString(CultureInfo.InvariantCulture)}, {PovecanjeCenePoUsluzi.ToString(CultureInfo.InvariantCulture)},'{Vlasnik}', '{Tip.Id}'";
                             //format 30.5 jer je na formi 30,5
        public string PrimaryKeyClause => $"id = {Id}";

        public Boolean FilterPoUsluzi { get; set; }
        public Boolean FilterPoTipu { get; set; }
        public Boolean PretraziSJ {  get; set; }
        public Boolean ProveriNaziv { get; set; }
        public string WhereClause {
            get
            {
                string uslovi = $"vlasnik = '{Vlasnik}' ";

                if (PretraziSJ)
                {
                    uslovi += $"AND sj.id = {Id}";
                }
                if (ProveriNaziv)
                {
                    uslovi += $"AND sj.naziv = '{Naziv}'";
                }
                if(FilterPoUsluzi && FilterPoTipu)
                {
                    uslovi +=$"AND sj.osnovnaVrstaUsluge = {(int)OsnovnaVrstaUsluge} " +
                        $"AND t.naziv = '{Tip.Naziv}' ";
                }
                if(FilterPoUsluzi && !FilterPoTipu)
                {
                    uslovi += $"AND sj.osnovnaVrstaUsluge = {(int)OsnovnaVrstaUsluge} ";
                }
                if (!FilterPoUsluzi && FilterPoTipu)
                {
                    uslovi += $"AND t.naziv = '{Tip.Naziv}' ";
                }

                return uslovi;
            }
            set { }
        }  
        public string UpdateSetClause => $"naziv = '{Naziv}', osnovnaVrstaUsluge = {(int)OsnovnaVrstaUsluge}," +
            $" cenaPoOsobi = {CenaPoOsobi.ToString(CultureInfo.InvariantCulture)}, PovecanjeCenePoUsluzi = {PovecanjeCenePoUsluzi.ToString(CultureInfo.InvariantCulture)}, " +
            $"vlasnik = '{Vlasnik}', idTip = {Tip.Id}";

        public List<IDomainObj> VratiListuSvi(SqlDataReader reader)
        {
            List<IDomainObj> jedinice = new List<IDomainObj>();

            while (reader.Read())
            {

                SmestajnaJedinica sj = new SmestajnaJedinica
                {
                    Id = (long)reader["id"],
                    Naziv = reader["naziv"].ToString().Trim(),
                    OsnovnaVrstaUsluge = (VrstaUsluge)(int)reader["osnovnaVrstaUsluge"],
                    CenaPoOsobi = (decimal)reader["cenaPoOsobi"],
                    PovecanjeCenePoUsluzi = (decimal)reader["PovecanjeCenePoUsluzi"],
                    Vlasnik = reader["vlasnik"].ToString().Trim(),
                    Tip =new TipSmestaja()
                    {
                        Id = (long)reader["idTip"],
                        Naziv = reader["tipNaziv"].ToString().Trim(),
                        MinKapacitet = (decimal)reader["minKapacitet"],
                        MaxKapacitet = (decimal)reader["maxKapacitet"]
                    }

                };
                jedinice.Add(sj);
            }

            return jedinice;
        }

        public string SelectColumns =>
            $"sj.id, sj.naziv, sj.osnovnaVrstaUsluge, sj.cenaPoOsobi, sj.PovecanjeCenePoUsluzi, sj.vlasnik, sj.idTip, " +
            "t.naziv AS tipNaziv, t.minKapacitet AS minKapacitet, t.maxKapacitet AS maxKapacitet";

        public string JoinClause =>
            " sj " +
            "JOIN TipSmestaja t ON t.id = sj.idTip";

        public override string ToString()
        {
            return Naziv;
        }

    }
    
}
