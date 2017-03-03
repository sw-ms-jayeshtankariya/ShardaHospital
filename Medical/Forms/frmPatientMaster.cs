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
    public partial class frmPatientMaster : Form
    {
        private OleDbConnection bookConn;
        private OleDbCommand oleDbCmd = new OleDbCommand();
        private String connParam = ConfigurationSettings.AppSettings["dsn"];
        List<int> patientId = new List<int>();

        public string patientName { get; set; }

        public frmPatientMaster()
        {
            InitializeComponent();
        }

        private void setdatagrid()
        {
            string query = "select PatientCode,fname,mname,lname,Address,Sex,Age from pmaster";
            using (OleDbConnection conn = new OleDbConnection(connParam))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    if (ds != null)
                    {
                        adapter.Fill(ds);
                        dgPatientMaster.DataSource = ds.Tables[0];

                        dgPatientMaster.Columns[2].Visible = false;
                        dgPatientMaster.Columns[3].Visible = false;
                    }
                }
            }
        }

        private void frmPatientMaster_Load(object sender, EventArgs e)
        {
            setdatagrid();

            txtName.Text = patientName;
        }

        private void dgPatientMaster_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

        }

        private void dgPatientMaster_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgPatientMaster.SelectedRows)
            {
                txtFields0.Text = Convert.ToString(row.Cells[0].Value);
                txtFields1.Text = Convert.ToString(row.Cells[1].Value);
                txtFields4.Text = Convert.ToString(row.Cells[4].Value);
                txtFields5.Text = Convert.ToString(row.Cells[5].Value);
                txtFields6.Text = Convert.ToString(row.Cells[6].Value);
            }

            //txtFields0.Text = dgPatientMaster.Rows[e.RowIndex].Cells[0].Value.ToString();
            //txtFields1.Text = dgPatientMaster.Rows[e.RowIndex].Cells[1].Value.ToString();
            //txtFields4.Text = dgPatientMaster.Rows[e.RowIndex].Cells[4].Value.ToString();
            //txtFields5.Text = dgPatientMaster.Rows[e.RowIndex].Cells[5].Value.ToString();
            //txtFields6.Text = dgPatientMaster.Rows[e.RowIndex].Cells[6].Value.ToString();
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
            cmdPrescription.Visible = bVal;
            cmdFind.Visible = bVal;
        }

        private void patientOperations()
        {
            OleDbConnection con = new OleDbConnection(connParam);

            bool exists = false;

            // create a command to check if the username exists
            using (OleDbCommand cmd = new OleDbCommand("select count(*) from pmaster where PatientCode=@patientcode", con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("PatientCode", txtFields0.Text);
                exists = (int)cmd.ExecuteScalar() > 0;
                con.Close();
            }

            // if exists, show a message error
            if (exists)
            {
                // "UserName Already Taken";
                oleDbCmd = new OleDbCommand("update pmaster set fname=@frstname, Address=@address, Age=@age, Sex=@sex where PatientCode=@patientcode", con);
                con.Open();
                oleDbCmd.Parameters.AddWithValue("@frstname", Convert.ToString(txtFields1.Text));
                oleDbCmd.Parameters.AddWithValue("@address", Convert.ToString(txtFields4.Text));
                oleDbCmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtFields6.Text));
                oleDbCmd.Parameters.AddWithValue("@sex", Convert.ToString(txtFields5.Text));
                oleDbCmd.Parameters.AddWithValue("@patientcode", Convert.ToString(txtFields0.Text));
                oleDbCmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                if (txtFields0.Text != null)
                {
                    oleDbCmd = new OleDbCommand("insert into pmaster(PatientCode,fname,Address,Age,Sex) values(@patientcode,@frstname,@address,@age,@sex)", con);
                    con.Open();
                    oleDbCmd.Parameters.AddWithValue("@patientcode", Convert.ToString(txtFields0.Text));
                    oleDbCmd.Parameters.AddWithValue("@frstname", Convert.ToString(txtFields1.Text));
                    oleDbCmd.Parameters.AddWithValue("@address", Convert.ToString(txtFields4.Text));
                    oleDbCmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtFields6.Text));
                    oleDbCmd.Parameters.AddWithValue("@sex", Convert.ToString(txtFields5.Text));
                    oleDbCmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Enter code of the patient");
                }
            }
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            SetButtons(false);

            int nRowIndex = dgPatientMaster.Rows.Count - 1;
            int nColumnIndex = 3;

            dgPatientMaster.Rows[nRowIndex].Selected = true;
            dgPatientMaster.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

            //In case if you want to scroll down as well.
            dgPatientMaster.FirstDisplayedScrollingRowIndex = nRowIndex;
            //patientOperations("insert");

            txtFields0.Text = "";
            txtFields1.Text = txtName.Text;
            txtFields4.Text = "SEC-0";
            txtFields5.Text = "M";
            txtFields6.Text = "1";
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            SetButtons(true);
            patientOperations();
            setdatagrid();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            SetButtons(false);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SetButtons(true);
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            setdatagrid();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(connParam);

            foreach (DataGridViewRow row in dgPatientMaster.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    if (!String.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                    {
                        oleDbCmd = new OleDbCommand("delete from pmaster where PatientCode=@patientcode", con);
                        con.Open();
                        oleDbCmd.Parameters.AddWithValue("@patientcode", row.Cells[0].Value);
                        oleDbCmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            setdatagrid();
        }
    }
}
