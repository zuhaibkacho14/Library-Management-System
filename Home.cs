using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_library_ms
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Book bk = new Book();
            bk.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            issue_book ib = new issue_book();
            ib.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnstudent_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            std.ShowDialog();
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            returnBook rb = new returnBook();
            rb.ShowDialog();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            dashboard dh = new dashboard();
            dh.ShowDialog();
        }
    }
}
