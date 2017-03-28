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
    public partial class frmSerial : Form
    {
        public DateTime fromDate { get; set; }

        public frmSerial()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            fromDate = dateFrom.Value;            
            this.Close();
        }

        private void cmdReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
