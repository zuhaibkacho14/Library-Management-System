using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_library_ms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string sqlQuery = "Select * from Login where username='" + txtusername.Text + "' and password='" + txtpassword.Text + "'";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if(txtusername.Text=="" || txtpassword.Text == "")
                {
                    MessageBox.Show("Please enter required information");
                }else if (dt.Rows.Count > 0)
                {
                    lblerrormsg.Visible = false;
                    Home hm = new Home();
                    hm.Show();
                    this.Hide();
                }
                else
                {
                    lblerrormsg.Visible = true;
                }
               
               
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
