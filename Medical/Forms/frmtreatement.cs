using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medical
{
    public partial class frmtreatement : Form
    {
        bool exists = false;

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
            BindRx();
            BindComplains();
            setdatagrid();
            lblStatus.Text = "";
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

                //int nRowIndex = dgtreatment.Rows.Count - 1;
                //int nColumnIndex = 3;

                //dgtreatment.Rows[nRowIndex - 1].Selected = true;
                //dgtreatment.Rows[nRowIndex - 1].Cells[nColumnIndex].Selected = true;

                //In case if you want to scroll down as well.
                //dgtreatment.FirstDisplayedScrollingRowIndex = nRowIndex;
                //dgtreatment.FirstDisplayedScrollingRowIndex = dgtreatment.RowCount - 1;

                //lblStatus.Text = Convert.ToString(nRowIndex);
            }
            txtPname.Text = patientName;
            txtPid.Text = patientCode;
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
            txtpulse.Text = Convert.ToString(dt.Rows[0]["Pulse"]);
            txtQty.Text = Convert.ToString(dt.Rows[0]["Qty"]);
            txtRs.Text = Convert.ToString(dt.Rows[0]["RS"]);
            cmbRx.Text = Convert.ToString(dt.Rows[0]["Rx"]);
            txtTemp.Text = Convert.ToString(dt.Rows[0]["Temp"]);

            lstChiefComplain.Items.Clear();
            if (dt.Rows[0]["chiefComplainName"] != null)
            {
                string chiefComplainName = Convert.ToString(dt.Rows[0]["chiefComplainName"]);
                if (chiefComplainName.Contains(','))
                {
                    string[] lstchiefComp = chiefComplainName.Split(',');
                    foreach (string singlechiefComp in lstchiefComp)
                    {
                        lstChiefComplain.Items.Add(singlechiefComp);
                    }
                }
                else
                {
                    lstChiefComplain.Items.Add(chiefComplainName);
                }
                //lstChiefComplain.Items.Add(dt.Rows[0]["chiefComplainName"] != null ? Convert.ToString(dt.Rows[0]["chiefComplainName"]) : "");
            }
        }

        private void dgtreatment_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgtreatment.SelectedRows)
            {
                // PID,DateOfConsultancy,pname,fname,mname,lname,Sex,Age,Rx,Name,MorningDose,NoonDose,EveningDose,NoOfDay,Qty,AS1,Bp,ChipComplain,CNS,CVS,Doa,Dod,RS,pulse,Temp,FollowupDate,chiefComplainName
                txtAs.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[15].Value)) ? Convert.ToString(row.Cells[15].Value) : txtAs.Text;
                txtBp.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[16].Value)) ? Convert.ToString(row.Cells[16].Value) : txtBp.Text;
                cmbComplain.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[17].Value)) ? Convert.ToString(row.Cells[17].Value) : cmbComplain.Text;
                txtCns.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[18].Value)) ? Convert.ToString(row.Cells[18].Value) : txtCns.Text;
                txtCvs.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[19].Value)) ? Convert.ToString(row.Cells[19].Value) : txtCvs.Text;
                dtpDateOfConsult.Text = Convert.ToString(row.Cells[1].Value) != "" ? Convert.ToDateTime(row.Cells[1].Value).ToShortDateString() : DateTime.Now.ToShortDateString();
                dtpDoa.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[20].Value)) ? Convert.ToString(row.Cells[20].Value) : dtpDoa.Text;
                dtpDod.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[21].Value)) ? Convert.ToString(row.Cells[21].Value) : dtpDod.Text;
                cmbEdose.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[12].Value)) ? Convert.ToString(row.Cells[12].Value) : cmbEdose.Text;
                dtpFollowupDate.Text = Convert.ToString(row.Cells[25].Value) != "" ? Convert.ToDateTime(row.Cells[25].Value).ToShortDateString() : DateTime.Now.ToShortDateString();
                cmbMdose.SelectedValue = !string.IsNullOrEmpty(Convert.ToString(row.Cells[10].Value)) ? Convert.ToString(row.Cells[10].Value) : cmbMdose.SelectedValue;
                txtNoOfDay.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[13].Value)) ? Convert.ToString(row.Cells[13].Value) : txtNoOfDay.Text;
                cmbNdose.SelectedValue = !string.IsNullOrEmpty(Convert.ToString(row.Cells[11].Value)) ? Convert.ToString(row.Cells[11].Value) : cmbNdose.SelectedValue;
                txtpulse.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[23].Value)) ? Convert.ToString(row.Cells[23].Value) : txtpulse.Text;
                txtQty.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[14].Value)) ? Convert.ToString(row.Cells[14].Value) : txtQty.Text;
                txtRs.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[22].Value)) ? Convert.ToString(row.Cells[22].Value) : txtRs.Text;
                cmbRx.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[8].Value)) ? Convert.ToString(row.Cells[8].Value) : cmbRx.Text;
                txtTemp.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[24].Value)) ? Convert.ToString(row.Cells[24].Value) : txtTemp.Text;
                cmbName.Text = !string.IsNullOrEmpty(Convert.ToString(row.Cells[9].Value)) ? Convert.ToString(row.Cells[9].Value) : cmbName.Text;

                lstChiefComplain.Items.Clear();
                if (Convert.ToString(row.Cells[26].Value) != null)
                {
                    string chiefComplainName = Convert.ToString(row.Cells[26].Value);
                    if (chiefComplainName.Contains(','))
                    {
                        string[] lstchiefComp = chiefComplainName.Split(',');
                        foreach (string singlechiefComp in lstchiefComp)
                        {
                            lstChiefComplain.Items.Add(singlechiefComp);
                        }
                    }
                    else
                    {
                        lstChiefComplain.Items.Add(chiefComplainName);
                    }
                }
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

            double noofdays = (Convert.ToDouble(setDose(Convert.ToString(cmbMdose.SelectedValue))) + Convert.ToDouble(setDose(Convert.ToString(cmbNdose.SelectedValue))) + Convert.ToDouble(setDose(Convert.ToString(cmbEdose.SelectedValue))));

            txtQty.Text = Convert.ToString(days * noofdays);
        }

        private string setDose(string dose)
        {
            string s = "0";
            if (dose != "[0, 0]" && !string.IsNullOrEmpty(dose))
            {
                s = dose;
                if (Convert.ToString(s) == "")
                    s = "0";
                else if (Convert.ToString(s) == "1/2")
                    s = "0.5";
                else if (Convert.ToString(s) == "1-1/2")
                    s = "1.5";
            }
            return Convert.ToString(s);
        }

        private void cmbMdose_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcDose();
        }

        private void cmbNdose_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcDose();
        }

        private void cmbEdose_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcDose();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            SetButtons(false);
            if (dgtreatment.Rows.Count > 0)
            {
                int nRowIndex = dgtreatment.Rows.Count - 1;
                int nColumnIndex = 3;

                dgtreatment.CurrentCell = dgtreatment.Rows[nRowIndex].Cells[1];
                dgtreatment.Rows[nRowIndex].Selected = true;
                dgtreatment.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

                //In case if you want to scroll down as well.
                dgtreatment.FirstDisplayedScrollingRowIndex = nRowIndex;

                dtpDateOfConsult.Text = DateTime.Now.ToShortDateString();
                txtPid.Text = patientCode;
                txtBp.Focus();
                exists = false;
            }
            lblStatus.Text = "Add record";
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            SetButtons(false);
            exists = true;
            lblStatus.Text = "Edit record";
        }

        private void cmddelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgtreatment.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                    {
                        List<OleDbParameter> param = new List<OleDbParameter>();
                        param.Add(new OleDbParameter("@Pid", row.Cells[0].Value));
                        param.Add(new OleDbParameter("@DateOfConsultancy", Convert.ToDateTime(row.Cells[1].Value).ToShortDateString()));
                        Operation.ExecuteNonQuery("delete from treatement where Pid=@Pid and DateOfConsultancy=@DateOfConsultancy", param);
                    }
                }
            }
            setdatagrid();
        }

        private void cmdrefresh_Click(object sender, EventArgs e)
        {
            setdatagrid();
        }

        private void cmdclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SetButtons(true);
            RefMedicines();
            setdatagrid();
        }

        private void cmdupdate_Click(object sender, EventArgs e)
        {
            if (exists)
            {
                // "PatientCode Already Taken";
                if (txtPid.Text != null)
                {
                    List<OleDbParameter> param = new List<OleDbParameter>();
                    param.Add(new OleDbParameter("@bp", Convert.ToString(txtBp.Text)));
                    param.Add(new OleDbParameter("@pulse", txtpulse.Text != "" ? Convert.ToInt32(txtpulse.Text) : 0));
                    param.Add(new OleDbParameter("@temp", Convert.ToString(txtTemp.Text)));
                    param.Add(new OleDbParameter("@doa", Convert.ToString(dtpDoa.Text)));
                    param.Add(new OleDbParameter("@dod", Convert.ToString(dtpDod.Text)));
                    //param.Add(new OleDbParameter("@chipComplain", Convert.ToString(cmbComplain.Text.Trim())));
                    param.Add(new OleDbParameter("@rs", Convert.ToString(txtRs.Text)));
                    param.Add(new OleDbParameter("@cvs", Convert.ToString(txtCvs.Text)));
                    param.Add(new OleDbParameter("@as1", Convert.ToString(txtAs.Text)));
                    param.Add(new OleDbParameter("@cns", Convert.ToString(txtCns.Text)));
                    param.Add(new OleDbParameter("@rx", Convert.ToString(cmbRx.Text)));
                    param.Add(new OleDbParameter("@name", Convert.ToString(cmbName.Text)));
                    param.Add(new OleDbParameter("@morningDose", Convert.ToString(cmbMdose.Text)));
                    param.Add(new OleDbParameter("@noonDose", Convert.ToString(cmbNdose.Text)));
                    param.Add(new OleDbParameter("@eveningDose", Convert.ToString(cmbEdose.Text)));
                    param.Add(new OleDbParameter("@noOfDay", Convert.ToString(txtNoOfDay.Text)));
                    param.Add(new OleDbParameter("@qty", Convert.ToString(txtQty.Text)));
                    param.Add(new OleDbParameter("@followupDate", Convert.ToString(dtpFollowupDate.Text)));
                    param.Add(new OleDbParameter("@chiefcomplainname", lstChiefComplain.Items.Count > 0 ? Convert.ToString(lstChiefComplain.Items[0]) : ""));
                    param.Add(new OleDbParameter("@Pid", Convert.ToString(txtPid.Text)));
                    param.Add(new OleDbParameter("@dateOfConsultancy", Convert.ToString(dtpDateOfConsult.Text)));
                    //Operation.ExecuteNonQuery("update treatement set Bp=@bp, Pulse=@pulse, Temp=@temp, Doa=@doa, Dod=@dod, ChipComplain-@chipComplain, RS=@rs, CVS=@cvs, AS1=@as1, CNS=@cns, Rx=@rx, Name=@name, MorningDose=@morningDose, NoonDose=@noonDose, EveningDose=@eveningDose, NoOfDay=@noOfDay, Qty=@qty, FollowupDate=@followupDate where Pid=@Pid and DateOfConsultancy=@dateOfConsultancy", param);
                    Operation.ExecuteNonQuery("update treatement set Bp=@bp, Pulse=@pulse, Temp=@temp, Doa=@doa, Dod=@dod, RS=@rs, CVS=@cvs, AS1=@as1, CNS=@cns, Rx=@rx, Name=@name, MorningDose=@morningDose, NoonDose=@noonDose, EveningDose=@eveningDose, NoOfDay=@noOfDay, Qty=@qty, FollowupDate=@followupDate, chiefComplainName=@chiefcomplainname where Pid=@Pid and DateOfConsultancy=@dateOfConsultancy", param);
                }
                else
                {
                    MessageBox.Show("Patient code not available");
                }
            }
            else
            {
                if (txtPid.Text != null)
                {
                    List<OleDbParameter> param = new List<OleDbParameter>();
                    param.Add(new OleDbParameter("@bp", Convert.ToString(txtBp.Text)));
                    param.Add(new OleDbParameter("@pulse", txtpulse.Text != "" ? Convert.ToInt32(txtpulse.Text) : 0));
                    param.Add(new OleDbParameter("@temp", Convert.ToString(txtTemp.Text)));
                    param.Add(new OleDbParameter("@doa", Convert.ToString(dtpDoa.Text)));
                    param.Add(new OleDbParameter("@dod", Convert.ToString(dtpDod.Text)));
                    //param.Add(new OleDbParameter("@chipComplain", Convert.ToString(cmbComplain.Text.Trim())));
                    param.Add(new OleDbParameter("@rs", Convert.ToString(txtRs.Text)));
                    param.Add(new OleDbParameter("@cvs", Convert.ToString(txtCvs.Text)));
                    param.Add(new OleDbParameter("@as1", Convert.ToString(txtAs.Text)));
                    param.Add(new OleDbParameter("@cns", Convert.ToString(txtCns.Text)));
                    param.Add(new OleDbParameter("@rx", Convert.ToString(cmbRx.Text)));
                    param.Add(new OleDbParameter("@name", Convert.ToString(cmbName.Text)));
                    param.Add(new OleDbParameter("@morningDose", Convert.ToString(cmbMdose.Text)));
                    param.Add(new OleDbParameter("@noonDose", Convert.ToString(cmbNdose.Text)));
                    param.Add(new OleDbParameter("@eveningDose", Convert.ToString(cmbEdose.Text)));
                    param.Add(new OleDbParameter("@noOfDay", Convert.ToString(txtNoOfDay.Text)));
                    param.Add(new OleDbParameter("@qty", Convert.ToString(txtQty.Text)));
                    param.Add(new OleDbParameter("@followupDate", Convert.ToString(dtpFollowupDate.Text)));
                    param.Add(new OleDbParameter("@chiefcomplainname", lstChiefComplain.Items.Count > 0 ? Convert.ToString(lstChiefComplain.Items[0]) : ""));
                    param.Add(new OleDbParameter("@Pid", Convert.ToString(txtPid.Text)));
                    param.Add(new OleDbParameter("@dateOfConsultancy", Convert.ToString(dtpDateOfConsult.Text)));
                    //Operation.ExecuteNonQuery("update treatement set Bp=@bp, Pulse=@pulse, Temp=@temp, Doa=@doa, Dod=@dod, ChipComplain-@chipComplain, RS=@rs, CVS=@cvs, AS1=@as1, CNS=@cns, Rx=@rx, Name=@name, MorningDose=@morningDose, NoonDose=@noonDose, EveningDose=@eveningDose, NoOfDay=@noOfDay, Qty=@qty, FollowupDate=@followupDate where Pid=@Pid and DateOfConsultancy=@dateOfConsultancy", param);
                    Operation.ExecuteNonQuery("insert into treatement (Bp,Pulse,Temp,Doa,Dod,RS,CVS,AS1,CNS,Rx,Name,MorningDose,NoonDose,EveningDose,NoOfDay,Qty,FollowupDate,chiefComplainName,Pid,DateOfConsultancy) values(@bp,@pulse,@temp,@doa,@dod,@rs,@cvs,@as1,@cns,@rx,@name,@morningDose,@noonDose,@eveningDose,@noOfDay,@qty,@followupDate,@chiefcomplainname,@Pid,@dateOfConsultancy)", param);
                }
                else
                {
                    MessageBox.Show("Patient code not available");
                }
            }

            setdatagrid();
            SetButtons(true);
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void cmdFirst_Click(object sender, EventArgs e)
        {
            if (dgtreatment.Rows.Count > 0)
                dgtreatment.CurrentCell = dgtreatment[0, 0];

            //dgtreatment.Rows[0].Selected = true;
            //dgtreatment.FirstDisplayedScrollingRowIndex = dgtreatment.Rows[0].Index;
        }

        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            //if (!dgtreatment.Rows[0].Selected)
            //{
            //    if (dgtreatment.Rows[dgtreatment.CurrentCell.RowIndex - 1] != null)
            //    {
            //        dgtreatment.CurrentCell = dgtreatment.Rows[dgtreatment.CurrentCell.RowIndex - 1].Cells[1];
            //        dgtreatment.FirstDisplayedScrollingRowIndex = dgtreatment.Rows[dgtreatment.CurrentCell.RowIndex - 1].Index;
            //    }
            //}
            //Get number of records displayed in the data grid view and subtract one to keep in line with index that starts with 0
            if (dgtreatment.Rows.Count > 0)
            {
                int numOfRows = dgtreatment.Rows.Count - 1;

                //Get current row selected
                int index = dgtreatment.SelectedRows[0].Index;

                // Determine if the previous record exists or cycle back to the last record in the set
                if (index != 0)
                {
                    //Change the selected row to next row down in the data set
                    dgtreatment.CurrentCell = dgtreatment[0, index - 1];
                }
                else
                {
                    // Select the first record of the data set
                    dgtreatment.CurrentCell = dgtreatment[0, numOfRows];
                }
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            //if (dgtreatment.CurrentCell.RowIndex + 1 < dgtreatment.Rows.Count - 1)
            //{
            //    if (dgtreatment.Rows[dgtreatment.CurrentCell.RowIndex + 1] != null)
            //    {
            //        dgtreatment.CurrentCell = dgtreatment.Rows[dgtreatment.CurrentCell.RowIndex + 1].Cells[1];
            //        dgtreatment.FirstDisplayedScrollingRowIndex = dgtreatment.Rows[dgtreatment.CurrentCell.RowIndex + 1].Index;
            //    }
            //}
            if (dgtreatment.Rows.Count > 0)
            {
                //Get number of records displayed in the data grid view and subtract one to keep in line with index that starts with 0
                int numOfRows = dgtreatment.Rows.Count - 1;

                //Get current row selected
                int index = dgtreatment.SelectedRows[0].Index;

                // Determine if the next record exists or cycle back to the first record in the set
                if (index < numOfRows)
                {
                    //Change the selected row to next row down in the data set
                    dgtreatment.CurrentCell = dgtreatment[0, index + 1];
                }
                else
                {
                    // Select the first record of the data set
                    dgtreatment.CurrentCell = dgtreatment[0, 0];
                }
            }
        }

        private void cmdLast_Click(object sender, EventArgs e)
        {
            if (dgtreatment.Rows.Count > 0)
            {
                int numOfRows = dgtreatment.Rows.Count - 1;
                dgtreatment.CurrentCell = dgtreatment[0, numOfRows];
            }

            //int nRowIndex = dgtreatment.Rows.Count - 1;
            //int nColumnIndex = 3;

            //dgtreatment.Rows[nRowIndex].Selected = true;
            //dgtreatment.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

            ////In case if you want to scroll down as well.
            //dgtreatment.FirstDisplayedScrollingRowIndex = nRowIndex;
        }

        private void frmtreatement_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to close?",
                                   "Sharada Hospital",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Information) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void cmdPrintPlain_Click(object sender, EventArgs e)
        {
            treamentPlainReceipt();
        }

        private void treamentPlainReceipt()
        {
            DataTable dt = new DataTable();
            //select * from treatement where pid=@pid and Dateofconsultancy=@dt
            dt = Operation.GetDataTable("select * from treatement where Pid ='" + patientCode + "' and DateOfConsultancy = #" + dtpDateOfConsult.Value + "#");

            if (dt.Rows.Count > 0)
            {
                var dateGroup = dt.AsEnumerable().GroupBy(x => Convert.ToString(x["chiefComplainName"])).Select(x => new dateGroupingTreatement() { chiefComplainName = x.Key, rows = x.ToList() });
                //DataView view = new DataView(dt);
                //DataTable distinctValues = view.ToTable(true, "chiefComplainName");

                var receiptHtml = "";
                //Create a byte array that will eventually hold our final PDF
                Byte[] bytes;

                //Boilerplate iTextSharp setup here
                //Create a stream that we can write to, in this case a MemoryStream
                using (var ms = new MemoryStream())
                {
                    //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
                    using (var doc = new Document(PageSize.A4, 10f, 10f, 10f, 10f))
                    {
                        //Create a writer that's bound to our PDF abstraction and our stream
                        using (var writer = PdfWriter.GetInstance(doc, ms))
                        {
                            //Open the document for writing
                            doc.Open();
                            foreach (var grouprecord in dateGroup)
                            {
                                string tablestringCart = "";
                                //Our sample HTML and CSS
                                receiptHtml = File.ReadAllText(Application.StartupPath + "\\TreamentPlain.html");

                                //foreach (var record in grouprecord.rows)
                                //{
                                receiptHtml = receiptHtml.Replace("{{PtName}}", patientName);
                                receiptHtml = receiptHtml.Replace("{{Pid}}", Convert.ToString(patientCode));
                                //receiptHtml = receiptHtml.Replace("{{Complain}}", lstChiefComplain.Items.Count > 0 ? Convert.ToString(lstChiefComplain.Items[0]) : "");
                                receiptHtml = receiptHtml.Replace("{{Complain}}", Convert.ToString(grouprecord.rows[0]["chiefComplainName"]));
                                receiptHtml = receiptHtml.Replace("{{BP}}", Convert.ToString(txtBp.Text));
                                receiptHtml = receiptHtml.Replace("{{ConsultDate}}", Convert.ToString(dtpDateOfConsult.Value.ToShortDateString()));
                                //receiptHtml = receiptHtml.Replace("{{Age}}", Convert.ToString(dt.Rows[0]["age"]));
                                //receiptHtml = receiptHtml.Replace("{{Sex}}", Convert.ToString(dt.Rows[0]["sex"]));
                                receiptHtml = receiptHtml.Replace("{{Age}}", Convert.ToString(grouprecord.rows[0]["age"]));
                                receiptHtml = receiptHtml.Replace("{{Sex}}", Convert.ToString(grouprecord.rows[0]["sex"]));
                                receiptHtml = receiptHtml.Replace("{{FollowupDate}}", Convert.ToString(dtpFollowupDate.Value.ToShortDateString()));

                                tablestringCart = tablestringCart + "<table width='100%'>";
                                //for (int i = 0; i < dt.Rows.Count; i++)
                                //{
                                foreach (var record in grouprecord.rows)
                                {
                                    string rx = Convert.ToString(record["Rx"]);
                                    string medicineName = Convert.ToString(record["Name"]);
                                    string qty = Convert.ToString(record["Qty"]);
                                    string morning = Convert.ToString(record["MorningDose"]);
                                    string noon = Convert.ToString(record["NoonDose"]);
                                    string evening = Convert.ToString(record["EveningDose"]);

                                    tablestringCart = tablestringCart + "<tr>" + "<td align='center' width='25%'>" + rx + " :</td>" + "<td align='left' width='30%'>" + medicineName + "</td><td align='center' width='45%'>( " + qty + " )</td>" + "</tr>"
                                        + "<tr><td align='center' width='25%'></td><td align='left' width='50%'>" + morning + "    -------    " + noon + "    -------    " + evening + "</td><td align='center' width='25%'></td></tr>";
                                    //}
                                }
                                tablestringCart = tablestringCart + "</table>";

                                receiptHtml = receiptHtml.Replace("{{MedicineDetails}}", tablestringCart);

                                //Create a new HTMLWorker bound to our document
                                using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
                                {
                                    //HTMLWorker doesn't read a string directly but instead needs a TextReader (which StringReader subclasses)
                                    using (var sr = new StringReader(receiptHtml))
                                    {
                                        //Parse the HTML
                                        htmlWorker.Parse(sr);
                                    }
                                    //doc.Close();
                                }
                            }
                            doc.Close();
                        }
                    }
                    //After all of the PDF "stuff" above is done and closed but **before** we
                    //close the MemoryStream, grab all of the active bytes from the stream
                    bytes = ms.ToArray();
                }

                //Now we just need to do something with those bytes.
                //Here I'm writing them to disk but if you were in ASP.Net you might Response.BinaryWrite() them.
                //You could also write the bytes to a database in a varbinary() column (but please don't) or you
                //could pass them to another function for further PDF processing.
                var pdfFile = Application.StartupPath + "\\" + "PrintPlain_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".pdf";
                File.WriteAllBytes(pdfFile, bytes);
                System.Diagnostics.Process.Start(pdfFile);
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            treamentReceipt();
        }

        private void treamentReceipt()
        {
            DataTable dt = new DataTable();
            //select * from treatement where pid=@pid and Dateofconsultancy=@dt
            dt = Operation.GetDataTable("select * from treatement where Pid ='" + patientCode + "' and DateOfConsultancy = #" + dtpDateOfConsult.Value + "#");

            if (dt.Rows.Count > 0)
            {
                var dateGroup = dt.AsEnumerable().GroupBy(x => Convert.ToString(x["chiefComplainName"])).Select(x => new dateGroupingTreatement() { chiefComplainName = x.Key, rows = x.ToList() });

                //Create a byte array that will eventually hold our final PDF
                Byte[] bytes;

                //Boilerplate iTextSharp setup here
                //Create a stream that we can write to, in this case a MemoryStream
                using (var ms = new MemoryStream())
                {
                    //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
                    using (var doc = new Document(PageSize.A4, 10f, 10f, 10f, 10f))
                    {
                        //Create a writer that's bound to our PDF abstraction and our stream
                        using (var writer = PdfWriter.GetInstance(doc, ms))
                        {
                            //Open the document for writing
                            doc.Open();
                            foreach (var grouprecord in dateGroup)
                            {
                                string tablestringCart = "";
                                //Our sample HTML and CSS
                                var receiptHtml = File.ReadAllText(Application.StartupPath + "\\Treament.html");

                                receiptHtml = receiptHtml.Replace("{{PtName}}", patientName);
                                receiptHtml = receiptHtml.Replace("{{Pid}}", Convert.ToString(patientCode));
                                receiptHtml = receiptHtml.Replace("{{Complain}}", lstChiefComplain.Items.Count > 0 ? Convert.ToString(lstChiefComplain.Items[0]) : "");
                                receiptHtml = receiptHtml.Replace("{{BP}}", Convert.ToString(txtBp.Text));
                                receiptHtml = receiptHtml.Replace("{{ConsultDate}}", Convert.ToString(dtpDateOfConsult.Value.ToShortDateString()));
                                receiptHtml = receiptHtml.Replace("{{Age}}", Convert.ToString(grouprecord.rows[0]["age"]));
                                receiptHtml = receiptHtml.Replace("{{Sex}}", Convert.ToString(grouprecord.rows[0]["sex"]));
                                receiptHtml = receiptHtml.Replace("{{FollowupDate}}", Convert.ToString(dtpFollowupDate.Value.ToShortDateString()));
                                receiptHtml = receiptHtml.Replace("{{RS}}", Convert.ToString(grouprecord.rows[0]["RS"]));
                                receiptHtml = receiptHtml.Replace("{{AS}}", Convert.ToString(grouprecord.rows[0]["AS1"]));
                                receiptHtml = receiptHtml.Replace("{{Pulse}}", Convert.ToString(grouprecord.rows[0]["Pulse"]));
                                receiptHtml = receiptHtml.Replace("{{Temp}}", Convert.ToString(grouprecord.rows[0]["Temp"]));
                                receiptHtml = receiptHtml.Replace("{{Cvs}}", Convert.ToString(grouprecord.rows[0]["CVS"]));
                                receiptHtml = receiptHtml.Replace("{{Cns}}", Convert.ToString(grouprecord.rows[0]["CNS"]));

                                tablestringCart = tablestringCart + "<table width='100%'>";
                                //for (int i = 0; i < dt.Rows.Count; i++)
                                //{
                                foreach (var record in grouprecord.rows)
                                {
                                    string rx = Convert.ToString(record["Rx"]);
                                    string medicineName = Convert.ToString(record["Name"]);
                                    string qty = Convert.ToString(record["Qty"]);
                                    string morning = Convert.ToString(record["MorningDose"]);
                                    string noon = Convert.ToString(record["NoonDose"]);
                                    string evening = Convert.ToString(record["EveningDose"]);

                                    tablestringCart = tablestringCart + "<tr>" + "<td align='center' width='25%'>" + rx + " :</td>" + "<td align='left' width='30%'>" + medicineName + "</td><td align='center' width='45%'>( " + qty + " )</td>" + "</tr>"
                                        + "<tr><td align='center' width='25%'></td><td align='left' width='50%'>" + morning + "    -------    " + noon + "    -------    " + evening + "</td><td align='center' width='25%'></td></tr>";
                                }
                                tablestringCart = tablestringCart + "</table>";

                                receiptHtml = receiptHtml.Replace("{{MedicineDetails}}", tablestringCart);

                                //Create a new HTMLWorker bound to our document
                                using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
                                {
                                    //HTMLWorker doesn't read a string directly but instead needs a TextReader (which StringReader subclasses)
                                    using (var sr = new StringReader(receiptHtml))
                                    {
                                        //Parse the HTML
                                        htmlWorker.Parse(sr);
                                    }
                                }
                            }
                            doc.Close();
                        }
                    }
                    //After all of the PDF "stuff" above is done and closed but **before** we
                    //close the MemoryStream, grab all of the active bytes from the stream
                    bytes = ms.ToArray();
                }

                //Now we just need to do something with those bytes.
                //Here I'm writing them to disk but if you were in ASP.Net you might Response.BinaryWrite() them.
                //You could also write the bytes to a database in a varbinary() column (but please don't) or you
                //could pass them to another function for further PDF processing.
                var pdfFile = Application.StartupPath + "\\" + "Plain_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".pdf";
                File.WriteAllBytes(pdfFile, bytes);
                System.Diagnostics.Process.Start(pdfFile);
            }
        }

        private void cmdAddRx_Click(object sender, EventArgs e)
        {
            if (cmbRx.Text == "")
            {
                MessageBox.Show("Write Rx value");
            }
            else
            {
                DataTable dt = new DataTable();

                dt = Operation.GetDataTable("select * from rx where RxName = '" + cmbRx.Text.Trim() + "'");
                if (dt.Rows.Count <= 0)
                {
                    List<OleDbParameter> param = new List<OleDbParameter>();
                    param.Add(new OleDbParameter("@rxName", Convert.ToString(cmbRx.Text.Trim())));
                    Operation.ExecuteNonQuery("insert into rx(RxName) values(@rxName)", param);
                }
            }
        }
    }
}


public class dateGroupingTreatement
{
    public string chiefComplainName { get; set; }
    public List<DataRow> rows { get; set; }
}