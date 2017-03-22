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

        private void cmdAdmitReport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = Operation.GetDataTable("select PatientDate,Time,Temp,Bp,USugar,BlSugar,Insulin from AdmitPatient where Pid = '" + cmbPid.Text.Trim() + "'");

            if (dt.Rows.Count > 0)
                ExportPatientInfoToPdf(dt);
        }

        public void ExportPatientInfoToPdf(DataTable dt)
        {
            var pdfFile = Application.StartupPath + "\\" + "IndoorPatient_" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".pdf";

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFile, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 7);

            PdfPTable table = new PdfPTable(dt.Columns.Count);

            float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f, 4f, 4f };

            table.SetWidths(widths);

            table.WidthPercentage = 100;

            PdfPCell cell = new PdfPCell(new Phrase("Indoor patient - " + DateTime.Now.ToShortDateString()));

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
                    table.AddCell(new Phrase(Convert.ToString(r[0]) != "" ? Convert.ToDateTime(r[0].ToString()).ToShortDateString() : "", font5));
                    table.AddCell(new Phrase(Convert.ToString(r[1]), font5));
                    table.AddCell(new Phrase(Convert.ToString(r[2]), font5));
                    table.AddCell(new Phrase(Convert.ToString(r[3]), font5));
                    table.AddCell(new Phrase(Convert.ToString(r[4]), font5));
                    table.AddCell(new Phrase(Convert.ToString(r[5]), font5));
                    table.AddCell(new Phrase(Convert.ToString(r[6]), font5));
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
    }
}
