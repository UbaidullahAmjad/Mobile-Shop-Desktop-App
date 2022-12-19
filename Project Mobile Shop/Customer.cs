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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        DataSet ds = new DataSet();
        private void Customer_Load(object sender, EventArgs e)
        {
            string conStr = "Data Source=HP-430\\SQLEXPRESS;Initial Catalog=ProjMobileMgmtSys;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string query = "select BCompany, BModel, BPrice, BQty, BTotal from Bill ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            con.Close();
            dataGridView1.DataSource = ds.Tables[0];
            //
            string conStr1 = "Data Source=HP-430\\SQLEXPRESS;Initial Catalog=ProjMobileMgmtSys;Integrated Security=True";
            SqlConnection con1 = new SqlConnection(conStr1);
            con1.Open();
            string query1 = "select BTotal from Bill";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            SqlDataReader sdr = cmd1.ExecuteReader();
            while (sdr.Read())
            {
                textBox1.Text = sdr["BTotal"].ToString();
            }
            con1.Close();

            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            string conStr1 = "Data Source=HP-430\\SQLEXPRESS;Initial Catalog=ProjMobileMgmtSys;Integrated Security=True";
            SqlConnection con1 = new SqlConnection(conStr1);
            con1.Open();
            string query1 = "insert into Customer1 values ('" + tbName.Text + "','" + tbCNIC.Text + "', '" + tbAdds.Text + "',  '" + textBox1.Text + "')";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.ExecuteNonQuery();
            con1.Close();
            
            
            //MessageBox.Show("Data Added");

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            
            if (tbCNIC.Text=="")
            {
                   MessageBox.Show("Enter Customer Data First....");
            }
            else
            {
                string conStr = "Data Source=HP-430\\SQLEXPRESS;Initial Catalog=ProjMobileMgmtSys;Integrated Security=True";
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                string query = "delete from Bill";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Random r1 = new Random();
            string count = r1.Next(15000, 99000).ToString();
            string m = "ES Z- ";
            MessageBox.Show("Your Order has been Placed..." + m + count);
        }
    }
}
