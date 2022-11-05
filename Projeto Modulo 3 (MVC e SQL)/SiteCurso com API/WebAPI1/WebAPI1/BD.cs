using System.Data;
using System.Data.SqlClient;

namespace WebAPI1
{
    public class BD
    {
        public static SqlConnection OpenBD(string ConnectionString)
        {
            SqlConnection MyDatabase = default(SqlConnection);
            try
            {
                MyDatabase = new SqlConnection();
                MyDatabase.ConnectionString = ConnectionString;
                MyDatabase.Open();
            }
            catch (Exception ex)
            {
            }
            return MyDatabase;
        }

        public static int CmdExecute(SqlConnection cn, string sQry)
        {
            SqlCommand command = new SqlCommand(sQry, cn);
            return command.ExecuteNonQuery();
        }

        public static int CmdExecute(string sServer, string sBDName, string sQry)
        {
            string connectionString =
                "Data Source=" + sServer + ";Initial Catalog=" + sBDName + ";"
                + "Integrated Security=true";


            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sQry, cn);
            cn.Open();
            return command.ExecuteNonQuery();
        }

        public static SqlDataReader LerQuery(SqlConnection cn, string sQry)
        {
            SqlCommand command = new SqlCommand(sQry, cn);
            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }

        public static SqlDataReader LerQuery(string sServer, string sBDName, string sQry)
        {
            string connectionString =
                "Data Source=" + sServer + ";Initial Catalog=" + sBDName + ";"
                + "Integrated Security=true";


            SqlDataReader reader = null;

            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sQry, cn);
            cn.Open();
            reader = command.ExecuteReader();

            return reader;
        }

        public static SqlDataReader LerQuery(string sServer, string sBDName, string sQry, ref SqlConnection cn)
        {
            string connectionString =
                "Data Source=" + sServer + ";Initial Catalog=" + sBDName + ";"
                + "Integrated Security=true";


            SqlDataReader reader = null;
            /*
            using (SqlConnection cn = new SqlConnection(sConn))
            {
                SqlCommand command = new SqlCommand(sQry, cn);
                cn.Open();
                reader = command.ExecuteReader();
            }
            */

            cn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sQry, cn);
            cn.Open();
            reader = command.ExecuteReader();

            return reader;
        }

        public static DataTable LerQuery(ref SqlConnection cn, string sQry)
        {
            return GetDTForSQL(ref cn, sQry);
        }

        public static SqlConnection SPExecute(string sServer, string sBDName, string spName, List<String> prmNames, List<Object> prmValues, ref SqlCommand cmd)
        {
            string connectionString =
                "Data Source=" + sServer + ";Initial Catalog=" + sBDName + ";"
                + "Integrated Security=true";


            SqlConnection cn = new SqlConnection(connectionString);
            cmd = new SqlCommand(spName, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (prmNames != null)
            {
                for (int i = 0; i < prmNames.Count(); i++)
                {
                    cmd.Parameters.Add(new SqlParameter(prmNames[i], prmValues[i]));
                }
            }
            cn.Open();

            return cn;
        }

        public static List<Dictionary<string, Object>> SPExecute(SqlConnection cn, string spName, List<String> prmNames, List<Object> prmValues)
        {
            SqlCommand cmd = new SqlCommand(spName, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (prmNames != null)
            {
                for (int i = 0; i < prmNames.Count(); i++)
                {
                    cmd.Parameters.Add(new SqlParameter(prmNames[i], prmValues[i]));
                }
            }

            return ToListDictionary(cmd.ExecuteReader());
        }
        public static SqlDataAdapter GetDAForUpdate(string stSQL, ref SqlConnection pConnection, SqlTransaction pTransaction = null)
        {
            SqlDataAdapter oDA = default(SqlDataAdapter);
            SqlCommandBuilder oCB = default(SqlCommandBuilder);
            SqlCommand cmd = default(SqlCommand);
            cmd = new SqlCommand(stSQL, pConnection, pTransaction);
            oDA = new SqlDataAdapter(cmd);
            oDA.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            oCB = new SqlCommandBuilder(oDA);
            oCB.QuotePrefix = "[";
            oCB.QuoteSuffix = "]";
            return oDA;
        }

        public static SqlDataAdapter GetDAForSQL(string stSQL, ref SqlConnection pConnection, SqlTransaction pTransaction = null, int TimeoutSeconds = 300)
        {
            SqlDataAdapter oDA = default(SqlDataAdapter);
            oDA = new SqlDataAdapter(stSQL, pConnection);
            oDA.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            oDA.SelectCommand.Transaction = pTransaction;
            oDA.SelectCommand.CommandTimeout = TimeoutSeconds;
            return oDA;
        }

        public static DataTable GetDTForUpdate(ref SqlConnection cn, string sSQL, ref SqlDataAdapter daDB, SqlTransaction pTransaction = null)
        {
            DataTable dtt = new DataTable();

            daDB = GetDAForUpdate(sSQL, ref cn, pTransaction);
            daDB.Fill(dtt);

            return dtt;
        }

        public static DataTable GetDTForSQL(ref SqlConnection cn, string sSQL)
        {
            SqlDataAdapter daDB = default(SqlDataAdapter);
            DataTable dtt = new DataTable();

            daDB = GetDAForSQL(sSQL, ref cn);
            daDB.Fill(dtt);

            return dtt;
        }

        public static List<List<Object>> ToList(SqlConnection cn, String sQry)
        {
            DataTable dt = BD.LerQuery(ref cn, sQry);

            List<List<Object>> lst = new List<List<Object>>();

            foreach (DataRow dr in dt.Rows)
            {
                List<Object> lstRecord = new List<Object>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    lstRecord.Add(dr[i]);
                }

                lst.Add(lstRecord);
            }

            return lst;
        }

        public static List<Dictionary<string, Object>> ToListDictionary(SqlConnection cn, String sQry)
        {
            DataTable dt = BD.LerQuery(ref cn, sQry);

            List<Dictionary<string, Object>> lst = new List<Dictionary<string, Object>>();

            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, Object> lstRecord = new Dictionary<string, Object>();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    lstRecord.Add(dt.Columns[i].ColumnName, dr[i]);
                }

                lst.Add(lstRecord);
            }

            return lst;
        }

        public static List<List<Object>> ToList(SqlDataReader dr)
        {
            List<List<Object>> lst = new List<List<Object>>();

            while (dr.Read())
            {
                List<Object> lstRecord = new List<Object>();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    lstRecord.Add(dr[i]);
                }

                lst.Add(lstRecord);
            }

            return lst;
        }

        public static List<Dictionary<string, Object>> ToListDictionary(SqlDataReader dr)
        {
            List<Dictionary<string, Object>> lst = new List<Dictionary<string, Object>>();

            while (dr.Read())
            {
                Dictionary<string, Object> lstRecord = new Dictionary<string, Object>();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    lstRecord.Add(dr.GetName(i), dr[i]);
                }

                lst.Add(lstRecord);
            }

            return lst;
        }
    }
}

