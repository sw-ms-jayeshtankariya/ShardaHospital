using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medical
{
    public partial class frmSearch : Form
    {
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string patientName { get; set; }
        public string receptNo { get; set; }

        public frmSearch()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            chkName.Checked = false;
            chkReceiptNo.Checked = false;
            fraDate.Visible = false;
            fraName.Visible = false;
            fraReceiptNo.Visible = false;
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
                fraDate.Visible = true;
            else
                fraDate.Visible = false;
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked)
            {
                fraName.Visible = true;
                fraReceiptNo.Visible = false;
            }
        }

        private void chkReceiptNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReceiptNo.Checked)
            {
                fraName.Visible = false;
                fraReceiptNo.Visible = true;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                fromDate = dateFrom.Value;
                toDate = dateTo.Value;
            }
            if (chkName.Checked && txtName.Text != null)
                patientName = Convert.ToString(txtName.Text);
            if (chkReceiptNo.Checked && txtReceiptNo.Text != null)
                receptNo = Convert.ToString(txtReceiptNo.Text);
            this.Close();
        }
    }
}
