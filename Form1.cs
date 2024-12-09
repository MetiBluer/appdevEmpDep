using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace db_f1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDep_Click(object sender, EventArgs e)
        {
            frmDepartment dep = new frmDepartment();
            dep.ShowDialog();
        }

        private void btnEmp_Click(object sender, EventArgs e)
        {
            frmEmployee emp = new frmEmployee();
            emp.ShowDialog();
        }
    }
}
