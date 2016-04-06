using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overcuts_Program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ProductStyles productStyles = new ProductStyles();
            DataSet styles = productStyles.getStyles();
          
            orderFrom.Format = DateTimePickerFormat.Custom;
            orderFrom.CustomFormat = "dd/MM/yyyy";

            orderTo.Format = DateTimePickerFormat.Custom;
            orderTo.CustomFormat = "dd/MM/yyyy";

           
           
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string orderFromS = orderFrom.Value.Date.ToString("yyyyMMdd");
            string orderToS   = orderTo.Value.Date.ToString("yyyyMMdd");
            int currDate = Int32.Parse(DateTime.Now.ToString("yyyyMMdd"));
            if(currDate==Int32.Parse(orderFromS) && currDate==Int32.Parse(orderToS) ) {
                orderFromS = "";
                orderToS = "";
            }
            EcommOvercuts ecomm = new EcommOvercuts();
            WholesalesOvercuts wholesale = new WholesalesOvercuts();
            ecomm.getOvercuts(styleInput.Text.ToString(),colorInput.Text.ToString(),orderFromS,orderToS);
            wholesale.getOvercuts(styleInput.Text.ToString(), colorInput.Text.ToString(), orderFromS, orderToS);

            if (!ecomm.noRows)
            {
                removePanel("ecommOvercutPanel","ecommOvercutLabel");
                drawEcommOvercutsTable(ecomm);
            }

            if(!wholesale.noRows) {
                removePanel("wholesaleOvercutPanel","wholesaleOvercutLabel");
                drawWholesaleOvercutsTable(wholesale);
            }
        }

        public void removePanel(string panelName,string panelLabelName) {
            if (this.Controls.OfType<TableLayoutPanel>().FirstOrDefault(l => l.Name == panelName) != null) {
                this.Controls.Remove(this.Controls.OfType<TableLayoutPanel>().FirstOrDefault(l => l.Name == panelName));
            }
            if (this.Controls.OfType<Label>().FirstOrDefault(l => l.Name == panelLabelName) != null)
            {
                this.Controls.Remove(this.Controls.OfType<Label>().FirstOrDefault(l => l.Name == panelLabelName));
            }
            
        }

        private void drawEcommOvercutsTable(EcommOvercuts overcuts) {
            try
            {
                int unitsToShip = Int32.Parse(unitsInput.Text.ToString());
                //label4.Text = unitsToShip.ToString();
                TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
                Label ecommLabelTable = new Label();
                ecommLabelTable.Text = "E-Commerce";
                ecommLabelTable.Name = "ecommOvercutLabel";
                ecommLabelTable.Location = new System.Drawing.Point(49, 90);
                ecommLabelTable.Font = new Font("Arial", 18, FontStyle.Bold);
                ecommLabelTable.AutoSize = true;
                Controls.Add(ecommLabelTable);
                tableLayoutPanel1.SuspendLayout();


                // tableLayoutPanel1
                tableLayoutPanel1.ColumnCount = 15;
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));

                // header row
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Style" }, 0, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Color" }, 1, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "0" }, 2, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "2" }, 3, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "4" }, 4, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "6" }, 5, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "8" }, 6, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "10" }, 7, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "12" }, 8, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "14" }, 9, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "16" }, 10, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "18" }, 11, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "20" }, 12, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Bulk" }, 13, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Totals" }, 14, 0);

                // RETURNED VALUES ROW
                tableLayoutPanel1.Controls.Add(new Label() { Text = overcuts.overcutvalues["PRODUCTCODE"] }, 0, 1);
                tableLayoutPanel1.Controls.Add(new Label() { Text = overcuts.overcutvalues["COLORCODE"] }, 1, 1);
                var colIndex = 2;
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
                    tableLayoutPanel1.Controls.Add(new Label() { Text = overcuts.overcutvalues[sizekey] }, colIndex++, 1);
                }
                tableLayoutPanel1.Controls.Add(new Label() { Text = overcuts.overcutvalues["UNITSTOTAL"] }, 14, 1);

                tableLayoutPanel1.Controls.Add(new Label() { Text = "Estimation" }, 0, 2);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "" }, 1, 2);
                colIndex = 2;
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


                    double percentage = (double)overcuts.unitsBySize[sizekey] / (double)overcuts.totalUnits;

                    int estimatedSizeQuantity = (int)(percentage * (double)unitsToShip);

                    tableLayoutPanel1.Controls.Add(new Label() { Text = estimatedSizeQuantity.ToString() }, colIndex++, 2);

                }

                tableLayoutPanel1.Controls.Add(new Label() { Text = unitsToShip.ToString() }, 14, 2);

                tableLayoutPanel1.Location = new System.Drawing.Point(49, 130);
                tableLayoutPanel1.Name = "ecommOvercutPanel";
                tableLayoutPanel1.RowCount = 3;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
                tableLayoutPanel1.Size = new System.Drawing.Size(688, 90);
                tableLayoutPanel1.TabIndex = 0;
                //tableLayoutPanel1.CellPaint += new TableLayoutCellPaintEventHandler(tableLayoutPanel1_CellPaint);





                Controls.Add(tableLayoutPanel1);
                tableLayoutPanel1.ResumeLayout(false);
                tableLayoutPanel1.PerformLayout();
            }
            catch (Exception e) {
                MessageBox.Show(e.ToString());
            }
           
        }


        private void drawWholesaleOvercutsTable(WholesalesOvercuts overcuts)
        {
            try
            {
                int unitsToShip = Int32.Parse(unitsInput.Text.ToString());
                //label4.Text = unitsToShip.ToString();
                TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
                Label ecommLabelTable = new Label();
                ecommLabelTable.Text = "Wholesale";
                ecommLabelTable.Name = "wholesaleOvercutLabel";
                ecommLabelTable.Location = new System.Drawing.Point(49, 240);
                ecommLabelTable.Font = new Font("Arial", 18, FontStyle.Bold);
                ecommLabelTable.AutoSize = true;
                Controls.Add(ecommLabelTable);
                tableLayoutPanel1.SuspendLayout();


                // tableLayoutPanel1
                tableLayoutPanel1.ColumnCount = 15;
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));

                // header row
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Style" }, 0, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Color" }, 1, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "0" }, 2, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "2" }, 3, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "4" }, 4, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "6" }, 5, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "8" }, 6, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "10" }, 7, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "12" }, 8, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "14" }, 9, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "16" }, 10, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "18" }, 11, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "20" }, 12, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Bulk" }, 13, 0);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "Totals" }, 14, 0);

                // RETURNED VALUES ROW
                tableLayoutPanel1.Controls.Add(new Label() { Text = overcuts.overcutvalues["PRODUCTCODE"] }, 0, 1);
                tableLayoutPanel1.Controls.Add(new Label() { Text = overcuts.overcutvalues["COLORCODE"] }, 1, 1);
                var colIndex = 2;
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
                    tableLayoutPanel1.Controls.Add(new Label() { Text = overcuts.overcutvalues[sizekey] }, colIndex++, 1);
                }
                tableLayoutPanel1.Controls.Add(new Label() { Text = overcuts.overcutvalues["UNITSTOTAL"] }, 14, 1);

                tableLayoutPanel1.Controls.Add(new Label() { Text = "Estimation" }, 0, 2);
                tableLayoutPanel1.Controls.Add(new Label() { Text = "" }, 1, 2);
                colIndex = 2;
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


                    double percentage = (double)overcuts.unitsBySize[sizekey] / (double)overcuts.totalUnits;

                    int estimatedSizeQuantity = (int)(percentage * (double)unitsToShip);

                    tableLayoutPanel1.Controls.Add(new Label() { Text = estimatedSizeQuantity.ToString() }, colIndex++, 2);

                }

                tableLayoutPanel1.Controls.Add(new Label() { Text = unitsToShip.ToString() }, 14, 2);

                tableLayoutPanel1.Location = new System.Drawing.Point(49, 280);
                tableLayoutPanel1.Name = "wholesaleOvercutPanel";
                tableLayoutPanel1.RowCount = 3;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
                tableLayoutPanel1.Size = new System.Drawing.Size(688, 90);
                tableLayoutPanel1.TabIndex = 0;
                //tableLayoutPanel1.CellPaint += new TableLayoutCellPaintEventHandler(tableLayoutPanel1_CellPaint);





                Controls.Add(tableLayoutPanel1);
                tableLayoutPanel1.ResumeLayout(false);
                tableLayoutPanel1.PerformLayout();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column == 0)
            {
                var rectangle = e.CellBounds;
                rectangle.Inflate(-1, -1);

                ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.Raised, Border3DSide.All); // 3D border
            }
            else if (e.Column == 1 && e.Row == 0)
            {
                var rectangle = e.CellBounds;
                rectangle.Inflate(-1, -1);

                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Red, ButtonBorderStyle.Dotted); // dotted border
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void colorInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void unitsInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void StyleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
