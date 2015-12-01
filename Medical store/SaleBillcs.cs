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
    public partial class SaleBill : Form
    {
        string ConnectionString =
                ConfigurationManager.ConnectionStrings["MedicalConnectionString"].ConnectionString;
        public int id;
        public string st1, st;
        public SaleBill(Medical_store.Mdi_parent1 parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
        }

        private void SaleBill_Load(object sender, EventArgs e)
        {
            this.LoadCompanyCombo();
            this.LoadItemIdCombo();
            // TODO: This line of code loads data into the 'medicalDataSet._Item_master' table. You can move, or remove it, as needed.
            // this.item_masterTableAdapter.Fill(this.medicalDataSet._Item_master);
            // TODO: This line of code loads data into the 'medicalDataSet2._supplier_master' table. You can move, or remove it, as needed.
            //this.supplier_masterTableAdapter.Fill(this.medicalDataSet2._supplier_master);
            // TODO: This line of code loads data into the 'medicalDataSet1.Stock' table. You can move, or remove it, as needed.
            // this.stockTableAdapter.Fill(this.medicalDataSet1.Stock);
            // TODO: This line of code loads data into the 'medicalDataSet5._Purchase_Final' table. You can move, or remove it, as needed.
            //this.purchase_FinalTableAdapter.Fill(this.medicalDataSet5._Purchase_Final);
            // TODO: This line of code loads data into the 'medicalDataSet5.Purchase' table. You can move, or remove it, as needed.
            //this.purchaseTableAdapter.Fill(this.medicalDataSet5.Purchase);

            // dataGridView2.Hide();
            textBox10.Text = "";
            comboBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox11.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";



            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();
            SqlDataAdapter adptr1 = new SqlDataAdapter("SELECT * FROM [Sales-Final]", con);
            DataSet ds1 = new DataSet();
            adptr1.Fill(ds1);
            DataTable dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
            int b = (dt1.Rows.Count);
            b++;
            textBox1.Text = b.ToString();

            con.Close();

            con.Open();
            SqlDataAdapter adptr2 = new SqlDataAdapter("SELECT * FROM [Stock]", con);
            DataSet ds2 = new DataSet();
            adptr2.Fill(ds2);
            DataTable dt2 = ds2.Tables[0];
            dataGridView2.DataSource = dt2;

            con.Close();

        }
        void LoadCompanyCombo()
        {

            // string Query = "select CompanyName from Company";

            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT CompanyName FROM Company";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<string> myList = new List<string>();
            while (reader.Read())
            {
                myList.Add(reader["CompanyName"].ToString());
            }
            connection.Close();

            comboBox2.DataSource = myList;
        }

        void LoadItemIdCombo()
        {

            // string Query = "select CompanyName from Company";

            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT ItemId FROM Itemmaster";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<string> myList = new List<string>();
            while (reader.Read())
            {
                myList.Add(reader["ItemId"].ToString());
            }
            connection.Close();

            comboBox3.DataSource = myList;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Clear Button
            textBox2.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox11.Text = "";

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM Sales", con);
            DataSet ds = new DataSet();
            adptr.Fill(ds);
            DataTable dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            int b = (dt.Rows.Count);
            b++;
            textBox2.Text = b.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //add button
            //insert into purchase query update into stock 
            //try
            //{
            //    
            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();


            //insert into purchase
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;


            cmd.CommandText = "SELECT [Company-Name],[Item-id],[Sale-QTY],[Purchase-QTY],[Available-QTY] FROM Stock WHERE [Item-id]='" + comboBox3.Text + "'";
            SqlDataReader dar = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dar);

            dataGridView2.DataSource = dt;

            int q3 = 0, q1, q2, q4, q5 = 0;
            q1 = int.Parse(textBox5.Text);


            q2 = Convert.ToInt32(dataGridView2.Rows[0].Cells[3].Value.ToString().Trim());
            if (q2 <= 5)
            {
                MessageBox.Show("out of stock item");
            }
            q3 = q1 + q2;
            q4 = Convert.ToInt32(dataGridView2.Rows[0].Cells[4].Value.ToString().Trim());
            q5 = q4 - q1;


            cmd.CommandText = "UPDATE Stock SET [Company-Name] ='" + comboBox2.Text + "', [Item-id] ='" + comboBox3.Text + "',  [Sale-QTY] ='" + q3 + "',[Available-QTY]='" + q5 + "' WHERE [Item-id] ='" + comboBox3.Text + "'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Sales VALUES('" + textBox1.Text + "','" + textBox10.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox11.Text + "')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record is succesfully added", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            SqlDataAdapter adptr = new SqlDataAdapter("SELECT [Bill-No],Date,[Party-Name],[Sr.No],[Company-Name],[Model-Id],Prize,Vat,Qty,[Total-vat],[Total-Prize] FROM Sales WHERE [Bill-No]='" + textBox1.Text + "'", con);
            DataSet ds = new DataSet();
            adptr.Fill(ds);
            DataTable dt1 = ds.Tables[0];
            dataGridView1.DataSource = dt1;
            //dataGridView1.Rows.Add(dt1);
            textBox2.Text = (dt1.Rows.Count + 1).ToString()
        ;
            cmd.Connection.Close();

            LoadDataGridStock();

            //}
            //catch (Exception S)
            //{
            //    MessageBox.Show(S.Message);
            //}
        }

        private void LoadDataGridStock()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlDataAdapter adptr2 = new SqlDataAdapter("SELECT * FROM [Stock]", con);
            DataSet ds2 = new DataSet();
            adptr2.Fill(ds2);
            DataTable dt2 = ds2.Tables[0];
            dataGridView2.DataSource = dt2;

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //delete from Sales
            //update into stock
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();

                //delete query  
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Sales";
                DialogResult result = MessageBox.Show("Do You Really Want TO Delete This Record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    textBox2.Focus();
                }
                else
                {

                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;


                    cmd.CommandText = "SELECT [Company-Name],[Item-id],[Sale-QTY],[Purchase-QTY],[Available-QTY] FROM Stock WHERE [Item-id]='" + comboBox3.Text + "'";
                    SqlDataReader dar = cmd.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(dar);

                    dataGridView2.DataSource = dt;

                    int q3 = 0, q1, q2, q4, q5 = 0;
                    q1 = int.Parse(textBox5.Text);


                    q2 = Convert.ToInt32(dataGridView2.Rows[0].Cells[2].Value.ToString().Trim());
                    q3 = q2 - q1;
                    q4 = Convert.ToInt32(dataGridView2.Rows[0].Cells[4].Value.ToString().Trim());
                    q5 = q4 + q1;


                    cmd.CommandText = "UPDATE Stock SET [Company-Name] ='" + comboBox2.Text + "', [Item-id] ='" + comboBox3.Text + "', [Sale-QTY] ='" + q3 + "',[Available-QTY]='" + q5 + "' WHERE [Item-id] ='" + comboBox3.Text + "'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM Sales WHERE [Bill-No]= '" + textBox1.Text + "' AND [Sr.No] = '" + textBox2.Text + "' AND [Model-Id]='" + comboBox3.Text + "'";
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Selected Record is deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //next button
            try
            {

                SqlConnection con = new SqlConnection(ConnectionString);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlDataAdapter adptr = new SqlDataAdapter("Select * From Sales Where [Bill-No]='" + textBox1.Text + "'", con);

                DataSet ds = new DataSet();

                adptr.Fill(ds);

                DataTable dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0] = (i + 1);
                }
                id = int.Parse(textBox2.Text);
                id = id + 1;
                if (id <= dt.Rows.Count)
                {
                    //button12.Enabled = true;
                    //button11.Enabled = true;

                    textBox10.Text = (dt.Rows[id - 1][1]).ToString();
                    comboBox1.Text = (dt.Rows[id - 1][2]).ToString();
                    textBox2.Text = (dt.Rows[id - 1][3]).ToString();
                    comboBox2.Text = (dt.Rows[id - 1][4]).ToString();
                    comboBox3.Text = (dt.Rows[id - 1][5]).ToString();
                    textBox3.Text = (dt.Rows[id - 1][6]).ToString();
                    textBox4.Text = (dt.Rows[id - 1][7]).ToString();
                    textBox5.Text = (dt.Rows[id - 1][8]).ToString();
                    textBox6.Text = (dt.Rows[id - 1][9]).ToString();
                    textBox11.Text = (dt.Rows[id - 1][10]).ToString();


                    //textBox1.Focus();
                    con.Close();
                }
                else
                {
                    //button12.Enabled = false;
                }
            }
            catch (Exception s)
            {
                //MessageBox.Show(s.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Previous button
            try
            {

                SqlConnection con = new SqlConnection(ConnectionString);
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlDataAdapter adptr = new SqlDataAdapter("Select * From Sales Where [Bill-No]='" + textBox1.Text + "'", con);

                DataSet ds = new DataSet();

                adptr.Fill(ds);

                DataTable dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0] = (i + 1);
                }
                id = int.Parse(textBox2.Text);
                id = id - 1;
                if (id <= dt.Rows.Count)
                {
                    //button12.Enabled = true;
                    //button11.Enabled = true;

                    textBox10.Text = (dt.Rows[id - 1][1]).ToString();
                    comboBox1.Text = (dt.Rows[id - 1][2]).ToString();
                    textBox2.Text = (dt.Rows[id - 1][3]).ToString();
                    comboBox2.Text = (dt.Rows[id - 1][4]).ToString();
                    comboBox3.Text = (dt.Rows[id - 1][5]).ToString();
                    textBox3.Text = (dt.Rows[id - 1][6]).ToString();
                    textBox4.Text = (dt.Rows[id - 1][7]).ToString();
                    textBox5.Text = (dt.Rows[id - 1][8]).ToString();
                    textBox6.Text = (dt.Rows[id - 1][9]).ToString();
                    textBox11.Text = (dt.Rows[id - 1][10]).ToString();
                    con.Close();
                }
                else
                {
                   // button11.Enabled = false;
                }
            }
            catch (Exception s)
            {
                //MessageBox.Show(s.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //total priz
            
            
            
             st = ((float.Parse(textBox3.Text) * (float.Parse(textBox5.Text))) + ((((float.Parse(textBox4.Text)) / 100) * (float.Parse(textBox3.Text))) * (float.Parse(textBox5.Text)))).ToString();
            textBox11.Text = st;
             st1 = (float.Parse(textBox3.Text) * ((float.Parse(textBox4.Text)) / 100) * (float.Parse(textBox5.Text))).ToString();
            textBox6.Text = st1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //total amt
            //Total Vat AMT
            //Total Net AMT

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);

                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                cmd.CommandText = "select [Bill-No],Date,[Party-Name],[Sr.No],[Company-Name],[Model-Id],Prize,Vat,Qty,[Total-vat],[Total-Prize] from Sales Where [Bill-No]='" + int.Parse(textBox1.Text) + "'";
                SqlDataReader dar = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(dar);

                dataGridView1.DataSource = dt;

                double total = 0;
                double total1 = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    total1 += Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value.ToString().Trim());
                    total += Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value.ToString().Trim());
                    textBox8.Text = total1.ToString().Trim();
                    textBox7.Text = total.ToString().Trim();
                    textBox9.Text = (double.Parse(textBox7.Text) - double.Parse(textBox8.Text)).ToString();

                }

                con.Close();
            }
            catch (Exception S)
            {
                MessageBox.Show(S.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //new button
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox11.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();
            SqlDataAdapter adptr1 = new SqlDataAdapter("SELECT * FROM [Sales-Final]", con);
            DataSet ds1 = new DataSet();
            adptr1.Fill(ds1);
            DataTable dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
            int b = (dt1.Rows.Count);
            b++;
            textBox1.Text = b.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Save button
            //insert into [Sales-Final]
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();


                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO [Sales-Final] VALUES('" + textBox1.Text + "','" + textBox10.Text + "','" + comboBox1.Text + "','" + textBox9.Text + "','" + textBox8.Text + "','" + textBox7.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully added", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmd.Connection.Close();
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Sales-Final]", con);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;

                //textBox10.Text = "";
                comboBox1.Text = "";
                textBox2.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox11.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";

                con.Close();
            }
            catch (Exception s)
            {
                //MessageBox.Show(s.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //update query  [Sales-Final]
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();

                //update query  
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE [Sales-Final] SET [Bill-No]='" + textBox1.Text + "',Date='" + textBox10.Text + "', [Party-Name]='" + comboBox1.Text + "', [Total-Net-AMT]='" + textBox9.Text + "', [Total-Vat-AMT]='" + textBox8.Text + "', [Total-AMT]='" + textBox7.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully updated", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd.Connection.Close();



            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //delete query in [Sales-Final]
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();

                //delete query  
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [Sales-Final]";
                DialogResult result = MessageBox.Show("Do You Really Want TO Delete This Record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    textBox1.Focus();
                }
                else
                {
                    cmd.CommandText = "DELETE FROM [Sales-Final] WHERE [Bill-No]= '" + textBox1.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Selected Record is deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                cmd.Connection.Close();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string name = comboBox2.SelectedItem.ToString();
            string query = "SELECT * FROM Itemmaster";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<string> myList = new List<string>();
            string price = "";
            while (reader.Read())
            {
                if (reader["CompanyName"].ToString() == name)
                    myList.Add(reader["ItemId"].ToString());

            }


            comboBox3.DataSource = myList;

            reader.Close();
            connection.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string name = comboBox3.SelectedItem.ToString();
            string query = "SELECT * FROM Itemmaster";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<string> myList = new List<string>();
            string price = "";
            while (reader.Read())
            {
                if (reader["ItemId"].ToString() == name)
                    price = reader["Price"].ToString();

            }


            textBox3.Text = price;

            reader.Close();
            connection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;

                DataGridViewRow row = dataGridView1.Rows[i];
                textBox2.Text = row.Cells[0].Value.ToString();
                comboBox2.Text = row.Cells[1].Value.ToString();
                comboBox3.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                textBox4.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[6].Value.ToString();
                textBox11.Text = row.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
