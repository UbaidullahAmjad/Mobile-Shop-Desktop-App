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
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCompany_TextChanged(object sender, EventArgs e)
        {
            if (txtCompany.Text == "")
            {
            }
            else
            {
                dataGridView1.Rows.Clear();
                string conStr = "Data Source=HP-430\\SQLEXPRESS;Initial Catalog=ProjMobileMgmtSys;Integrated Security=True";
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                string query = "select Company, Model, Qty, Price, Description from Product where Model like '" + txtCompany.Text + "%'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    dataGridView1.Rows.Add(sdr["Company"], sdr["Model"], sdr["Qty"], sdr["Price"], sdr["Description"]);
                }
                con.Close();

            }

            //string query = "select * from Product";
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //sda.Fill(ds);
            //con.Close();
            //dataGridView1.Rows.Clear();
            //DataRow[] dr =ds.Tables[0].Select("Company like '" +txtCompany.Text +"'");
            //foreach (DataRow d in dr)
            //{
            //    dataGridView1.Rows.Add(d["Company"], d["Model"], d["Qty"], d["Price"], d["Company"]);
            //}

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashBoard db = new DashBoard();
            db.ShowDialog();
        }

        private void aDDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADDProduct ad = new ADDProduct();
            ad.ShowDialog();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {

                double pr = Convert.ToDouble(txtPrice.Text);
                dataGridView1.Rows.Clear();
                string conStr = "Data Source=HP-430\\SQLEXPRESS;Initial Catalog=ProjMobileMgmtSys;Integrated Security=True";
                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                string query = "select Company, Model, Qty, Price, Description from Product where Price <= '" + pr + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    dataGridView1.Rows.Add(sdr["Company"], sdr["Model"], sdr["Qty"], sdr["Price"], sdr["Description"]);
                }
                con.Close();
            }
            catch (Exception ex) {
                MessageBox.Show("An Error Occured");
            }
        }

        private void View_Load(object sender, EventArgs e)
        {
            string conStr = "Data Source=HP-430\\SQLEXPRESS;Initial Catalog=ProjMobileMgmtSys;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string query = "select Company from Product";
            //string query1 = "select Model from Product";
            SqlCommand cmd = new SqlCommand(query, con);
            
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                TreeNode obj = treeView1.Nodes.Add(sdr["Company"].ToString());
             //   TreeNode obj1 = treeView1.Nodes[obj]
            }
            con.Close();


        }
    }
}
