using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_Mobile_Shop
{
    public partial class Record : Form
    {
        public Record()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        private void Record_Load(object sender, EventArgs e)
        {

            string conStr = "Data Source=HP-430\\SQLEXPRESS;Initial Catalog=ProjMobileMgmtSys;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string query = "select * from Customer1 ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            con.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
