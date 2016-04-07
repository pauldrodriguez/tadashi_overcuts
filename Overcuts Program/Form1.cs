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
        private Form1 form = null;
        private ProductStyles product;
        private Dictionary<string, string> headerColumnNames = new Dictionary<string, string>();

        private void initializeHeaderRows() { 
            this.headerColumnNames["PRODUCTCODE"] = "Style";
            this.headerColumnNames["COLORCODE"] = "Color";
            this.headerColumnNames["SIZE0"] = "0";
            this.headerColumnNames["SIZE2"] = "2";
            this.headerColumnNames["SIZE4"] = "4";
            this.headerColumnNames["SIZE6"] = "6";
            this.headerColumnNames["SIZE8"] = "8";
            this.headerColumnNames["SIZE10"] = "10";
            this.headerColumnNames["SIZE12"] = "12";
            this.headerColumnNames["SIZE14"] = "14";
            this.headerColumnNames["SIZE16"] = "16";
            this.headerColumnNames["SIZE18"] = "18";
            this.headerColumnNames["SIZE20"] = "20";
            this.headerColumnNames["BULK"] = "Bulk";
            this.headerColumnNames["UNITTOTALS"] = "Totals";
        }
        public Form1()
        {
            InitializeComponent();

            this.initializeHeaderRows();
            form = this;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int desiredQuantity = Int32.Parse(unitsInput.Text.ToString());
            string styleCode   = styleInput.Text.ToString();
            string colorCode   = colorInput.Text.ToString();
            string orderFromS  = orderFrom.Value.Date.ToString("yyyyMMdd");
            string orderToS    = orderTo.Value.Date.ToString("yyyyMMdd");
            int currDate       = Int32.Parse(DateTime.Now.ToString("yyyyMMdd"));

            string orderFromDate = orderFrom.Value.Date.ToString("yyyy-MM-dd");
            string orderToDate = orderFrom.Value.Date.ToString("yyyy-MM-dd");

            if( currDate<=Int32.Parse(orderFromS) ) {
                orderFromS = "";
                orderFromDate = "";
                
            }

            if ( currDate <= Int32.Parse(orderToS) ) {
                orderToS = "";
                orderToDate = "";
            }

            this.product = new ProductStyles(styleCode,colorCode,desiredQuantity);

            Overcuts.setProduct(this.product);

            EcommOvercuts ecomm = new EcommOvercuts();
            WholesalesOvercuts wholesale = new WholesalesOvercuts();
            RetailOvercuts retail = new RetailOvercuts();

            ecomm.getOvercuts(styleCode, colorCode, orderFromS, orderToS);
            wholesale.getOvercuts(styleCode, colorCode, orderFromS, orderToS);
            retail.getOvercuts(styleCode, colorCode, orderFromDate, orderToDate);

            DrawOvercuts draw = new DrawOvercuts(this.form);
            draw.drawOvercuts(ecomm).drawOvercuts(wholesale).drawOvercuts(retail);

            /*int xPos = 49;
            int yPos = 90;

            if (ecomm.hasRows())
            {
                ecomm.removePanel(this.form);
                //removePanel("ecommOvercutPanel","ecommOvercutLabel");
                drawEcommOvercutsTable(ecomm,ref xPos,ref yPos);
            }

            if (wholesale.hasRows())
            {
                yPos += 110;
                wholesale.removePanel(this.form);
                //removePanel("wholesaleOvercutPanel","wholesaleOvercutLabel");
                drawWholesaleOvercutsTable(wholesale,ref xPos, ref yPos);
            }

            if (retail.hasRows())
            {
                yPos += 110;
                retail.removePanel(this.form);
                //removePanel("retailOvercutPanel", "retailOvercutLabel");
                drawRetailOvercutsTable(retail, ref xPos, ref yPos);
            }*/
        }

        /*
        public void removePanel(string panelName,string panelLabelName) {
            if (this.Controls.OfType<TableLayoutPanel>().FirstOrDefault(l => l.Name == panelName) != null) {
                this.Controls.Remove(this.Controls.OfType<TableLayoutPanel>().FirstOrDefault(l => l.Name == panelName));
            }
            if (this.Controls.OfType<Label>().FirstOrDefault(l => l.Name == panelLabelName) != null)
            {
                this.Controls.Remove(this.Controls.OfType<Label>().FirstOrDefault(l => l.Name == panelLabelName));
            }
            
        }

        private void addTopSizes(TableLayoutPanel tableLayout) {
            int row = 0;
            tableLayout.Controls.Add(new Label() { Text = "Style" }, 0, row);
            tableLayout.Controls.Add(new Label() { Text = "Color" }, 1, row);
            int columnIndex = 2;
            foreach (KeyValuePair<string, string> productSize in this.product.getStyleSizes()) {
                tableLayout.Controls.Add(new Label() { Text = productSize.Value }, columnIndex, row);
                columnIndex++;
            }
            tableLayout.Controls.Add(new Label() { Text = "Totals" }, 14, row);
        }

        private void addHeaderRow(TableLayoutPanel tableLayout,int row)
        {
            int columnIndex = 0;
            foreach (KeyValuePair<string, string> columnName in this.headerColumnNames)
            {
                tableLayout.Controls.Add(new Label() { Text = columnName.Value }, columnIndex, row);
                columnIndex++;
            }
        }

        private void createColumnStyles(TableLayoutPanel tableLayout) {
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
        }

        private void drawEcommOvercutsTable(Overcuts overcuts, ref int xPos, ref int yPos) {
            try
            {
                int desiredQuantity = Int32.Parse(unitsInput.Text.ToString());
                //label4.Text = unitsToShip.ToString();

                overcuts.drawTableLabel(this.form, xPos, yPos);

                TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
                tableLayoutPanel1.SuspendLayout();

                yPos += 40;

                // tableLayoutPanel1
                tableLayoutPanel1.ColumnCount = 15;
                this.createColumnStyles(tableLayoutPanel1);

                // SIZES ROW
                this.addTopSizes(tableLayoutPanel1);

                // HEADER ROW
                //this.addHeaderRow(tableLayoutPanel1,1);
                
                // RETURNED VALUES ROW
                overcuts.incrementRowCount();
                overcuts.setTableLayoutSizes(tableLayoutPanel1);
              
                // ESTIMATION VALUE ROW
                overcuts.incrementRowCount();
                overcuts.setTableLayoutEstimateSizes(tableLayoutPanel1);

                tableLayoutPanel1.Location = new System.Drawing.Point(xPos, yPos);
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


        private void drawWholesaleOvercutsTable(Overcuts overcuts, ref int xPos, ref int yPos)
        {
            try
            {
              

                int desiredQuantity = Int32.Parse(unitsInput.Text.ToString());

                overcuts.drawTableLabel(this.form, xPos, yPos);
                

                TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
                tableLayoutPanel1.SuspendLayout();

                yPos += 40;

                // tableLayoutPanel1
                tableLayoutPanel1.ColumnCount = 15;
                this.createColumnStyles(tableLayoutPanel1);

                // SIZES ROW
                this.addTopSizes(tableLayoutPanel1);

                // HEADER ROW
                //this.addHeaderRow(tableLayoutPanel1, 1);

                // RETURNED VALUES ROW
                overcuts.incrementRowCount();
                overcuts.setTableLayoutSizes(tableLayoutPanel1);

                // ESTIMATION VALUE ROW
                overcuts.incrementRowCount();
                overcuts.setTableLayoutEstimateSizes(tableLayoutPanel1);

                tableLayoutPanel1.Location = new System.Drawing.Point(xPos, yPos);
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

        private void drawRetailOvercutsTable(Overcuts overcuts, ref int xPos, ref int yPos)
        {
            try
            {
             
                int desiredQuantity = Int32.Parse(unitsInput.Text.ToString());
                //label4.Text = unitsToShip.ToString();
                TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
                Label ecommLabelTable = new Label();
                ecommLabelTable.Text = "Retail";
                ecommLabelTable.Name = "retailOvercutLabel";
                ecommLabelTable.Location = new System.Drawing.Point(xPos, yPos);
                ecommLabelTable.Font = new Font("Arial", 18, FontStyle.Bold);
                ecommLabelTable.AutoSize = true;
                Controls.Add(ecommLabelTable);
                tableLayoutPanel1.SuspendLayout();

                yPos += 40;

                // tableLayoutPanel1
                tableLayoutPanel1.ColumnCount = 15;
                this.createColumnStyles(tableLayoutPanel1);

                // SIZES ROW
                this.addTopSizes(tableLayoutPanel1);

                // HEADER ROW
                //this.addHeaderRow(tableLayoutPanel1,1);

                // RETURNED VALUES ROW
                overcuts.incrementRowCount();
                overcuts.setTableLayoutSizes(tableLayoutPanel1);

                // ESTIMATION VALUE ROW
                overcuts.incrementRowCount();
                overcuts.setTableLayoutEstimateSizes(tableLayoutPanel1);

                tableLayoutPanel1.Location = new System.Drawing.Point(xPos, yPos);
                tableLayoutPanel1.Name = "retailOvercutPanel";
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

        }*/

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
