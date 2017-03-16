using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;

namespace Medical
{
    public partial class frmFind : Form
    {
        public string patientId { get; set; }

        public frmFind()
        {
            InitializeComponent();
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            var fields = new Dictionary<string, string>();
            fields["PatientCode"] = "Patient Code";
            fields["fname"] = "First Name";
            fields["mname"] = "Middle Name";
            fields["lname"] = "Last Name";
            fields["Address"] = "Address";
            fields["Age"] = "Age";
            fields["Sex"] = "Sex";
            cmbFind.DataSource = new BindingSource(fields, null);
            cmbFind.DisplayMember = "Value";
            cmbFind.ValueMember = "Key";
        }

        private void optByName_CheckedChanged(object sender, EventArgs e)
        {
            if (optByName.Checked)
                cmbFind.Visible = true;
            else
                cmbFind.Visible = false;
        }

        private void cmdReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //select * from pMaster where " & Trim(cmbFind.Text) & " " & "like '" & Trim(txtCode.Text) & "%'"
            dt = Operation.GetDataTable("select * from pMaster where " + Convert.ToString(cmbFind.SelectedValue) + " like '" + txtCode.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                dgPatient.DataSource = dt;

                dgPatient.Columns[2].Visible = false;
                dgPatient.Columns[3].Visible = false;
            }
            else
            {
                MessageBox.Show("No record found");
            }
        }

        private void dgPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                patientId = Convert.ToString(dgPatient.Rows[e.RowIndex].Cells[0].Value);

                this.Close();
            }
        }
    }
}
