namespace Overcuts_Program
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.submitOvercuts = new System.Windows.Forms.Button();
            this.styleInput = new System.Windows.Forms.TextBox();
            this.colorInput = new System.Windows.Forms.TextBox();
            this.unitsInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.orderFrom = new System.Windows.Forms.DateTimePicker();
            this.orderTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submitOvercuts
            // 
            this.submitOvercuts.Location = new System.Drawing.Point(845, 49);
            this.submitOvercuts.Name = "submitOvercuts";
            this.submitOvercuts.Size = new System.Drawing.Size(96, 23);
            this.submitOvercuts.TabIndex = 0;
            this.submitOvercuts.Text = "Get Overcuts";
            this.submitOvercuts.UseVisualStyleBackColor = true;
            this.submitOvercuts.Click += new System.EventHandler(this.button1_Click);
            // 
            // styleInput
            // 
            this.styleInput.Location = new System.Drawing.Point(35, 53);
            this.styleInput.Name = "styleInput";
            this.styleInput.Size = new System.Drawing.Size(100, 20);
            this.styleInput.TabIndex = 1;
            this.styleInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // colorInput
            // 
            this.colorInput.Location = new System.Drawing.Point(155, 53);
            this.colorInput.Name = "colorInput";
            this.colorInput.Size = new System.Drawing.Size(100, 20);
            this.colorInput.TabIndex = 2;
            this.colorInput.TextChanged += new System.EventHandler(this.colorInput_TextChanged);
            // 
            // unitsInput
            // 
            this.unitsInput.Location = new System.Drawing.Point(275, 53);
            this.unitsInput.Name = "unitsInput";
            this.unitsInput.Size = new System.Drawing.Size(100, 20);
            this.unitsInput.TabIndex = 3;
            this.unitsInput.TextChanged += new System.EventHandler(this.unitsInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Style";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Units";
            // 
            // orderFrom
            // 
            this.orderFrom.Location = new System.Drawing.Point(405, 52);
            this.orderFrom.Name = "orderFrom";
            this.orderFrom.Size = new System.Drawing.Size(189, 20);
            this.orderFrom.TabIndex = 7;
            // 
            // orderTo
            // 
            this.orderTo.Location = new System.Drawing.Point(613, 53);
            this.orderTo.Name = "orderTo";
            this.orderTo.Size = new System.Drawing.Size(200, 20);
            this.orderTo.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 734);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.orderTo);
            this.Controls.Add(this.orderFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unitsInput);
            this.Controls.Add(this.colorInput);
            this.Controls.Add(this.styleInput);
            this.Controls.Add(this.submitOvercuts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitOvercuts;
        private System.Windows.Forms.TextBox styleInput;
        private System.Windows.Forms.TextBox colorInput;
        private System.Windows.Forms.TextBox unitsInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker orderFrom;
        private System.Windows.Forms.DateTimePicker orderTo;
        private System.Windows.Forms.Label label4;
    }
}

