/**
 * Author: Paul Rodriguez
 * @copyright Tadashi Shoji & Associates, Inc.
 **/

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

            submitOvercuts.FlatStyle = FlatStyle.Flat;
            helpButton.FlatStyle = FlatStyle.Flat;

            this.WindowState = FormWindowState.Maximized;

            orderFrom.Format = DateTimePickerFormat.Custom;
            orderFrom.CustomFormat = "MMMM dd, yyyy";
            
            orderTo.Format = DateTimePickerFormat.Custom;
            orderTo.CustomFormat = "MMMM dd, yyyy";
        }

        private string validateInput() {
            string errorMessages = "";
        
            if (styleInput.Text.ToString() == "")
            {
                errorMessages += "you must Enter a product code\n";
              
            }
            if (colorInput.Text.ToString() == "")
            {
                errorMessages += "you must Enter a color code\n";

            }
            if (unitsInput.Text.ToString() == "")
            {
                errorMessages += "you must Enter your desired units\n";
          
            }
            return errorMessages;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                string errors = this.validateInput();
                if (errors != "") {
                    MessageBox.Show(errors);
                    return;
                }
                
                int desiredQuantity = Int32.Parse(unitsInput.Text.ToString());
                string styleCode = styleInput.Text.ToString();
                string colorCode = colorInput.Text.ToString();
                string orderFromS = orderFrom.Value.Date.ToString("yyyyMMdd");
                string orderToS = orderTo.Value.Date.ToString("yyyyMMdd");
                int currDate = Int32.Parse(DateTime.Now.ToString("yyyyMMdd"));

                string orderFromDate = orderFrom.Value.Date.ToString("yyyy-MM-dd");
                string orderToDate = orderFrom.Value.Date.ToString("yyyy-MM-dd");

                if (currDate <= Int32.Parse(orderFromS))
                {
                    orderFromS = "";
                    orderFromDate = "";

                }

                if (currDate <= Int32.Parse(orderToS))
                {
                    orderToS = "";
                    orderToDate = "";
                }

                this.product = new ProductStyles(styleCode, colorCode, desiredQuantity);

                Overcuts.setProduct(this.product);

                EcommOvercuts ecomm = new EcommOvercuts();
                WholesalesOvercuts wholesale = new WholesalesOvercuts();
                RetailOvercuts retail = new RetailOvercuts();


                ecomm.getOvercuts(styleCode, colorCode, orderFromS, orderToS);
                wholesale.getOvercuts(styleCode, colorCode, orderFromS, orderToS);
                retail.getOvercuts(styleCode, colorCode, orderFromDate, orderToDate);

                EcommRetailOvercuts ecommRetail = new EcommRetailOvercuts(ecomm, retail);


                DrawOvercuts draw = new DrawOvercuts(this.form);
                draw.drawOvercuts(ecommRetail).drawOvercuts(ecomm).drawOvercuts(wholesale).drawOvercuts(retail);
            }
            catch (Exception exp) {
                MessageBox.Show(exp.ToString());
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

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Help helpWindow = new Help();
            helpWindow.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
