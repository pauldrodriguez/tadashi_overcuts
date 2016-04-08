/**
 * Author: Paul Rodriguez
 * @copyright Tadashi Shoji & Associates, Inc.
 **/

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
        protected int tableWidth;
        protected int tableHeight;
        protected int tableOffset;

        public DrawOvercuts(Form1 form) {
            this.form = form;
            this.xPos = 49;
            this.yPos = 90;
            this.tableWidth = 800;
            this.tableHeight = 90;
            this.tableOffset = 20;
        }

        private int getNextTableYPosition() {
            return this.tableHeight + this.tableOffset;
        }

        private void createColumns(TableLayoutPanel tableLayout)
        {
            tableLayout.ColumnCount = 15;
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6F));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9F));
        }

        private void createRows(TableLayoutPanel tableLayout) {
            tableLayout.RowCount = 3;
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
        }

        private void addHeader(TableLayoutPanel tableLayout)
        {
            int row = 0;
            int columnIndex = 0;
            tableLayout.Controls.Add(new Label() { Text = "Style", Dock = DockStyle.Fill, Anchor = AnchorStyles.None, TextAlign = ContentAlignment.MiddleCenter }, columnIndex++, row);
            tableLayout.Controls.Add(new Label() { Text = "Color", Dock = DockStyle.Fill, Anchor = AnchorStyles.None, TextAlign = ContentAlignment.MiddleCenter }, columnIndex++, row);
            
           
            foreach (KeyValuePair<string, string> productSize in Overcuts.getProduct().getStyleSizes())
            {
                tableLayout.Controls.Add(new Label() { Text = productSize.Value, Dock = DockStyle.Fill,Anchor=AnchorStyles.None,TextAlign=ContentAlignment.MiddleCenter }, columnIndex++, row);
            }
            tableLayout.Controls.Add(new Label() { Text = "Totals", Dock = DockStyle.Fill, Anchor = AnchorStyles.None, TextAlign = ContentAlignment.MiddleCenter }, columnIndex, row);
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

                this.addHeader(tableLayoutPanel1);

                overcut.incrementRowCount();
                overcut.setTableLayoutSizes(tableLayoutPanel1);

                overcut.incrementRowCount();
                overcut.setTableLayoutEstimateSizes(tableLayoutPanel1);

                tableLayoutPanel1.Location = new System.Drawing.Point(xPos, yPos);
                tableLayoutPanel1.Name = overcut.getTableName();
                this.createRows(tableLayoutPanel1);
               
                tableLayoutPanel1.Size = new System.Drawing.Size(this.tableWidth, this.tableHeight);
                tableLayoutPanel1.TabIndex = 0;
                tableLayoutPanel1.CellPaint += this.tableLayoutPanel1_CellPaint;
           
                this.form.Controls.Add(tableLayoutPanel1);
                tableLayoutPanel1.ResumeLayout(false);
                tableLayoutPanel1.PerformLayout();

                this.yPos += this.getNextTableYPosition();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return this;
        }

        void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0)
            {
                var rectangle = e.CellBounds;
                //rectangle.Inflate(-1, -1);
                if (e.Column < 14)
                {
                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Black, 2, ButtonBorderStyle.Solid, Color.Black, 2, ButtonBorderStyle.Solid, Color.Black, 2, ButtonBorderStyle.None, Color.Black, 2, ButtonBorderStyle.Solid);
                }
                else {
                    ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Black, 2, ButtonBorderStyle.Solid, Color.Black, 2, ButtonBorderStyle.Solid, Color.Black, 2, ButtonBorderStyle.Solid, Color.Black, 2, ButtonBorderStyle.Solid);
                }
                //ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.Raised, Border3DSide.All); // 3D border
            }
            if (e.Row == 1) {
                var rectangle = e.CellBounds;

                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.RoyalBlue, 2, ButtonBorderStyle.None, Color.RoyalBlue, 2, ButtonBorderStyle.None, Color.RoyalBlue, 2, ButtonBorderStyle.None, Color.RoyalBlue, 2, ButtonBorderStyle.Solid);
                
            }
            if (e.Row == 2) {
                var rectangle = e.CellBounds;

                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.RoyalBlue, 2, ButtonBorderStyle.None, Color.RoyalBlue, 2, ButtonBorderStyle.None, Color.RoyalBlue, 2, ButtonBorderStyle.None, Color.RoyalBlue, 2, ButtonBorderStyle.Solid);
                
            }
            /*else if (e.Column == 1 && e.Row == 0)
            {
                var rectangle = e.CellBounds;
                rectangle.Inflate(-1, -1);

                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Red, ButtonBorderStyle.Dotted); // dotted border

            }*/
        }
    }
}
