using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_Mobile_Shop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string user = "Kazmi@BIIT";
        string pwd = "abc";

        private void txtUser_MouseLeave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "User Name";
            }
        }

        private void txtUser_MouseEnter(object sender, EventArgs e)
        {
            if (txtUser.Text == "User Name")
            {
                txtUser.Text = "";
            }
        }

        private void cbSeePwd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSeePwd.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == user && txtPassword.Text == pwd)
            {
                DashBoard dash = new DashBoard();
                dash.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect Password....");
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "123456";
            }
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "123456")
            {
                txtPassword.Text = "";
            }
        }
    }
}
