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
    public partial class frmMain : Form
    {
        //private String connParam = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Nirav Golani Projects\Medical\Medical\bin\Debug\eyemedical.mdb";
        //OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Nirav Golani Projects\Medical\Medical\bin\Debug\eyemedical.mdb");
        private OleDbConnection bookConn;
        private OleDbCommand oleDbCmd = new OleDbCommand();
        //parameter from mdsaputra.udl
        private String connParam = ConfigurationSettings.AppSettings["dsn"];
        List<int> patientId = new List<int>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void setdatagrid()
        {
            string query = "select * from patient order by Date,srno";
            using (OleDbConnection conn = new OleDbConnection(connParam))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    if (ds != null)
                    {
                        adapter.Fill(ds);
                        grdDataGrid.DataSource = ds.Tables[0];

                        HideGridCol();
                        //grdDataGrid.Columns[0].Visible = false;
                        //grdDataGrid.Columns[11].Visible = false;
                        //grdDataGrid.Columns[12].Visible = false;
                        //grdDataGrid.Columns[13].Visible = false;
                        //grdDataGrid.Columns[14].Visible = false;
                        //grdDataGrid.Columns[15].Visible = false;
                        //grdDataGrid.Columns[16].Visible = false;
                        //grdDataGrid.Columns[17].Visible = false;
                        //grdDataGrid.Columns[18].Visible = false;
                        //grdDataGrid.Columns[19].Visible = false;
                        //grdDataGrid.Columns[20].Visible = false;
                        //grdDataGrid.Columns[21].Visible = false;
                        //grdDataGrid.Columns[22].Visible = false;
                        //grdDataGrid.Columns[23].Visible = false;
                        //grdDataGrid.Columns[24].Visible = false;
                        //grdDataGrid.Columns[25].Visible = false;
                        //grdDataGrid.Columns[26].Visible = true;
                        ////grdDataGrid.Columns[26].Width = 1000;
                        //grdDataGrid.Columns[27].Visible = false;
                        //grdDataGrid.Columns[28].Visible = false;
                        //grdDataGrid.Columns[29].Visible = false;
                        //grdDataGrid.Columns[30].Visible = false;
                        //grdDataGrid.Columns[31].Visible = false;
                        //grdDataGrid.Columns[32].Visible = false;
                        //grdDataGrid.Columns[33].Visible = false;
                        //grdDataGrid.Columns[34].Visible = false;
                        //grdDataGrid.Columns[35].Visible = false;
                        //grdDataGrid.Columns[36].Visible = false;
                        //grdDataGrid.Columns[37].Visible = false;
                        //grdDataGrid.Columns[38].Visible = false;
                        //grdDataGrid.Columns[39].Visible = false;
                        //grdDataGrid.Columns[40].Visible = false;
                        //grdDataGrid.Columns[41].Visible = false;
                        //grdDataGrid.Columns[42].Visible = false;


                        ////grdDataGrid.Columns["Name"].Width = 2000;
                        ////grdDataGrid.Columns["Age"].Width = 375;
                        ////grdDataGrid.Columns["Sex"].Width = 350;
                        ////grdDataGrid.Columns["Weight"].Width = 600;
                        ////grdDataGrid.Columns["Address"].Width = 2000;
                        //////grdDataGrid.RowHeight = 450;
                        //////grdDataGrid.Columns["Address"].WrapText = true;
                        ////grdDataGrid.Columns["Date"].Width = 1000;

                        ////grdDataGrid.Columns("Total").Width = 735;
                        ////grdDataGrid.Columns("ReceiptNo").Width = 850;
                        ////grdDataGrid.Columns("Remark").Width = 2000;
                        ////grdDataGrid.Columns("Remark").WrapText = true;

                        //int nRowIndex = grdDataGrid.Rows.Count - 1;
                        //int nColumnIndex = 3;

                        //grdDataGrid.Rows[nRowIndex].Selected = true;
                        //grdDataGrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

                        ////In case if you want to scroll down as well.
                        //grdDataGrid.FirstDisplayedScrollingRowIndex = nRowIndex;
                        ////grdDataGrid.FirstDisplayedScrollingRowIndex = grdDataGrid.RowCount - 1;

                        //lblStatus.Text = Convert.ToString(nRowIndex);
                    }
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            setdatagrid();
        }

        private void fraBill_Enter(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void grdDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int Id;
            SetButtons(false);

            if (!String.IsNullOrEmpty(Convert.ToString(grdDataGrid.Rows[e.RowIndex].Cells[0].Value)))
            {
                Id = Convert.ToInt32(grdDataGrid.Rows[e.RowIndex].Cells[0].Value);
                if (!patientId.Contains(Id))
                    patientId.Add(Id);
            }
        }

        private void SetButtons(bool bVal)
        {
            cmdAdd.Visible = bVal;
            cmdEdit.Visible = bVal;
            cmdUpdate.Visible = !(bVal);
            cmdCancel.Visible = !(bVal);
            cmdDelete.Visible = bVal;
            cmdClose.Visible = bVal;
            cmdRefresh.Visible = bVal;
            cmdNext.Enabled = bVal;
            cmdFirst.Enabled = bVal;
            cmdLast.Enabled = bVal;
            cmdPrevious.Enabled = bVal;
            cmdGetREceiptNo.Visible = bVal;
            cmdBill.Visible = bVal;
            cmdFind.Visible = bVal;
            cmdView.Visible = bVal;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SetButtons(true);
            setdatagrid();
            patientId.Clear();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(connParam);

            foreach (DataGridViewRow row in grdDataGrid.Rows)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                {
                    if (patientId != null)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) > 0 && patientId.Contains(Convert.ToInt32(row.Cells[0].Value)))
                        {
                            oleDbCmd = new OleDbCommand("update patient set SrNo=@srno, Name=@name, Age=@age, Sex=@sex, Weight=@weight, Address=@address, [Date]=@date, ReceiptNo=@receiptno, Total=@total, Remark=@remark, EndDate=@enddate where PatientId=@id", con);
                            con.Open();
                            oleDbCmd.Parameters.AddWithValue("@srno", row.Cells[1].Value);
                            oleDbCmd.Parameters.AddWithValue("@name", row.Cells[2].Value);
                            oleDbCmd.Parameters.AddWithValue("@age", row.Cells[3].Value);
                            oleDbCmd.Parameters.AddWithValue("@sex", row.Cells[4].Value);
                            oleDbCmd.Parameters.AddWithValue("@weight", row.Cells[5].Value);
                            oleDbCmd.Parameters.AddWithValue("@address", row.Cells[6].Value);
                            oleDbCmd.Parameters.AddWithValue("@date", !String.IsNullOrEmpty(Convert.ToString(row.Cells[7].Value)) ? Convert.ToDateTime(row.Cells[7].Value).ToShortDateString() : DateTime.Now.ToShortDateString());
                            oleDbCmd.Parameters.AddWithValue("@receiptno", row.Cells[8].Value);
                            oleDbCmd.Parameters.AddWithValue("@total", row.Cells[9].Value);
                            oleDbCmd.Parameters.AddWithValue("@remark", row.Cells[10].Value);
                            oleDbCmd.Parameters.AddWithValue("@enddate", !String.IsNullOrEmpty(Convert.ToString(row.Cells[26].Value)) ? Convert.ToDateTime(row.Cells[26].Value).ToShortDateString() : DateTime.Now.ToShortDateString());
                            oleDbCmd.Parameters.AddWithValue("@id", Convert.ToInt32(row.Cells[0].Value));
                            oleDbCmd.ExecuteNonQuery();
                            con.Close();
                            //MessageBox.Show("Record Updated Successfully");
                            //setdatagrid();
                            //patientId.Clear();
                        }
                    }

                    //string SqlString = "Update patient Set Name = ? where PatientId = ?";
                    //using (OleDbConnection conn = new OleDbConnection(connParam))
                    //{
                    //    using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                    //    {
                    //        cmd.CommandType = CommandType.Text;
                    //        cmd.Parameters.AddWithValue("Name", row.Cells[2].Value);
                    //        cmd.Parameters.AddWithValue("PatientId", Convert.ToInt32(row.Cells[0].Value));
                    //        conn.Open();
                    //        cmd.ExecuteNonQuery();
                    //    }
                    //}
                }
                else
                {
                    if (row.Cells[2].Value != null)
                    {
                        oleDbCmd = new OleDbCommand("insert into patient(SrNo,Name,Age,Sex,Weight,Address,[Date],ReceiptNo,Total,Remark,EndDate) values(@srno,@name,@age,@sex,@weight,@address,@date,@receiptno,@total,@remark,@enddate)", con);
                        con.Open();
                        oleDbCmd.Parameters.AddWithValue("@srno", row.Cells[1].Value);
                        oleDbCmd.Parameters.AddWithValue("@name", row.Cells[2].Value);
                        oleDbCmd.Parameters.AddWithValue("@age", row.Cells[3].Value);
                        oleDbCmd.Parameters.AddWithValue("@sex", row.Cells[4].Value);
                        oleDbCmd.Parameters.AddWithValue("@weight", row.Cells[5].Value);
                        oleDbCmd.Parameters.AddWithValue("@address", row.Cells[6].Value);
                        oleDbCmd.Parameters.AddWithValue("@date", !String.IsNullOrEmpty(Convert.ToString(row.Cells[7].Value)) ? Convert.ToDateTime(row.Cells[7].Value).ToShortDateString() : DateTime.Now.ToShortDateString());
                        oleDbCmd.Parameters.AddWithValue("@receiptno", row.Cells[8].Value);
                        oleDbCmd.Parameters.AddWithValue("@total", row.Cells[9].Value);
                        oleDbCmd.Parameters.AddWithValue("@remark", row.Cells[10].Value);
                        oleDbCmd.Parameters.AddWithValue("@enddate", !String.IsNullOrEmpty(Convert.ToString(row.Cells[26].Value)) ? Convert.ToDateTime(row.Cells[26].Value).ToShortDateString() : DateTime.Now.ToShortDateString());
                        oleDbCmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            setdatagrid();
            patientId.Clear();
            SetButtons(true);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(connParam);

            foreach (DataGridViewRow row in grdDataGrid.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    //grdDataGrid.Rows.Remove(row);
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) != 0)
                        {
                            oleDbCmd = new OleDbCommand("delete from patient where PatientId=@id", con);
                            con.Open();
                            oleDbCmd.Parameters.AddWithValue("@id", row.Cells[0].Value);
                            oleDbCmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            setdatagrid();
            patientId.Clear();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            SetButtons(false);
            setdatagrid();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            SetButtons(false);
            setdatagrid();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            setdatagrid();
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            setdatagrid();
        }

        private void cmdFirst_Click(object sender, EventArgs e)
        {
            grdDataGrid.Rows[0].Selected = true;
            grdDataGrid.FirstDisplayedScrollingRowIndex = grdDataGrid.Rows[0].Index;
        }

        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            if (!grdDataGrid.Rows[0].Selected)
            {
                if (grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex - 1] != null)
                {
                    grdDataGrid.CurrentCell = grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex - 1].Cells[1];
                    grdDataGrid.FirstDisplayedScrollingRowIndex = grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex - 1].Index;
                }
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            if (grdDataGrid.CurrentCell.RowIndex + 1 < grdDataGrid.Rows.Count - 1)
            {
                if (grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex + 1] != null)
                {
                    grdDataGrid.CurrentCell = grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex + 1].Cells[1];
                    grdDataGrid.FirstDisplayedScrollingRowIndex = grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex + 1].Index;
                }
            }
        }

        private void cmdLast_Click(object sender, EventArgs e)
        {
            int nRowIndex = grdDataGrid.Rows.Count - 1;
            int nColumnIndex = 3;

            grdDataGrid.Rows[nRowIndex].Selected = true;
            grdDataGrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

            //In case if you want to scroll down as well.
            grdDataGrid.FirstDisplayedScrollingRowIndex = nRowIndex;
        }

        private void grdDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            //if (grdDataGrid.SelectedRows.Count > 0)
            //lblStatus.Text = Convert.ToString(grdDataGrid.SelectedRows[0].Index + 1);

            if (grdDataGrid.CurrentCell != null)
                lblStatus.Text = Convert.ToString(grdDataGrid.CurrentCell.RowIndex + 1);
        }

        private void cmdBill_Click(object sender, EventArgs e)
        {
            fraBill.Visible = true;

            lblName.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[2].Value);
            lblReceiptNo.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[8].Value);
            txtCharges14.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[9].Value);
            txtDesease.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[28].Value);
            if (!string.IsNullOrEmpty(Convert.ToString(this.grdDataGrid.CurrentRow.Cells[7].Value)))
                dateFrom1.Text = Convert.ToDateTime(this.grdDataGrid.CurrentRow.Cells[7].Value).ToShortDateString();
            if (!string.IsNullOrEmpty(Convert.ToString(this.grdDataGrid.CurrentRow.Cells[26].Value)))
                dateTo1.Text = Convert.ToDateTime(this.grdDataGrid.CurrentRow.Cells[26].Value).ToShortDateString();

            txtCharges0.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[11].Value);
            txtCharges1.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[12].Value);
            txtCharges2.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[13].Value);
            txtCharges3.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[14].Value);
            txtCharges4.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[15].Value);
            txtCharges5.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[16].Value);
            txtCharges6.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[17].Value);
            txtCharges7.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[18].Value);
            txtCharges8.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[19].Value);
            txtCharges9.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[20].Value);
            txtCharges10.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[21].Value);
            txtCharges11.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[22].Value);
            txtCharges12.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[23].Value);
            txtCharges13.Text = Convert.ToString(this.grdDataGrid.CurrentRow.Cells[24].Value);
        }

        private void cmdCancelReceipt_Click(object sender, EventArgs e)
        {
            fraBill.Visible = false;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            chargecalc();
        }

        private void chargecalc()
        {
            double total = 0;
            //int i = 0;
            //string strRupeeInWord = null;
            //string strCrorer = null;
            //string strRem = null;
            //string strNum = null;
            //int l = 0;

            double box_total = Convert.ToDouble(txtCharges0.Text) +
                Convert.ToDouble(txtCharges1.Text) +
                Convert.ToDouble(txtCharges2.Text) +
                Convert.ToDouble(txtCharges3.Text) +
                Convert.ToDouble(txtCharges4.Text) +
                Convert.ToDouble(txtCharges5.Text) +
                Convert.ToDouble(txtCharges6.Text) +
                Convert.ToDouble(txtCharges7.Text) +
                Convert.ToDouble(txtCharges8.Text) +
                Convert.ToDouble(txtCharges9.Text) +
                Convert.ToDouble(txtCharges10.Text) +
                Convert.ToDouble(txtCharges11.Text) +
                Convert.ToDouble(txtCharges12.Text) +
                Convert.ToDouble(txtCharges13.Text);

            total = total + box_total;

            OleDbConnection con = new OleDbConnection(connParam);

            foreach (DataGridViewRow row in grdDataGrid.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    //grdDataGrid.Rows.Remove(row);
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) != 0)
                        {
                            oleDbCmd = new OleDbCommand("update patient set BadCharge=@badcharge, IvDripCharge=@ivdripcharge, Pint=@pint, IvSet=@ivset, ScalpVein=@scalpvein, O2Charge=@o2charge, CounsultationFee=@counsultationfee, ReCounsultationFee=@reCounsultationfee, DailyExaminationFee=@dailyexaminationfee, InjectionCharge=@injectioncharge, EcgCharge=@ecgcharge, XRayCharge=@xraycharge, CardiacMonitorCharge=@cardiacmonitorcharge, Other=@other, Total=@total where PatientId=@id", con);
                            con.Open();
                            oleDbCmd.Parameters.AddWithValue("@badcharge", txtCharges0.Text);
                            oleDbCmd.Parameters.AddWithValue("@ivdripcharge", txtCharges1.Text);
                            oleDbCmd.Parameters.AddWithValue("@pint", txtCharges2.Text);
                            oleDbCmd.Parameters.AddWithValue("@ivset", txtCharges3.Text);
                            oleDbCmd.Parameters.AddWithValue("@scalpvein", txtCharges4.Text);
                            oleDbCmd.Parameters.AddWithValue("@o2charge", txtCharges5.Text);
                            oleDbCmd.Parameters.AddWithValue("@counsultationfee", txtCharges6.Text);
                            oleDbCmd.Parameters.AddWithValue("@reCounsultationfee", txtCharges7.Text);
                            oleDbCmd.Parameters.AddWithValue("@dailyexaminationfee", txtCharges8.Text);
                            oleDbCmd.Parameters.AddWithValue("@injectioncharge", txtCharges9.Text);
                            oleDbCmd.Parameters.AddWithValue("@ecgcharge", txtCharges10.Text);
                            oleDbCmd.Parameters.AddWithValue("@xraycharge", txtCharges11.Text);
                            oleDbCmd.Parameters.AddWithValue("@cardiacmonitorcharge", txtCharges12.Text);
                            oleDbCmd.Parameters.AddWithValue("@other", txtCharges13.Text);
                            oleDbCmd.Parameters.AddWithValue("@total", Convert.ToInt32(total));
                            oleDbCmd.Parameters.AddWithValue("@id", Convert.ToInt32(row.Cells[0].Value));
                            oleDbCmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            setdatagrid();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            clearboxes();
        }

        private void clearboxes()
        {
            txtCharges0.Text = Convert.ToString(0);
            txtCharges1.Text = Convert.ToString(0);
            txtCharges2.Text = Convert.ToString(0);
            txtCharges3.Text = Convert.ToString(0);
            txtCharges4.Text = Convert.ToString(0);
            txtCharges5.Text = Convert.ToString(0);
            txtCharges6.Text = Convert.ToString(0);
            txtCharges7.Text = Convert.ToString(0);
            txtCharges8.Text = Convert.ToString(0);
            txtCharges9.Text = Convert.ToString(0);
            txtCharges10.Text = Convert.ToString(0);
            txtCharges11.Text = Convert.ToString(0);
            txtCharges12.Text = Convert.ToString(0);
            txtCharges13.Text = Convert.ToString(0);
        }

        private void cmdAdmit_Click(object sender, EventArgs e)
        {
            string query = "select * from patient where Remark like 'admit%' or Remark like 'dis%' order by name";
            using (OleDbConnection conn = new OleDbConnection(connParam))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    if (ds != null)
                    {
                        adapter.Fill(ds);
                        grdDataGrid.DataSource = ds.Tables[0];

                        HideGridCol();
                    }
                }
            }
        }

        private void HideGridCol()
        {
            grdDataGrid.Columns[0].Visible = false;
            grdDataGrid.Columns[11].Visible = false;
            grdDataGrid.Columns[12].Visible = false;
            grdDataGrid.Columns[13].Visible = false;
            grdDataGrid.Columns[14].Visible = false;
            grdDataGrid.Columns[15].Visible = false;
            grdDataGrid.Columns[16].Visible = false;
            grdDataGrid.Columns[17].Visible = false;
            grdDataGrid.Columns[18].Visible = false;
            grdDataGrid.Columns[19].Visible = false;
            grdDataGrid.Columns[20].Visible = false;
            grdDataGrid.Columns[21].Visible = false;
            grdDataGrid.Columns[22].Visible = false;
            grdDataGrid.Columns[23].Visible = false;
            grdDataGrid.Columns[24].Visible = false;
            grdDataGrid.Columns[25].Visible = false;
            grdDataGrid.Columns[26].Visible = true;
            grdDataGrid.Columns[27].Visible = false;
            grdDataGrid.Columns[28].Visible = false;
            grdDataGrid.Columns[29].Visible = false;
            grdDataGrid.Columns[30].Visible = false;
            grdDataGrid.Columns[31].Visible = false;
            grdDataGrid.Columns[32].Visible = false;
            grdDataGrid.Columns[33].Visible = false;
            grdDataGrid.Columns[34].Visible = false;
            grdDataGrid.Columns[35].Visible = false;
            grdDataGrid.Columns[36].Visible = false;
            grdDataGrid.Columns[37].Visible = false;
            grdDataGrid.Columns[38].Visible = false;
            grdDataGrid.Columns[39].Visible = false;
            grdDataGrid.Columns[40].Visible = false;
            grdDataGrid.Columns[41].Visible = false;
            grdDataGrid.Columns[42].Visible = false;

            int nRowIndex = grdDataGrid.Rows.Count - 1;
            int nColumnIndex = 3;

            grdDataGrid.Rows[nRowIndex].Selected = true;
            grdDataGrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

            //In case if you want to scroll down as well.
            grdDataGrid.FirstDisplayedScrollingRowIndex = nRowIndex;
            //grdDataGrid.FirstDisplayedScrollingRowIndex = grdDataGrid.RowCount - 1;

            lblStatus.Text = Convert.ToString(nRowIndex);
        }

        private void cmdWritePresction_Click(object sender, EventArgs e)
        {
            if (grdDataGrid.CurrentCell != null)
            {
                string patientName = Convert.ToString(grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex].Cells[2].Value);

                frmPatientMaster objPatientMaster = new frmPatientMaster();
                objPatientMaster.patientName = patientName;
                objPatientMaster.ShowDialog();
            }
        }

        private void cmdSerial_Click(object sender, EventArgs e)
        {
            string query = "";
            frmSerial objSerial = new frmSerial();
            objSerial.ShowDialog();
            string fromDate = "";

            if (objSerial.fromDate != null)
                fromDate = Convert.ToDateTime(objSerial.fromDate).ToShortDateString();

            if (fromDate != "1/1/0001")
            {
                query = "select * from patient where [Date] = #" + fromDate + "# order by PatientId";
                if (query != "")
                {
                    OleDbConnection con = new OleDbConnection(connParam);
                    using (OleDbConnection conn = new OleDbConnection(connParam))
                    {
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                        {
                            DataSet ds = new DataSet();
                            if (ds != null)
                            {
                                adapter.Fill(ds);
                                int no = 1;
                                foreach (DataRow drRow in ds.Tables[0].Rows)
                                {
                                    if (!String.IsNullOrEmpty(Convert.ToString(drRow["SrNo"])))
                                    {
                                        oleDbCmd = new OleDbCommand("update patient set SrNo=@srno where PatientId=@id", con);
                                        con.Open();
                                        oleDbCmd.Parameters.AddWithValue("@srno", no);
                                        oleDbCmd.Parameters.AddWithValue("@id", Convert.ToInt32(drRow["PatientId"]));
                                        oleDbCmd.ExecuteNonQuery();
                                        con.Close();
                                        no++;
                                    }
                                }
                            }
                            setdatagrid();
                        }
                    }
                }
            }
        }


        private void cmdFind_Click(object sender, EventArgs e)
        {
            string query = "";
            frmDate objDate = new frmDate();
            //objPatientMaster.patientName = patientName;
            objDate.ShowDialog();
            string fromDate = "";
            string toDate = "";
            string recNo = "";
            string ptName = "";

            if (objDate.fromDate != null)
                fromDate = Convert.ToDateTime(objDate.fromDate).ToShortDateString();
            if (objDate.toDate != null)
                toDate = Convert.ToDateTime(objDate.toDate).ToShortDateString();
            if (objDate.receptNo != null)
                recNo = Convert.ToString(objDate.receptNo);
            if (objDate.patientName != null)
                ptName = Convert.ToString(objDate.patientName);

            if (!string.IsNullOrEmpty(recNo) && fromDate != "1/1/0001" && toDate != "1/1/0001")
            {
                query = "select * from patient where ReceiptNo like '" + recNo.Trim() + "%' and [Date] between #" + fromDate + "# and #" + toDate + "#";
            }
            else if (fromDate != "1/1/0001" && toDate != "1/1/0001")
            {
                query = "select * from patient where [Date] between #" + fromDate + "# and #" + toDate + "#";
            }
            else if (!string.IsNullOrEmpty(recNo))
            {
                query = "select * from patient where ReceiptNo like '" + recNo.Trim() + "%'";
            }
            else if (!string.IsNullOrEmpty(ptName))
            {
                query = "select * from patient where Name like '" + ptName.Trim() + "%'";
            }
            
            if (query != "")
            {
                using (OleDbConnection conn = new OleDbConnection(connParam))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                    {
                        DataSet ds = new DataSet();
                        if (ds != null)
                        {
                            adapter.Fill(ds);
                            grdDataGrid.DataSource = ds.Tables[0];

                            HideGridCol();
                        }
                    }
                }
            }
            //else
            //{
            //    MessageBox.Show("Record is not found");
            //}
        }
    }
}
