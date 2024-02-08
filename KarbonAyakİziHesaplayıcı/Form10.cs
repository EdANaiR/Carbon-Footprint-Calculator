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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        OleDbConnection veri_baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=KarBonProjesi.mdb");
        OleDbDataAdapter veri_adaptor;
        DataSet veri_seti;
        OleDbCommand veri_komutu;
        OleDbDataReader veri_oku;

        void veri_Listele(string tablo)
        {
            veri_adaptor = new OleDbDataAdapter("Select * from " + tablo, veri_baglanti);
            veri_seti = new DataSet();
            veri_baglanti.Open();
        }

        void veri_kapat()
        {
            veri_baglanti.Close();
        }

        void Tablo_Veri_Getir(string s)
        {
            veri_Listele(s);
            veri_adaptor.Fill(veri_seti, s);
            dataGridView1.DataSource = veri_seti.Tables[s];
            veri_kapat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tablo_Veri_Getir("İcerik");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            veri_komutu = new OleDbCommand();
            veri_baglanti.Open();
            veri_komutu.Connection = veri_baglanti;
            veri_komutu.CommandText = "INSERT INTO İcerik (geriDönüsüm, kvSaat, dogalgazTüketim, kargoMiktari, yakitTürü) " +
                "VALUES (@geriDonusum, @kvSaat, @dogalgazTuketim, @kargoMiktari, @yakitTuru)";

            
            veri_komutu.Parameters.AddWithValue("@geriDonusum", checkBox1.Checked);
            veri_komutu.Parameters.AddWithValue("@kvSaat", Convert.ToInt32(textBox1.Text));
            veri_komutu.Parameters.AddWithValue("@dogalgazTuketim", Convert.ToInt32(textBox2.Text));
            veri_komutu.Parameters.AddWithValue("@kargoMiktari", Convert.ToInt32(textBox3.Text));
            veri_komutu.Parameters.AddWithValue("@yakitTuru", textBox4.Text);

            veri_komutu.ExecuteNonQuery();
            veri_baglanti.Close();
            Tablo_Veri_Getir("İcerik");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";



        }

       

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            checkBox1.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[1].Value);
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            veri_komutu = new OleDbCommand();
            veri_baglanti.Open();

            veri_komutu.Connection = veri_baglanti;
            veri_komutu.CommandText = "Delete from İcerik where ID='" + textBox5.Text + "'";

            veri_komutu.ExecuteNonQuery();
            veri_baglanti.Close();
            Tablo_Veri_Getir("İcerik");
        }
    }
    
}
