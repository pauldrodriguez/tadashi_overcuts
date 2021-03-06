﻿/**
 * Author: Paul Rodriguez
 * @copyright Tadashi Shoji & Associates, Inc.
 **/

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
    class EcommRetailOvercuts: Overcuts
    {
        protected EcommOvercuts ecomm;
        protected RetailOvercuts retail;
        protected Dictionary<string, string> overcutvalues;
        protected Dictionary<string, int> unitsBySize;
       

        public EcommRetailOvercuts(EcommOvercuts ecomm, RetailOvercuts retail) {
            this.unitsBySize = new Dictionary<string, int>();
            this.overcutvalues = new Dictionary<string, string>();
            this.ecomm  = ecomm;
            this.retail = retail;
            this.labelText = "Ecomm and Retail";
            this.labelName = "ecommRetailOvercutLabel";
            this.tableName = "ecommRetailOvercutPanel";

            if (this.ecomm.hasRows() && retail.hasRows()) { 
                noRows = false;
                this.combineTotals();
            }
        }

        public override void getOvercuts(String productCode, String colorCode, String orderFrom = "", String orderTo = "") {
            return;
        }

        public void combineTotals() {
            ProductStyles product = Overcuts.product;
            overcutvalues["PRODUCTCODE"] = product.getStyleCode();
            overcutvalues["COLORCODE"]   = product.getColorCode();

            foreach (KeyValuePair<string, string> productSize in product.getStyleSizes())
            {
                int sizeQtyRetail = 0;
                retail.qtySoldPerSize.TryGetValue(productSize.Value.ToUpper(), out sizeQtyRetail);

                int sizeQtyEcomm = 0;
                ecomm.unitsBySize.TryGetValue(productSize.Key.ToUpper(), out sizeQtyEcomm);

                int sizeQtyTotal = sizeQtyEcomm + sizeQtyRetail;
                this.unitsBySize[productSize.Key.ToUpper()] = sizeQtyTotal;
                overcutvalues[productSize.Key.ToUpper()] = sizeQtyTotal.ToString();
                
            }
            this.totalUnits = retail.getTotalUnits() + ecomm.getTotalUnits();
            overcutvalues["UNITSTOTAL"] = this.totalUnits.ToString();
        }

        public override void setTableLayoutSizes(TableLayoutPanel tableLayout)
        {
            // Do not iterate the dictionary using key value pair as it can return items in different order than they were put in
            int columnIndex = 0;
            tableLayout.Controls.Add(new Label() { Text = this.overcutvalues["PRODUCTCODE"], Dock = DockStyle.Fill, Anchor = AnchorStyles.None, TextAlign = ContentAlignment.MiddleCenter }, columnIndex++, row);
            tableLayout.Controls.Add(new Label() { Text = this.overcutvalues["COLORCODE"], Dock = DockStyle.Fill, Anchor = AnchorStyles.None, TextAlign = ContentAlignment.MiddleCenter }, columnIndex++, row);
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
                string sizeVal = "";
               
                this.overcutvalues.TryGetValue(sizekey, out sizeVal);

                tableLayout.Controls.Add(new Label() { Text = sizeVal, Dock = DockStyle.Fill, Anchor = AnchorStyles.None, TextAlign = ContentAlignment.MiddleCenter }, columnIndex++, row);
            }
            string total = "";
            this.overcutvalues.TryGetValue("UNITSTOTAL",out total);
            tableLayout.Controls.Add(new Label() { Text = total, Dock = DockStyle.Fill, Anchor = AnchorStyles.None, TextAlign = ContentAlignment.MiddleCenter }, columnIndex++, row);
           
        }

        public override void setTableLayoutEstimateSizes(TableLayoutPanel tableLayout)
        {

            int desiredQuantity = Overcuts.product.getDesiredQuantity();
            int colIndex = 0;
            tableLayout.Controls.Add(new Label() { Text = "Estimation", Dock = DockStyle.Fill, Anchor = AnchorStyles.None, TextAlign = ContentAlignment.MiddleCenter }, colIndex++, row);
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

                int qtySold = 0;
                this.unitsBySize.TryGetValue(sizekey, out qtySold);
                double percentage = (double)qtySold/ (double)this.totalUnits;

                int estimatedSizeQuantity = (int)(percentage * (double)desiredQuantity);

                tableLayout.Controls.Add(new Label() { Text = estimatedSizeQuantity.ToString(), Dock = DockStyle.Fill, Anchor = AnchorStyles.None, TextAlign = ContentAlignment.MiddleCenter }, colIndex++, row);

            }
            tableLayout.Controls.Add(new Label() { Text = desiredQuantity.ToString(), Dock = DockStyle.Fill, Anchor = AnchorStyles.None, TextAlign = ContentAlignment.MiddleCenter }, colIndex, row);
        }

    }
}
