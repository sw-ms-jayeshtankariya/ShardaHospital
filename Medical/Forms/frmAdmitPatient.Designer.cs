namespace Medical
{
    partial class frmAdmitPatient
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtUSugar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBp = new System.Windows.Forms.TextBox();
            this.txtTemp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInsulin = new System.Windows.Forms.TextBox();
            this.txtBlSugar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdAdmitReport = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.cmbRx = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.dgAdminPatient = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.chk12Mid = new System.Windows.Forms.CheckBox();
            this.chk10PM = new System.Windows.Forms.CheckBox();
            this.chk6PM = new System.Windows.Forms.CheckBox();
            this.chk2PM = new System.Windows.Forms.CheckBox();
            this.chk12Noon = new System.Windows.Forms.CheckBox();
            this.chk8AM = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAdminPatient)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.txtPname, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtPId, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtpDate, 5, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(33, 31);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(707, 59);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // txtPname
            // 
            this.txtPname.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPname.Location = new System.Drawing.Point(253, 19);
            this.txtPname.Name = "txtPname";
            this.txtPname.ReadOnly = true;
            this.txtPname.Size = new System.Drawing.Size(176, 20);
            this.txtPname.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pid";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(435, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Date";
            // 
            // txtPId
            // 
            this.txtPId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPId.Location = new System.Drawing.Point(33, 19);
            this.txtPId.Name = "txtPId";
            this.txtPId.ReadOnly = true;
            this.txtPId.Size = new System.Drawing.Size(125, 20);
            this.txtPId.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(164, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Patient Name";
            // 
            // dtpDate
            // 
            this.dtpDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDate.CustomFormat = "MM/dd/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(474, 19);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(93, 20);
            this.dtpDate.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txtUSugar, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBp, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTemp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(33, 180);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(707, 59);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // txtUSugar
            // 
            this.txtUSugar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUSugar.Location = new System.Drawing.Point(346, 19);
            this.txtUSugar.Name = "txtUSugar";
            this.txtUSugar.Size = new System.Drawing.Size(104, 20);
            this.txtUSugar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(295, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "USugar";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bp";
            // 
            // txtBp
            // 
            this.txtBp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBp.Location = new System.Drawing.Point(184, 19);
            this.txtBp.Name = "txtBp";
            this.txtBp.Size = new System.Drawing.Size(105, 20);
            this.txtBp.TabIndex = 1;
            // 
            // txtTemp
            // 
            this.txtTemp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTemp.Location = new System.Drawing.Point(46, 19);
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(105, 20);
            this.txtTemp.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Temp";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtInsulin, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtBlSugar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(33, 252);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(707, 59);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(163, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Insulin";
            // 
            // txtInsulin
            // 
            this.txtInsulin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtInsulin.Location = new System.Drawing.Point(211, 19);
            this.txtInsulin.Name = "txtInsulin";
            this.txtInsulin.Size = new System.Drawing.Size(105, 20);
            this.txtInsulin.TabIndex = 2;
            // 
            // txtBlSugar
            // 
            this.txtBlSugar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBlSugar.Location = new System.Drawing.Point(59, 19);
            this.txtBlSugar.Name = "txtBlSugar";
            this.txtBlSugar.Size = new System.Drawing.Size(98, 20);
            this.txtBlSugar.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "BLSugar";
            // 
            // cmdAdmitReport
            // 
            this.cmdAdmitReport.Location = new System.Drawing.Point(167, 3);
            this.cmdAdmitReport.Name = "cmdAdmitReport";
            this.cmdAdmitReport.Size = new System.Drawing.Size(117, 25);
            this.cmdAdmitReport.TabIndex = 10;
            this.cmdAdmitReport.Text = "Generate Report";
            this.cmdAdmitReport.UseVisualStyleBackColor = true;
            this.cmdAdmitReport.Click += new System.EventHandler(this.cmdAdmitReport_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cmbName, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.cmbRx, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(33, 106);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(707, 59);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(96, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Prescription";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Rx";
            // 
            // cmbName
            // 
            this.cmbName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(175, 19);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(121, 21);
            this.cmbName.TabIndex = 3;
            this.cmbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbRx_KeyPress);
            // 
            // cmbRx
            // 
            this.cmbRx.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbRx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRx.FormattingEnabled = true;
            this.cmbRx.Location = new System.Drawing.Point(29, 19);
            this.cmbRx.Name = "cmbRx";
            this.cmbRx.Size = new System.Drawing.Size(61, 21);
            this.cmbRx.TabIndex = 1;
            this.cmbRx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbRx_KeyPress);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.cmdAdmitReport, 2, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(33, 392);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(752, 34);
            this.tableLayoutPanel5.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdCancel);
            this.panel2.Location = new System.Drawing.Point(86, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(75, 25);
            this.panel2.TabIndex = 18;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(0, 0);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 25);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdUpdate);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(77, 25);
            this.panel1.TabIndex = 18;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(0, 0);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(75, 25);
            this.cmdUpdate.TabIndex = 10;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(119, 395);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 25);
            this.cmdDelete.TabIndex = 12;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(37, 395);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 25);
            this.cmdAdd.TabIndex = 16;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // dgAdminPatient
            // 
            this.dgAdminPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAdminPatient.BackgroundColor = System.Drawing.Color.White;
            this.dgAdminPatient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgAdminPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAdminPatient.Location = new System.Drawing.Point(33, 462);
            this.dgAdminPatient.Name = "dgAdminPatient";
            this.dgAdminPatient.ReadOnly = true;
            this.dgAdminPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgAdminPatient.Size = new System.Drawing.Size(743, 219);
            this.dgAdminPatient.TabIndex = 16;
            this.dgAdminPatient.SelectionChanged += new System.EventHandler(this.dgAdminPatient_SelectionChanged);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 6;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.chk12Mid, 5, 0);
            this.tableLayoutPanel6.Controls.Add(this.chk10PM, 4, 0);
            this.tableLayoutPanel6.Controls.Add(this.chk6PM, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.chk2PM, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.chk12Noon, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.chk8AM, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(33, 317);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(707, 59);
            this.tableLayoutPanel6.TabIndex = 8;
            // 
            // chk12Mid
            // 
            this.chk12Mid.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk12Mid.AutoSize = true;
            this.chk12Mid.Location = new System.Drawing.Point(316, 21);
            this.chk12Mid.Name = "chk12Mid";
            this.chk12Mid.Size = new System.Drawing.Size(95, 17);
            this.chk12Mid.TabIndex = 19;
            this.chk12Mid.Text = "12 MIDNIGHT";
            this.chk12Mid.UseVisualStyleBackColor = true;
            // 
            // chk10PM
            // 
            this.chk10PM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk10PM.AutoSize = true;
            this.chk10PM.Location = new System.Drawing.Point(253, 21);
            this.chk10PM.Name = "chk10PM";
            this.chk10PM.Size = new System.Drawing.Size(57, 17);
            this.chk10PM.TabIndex = 18;
            this.chk10PM.Text = "10 PM";
            this.chk10PM.UseVisualStyleBackColor = true;
            // 
            // chk6PM
            // 
            this.chk6PM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk6PM.AutoSize = true;
            this.chk6PM.Location = new System.Drawing.Point(196, 21);
            this.chk6PM.Name = "chk6PM";
            this.chk6PM.Size = new System.Drawing.Size(51, 17);
            this.chk6PM.TabIndex = 17;
            this.chk6PM.Text = "6 PM";
            this.chk6PM.UseVisualStyleBackColor = true;
            // 
            // chk2PM
            // 
            this.chk2PM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk2PM.AutoSize = true;
            this.chk2PM.Location = new System.Drawing.Point(139, 21);
            this.chk2PM.Name = "chk2PM";
            this.chk2PM.Size = new System.Drawing.Size(51, 17);
            this.chk2PM.TabIndex = 16;
            this.chk2PM.Text = "2 PM";
            this.chk2PM.UseVisualStyleBackColor = true;
            // 
            // chk12Noon
            // 
            this.chk12Noon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk12Noon.AutoSize = true;
            this.chk12Noon.Location = new System.Drawing.Point(60, 21);
            this.chk12Noon.Name = "chk12Noon";
            this.chk12Noon.Size = new System.Drawing.Size(73, 17);
            this.chk12Noon.TabIndex = 15;
            this.chk12Noon.Text = "12 NOON";
            this.chk12Noon.UseVisualStyleBackColor = true;
            // 
            // chk8AM
            // 
            this.chk8AM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chk8AM.AutoSize = true;
            this.chk8AM.Location = new System.Drawing.Point(3, 21);
            this.chk8AM.Name = "chk8AM";
            this.chk8AM.Size = new System.Drawing.Size(51, 17);
            this.chk8AM.TabIndex = 14;
            this.chk8AM.Text = "8 AM";
            this.chk8AM.UseVisualStyleBackColor = true;
            // 
            // frmAdmitPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 721);
            this.Controls.Add(this.tableLayoutPanel6);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.dgAdminPatient);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdmitPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Indoor Patient Dose details";
            this.Load += new System.EventHandler(this.frmAdmitPatient_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAdminPatient)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtUSugar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtInsulin;
        private System.Windows.Forms.TextBox txtBlSugar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTemp;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button cmdAdmitReport;
        private System.Windows.Forms.TextBox txtPId;
        private System.Windows.Forms.TextBox txtPname;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbRx;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.DataGridView dgAdminPatient;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.CheckBox chk8AM;
        private System.Windows.Forms.CheckBox chk12Noon;
        private System.Windows.Forms.CheckBox chk6PM;
        private System.Windows.Forms.CheckBox chk2PM;
        private System.Windows.Forms.CheckBox chk12Mid;
        private System.Windows.Forms.CheckBox chk10PM;
    }
}