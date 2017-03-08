using System;
using System.Windows.Forms;

namespace LOGPaineldeControle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.AllowWebBrowserDrop = false;
            webBrowser1.Url = new Uri("http://loglogin.azurewebsites.net");
        }
    }
}
