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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Insert into student values('" + txtid.Text + "', '" + txtname.Text + "', '" + cboclass.SelectedItem + "','" + cbosection.SelectedItem + "')";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                if(txtid.Text =="" || txtname.Text==""|| cboclass.Text == "" || cbosection.Text == "")
                {
                    MessageBox.Show("Please Enter All requried information");
                }
                else{
                  
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Add Successfully");
                    refresh();
                    txtid.Text = "";
                    txtname.Text = "";
                    cboclass.Text = "";
                    cbosection.Text = "";
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Student_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Select * from student";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Update student set name='" + txtname.Text+"', class='"+cboclass.SelectedItem+"', section='"+cbosection.SelectedItem+ "' where stdid='"+txtid.Text+"' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                if (txtid.Text == "" || txtname.Text == "" || cboclass.Text == "" || cbosection.Text == "")
                {
                    MessageBox.Show("Please Enter All requried information");
                }
                else
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update Successfully");
                    refresh();
                    txtid.Text = "";
                    txtname.Text = "";
                    cboclass.Text = "";
                    cbosection.Text = "";
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            cboclass.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            cbosection.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Delete from student where stdid='"+txtid.Text+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                if (txtid.Text == "")
                {
                    MessageBox.Show("Please Student id");
                }
                else
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Successfully");
                    refresh();
                    txtid.Text = "";
                    txtname.Text = "";
                    cboclass.Text = "";
                    cbosection.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
           
        }
    }
}
