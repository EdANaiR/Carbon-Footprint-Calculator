using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace KarbonAyakİziHesaplayıcı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=KarBonProjesi.mdb");
                baglanti.Open();
                OleDbCommand sorgu = new OleDbCommand("select kAd, kSifre from kullaniciİslemleri where kAd=@ad and kSifre=@sifre", baglanti);
                sorgu.Parameters.AddWithValue("@ad", textBox1.Text);
                sorgu.Parameters.AddWithValue("@sifre", textBox2.Text);
                OleDbDataReader dr;
                dr = sorgu.ExecuteReader();

                if (dr.Read())
                {
                    Form3 form3 = new Form3();
                    form3.Show();
                    
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Yanlış Şifre!");
                }
            }

            catch
            {
                MessageBox.Show("Lütfen Kullanıcı Adı ve Parola İle Giriş Yapınız!");
            }
            finally
            {
                textBox1.Clear();
                textBox2.Clear();
            }


        }

       
    }
}
