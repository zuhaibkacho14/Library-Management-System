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
    public partial class returnBook : Form
    {
        public returnBook()
        {
            InitializeComponent();
        }

        private void returnBook_Load(object sender, EventArgs e)
        {
            load();
            refresh();
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Insert into return_book values('"+txtissueId.Text+"','"+txtstdid.Text+"','"+txtname.Text+"','"+txtclass.Text+"','"+txtsection.Text+"','"+cbobook.Text+"','"+dtpissuedate.Text+"', '"+dtpreturn.Text+"')";

            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                if(dtpissuedate.Value > dtpreturn.Value)
                {
                    MessageBox.Show("Please enter valid return date");
                }
                else
                {
                    conn.Open();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    refresh();
                    remove();
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
        private void refresh()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Select * from return_book";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        
        private void load()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Select * from issue_book";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void remove()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Delete from issue_book where issue_id='"+txtissueId.Text+"'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                refresh();
                load();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-V3OM59N;Initial Catalog=schoollibraryMs;Integrated Security=True");
            string query = "Select * from issue_book where issue_id='" + txtissueId.Text + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    txtstdid.Text = dr["stdid"].ToString();
                    txtname.Text = dr["name"].ToString();
                    txtclass.Text = dr["class"].ToString();
                    txtsection.Text = dr["section"].ToString();
                    cbobook.Text = dr["book"].ToString();
                    dtpissuedate.Text = dr["issue_date"].ToString();
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
