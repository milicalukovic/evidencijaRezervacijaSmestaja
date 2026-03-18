using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public interface IDomainObj  //nasledjuju ga domenski objekti
    {
        string TableName { get; }

        // primarni ključ (i za prost i za složen)
        string KeyWhereClause { get; }   //uslov u WHERE za identifikaciju npr. "id=@id" ili "idEvidencije=@idE AND rb=@rb"
        List<SqlParameter> GetKeyParameters();  // parametri koji odgovaraju uslovu

        string InsertColumns { get; } //kolone koje se upisuju u insert
        string InsertParameters { get; } //parametri koji odg kolonama
        string UpdateSetClause { get; } //nakon SET u UPDATE, kolone i parametr koji me azuriraju

        List<SqlParameter> GetInsertParameters(); //realne vrednosti parametara
        List<SqlParameter> GetUpdateParameters(); //realne vrednosti

        //SELECT
        List<IDomainObj> GetReaderList(SqlDataReader reader);

        // JOIN
        string SelectColumns { get; }  // kolone sa alijasima koje biramo za SELECT: "e.id AS evidencijaId, e.mesec, ..."
        string JoinClause { get; }  // FROM+JOIN deo : "e JOIN SmestajnaJedinica sj ON ... "

        //imenovani tuple
        (string WhereClause, List<SqlParameter> Parameters) GetSearchCondition();

    }
    public static class SqlDataReaderExtensions
    {
        public static bool ColumnsContains(this SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;

            return false;
        }
    }
}
