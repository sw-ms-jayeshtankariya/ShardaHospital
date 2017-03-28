using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medical
{
    public partial class frmAdmitPatient : Form
    {
        public frmAdmitPatient()
        {
            InitializeComponent();
        }

        private void frmAdmitPatient_Load(object sender, EventArgs e)
        {
            bindTime();
            bindAdmitPatients();
        }

        private void bindTime()
        {
            var fields = new Dictionary<string, string>();
            fields["0"] = "8 AM";
            fields["1"] = "12 NOON";
            fields["2"] = "2 PM";
            fields["3"] = "6 PM";
            fields["4"] = "10 PM";
            fields["5"] = "12 MIDNIGHT";

            cmbTime.DataSource = new BindingSource(fields, null);
            cmbTime.DisplayMember = "Value";
            cmbTime.ValueMember = "Key";
        }

        private void bindAdmitPatients()
        {
            DataTable dt = new DataTable();
            dt = Operation.GetDataTable("select PatientId,Name,Remark from patient where Remark like 'admit%' or Remark like 'dis%' order by name");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbPid.Items.Add(dt.Rows[i][1] + "-" + dt.Rows[i][0]);                    
                }
                cmbPid.SelectedIndex = 0;

                //cmbPid.DataSource = dt;
                //cmbPid.DisplayMember = "PatientId";
                //cmbPid.ValueMember = "PatientId";
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            string pId = cmbPid.Text.Substring(cmbPid.Text.IndexOf('-') + 1);

            dt = Operation.GetDataTable("select * from AdmitPatient where Pid = '" + pId + "' and PatientDate = #" + Convert.ToDateTime(dtpDate.Text.Trim()).ToShortDateString() + "# and Time = '" + Convert.ToString(cmbTime.Text.Trim()) + "'");
            if (dt.Rows.Count <= 0)
            {
                string sortOrder = "";
                if (cmbTime.Text.Trim() == "8 AM")
                    sortOrder = "1";
                else if (cmbTime.Text.Trim() == "12 NOON")
                    sortOrder = "2";
                else if (cmbTime.Text.Trim() == "2 PM")
                    sortOrder = "3";
                else if (cmbTime.Text.Trim() == "6 PM")
                    sortOrder = "4";
                else if (cmbTime.Text.Trim() == "10 PM")
                    sortOrder = "5";
                else if (cmbTime.Text.Trim() == "12 MIDNIGHT")
                    sortOrder = "6";

                List<OleDbParameter> param = new List<OleDbParameter>();
                param.Add(new OleDbParameter("@pid", Convert.ToString(pId)));
                param.Add(new OleDbParameter("@patientDate", Convert.ToDateTime(dtpDate.Text.Trim())));
                param.Add(new OleDbParameter("@time", Convert.ToString(cmbTime.Text.Trim())));
                param.Add(new OleDbParameter("@temp", Convert.ToString(txtTemp.Text)));
                param.Add(new OleDbParameter("@bp", Convert.ToString(txtBp.Text)));
                param.Add(new OleDbParameter("@uSugar", Convert.ToString(txtUSugar.Text)));
                param.Add(new OleDbParameter("@blSugar", Convert.ToString(txtBlSugar.Text)));
                param.Add(new OleDbParameter("@insulin", Convert.ToString(txtInsulin.Text)));
                param.Add(new OleDbParameter("@sortorder", Convert.ToString(sortOrder)));
                Operation.ExecuteNonQuery("insert into AdmitPatient (Pid,PatientDate,[Time],Temp,Bp,USugar,BlSugar,Insulin,SortOrder) values (@pid,@patientDate,@time,@temp,@bp,@uSugar,@blSugar,@insulin,@sortorder)", param);
                MessageBox.Show("Dose successfully added");
                cmbTime.Text = "8 AM";
                txtTemp.Text = "";
                txtBp.Text = "";
                txtUSugar.Text = "";
                txtBlSugar.Text = "";
                txtInsulin.Text = "";
            }
            else
            {
                MessageBox.Show("Dose already given to patient");
            }
        }

        private void cmdAdmitReport_Click(object sender, EventArgs e)
        {
            frmAdmitReport objAdmitReport = new frmAdmitReport();
            objAdmitReport.ShowDialog();
        }
    }
}
