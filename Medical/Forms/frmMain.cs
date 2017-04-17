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
using System.Diagnostics;

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
            if (grdDataGrid.Rows.Count > 0)
                grdDataGrid.CurrentCell = grdDataGrid.Rows[grdDataGrid.Rows.Count - 2].Cells[1];
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
            //setdatagrid();
            patientId.Clear();
            SetButtons(true);
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in grdDataGrid.SelectedRows)
            //{
            //    if (!row.IsNewRow)
            //    {
            //        if (!String.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
            //        {
            //            if (Convert.ToInt32(row.Cells[0].Value) != 0)
            //            {
            if (grdDataGrid.CurrentCell != null)
            {
                int ptId = Convert.ToInt32(grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex].Cells[0].Value);
                if (!String.IsNullOrEmpty(Convert.ToString(ptId)))
                {
                    if (Convert.ToInt32(ptId) != 0)
                    {
                        List<OleDbParameter> param = new List<OleDbParameter>();
                        param.Add(new OleDbParameter("@id", ptId));
                        Operation.ExecuteNonQuery("delete from patient where PatientId=@id", param);
                    }
                }
            }
            //}
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
            //setdatagrid();
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

        private void ShowRowCount()
        {
            if (grdDataGrid.CurrentCell != null)
                lblStatus.Text = Convert.ToString(grdDataGrid.CurrentCell.RowIndex + 1);
        }

        private void cmdFirst_Click(object sender, EventArgs e)
        {
            grdDataGrid.CurrentCell = grdDataGrid.Rows[0].Cells[1];
            grdDataGrid.Rows[0].Selected = true;
            grdDataGrid.FirstDisplayedScrollingRowIndex = grdDataGrid.Rows[0].Index;
            ShowRowCount();
        }

        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            if (!grdDataGrid.Rows[0].Selected)
            {
                if (grdDataGrid.CurrentCell.RowIndex > 0 && grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex - 1] != null)
                {
                    grdDataGrid.CurrentCell = grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex - 1].Cells[1];
                    if (grdDataGrid.CurrentCell.RowIndex > 0)
                        grdDataGrid.FirstDisplayedScrollingRowIndex = grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex - 1].Index;
                    ShowRowCount();
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
                    if (grdDataGrid.CurrentCell.RowIndex > 0)
                        grdDataGrid.FirstDisplayedScrollingRowIndex = grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex - 1].Index;
                    ShowRowCount();
                }
            }
        }

        private void cmdLast_Click(object sender, EventArgs e)
        {
            int nRowIndex = grdDataGrid.Rows.Count - 2;
            int nColumnIndex = 3;

            grdDataGrid.CurrentCell = grdDataGrid.Rows[nRowIndex].Cells[1];
            grdDataGrid.Rows[nRowIndex].Selected = true;
            grdDataGrid.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

            //In case if you want to scroll down as well.
            grdDataGrid.FirstDisplayedScrollingRowIndex = nRowIndex;
            ShowRowCount();
        }

        private void grdDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            ShowRowCount();

            if (fraBill.Visible && gbPrint.Visible)
                ShowBillValues();
        }

        private void cmdBill_Click(object sender, EventArgs e)
        {
            fraBill.Visible = true;
            gbPrint.Visible = true;

            ShowBillValues();
        }

        private void ShowBillValues()
        {
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
            gbPrint.Visible = false;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            double total = chargecalc();
            generateReceipt(total);
            setdatagrid();
        }

        private void generateReceipt(double total)
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

                        receiptHtml = receiptHtml.Replace("{{Name}}", Convert.ToString(lblName.Text));
                        receiptHtml = receiptHtml.Replace("{{Total}}", Convert.ToString(total));
                        receiptHtml = receiptHtml.Replace("{{FromDate}}", Convert.ToString(dateFrom1.Text));
                        receiptHtml = receiptHtml.Replace("{{ToDate}}", Convert.ToString(dateTo1.Text));
                        if (txtDesease.Text != null)
                            receiptHtml = receiptHtml.Replace("{{Disease}}", Convert.ToString(txtDesease.Text));
                        else
                            receiptHtml = receiptHtml.Replace("{{Disease}}", "");
                        TimeSpan diff = Convert.ToDateTime(dateTo1.Text) - Convert.ToDateTime(dateFrom1.Text);
                        int days = Convert.ToInt32(diff.TotalDays);
                        if (days > 0)
                            receiptHtml = receiptHtml.Replace("{{Days}}", Convert.ToString(days));
                        else
                            receiptHtml = receiptHtml.Replace("{{Days}}", "0");
                        receiptHtml = receiptHtml.Replace("{{Counsultation}}", Convert.ToString(txtCharges6.Text));
                        receiptHtml = receiptHtml.Replace("{{ReCounsultation}}", Convert.ToString(txtCharges7.Text));
                        receiptHtml = receiptHtml.Replace("{{Operation}}", Convert.ToString(txtCharges8.Text));
                        receiptHtml = receiptHtml.Replace("{{OperationTheatre}}", Convert.ToString(txtCharges9.Text));
                        receiptHtml = receiptHtml.Replace("{{Anaethesia}}", Convert.ToString(txtCharges10.Text));
                        receiptHtml = receiptHtml.Replace("{{Dressing}}", Convert.ToString(txtCharges11.Text));
                        receiptHtml = receiptHtml.Replace("{{Other}}", Convert.ToString(txtCharges13.Text));
                        receiptHtml = receiptHtml.Replace("{{Scan}}", Convert.ToString(txtCharges5.Text));
                        receiptHtml = receiptHtml.Replace("{{Medicine}}", Convert.ToString(txtCharges12.Text));
                        receiptHtml = receiptHtml.Replace("{{TodayDate}}", Convert.ToString(DateTime.Now.ToShortDateString()));
                        //receiptHtml = receiptHtml.Replace("{{ToDate}}", Convert.ToString(dateTo1.Text));

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
            var pdfFile = Application.StartupPath + "\\" + "Receipt_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".pdf";
            File.WriteAllBytes(pdfFile, bytes);
            System.Diagnostics.Process.Start(pdfFile);
        }

        private double chargecalc()
        {
            int number;
            double total = 0;

            double box_total = (int.TryParse(txtCharges0.Text, out number) ? Convert.ToDouble(txtCharges0.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges1.Text, out number) ? Convert.ToDouble(txtCharges1.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges2.Text, out number) ? Convert.ToDouble(txtCharges2.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges3.Text, out number) ? Convert.ToDouble(txtCharges3.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges4.Text, out number) ? Convert.ToDouble(txtCharges4.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges5.Text, out number) ? Convert.ToDouble(txtCharges5.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges6.Text, out number) ? Convert.ToDouble(txtCharges6.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges7.Text, out number) ? Convert.ToDouble(txtCharges7.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges8.Text, out number) ? Convert.ToDouble(txtCharges8.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges9.Text, out number) ? Convert.ToDouble(txtCharges9.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges10.Text, out number) ? Convert.ToDouble(txtCharges10.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges11.Text, out number) ? Convert.ToDouble(txtCharges11.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges12.Text, out number) ? Convert.ToDouble(txtCharges12.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges13.Text, out number) ? Convert.ToDouble(txtCharges13.Text) : Convert.ToDouble(0));

            total = total + box_total;

            //foreach (DataGridViewRow row in grdDataGrid.SelectedRows)
            //{
            //    if (!row.IsNewRow)
            //    {
            //grdDataGrid.Rows.Remove(row);
            if (grdDataGrid.CurrentCell != null)
            {
                string patientId = Convert.ToString(grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex].Cells[0].Value);
                if (!String.IsNullOrEmpty(patientId))
                {
                    if (Convert.ToInt32(patientId) != 0)
                    {
                        List<OleDbParameter> param = new List<OleDbParameter>();
                        param.Add(new OleDbParameter("@badcharge", int.TryParse(txtCharges0.Text, out number) ? Convert.ToDouble(txtCharges0.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@ivdripcharge", int.TryParse(txtCharges1.Text, out number) ? Convert.ToDouble(txtCharges1.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@pint", int.TryParse(txtCharges2.Text, out number) ? Convert.ToDouble(txtCharges2.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@ivset", int.TryParse(txtCharges3.Text, out number) ? Convert.ToDouble(txtCharges3.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@scalpvein", int.TryParse(txtCharges4.Text, out number) ? Convert.ToDouble(txtCharges4.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@o2charge", int.TryParse(txtCharges5.Text, out number) ? Convert.ToDouble(txtCharges5.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@counsultationfee", int.TryParse(txtCharges6.Text, out number) ? Convert.ToDouble(txtCharges6.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@reCounsultationfee", int.TryParse(txtCharges7.Text, out number) ? Convert.ToDouble(txtCharges7.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@dailyexaminationfee", int.TryParse(txtCharges8.Text, out number) ? Convert.ToDouble(txtCharges8.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@injectioncharge", int.TryParse(txtCharges9.Text, out number) ? Convert.ToDouble(txtCharges9.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@ecgcharge", int.TryParse(txtCharges10.Text, out number) ? Convert.ToDouble(txtCharges10.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@xraycharge", int.TryParse(txtCharges11.Text, out number) ? Convert.ToDouble(txtCharges11.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@cardiacmonitorcharge", int.TryParse(txtCharges12.Text, out number) ? Convert.ToDouble(txtCharges12.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@other", int.TryParse(txtCharges13.Text, out number) ? Convert.ToDouble(txtCharges13.Text) : Convert.ToDouble(0)));
                        param.Add(new OleDbParameter("@total", Convert.ToInt32(total)));
                        param.Add(new OleDbParameter("@enddate", Convert.ToDateTime(dateTo1.Text).ToShortDateString()));
                        param.Add(new OleDbParameter("@desease", Convert.ToString(txtDesease.Text)));
                        param.Add(new OleDbParameter("@id", Convert.ToInt32(patientId)));
                        Operation.ExecuteNonQuery("update patient set BadCharge=@badcharge, IvDripCharge=@ivdripcharge, Pint=@pint, IvSet=@ivset, ScalpVein=@scalpvein, O2Charge=@o2charge, CounsultationFee=@counsultationfee, ReCounsultationFee=@reCounsultationfee, DailyExaminationFee=@dailyexaminationfee, InjectionCharge=@injectioncharge, EcgCharge=@ecgcharge, XRayCharge=@xraycharge, CardiacMonitorCharge=@cardiacmonitorcharge, Other=@other, Total=@total, EndDate=@enddate, Desease=@desease where PatientId=@id", param);
                    }
                }
            }
            //}

            return total;
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

            grdDataGrid.CurrentCell = grdDataGrid.Rows[nRowIndex - 1].Cells[1];
            grdDataGrid.Rows[nRowIndex - 1].Selected = true;
            grdDataGrid.Rows[nRowIndex - 1].Cells[nColumnIndex].Selected = true;

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
            else if (!string.IsNullOrEmpty(ptName) && fromDate != "1/1/0001" && toDate != "1/1/0001")
            {
                query = "select * from patient where Name like '" + ptName.Trim() + "%' and [Date] between #" + fromDate + "# and #" + toDate + "#";
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
                //grdDataGrid.DataSource = Operation.GetDataTable(query);
                DataTable dt = new DataTable();
                dt = Operation.GetDataTable(query);

                if (dt.Rows.Count > 0)
                {
                    grdDataGrid.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Record is not found");
                }
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
                if (grdDataGrid.CurrentCell != null)
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex].Cells[0].Value)))
                    {
                        grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex].Cells[8].Value = Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1;

                        int Id = Convert.ToInt32(grdDataGrid.Rows[grdDataGrid.CurrentCell.RowIndex].Cells[0].Value);
                        if (!patientId.Contains(Id))
                            patientId.Add(Id);
                    }
                }
                SetButtons(false);
                //foreach (DataGridViewRow row in grdDataGrid.SelectedRows)
                //{
                //    if (!row.IsNewRow)
                //    {
                //        if (!String.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                //        {
                //            if (Convert.ToInt32(row.Cells[0].Value) != 0)
                //            {
                //                row.Cells[8].Value = Convert.ToInt32(dt.Rows[0].ItemArray[0]) + 1;

                //                int Id = Convert.ToInt32(row.Cells[0].Value);
                //                if (!patientId.Contains(Id))
                //                    patientId.Add(Id);
                //            }
                //        }
                //    }
                //    break;
                //}
                //SetButtons(false);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Do you want to close?",
            //                       "Sharada Hospital",
            //                        MessageBoxButtons.YesNo,
            //                        MessageBoxIcon.Information) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void cmdPatient_Click(object sender, EventArgs e)
        {
            string query = "";
            frmSearch objSearch = new frmSearch();
            objSearch.ShowDialog();
            string fromDate = "";
            string toDate = "";
            string recNo = "";
            string ptName = "";
            DataTable dt = new DataTable();

            if (objSearch.fromDate != null)
                fromDate = Convert.ToDateTime(objSearch.fromDate).ToShortDateString();
            if (objSearch.toDate != null)
                toDate = Convert.ToDateTime(objSearch.toDate).ToShortDateString();
            if (objSearch.receptNo != null)
                recNo = Convert.ToString(objSearch.receptNo);
            if (objSearch.patientName != null)
                ptName = Convert.ToString(objSearch.patientName);

            if (!string.IsNullOrEmpty(recNo) && fromDate != "1/1/0001" && toDate != "1/1/0001")
            {
                query = "select SrNo,Name,Address,Total,ReceiptNo,Remark,EndDate from patient where ReceiptNo like '" + recNo.Trim() + "%' and [Date] between #" + fromDate + "# and #" + toDate + "#";
            }
            else if (!string.IsNullOrEmpty(ptName) && fromDate != "1/1/0001" && toDate != "1/1/0001")
            {
                query = "select SrNo,Name,Address,Total,ReceiptNo,Remark,EndDate from patient where Name like '" + ptName.Trim() + "%' and [Date] between #" + fromDate + "# and #" + toDate + "#";
            }
            else if (fromDate != "1/1/0001" && toDate != "1/1/0001")
            {
                query = "select SrNo,Name,Address,Total,ReceiptNo,Remark,EndDate from patient where [Date] between #" + fromDate + "# and #" + toDate + "#";
            }
            else if (!string.IsNullOrEmpty(recNo))
            {
                query = "select SrNo,Name,Address,Total,ReceiptNo,Remark,EndDate from patient where ReceiptNo like '" + recNo.Trim() + "%'";
            }
            else if (!string.IsNullOrEmpty(ptName))
            {
                query = "select SrNo,Name,Address,Total,ReceiptNo,Remark,EndDate from patient where Name like '" + ptName.Trim() + "%'";
            }

            if (query != "")
            {
                dt = Operation.GetDataTable(query);
                if (dt.Rows.Count > 0)
                    ExportPatientInfoToPdf(dt);
            }
        }

        public void ExportPatientInfoToPdf(DataTable dt)
        {
            var pdfFile = Application.StartupPath + "\\" + "PatientInfo_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".pdf";

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFile, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 7);

            PdfPTable table = new PdfPTable(dt.Columns.Count);

            float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f, 4f, 4f };

            table.SetWidths(widths);

            table.WidthPercentage = 100;

            PdfPCell cell = new PdfPCell(new Phrase("Patient Daily Report - " + DateTime.Now.ToShortDateString()));

            cell.Colspan = dt.Columns.Count;
            cell.HorizontalAlignment = 1;
            cell.BorderWidth = 0;
            cell.PaddingBottom = 10;

            table.AddCell(cell);
            foreach (DataColumn c in dt.Columns)
            {
                table.AddCell(new Phrase(c.ColumnName, font5));
            }

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {
                    table.AddCell(new Phrase(Convert.ToString(r[0]), font5));
                    table.AddCell(new Phrase(Convert.ToString(r[1]), font5));
                    table.AddCell(new Phrase(Convert.ToString(r[2]), font5));
                    table.AddCell(new Phrase(Convert.ToString(r[3]), font5));
                    table.AddCell(new Phrase(Convert.ToString(r[4]), font5));
                    table.AddCell(new Phrase(Convert.ToString(r[5]), font5));
                    //table.AddCell(new Phrase(r[6].ToString(), font5));
                    table.AddCell(new Phrase(Convert.ToString(r[6]) != "" ? Convert.ToDateTime(r[6].ToString()).ToShortDateString() : "", font5));
                }
            }
            document.Add(table);
            document.Close();
            ShowPdf(pdfFile);
        }

        public void ShowPdf(string filename)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;

            startInfo.FileName = filename;
            process.Start();
        }

        private void cmdBillReport_Click(object sender, EventArgs e)
        {
            frmBillReport objBillReport = new frmBillReport();
            objBillReport.ShowDialog();
            string query = "";
            string fromDate = "";
            string toDate = "";

            DataTable dt = new DataTable();

            if (objBillReport.fromDate != null)
                fromDate = Convert.ToDateTime(objBillReport.fromDate).ToShortDateString();
            if (objBillReport.toDate != null)
                toDate = Convert.ToDateTime(objBillReport.toDate).ToShortDateString();

            if (fromDate != "1/1/0001" && toDate != "1/1/0001")
            {
                query = "select SrNo,Name,Address,Total,ReceiptNo,Remark,Date from patient where [Date] between #" + fromDate + "# and #" + toDate + "# order by Date,SrNo";
            }

            if (query != "")
            {
                dt = Operation.GetDataTable(query);
                ExportPatientDailyReportToPdf(dt);
            }
        }

        public void ExportPatientDailyReportToPdf(DataTable dt)
        {
            var pdfFile = Application.StartupPath + "\\" + "BillReport_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".pdf";

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFile, FileMode.Create));
            // calling PDFFooter class to Include in document
            //writer.PageEvent = new PDFFooter();

            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 7);

            PdfPTable table = new PdfPTable(dt.Columns.Count);

            float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f, 4f, 4f };

            table.SetWidths(widths);

            table.WidthPercentage = 100;

            //PdfPCell cell = new PdfPCell(new Phrase("Patient Daily Report - " + DateTime.Now.ToShortDateString()));

            //cell.Colspan = dt.Columns.Count;
            //cell.HorizontalAlignment = 1;

            //table.AddCell(cell);
            //foreach (DataColumn c in dt.Columns)
            //{
            //    table.AddCell(new Phrase(c.ColumnName, font5));
            //}

            //document.Add(table);
            double finalTotal = 0.00;
            var dateGroup = dt.AsEnumerable().GroupBy(x => Convert.ToDateTime(x["Date"])).Select(x => new dateGrouping() { date = x.Key, rows = x.ToList() });
            foreach (var grouprecord in dateGroup)
            {
                PdfPCell cell = new PdfPCell(new Phrase("Patient Daily Report - " + grouprecord.date.ToShortDateString()));
                cell.Colspan = dt.Columns.Count;
                cell.HorizontalAlignment = 1;
                cell.BorderWidth = 0;
                cell.PaddingBottom = 10;
                table.AddCell(cell);
                int total = 0;
                foreach (DataColumn c in dt.Columns)
                {
                    table.AddCell(new Phrase(c.ColumnName, font5));
                }

                foreach (var record in grouprecord.rows)
                {
                    table.AddCell(new Phrase(Convert.ToString(record[0]), font5));
                    table.AddCell(new Phrase(Convert.ToString(record[1]), font5));
                    table.AddCell(new Phrase(Convert.ToString(record[2]), font5));
                    table.AddCell(new Phrase(Convert.ToString(record[3]), font5));
                    table.AddCell(new Phrase(Convert.ToString(record[4]), font5));
                    table.AddCell(new Phrase(Convert.ToString(record[5]), font5));
                    table.AddCell(new Phrase(Convert.ToString(record[6]) != "" ? Convert.ToDateTime(record[6].ToString()).ToShortDateString() : "", font5));
                    total += Convert.ToInt32(Convert.ToString(record[3]) != "" ? record[3] : 0);
                }

                var redListTextFont = FontFactory.GetFont(FontFactory.HELVETICA, 16, BaseColor.BLUE);
                var descriptionChunk = new Chunk("Total - " + total, redListTextFont);
                var phrase = new Phrase(descriptionChunk);
                cell = new PdfPCell(phrase);
                //cell = new PdfPCell(new Phrase("Total - " + total));
                cell.Colspan = dt.Columns.Count;
                cell.HorizontalAlignment = 1;
                cell.BorderWidth = 0;
                table.AddCell(cell);
                document.Add(table);
                document.NewPage();
                table = new PdfPTable(dt.Columns.Count);
                widths = new float[] { 4f, 4f, 4f, 4f, 4f, 4f, 4f };
                table.SetWidths(widths);
                table.WidthPercentage = 100;
                finalTotal += total;
            }

            PdfPCell lastcell = new PdfPCell(new Phrase("Patient Daily Report"));
            lastcell.Colspan = dt.Columns.Count;
            lastcell.HorizontalAlignment = 1;
            lastcell.BorderWidth = 0;
            lastcell.PaddingBottom = 10;
            table.AddCell(lastcell);

            var blueListTextFont = FontFactory.GetFont(FontFactory.HELVETICA, 16, BaseColor.BLUE);
            var footerChunk = new Chunk("GrossTotal - " + finalTotal, blueListTextFont);
            var phraseFooter = new Phrase(footerChunk);
            lastcell = new PdfPCell(phraseFooter);
            lastcell.Colspan = dt.Columns.Count;
            lastcell.HorizontalAlignment = 1;
            lastcell.BorderWidth = 0;
            table.AddCell(lastcell);

            document.Add(table);
            document.NewPage();
            //foreach (DataRow r in dt.Rows)
            //{
            //    if (Convert.ToString(r["Date"]) != date)
            //    {
            //        document.Add(table);
            //        document.NewPage();
            //        table = new PdfPTable(dt.Columns.Count);
            //        widths = new float[] { 4f, 4f, 4f, 4f, 4f, 4f, 4f };
            //        table.SetWidths(widths);
            //        table.WidthPercentage = 100;
            //    }
            //    table.AddCell(new Phrase(Convert.ToString(r[0]), font5));
            //    table.AddCell(new Phrase(Convert.ToString(r[1]), font5));
            //    table.AddCell(new Phrase(Convert.ToString(r[2]), font5));
            //    table.AddCell(new Phrase(Convert.ToString(r[3]), font5));
            //    table.AddCell(new Phrase(Convert.ToString(r[4]), font5));
            //    table.AddCell(new Phrase(Convert.ToString(r[5]), font5));
            //    table.AddCell(new Phrase(Convert.ToString(r[6]) != "" ? Convert.ToDateTime(r[6].ToString()).ToShortDateString() : "", font5));
            //    if (Convert.ToString(r["Date"]) != date)
            //    {
            //        date = Convert.ToString(r["Date"]);
            //        document.Add(table);
            //    }
            //    if (string.IsNullOrEmpty(date))
            //    {
            //        date = Convert.ToString(r["Date"]);
            //    }
            //}

            document.Close();
            ShowPdf(pdfFile);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure ?", "prjMedical", MessageBoxButtons.YesNo);
            if (Convert.ToString(result) == "Yes")
            {
                string fileName = "eyemedical.mdb";
                string targetPath = @"C:\eye_doctor";
                string sourcePath = @"N:\";

                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);

                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath))
                    System.IO.Directory.CreateDirectory(targetPath);

                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                if (System.IO.Directory.Exists(sourcePath))
                    System.IO.File.Copy(sourceFile, destFile, true);
                else
                    MessageBox.Show("Source Path not exists");
            }
        }

        private void cmdSaveTo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure ?", "prjMedical", MessageBoxButtons.YesNo);
            if (Convert.ToString(result) == "Yes")
            {
                string fileName = "eyemedical.mdb";
                string fileName1 = "eyemedical1.mdb";
                string sourcePath = @"C:\doctor";
                string targetPath = @"N:\";

                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                string destFile1 = System.IO.Path.Combine(targetPath, fileName1);

                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath))
                    System.IO.Directory.CreateDirectory(targetPath);

                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                if (System.IO.Directory.Exists(sourcePath))
                {
                    System.IO.File.Copy(sourceFile, destFile1, true);
                    System.IO.File.Copy(sourceFile, destFile, true);
                }
                else
                    MessageBox.Show("Source Path not exists");
            }
        }

        private void cmdWritePresction_Click_1(object sender, EventArgs e)
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

        private void cmdIndoorPatients_Click(object sender, EventArgs e)
        {
            frmAdmitPatient objAdmitPatient = new frmAdmitPatient();
            objAdmitPatient.ShowDialog();
        }

        private void txtDispayCalc_Leave(object sender, EventArgs e)
        {
            DisplayCalc();
        }

        private void DisplayCalc()
        {
            int number;
            double total = 0;

            double box_total = (int.TryParse(txtCharges0.Text, out number) ? Convert.ToDouble(txtCharges0.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges1.Text, out number) ? Convert.ToDouble(txtCharges1.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges2.Text, out number) ? Convert.ToDouble(txtCharges2.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges3.Text, out number) ? Convert.ToDouble(txtCharges3.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges4.Text, out number) ? Convert.ToDouble(txtCharges4.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges5.Text, out number) ? Convert.ToDouble(txtCharges5.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges6.Text, out number) ? Convert.ToDouble(txtCharges6.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges7.Text, out number) ? Convert.ToDouble(txtCharges7.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges8.Text, out number) ? Convert.ToDouble(txtCharges8.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges9.Text, out number) ? Convert.ToDouble(txtCharges9.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges10.Text, out number) ? Convert.ToDouble(txtCharges10.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges11.Text, out number) ? Convert.ToDouble(txtCharges11.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges12.Text, out number) ? Convert.ToDouble(txtCharges12.Text) : Convert.ToDouble(0)) +
                (int.TryParse(txtCharges13.Text, out number) ? Convert.ToDouble(txtCharges13.Text) : Convert.ToDouble(0));

            total = total + box_total;

            txtCharges14.Text = Convert.ToString(total);
        }
    }
}

public class dateGrouping
{
    public DateTime date { get; set; }
    public List<DataRow> rows { get; set; }
}

//public class PDFFooter : PdfPageEventHelper
//{
//    // write on top of document
//    iTextSharp.text.Font FONT = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);

//    public override void OnEndPage(PdfWriter writer, Document document)
//    {
//        PdfContentByte canvas = writer.DirectContent;
//        ColumnText.ShowTextAligned(
//          canvas, Element.ALIGN_CENTER,
//          new Phrase("Header - ", FONT), 300, 810, 0
//        );
//        ColumnText.ShowTextAligned(
//          canvas, Element.ALIGN_MIDDLE,
//          new Phrase("Footer", FONT), 10, 10, 0
//        );
//    }
//}
