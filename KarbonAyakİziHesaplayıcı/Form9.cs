using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarbonAyakİziHesaplayıcı
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }


        private double karbonSalinimi;
        public Form9(double karbonSalinimi)
        {
            InitializeComponent();
            this.karbonSalinimi = karbonSalinimi;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            label1.Text = karbonSalinimi.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10();
            frm10.Show();
            this.Close();

        }
    }
}
