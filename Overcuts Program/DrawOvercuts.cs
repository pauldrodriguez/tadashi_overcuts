using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Overcuts_Program
{
    class DrawOvercuts
    {
        protected Form1 form = null;
        protected int xPos;
        protected int yPos;

        public DrawOvercuts(Form1 form) {
            this.form = form;
            this.xPos = 49;
            this.yPos = 90;
        }

        private void createColumns(TableLayoutPanel tableLayout)
        {
            tableLayout.ColumnCount = 15;
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

        private void createRows(TableLayoutPanel tableLayout) {
            tableLayout.RowCount = 3;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
        }

        private void addTopSizes(TableLayoutPanel tableLayout)
        {
            int row = 0;
            int columnIndex = 0;
            tableLayout.Controls.Add(new Label() { Text = "Style" }, columnIndex++, row);
            tableLayout.Controls.Add(new Label() { Text = "Color" }, columnIndex++, row);
            
           
            foreach (KeyValuePair<string, string> productSize in Overcuts.getProduct().getStyleSizes())
            {
                tableLayout.Controls.Add(new Label() { Text = productSize.Value }, columnIndex++, row);
            }
            tableLayout.Controls.Add(new Label() { Text = "Totals" }, columnIndex, row);
        }

        public DrawOvercuts drawOvercuts(Overcuts overcut) {
            try
            {
                overcut.removePanel(this.form);

                if (!overcut.hasRows())
                {
                    return this;
                }

                overcut.drawTableLabel(this.form, this.xPos, this.yPos);
                this.yPos += 40;

                TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();

                tableLayoutPanel1.SuspendLayout();

                
                this.createColumns(tableLayoutPanel1);

                this.addTopSizes(tableLayoutPanel1);

                overcut.incrementRowCount();
                overcut.setTableLayoutSizes(tableLayoutPanel1);

                overcut.incrementRowCount();
                overcut.setTableLayoutEstimateSizes(tableLayoutPanel1);

                tableLayoutPanel1.Location = new System.Drawing.Point(xPos, yPos);
                tableLayoutPanel1.Name = overcut.getTableName();
                this.createRows(tableLayoutPanel1);
               
                tableLayoutPanel1.Size = new System.Drawing.Size(688, 90);
                tableLayoutPanel1.TabIndex = 0;
           
                this.form.Controls.Add(tableLayoutPanel1);
                tableLayoutPanel1.ResumeLayout(false);
                tableLayoutPanel1.PerformLayout();

                this.yPos += 110;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return this;
        }
    }
}
