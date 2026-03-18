using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class ProsecnaOcena : IDomainObj
    {
        public DateOnly DatumDodeljivanja {  get; set; }
        public Vlasnik Vlasnik { get; set; }=new Vlasnik();
        public IzvorOcene Izvor {  get; set; } = new IzvorOcene();
        public decimal Vrednost {  get; set; }

        public string TableName => "ProsecnaOcena";
        public string InsertColumns => "datumDodeljivanja, idVlasnik, idIzvora, vrednost";
        public string InsertValues => $"'{DatumDodeljivanja}', '{Vlasnik?.Id}', '{Izvor?.Id}', '{Vrednost}";
        public string PrimaryKeyClause => "";
        public string WhereClause { get; set; }

        public string UpdateSetClause =>"";

        public List<IDomainObj> VratiListuSvi(SqlDataReader reader)
        {
            List<IDomainObj> ocene = new List<IDomainObj>();

            while (reader.Read())
            {
                ProsecnaOcena ocena = new ProsecnaOcena
                {
                    DatumDodeljivanja = (DateOnly)reader["datumDodeljivanja"],
                    Vlasnik=new Vlasnik
                    {
                        Id = Convert.ToInt64( reader["idVlasnik"]),
                    },
                    Izvor = new IzvorOcene
                    {
                        Id = Convert.ToInt64(reader["idIzvora"]),
                    },
                    Vrednost = (decimal)reader["vrednost"],
                };
                ocene.Add(ocena);
            }

            return ocene;
        }

        public string SelectColumns => "*";

        public string JoinClause =>
            " po " +
            "JOIN Vlasnik v ON v.id = po.idVlasnik " +
            "JOIN IzvorOcene io ON io.id = po.idIzvora";

        }
}
