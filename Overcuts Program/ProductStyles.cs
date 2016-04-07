using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Overcuts_Program
{
    class ProductStyles
    {
        const String as400conn = "Provider=IBMDA400.1;Data Source=10.1.1.10;User ID=PAULR;Password=PAULR;Default Collection=VPSFILES";

        private string styleCode;
        private string colorCode;
        private int desiredQuantity;
        private Dictionary<string, string> productSizes;

        public ProductStyles(string styleCode,string colorCode,int desiredQuantity) {
            this.styleCode = styleCode;
            this.colorCode = colorCode;
            this.desiredQuantity = desiredQuantity;
            this.productSizes = new Dictionary<string, string>();
            this.fetchStyleSizes();
        }

        public string getStyleCode() {
            return styleCode;
        }

        public string getColorCode() {
            return colorCode;
        }

        public int getDesiredQuantity() {
            return this.desiredQuantity;
        }

        public static DataSet getStyles()
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

        public Dictionary<string, string> getStyleSizes() {
            return productSizes;
        }

        public void fetchStyleSizes() {
            string query = "SELECT B.SZ013G AS SIZE0,B.SZ023G AS SIZE2,B.SZ033G AS SIZE4,B.SZ043G AS SIZE6,B.SZ053G AS SIZE8,B.SZ063G AS SIZE10," +
                "B.SZ073G AS SIZE12,B.SZ083G AS SIZE14,B.SZ093G AS SIZE16,B.SZ103G AS SIZE18,B.SZ113G AS SIZE20,B.SZ123G AS BULK " +
                "FROM PRHDMS0 AS A LEFT JOIN SZSCMS0 AS B ON A.SZCD3K=B.SZCD3G AND A.CONO3K=B.CONO3G " +
                "WHERE A.CONO3K=1 AND A.PRCD3K='"+this.styleCode+"'";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(as400conn))
                {
                    OleDbCommand command = new OleDbCommand(query, conn);
                    conn.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.HasRows) {
                        while (reader.Read())
                        {
                            for (int index = 0; index < reader.FieldCount; index++)
                            {
                                string columnName = reader.GetName(index);
                                this.productSizes[reader.GetName(index)] = reader.GetValue(index).ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }



    }
}
