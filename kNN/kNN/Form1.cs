using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kNN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti;
        OleDbDataAdapter da;
        Hashtable veri = new Hashtable();
        private void button1_Click_1(object sender, EventArgs e)
        {
            veri.Clear(); // Yeni dosya aldığım veri tablosu temizlendi.
            //Dosya seçim ekranı için gerekli olan kodlar yazıldı. ------------
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls";
            file.Title = "Excel Dosyası Seçiniz..";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;
            //-----------------------------------------------------------------
            if (file.ShowDialog() == DialogResult.OK)
            {
                //Veri tabanı bağlantısı yapıldı ve veriler datagrid ve hashe sütün öncelikli olarak atandı.----
                string dosyayolu = file.FileName;
                textBox1.Text = dosyayolu;
                baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dosyayolu + "; Extended Properties='Excel 12.0 xml;HDR=YES;'");
                baglanti.Open();
                da = new OleDbDataAdapter("SELECT * FROM [Sayfa1$]", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;               
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    List<string> attribute = new List<string>();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string hucre = dt.Rows[j][i].ToString();
                        dataGridView1.Rows[j].HeaderCell.Value = j.ToString();
                        if (hucre != null)
                            attribute.Add(hucre);
                    }
                        veri.Add(i, attribute);
                }
                
                baglanti.Close();
                //-----------------------------------------------------------------------------------------
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                richTextBox1.Text = ""; //Sıfırlandı
                Hashtable testH = new Hashtable(); //Eğitim için hash tanımlandı.
                Hashtable egitimH = new Hashtable(); //Test için hash tanımlandı.
                Random rand = new Random();
                int testrand;
                double yuzdekac;
                List<string> a = (List<string>)veri[0];
                int toplam = a.Count(); // veri sayısı toplam değişkenine atandı
                yuzdekac =((double)((double)toplam * 50) / 100); // verilerin yüzde kaçı alınacağı belirlendi.
                yuzdekac = Math.Round(yuzdekac); // double sayılar için yuvarlandı.
                double[,] veribenzer = new double[(int)yuzdekac, a.Count]; // hesap işlemleri için dizi tanımlandı.
                string[] sonuc2 = new string[(int)yuzdekac];// test verilerini tutmak için tanımlandı.
                for (int i = 0; i < yuzdekac; i++)
                {
                    List<string> ab = (List<string>)veri[0];
                    testrand = rand.Next(ab.Count); // rastgele için gerekli işlem yapıldı.
                    List<string> test = new List<string>();
                    for (int key = 0; key < veri.Keys.Count; key++)
                    {
                        List<string> asil = (List<string>)veri[key];
                        List<string> egitim = new List<string>();
                        test.Add(asil[testrand]);//teste rastgele olan veri atandı.
                        asil.Remove(asil[testrand]); // seçilen veriyi seçmemek için listeden çıkarıldı
                        if (yuzdekac - 1 == i)
                        {
                            egitim.AddRange(asil);
                            egitimH.Add(key, egitim); // hash e atandı.
                        }
                        sonuc2[i] += test[key] + " ";
                    }
                    testH.Add(i, test); // hash e atandı.
                }
                int[,] max = new int[(int)yuzdekac, a.Count()]; // büyükten küçüge veya tersi şeklinde sıralamak için gerekli dizi tanımlandı.
                if (comboBox1.SelectedItem == comboBox1.Items[0]) // veri türü kontorlü yapıldı
                {
                    for (int j = 0; j < testH.Count; j++)
                    {
                        for (int key = 0; key < egitimH.Keys.Count - 1; key++)
                        {
                            List<string> egitim = (List<string>)egitimH[key];
                            List<string> test = (List<string>)testH[j];
                            for (int i = 0; i < egitim.Count; i++)
                            {
                                if (egitim[i] == test[key]) // eğitim verisi ve test verisi benzerlik kontrolu yapıldı.
                                    veribenzer[j, i] += (double)1 / (egitimH.Keys.Count-1); // formül uygulandı.
                                Console.Write(egitim[i].ToString() + " ");
                            }
                        }
                    }

                    //Max dizisinde büyükten küçüğe sıralandı -------------
                    double m = 0;
                    for (int j = 0; j < testH.Count; j++)
                    {
                        for (int i = 0; i < a.Count(); i++)
                        {
                            for (int k = 0; k < a.Count(); k++)
                            {
                                if (m < veribenzer[j, k])
                                {
                                    max[j, i] = k;
                                    m = veribenzer[j, k];
                                }
                            }
                            m = 0;
                            veribenzer[j, max[j, i]] = 0;
                        }
                    }
                    //------------------------------------------------------
                }
                else if (comboBox1.SelectedItem == comboBox1.Items[1])// kontrol sayısal verilen için yapıldı
                {
                    try
                    {
                        double x, y;
                        for (int j = 0; j < testH.Count; j++)
                        {
                            for (int key = 0; key < egitimH.Keys.Count - 1; key++)
                            {
                                List<string> egitim = (List<string>)egitimH[key];
                                List<string> test = (List<string>)testH[j];
                                for (int i = 0; i < egitim.Count; i++)
                                {

                                    x = Convert.ToDouble(egitim[i]);
                                    y = Convert.ToDouble(test[key]);
                                    veribenzer[j, i] += Math.Abs(x - y); // veriler için manhattan uzaklıgı hesaplandı
                                    Console.Write(egitim[i].ToString() + " "); // log için veriler yazıldı.
                                }
                                
                            }
                        }
                    
                    // max dizisinde küçükten büyüğe sıralama yapıldı--------------
                    double m = 66666;
                    for (int j = 0; j < testH.Count; j++)
                    {
                        for (int i = 0; i < a.Count(); i++)
                        {
                            for (int k = 0; k < a.Count(); k++)
                            {
                                if (m > veribenzer[j, k])
                                {
                                    max[j, i] = k;
                                    m = veribenzer[j, k];
                                }
                            }
                            m = 66666;
                            veribenzer[j, max[j, i]] = 99999;
                        }
                    }
                    //-------------------------------------------------------------------
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Verileriniz Sayısal değil");
                    }

                }
                //--------------------------------------------------------------
                //Verilerin sıralamaya göre seçimleri yapıldı. doğruluğa göre k komşuluğu belirlendi
                int say = 0, accdsay = 0, tp = 0,fn=0,fp=0,tn=0;
                int say2 = 0, tut2 = 0 ,kd=1,maxkd=1;
                string[] sonuc1 = new string[testH.Keys.Count];
                double acc = 0, maxacc = 0;
                List<string> sonuc = (List<string>)egitimH[veri.Count - 1];
                for (int j = 0; j < testH.Count; j++)
                {
                    List<string> test = (List<string>)testH[j];
                    for (int i = 0; i < kd; i++)
                    {
                        if (sonuc[max[j, i]] == test[veri.Count - 1])
                            say++;// yes ve no için sayımlar yapıldı. test verisindeki değer baz alındı.
                        else
                        {
                            say2++; tut2 = max[j, i];
                        }
                    }
                      if (say > say2)
                        accdsay += 1; // doğruluk hesapı için doğru bildikleri sayıldı.

                    say = 0;
                    say2 = 0;

                    if (j == (testH.Count - 1) && maxacc <= ((double)accdsay / testH.Count) && kd < sonuc.Count)
                    {
                        maxacc = (double)accdsay / testH.Count; // k komşuluk hesabı için max doğruluk seçildi
                        maxkd = kd;// ve k komşulugu tutuldu.
                        kd += 1;
                        j = -1; accdsay = 0;
                    }
                    else if(j == (testH.Count - 1) && kd<sonuc.Count)
                    {
                        kd += 1;
                        j = -1; accdsay = 0;
                    }
                }
                accdsay = 0; say = 0;say2 = 0; // sıfırlandı

                //--------------------------------------------
                //max k komşuluğa göre tekrar veriler sınıflandırıldı ve buna göre sensivity, specifity, 
                //f ölçüm değerleri hesaplandı 
                for (int j = 0; j < testH.Count; j++)
                {
                    List<string> test = (List<string>)testH[j];
                    for (int i = 0; i < maxkd; i++)
                    {
                        if (sonuc[max[j, i]] == test[veri.Count-1])
                            say++;
                        else
                        {
                            say2++; tut2 = max[j, i];
                        }
                    }
                    sonuc1[j]= "\n"+" test : \n" + test[veri.Count - 1] + "--> " + say + "\n" + sonuc[tut2].ToString() + "--> " + say2;
                    if (say > say2)
                    {
                        sonuc1[j] += "\nVerinin ataması: " + test[veri.Count - 1];

                        accdsay += 1;
                        if (test[veri.Count - 1] == "yes")
                            tp += 1;
                        else
                            tn += 1;

                    }
                    else
                    {
                        sonuc1[j] += "\nVerinin ataması: " + sonuc[tut2].ToString();


                        if (sonuc[tut2] == "yes")
                            fp += 1;
                        else
                            fn += 1;
                    }

                    Console.Write(" ");
                    say = 0;
                    say2 = 0;
                }
                // Forma yazdırma işlemleri yapıldı.
                acc = (double)accdsay / testH.Count;
                for (int j = 0; j < testH.Count; j++)
                {
                    richTextBox1.Text += (j+1)+". "+sonuc2[j];
                    richTextBox1.Text += sonuc1[j]+"\n\n";
                    
                }
                richTextBox1.Text += "\n doğruluk: " + acc.ToString();
                richTextBox1.Text += "\n hata oranı: " + (1-acc).ToString();
                richTextBox1.Text += "\n kesinlik: " + ((double)tp / (tp + fn)).ToString();
                richTextBox1.Text += "\n duyarlılık: " + ((double)tn / (fp + tn)).ToString();
                richTextBox1.Text += "\n f-ölçümü: " + ((double)2 * tp / (2 * tp + fp + fn)).ToString();
                richTextBox1.Text +="\nk:" +maxkd;

            }
            else
                MessageBox.Show("Lütfen Kategori Seçiniz");



        }


    }
}
