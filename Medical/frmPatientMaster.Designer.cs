namespace Medical
{
    partial class frmPatientMaster
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtFields0 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCheck = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmdPfind = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtFields3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFields2 = new System.Windows.Forms.TextBox();
            this.txtFields1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFields4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFields5 = new System.Windows.Forms.TextBox();
            this.txtFields6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdFind = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdRefresh = new System.Windows.Forms.Button();
            this.cmdPrescription = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdLast = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmdPrevious = new System.Windows.Forms.Button();
            this.cmdFirst = new System.Windows.Forms.Button();
            this.dgPatientMaster = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatientMaster)).BeginInit();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.txtFields0, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdCheck, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCode, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmdPfind, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(30, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(707, 55);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtFields0
            // 
            this.txtFields0.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFields0.Location = new System.Drawing.Point(43, 17);
            this.txtFields0.Name = "txtFields0";
            this.txtFields0.Size = new System.Drawing.Size(125, 20);
            this.txtFields0.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "pid:";
            // 
            // cmdCheck
            // 
            this.cmdCheck.Location = new System.Drawing.Point(280, 3);
            this.cmdCheck.Name = "cmdCheck";
            this.cmdCheck.Size = new System.Drawing.Size(75, 42);
            this.cmdCheck.TabIndex = 3;
            this.cmdCheck.Text = "Get Patient Code";
            this.cmdCheck.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCode.Location = new System.Drawing.Point(174, 17);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtName.Location = new System.Drawing.Point(361, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(247, 20);
            this.txtName.TabIndex = 1;
            // 
            // cmdPfind
            // 
            this.cmdPfind.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmdPfind.Location = new System.Drawing.Point(614, 16);
            this.cmdPfind.Name = "cmdPfind";
            this.cmdPfind.Size = new System.Drawing.Size(75, 23);
            this.cmdPfind.TabIndex = 5;
            this.cmdPfind.Text = "Find";
            this.cmdPfind.UseVisualStyleBackColor = true;
            this.cmdPfind.Click += new System.EventHandler(this.cmdPfind_Click);
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
            this.tableLayoutPanel3.Controls.Add(this.txtFields3, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtFields2, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtFields1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(30, 92);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(707, 55);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // txtFields3
            // 
            this.txtFields3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFields3.Location = new System.Drawing.Point(585, 17);
            this.txtFields3.Name = "txtFields3";
            this.txtFields3.Size = new System.Drawing.Size(104, 20);
            this.txtFields3.TabIndex = 3;
            this.txtFields3.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(497, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Last Name";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(280, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Middle Name";
            this.label5.Visible = false;
            // 
            // txtFields2
            // 
            this.txtFields2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFields2.Location = new System.Drawing.Point(386, 17);
            this.txtFields2.Name = "txtFields2";
            this.txtFields2.Size = new System.Drawing.Size(105, 20);
            this.txtFields2.TabIndex = 2;
            this.txtFields2.Visible = false;
            // 
            // txtFields1
            // 
            this.txtFields1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFields1.Location = new System.Drawing.Point(58, 17);
            this.txtFields1.Name = "txtFields1";
            this.txtFields1.Size = new System.Drawing.Size(216, 20);
            this.txtFields1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Name";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Address";
            // 
            // txtFields4
            // 
            this.txtFields4.Location = new System.Drawing.Point(88, 179);
            this.txtFields4.Multiline = true;
            this.txtFields4.Name = "txtFields4";
            this.txtFields4.Size = new System.Drawing.Size(206, 73);
            this.txtFields4.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(325, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sex";
            // 
            // txtFields5
            // 
            this.txtFields5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFields5.Location = new System.Drawing.Point(377, 179);
            this.txtFields5.Name = "txtFields5";
            this.txtFields5.Size = new System.Drawing.Size(45, 20);
            this.txtFields5.TabIndex = 6;
            // 
            // txtFields6
            // 
            this.txtFields6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFields6.Location = new System.Drawing.Point(377, 216);
            this.txtFields6.Name = "txtFields6";
            this.txtFields6.Size = new System.Drawing.Size(45, 20);
            this.txtFields6.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(323, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Age";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmdFind, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmdDelete, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmdClose, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmdRefresh, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmdPrescription, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(16, 276);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(597, 32);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdEdit);
            this.panel2.Controls.Add(this.cmdCancel);
            this.panel2.Location = new System.Drawing.Point(86, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(75, 23);
            this.panel2.TabIndex = 18;
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(0, 0);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 23);
            this.cmdEdit.TabIndex = 17;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(0, 0);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdFind
            // 
            this.cmdFind.Location = new System.Drawing.Point(518, 3);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(75, 23);
            this.cmdFind.TabIndex = 13;
            this.cmdFind.Text = "Find";
            this.cmdFind.UseVisualStyleBackColor = true;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(167, 3);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 12;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(329, 3);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(75, 23);
            this.cmdClose.TabIndex = 13;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.Location = new System.Drawing.Point(248, 3);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(75, 23);
            this.cmdRefresh.TabIndex = 3;
            this.cmdRefresh.Text = "ViewAll";
            this.cmdRefresh.UseVisualStyleBackColor = true;
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdPrescription
            // 
            this.cmdPrescription.Location = new System.Drawing.Point(410, 3);
            this.cmdPrescription.Name = "cmdPrescription";
            this.cmdPrescription.Size = new System.Drawing.Size(102, 23);
            this.cmdPrescription.TabIndex = 14;
            this.cmdPrescription.Text = "WritePrescription";
            this.cmdPrescription.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdAdd);
            this.panel1.Controls.Add(this.cmdUpdate);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(77, 23);
            this.panel1.TabIndex = 18;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(0, 0);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 23);
            this.cmdAdd.TabIndex = 16;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(0, 0);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(75, 23);
            this.cmdUpdate.TabIndex = 10;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdLast
            // 
            this.cmdLast.Location = new System.Drawing.Point(165, 338);
            this.cmdLast.Name = "cmdLast";
            this.cmdLast.Size = new System.Drawing.Size(37, 22);
            this.cmdLast.TabIndex = 14;
            this.cmdLast.Text = ">>";
            this.cmdLast.UseVisualStyleBackColor = true;
            // 
            // cmdNext
            // 
            this.cmdNext.Location = new System.Drawing.Point(127, 337);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(32, 23);
            this.cmdNext.TabIndex = 13;
            this.cmdNext.Text = ">";
            this.cmdNext.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(85, 347);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "label1";
            // 
            // cmdPrevious
            // 
            this.cmdPrevious.Location = new System.Drawing.Point(51, 337);
            this.cmdPrevious.Name = "cmdPrevious";
            this.cmdPrevious.Size = new System.Drawing.Size(28, 23);
            this.cmdPrevious.TabIndex = 11;
            this.cmdPrevious.Text = "<";
            this.cmdPrevious.UseVisualStyleBackColor = true;
            // 
            // cmdFirst
            // 
            this.cmdFirst.Location = new System.Drawing.Point(16, 337);
            this.cmdFirst.Name = "cmdFirst";
            this.cmdFirst.Size = new System.Drawing.Size(29, 23);
            this.cmdFirst.TabIndex = 10;
            this.cmdFirst.Text = "<<";
            this.cmdFirst.UseVisualStyleBackColor = true;
            // 
            // dgPatientMaster
            // 
            this.dgPatientMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPatientMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatientMaster.Location = new System.Drawing.Point(16, 366);
            this.dgPatientMaster.Name = "dgPatientMaster";
            this.dgPatientMaster.ReadOnly = true;
            this.dgPatientMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPatientMaster.Size = new System.Drawing.Size(743, 203);
            this.dgPatientMaster.TabIndex = 15;
            this.dgPatientMaster.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgPatientMaster_RowHeaderMouseClick);
            this.dgPatientMaster.SelectionChanged += new System.EventHandler(this.dgPatientMaster_SelectionChanged);
            // 
            // frmPatientMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 588);
            this.Controls.Add(this.dgPatientMaster);
            this.Controls.Add(this.cmdLast);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmdPrevious);
            this.Controls.Add(this.cmdFirst);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.txtFields6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFields5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFields4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmPatientMaster";
            this.Text = "Enter Patient personal details";
            this.Load += new System.EventHandler(this.frmPatientMaster_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPatientMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button cmdCheck;
        private System.Windows.Forms.TextBox txtFields0;
        private System.Windows.Forms.Button cmdPfind;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtFields1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFields2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFields3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFields4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFields5;
        private System.Windows.Forms.TextBox txtFields6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button cmdRefresh;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdFind;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdPrescription;
        private System.Windows.Forms.Button cmdLast;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button cmdPrevious;
        private System.Windows.Forms.Button cmdFirst;
        private System.Windows.Forms.DataGridView dgPatientMaster;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}