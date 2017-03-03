namespace Medical
{
    partial class frmDate
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
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.fraDate = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.fraSelectOption = new System.Windows.Forms.GroupBox();
            this.chkName = new System.Windows.Forms.RadioButton();
            this.chkReceiptNo = new System.Windows.Forms.RadioButton();
            this.fraName = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.fraReceiptNo = new System.Windows.Forms.GroupBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.cmdOk = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.fraDate.SuspendLayout();
            this.fraSelectOption.SuspendLayout();
            this.fraName.SuspendLayout();
            this.fraReceiptNo.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDate.Location = new System.Drawing.Point(29, 31);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(68, 19);
            this.chkDate.TabIndex = 0;
            this.chkDate.Text = "By Date";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // fraDate
            // 
            this.fraDate.Controls.Add(this.dateTo);
            this.fraDate.Controls.Add(this.label2);
            this.fraDate.Controls.Add(this.dateFrom);
            this.fraDate.Controls.Add(this.label1);
            this.fraDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraDate.Location = new System.Drawing.Point(168, 12);
            this.fraDate.Name = "fraDate";
            this.fraDate.Size = new System.Drawing.Size(273, 49);
            this.fraDate.TabIndex = 2;
            this.fraDate.TabStop = false;
            this.fraDate.Text = "Select Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "MM/dd/yyyy";
            this.dateFrom.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(54, 19);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(87, 20);
            this.dateFrom.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "MM/dd/yyyy";
            this.dateTo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(176, 19);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(87, 20);
            this.dateTo.TabIndex = 6;
            // 
            // fraSelectOption
            // 
            this.fraSelectOption.Controls.Add(this.chkReceiptNo);
            this.fraSelectOption.Controls.Add(this.chkName);
            this.fraSelectOption.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraSelectOption.Location = new System.Drawing.Point(12, 67);
            this.fraSelectOption.Name = "fraSelectOption";
            this.fraSelectOption.Size = new System.Drawing.Size(130, 117);
            this.fraSelectOption.TabIndex = 3;
            this.fraSelectOption.TabStop = false;
            this.fraSelectOption.Text = "Select Option";
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkName.Location = new System.Drawing.Point(17, 23);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(75, 19);
            this.chkName.TabIndex = 0;
            this.chkName.TabStop = true;
            this.chkName.Text = "By Name";
            this.chkName.UseVisualStyleBackColor = true;
            this.chkName.CheckedChanged += new System.EventHandler(this.chkName_CheckedChanged);
            // 
            // chkReceiptNo
            // 
            this.chkReceiptNo.AutoSize = true;
            this.chkReceiptNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReceiptNo.Location = new System.Drawing.Point(17, 64);
            this.chkReceiptNo.Name = "chkReceiptNo";
            this.chkReceiptNo.Size = new System.Drawing.Size(99, 19);
            this.chkReceiptNo.TabIndex = 4;
            this.chkReceiptNo.TabStop = true;
            this.chkReceiptNo.Text = "By ReceiptNo";
            this.chkReceiptNo.UseVisualStyleBackColor = true;
            this.chkReceiptNo.CheckedChanged += new System.EventHandler(this.chkReceiptNo_CheckedChanged);
            // 
            // fraName
            // 
            this.fraName.Controls.Add(this.txtName);
            this.fraName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraName.Location = new System.Drawing.Point(168, 67);
            this.fraName.Name = "fraName";
            this.fraName.Size = new System.Drawing.Size(273, 55);
            this.fraName.TabIndex = 4;
            this.fraName.TabStop = false;
            this.fraName.Text = "Enter Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(257, 22);
            this.txtName.TabIndex = 0;
            // 
            // fraReceiptNo
            // 
            this.fraReceiptNo.Controls.Add(this.txtReceiptNo);
            this.fraReceiptNo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraReceiptNo.Location = new System.Drawing.Point(168, 131);
            this.fraReceiptNo.Name = "fraReceiptNo";
            this.fraReceiptNo.Size = new System.Drawing.Size(273, 53);
            this.fraReceiptNo.TabIndex = 5;
            this.fraReceiptNo.TabStop = false;
            this.fraReceiptNo.Text = "Enter Receipt Number";
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(6, 21);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(257, 22);
            this.txtReceiptNo.TabIndex = 0;
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(168, 199);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 6;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(249, 199);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 262);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.fraReceiptNo);
            this.Controls.Add(this.fraDate);
            this.Controls.Add(this.fraName);
            this.Controls.Add(this.fraSelectOption);
            this.Controls.Add(this.chkDate);
            this.Name = "frmDate";
            this.Text = "frmDate";
            this.Load += new System.EventHandler(this.frmDate_Load);
            this.fraDate.ResumeLayout(false);
            this.fraDate.PerformLayout();
            this.fraSelectOption.ResumeLayout(false);
            this.fraSelectOption.PerformLayout();
            this.fraName.ResumeLayout(false);
            this.fraName.PerformLayout();
            this.fraReceiptNo.ResumeLayout(false);
            this.fraReceiptNo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.GroupBox fraDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox fraSelectOption;
        private System.Windows.Forms.RadioButton chkName;
        private System.Windows.Forms.RadioButton chkReceiptNo;
        private System.Windows.Forms.GroupBox fraName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox fraReceiptNo;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Button cmdCancel;
    }
}