using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Medical_store
{
    public partial class Company : Form
    {
string ConnectionString =
                ConfigurationManager.ConnectionStrings["MedicalConnectionString"].ConnectionString;
       
        public Company()
        {
            InitializeComponent();
        }

        private void saveCompanyButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);


                if (con.State == ConnectionState.Closed)
                    con.Open();
                //insert query  
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                int a = 0;
                cmd.CommandText = "INSERT INTO [Company] VALUES('" + textBox1.Text +"')";
                cmd.ExecuteNonQuery();
                // cmd.CommandText = "INSERT INTO Stock([Company-Name],[Item-id],[Sale-QTY],[Purchase-QTY],[Available-QTY])VALUES ('" + comboBox1.Text + "','" + textBox2.Text + "','" + a + "','" + a + "','" + a + "')";
                //cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully added", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmd.Connection.Close();
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Company]", con);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
            finally
            {
                //After succeesful insertion, all the fields will be cleared
                textBox1.Text = "";

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            textBox1.Text = row.Cells[0].Value.ToString();
           
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();

                //update query
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE [Company] SET [CompanyName] = '" + textBox1.Text + "' ";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully updated", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Connection.Close();

                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Company]", con);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();

                //delete query  
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;



                cmd.CommandText = "select * from [Company]";
                DialogResult result = MessageBox.Show("Do You Really Want TO Delete This Record", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    textBox1.Focus();
                }
                else
                {
                    cmd.CommandText = "DELETE FROM [Company] WHERE [CompanyId]= '" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Selected Record is deleted", "Delete", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }


                cmd.Connection.Close();

                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Company]", con);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
    }

        private void Company_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'medicalDataSet1.Stock' table. You can move, or remove it, as needed.
                //this.stockTableAdapter.Fill(this.medicalDataSet1.Stock);
                // TODO: This line of code loads data into the 'medicalDataSet._Item_master' table. You can move, or remove it, as needed.
                // this.item_masterTableAdapter.Fill(this.medicalDataSet._Item_master);

                
                textBox1.Text = "";
               
                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();

                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Company]", con);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
               
                con.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
