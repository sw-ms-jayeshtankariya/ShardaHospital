namespace Medical
{
    partial class frmSerial
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
            this.fraDate = new System.Windows.Forms.GroupBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.cmdReturn = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.fraDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // fraDate
            // 
            this.fraDate.Controls.Add(this.dateFrom);
            this.fraDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraDate.Location = new System.Drawing.Point(47, 9);
            this.fraDate.Name = "fraDate";
            this.fraDate.Size = new System.Drawing.Size(135, 65);
            this.fraDate.TabIndex = 3;
            this.fraDate.TabStop = false;
            this.fraDate.Text = "Select Date";
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "MM/dd/yyyy";
            this.dateFrom.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(24, 27);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(87, 20);
            this.dateFrom.TabIndex = 5;
            // 
            // cmdReturn
            // 
            this.cmdReturn.Location = new System.Drawing.Point(117, 88);
            this.cmdReturn.Name = "cmdReturn";
            this.cmdReturn.Size = new System.Drawing.Size(75, 25);
            this.cmdReturn.TabIndex = 9;
            this.cmdReturn.Text = "Cancel";
            this.cmdReturn.UseVisualStyleBackColor = true;
            this.cmdReturn.Click += new System.EventHandler(this.cmdReturn_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(36, 88);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 25);
            this.cmdOk.TabIndex = 8;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // frmSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(226, 125);
            this.Controls.Add(this.cmdReturn);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.fraDate);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSerial";
            this.Text = "Set serial number";
            this.fraDate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox fraDate;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Button cmdReturn;
        private System.Windows.Forms.Button cmdOk;
    }
}