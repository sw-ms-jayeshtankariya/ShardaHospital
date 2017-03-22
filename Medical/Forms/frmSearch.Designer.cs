namespace Medical
{
    partial class frmSearch
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
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.fraSelectOption = new System.Windows.Forms.GroupBox();
            this.chkReceiptNo = new System.Windows.Forms.RadioButton();
            this.chkName = new System.Windows.Forms.RadioButton();
            this.fraName = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.fraReceiptNo = new System.Windows.Forms.GroupBox();
            this.txtReceiptNo = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.fraDate.SuspendLayout();
            this.fraSelectOption.SuspendLayout();
            this.fraName.SuspendLayout();
            this.fraReceiptNo.SuspendLayout();
            this.SuspendLayout();
            // 
            // fraDate
            // 
            this.fraDate.Controls.Add(this.dateTo);
            this.fraDate.Controls.Add(this.label2);
            this.fraDate.Controls.Add(this.dateFrom);
            this.fraDate.Controls.Add(this.label1);
            this.fraDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraDate.Location = new System.Drawing.Point(159, 13);
            this.fraDate.Name = "fraDate";
            this.fraDate.Size = new System.Drawing.Size(273, 53);
            this.fraDate.TabIndex = 9;
            this.fraDate.TabStop = false;
            this.fraDate.Text = "Select Date";
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "MM/dd/yyyy";
            this.dateTo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(176, 20);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(87, 21);
            this.dateTo.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "MM/dd/yyyy";
            this.dateFrom.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(54, 20);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(87, 21);
            this.dateFrom.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDate.Location = new System.Drawing.Point(30, 33);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(67, 18);
            this.chkDate.TabIndex = 8;
            this.chkDate.Text = "By Date";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // fraSelectOption
            // 
            this.fraSelectOption.Controls.Add(this.chkReceiptNo);
            this.fraSelectOption.Controls.Add(this.chkName);
            this.fraSelectOption.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraSelectOption.Location = new System.Drawing.Point(13, 72);
            this.fraSelectOption.Name = "fraSelectOption";
            this.fraSelectOption.Size = new System.Drawing.Size(130, 126);
            this.fraSelectOption.TabIndex = 10;
            this.fraSelectOption.TabStop = false;
            this.fraSelectOption.Text = "Select Option";
            // 
            // chkReceiptNo
            // 
            this.chkReceiptNo.AutoSize = true;
            this.chkReceiptNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReceiptNo.Location = new System.Drawing.Point(17, 69);
            this.chkReceiptNo.Name = "chkReceiptNo";
            this.chkReceiptNo.Size = new System.Drawing.Size(96, 18);
            this.chkReceiptNo.TabIndex = 4;
            this.chkReceiptNo.TabStop = true;
            this.chkReceiptNo.Text = "By ReceiptNo";
            this.chkReceiptNo.UseVisualStyleBackColor = true;
            this.chkReceiptNo.CheckedChanged += new System.EventHandler(this.chkReceiptNo_CheckedChanged);
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkName.Location = new System.Drawing.Point(17, 25);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(72, 18);
            this.chkName.TabIndex = 0;
            this.chkName.TabStop = true;
            this.chkName.Text = "By Name";
            this.chkName.UseVisualStyleBackColor = true;
            this.chkName.CheckedChanged += new System.EventHandler(this.chkName_CheckedChanged);
            // 
            // fraName
            // 
            this.fraName.Controls.Add(this.txtName);
            this.fraName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraName.Location = new System.Drawing.Point(159, 72);
            this.fraName.Name = "fraName";
            this.fraName.Size = new System.Drawing.Size(273, 59);
            this.fraName.TabIndex = 11;
            this.fraName.TabStop = false;
            this.fraName.Text = "Enter Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(257, 23);
            this.txtName.TabIndex = 0;
            // 
            // fraReceiptNo
            // 
            this.fraReceiptNo.Controls.Add(this.txtReceiptNo);
            this.fraReceiptNo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraReceiptNo.Location = new System.Drawing.Point(159, 141);
            this.fraReceiptNo.Name = "fraReceiptNo";
            this.fraReceiptNo.Size = new System.Drawing.Size(273, 57);
            this.fraReceiptNo.TabIndex = 12;
            this.fraReceiptNo.TabStop = false;
            this.fraReceiptNo.Text = "Enter Receipt Number";
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(6, 23);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(257, 23);
            this.txtReceiptNo.TabIndex = 0;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(230, 214);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 25);
            this.cmdCancel.TabIndex = 14;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(149, 214);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 25);
            this.cmdOk.TabIndex = 13;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(445, 252);
            this.Controls.Add(this.fraDate);
            this.Controls.Add(this.chkDate);
            this.Controls.Add(this.fraSelectOption);
            this.Controls.Add(this.fraName);
            this.Controls.Add(this.fraReceiptNo);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.Name = "frmSearch";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.frmSearch_Load);
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

        private System.Windows.Forms.GroupBox fraDate;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.GroupBox fraSelectOption;
        private System.Windows.Forms.RadioButton chkReceiptNo;
        private System.Windows.Forms.RadioButton chkName;
        private System.Windows.Forms.GroupBox fraName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox fraReceiptNo;
        private System.Windows.Forms.TextBox txtReceiptNo;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOk;



    }
}