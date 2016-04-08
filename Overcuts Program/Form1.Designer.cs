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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.submitOvercuts = new System.Windows.Forms.Button();
            this.styleInput = new System.Windows.Forms.TextBox();
            this.colorInput = new System.Windows.Forms.TextBox();
            this.unitsInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.orderFrom = new System.Windows.Forms.DateTimePicker();
            this.orderTo = new System.Windows.Forms.DateTimePicker();
            this.helpButton = new System.Windows.Forms.Button();
            this.dateFromLabel = new System.Windows.Forms.Label();
            this.DateToLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submitOvercuts
            // 
            this.submitOvercuts.BackColor = System.Drawing.Color.LawnGreen;
            this.submitOvercuts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitOvercuts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.submitOvercuts.Location = new System.Drawing.Point(840, 41);
            this.submitOvercuts.Name = "submitOvercuts";
            this.submitOvercuts.Size = new System.Drawing.Size(130, 42);
            this.submitOvercuts.TabIndex = 0;
            this.submitOvercuts.Text = "GET OVERCUTS";
            this.submitOvercuts.UseVisualStyleBackColor = false;
            this.submitOvercuts.Click += new System.EventHandler(this.button1_Click);
            // 
            // styleInput
            // 
            this.styleInput.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styleInput.Location = new System.Drawing.Point(35, 53);
            this.styleInput.Name = "styleInput";
            this.styleInput.Size = new System.Drawing.Size(100, 23);
            this.styleInput.TabIndex = 1;
            this.styleInput.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // colorInput
            // 
            this.colorInput.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorInput.Location = new System.Drawing.Point(155, 53);
            this.colorInput.Name = "colorInput";
            this.colorInput.Size = new System.Drawing.Size(100, 23);
            this.colorInput.TabIndex = 2;
            this.colorInput.TextChanged += new System.EventHandler(this.colorInput_TextChanged);
            // 
            // unitsInput
            // 
            this.unitsInput.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitsInput.Location = new System.Drawing.Point(275, 53);
            this.unitsInput.Name = "unitsInput";
            this.unitsInput.Size = new System.Drawing.Size(100, 23);
            this.unitsInput.TabIndex = 3;
            this.unitsInput.TextChanged += new System.EventHandler(this.unitsInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Style";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(152, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Color";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(272, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Units";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // orderFrom
            // 
            this.orderFrom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderFrom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.orderFrom.Location = new System.Drawing.Point(393, 53);
            this.orderFrom.Name = "orderFrom";
            this.orderFrom.Size = new System.Drawing.Size(189, 23);
            this.orderFrom.TabIndex = 7;
            // 
            // orderTo
            // 
            this.orderTo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderTo.Location = new System.Drawing.Point(613, 53);
            this.orderTo.Name = "orderTo";
            this.orderTo.Size = new System.Drawing.Size(200, 23);
            this.orderTo.TabIndex = 8;
            // 
            // helpButton
            // 
            this.helpButton.BackColor = System.Drawing.SystemColors.Info;
            this.helpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpButton.Location = new System.Drawing.Point(1020, 41);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 42);
            this.helpButton.TabIndex = 9;
            this.helpButton.Text = "HELP";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // dateFromLabel
            // 
            this.dateFromLabel.AutoSize = true;
            this.dateFromLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFromLabel.Location = new System.Drawing.Point(405, 33);
            this.dateFromLabel.Name = "dateFromLabel";
            this.dateFromLabel.Size = new System.Drawing.Size(76, 16);
            this.dateFromLabel.TabIndex = 10;
            this.dateFromLabel.Text = "Date From";
            // 
            // DateToLabel
            // 
            this.DateToLabel.AutoSize = true;
            this.DateToLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateToLabel.Location = new System.Drawing.Point(610, 33);
            this.DateToLabel.Name = "DateToLabel";
            this.DateToLabel.Size = new System.Drawing.Size(61, 16);
            this.DateToLabel.TabIndex = 11;
            this.DateToLabel.Text = "Date To";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1215, 734);
            this.Controls.Add(this.DateToLabel);
            this.Controls.Add(this.dateFromLabel);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.orderTo);
            this.Controls.Add(this.orderFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unitsInput);
            this.Controls.Add(this.colorInput);
            this.Controls.Add(this.styleInput);
            this.Controls.Add(this.submitOvercuts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Overcuts Software (Tadashi)";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Label dateFromLabel;
        private System.Windows.Forms.Label DateToLabel;
    }
}

