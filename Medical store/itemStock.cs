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
    public partial class itemStock : Form
    {
        string ConnectionString =
                ConfigurationManager.ConnectionStrings["MedicalConnectionString"].ConnectionString;
        public itemStock(Medical_store.Mdi_parent1 parent)
        {
            InitializeComponent();
            this.MdiParent = parent;
        }

        private void itemStock_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'medicalDataSet1.Stock' table. You can move, or remove it, as needed.
          //  this.stockTableAdapter.Fill(this.medicalDataSet1.Stock);
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlDataAdapter adptr2 = new SqlDataAdapter("SELECT * FROM [Stock]", con);
            DataSet ds2 = new DataSet();
            adptr2.Fill(ds2);
            DataTable dt2 = ds2.Tables[0];
            dataGridView1.DataSource = dt2;

            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
