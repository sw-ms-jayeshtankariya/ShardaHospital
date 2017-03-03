using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medical
{
    public class Operation
    {
        private static String connParam = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath+ "\\eyemedical.mdb;Persist Security Info=False";
        public static DataTable GetDataTable(string Query)
        {
            using (OleDbConnection conn = new OleDbConnection(connParam))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(Query, conn))
                {
                    DataSet ds = new DataSet();
                    if (ds != null)
                    {
                        adapter.Fill(ds);
                        return ds.Tables[0];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public static int ExecuteNonQuery(string Query, List<OleDbParameter> param)
        {
            using (OleDbConnection conn = new OleDbConnection(connParam))
            {
                using (OleDbCommand cmd = new OleDbCommand(Query, conn))
                {
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param.ToArray());
                    }
                    if (cmd.Connection.State == ConnectionState.Closed)
                        cmd.Connection.Open();

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
