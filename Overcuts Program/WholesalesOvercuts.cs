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
    class WholesalesOvercuts : Overcuts
    {
        const String databaseConnection = "Provider=IBMDA400.1;Data Source=10.1.1.10;User ID=PAULR;Password=PAULR;Default Collection=VPSFILES";

        public Dictionary<string, string> overcutvalues = new Dictionary<string, string>();
        public Dictionary<string, int> unitsBySize = new Dictionary<string, int>();

        //public int totalUnits = 0;
        //public bool noRows = true;

        public WholesalesOvercuts() {
            this.labelText = "Wholesale";
            this.labelName = "wholesaleOvercutLabel";
            this.tableName = "wholesaleOvercutPanel";
        }

        public override void getOvercuts(String productCode, String colorCode, String orderFrom = "", String orderTo = "")
        {
            String query = buildQueryInvoice(productCode, colorCode, orderFrom, orderTo);

            try
            {
                using (OleDbConnection conn = new OleDbConnection(databaseConnection))
                {
                    OleDbCommand command = new OleDbCommand(query, conn);
                    conn.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        noRows = false;
                        while (reader.Read())
                        {
                            for (int index = 0; index < reader.FieldCount; index++)
                            {
                                string columnName = reader.GetName(index);
                                overcutvalues[reader.GetName(index)] = reader.GetValue(index).ToString();
                                if (columnName == "UNITSTOTAL")
                                {
                                    this.totalUnits = Int32.Parse(reader.GetValue(index).ToString());
                                }
                                if (columnName != "UNITSTOTAL" && columnName != "PRODUCTCODE" && columnName != "COLORCODE")
                                {
                                    this.unitsBySize[columnName] = Int32.Parse(reader.GetValue(index).ToString());
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("no sales found for this style for Wholesale");
                    }

                    reader.Close();
                    command.Dispose();
                    conn.Close();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private String buildQueryOrder(String productCode, String colorCode, String orderFrom = "", String orderTo = "")
        {
            String query = "SELECT A.PRCD4E AS PRODUCTCODE,A.CRCD4E AS COLORCODE," +
           "SUM(A.SZ014E) AS SIZE0,SUM(A.SZ024E) AS SIZE2,SUM(A.SZ034E) AS SIZE4,SUM(A.SZ044E) AS SIZE6,SUM(A.SZ054E) AS SIZE8,SUM(A.SZ064E) AS SIZE10," +
           "SUM(A.SZ074E) AS SIZE12,SUM(A.SZ084E) AS SIZE14,SUM(A.SZ094E) AS SIZE16,SUM(A.SZ104E) AS SIZE18,SUM(A.SZ114E) AS SIZE20,SUM(A.SZ124E) AS BULK," +
           "SUM(A.UNIT4E) AS UNITSTOTAL " +
           "FROM ORDDTL0 AS A LEFT JOIN ORDHDR0 AS B ON A.CONO4E=B.CONO2Y AND A.CSNO4E=B.CSNO2Y AND A.ORNO4E = B.ORNO2Y " +
           "WHERE A.CONO4E=1 AND A.CSNO4E<>777 AND A.PRCD4E='" + productCode.ToUpper() + "' AND A.CRCD4E='" + colorCode.ToUpper() + "'";
            if (orderFrom != "")
            {
                query += " AND B.ORDT2Y>=" + orderFrom;
            }
            if (orderTo != "")
            {
                query += " AND B.ORDT2Y<=" + orderTo;
            }
            query += " GROUP BY A.PRCD4E,A.CRCD4E";

            return query;
        }

        private String buildQueryInvoice(String productCode, String colorCode, String orderFrom = "", String orderTo = "")
        {
            String query = "SELECT A.PRCD5Z AS PRODUCTCODE,A.CRCD5Z AS COLORCODE," +
           "SUM(A.SZ015Z) AS SIZE0,SUM(A.SZ025Z) AS SIZE2,SUM(A.SZ035Z) AS SIZE4,SUM(A.SZ045Z) AS SIZE6,SUM(A.SZ055Z) AS SIZE8,SUM(A.SZ065Z) AS SIZE10," +
           "SUM(A.SZ075Z) AS SIZE12,SUM(A.SZ085Z) AS SIZE14,SUM(A.SZ095Z) AS SIZE16,SUM(A.SZ105Z) AS SIZE18,SUM(A.SZ115Z) AS SIZE20,SUM(A.SZ125Z) AS BULK," +
           "SUM(A.UNIT5Z) AS UNITSTOTAL " +
           "FROM INVDTL0 AS A LEFT JOIN INVHDR0 AS B ON A.CONO5Z=B.CONO6A AND A.CSNO5Z=B.CSNO6A AND A.ORNO5Z = B.ORNO6A " +
           "WHERE A.CONO5Z=1 AND A.CSNO5Z<>777 AND A.PRCD5Z='" + productCode.ToUpper() + "' AND A.CRCD5Z='" + colorCode.ToUpper() + "'";
            if (orderFrom != "")
            {
                query += " AND B.ORDT6A>=" + orderFrom;
            }
            if (orderTo != "")
            {
                query += " AND B.ORDT6A<=" + orderTo;
            }
            query += " GROUP BY A.PRCD5Z,A.CRCD5Z";
            return query;
        }

        public override void setTableLayoutSizes(TableLayoutPanel tableLayout)
        {
        
            int columnIndex = 0;
            foreach (KeyValuePair<string, string> product in this.overcutvalues)
            {
                tableLayout.Controls.Add(new Label() { Text = product.Value }, columnIndex++, row);
            }
        }

        public override void setTableLayoutEstimateSizes(TableLayoutPanel tableLayout)
        {
          
            int desiredQuantity = Overcuts.product.getDesiredQuantity();
            int colIndex = 0;
            tableLayout.Controls.Add(new Label() { Text = "Estimation" }, colIndex++, row);
            tableLayout.Controls.Add(new Label() { Text = "" }, colIndex++, row);
            for (int index = 0; index <= 22; index += 2)
            {
                string sizekey = "";
                if (index < 22)
                {
                    sizekey += "SIZE" + index;
                }
                else
                {
                    sizekey += "BULK";
                }
                double percentage = (double)this.unitsBySize[sizekey] / (double)this.totalUnits;

                int estimatedSizeQuantity = (int)(percentage * (double)desiredQuantity);

                tableLayout.Controls.Add(new Label() { Text = estimatedSizeQuantity.ToString() }, colIndex++, row);

            }
            tableLayout.Controls.Add(new Label() { Text = desiredQuantity.ToString() }, colIndex, row);
        }

    }
}
