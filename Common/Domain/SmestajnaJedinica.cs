using Common.Domain.enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class SmestajnaJedinica : IDomainObj
    {
        public long Id { get; set; }
        public string Naziv {  get; set; }
        public VrstaUsluge OsnovnaVrstaUsluge { get; set;}
        public decimal CenaPoOsobi {  get; set; }
        public decimal ProcenatPovecanjaPoUsluzi { get; set; }

        public TipSmestaja Tip { get; set; } = new TipSmestaja();

        public string TableName =>"SmestajnaJedinica";
        public string InsertColumns => "naziv, osnovnaVrstaUsluge, cenaPoOsobi, procenatPovecanjaPoUsluzi, idTip";
        public string InsertValues => $"'{Naziv}', '{(int)OsnovnaVrstaUsluge}'," +
            $" '{CenaPoOsobi}', '{ProcenatPovecanjaPoUsluzi}', '{Tip.Id}'";
        public string PrimaryKeyClause => $"id = '{Id}'";
        public string WhereClause { get; set ; }
        public string UpdateSetClause => "";

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
                    ProcenatPovecanjaPoUsluzi = (decimal)reader["procenatPovecanjaPoUsluzi"],
                    Tip=new TipSmestaja()
                    {
                        Id = (long)reader["idTip"],
                        Naziv = reader["tip_naziv"].ToString().Trim(),
                        MinKapacitet = (decimal)reader["minKapacitet"],
                        MaxKapacitet = (decimal)reader["maxKapacitet"]
                    }

                };
                jedinice.Add(sj);
            }

            return jedinice;
        }

        public string SelectColumns =>
            $"sj.id, sj.naziv, sj.osnovnaVrstaUsluge, sj.cenaPoOsobi, sj.procenatPovecanjaPoUsluzi, sj.idTip, " +
            "t.naziv AS tip_naziv, t.minKapacitet AS minKapacitet, t.maxKapacitet AS maxKapacitet";

        public string JoinClause =>
            " sj " +
            "JOIN TipSmestaja t ON t.id = sj.idTip";

    }
}
