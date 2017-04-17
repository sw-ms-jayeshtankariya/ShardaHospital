using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        public string patientCode { get; set; }
        public string patientName { get; set; }
        private String connParam = ConfigurationSettings.AppSettings["dsn"];

        public frmAdmitPatient()
        {
            InitializeComponent();
        }

        private void frmAdmitPatient_Load(object sender, EventArgs e)
        {
            BindRx();
            RefMedicines();
            setdatagrid();
        }

        private void BindRx()
        {
            DataTable dt = new DataTable();

            dt = Operation.GetDataTable("select * from rx");
            if (dt.Rows.Count > 0)
            {
                cmbRx.DataSource = dt;
                cmbRx.DisplayMember = "RxName";
                cmbRx.ValueMember = "RxCode";
            }
        }

        private void RefMedicines()
        {
            DataTable dt = new DataTable();

            dt = Operation.GetDataTable("select * from medicine order by medicineName");
            if (dt.Rows.Count > 0)
            {
                cmbName.DataSource = dt;
                cmbName.DisplayMember = "MedicineName";
                cmbName.ValueMember = "MedicineCode";
            }
        }

        private void setdatagrid()
        {
            DataTable dt = new DataTable();
            //dt = Operation.GetDataTable("select * from AdmitPatient where Pid='" + patientCode + "'");
            dt = Operation.GetDataTable("SELECT t1.Id, t1.Pid, t1.PName, t1.PatientDate, t2.RxName, t3.MedicineName, t1.Temp, t1.Bp, t1.USugar, t1.BlSugar, t1.Insulin, [t1.8AM], [t1.12NOON], [t1.2PM], [t1.6PM], [t1.10PM], [t1.12MIDNIGHT] FROM ((AdmitPatient t1 LEFT JOIN Rx t2 ON t1.Rx = t2.RxCode) LEFT JOIN medicine t3 ON t1.Prescription = t3.MedicineCode) where Pid='" + patientCode + "'");

            if (dt.Rows.Count > 0)
            {
                dgAdminPatient.DataSource = dt;
                dgAdminPatient.Columns[2].HeaderText = "PatientName";
                dgAdminPatient.Columns[4].HeaderText = "Rx";
                dgAdminPatient.Columns[5].HeaderText = "Prescription";
                dgAdminPatient.Columns[11].HeaderText = "8 AM";
                dgAdminPatient.Columns[12].HeaderText = "12 NOON";
                dgAdminPatient.Columns[13].HeaderText = "2 PM";
                dgAdminPatient.Columns[14].HeaderText = "6 PM";
                dgAdminPatient.Columns[15].HeaderText = "10 PM";
                dgAdminPatient.Columns[16].HeaderText = "12 MIDNIGHT";
            }

            txtPId.Text = patientCode;
            txtPname.Text = patientName;
        }

        //private void bindTime()
        //{
        //    var fields = new Dictionary<string, string>();
        //    fields["0"] = "8 AM";
        //    fields["1"] = "12 NOON";
        //    fields["2"] = "2 PM";
        //    fields["3"] = "6 PM";
        //    fields["4"] = "10 PM";
        //    fields["5"] = "12 MIDNIGHT";

        //    cmbTime.DataSource = new BindingSource(fields, null);
        //    cmbTime.DisplayMember = "Value";
        //    cmbTime.ValueMember = "Key";
        //}

        //private void bindAdmitPatients()
        //{
        //    DataTable dt = new DataTable();
        //    dt = Operation.GetDataTable("select PatientId,Name,Remark from patient where Remark like 'admit%' or Remark like 'dis%' order by name");
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            cmbPid.Items.Add(dt.Rows[i][1] + "-" + dt.Rows[i][0]);                    
        //        }
        //        cmbPid.SelectedIndex = 0;

        //        //cmbPid.DataSource = dt;
        //        //cmbPid.DisplayMember = "PatientId";
        //        //cmbPid.ValueMember = "PatientId";
        //    }
        //}

        //private void cmdSave_Click(object sender, EventArgs e)
        //{
        //DataTable dt = new DataTable();

        //string pId = cmbPid.Text.Substring(cmbPid.Text.IndexOf('-') + 1);

        //dt = Operation.GetDataTable("select * from AdmitPatient where Pid = '" + pId + "' and PatientDate = #" + Convert.ToDateTime(dtpDate.Text.Trim()).ToShortDateString() + "# and Time = '" + Convert.ToString(cmbTime.Text.Trim()) + "'");
        //if (dt.Rows.Count <= 0)
        //{
        //    string sortOrder = "";
        //    if (cmbTime.Text.Trim() == "8 AM")
        //        sortOrder = "1";
        //    else if (cmbTime.Text.Trim() == "12 NOON")
        //        sortOrder = "2";
        //    else if (cmbTime.Text.Trim() == "2 PM")
        //        sortOrder = "3";
        //    else if (cmbTime.Text.Trim() == "6 PM")
        //        sortOrder = "4";
        //    else if (cmbTime.Text.Trim() == "10 PM")
        //        sortOrder = "5";
        //    else if (cmbTime.Text.Trim() == "12 MIDNIGHT")
        //        sortOrder = "6";

        //    List<OleDbParameter> param = new List<OleDbParameter>();
        //    param.Add(new OleDbParameter("@pid", Convert.ToString(pId)));
        //    param.Add(new OleDbParameter("@patientDate", Convert.ToDateTime(dtpDate.Text.Trim())));
        //    param.Add(new OleDbParameter("@time", Convert.ToString(cmbTime.Text.Trim())));
        //    param.Add(new OleDbParameter("@temp", Convert.ToString(txtTemp.Text)));
        //    param.Add(new OleDbParameter("@bp", Convert.ToString(txtBp.Text)));
        //    param.Add(new OleDbParameter("@uSugar", Convert.ToString(txtUSugar.Text)));
        //    param.Add(new OleDbParameter("@blSugar", Convert.ToString(txtBlSugar.Text)));
        //    param.Add(new OleDbParameter("@insulin", Convert.ToString(txtInsulin.Text)));
        //    param.Add(new OleDbParameter("@sortorder", Convert.ToString(sortOrder)));
        //    Operation.ExecuteNonQuery("insert into AdmitPatient (Pid,PatientDate,[Time],Temp,Bp,USugar,BlSugar,Insulin,SortOrder) values (@pid,@patientDate,@time,@temp,@bp,@uSugar,@blSugar,@insulin,@sortorder)", param);
        //    MessageBox.Show("Dose successfully added");
        //    cmbTime.Text = "8 AM";
        //    txtTemp.Text = "";
        //    txtBp.Text = "";
        //    txtUSugar.Text = "";
        //    txtBlSugar.Text = "";
        //    txtInsulin.Text = "";
        //}
        //else
        //{
        //    MessageBox.Show("Dose already given to patient");
        //}
        //}

        private void cmdAdmitReport_Click(object sender, EventArgs e)
        {
            if (patientCode != null && patientCode != null)
            {
                frmAdmitReport objAdmitReport = new frmAdmitReport();
                objAdmitReport.patientCode = patientCode;
                objAdmitReport.patientName = patientName;
                objAdmitReport.ShowDialog();
            }
        }

        private void dgAdminPatient_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgAdminPatient.SelectedRows)
            {
                txtPId.Text = patientCode;
                txtPname.Text = patientName;
                dtpDate.Text = Convert.ToString(row.Cells[3].Value);

                cmbRx.Text = Convert.ToString(row.Cells[4].Value);
                cmbName.Text = Convert.ToString(row.Cells[5].Value);

                txtTemp.Text = Convert.ToString(row.Cells[6].Value);
                txtBp.Text = Convert.ToString(row.Cells[7].Value);
                txtUSugar.Text = Convert.ToString(row.Cells[8].Value);
                txtBlSugar.Text = Convert.ToString(row.Cells[9].Value);
                txtInsulin.Text = Convert.ToString(row.Cells[10].Value);

                chk8AM.Checked = !string.IsNullOrEmpty(Convert.ToString(row.Cells[11].Value)) ? Convert.ToBoolean(row.Cells[11].Value) : false;
                chk12Noon.Checked = !string.IsNullOrEmpty(Convert.ToString(row.Cells[12].Value)) ? Convert.ToBoolean(row.Cells[12].Value) : false;
                chk2PM.Checked = !string.IsNullOrEmpty(Convert.ToString(row.Cells[13].Value)) ? Convert.ToBoolean(row.Cells[13].Value) : false;
                chk6PM.Checked = !string.IsNullOrEmpty(Convert.ToString(row.Cells[14].Value)) ? Convert.ToBoolean(row.Cells[14].Value) : false;
                chk10PM.Checked = !string.IsNullOrEmpty(Convert.ToString(row.Cells[15].Value)) ? Convert.ToBoolean(row.Cells[15].Value) : false;
                chk12Mid.Checked = !string.IsNullOrEmpty(Convert.ToString(row.Cells[16].Value)) ? Convert.ToBoolean(row.Cells[16].Value) : false;
            }
        }

        private void SetButtons(bool bVal)
        {
            cmdAdd.Visible = bVal;
            cmdUpdate.Visible = !(bVal);
            cmdCancel.Visible = !(bVal);
            cmdDelete.Visible = bVal;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            SetButtons(false);

            if (dgAdminPatient.Rows.Count > 0)
            {
                int nRowIndex = dgAdminPatient.Rows.Count - 1;
                int nColumnIndex = 3;

                dgAdminPatient.CurrentCell = dgAdminPatient.Rows[nRowIndex].Cells[1];
                dgAdminPatient.Rows[nRowIndex].Selected = true;
                dgAdminPatient.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

                //In case if you want to scroll down as well.
                dgAdminPatient.FirstDisplayedScrollingRowIndex = nRowIndex;
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            SetButtons(true);
            patientOperations();
            setdatagrid();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SetButtons(true);
            setdatagrid();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteIndoorPatient();
            setdatagrid();
        }

        private void DeleteIndoorPatient()
        {
            OleDbConnection con = new OleDbConnection(connParam);

            foreach (DataGridViewRow row in dgAdminPatient.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                    {
                        string rxName = Convert.ToString(row.Cells[4].Value);
                        string rxId = "";
                        if (!string.IsNullOrEmpty(rxName))
                            rxId = GetRxId(rxName);

                        string presName = Convert.ToString(row.Cells[5].Value);
                        string presId = "";
                        if (!string.IsNullOrEmpty(presName))
                            presId = GetMedicineId(presName);

                        List<OleDbParameter> param = new List<OleDbParameter>();
                        param.Add(new OleDbParameter("@patientcode", row.Cells[1].Value));
                        param.Add(new OleDbParameter("@patientdate", Convert.ToDateTime(row.Cells[3].Value).ToShortDateString()));
                        param.Add(new OleDbParameter("@rx", rxId));
                        param.Add(new OleDbParameter("@prescription", presId));
                        Operation.ExecuteNonQuery("delete from AdmitPatient where Pid=@Pid and PatientDate=@patientdate and Rx=@rx and Prescription=@prescription", param);
                    }
                }
            }
        }

        private void DeleteNewInsPt()
        {
            List<OleDbParameter> param = new List<OleDbParameter>();
            param.Add(new OleDbParameter("@patientcode", Convert.ToString(txtPId.Text)));
            param.Add(new OleDbParameter("@patientdate", Convert.ToString(dtpDate.Text.Trim())));
            param.Add(new OleDbParameter("@rx", cmbRx.SelectedValue));
            param.Add(new OleDbParameter("@prescription", cmbName.SelectedValue));
            Operation.ExecuteNonQuery("delete from AdmitPatient where Pid=@Pid and PatientDate=@patientdate and Rx=@rx and Prescription=@prescription", param);
        }

        private void SavePatient()
        {
            //string sortOrder = "";
            //if (cmbTime.Text.Trim() == "8 AM")
            //    sortOrder = "1";
            //else if (cmbTime.Text.Trim() == "12 NOON")
            //    sortOrder = "2";
            //else if (cmbTime.Text.Trim() == "2 PM")
            //    sortOrder = "3";
            //else if (cmbTime.Text.Trim() == "6 PM")
            //    sortOrder = "4";
            //else if (cmbTime.Text.Trim() == "10 PM")
            //    sortOrder = "5";
            //else if (cmbTime.Text.Trim() == "12 MIDNIGHT")
            //    sortOrder = "6";

            string rxId = "";
            if (!string.IsNullOrEmpty(cmbRx.Text.Trim()))
                rxId = GetRxId(cmbRx.Text.Trim());
            if (string.IsNullOrEmpty(rxId))
            {
                InsertRx();
                rxId = GetRxId(cmbRx.Text.Trim());
            }

            string presId = "";
            if (!string.IsNullOrEmpty(cmbName.Text.Trim()))
                presId = GetMedicineId(cmbName.Text.Trim());
            if (string.IsNullOrEmpty(presId))
            {
                InsertMedicine();
                presId = GetMedicineId(cmbName.Text.Trim());
            }

            List<OleDbParameter> param = new List<OleDbParameter>();
            param.Add(new OleDbParameter("@pid", Convert.ToString(txtPId.Text)));
            param.Add(new OleDbParameter("@pname", Convert.ToString(txtPname.Text)));
            param.Add(new OleDbParameter("@patientDate", Convert.ToDateTime(dtpDate.Text.Trim())));
            param.Add(new OleDbParameter("@temp", Convert.ToString(txtTemp.Text)));
            param.Add(new OleDbParameter("@bp", Convert.ToString(txtBp.Text)));
            param.Add(new OleDbParameter("@uSugar", Convert.ToString(txtUSugar.Text)));
            param.Add(new OleDbParameter("@blSugar", Convert.ToString(txtBlSugar.Text)));
            param.Add(new OleDbParameter("@insulin", Convert.ToString(txtInsulin.Text)));
            param.Add(new OleDbParameter("@rx", Convert.ToInt32(rxId)));
            param.Add(new OleDbParameter("@prescription", Convert.ToInt32(presId)));
            param.Add(new OleDbParameter("@8am", Convert.ToString(chk8AM.Checked)));
            param.Add(new OleDbParameter("@12noon", Convert.ToString(chk12Noon.Checked)));
            param.Add(new OleDbParameter("@2pm", Convert.ToString(chk2PM.Checked)));
            param.Add(new OleDbParameter("@6pm", Convert.ToString(chk6PM.Checked)));
            param.Add(new OleDbParameter("@10pm", Convert.ToString(chk10PM.Checked)));
            param.Add(new OleDbParameter("@12midnight", Convert.ToString(chk12Mid.Checked)));
            Operation.ExecuteNonQuery("insert into AdmitPatient (Pid,PName,PatientDate,Temp,Bp,USugar,BlSugar,Insulin,Rx,Prescription,8AM,12NOON,2PM,6PM,10PM,12MIDNIGHT) values (@pid,@pname,@patientDate,@temp,@bp,@uSugar,@blSugar,@insulin,@rx,@prescription,@8am,@12noon,@2pm,@6pm,@10pm,@12midnight)", param);
            MessageBox.Show("Dose successfully added");
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {

        }

        private string GetRxId(string rxName)
        {
            string rxId = "";

            DataTable dt = Operation.GetDataTable("select RxCode from Rx where RxName='" + rxName + "'");
            if (dt.Rows.Count > 0)
                rxId = Convert.ToString(dt.Rows[0][0]);

            return rxId;
        }

        private void InsertRx()
        {
            List<OleDbParameter> param = new List<OleDbParameter>();
            param.Add(new OleDbParameter("@rxname", Convert.ToString(cmbRx.Text.Trim())));
            Operation.ExecuteNonQuery("insert into Rx (RxName) values (@rxname)", param);
        }

        private string GetMedicineId(string medName)
        {
            string medId = "";

            DataTable dt = Operation.GetDataTable("select MedicineCode from medicine where MedicineName='" + medName + "'");
            if (dt.Rows.Count > 0)
                medId = Convert.ToString(dt.Rows[0][0]);

            return medId;
        }

        private void InsertMedicine()
        {
            List<OleDbParameter> param = new List<OleDbParameter>();
            param.Add(new OleDbParameter("@medicinename", Convert.ToString(cmbName.Text.Trim())));
            Operation.ExecuteNonQuery("insert into medicine (MedicineName) values (@medicinename)", param);
        }

        private void patientOperations()
        {
            string rx = Convert.ToString(cmbRx.SelectedValue);
            string presc = Convert.ToString(cmbName.SelectedValue);

            if (!string.IsNullOrEmpty(rx) && !string.IsNullOrEmpty(presc))
            {
                DataTable dt = new DataTable();

                dt = Operation.GetDataTable("select * from AdmitPatient where Pid = '" + patientCode + "' and PatientDate = #" + Convert.ToDateTime(dtpDate.Text.Trim()).ToShortDateString() + "# and Rx = " + cmbRx.SelectedValue + " and Prescription = " + cmbName.SelectedValue + "");
                if (dt.Rows.Count <= 0)
                {
                    SavePatient();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Dose already given to patient. Do you still want to save ?", "prjMedical", MessageBoxButtons.YesNo);
                    if (Convert.ToString(result) == "Yes")
                    {
                        DeleteNewInsPt();
                        SavePatient();
                        setdatagrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Rx or Prescription is empty !");
            }
        }

        private void cmbRx_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
    }
}
