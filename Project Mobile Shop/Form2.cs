using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_Mobile_Shop
{
    public partial class ADDProduct : Form
    {
        public ADDProduct()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var home = new DashBoard();
            home.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string conStr = "Data Source=HP-430\\SQLEXPRESS;Initial Catalog=ProjMobileMgmtSys;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            string query = "insert into Product values ('" + cbCompany.SelectedItem + "','" + tbModel.Text + "', '" + NQty.Value + "', '" + tbPrice.Text + "' , '" + rtbProp.Text + "' )";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Added");


        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
