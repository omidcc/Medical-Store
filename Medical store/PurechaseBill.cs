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
    public partial class PurechaseBill : Form
    {
        string ConnectionString =
                ConfigurationManager.ConnectionStrings["MedicalConnectionString"].ConnectionString;
        public string st, st1;
        public int id;
        
        public PurechaseBill(Medical_store.Mdi_parent1 parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
        }

        private void PurechaseBill_Load(object sender, EventArgs e)
        {
            try
            {


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
                partyNameTextBox.Text = "";
                //comboBox1.Text = "";
                serialTextBox.Text = "";
                companyComboBox.Text = "";
                itemComboBox.Text = "";
                priceTextBox.Text = "";
                vatTextBox.Text = "";
                quantityTextBox.Text = "";
                totalVatTextBox.Text = "";
                totalPriceTextBox.Text = "";
                totalAmountTextBox.Text = "";
                totalVatAmountTextBox.Text = "";
                totalNetAmountTextBox.Text = "";

                this.LoadCompanyCombo();
                this.LoadItemIdCombo();

                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();
               
                SqlDataAdapter adptr1 = new SqlDataAdapter("SELECT * FROM [Stock]", con);
                DataSet ds1 = new DataSet();
                adptr1.Fill(ds1);
                DataTable dt1 = ds1.Tables[0];
                dataGridView2.DataSource = dt1;
               
                SqlDataAdapter adptr2 = new SqlDataAdapter("select [Sr_No],[Company-Name],[Model-Id],Prize,Vat,Qty,[Total-vat],[Total-Prize] from Purchase", con);
                DataSet ds2 = new DataSet();
                adptr2.Fill(ds2);
                DataTable dt2 = ds2.Tables[0];
                dataGridView1.DataSource = dt2;
                int c = (dt1.Rows.Count);
                c++;
                billNoTextBox.Text = c.ToString();

                con.Close();

                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Clear Button
            serialTextBox.Text = "";
            companyComboBox.Text = "";
            itemComboBox.Text = "";
            priceTextBox.Text = "";
            vatTextBox.Text = "";
            quantityTextBox.Text = "";
            totalVatTextBox.Text = "";
            totalPriceTextBox.Text = "";

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM Purchase", con);
            DataSet ds = new DataSet();
            adptr.Fill(ds);
            DataTable dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
            int b = (dt.Rows.Count);
            b++;
            serialTextBox.Text = b.ToString();
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            //add button
            //insert into purchase query update into stock 
            //try
            //{
            SqlConnection con=new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "INSERT INTO  [Purchase] VALUES('"+billNoTextBox.Text+"','"+dateTextBox.Text+"','"+partyNameTextBox.Text+"','"+serialTextBox.Text+"','"+companyComboBox.SelectedItem+"','"+itemComboBox.SelectedItem+"','"+priceTextBox.Text+"','"+vatTextBox.Text+"','"+quantityTextBox.Text+"','"+totalVatTextBox.Text+"','"+totalPriceTextBox.Text+"')";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record is succesfully added", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
                   
                    SqlDataAdapter adptr = new SqlDataAdapter("select [Sr_No],[Company-Name],[Model-Id],Prize,Vat,Qty,[Total-vat],[Total-Prize] from Purchase", con);
                    DataSet ds = new DataSet();
                    adptr.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    dataGridView1.DataSource = dt;
                    int b = (dt.Rows.Count);
                    b++;
                    serialTextBox.Text = b.ToString();

            
            con.Close();
            //}
            //catch (Exception S)
            //{
            //    MessageBox.Show(S.Message);
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //delete from purchase
            //update into stock
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();

                //delete query  
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Purchase";
                DialogResult result = MessageBox.Show("Do You Really Want TO Delete This Record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    serialTextBox.Focus();
                }
                else
                {

                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;


                    cmd.CommandText = "SELECT [Company-Name],[Item-id],[Sale-QTY],[Purchase-QTY],[Available-QTY] FROM Stock WHERE [Item-id]='" + itemComboBox.Text + "'";
                    SqlDataReader dar = cmd.ExecuteReader();

                    DataTable dt = new DataTable();

                    dt.Load(dar);

                    dataGridView2.DataSource = dt;

                    int q3 = 0, q1, q2, q4, q5 = 0;
                    q1 = int.Parse(quantityTextBox.Text);


                    q2 = Convert.ToInt32(dataGridView2.Rows[0].Cells[3].Value.ToString().Trim());
                    q3 = q2 - q1;
                    q4 = Convert.ToInt32(dataGridView2.Rows[0].Cells[4].Value.ToString().Trim());
                    q5 = q4 - q1;


                    cmd.CommandText = "UPDATE Stock SET [Company-Name] ='" + companyComboBox.Text + "', [Item-id] ='" + itemComboBox.Text + "', [Purchase-QTY] ='" + q3 + "',[Available-QTY]='" + q5 + "' WHERE [Item-id] ='" + itemComboBox.Text + "'";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE FROM Purchase WHERE [Bill-No]= '" + billNoTextBox.Text + "' AND [Sr.No] = '" + serialTextBox.Text + "' AND [Model-Id]='" + itemComboBox.Text + "'";
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Selected Record is deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //cmd.CommandText = "select * from Purchase ";





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

                SqlDataAdapter adptr = new SqlDataAdapter("Select * From Purchase Where [Bill-No]='" + billNoTextBox.Text + "'", con);

                DataSet ds = new DataSet();

                adptr.Fill(ds);

                DataTable dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0] = (i + 1);
                }
                id = int.Parse(serialTextBox.Text);
                id = id + 1;
                if (id <= dt.Rows.Count)
                {
                    //button12.Enabled = true;
                    //button11.Enabled = true;

                    partyNameTextBox.Text = (dt.Rows[id - 1][1]).ToString();
                    //comboBox1.Text = (dt.Rows[id - 1][2]).ToString();
                    serialTextBox.Text = (dt.Rows[id - 1][3]).ToString();
                    companyComboBox.Text = (dt.Rows[id - 1][4]).ToString();
                    itemComboBox.Text = (dt.Rows[id - 1][5]).ToString();
                    priceTextBox.Text = (dt.Rows[id - 1][6]).ToString();
                    vatTextBox.Text = (dt.Rows[id - 1][7]).ToString();
                    quantityTextBox.Text = (dt.Rows[id - 1][8]).ToString();
                    totalVatTextBox.Text = (dt.Rows[id - 1][9]).ToString();
                    totalPriceTextBox.Text = (dt.Rows[id - 1][10]).ToString();


                    //textBox1.Focus();
                    con.Close();
                }
                else
                {
                   // button12.Enabled = false;
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

                SqlDataAdapter adptr = new SqlDataAdapter("Select * From Purchase Where [Bill-No]='" + billNoTextBox.Text + "'", con);

                DataSet ds = new DataSet();

                adptr.Fill(ds);

                DataTable dt = ds.Tables[0];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][0] = (i + 1);
                }
                id = int.Parse(serialTextBox.Text);
                id = id - 1;
                if (id <= dt.Rows.Count)
                {
                    //button12.Enabled = true;
                    //button11.Enabled = true;

                    partyNameTextBox.Text = (dt.Rows[id - 1][1]).ToString();
                   // comboBox1.Text = (dt.Rows[id - 1][2]).ToString();
                    serialTextBox.Text = (dt.Rows[id - 1][3]).ToString();
                    companyComboBox.Text = (dt.Rows[id - 1][4]).ToString();
                    itemComboBox.Text = (dt.Rows[id - 1][5]).ToString();
                    priceTextBox.Text = (dt.Rows[id - 1][6]).ToString();
                    vatTextBox.Text = (dt.Rows[id - 1][7]).ToString();
                    quantityTextBox.Text = (dt.Rows[id - 1][8]).ToString();
                    totalVatTextBox.Text = (dt.Rows[id - 1][9]).ToString();
                    totalPriceTextBox.Text = (dt.Rows[id - 1][10]).ToString();


                    //textBox1.Focus();
                    con.Close();
                }
                else
                {
                    //button11.Enabled = false;
                }
            }
            catch (Exception s)
            {
                //MessageBox.Show(s.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //total prize
            st = ((float.Parse(priceTextBox.Text) * (float.Parse(quantityTextBox.Text))) + ((((float.Parse(vatTextBox.Text)) / 100) * (float.Parse(priceTextBox.Text))) * (float.Parse(quantityTextBox.Text)))).ToString();
            totalPriceTextBox.Text = st;
            st1 = (float.Parse(priceTextBox.Text) * ((float.Parse(vatTextBox.Text)) / 100) * (float.Parse(quantityTextBox.Text))).ToString();
            totalVatTextBox.Text = st1;


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
                cmd.CommandText = "select [Bill-No],Date,[Party-Name],[Sr.No],[Company-Name],[Model-Id],Prize,Vat,Qty,[Total-vat],[Total-Prize] from Purchase Where [Bill-No]='" + int.Parse(billNoTextBox.Text) + "'";
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
                    totalVatAmountTextBox.Text = total1.ToString().Trim();
                    totalAmountTextBox.Text = total.ToString().Trim();
                    totalNetAmountTextBox.Text = (double.Parse(totalAmountTextBox.Text) - double.Parse(totalVatAmountTextBox.Text)).ToString();

                }

                con.Close();
            }
            catch (Exception S)
            {
                //MessageBox.Show(S.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //new button
            billNoTextBox.Text = "";
            //textBox10.Text = "";
           // comboBox1.Text = "";
            serialTextBox.Text = "";
            companyComboBox.Text = "";
            itemComboBox.Text = "";
            priceTextBox.Text = "";
            vatTextBox.Text = "";
            quantityTextBox.Text = "";
            totalVatTextBox.Text = "";
            totalPriceTextBox.Text = "";
            totalAmountTextBox.Text = "";
            totalVatAmountTextBox.Text = "";
            totalNetAmountTextBox.Text = "";

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();
            SqlDataAdapter adptr1 = new SqlDataAdapter("SELECT * FROM [Purchase-Final]", con);
            DataSet ds1 = new DataSet();
            adptr1.Fill(ds1);
            DataTable dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;
            int b = (dt1.Rows.Count);
            b++;
            billNoTextBox.Text = b.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Save button
            //insert into purchasefinal
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();


                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO  [Purchase-Final] VALUES('" + billNoTextBox.Text + "','" + partyNameTextBox.Text + "','" + //comboBox1.Text + "','" + totalNetAmountTextBox.Text + "','" + totalVatAmountTextBox.Text + "','" + totalAmountTextBox.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record is succesfully added", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmd.Connection.Close();
                SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Purchase-Final]", con);
                DataSet ds = new DataSet();
                adptr.Fill(ds);
                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;

                //textBox10.Text = "";
               // comboBox1.Text = "";
                serialTextBox.Text = "";
                companyComboBox.Text = "";
                itemComboBox.Text = "";
                priceTextBox.Text = "";
                vatTextBox.Text = "";
                quantityTextBox.Text = "";
                totalVatTextBox.Text = "";
                totalPriceTextBox.Text = "";
                totalAmountTextBox.Text = "";
                totalVatAmountTextBox.Text = "";
                totalNetAmountTextBox.Text = "";

                con.Close();
            }
            catch (Exception s)
            {
                //MessageBox.Show(s.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //update query  [Purchase-Final]
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();

                //update query  
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE [Purchase-Final] SET [Bill-No]='" + billNoTextBox.Text + "',Date='" + partyNameTextBox.Text + "', [Party-Name]='" + //comboBox1.Text + "', [Total-Net-AMT]='" + totalNetAmountTextBox.Text + "', [Total-Vat-AMT]='" + totalVatAmountTextBox.Text + "', [Total-AMT]='" + totalAmountTextBox.Text + "'";
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
            //delete query in [Purchase-Final]
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);

                con.Open();

                //delete query  
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [Purchase-Final]";
                DialogResult result = MessageBox.Show("Do You Really Want TO Delete This Record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    billNoTextBox.Focus();
                }
                else
                {
                    cmd.CommandText = "DELETE FROM [Purchase-Final] WHERE [Bill-No]= '" + billNoTextBox.Text + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Selected Record is deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }




                cmd.Connection.Close();

                //SqlDataAdapter adptr = new SqlDataAdapter("SELECT * FROM [Purchase-Final]", con);
                //DataSet ds = new DataSet();
                //adptr.Fill(ds);
                //DataTable dt = ds.Tables[0];
                //dataGridView1.DataSource = dt;

            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

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

            companyComboBox.DataSource = myList;
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

            itemComboBox.DataSource = myList;
        }
    }
}
