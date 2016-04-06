using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace Overcuts_Program
{
    class ProductStyles
    {
        const String as400conn = "Provider=IBMDA400.1;Data Source=10.1.1.10;User ID=PAULR;Password=PAULR;Default Collection=VPSFILES";

        public DataSet getStyles()
        {
            DataSet dt = new DataSet();
            String query = "SELECT PRCD3L FROM PRDTMS0 WHERE CONO3L=1 GROUP BY PRCD3L";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(as400conn))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    //OleDbCommand command = new OleDbCommand(query, conn);
                    conn.Open();
                    //OleDbDataReader reader = command.ExecuteReader();
                    //adapter.SelectCommand = command;
                    adapter.Fill(dt);
                    adapter.Dispose();
                    //command.Dispose();
                    conn.Close();
                }
            }
            catch (Exception e)
            {

            }
            return dt;

        }
    }
}
