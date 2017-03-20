using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
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

            dt = Operation.GetDataTable("select * from patient where Remark like 'admit%' or Remark like 'dis%' order by name");
            if (dt.Rows.Count > 0)
            {
                cmbPid.DataSource = dt;
                cmbPid.DisplayMember = "PatientId";
                cmbPid.ValueMember = "PatientId";
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = Operation.GetDataTable("select * from AdmitPatient where Pid = '" + cmbPid.Text.Trim() + "'");
            if (dt.Rows.Count <= 0)
            {
                List<OleDbParameter> param = new List<OleDbParameter>();
                param.Add(new OleDbParameter("@pid", Convert.ToString(cmbPid.Text.Trim())));
                param.Add(new OleDbParameter("@patientDate", Convert.ToDateTime(dtpDate.Text.Trim())));
                param.Add(new OleDbParameter("@time", Convert.ToString(cmbTime.Text.Trim())));
                param.Add(new OleDbParameter("@temp", Convert.ToString(txtTemp.Text)));
                param.Add(new OleDbParameter("@bp", Convert.ToString(txtBp.Text)));
                param.Add(new OleDbParameter("@uSugar", Convert.ToString(txtUSugar.Text)));
                param.Add(new OleDbParameter("@blSugar", Convert.ToString(txtBlSugar.Text)));
                param.Add(new OleDbParameter("@insulin", Convert.ToString(txtInsulin.Text)));
                Operation.ExecuteNonQuery("insert into AdmitPatient (Pid,PatientDate,[Time],Temp,Bp,USugar,BlSugar,Insulin) values (@pid,@patientDate,@time,@temp,@bp,@uSugar,@blSugar,@insulin)", param);
            }
            else
            {
                MessageBox.Show("Patient already admitted");
            }
        }
    }
}
