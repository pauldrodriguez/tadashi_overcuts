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
    class EcommOvercuts
    {
        const String as400conn = "Provider=IBMDA400.1;Data Source=10.1.1.10;User ID=PAULR;Password=PAULR;Default Collection=VPSFILES";
       
        public Dictionary<string, string> overcutvalues = new Dictionary<string, string>();
        public Dictionary<string, int> unitsBySize = new Dictionary<string, int>();

        public int totalUnits;
      
        public bool noRows = true;
        public void getOvercuts(String productCode,String colorCode, String orderFrom="", String orderTo="") {
         
            String query = buildQueryInvoice(productCode,colorCode,orderFrom,orderTo);
            try
            {
                using (OleDbConnection conn = new OleDbConnection(as400conn))
                {
                    //OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    OleDbCommand command = new OleDbCommand(query, conn);
                    conn.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    //adapter.SelectCommand = command;
                    //adapter.Fill(dt);
                    //adapter.Dispose();

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
                    else {
                        MessageBox.Show("no sales found for this style for E-Commerce");
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
            String query = "SELECT A.PRCD4D AS PRODUCTCODE,A.CRCD4D AS COLORCODE," +
           "SUM(A.SZ014D) AS SIZE0,SUM(A.SZ024D) AS SIZE2,SUM(A.SZ034D) AS SIZE4,SUM(A.SZ044D) AS SIZE6,SUM(A.SZ054D) AS SIZE8,SUM(A.SZ064D) AS SIZE10," +
           "SUM(A.SZ074D) AS SIZE12,SUM(A.SZ084D) AS SIZE14,SUM(A.SZ094D) AS SIZE16,SUM(A.SZ104D) AS SIZE18,SUM(A.SZ114D) AS SIZE20,SUM(A.SZ124D) AS BULK," +
           "SUM(A.UNIT4D) AS UNITSTOTAL " +
           "FROM ORDDTL0 AS A LEFT JOIN ORDHDR0 AS B ON A.CONO4D=B.CONO2Y AND A.CSNO4D=B.CSNO2Y AND A.ORNO4D = B.ORNO2Y " +
           "WHERE A.CONO4D=1 AND A.CSNO4D=777 AND A.PRCD4D='" + productCode.ToUpper() + "' AND A.CRCD4D='" + colorCode.ToUpper() + "'";
            if (orderFrom != "")
            {
                query += " AND B.ORDT2Y>=" + orderFrom;
            }
            if (orderTo != "")
            {
                query += " AND B.ORDT2Y<=" + orderTo;
            }
            query += " GROUP BY A.PRCD4D,A.CRCD4D";

            return query;
        }

        private String buildQueryInvoice(String productCode, String colorCode, String orderFrom = "", String orderTo = "")
        {
            String query = "SELECT A.PRCD5Z AS PRODUCTCODE,A.CRCD5Z AS COLORCODE," +
           "SUM(A.SZ015Z) AS SIZE0,SUM(A.SZ025Z) AS SIZE2,SUM(A.SZ035Z) AS SIZE4,SUM(A.SZ045Z) AS SIZE6,SUM(A.SZ055Z) AS SIZE8,SUM(A.SZ065Z) AS SIZE10," +
           "SUM(A.SZ075Z) AS SIZE12,SUM(A.SZ085Z) AS SIZE14,SUM(A.SZ095Z) AS SIZE16,SUM(A.SZ105Z) AS SIZE18,SUM(A.SZ115Z) AS SIZE20,SUM(A.SZ125Z) AS BULK," +
           "SUM(A.UNIT5Z) AS UNITSTOTAL " +
           "FROM INVDTL0 AS A LEFT JOIN INVHDR0 AS B ON A.CONO5Z=B.CONO6A AND A.CSNO5Z=B.CSNO6A AND A.ORNO5Z = B.ORNO6A " +
           "WHERE A.CONO5Z=1 AND A.CSNO5Z=777 AND A.PRCD5Z='" + productCode.ToUpper() + "' AND A.CRCD5Z='" + colorCode.ToUpper() + "'";
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
    }
}
