﻿using System;
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
    public partial class PurchaseReg : Form
    {
        string ConnectionString =
                ConfigurationManager.ConnectionStrings["MedicalConnectionString"].ConnectionString;
        public PurchaseReg(Medical_store.Mdi_parent1 parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
        }

        private void PurchaseReg_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'medicalDataSet5._Purchase_Final' table. You can move, or remove it, as needed.
           // this.purchase_FinalTableAdapter.Fill(this.medicalDataSet5._Purchase_Final);

            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            SqlDataAdapter adptr1 = new SqlDataAdapter("SELECT * FROM [Purchase-Final]", con);
            DataSet ds1 = new DataSet();
            adptr1.Fill(ds1);
            DataTable dt1 = ds1.Tables[0];
            dataGridView1.DataSource = dt1;

            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Total AMT
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                

                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand(ConnectionString);

                cmd.Connection = con;
                cmd.CommandText = "select [Bill-No],Date,[Party-Name],[Total-Net-AMT],[Total-Vat-AMT],[Total-AMT] FROM [Purchase-Final]";
                SqlDataReader dar = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(dar);

                dataGridView1.DataSource = dt;
                var p = dataGridView1.Rows.Count;

                double total = 0;
                
                for (int i = 0; i+1 < dataGridView1.Rows.Count; i++)
                {

                   
                    total += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value.ToString().Trim());
                    
                    //textBox1.Text = total.ToString().Trim();
                   

                }
                textBox1.Text = total.ToString().Trim();
                con.Close();
            }
            catch (Exception S)
            {
                MessageBox.Show(S.Message);
            }

        }
    }
}
