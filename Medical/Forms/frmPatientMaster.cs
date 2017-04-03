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
        public string patientAge { get; set; }
        public string patientSex { get; set; }
        public string patientAddress { get; set; }
        bool IsGetPtCode = false;

        public frmPatientMaster()
        {
            InitializeComponent();
        }

        private void setdatagrid()
        {
            dgPatientMaster.DataSource = Operation.GetDataTable("select PatientCode,fname,mname,lname,Address,Sex,Age from pmaster");

            dgPatientMaster.Columns[2].Visible = false;
            dgPatientMaster.Columns[3].Visible = false;

            lblStatus.Text = "";
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

            List<OleDbParameter> paramselect = new List<OleDbParameter>();
            paramselect.Add(new OleDbParameter("@patientcode", txtFields0.Text));
            exists = Operation.ExecuteScalar("select count(*) from pmaster where PatientCode=@patientcode", paramselect);

            if (exists)
            {
                // "PatientCode Already Taken";
                if (txtFields0.Text != null && txtFields0.Text != "")
                {
                    List<OleDbParameter> param = new List<OleDbParameter>();
                    param.Add(new OleDbParameter("@frstname", Convert.ToString(txtFields1.Text)));
                    param.Add(new OleDbParameter("@address", Convert.ToString(txtFields4.Text)));
                    param.Add(new OleDbParameter("@age", Convert.ToInt32(txtFields6.Text)));
                    param.Add(new OleDbParameter("@sex", Convert.ToString(txtFields5.Text)));
                    param.Add(new OleDbParameter("@patientcode", Convert.ToString(txtFields0.Text)));
                    Operation.ExecuteNonQuery("update pmaster set fname=@frstname, Address=@address, Age=@age, Sex=@sex where PatientCode=@patientcode", param);

                    int currentRow = dgPatientMaster.CurrentCell.RowIndex;
                    if (currentRow != 0 && dgPatientMaster.Rows.Count > 1)
                        setdatagrid();
                    else
                    {
                        DataTable dt = new DataTable();
                        dt.Rows.Clear();
                        dt.Columns.Add("PatientCode");
                        dt.Columns.Add("fname");
                        dt.Columns.Add("mname");
                        dt.Columns.Add("lname");
                        dt.Columns.Add("Address");
                        dt.Columns.Add("Sex");
                        dt.Columns.Add("Age", typeof(int));

                        dt.Rows.Add(txtFields0.Text, txtFields1.Text, "", "", txtFields4.Text, txtFields5.Text, Convert.ToInt32(txtFields6.Text));
                        dgPatientMaster.DataSource = dt;
                    }
                    dgPatientMaster.CurrentCell = dgPatientMaster[0, currentRow];

                    //oleDbCmd = new OleDbCommand("update pmaster set fname=@frstname, Address=@address, Age=@age, Sex=@sex where PatientCode=@patientcode", con);
                    //con.Open();
                    //oleDbCmd.Parameters.AddWithValue("@frstname", Convert.ToString(txtFields1.Text));
                    //oleDbCmd.Parameters.AddWithValue("@address", Convert.ToString(txtFields4.Text));
                    //oleDbCmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtFields6.Text));
                    //oleDbCmd.Parameters.AddWithValue("@sex", Convert.ToString(txtFields5.Text));
                    //oleDbCmd.Parameters.AddWithValue("@patientcode", Convert.ToString(txtFields0.Text));
                    //oleDbCmd.ExecuteNonQuery();
                    //con.Close();
                }
                else
                {
                    MessageBox.Show("Enter code of the patient");
                }
            }
            else
            {
                if (txtFields0.Text != null && txtFields0.Text != "")
                {
                    List<OleDbParameter> param = new List<OleDbParameter>();
                    param.Add(new OleDbParameter("@patientcode", Convert.ToString(txtFields0.Text)));
                    param.Add(new OleDbParameter("@frstname", Convert.ToString(txtFields1.Text)));
                    param.Add(new OleDbParameter("@address", Convert.ToString(txtFields4.Text)));
                    param.Add(new OleDbParameter("@age", Convert.ToInt32(txtFields6.Text)));
                    param.Add(new OleDbParameter("@sex", Convert.ToString(txtFields5.Text)));
                    Operation.ExecuteNonQuery("insert into pmaster(PatientCode,fname,Address,Age,Sex) values(@patientcode,@frstname,@address,@age,@sex)", param);

                    if (!IsGetPtCode)
                    {
                        setdatagrid();

                        int numOfRows = dgPatientMaster.Rows.Count - 2;
                        dgPatientMaster.CurrentCell = dgPatientMaster[0, numOfRows];
                    }
                    else
                    {
                        //dgPatientMaster.Columns[0].Name = "Product ID";
                        //dgPatientMaster.Columns[1].Name = "Product Name";
                        //dgPatientMaster.Columns[2].Name = "Product Price";
                        //this.dgPatientMaster.Columns.Add("PatientCode", "fname", "Address", "Age", "Sex");
                        //this.dgPatientMaster.Columns.Add("PatientCode", "PatientCode");
                        //this.dgPatientMaster.Columns.Add("fname", "fname");
                        //this.dgPatientMaster.Columns.Add("mname", "mname");
                        //this.dgPatientMaster.Columns.Add("lname", "lname");
                        //this.dgPatientMaster.Columns.Add("Address", "Address");
                        //this.dgPatientMaster.Columns.Add("Age", "Age");
                        //this.dgPatientMaster.Columns.Add("Sex", "Sex");   
                        DataTable dt = new DataTable();
                        dt.Columns.Add("PatientCode");
                        dt.Columns.Add("fname");
                        dt.Columns.Add("mname");
                        dt.Columns.Add("lname");
                        dt.Columns.Add("Address");
                        dt.Columns.Add("Sex");
                        dt.Columns.Add("Age", typeof(int));

                        dt.Rows.Add(txtFields0.Text, txtFields1.Text, "", "", txtFields4.Text, txtFields5.Text, Convert.ToInt32(txtFields6.Text));
                        dgPatientMaster.DataSource = dt;
                        dgPatientMaster.Columns[2].Visible = false;
                        dgPatientMaster.Columns[3].Visible = false;
                    }

                    //oleDbCmd = new OleDbCommand("insert into pmaster(PatientCode,fname,Address,Age,Sex) values(@patientcode,@frstname,@address,@age,@sex)", con);
                    //con.Open();
                    //oleDbCmd.Parameters.AddWithValue("@patientcode", Convert.ToString(txtFields0.Text));
                    //oleDbCmd.Parameters.AddWithValue("@frstname", Convert.ToString(txtFields1.Text));
                    //oleDbCmd.Parameters.AddWithValue("@address", Convert.ToString(txtFields4.Text));
                    //oleDbCmd.Parameters.AddWithValue("@age", Convert.ToInt32(txtFields6.Text));
                    //oleDbCmd.Parameters.AddWithValue("@sex", Convert.ToString(txtFields5.Text));
                    //oleDbCmd.ExecuteNonQuery();
                    //con.Close();
                }
                else
                {
                    MessageBox.Show("Enter code of the patient");
                }
            }
        }
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            IsGetPtCode = false;
            SetButtons(false);

            int nRowIndex = dgPatientMaster.Rows.Count - 1;
            int nColumnIndex = 3;

            dgPatientMaster.CurrentCell = dgPatientMaster.Rows[nRowIndex].Cells[1];
            dgPatientMaster.Rows[nRowIndex].Selected = true;
            dgPatientMaster.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

            //In case if you want to scroll down as well.
            dgPatientMaster.FirstDisplayedScrollingRowIndex = nRowIndex;
            //patientOperations("insert");

            txtFields0.Text = "";
            txtFields1.Text = txtName.Text;
            txtFields4.Text = patientAddress;
            txtFields5.Text = patientSex;
            txtFields6.Text = patientAge;

            lblStatus.Text = "Add record";
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            SetButtons(true);
            patientOperations();
            //setdatagrid();
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            SetButtons(false);
            lblStatus.Text = "Edit record";
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SetButtons(true);
            setdatagrid();
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
                        List<OleDbParameter> param = new List<OleDbParameter>();
                        param.Add(new OleDbParameter("@patientcode", row.Cells[0].Value));
                        Operation.ExecuteNonQuery("delete from pmaster where PatientCode=@patientcode", param);

                        //oleDbCmd = new OleDbCommand("delete from pmaster where PatientCode=@patientcode", con);
                        //con.Open();
                        //oleDbCmd.Parameters.AddWithValue("@patientcode", row.Cells[0].Value);
                        //oleDbCmd.ExecuteNonQuery();
                        //con.Close();
                    }
                }
            }
            setdatagrid();
        }

        private void cmdPfind_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = Operation.GetDataTable("select PatientCode,fname,mname,lname,Address,Sex,Age from pmaster where fname like '" + txtName.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                dgPatientMaster.DataSource = dt;

                dgPatientMaster.Columns[2].Visible = false;
                dgPatientMaster.Columns[3].Visible = false;
            }
            else
            {
                MessageBox.Show("Patine is not found");
                clearboxes();
            }

        }

        private void clearboxes()
        {
            txtFields0.Text = "";
            txtFields1.Text = "";
            txtFields4.Text = "";
            txtFields6.Text = "";
            txtFields5.Text = "";
        }

        private void cmdCheck_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = Operation.GetDataTable("select PatientCode,fname,mname,lname,Address,Sex,Age from pmaster where PatientCode like '" + txtCode.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                dgPatientMaster.DataSource = dt;

                dgPatientMaster.Columns[2].Visible = false;
                dgPatientMaster.Columns[3].Visible = false;
            }
            else
            {
                DialogResult result = MessageBox.Show("Patine Code is not found Do you want to ADD (Yes/No)?", "Confirmation box", MessageBoxButtons.YesNo);
                if (Convert.ToString(result) == "Yes")
                {
                    clearboxes();

                    txtFields0.Text = txtCode.Text;
                    txtFields1.Text = txtName.Text;
                    txtFields4.Text = patientAddress;
                    txtFields5.Text = patientSex;
                    txtFields6.Text = patientAge;

                    dt.Rows.Clear();
                    dgPatientMaster.DataSource = dt;
                    SetButtons(false);

                    IsGetPtCode = true;
                }
                else
                {
                    setdatagrid();
                }
            }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            frmFind objFind = new frmFind();
            objFind.ShowDialog();

            string pat_Id = "";
            string query = "";

            if (objFind.patientId != null)
            {
                pat_Id = objFind.patientId;
                //select * from pMaster where PatientCode " & "like '" & Trim(pcode) & "%'"
                query = "select * from pMaster where PatientCode like '" + pat_Id.Trim() + "'";

                if (query != "")
                {
                    dgPatientMaster.DataSource = Operation.GetDataTable(query);
                }
            }
        }

        private void cmdFirst_Click(object sender, EventArgs e)
        {
            dgPatientMaster.CurrentCell = dgPatientMaster[0, 0];

            //dgPatientMaster.Rows[0].Selected = true;
            //dgPatientMaster.FirstDisplayedScrollingRowIndex = dgPatientMaster.Rows[0].Index;
        }

        private void cmdPrevious_Click(object sender, EventArgs e)
        {
            //if (!dgPatientMaster.Rows[0].Selected)
            //{
            //    if (dgPatientMaster.Rows[dgPatientMaster.CurrentCell.RowIndex - 1] != null)
            //    {
            //        dgPatientMaster.CurrentCell = dgPatientMaster.Rows[dgPatientMaster.CurrentCell.RowIndex - 1].Cells[1];
            //        dgPatientMaster.FirstDisplayedScrollingRowIndex = dgPatientMaster.Rows[dgPatientMaster.CurrentCell.RowIndex - 1].Index;
            //    }
            //}
            //Get number of records displayed in the data grid view and subtract one to keep in line with index that starts with 0
            int numOfRows = dgPatientMaster.Rows.Count - 1;

            //Get current row selected
            int index = dgPatientMaster.SelectedRows[0].Index;

            // Determine if the previous record exists or cycle back to the last record in the set
            if (index != 0)
            {
                //Change the selected row to next row down in the data set
                dgPatientMaster.CurrentCell = dgPatientMaster[0, index - 1];
            }
            else
            {
                // Select the first record of the data set
                dgPatientMaster.CurrentCell = dgPatientMaster[0, numOfRows];
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            //if (dgPatientMaster.CurrentCell.RowIndex + 1 < dgPatientMaster.Rows.Count - 1)
            //{
            //    if (dgPatientMaster.Rows[dgPatientMaster.CurrentCell.RowIndex + 1] != null)
            //    {
            //        dgPatientMaster.CurrentCell = dgPatientMaster.Rows[dgPatientMaster.CurrentCell.RowIndex + 1].Cells[1];
            //        dgPatientMaster.FirstDisplayedScrollingRowIndex = dgPatientMaster.Rows[dgPatientMaster.CurrentCell.RowIndex + 1].Index;
            //    }
            //}
            //Get number of records displayed in the data grid view and subtract one to keep in line with index that starts with 0
            int numOfRows = dgPatientMaster.Rows.Count - 1;

            //Get current row selected
            int index = dgPatientMaster.SelectedRows[0].Index;

            // Determine if the next record exists or cycle back to the first record in the set
            if (index < numOfRows)
            {
                //Change the selected row to next row down in the data set
                dgPatientMaster.CurrentCell = dgPatientMaster[0, index + 1];
            }
            else
            {
                // Select the first record of the data set
                dgPatientMaster.CurrentCell = dgPatientMaster[0, 0];
            }
        }

        private void cmdLast_Click(object sender, EventArgs e)
        {
            int numOfRows = dgPatientMaster.Rows.Count - 1;
            dgPatientMaster.CurrentCell = dgPatientMaster[0, numOfRows];
            //int nRowIndex = dgPatientMaster.Rows.Count - 1;
            //int nColumnIndex = 3;

            //dgPatientMaster.Rows[nRowIndex].Selected = true;
            //dgPatientMaster.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

            ////In case if you want to scroll down as well.
            //dgPatientMaster.FirstDisplayedScrollingRowIndex = nRowIndex;
        }

        private void cmdPrescription_Click(object sender, EventArgs e)
        {
            if (dgPatientMaster.CurrentCell != null)
            {
                string patientCode = Convert.ToString(dgPatientMaster.Rows[dgPatientMaster.CurrentCell.RowIndex].Cells[0].Value);
                string patientName = Convert.ToString(dgPatientMaster.Rows[dgPatientMaster.CurrentCell.RowIndex].Cells[1].Value);

                frmtreatement objtreatement = new frmtreatement();
                objtreatement.patientCode = patientCode;
                objtreatement.patientName = patientName;
                objtreatement.ShowDialog();
            }
        }
    }
}
