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
    public partial class Book : Form
    {
        public Book()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Insert into Book values('" + txtid.Text + "', '" + txtname.Text + "', '" + txtauther.Text + "','" +txtpublisher.Text + "','"+txtprice.Text+"','"+txtquantity.Text+"')";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                if (txtid.Text == "" || txtname.Text == "" || txtauther.Text == "" || txtpublisher.Text == "" || txtprice.Text==""||txtquantity.Text=="")
                {
                    MessageBox.Show("Please Enter All requried information");
                }
                else
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Add Successfully");
                    refresh();
                    txtid.Text = "";
                    txtname.Text = "";
                    txtauther.Text = "";
                    txtpublisher.Text = "";
                    txtprice.Text = "";
                    txtquantity.Text = "";
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
        private void refresh()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Select * from Book";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Book_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Delete from Book where bookid='" + txtid.Text + "'";
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
                    txtauther.Text = "";
                    txtpublisher.Text = "";
                    txtprice.Text = "";
                    txtquantity.Text = "";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtauther.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtpublisher.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtprice.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtquantity.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Update Book set bookname='" + txtname.Text + "', auther='" + txtauther.Text + "', publisher='" +txtpublisher.Text + "',price='"+txtprice.Text+"',quantity='"+txtquantity.Text+"' where bookid='" + txtid.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                if (txtid.Text == "" || txtname.Text == "" || txtauther.Text == "" || txtpublisher.Text == "" || txtprice.Text == "" || txtquantity.Text == "")
                {
                    MessageBox.Show("Please Enter All required information");
                }
                else
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("update Successfully");
                    refresh();
                    txtid.Text = "";
                    txtname.Text = "";
                    txtauther.Text = "";
                    txtpublisher.Text = "";
                    txtprice.Text = "";
                    txtquantity.Text = "";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
