using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace db_f1
{
    public partial class frmEmployee : Form
    {
        string strConn = "server=localhost; database=db_act1; uid=root; pwd=mysql; port=3306;";
        MySqlConnection conn;
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            display();
            getDepID();
        }
         private void getDepID()
        {
            using (conn = new MySqlConnection(strConn))
            {
                conn.Open();
                string popu =
                 "SELECT deptID " +
                 "FROM DEPARTMENT";
                using (MySqlCommand dept = new MySqlCommand(popu, conn))
                using (MySqlDataReader dr = dept.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        cbDep.Items.Add(dr["deptID"].ToString());
                    }
                }
            }                      
        }
        private void display()
        {
            DataTable dt = new DataTable();
            conn = new MySqlConnection(strConn);
            string query = "select * from EMPLOYEE ;";
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            dgvDisp.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAge.Text) && string.IsNullOrEmpty(txtName.Text) && string
                .IsNullOrEmpty(txtSex.Text) && string.IsNullOrEmpty(txtMarital.Text) && string.IsNullOrEmpty(cbDep.Text))
            {
                MessageBox.Show("All Fields Required");
            }
            else
            {
                DataTable dt = new DataTable();
                conn = new MySqlConnection(strConn);
                string query = "" +
                    "INSERT INTO EMPLOYEE(emp_name,emp_age,emp_sex,marital_status,deptID) " +
                    "VALUES('" + txtName.Text + "'," + txtAge.Text + ",'"+txtSex.Text+"','" + txtMarital.Text + "'," + cbDep.Text + ") ;";
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
                conn.Close();
                dgvDisp.DataSource = dt;
            }
            display();

        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            conn = new MySqlConnection(strConn);
            string query = "" +
                "UPDATE EMPLOYEE " +
                "SET emp_name = '"+ txtName.Text +"'," +
                "emp_age = "+ txtAge.Text +"," +
                "emp_sex = '"+ txtSex.Text +"'," +
                "marital_status = '"+ txtMarital.Text +"'," +
                "deptID = "+ cbDep.Text +" " +
                "where empID = "+ txtID.Text +" ";
            conn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();
            dgvDisp.DataSource = dt;

            display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection(strConn);
            conn.Open();
            string query = "" +
                "DELETE FROM EMPLOYEE " +
                "WHERE emp_name = '" + txtName.Text + "' " +
                "and emp_age = " + txtAge.Text + " ; ";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted");
            conn.Close();
            display();
        }

        private void dgvDisp_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
