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
    public partial class Track : Form
    {
        public Track()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           // webBrowser1.Url = new Uri("https://www.tcsexpress.com/");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Track_Load(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri("https://www.google.com");

        }
    }
}
