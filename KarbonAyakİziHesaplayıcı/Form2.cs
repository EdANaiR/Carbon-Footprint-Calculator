using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.OleDb;

namespace KarbonAyakİziHesaplayıcı
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
            

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=KarBonProjesi.mdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("INSERT INTO kullaniciİslemleri (kAd, kSifre) VALUES (@ad, @sifre)", baglanti);
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@sifre", textBox2.Text);
            komut.ExecuteNonQuery();

            MessageBox.Show("Başarıyla Kayıt Olundu!");
            textBox1.Clear();
            textBox2.Clear();
            Form1 form1 = new Form1();
            form1.Show();

            this.Close();



        }
    }
    
}
