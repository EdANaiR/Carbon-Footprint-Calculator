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
    public partial class Form11 : Form
    {
        

        
        public Form11()
        {
            InitializeComponent();


            if (tabControl1.TabPages.Count > 0)
            {
                tabControl1.TabPages.RemoveAt(0);
            }

        }





        double karbonSalinimi = 0;
        double atikMiktariTon = 1.0;
        double metanUretimPotansiyeli = 100.0;
        double metanToCO2E = 25.0;


        private void button2_Click(object sender, EventArgs e)
        {
            bool geriDonusum = false;

            if (radioButton1.Checked == true)
            {
                karbonSalinimi = 0;
                geriDonusum = true;
            }

            else if (radioButton2.Checked == true)
            {
                karbonSalinimi = atikMiktariTon * metanUretimPotansiyeli * metanToCO2E;
                geriDonusum = false;
                
            }

            SaveToDatabase(geriDonusum);


            int currentIndex = tabControl1.SelectedIndex;

            // Eğer son sayfa değilse bir sonraki sayfaya geç
            if (currentIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex = currentIndex + 1;
            }

            

        }

        private void SaveToDatabase(bool geriDonusum)
        {
            using (OleDbConnection connection = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=KarBonProjesi.mdb"))
            {
                connection.Open();

                string insertQuery = "INSERT INTO İcerik  (geriDönüsüm) VALUES (@geriDönüsüm)";
                using (OleDbCommand cmd = new OleDbCommand(insertQuery, connection))
                {            
                    cmd.Parameters.AddWithValue("@geriDönüsüm", geriDonusum);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        double elektrikFiyat = 1.13;
        double tutar = 0;
        double kvSaat = 0;


        private void button4_Click(object sender, EventArgs e)
        {


            try
            {
                if (double.TryParse(textBox1.Text, out tutar))
                {
                    kvSaat = tutar / elektrikFiyat;

                    SaveToDatabase(kvSaat);

                    karbonSalinimi += kvSaat * 0.623;
                }
                else
                {
                    MessageBox.Show("Geçersiz tutar girişi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }


            

            

            int currentIndex = tabControl1.SelectedIndex;

            // Eğer son sayfa değilse bir sonraki sayfaya geç
            if (currentIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex = currentIndex + 1;
            }
        }

        private void SaveToDatabase(double kvSaat)
        {
            using (OleDbConnection connection = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=KarBonProjesi.mdb"))
            {
                connection.Open();

                string insertQuery = "INSERT INTO İcerik (kvSaat) VALUES (@kvSaat)";
                using (OleDbCommand cmd = new OleDbCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@kvSaat", kvSaat);
                    cmd.ExecuteNonQuery();
                }
            }
        }


      

        double dogalgazFiyat = 4.63;
        double tutarr = 0;
        double kvSaatt = 0;

        private void button6_Click(object sender, EventArgs e)
        {


            try
            {
                if (double.TryParse(textBox2.Text, out tutarr))
                {
                    kvSaatt = tutarr / dogalgazFiyat;
                    SaveToDatabasee(kvSaatt); 
                }
                else
                {
                    MessageBox.Show("Geçersiz tutar girişi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }


            karbonSalinimi += kvSaatt * 0.215;



            int currentIndex = tabControl1.SelectedIndex;

            // Eğer son sayfa değilse bir sonraki sayfaya geç
            if (currentIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex = currentIndex + 1;
            }
        }


        private void SaveToDatabasee(double kvSaatt)
        {
            using (OleDbConnection connection = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=KarBonProjesi.mdb"))
            {
                connection.Open();

                string insertQuery = "INSERT INTO İcerik (dogalgazTüketim) VALUES (@dogalgazTüketim)";
                using (OleDbCommand cmd = new OleDbCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@dogalgazTüketim", kvSaatt);
                    cmd.ExecuteNonQuery();
                }
            }
        }









        int kargoKullanım;
        double ortgramKarbon = 404;


        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                double parsedValue;

                if (double.TryParse(textBox3.Text, out parsedValue))
                {
                    kargoKullanım = (int)parsedValue;

                    karbonSalinimi = kargoKullanım * ortgramKarbon;
                    SaveToDatabaseee(kargoKullanım);

                }
                else
                {
                    MessageBox.Show("Geçersiz tutar girişi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}");
            }


            int currentIndex = tabControl1.SelectedIndex;

            // Eğer son sayfa değilse bir sonraki sayfaya geç
            if (currentIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex = currentIndex + 1;
            }
        }

        private void SaveToDatabaseee(double kargoKullanım)
        {
            using (OleDbConnection connection = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=KarBonProjesi.mdb"))
            {
                connection.Open();

                string insertQuery = "INSERT INTO İcerik (kargoMiktari) VALUES (@kargoMiktari)";
                using (OleDbCommand cmd = new OleDbCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@kargoMiktari", kargoKullanım);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            int currentIndex = tabControl1.SelectedIndex;

            // Eğer ilk sayfa değilse bir önceki sayfaya geç
            if (currentIndex > 0)
            {
                tabControl1.SelectedIndex = currentIndex - 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int currentIndex = tabControl1.SelectedIndex;

            // Eğer ilk sayfa değilse bir önceki sayfaya geç
            if (currentIndex > 0)
            {
                tabControl1.SelectedIndex = currentIndex - 1;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int currentIndex = tabControl1.SelectedIndex;

            // Eğer ilk sayfa değilse bir önceki sayfaya geç
            if (currentIndex > 0)
            {
                tabControl1.SelectedIndex = currentIndex - 1;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int currentIndex = tabControl1.SelectedIndex;

            // Eğer ilk sayfa değilse bir önceki sayfaya geç
            if (currentIndex > 0)
            {
                tabControl1.SelectedIndex = currentIndex - 1;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string yakitTürü = "";

            if (radioButton5.Checked == true)
            {
                karbonSalinimi += 12 * 3.000;
                yakitTürü = "Dizel (Motorin)";


            }
            else if (radioButton4.Checked == true)
            {
                karbonSalinimi += 12 * 2.900;
                yakitTürü = "Benzin";
            }
            else if (radioButton3.Checked == true)
            {
                karbonSalinimi += 35;
                yakitTürü = "Elektrik";
            }

            SaveToDatabaseeee(yakitTürü);

            Form9 form9 = new Form9();
            form9.Owner = this;
            form9.Show();
            

            form9.label1.Text= Convert.ToString(karbonSalinimi);

        }





        private void SaveToDatabaseeee(string yakitTürü)
        {
            using (OleDbConnection connection = new OleDbConnection("provider=microsoft.jet.oledb.4.0; data source=KarBonProjesi.mdb"))
            {
                connection.Open();

                string insertQuery = "INSERT INTO İcerik  (yakitTürü) VALUES (@yakitTürü)";
                using (OleDbCommand cmd = new OleDbCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@yakitTürü", yakitTürü);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
