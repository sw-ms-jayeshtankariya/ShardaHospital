namespace Medical
{
    partial class frmFind
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
            this.fraSelectOption = new System.Windows.Forms.GroupBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.cmbFind = new System.Windows.Forms.ComboBox();
            this.optByName = new System.Windows.Forms.RadioButton();
            this.cmdReturn = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.dgPatient = new System.Windows.Forms.DataGridView();
            this.fraSelectOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // fraSelectOption
            // 
            this.fraSelectOption.Controls.Add(this.txtCode);
            this.fraSelectOption.Controls.Add(this.cmbFind);
            this.fraSelectOption.Controls.Add(this.optByName);
            this.fraSelectOption.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraSelectOption.Location = new System.Drawing.Point(35, 25);
            this.fraSelectOption.Name = "fraSelectOption";
            this.fraSelectOption.Size = new System.Drawing.Size(510, 65);
            this.fraSelectOption.TabIndex = 4;
            this.fraSelectOption.TabStop = false;
            this.fraSelectOption.Text = "Find";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(282, 20);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(201, 23);
            this.txtCode.TabIndex = 2;
            // 
            // cmbFind
            // 
            this.cmbFind.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFind.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFind.FormattingEnabled = true;
            this.cmbFind.Location = new System.Drawing.Point(148, 21);
            this.cmbFind.Name = "cmbFind";
            this.cmbFind.Size = new System.Drawing.Size(103, 23);
            this.cmbFind.TabIndex = 1;
            // 
            // optByName
            // 
            this.optByName.AutoSize = true;
            this.optByName.Checked = true;
            this.optByName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optByName.Location = new System.Drawing.Point(17, 25);
            this.optByName.Name = "optByName";
            this.optByName.Size = new System.Drawing.Size(113, 18);
            this.optByName.TabIndex = 0;
            this.optByName.TabStop = true;
            this.optByName.Text = "By Patinet Name";
            this.optByName.UseVisualStyleBackColor = true;
            this.optByName.CheckedChanged += new System.EventHandler(this.optByName_CheckedChanged);
            // 
            // cmdReturn
            // 
            this.cmdReturn.Location = new System.Drawing.Point(264, 108);
            this.cmdReturn.Name = "cmdReturn";
            this.cmdReturn.Size = new System.Drawing.Size(75, 25);
            this.cmdReturn.TabIndex = 9;
            this.cmdReturn.Text = "Return";
            this.cmdReturn.UseVisualStyleBackColor = true;
            this.cmdReturn.Click += new System.EventHandler(this.cmdReturn_Click);
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(183, 108);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 25);
            this.cmdOk.TabIndex = 8;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // dgPatient
            // 
            this.dgPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPatient.BackgroundColor = System.Drawing.Color.White;
            this.dgPatient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatient.Location = new System.Drawing.Point(35, 175);
            this.dgPatient.Name = "dgPatient";
            this.dgPatient.ReadOnly = true;
            this.dgPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPatient.Size = new System.Drawing.Size(510, 219);
            this.dgPatient.TabIndex = 16;
            this.dgPatient.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPatient_CellDoubleClick);
            // 
            // frmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 424);
            this.Controls.Add(this.dgPatient);
            this.Controls.Add(this.cmdReturn);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.fraSelectOption);
            this.Name = "frmFind";
            this.Text = "frmFind";
            this.Load += new System.EventHandler(this.frmFind_Load);
            this.fraSelectOption.ResumeLayout(false);
            this.fraSelectOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox fraSelectOption;
        private System.Windows.Forms.RadioButton optByName;
        private System.Windows.Forms.ComboBox cmbFind;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button cmdReturn;
        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.DataGridView dgPatient;
    }
}