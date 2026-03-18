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
        public int Kapacitet { get; set; }
        public double CenaPoOsobi {  get; set; }
        public int MinOsoba { get; set; }
        public TipSmestaja Tip { get; set; } = new TipSmestaja();

        public string TableName =>"SmestajnaJedinica";

        public string KeyWhereClause => "id=@id";

        public List<SqlParameter> GetKeyParameters() => new()
        {
            new SqlParameter("@id", Id)
        };

        public string InsertColumns => "naziv, kapacitet, cenaPoOsobi, idTip, minOsoba";

        public string InsertParameters => "@naziv, @kapacitet, @cenaPoOsobi, @idTip, @minOsoba";

        public string UpdateSetClause => "naziv=@naziv, kapacitet=@kapacitet, cenaPoOsobi=@cenaPoOsobi, idTip=@idTip, minOsoba=@minOsoba";

        public List<SqlParameter> GetInsertParameters() => new()
        {
            new SqlParameter("@naziv", Naziv),
            new SqlParameter("@kapacitet", Kapacitet),
            new SqlParameter("@cenaPoOsobi", CenaPoOsobi),
            new SqlParameter("@idTip", Tip.Id),
            new SqlParameter("@minOsoba", MinOsoba)
        };

        public List<SqlParameter> GetUpdateParameters()
        {
            return GetInsertParameters();
        }


        public List<IDomainObj> GetReaderList(SqlDataReader reader)
        {
            List<IDomainObj> jedinice = new List<IDomainObj>();

            while (reader.Read())
            {

                SmestajnaJedinica sj = new SmestajnaJedinica
                {
                    Id = (long)reader["id"],
                    Naziv = (string)reader["naziv"],
                    Kapacitet = (int)reader["kapacitet"],
                    CenaPoOsobi = (double)reader["cenaPoOsobi"],
                    MinOsoba = (int)reader["minOsoba"],
                    Tip=new TipSmestaja()
                    {
                        Id = (long)reader["idTip"],
                        // kada se pozove GetAllJoin -> postoji tip_naziv
                        Naziv = reader.ColumnsContains("tip_naziv")
                            ? reader["tip_naziv"]?.ToString() ?? ""
                            : ""
                    }

                };
                jedinice.Add(sj);
            }

            return jedinice;
        }

        public (string WhereClause, List<SqlParameter> Parameters) GetSearchCondition()
        {
            throw new NotImplementedException();
        }

        public string SelectColumns =>
            "sj.id, sj.naziv, sj.kapacitet, sj.cenaPoOsobi, sj.minOsoba, sj.idTip, " +
            "t.naziv AS tip_naziv";

        public string JoinClause =>
            "SmestajnaJedinica sj " +
            "JOIN TipSmestaja t ON t.id = sj.idTip";
    }
}
