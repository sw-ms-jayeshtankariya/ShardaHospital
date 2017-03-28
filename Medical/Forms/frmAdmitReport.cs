using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medical
{
    public partial class frmAdmitReport : Form
    {
        public frmAdmitReport()
        {
            InitializeComponent();
        }

        private void frmAdmitReport_Load(object sender, EventArgs e)
        {
            bindTime();
            bindAdmitPatients();
            bindPatientDeases();
        }

        private void bindTime()
        {
            dateFrom.Value = DateTime.Now.Subtract(new TimeSpan(365, 0, 0, 0));
        }

        private void bindAdmitPatients()
        {
            DataTable dt = new DataTable();

            dt = Operation.GetDataTable("select PatientId,Name,Remark from patient where Remark like 'admit%' or Remark like 'dis%' order by name");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbPatient.Items.Add(dt.Rows[i][1] + "-" + dt.Rows[i][0]);
                }
                cmbPatient.SelectedIndex = 0;

                //cmbPatient.DataSource = dt;
                //cmbPatient.DisplayMember = "Name";
                //cmbPatient.ValueMember = "PatientId";
            }
        }

        private void bindPatientDeases()
        {
            lstDeases.Items.Add("Temp");
            lstDeases.Items.Add("Bp");
            lstDeases.Items.Add("USugar");
            lstDeases.Items.Add("BlSugar");
            lstDeases.Items.Add("Insulin");
        }

        private void cmdAdmitReport_Click(object sender, EventArgs e)
        {
            string query = "";
            string fromDate = "";
            string toDate = "";
            //string recNo = "";
            string ptId = "";

            fromDate = Convert.ToDateTime(dateFrom.Value).ToShortDateString();
            toDate = Convert.ToDateTime(dateTo.Value).ToShortDateString();
            //ptId = Convert.ToString(cmbPatient.SelectedValue);
            ptId = cmbPatient.Text.Substring(cmbPatient.Text.IndexOf('-') + 1);

            if (!string.IsNullOrEmpty(ptId))
                query = "select PatientDate,Time,Temp,Bp,USugar,BlSugar,Insulin,SortOrder from AdmitPatient where Pid = '" + ptId.Trim() + "' and PatientDate between #" + fromDate + "# and #" + toDate + "#";

            if (query != "")
            {
                DataTable dt = new DataTable();
                dt = Operation.GetDataTable(query);

                if (dt.Rows.Count > 0)
                    ExportPatientInfoToPdf(dt);
                else
                    MessageBox.Show("Dose not found");
            }
        }

        public void ExportPatientInfoToPdf(DataTable dt)
        {
            var pdfFile = Application.StartupPath + "\\" + "IndoorPatient_" + Convert.ToString(cmbPatient.SelectedItem.ToString()) + "-" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".pdf";

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFile, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 7);

            int tblColCount = 7 + lstDeases.SelectedItems.Count;

            PdfPTable table = new PdfPTable(tblColCount);

            //float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f };

            //table.SetWidths(widths);

            table.WidthPercentage = 100;

            PdfPCell cell = new PdfPCell(new Phrase("Indoor patient - " + Convert.ToString(cmbPatient.SelectedItem.ToString()) + " - " + DateTime.Now.ToShortDateString()));

            cell.Colspan = tblColCount;
            cell.HorizontalAlignment = 1;
            cell.BorderWidth = 0;
            cell.PaddingBottom = 10;

            table.AddCell(cell);

            table.AddCell(new Phrase("DATE", font5));
            table.AddCell(new Phrase("8 AM", font5));
            table.AddCell(new Phrase("12 NOON", font5));
            table.AddCell(new Phrase("2 PM", font5));
            table.AddCell(new Phrase("6 PM", font5));
            table.AddCell(new Phrase("10 PM", font5));
            table.AddCell(new Phrase("12 MIDNIGHT", font5));
            foreach (string deases in lstDeases.SelectedItems)
            {
                table.AddCell(new Phrase(deases, font5));
            }

            DataView view = new DataView(dt);
            DataTable distinctDates = view.ToTable(true, "PatientDate");
            var orderedRows = from row in distinctDates.AsEnumerable()
                              orderby row.Field<DateTime>("PatientDate")
                              select row;
            distinctDates = orderedRows.CopyToDataTable();

            foreach (DataRow drDate in distinctDates.Rows)
            {
                var SelectedDates = dt.AsEnumerable().Where(x => Convert.ToString(x["PatientDate"]) == Convert.ToString(drDate["PatientDate"])).Select(s => s.Field<string>("Time")).ToArray();
                string commaSeperatedDates = string.Join(",", SelectedDates);

                table.AddCell(new Phrase(Convert.ToDateTime(drDate["PatientDate"]).ToShortDateString(), font5));
                table.AddCell(new Phrase(commaSeperatedDates.Contains("8 AM") ? "YES" : "", font5));
                table.AddCell(new Phrase(commaSeperatedDates.Contains("12 NOON") ? "YES" : "", font5));
                table.AddCell(new Phrase(commaSeperatedDates.Contains("2 PM") ? "YES" : "", font5));
                table.AddCell(new Phrase(commaSeperatedDates.Contains("6 PM") ? "YES" : "", font5));
                table.AddCell(new Phrase(commaSeperatedDates.Contains("10 PM") ? "YES" : "", font5));
                table.AddCell(new Phrase(commaSeperatedDates.Contains("12 MIDNIGHT") ? "YES" : "", font5));

                foreach (string deases in lstDeases.SelectedItems)
                {
                    SelectedDates = dt.AsEnumerable().OrderBy(s => s.Field<string>("SortOrder")).Where(x => Convert.ToString(x["PatientDate"]) == Convert.ToString(drDate["PatientDate"]))
                        .Select(s => s.Field<string>(deases))
                        .Where(s => !string.IsNullOrEmpty(s)).ToArray();
                    commaSeperatedDates = string.Join(",", SelectedDates);
                    string lastWord = commaSeperatedDates.Split(',').Last();
                    table.AddCell(new Phrase(Convert.ToString(lastWord), font5));
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
