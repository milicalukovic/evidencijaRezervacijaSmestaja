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
        public DateTime DatumDodeljivanja {  get; set; }
        public Vlasnik Vlasnik { get; set; }=new Vlasnik();
        public IzvorOcene Izvor {  get; set; } = new IzvorOcene();
        public double Vrednost {  get; set; }

        public string TableName => "ProsecnaOcena";

        // SLOŽENI KEY: (idVlasnik, idIzvora, datumDodeljivanja)
        public string KeyWhereClause => "idVlasnik=@idVlasnik AND idIzvora=@idIzvora AND datumDodeljivanja=@datum";

        public List<SqlParameter> GetKeyParameters() => new()
        {
            new SqlParameter("@idVlasnik", Vlasnik.Id),
            new SqlParameter("@idIzvora", Izvor.Id),
            new SqlParameter("@datum", DatumDodeljivanja)
        };

        public string InsertColumns => "datumDodeljivanja, idVlasnik, idIzvora, vrednost";

        public string InsertParameters => "@datum, @idVlasnik, @idIzvora, @vrednost";

        public string UpdateSetClause =>"vrednost=@vrednost";

        public List<SqlParameter> GetInsertParameters() => new()
        {
            new SqlParameter("@datum", DatumDodeljivanja),
            new SqlParameter("@idVlasnik", Vlasnik.Id),
            new SqlParameter("@idIzvora", Izvor.Id),
            new SqlParameter("@vrednost", Vrednost)
        };

        public List<SqlParameter> GetUpdateParameters() => new()
        {
            new SqlParameter("@vrednost", Vrednost)
        };

        public List<IDomainObj> GetReaderList(SqlDataReader reader)
        {
            List<IDomainObj> ocene = new List<IDomainObj>();

            while (reader.Read())
            {
                ProsecnaOcena ocena = new ProsecnaOcena
                {
                    DatumDodeljivanja = (DateTime)reader["datumDodeljivanja"],
                    Vlasnik=new Vlasnik
                    {
                        Id = (long)reader["idVlasnik"],
                        Ime = reader.ColumnsContains("v_ime") ? reader["v_ime"]?.ToString() ?? "" : "",
                        Prezime = reader.ColumnsContains("v_prezime") ? reader["v_prezime"]?.ToString() ?? "" : ""
                    },
                    Izvor = new IzvorOcene
                    {
                        Id = (long)reader["idIzvora"],
                        Naziv = reader.ColumnsContains("io_naziv") ? reader["io_naziv"]?.ToString() ?? "" : ""
                    },
                    Vrednost = (double)reader["vrednost"],
                };
                ocene.Add(ocena);
            }

            return ocene;
        }

        public (string WhereClause, List<SqlParameter> Parameters) GetSearchCondition()
        {
            throw new NotImplementedException();
        }

        public string SelectColumns =>
            "po.datumDodeljivanja, po.idVlasnik, po.idIzvora, po.vrednost, " +
            "v.ime AS v_ime, v.prezime AS v_prezime, " +
            "io.naziv AS io_naziv";

        public string JoinClause =>
            "ProsecnaOcena po " +
            "JOIN Vlasnik v ON v.id = po.idVlasnik " +
            "JOIN IzvorOcene io ON io.id = po.idIzvora";
    }
}
