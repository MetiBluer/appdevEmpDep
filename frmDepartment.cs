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
    public partial class frmDepartment : Form
    {
        string strConn = "server=localhost; database=db_act1; uid=root; pwd=mysql; port=3306;";
        MySqlConnection conn;
        DataTable dt;
        public frmDepartment()
        {
           
            InitializeComponent();
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
           
            display();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            conn = new MySqlConnection(strConn);
            conn.Open();
            string query = "" +
                "INSERT INTO DEPARTMENT(deptName) " +
                "VALUES ('" + txtDeptName.Text + "');";
            
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            display();

        }
        private void display()
        {

           

            using (dt = new DataTable())
            {
                using (conn = new MySqlConnection(strConn))
                {
                    conn.Open();
                    string query = "select * from DEPARTMENT ;";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.Fill(dt);
                    conn.Close();
                    dgvDisp.DataSource = dt;
                }
                    
               
            }
                
        }



        private void btnUpd_Click(object sender, EventArgs e)
        {

            try
            {
                
                string sel = dgvDisp.SelectedCells[0].Value.ToString();
                using (conn = new MySqlConnection(strConn))
                {
                    conn.Open();
                    string query = "" +
                        "UPDATE DEPARTMENT " +
                        "SET deptName = '" + txtDeptName.Text + "' " +
                        "WHERE deptID = " + sel + "";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        cmd.ExecuteNonQuery();
                    conn.Close();
                    display();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string selected = dgvDisp.SelectedCells[1].Value.ToString();
                conn = new MySqlConnection(strConn);
                conn.Open();
                string query = "" +
                    "DELETE FROM DEPARTMENT " +
                    "WHERE deptName = '" + selected + "'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                display();
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message); 
            }
            
        }

        private void dgvDisp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDeptName.Text = dgvDisp.SelectedCells[1].Value.ToString();
            txtID.Text = dgvDisp.SelectedCells[0].Value.ToString();
        }
    }
}
