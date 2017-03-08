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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Medical
{
    public partial class frmMain : Form
    {
        //private String connParam = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Nirav Golani Projects\Medical\Medical\bin\Debug\eyemedical.mdb";
        //OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Nirav Golani Projects\Medical\Medical\bin\Debug\eyemedical.mdb");
        private OleDbConnection bookConn;
        private OleDbCommand oleDbCmd = new OleDbCommand();
        //private string connParam = "";
        //parameter from mdsaputra.udl

        List<int> patientId = new List<int>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void setdatagrid()
        {
            grdDataGrid.DataSource = Operation.GetDataTable("select * from patient order by Date,srno");

            HideGridCol();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            setdatagrid();
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
            foreach (DataGridViewRow row in grdDataGrid.Rows)
            {
                if (!String.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                {
                    if (patientId != null)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) > 0 && patientId.Contains(Convert.ToInt32(row.Cells[0].Value)))
                        {
                            List<OleDbParameter> param = new List<OleDbParameter>();
                            param.Add(new OleDbParameter("@srno", row.Cells[1].Value));
                            param.Add(new OleDbParameter("@name", row.Cells[2].Value));
                            param.Add(new OleDbParameter("@age", row.Cells[3].Value));
                            param.Add(new OleDbParameter("@sex", row.Cells[4].Value));
                            param.Add(new OleDbParameter("@weight", row.Cells[5].Value));
                            param.Add(new OleDbParameter("@address", row.Cells[6].Value));
                            param.Add(new OleDbParameter("@date", !String.IsNullOrEmpty(Convert.ToString(row.Cells[7].Value)) ? Convert.ToDateTime(row.Cells[7].Value).ToShortDateString() : DateTime.Now.ToShortDateString()));
                            param.Add(new OleDbParameter("@receiptno", row.Cells[8].Value));
                            param.Add(new OleDbParameter("@total", row.Cells[9].Value));
                            param.Add(new OleDbParameter("@remark", row.Cells[10].Value));
                            param.Add(new OleDbParameter("@enddate", !String.IsNullOrEmpty(Convert.ToString(row.Cells[26].Value)) ? Convert.ToDateTime(row.Cells[26].Value).ToShortDateString() : DateTime.Now.ToShortDateString()));
                            param.Add(new OleDbParameter("@id", Convert.ToInt32(row.Cells[0].Value)));
                            Operation.ExecuteNonQuery("update patient set SrNo=@srno, Name=@name, Age=@age, Sex=@sex, Weight=@weight, Address=@address, [Date]=@date, ReceiptNo=@receiptno, Total=@total, Remark=@remark, EndDate=@enddate where PatientId=@id", param);
                        }
                    }
                }
                else
                {
                    if (row.Cells[2].Value != null)
                    {
                        List<OleDbParameter> param = new List<OleDbParameter>();
                        param.Add(new OleDbParameter("@srno", row.Cells[1].Value));
                        param.Add(new OleDbParameter("@name", row.Cells[2].Value));
                        param.Add(new OleDbParameter("@age", row.Cells[3].Value));
                        param.Add(new OleDbParameter("@sex", row.Cells[4].Value));
                        param.Add(new OleDbParameter("@weight", row.Cells[5].Value));
                        param.Add(new OleDbParameter("@address", row.Cells[6].Value));
                        param.Add(new OleDbParameter("@date", !String.IsNullOrEmpty(Convert.ToString(row.Cells[7].Value)) ? Convert.ToDateTime(row.Cells[7].Value).ToShortDateString() : DateTime.Now.ToShortDateString()));
                        param.Add(new OleDbParameter("@receiptno", row.Cells[8].Value));
                        param.Add(new OleDbParameter("@total", row.Cells[9].Value));
                        param.Add(new OleDbParameter("@remark", row.Cells[10].Value));
                        param.Add(new OleDbParameter("@enddate", !String.IsNullOrEmpty(Convert.ToString(row.Cells[26].Value)) ? Convert.ToDateTime(row.Cells[26].Value).ToShortDateString() : DateTime.Now.ToShortDateString()));
                        Operation.ExecuteNonQuery("insert into patient(SrNo,Name,Age,Sex,Weight,Address,[Date],ReceiptNo,Total,Remark,EndDate) values(@srno,@name,@age,@sex,@weight,@address,@date,@receiptno,@total,@remark,@enddate)", param);
                    }
                }
            }
            setdatagrid();
            patientId.Clear();
            SetButtons(true);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grdDataGrid.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) != 0)
                        {
                            List<OleDbParameter> param = new List<OleDbParameter>();
                            param.Add(new OleDbParameter("@id", Convert.ToInt32(row.Cells[0].Value)));
                            Operation.ExecuteNonQuery("delete from patient where PatientId=@id", param);
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
            generateReceipt();
        }

        private void generateReceipt()
        {
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
                        //Our sample HTML and CSS
                        var receiptHtml = File.ReadAllText(Application.StartupPath + "\\Receipt.html");
                        //var receiptCss = @".headline{font-size:200%}";

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
            var pdfFile = Application.StartupPath + "\\" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".pdf";
            File.WriteAllBytes(pdfFile, bytes);
            System.Diagnostics.Process.Start(pdfFile);
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
            
            foreach (DataGridViewRow row in grdDataGrid.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    //grdDataGrid.Rows.Remove(row);
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) != 0)
                        {
                            List<OleDbParameter> param = new List<OleDbParameter>();
                            param.Add(new OleDbParameter("@badcharge", txtCharges0.Text));
                            param.Add(new OleDbParameter("@ivdripcharge", txtCharges1.Text));
                            param.Add(new OleDbParameter("@pint", txtCharges2.Text));
                            param.Add(new OleDbParameter("@ivset", txtCharges3.Text));
                            param.Add(new OleDbParameter("@scalpvein", txtCharges4.Text));
                            param.Add(new OleDbParameter("@o2charge", txtCharges5.Text));
                            param.Add(new OleDbParameter("@counsultationfee", txtCharges6.Text));
                            param.Add(new OleDbParameter("@reCounsultationfee", txtCharges7.Text));
                            param.Add(new OleDbParameter("@dailyexaminationfee", txtCharges8.Text));
                            param.Add(new OleDbParameter("@injectioncharge", txtCharges9.Text));
                            param.Add(new OleDbParameter("@ecgcharge", txtCharges10.Text));
                            param.Add(new OleDbParameter("@xraycharge", txtCharges11.Text));
                            param.Add(new OleDbParameter("@cardiacmonitorcharge", txtCharges12.Text));
                            param.Add(new OleDbParameter("@other", txtCharges13.Text));
                            param.Add(new OleDbParameter("@total", Convert.ToInt32(total)));
                            param.Add(new OleDbParameter("@id", Convert.ToInt32(row.Cells[0].Value)));
                            Operation.ExecuteNonQuery("update patient set BadCharge=@badcharge, IvDripCharge=@ivdripcharge, Pint=@pint, IvSet=@ivset, ScalpVein=@scalpvein, O2Charge=@o2charge, CounsultationFee=@counsultationfee, ReCounsultationFee=@reCounsultationfee, DailyExaminationFee=@dailyexaminationfee, InjectionCharge=@injectioncharge, EcgCharge=@ecgcharge, XRayCharge=@xraycharge, CardiacMonitorCharge=@cardiacmonitorcharge, Other=@other, Total=@total where PatientId=@id", param);
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
            grdDataGrid.DataSource = Operation.GetDataTable("select * from patient where Remark like 'admit%' or Remark like 'dis%' order by name");
            HideGridCol();
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
                string patientAddress = Convert.ToString(grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex].Cells[6].Value);
                string patientAge = Convert.ToString(grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex].Cells[3].Value);
                string patientSex = Convert.ToString(grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex].Cells[4].Value);

                frmPatientMaster objPatientMaster = new frmPatientMaster();
                objPatientMaster.patientName = patientName;
                objPatientMaster.patientAddress = patientAddress;
                objPatientMaster.patientAge = patientAge;
                objPatientMaster.patientSex = patientSex;
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
                    DataTable dt = new DataTable();
                    dt = Operation.GetDataTable(query);
                    if (dt != null)
                    {
                        int no = 1;
                        foreach (DataRow drRow in dt.Rows)
                        {
                            if (!String.IsNullOrEmpty(Convert.ToString(drRow["SrNo"])))
                            {
                                List<OleDbParameter> param = new List<OleDbParameter>();
                                param.Add(new OleDbParameter("@srno", no));
                                param.Add(new OleDbParameter("@id", Convert.ToInt32(drRow["PatientId"])));
                                Operation.ExecuteNonQuery("update patient set SrNo=@srno where PatientId=@id", param);
                                no++;
                            }
                        }
                    }
                    setdatagrid();

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
                grdDataGrid.DataSource = Operation.GetDataTable(query);
                HideGridCol();
            }
            //else
            //{
            //    MessageBox.Show("Record is not found");
            //}
        }

        private void cmdGetREceiptNo_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = Operation.GetDataTable("select max(ReceiptNo) from patient");

            if (dt.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in grdDataGrid.SelectedRows)
                {
                    if (!row.IsNewRow)
                    {
                        if (!String.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                        {
                            if (Convert.ToInt32(row.Cells[0].Value) != 0)
                            {
                                row.Cells[8].Value = Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1;

                                int Id = Convert.ToInt32(row.Cells[0].Value);
                                if (!patientId.Contains(Id))
                                    patientId.Add(Id);
                            }
                        }
                    }
                    break;
                }
                SetButtons(false);
            }
        }
    }
}
