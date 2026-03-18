using Microsoft.Data.SqlClient;

namespace Common.Domain
{
    public interface IDomainObj  //nasledjuju ga domenski objekti
    {
        string TableName { get; }
        string InsertColumns { get; }
        string InsertValues { get; } //kolone koje se upisuju u insert
        string PrimaryKeyClause { get; } //za where deo upita
        string WhereClause { get; set; }
        string UpdateSetClause { get; } //kolone i parametri koji se azuriraju

        List<IDomainObj> VratiListuSvi(SqlDataReader reader); //kada se izvrsi upit (executeReader nakon SELECT)

        string SelectColumns { get; }  // kolone sa alijasima koje biramo za SELECT
        string JoinClause { get; }  // JOIN deo

    }
}
