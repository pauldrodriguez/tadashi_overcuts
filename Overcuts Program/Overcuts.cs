/**
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
    abstract class Overcuts
    {
        protected string labelText = "";
        protected string labelName = "";
        protected string tableName = "";
        protected int totalUnits = 0;
        protected bool noRows = true;

        protected static ProductStyles product = null;
        protected int row = 0;

        public void drawTableLabel(Form1 form, int xPos, int yPos)
        {
            Label label = new Label(); 
            label.Text = this.labelText;
            label.Name = this.labelName;
            label.Location = new System.Drawing.Point(xPos, yPos);
            label.Font = new Font("Arial", 18, FontStyle.Bold);
            label.AutoSize = true;
            form.Controls.Add(label);
        }

        public string getTableName() {
            return this.tableName;
        }

        public string getLabelName()
        {
            return this.labelName;
        }

        public string getLabelText()
        {
            return this.labelText;
        }

        public int getTotalUnits() {
            return this.totalUnits;
        }

        public bool hasRows() {
            return !noRows;
        }

        public static void setProduct(ProductStyles product) {
            Overcuts.product = product;
        }

        public static ProductStyles getProduct() {
            return Overcuts.product;
        }

        public static void resetDefaultVariables() {
            Overcuts.product = null;
        }

        public int getRow() {
            return this.row;
        }

        public void incrementRowCount() {
            this.row++;
        }

        public void removeTable(Form1 form) {
            if (form.Controls.OfType<TableLayoutPanel>().FirstOrDefault(l => l.Name == this.tableName) != null)
            {
                form.Controls.Remove(form.Controls.OfType<TableLayoutPanel>().FirstOrDefault(l => l.Name == this.tableName));
            }
        }

        public void RemoveLabel(Form1 form) {
            if (form.Controls.OfType<Label>().FirstOrDefault(l => l.Name == this.labelName) != null)
            {
                form.Controls.Remove(form.Controls.OfType<Label>().FirstOrDefault(l => l.Name == this.labelName));
            }
        }

        public void removePanel(Form1 form)
        {
            this.removeTable(form);
            this.RemoveLabel(form);
        }

        public abstract void setTableLayoutSizes(TableLayoutPanel tableLayout);

        public abstract void setTableLayoutEstimateSizes(TableLayoutPanel tableLayout);

        public abstract void getOvercuts(String productCode, String colorCode, String orderFrom = "", String orderTo = "");
    }
}
