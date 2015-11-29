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
    public partial class Customermaster : Form
    {
string ConnectionString =
                ConfigurationManager.ConnectionStrings["MedicalConnectionString"].ConnectionString;
       
        public int id;
        public Customermaster(Medical_store.Mdi_parent1 parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
        }

        private void Customermaster_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'medicalDataSet3._Customer_Master' table. You can move, or remove it, as needed.
            //   this.customer_MasterTableAdapter.Fill(this.medicalDataSet3._Customer_Master);
            try
            {
                // TODO: This line of code loads data into the 'medicalDataSet1.Stock' table. You can move, or remove it, as needed.
                //this.stockTableAdapter.Fill(this.medicalDataSet1.Stock);
                // TODO: This line of code loads data into the 'medicalDataSet._Item_master' table. You can move, or remove it, as needed.
                // this.item_masterTableAdapter.Fill(this.medicalDataSet._Item_master);


                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";


                SqlConnection con = new SqlConnection(ConnectionString);
               
                con.Open();

                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Customermaster]", con);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                int b = (dt.Rows.Count);
                b++;
                textBox1.Text = b.ToString();
                con.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //new button
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Customer-Master]", con);
            DataSet ds = new DataSet();
            adptr.Fill(ds);
            DataTable dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            int b = (dt.Rows.Count);
            b++;
            textBox1.Text = b.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //insert
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
               
                con.Open();


                //insert query  
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //cmd.CommandText = "INSERT INTO supplier-master VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                cmd.CommandText = "INSERT INTO [Customermaster] VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully added", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmd.Connection.Close();

                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Customermaster]", con);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                int b = (dt.Rows.Count);
                b++;
                textBox1.Text = b.ToString();


            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
            finally
            {
                //textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //update
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();

                //update query  
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE [Customermaster] SET [CustomerId]='" + textBox1.Text + "',[CustomerName]='" + textBox2.Text + "',[Address]= '" + textBox3.Text + "',[City] = '" + textBox4.Text + "',[MobileNo] = '" + textBox5.Text + "',[PhoneNo] = '" + textBox6.Text + "' WHERE  [CustomerId]= '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully updated", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Connection.Close();

                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Customermaster]", con);
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

        private void button5_Click(object sender, EventArgs e)
        {
            //delete query 
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();


                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;


                cmd.CommandText = "select * from [Customermaster] ";
                DialogResult result = MessageBox.Show("Do You Really Want TO Delete This Record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    textBox1.Focus();
                }
                else
                {
                    cmd.CommandText = "DELETE FROM [Customermaster]  WHERE [CustomerId]= '" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Selected Record is deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                cmd.Connection.Close();

                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Customermaster]", con);
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

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Next button
            try
            {

                SqlConnection con = new SqlConnection(ConnectionString);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlDataAdapter adptr = new SqlDataAdapter("Select * From [Customer-Master]", con);

                DataSet ds = new DataSet();

                adptr.Fill(ds);

                DataTable dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0] = (i + 1);
                }
                id = int.Parse(textBox1.Text);
                id = id + 1;
                if (id <= dt.Rows.Count)
                {
                   // button2.Enabled = true;
                    //button10.Enabled = true;

                    textBox1.Text = (dt.Rows[id - 1][0]).ToString();
                    textBox2.Text = (dt.Rows[id - 1][1]).ToString();
                    textBox3.Text = (dt.Rows[id - 1][2]).ToString();
                    textBox4.Text = (dt.Rows[id - 1][3]).ToString();
                    textBox5.Text = (dt.Rows[id - 1][4]).ToString();
                    textBox6.Text = (dt.Rows[id - 1][5]).ToString();

                    //textBox1.Focus();
                    con.Close();
                }
                else
                {
                    //button2.Enabled = false;
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Last button
            try
            {

                SqlConnection con = new SqlConnection(ConnectionString);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlDataAdapter adptr = new SqlDataAdapter("Select * From [Customer-Master]", con);

                DataSet ds = new DataSet();

                adptr.Fill(ds);

                DataTable dt = ds.Tables[0];
                int id = dt.Rows.Count;
                id--;
                if (id == 0)
                {
                    MessageBox.Show("Database is Empty");
                }
                else
                {
                   // button8.Enabled = true;
                    //button9.Enabled = true;
                    textBox1.Text = (dt.Rows[id][0]).ToString();
                    textBox2.Text = (dt.Rows[id][1]).ToString();
                    textBox3.Text = (dt.Rows[id][2]).ToString();
                    textBox4.Text = (dt.Rows[id][3]).ToString();
                    textBox5.Text = (dt.Rows[id][4]).ToString();
                    textBox6.Text = (dt.Rows[id][5]).ToString();
                    con.Close();
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //first button
            try
            {

                SqlConnection con = new SqlConnection(ConnectionString);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlDataAdapter adptr = new SqlDataAdapter("Select * From [Customer-Master]", con);

                DataSet ds = new DataSet();

                adptr.Fill(ds);

                DataTable dt = ds.Tables[0];
                int id = dt.Rows.Count;
                id--;
                if (id == 0)
                {
                    MessageBox.Show("Database is Empty");
                }
                else
                {
                   // button9.Enabled = true;
                   // button8.Enabled = true;
                    textBox1.Text = (dt.Rows[0][0]).ToString();
                    textBox2.Text = (dt.Rows[0][1]).ToString();
                    textBox3.Text = (dt.Rows[0][2]).ToString();
                    textBox4.Text = (dt.Rows[0][3]).ToString();
                    textBox5.Text = (dt.Rows[0][4]).ToString();
                    textBox6.Text = (dt.Rows[0][5]).ToString();
                    con.Close();
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //previous buttom
            try
            {

                SqlConnection con = new SqlConnection(ConnectionString);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlDataAdapter adptr = new SqlDataAdapter("Select * From [Customer-Master]", con);

                DataSet ds = new DataSet();

                adptr.Fill(ds);

                DataTable dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0] = (i + 1);
                }
                id = int.Parse(textBox1.Text);
                id = id - 1;
                if (id > 0)
                {
                    //button2.Enabled = true;
                    //button10.Enabled = true;

                    textBox1.Text = (dt.Rows[id - 1][0]).ToString();
                    textBox2.Text = (dt.Rows[id - 1][1]).ToString();
                    textBox3.Text = (dt.Rows[id - 1][2]).ToString();
                    textBox4.Text = (dt.Rows[id - 1][3]).ToString();
                    textBox5.Text = (dt.Rows[id - 1][4]).ToString();
                    textBox6.Text = (dt.Rows[id - 1][5]).ToString();



                    //textBox1.Focus();
                    con.Close();
                }
                else
                {
                    //button10.Enabled = false;
                }
            }

            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[5].Value.ToString();
        }
    }
}
