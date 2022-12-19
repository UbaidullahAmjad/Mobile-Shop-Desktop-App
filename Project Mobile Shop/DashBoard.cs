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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        private void moveslidepanel(Control btn)
        {
            panelSlide.Top = btn.Top;
            panelSlide.Height = btn.Height;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            moveslidepanel(btnHome);
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            moveslidepanel(btnSale);
            Sale form1 = new Sale();
            form1.ShowDialog();
        }

        private void btnAddP_Click(object sender, EventArgs e)
        {
            moveslidepanel(btnAddP);
            ADDProduct AP = new ADDProduct();
            AP.ShowDialog();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            moveslidepanel(btnView);
            View vm = new View();
            vm.ShowDialog();
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            moveslidepanel(btnExp);
            Record m = new Record();
            m.ShowDialog();

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            moveslidepanel(btnUser);
            Track m = new Track();
            m.ShowDialog();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            moveslidepanel(btnSetting);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
