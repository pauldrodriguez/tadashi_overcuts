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
    class RetailOvercuts
    {
        const String databaseConnection = "Data Source=10.1.1.20;Initial Catalog=TadashiPOS;User ID=sa;Password=B1llyg0@t5";

        //public Dictionary<string, string> overcutvalues = new Dictionary<string, string>();
        public Dictionary<string, int> qtySoldPerSize = new Dictionary<string, int>();

        public int totalUnits = 0;

        public bool noRows = true;

        public void getOvercuts(String productCode, String colorCode, String orderFrom = "", String orderTo = "")
        {
            String query = buildQuery(productCode, colorCode, orderFrom, orderTo);

            try
            {
                using (SqlConnection conn = new SqlConnection(databaseConnection))
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        noRows = false;
                        while (reader.Read())
                        {
                           
                            int qty = (int)Double.Parse(reader["TOTALS"].ToString());
                           
                            
                           qtySoldPerSize[reader["SIZE"].ToString().ToUpper()] = qty;

                            this.totalUnits += qty;
                          
                        }
                    }
                    else
                    {
                        MessageBox.Show("no sales found for this style for Retail");
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

        private string buildQuery(String productCode, String colorCode, String orderFrom = "", String orderTo = "") {
            string query = "SELECT IM_ITEM.VEND_ITEM_NO AS PRODUCTCODE, IM_ITEM.ATTR_COD_2 AS COLORCODE, dbo.IM_ITEM.ATTR_COD_3 AS SIZE, SUM(PS_TKT_HIST_LIN.QTY_SOLD) AS TOTALS " +
                "FROM AR_CUST " +
                "INNER JOIN PS_TKT_HIST ON AR_CUST.CUST_NO = PS_TKT_HIST.CUST_NO " +
                "INNER JOIN PS_TKT_HIST_LIN ON PS_TKT_HIST.BUS_DAT = PS_TKT_HIST_LIN.BUS_DAT AND PS_TKT_HIST.DOC_ID = PS_TKT_HIST_LIN.DOC_ID " +
                "INNER JOIN IM_ITEM ON PS_TKT_HIST_LIN.ITEM_NO = IM_ITEM.ITEM_NO "+
                "LEFT OUTER JOIN PS_TKT_HIST_PROF ON PS_TKT_HIST.BUS_DAT = PS_TKT_HIST_PROF.BUS_DAT AND PS_TKT_HIST.DOC_ID = PS_TKT_HIST_PROF.DOC_ID "+
                "WHERE (PS_TKT_HIST_LIN.LIN_TYP = 'S') AND ( UPPER(IM_ITEM.VEND_ITEM_NO)='" + productCode.ToUpper() + "' ) AND ( UPPER(IM_ITEM.ATTR_COD_2)='" + colorCode.ToUpper() + "' ) ";

            if (orderFrom != "") {
                query += "AND (PS_TKT_HIST_LIN.BUS_DAT >= CONVERT(DATETIME, '" + orderFrom + " 00:00:00', 102)) ";
            }
            if (orderTo != "")
            {
                query += "AND (PS_TKT_HIST_LIN.BUS_DAT <= CONVERT(DATETIME, '" + orderTo + " 00:00:00', 102)) ";
            }
            query += "GROUP BY IM_ITEM.VEND_ITEM_NO,IM_ITEM.ATTR_COD_2,IM_ITEM.ATTR_COD_3";

            return query;
        }

        public void setTableLayoutSizes(TableLayoutPanel tableLayout, int row,ProductStyles product)
        {
     
            int columnIndex = 0;
            tableLayout.Controls.Add(new Label() { Text = product.getStyleCode() }, columnIndex++, row);
            tableLayout.Controls.Add(new Label() { Text = product.getColorCode() }, columnIndex++, row);

            foreach (KeyValuePair<string, string> productSize in product.getStyleSizes())
            {
                int sizeQty = 0;
                this.qtySoldPerSize.TryGetValue(productSize.Value.ToUpper(), out sizeQty);
                
                tableLayout.Controls.Add(new Label() { Text = sizeQty.ToString() }, columnIndex++, row);
            }

            tableLayout.Controls.Add(new Label() { Text = this.totalUnits.ToString()}, columnIndex, row);
            
        }

        public void setTableLayoutEstimateSizes(TableLayoutPanel tableLayout, int desiredQuantity, int row,ProductStyles product)
        {
            int columnIndex = 0;
            tableLayout.Controls.Add(new Label() { Text = "Estimation" }, columnIndex++, row);
            tableLayout.Controls.Add(new Label() { Text = "" }, columnIndex++, row);

            foreach (KeyValuePair<string, string> productSize in product.getStyleSizes())
            {
                int sizeQty = 0;
                this.qtySoldPerSize.TryGetValue(productSize.Value.ToUpper(), out sizeQty);

                double percentage = 0;
                if (this.totalUnits > 0) {
                    percentage = (double)sizeQty / (double)this.totalUnits;
                }

                int estimatedSizeQuantity = (int)(percentage * (double)desiredQuantity);

                tableLayout.Controls.Add(new Label() { Text = estimatedSizeQuantity.ToString() }, columnIndex++, row);
            }


            tableLayout.Controls.Add(new Label() { Text = desiredQuantity.ToString() }, columnIndex, row);
        }

    }
}
