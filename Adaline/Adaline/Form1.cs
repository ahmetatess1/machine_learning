using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adaline
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<TextBox> txtboxs = new List<TextBox>();//xi
        List<TextBox> txtboxs1 = new List<TextBox>();//beklenen Çıktı
        List<TextBox> agirw = new List<TextBox>();// Ağırlıklar için
        List<TextBox> esikoran = new List<TextBox>();//esik ve oran için
        static int deger = 0, wdeger= 0; //örnek ve değişken sayısı için
        private void button1_Click(object sender, EventArgs e)
        {       
            button3_Click(sender,e);// Temizlemek için fonk çağırıyor
            if (textBox1.Text != "" && textBox2.Text!="")
            {
                this.Width = 742;
                this.Height = 405;
                deger = Convert.ToInt32(textBox1.Text);// textboxa girilen örnek sayısı alınıyor
                wdeger = Convert.ToInt32(textBox2.Text); // değişken sayısı alınıyor
                for (int i = 0; i <deger; i++) // bu forun içinde örnek sayısı kadar verileri almak için textbox oluşturuluyor.
                {
                    Label label = new Label();
                    label.Top = 35+ (i * 23);
                    label.Left = 9;
                    label.Text = "X" + (i + 1)+"(x (bosluk) y):";

                    TextBox textbox = new TextBox();
                    textbox.Top = 35 + (i * 23);
                    textbox.Left = 88;
                    textbox.Width = 80;

                    TextBox beklenen = new TextBox();
                    beklenen.Text = "Sinif degerini giriniz.";
                    beklenen.GotFocus += new EventHandler(RemoveText);
                    beklenen.LostFocus += new EventHandler(AddText);
                    beklenen.ForeColor = Color.LightGray;
                    beklenen.Top = 35 + (i * 23);
                    beklenen.Left = 178;
                    beklenen.Width = 80;
                   




                    this.Controls.Add(textbox); // ilgili labeller textboxlar ekrana basılıyor
                    txtboxs.Add(textbox); // daha sonra erişebilmek için listeye atılıyor.
                    this.Controls.Add(beklenen);
                    txtboxs1.Add(beklenen);
                    this.Controls.Add(label);                   
                }
                for (int j = 0; j < wdeger; j++) // değişken sayısı kadar ağırlıkları almak için textbox oluşturuluyor.
                {
                    Label ww = new Label();
                    ww.Top = 35 + (j * 23);
                    ww.Left = 264;
                    ww.Width = 34;
                    ww.Text = "W" + (j + 1) + ":";

                    TextBox agirlik = new TextBox();
                    agirlik.Top = 35 + (j * 23);
                    agirlik.Left = 301;
                    agirlik.Width = 80;
                    this.Controls.Add(ww);
                    this.Controls.Add(agirlik);
                    agirw.Add(agirlik);
                }


                Label lab = new Label(); // esik için label ve textbox
                lab.Top = 35 ;
                lab.Left = 384;
                lab.Width = 38;
                lab.Text = "Esik" + ":";
                TextBox esik = new TextBox();
                esik.Top = 35;
                esik.Left = 424;
                esik.Width = 80;
                Label lab1 = new Label(); // ögrenme oranını almak için textbox oluşturuluyor.
                lab1.Top = 58 ;
                lab1.Left = 384;
                lab1.Width = 38;
                lab1.Text = "Oran"+ ":";
                TextBox oran = new TextBox();
                oran.Top = 58;
                oran.Left = 424;
                oran.Width = 80;
                this.Controls.Add(lab);
                this.Controls.Add(lab1);
                this.Controls.Add(esik);
                this.Controls.Add(oran);
                esikoran.Add(esik);
                esikoran.Add(oran);
            }
            else
                MessageBox.Show("Lütfen Değer Giriniz");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double net = 0; int degis = 0; // ilgili değişkenler oluşturuluyor.
            int[,] x = new int[deger, wdeger];
            double[] w = new double[wdeger];
            int[] beklenen = new int[deger];
            int[] cikti = new int[deger];
            double esik = 0;
            double oran = 0, hata = 0;           
            try
            {
                foreach (TextBox textBox in txtboxs) // listede tuttugumuz değerler oluşturdugumuz değişkenlere alınıyor.
                {
                    string value = textBox.Text;
                    string[] sp = value.Split(' ');
                    for (int i = 0; i < wdeger; i++)
                        x[degis, i] = Convert.ToInt32(sp[i]);
                    degis++;
                }
                int say = 0;
                foreach (TextBox textBox in txtboxs1) // aynı şekilde 
                {
                    string value = textBox.Text;
                    beklenen[say] = Convert.ToInt32(value);
                    say++;
                }
                say = 0;
                foreach (TextBox textBox in agirw)
                {
                    string value = textBox.Text;
                    w[say] = Convert.ToDouble(value);
                    say++;
                }
                say = 0;
                foreach (TextBox textBox in esikoran)
                {
                    string value = textBox.Text;
                    if (say == 0)
                        esik = Convert.ToDouble(value);
                    else
                        oran = Convert.ToDouble(value);
                    say++;
                }
                degis = 0;
                say = 0;
                for (int ite = 0; ite < 1000; ite++)// iterasyon yapılıyor sonsuzda yapılabilirdi ben 1000 iterasyona kadar yaptım.
                {

                    for (int j = 0; j < deger; j++) // işlemler için
                    {
                        say++;
                        richTextBox1.Text += say + ". iterasyon\n";
                        for (int i = 0; i < wdeger; i++)
                        {
                            net += w[i] * x[j, i];// net hesaplanıyor
                        }
                        net += esik;
                        richTextBox1.Text += "net:" + net; // ekrana yazılıyor.
                        if (net >= 0)
                        {
                            cikti[j] = 1;
                            richTextBox1.Text += "  net>=0  Ç:" + cikti[j] + "\n"; // çıktı belirleniyor
                        }
                        else if (net < 0)
                        {
                            cikti[j] = -1;
                            richTextBox1.Text += "  net<0  Ç:" + cikti[j] + "\n";
                        }
                        hata = beklenen[j] - cikti[j];// hata hesaplanıyor.
                        richTextBox1.Text += "E(Hata):Çbek-Ç:" + hata + "\n Wn:[ ";

                        for (int i = 0; i < wdeger; i++) // yeni agırlıklar(w) hesaplanıyor.
                        {
                            w[i] = w[i] + oran * hata * x[j, i];
                            richTextBox1.Text += w[i] + " ";
                        }

                        esik = esik + oran * hata;// yeni eşik hesaplanıyor
                        richTextBox1.Text += "] Esik:" + esik + "\n\n"; // ekrana yazılıyor.
                        net = 0;
                    }
                    if (hata <= 0.01) // eğer hata 0.01 den kucukse iterasyon durduruluyor.
                        break;
                }

                }
                catch(Exception a)
                {
                    Console.WriteLine(a);
                    MessageBox.Show("Hatalı bir değer girdiniz");
                }
            }
        private void RemoveText(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = "";
            tb.ForeColor = Color.Black;
        }

        private void AddText(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = "Sinif degerini giriniz.";
                tb.ForeColor = Color.LightGray;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Width = 742;
            this.Height = 75;
            richTextBox1.Text = "";
            for (int i = 8; i < this.Controls.Count; i++)
            {
                this.Controls.RemoveAt(i);
                i = 7;
            }
            txtboxs.Clear();
            txtboxs1.Clear();
            agirw.Clear();
            esikoran.Clear();
            deger = 0;
            wdeger = 0; // ilgili formda butun oluşan şeyler sıfırlanıyor. temizleme görevi görüyor bu fonksiyon.
            //tekrar yeniden hesap yapabilmek için.

        }
    }
}
