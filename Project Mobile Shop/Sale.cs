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
    public partial class Sale : Form
    {
        public Sale()
        {
            InitializeComponent();
        }

        private void comboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            string conStr = "Data Source=HP-430\\SQLEXPRESS;Initial Catalog=ProjMobileMgmtSys;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string query = "select Company from Product";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {

                comboCompany.Items.Add(sdr["Company"].ToString());
            }
            con.Close();
        }

        private void comboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string conStr = "Data Source=HP-430\\SQLEXPRESS;Initial Catalog=ProjMobileMgmtSys;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string query = "select  Price, Description from Product where Model='" + comboModel.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                //comboModel.Items.Add(sdr["Model"].ToString());
                tbPrice.Text = sdr["Price"].ToString();
                RichTBDesc.Text = sdr["Description"].ToString();
            }
            con.Close();
            //comboModel.Items.Clear();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            string conStr = "Data Source=HP-430\\SQLEXPRESS;Initial Catalog=ProjMobileMgmtSys;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string query = "select Model from Product where Company='"+comboCompany.SelectedItem+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                
                comboModel.Items.Add(sdr["Model"].ToString());
                //tbPrice.Text = sdr["Price"].ToString();
                //RichTBDesc.Text = sdr["Description"].ToString();
                
            }
            con.Close();
            
        }
        double NT = 0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            double price = Convert.ToDouble(tbPrice.Text);
            double qty = Convert.ToDouble(Nqty.Value);
            double ans = price * qty;
            dataGridView1.Rows.Add(comboCompany.Text, comboModel.Text, tbPrice.Text, Nqty.Value, ans.ToString());
            NT = NT + ans;
            txtTotal.Text = NT.ToString();
            string conStr = "Data Source=HP-430\\SQLEXPRESS;Initial Catalog=ProjMobileMgmtSys;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string query = "insert into Bill values ('" + comboCompany.Text + "', '" + comboModel.Text + "', '" + tbPrice.Text + "', '" + Nqty.Value + "', '" + txtTotal.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            //MessageBox.Show("Data Inserted");
            comboCompany.Text = "";
            comboModel.Text = "";
            tbPrice.Text = "";
            Nqty.Value = 0;
            RichTBDesc.Text = "";
            comboModel.Items.Clear();
            }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            
            Customer cm = new Customer();
            cm.ShowDialog();

        }

        private void btnClr_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RichTBDesc.Text = "";
            tbPrice.Text = "";
            txtTotal.Text = "";
            comboCompany.Text = "";
            comboModel.Text = "";
        }
    }
}
