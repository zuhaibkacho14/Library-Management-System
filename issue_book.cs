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
    public partial class issue_book : Form
    {
        public issue_book()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Insert into issue_book values('" + txtissueId.Text + "', '" + txtstdid.Text + "', '" + txtname.Text + "','" + txtclass.Text + "','" + txtsection.Text + "','" + cbobook.SelectedItem + "','"+dtpissuedate.Text+"')";
            SqlCommand cmd = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                if (txtissueId.Text == "" || txtstdid.Text == "" || txtname.Text == "" || txtclass.Text == "" || txtsection.Text == "" || cbobook.Text == "" || dtpissuedate.Text=="")
                {
                    MessageBox.Show("Please Enter All requried information");
                }
                else
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Add Successfully");
                    refresh();
                    txtissueId.Text = "";
                    txtname.Text = "";
                    txtclass.Text = "";
                    txtsection.Text = "";
                    txtstdid.Text = "";
                    cbobook.Text = "";
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
            string query = "Select * from issue_book";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void issue_book_Load(object sender, EventArgs e)
        {
            refresh();
            cboBook();


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Select * from student where stdid='"+txtstdid.Text+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    txtname.Text = dr["name"].ToString();
                    txtclass.Text = dr["class"].ToString();
                    txtsection.Text = dr["section"].ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbobook_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
        private void cboBook()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Select bookname from Book";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cbobook.Items.Add(dr[0]);
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Delete from issue_book where issue_id='" + txtissueId.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                if (txtissueId.Text == "")
                {
                    MessageBox.Show("Please issue book id");
                }
                else
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Successfully");
                    refresh();
                    txtissueId.Text = "";
                    txtname.Text = "";
                    txtstdid.Text = "";
                    txtclass.Text = "";
                    txtsection.Text = "";
                    cbobook.Text = "";
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
            txtissueId.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtstdid.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtclass.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtsection.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            cbobook.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            dtpissuedate.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Update issue_book set stdid='" + txtstdid.Text + "', name='" + txtname.Text + "', class='" + txtclass.Text + "',section='" + txtsection.Text + "',book='" + cbobook.SelectedItem + "' where issue_id='" + txtissueId.Text + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                if (txtissueId.Text == "" || txtname.Text == "" || txtstdid.Text == "" || cbobook.Text == "" || dtpissuedate.Text == "")
                {
                    MessageBox.Show("Please Enter All required information");
                }
                else
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("update Successfully");
                    refresh();
                    txtissueId.Text = "";
                    txtname.Text = "";
                    txtstdid.Text = "";
                    txtclass.Text = "";
                    txtsection.Text = "";
                    cbobook.Text = "";
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
    }
}
