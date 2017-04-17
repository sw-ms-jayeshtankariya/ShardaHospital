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
        public string patientCode { get; set; }
        public string patientName { get; set; }

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

            dt = Operation.GetDataTable("select PatientCode,fname,mname,lname,Address,Sex,Age from pmaster order by fname");
            //dt = Operation.GetDataTable("select PatientId,Name,Remark from patient where Remark like 'admit%' or Remark like 'dis%' order by name");
            if (dt.Rows.Count > 0)
            {
                //cmbPatient.Items.Add("All");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmbPatient.Items.Add(dt.Rows[i][1] + "-" + dt.Rows[i][0]);
                }
                cmbPatient.Text = patientName + "-" + patientCode;
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
            if (cmbPatient.Text != "All")
                ptId = cmbPatient.Text.Substring(cmbPatient.Text.IndexOf('-') + 1);

            if (!string.IsNullOrEmpty(ptId))
                query = "select t1.PatientDate, t2.RxName, t3.MedicineName, [t1.8AM], [t1.12NOON], [t1.2PM], [t1.6PM], [t1.10PM], [t1.12MIDNIGHT], t1.Temp, t1.Bp, t1.USugar, t1.BlSugar, t1.Insulin FROM ((AdmitPatient t1 LEFT JOIN Rx t2 ON t1.Rx = t2.RxCode) LEFT JOIN medicine t3 ON t1.Prescription = t3.MedicineCode) where Pid = '" + ptId.Trim() + "' and PatientDate between #" + fromDate + "# and #" + toDate + "#";
            else
                query = "select PatientId,Name,Remark from patient where Remark like 'admit%' or Remark like 'dis%' order by name";

            if (query != "")
            {
                DataTable dt = new DataTable();
                dt = Operation.GetDataTable(query);

                if (dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(ptId))
                        ExportPatientInfoToPdf(dt);
                    else
                        ExportAllPatientInfoToPdf(dt, fromDate, toDate);
                }
                else
                    MessageBox.Show("Dose not found");
            }

            cmbPatient.SelectedIndex = 0;
        }

        public void ExportPatientInfoToPdf(DataTable dt)
        {
            var pdfFile = Application.StartupPath + "\\" + "IndoorPatient_" + Convert.ToString(cmbPatient.SelectedItem.ToString()) + "-" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".pdf";

            DataView view = new DataView(dt);
            DataTable distinctDates = view.ToTable(true, "PatientDate");
            var orderedRows = from row in distinctDates.AsEnumerable()
                              orderby row.Field<DateTime>("PatientDate")
                              select row;
            distinctDates = orderedRows.CopyToDataTable();

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFile, FileMode.Create));
            document.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 7);

            // for Image
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Application.StartupPath + "\\true.png");
            PdfPCell imageCell = new PdfPCell(img);
            imageCell.HorizontalAlignment = Element.ALIGN_CENTER;
            imageCell.VerticalAlignment = Element.ALIGN_MIDDLE;

            int tblColCount = 9 + lstDeases.SelectedItems.Count;
            foreach (DataRow drDate in distinctDates.Rows)
            {
                var Result = from x in dt.AsEnumerable()
                             where x.Field<DateTime>("PatientDate") == Convert.ToDateTime(drDate["PatientDate"])
                             select x;
                DataTable newDt = Result.CopyToDataTable();

                PdfPTable table = new PdfPTable(tblColCount);

                //float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f };

                //table.SetWidths(widths);

                table.WidthPercentage = 100;

                PdfPCell cell = new PdfPCell(new Phrase("Indoor patient - " + Convert.ToString(cmbPatient.SelectedItem.ToString()) + " - " + Convert.ToDateTime(drDate["PatientDate"]).ToShortDateString()));

                cell.Colspan = tblColCount;
                cell.HorizontalAlignment = 1;
                cell.BorderWidth = 0;
                cell.PaddingBottom = 10;

                table.AddCell(cell);

                table.AddCell(new Phrase("DATE", font5));
                table.AddCell(new Phrase("Rx", font5));
                table.AddCell(new Phrase("Medicine Name", font5));
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

                foreach (DataRow r in newDt.Rows)
                {
                    if (newDt.Rows.Count > 0)
                    {
                        table.AddCell(new Phrase(Convert.ToString(r[0]) != "" ? Convert.ToDateTime(r[0].ToString()).ToShortDateString() : "", font5));
                        table.AddCell(new Phrase(Convert.ToString(r[1]), font5));
                        table.AddCell(new Phrase(Convert.ToString(r[2]), font5));
                        if (Convert.ToString(r[3]) == "True")
                            table.AddCell(imageCell);//table.AddCell(new Phrase(Convert.ToString(r[3]), font5));
                        else
                            table.AddCell(new Phrase(" "));

                        if (Convert.ToString(r[4]) == "True")
                            table.AddCell(imageCell);//table.AddCell(new Phrase(Convert.ToString(r[4]), font5));
                        else
                            table.AddCell(new Phrase(" "));

                        if (Convert.ToString(r[5]) == "True")
                            table.AddCell(imageCell);//table.AddCell(new Phrase(Convert.ToString(r[4]), font5));
                        else
                            table.AddCell(new Phrase(" "));

                        if (Convert.ToString(r[6]) == "True")
                            table.AddCell(imageCell);//table.AddCell(new Phrase(Convert.ToString(r[4]), font5));
                        else
                            table.AddCell(new Phrase(" "));

                        if (Convert.ToString(r[7]) == "True")
                            table.AddCell(imageCell);//table.AddCell(new Phrase(Convert.ToString(r[4]), font5));
                        else
                            table.AddCell(new Phrase(" "));

                        if (Convert.ToString(r[8]) == "True")
                            table.AddCell(imageCell);//table.AddCell(new Phrase(Convert.ToString(r[4]), font5));
                        else
                            table.AddCell(new Phrase(" "));

                        //table.AddCell(new Phrase(Convert.ToString(r[5]), font5));
                        //table.AddCell(new Phrase(Convert.ToString(r[6]), font5));
                        //table.AddCell(new Phrase(Convert.ToString(r[7]), font5));
                        //table.AddCell(new Phrase(Convert.ToString(r[8]), font5));
                        
                        //var SelectedDates = dt.AsEnumerable().Where(x => Convert.ToString(x["PatientDate"]) == Convert.ToString(drDate["PatientDate"])).Select(s => s.Field<string>("Time")).ToArray();
                        //string commaSeperatedDates = string.Join(",", SelectedDates);

                        //table.AddCell(new Phrase(Convert.ToDateTime(drDate["PatientDate"]).ToShortDateString(), font5));
                        //table.AddCell(new Phrase(commaSeperatedDates.Contains("8 AM") ? "YES" : "", font5));
                        //table.AddCell(new Phrase(commaSeperatedDates.Contains("12 NOON") ? "YES" : "", font5));
                        //table.AddCell(new Phrase(commaSeperatedDates.Contains("2 PM") ? "YES" : "", font5));
                        //table.AddCell(new Phrase(commaSeperatedDates.Contains("6 PM") ? "YES" : "", font5));
                        //table.AddCell(new Phrase(commaSeperatedDates.Contains("10 PM") ? "YES" : "", font5));
                        //table.AddCell(new Phrase(commaSeperatedDates.Contains("12 MIDNIGHT") ? "YES" : "", font5));

                        foreach (string deases in lstDeases.SelectedItems)
                        {
                            if (lstDeases.SelectedItems.Contains("Temp"))
                            {
                                table.AddCell(new Phrase(Convert.ToString(r[9]), font5));
                            }
                            if (lstDeases.SelectedItems.Contains("Bp"))
                            {
                                table.AddCell(new Phrase(Convert.ToString(r[10]), font5));
                            }
                            if (lstDeases.SelectedItems.Contains("USugar"))
                            {
                                table.AddCell(new Phrase(Convert.ToString(r[11]), font5));
                            }
                            if (lstDeases.SelectedItems.Contains("BlSugar"))
                            {
                                table.AddCell(new Phrase(Convert.ToString(r[12]), font5));
                            }
                            if (lstDeases.SelectedItems.Contains("Insulin"))
                            {
                                table.AddCell(new Phrase(Convert.ToString(r[13]), font5));
                            }
                            break;
                            //SelectedDates = dt.AsEnumerable().OrderBy(s => s.Field<string>("SortOrder")).Where(x => Convert.ToString(x["PatientDate"]) == Convert.ToString(drDate["PatientDate"]))
                            //    .Select(s => s.Field<string>(deases))
                            //    .Where(s => !string.IsNullOrEmpty(s)).ToArray();
                            //commaSeperatedDates = string.Join(",", SelectedDates);
                            //string lastWord = commaSeperatedDates.Split(',').Last();
                            //table.AddCell(new Phrase(Convert.ToString(lastWord), font5));
                        }
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < tblColCount; j++)
                    {
                        table.AddCell(new Phrase(" ", font5));
                    }
                }
                document.Add(table);
            }
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

        public void ExportAllPatientInfoToPdf(DataTable dt, string fromDate, string toDate)
        {
            var pdfFile = "";
            DataTable dtPatient = null;

            pdfFile = Application.StartupPath + "\\" + "IndoorPatient_" + Convert.ToString(cmbPatient.SelectedItem.ToString()) + "-" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".pdf";

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFile, FileMode.Create));
            document.Open();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtPatient = Operation.GetDataTable("select * from AdmitPatient where Pid = '" + Convert.ToString(dt.Rows[i][0]).Trim() + "' and PatientDate between #" + fromDate + "# and #" + toDate + "#");

                iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 7);

                int tblColCount = 7 + lstDeases.SelectedItems.Count;

                PdfPTable table = new PdfPTable(tblColCount);

                //float[] widths = new float[] { 2f, 2f, 2f, 2f, 2f, 2f, 2f };

                //table.SetWidths(widths);

                table.WidthPercentage = 100;

                PdfPCell cell = new PdfPCell(new Phrase("Indoor patient - " + Convert.ToString(dt.Rows[i][1] + "-" + dt.Rows[i][0]) + " - " + DateTime.Now.ToShortDateString()));

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

                DataView view = new DataView(dtPatient);
                DataTable distinctDates = view.ToTable(true, "PatientDate");
                var orderedRows = from row in distinctDates.AsEnumerable()
                                  orderby row.Field<DateTime>("PatientDate")
                                  select row;
                distinctDates = orderedRows.CopyToDataTable();

                foreach (DataRow drDate in distinctDates.Rows)
                {
                    var SelectedDates = dtPatient.AsEnumerable().Where(x => Convert.ToString(x["PatientDate"]) == Convert.ToString(drDate["PatientDate"])).Select(s => s.Field<string>("Time")).ToArray();
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
                        SelectedDates = dtPatient.AsEnumerable().OrderBy(s => s.Field<string>("SortOrder")).Where(x => Convert.ToString(x["PatientDate"]) == Convert.ToString(drDate["PatientDate"]))
                            .Select(s => s.Field<string>(deases))
                            .Where(s => !string.IsNullOrEmpty(s)).ToArray();
                        commaSeperatedDates = string.Join(",", SelectedDates);
                        string lastWord = commaSeperatedDates.Split(',').Last();
                        table.AddCell(new Phrase(Convert.ToString(lastWord), font5));
                    }
                }

                document.Add(table);
                document.NewPage();
            }
            document.Close();
            ShowPdf(pdfFile);
        }
    }
}