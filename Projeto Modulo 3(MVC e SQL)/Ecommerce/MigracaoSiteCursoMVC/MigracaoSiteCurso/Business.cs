using System.Data;
using System.Data.SqlClient;
using static MigracaoSiteCurso.BD;
namespace MigracaoSiteCurso
{
    public class Business
    {
        public static List<Dictionary<string, Object>> GetCatalog()
        {
            string sConnection = "Initial Catalog=Cursos;Data Source=ALENOTE;Integrated Security=true";
            System.Data.SqlClient.SqlConnection cn = BD.OpenBD(sConnection);

            string sQry = "SELECT * FROM curso";

            DataTable dt = BD.GetDTForSQL(ref cn, sQry);

            return BD.ToListDictionary(cn, sQry);

            
        }
    }
}
