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
    public partial class frmtreatement : Form
    {
        public string patientCode { get; set; }
        public string patientName { get; set; }

        public frmtreatement()
        {
            InitializeComponent();
        }

        private void SetButtons(bool bVal)
        {
            cmdAdd.Visible = bVal;
            cmdEdit.Visible = bVal;
            cmdupdate.Visible = !(bVal);
            cmdCancel.Visible = !(bVal);
            cmddelete.Visible = bVal;
            cmdclose.Visible = bVal;
            cmdrefresh.Visible = bVal;
            cmdPrint.Visible = bVal;
            cmdPrintPlain.Visible = bVal;
            cmdNext.Enabled = bVal;
            cmdFirst.Enabled = bVal;
            cmdLast.Enabled = bVal;
            cmdPrevious.Enabled = bVal;
        }

        private void frmtreatement_Load(object sender, EventArgs e)
        {
            bindDose();
            RefMedicines();
            BindComplains();
            setdatagrid();
        }

        private void setdatagrid()
        {
            DataTable dt = new DataTable();
            dt = Operation.GetDataTable("select PID,DateOfConsultancy,pname,fname,mname,lname,Sex,Age,Rx,Name,MorningDose,NoonDose,EveningDose,NoOfDay,Qty,AS1,Bp,ChipComplain,CNS,CVS,Doa,Dod,RS,pulse,Temp,FollowupDate,chiefComplainName from treatement where pid='" + patientCode + "'");

            if (dt.Rows.Count > 0)
            {
                readData(dt);

                dgtreatment.DataSource = dt;

                dgtreatment.Columns["as1"].Visible = false;
                dgtreatment.Columns["bp"].Visible = false;
                dgtreatment.Columns["chipcomplain"].Visible = false;
                dgtreatment.Columns["cns"].Visible = false;
                dgtreatment.Columns["cvs"].Visible = false;
                dgtreatment.Columns["doa"].Visible = false;
                dgtreatment.Columns["dod"].Visible = false;
                dgtreatment.Columns["pulse"].Visible = false;
                dgtreatment.Columns["rs"].Visible = false;
                dgtreatment.Columns["temp"].Visible = false;
                dgtreatment.Columns["fname"].Visible = false;
                dgtreatment.Columns["lname"].Visible = false;
                dgtreatment.Columns["pname"].Visible = false;
                dgtreatment.Columns["mname"].Visible = false;
                dgtreatment.Columns["age"].Visible = false;
                dgtreatment.Columns["sex"].Visible = false;

                int nRowIndex = dgtreatment.Rows.Count - 1;
                //int nColumnIndex = 3;

                //dgtreatment.Rows[nRowIndex - 1].Selected = true;
                //dgtreatment.Rows[nRowIndex - 1].Cells[nColumnIndex].Selected = true;

                //In case if you want to scroll down as well.
                //dgtreatment.FirstDisplayedScrollingRowIndex = nRowIndex;
                //dgtreatment.FirstDisplayedScrollingRowIndex = dgtreatment.RowCount - 1;

                lblStatus.Text = Convert.ToString(nRowIndex);
            }
        }

        private void bindDose()
        {
            var fields = new Dictionary<string, string>();
            fields["0"] = "0";
            fields["1/2"] = "1/2";
            fields["1"] = "1";
            fields["1-1/2"] = "1-1/2";
            fields["2"] = "2";

            cmbMdose.DataSource = new BindingSource(fields, null);
            cmbMdose.DisplayMember = "Value";
            cmbMdose.ValueMember = "Key";

            cmbNdose.DataSource = new BindingSource(fields, null);
            cmbNdose.DisplayMember = "Value";
            cmbNdose.ValueMember = "Key";

            cmbEdose.DataSource = new BindingSource(fields, null);
            cmbEdose.DisplayMember = "Value";
            cmbEdose.ValueMember = "Key";
        }

        private void readData(DataTable dt)
        {
            txtPname.Text = patientName;
            txtAs.Text = Convert.ToString(dt.Rows[0]["As1"]);
            txtBp.Text = Convert.ToString(dt.Rows[0]["Bp"]);
            cmbComplain.Text = Convert.ToString(dt.Rows[0]["ChipComplain"]);
            txtCns.Text = Convert.ToString(dt.Rows[0]["CNS"]);
            txtCvs.Text = Convert.ToString(dt.Rows[0]["CVS"]);
            //dtpDateOfConsult.Text = Convert.ToDateTime(dt.Rows[0]["DateOfConsultancy"]).ToShortDateString();
            dtpDoa.Text = Convert.ToDateTime(dt.Rows[0]["Doa"]).ToShortDateString();
            dtpDod.Text = Convert.ToDateTime(dt.Rows[0]["Dod"]).ToShortDateString();
            cmbEdose.SelectedValue = Convert.ToString(dt.Rows[0]["EveningDose"]);
            //dtpFollowupDate.Text = dt.Rows[0]["FollowupDate"] != null ? Convert.ToDateTime(dt.Rows[0]["FollowupDate"]).ToShortDateString() : DateTime.Now.ToShortDateString();
            cmbMdose.SelectedValue = Convert.ToString(dt.Rows[0]["MorningDose"]);
            //cmbName.Text = Convert.ToString(dt.Rows[0]["Name"]);
            txtNoOfDay.Text = Convert.ToString(dt.Rows[0]["NoOfDay"]);
            cmbNdose.SelectedValue = Convert.ToString(dt.Rows[0]["NoonDose"]);
            txtPid.Text = Convert.ToString(dt.Rows[0]["Pid"]);
            txtpulse.Text = Convert.ToString(dt.Rows[0]["Pulse"]);
            txtQty.Text = Convert.ToString(dt.Rows[0]["Qty"]);
            txtRs.Text = Convert.ToString(dt.Rows[0]["RS"]);
            cmbRx.Text = Convert.ToString(dt.Rows[0]["Rx"]);
            txtTemp.Text = Convert.ToString(dt.Rows[0]["Temp"]);

            lstChiefComplain.Items.Clear();
            lstChiefComplain.Items.Add(dt.Rows[0]["chiefComplainName"] != null ? Convert.ToString(dt.Rows[0]["chiefComplainName"]) : "");
        }

        private void dgtreatment_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgtreatment.SelectedRows)
            {
                cmbName.Text = Convert.ToString(row.Cells[9].Value);
                dtpDateOfConsult.Text = Convert.ToString(row.Cells[1].Value) != "" ? Convert.ToDateTime(row.Cells[1].Value).ToShortDateString() : DateTime.Now.ToShortDateString();
                dtpFollowupDate.Text = Convert.ToString(row.Cells[25].Value) != "" ? Convert.ToDateTime(row.Cells[25].Value).ToShortDateString() : DateTime.Now.ToShortDateString();
            }
        }

        private void cmdAddName_Click(object sender, EventArgs e)
        {
            if (cmbName.Text == "")
            {
                MessageBox.Show("Write Medicine name");
            }
            else
            {
                DataTable dt = new DataTable();

                dt = Operation.GetDataTable("select * from medicine where MedicineName = '" + cmbName.Text.Trim() + "'");
                if (dt.Rows.Count <= 0)
                {
                    List<OleDbParameter> param = new List<OleDbParameter>();
                    param.Add(new OleDbParameter("@MedicineName", Convert.ToString(cmbName.Text.Trim())));
                    Operation.ExecuteNonQuery("insert into medicine(MedicineName) values(@MedicineName)", param);
                }
            }
        }

        private void cmdRefre_Click(object sender, EventArgs e)
        {
            RefMedicines();
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

        private void cmdComplainAdd_Click(object sender, EventArgs e)
        {
            if (cmbComplain.Text == "")
            {
                MessageBox.Show("Write Complain");
            }
            else
            {
                DataTable dt = new DataTable();

                dt = Operation.GetDataTable("select * from chipcomplain where complainName = '" + cmbComplain.Text.Trim() + "'");
                if (dt.Rows.Count <= 0)
                {
                    List<OleDbParameter> param = new List<OleDbParameter>();
                    param.Add(new OleDbParameter("@complainName", Convert.ToString(cmbComplain.Text.Trim())));
                    Operation.ExecuteNonQuery("insert into chipcomplain(complainName) values(@complainName)", param);
                }
                BindComplains();
            }
        }

        private void BindComplains()
        {
            DataTable dt = new DataTable();

            dt = Operation.GetDataTable("select * from chipcomplain");
            if (dt.Rows.Count > 0)
            {
                cmbComplain.DataSource = dt;
                cmbComplain.DisplayMember = "complainName";
                cmbComplain.ValueMember = "ChipComplainCode";
            }
        }

        private void cmbListAdd_Click(object sender, EventArgs e)
        {
            lstChiefComplain.Items.Add(cmbComplain.Text);
        }

        private void cmbListRemove_Click(object sender, EventArgs e)
        {
            if (lstChiefComplain.SelectedIndex != -1)
                lstChiefComplain.Items.RemoveAt(lstChiefComplain.SelectedIndex);
            else
                MessageBox.Show("Select Complain from the list box and then click Remove button");
        }

        private void cmbLstClear_Click(object sender, EventArgs e)
        {
            lstChiefComplain.Items.Clear();
        }

        private void txtNoOfDay_Leave(object sender, EventArgs e)
        {
            calcDose();
        }

        private void calcDose()
        {
            double days = 0.00;

            if (txtNoOfDay.Text == "")
                txtNoOfDay.Text = "1";
            else
                days = Convert.ToDouble(txtNoOfDay.Text);

            if (cmbRx.Text == "LIQ" || cmbRx.Text == "Liq")
                txtQty.Text = "1";

            double noofdays = (Convert.ToDouble(setDose(cmbMdose.Text)) + Convert.ToDouble(setDose(cmbNdose.Text)) + Convert.ToDouble(setDose(cmbEdose.Text)));

            txtQty.Text = Convert.ToString(days * noofdays);
        }

        private string setDose(string dose)
        {
            double s = 0.0;
            s = Convert.ToDouble(dose);
            if (Convert.ToString(s) == "")
                s = 0;
            else if (Convert.ToString(s) == "1/2")
                s = 0.5;
            else if (Convert.ToString(s) == "1-1/2")
                s = 1.5;
            
            return Convert.ToString(s);           
        }

        private void cmbMdose_SelectedIndexChanged(object sender, EventArgs e)
        {
            //calcDose();
        }

        private void cmbNdose_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
