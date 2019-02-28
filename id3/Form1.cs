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

namespace Makpro1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti;
        OleDbDataAdapter da;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public static int toplam;
        public static int[,] toplam2;
        public static int[,,] say2;
        public static int dmax;
        public static int frm2ayirma;
        public static string[,] kyt;
        public static string[] frm2durum;
        Form2 f;
        private void button1_Click(object sender, EventArgs e)
        {
            for (int asay = 0; asay < dataGridView1.ColumnCount - 1; asay++)
            {
                kyt = new string[dataGridView1.ColumnCount, 9];
                int ytut = 0, y = 0, kontrol = 0;
                toplam = 0;
                double entropi = 0;
                double[] hentro = new double[dataGridView1.ColumnCount];
                double[] gain = new double[dataGridView1.ColumnCount];
                double max = 0;
                dmax = 0;
                frm2ayirma = 0;

                for (int k = dataGridView1.ColumnCount - 1; k >= 0; k--)
                {
                    for (int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
                    {
                        if (dataGridView1.Rows[i].DefaultCellStyle.BackColor != Color.DarkTurquoise &&
                             dataGridView1.Columns[k].DefaultCellStyle.BackColor != Color.DarkTurquoise)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (kyt[k, j] == dataGridView1.Rows[i].Cells[k].Value.ToString())
                                {
                                    kontrol = 1;
                                    break;
                                }
                            }
                            if (kontrol == 0)
                            {
                                if (k != 4)
                                {
                                    kyt[k, y] = dataGridView1.Rows[i].Cells[k].Value.ToString();
                                    y++;
                                }
                                else
                                {
                                    kyt[k, y] = dataGridView1.Rows[i].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                                    y++;
                                }
                            }
                            kontrol = 0;
                        }
                    }
                    if (ytut < y)
                    { ytut = y; frm2ayirma = ytut; }

                    y = 0;
                }


                int[] say = new int[ytut];
                toplam2 = new int[dataGridView1.ColumnCount, ytut];
                say2 = new int[dataGridView1.ColumnCount, ytut, ytut];
                double[,] hent = new double[dataGridView1.ColumnCount, ytut];
                frm2durum = new string[dataGridView1.ColumnCount];
                for (int k = dataGridView1.ColumnCount - 1; k >= 0; k--)
                {
                    for (int m = 0; m < ytut; m++)
                    {
                        for (int j = 0; j < ytut; j++)
                        {
                            for (int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
                            {
                                if (dataGridView1.Rows[i].DefaultCellStyle.BackColor != Color.DarkTurquoise &&
                             dataGridView1.Columns[k].DefaultCellStyle.BackColor != Color.DarkTurquoise)
                                {

                                    if (dataGridView1.Rows[i].Cells[k].Value.ToString() == kyt[k, j] && k == dataGridView1.ColumnCount - 1 && m == 0)
                                    {
                                        say[j] += 1;
                                        toplam += 1;
                                    }
                                    else if (dataGridView1.Rows[i].Cells[dataGridView1.ColumnCount - 1].Value.ToString() == kyt[dataGridView1.ColumnCount - 1, j]
                                        && dataGridView1.Rows[i].Cells[k].Value.ToString() == kyt[k, m])
                                    {
                                        say2[k, m, j] += 1;
                                        toplam2[k, m] += 1;
                                    }
                                }
                            }
                        }
                    }
                }

                for (int j = 0; j < ytut; j++)
                {
                    entropi += -1 * ((double)say[j] / toplam) * ((double)Math.Log10((double)say[j] / toplam) / Math.Log10(2));
                }
                label1.Text += Math.Round(entropi, 3).ToString() + "  ";

                for (int k = 0; k < dataGridView1.ColumnCount - 1; k++)
                {
                    if (dataGridView1.Columns[k].DefaultCellStyle.BackColor != Color.DarkTurquoise)
                    {
                        for (int m = 0; m < ytut; m++)
                        {
                            for (int j = 0; j < ytut; j++)
                            {
                                if (toplam2[k, m] != 0 && say2[k, m, j] != 0)
                                    hent[k, m] += -1 * ((double)say2[k, m, j] / toplam2[k, m]) * ((double)Math.Log10((double)say2[k, m, j] / toplam2[k, m]) / Math.Log10(2));

                            }
                            hentro[k] += (double)((double)toplam2[k, m] / toplam) * hent[k, m];
                        }
                        label3.Text += Math.Round(hentro[k], 3).ToString() + "  ";
                        gain[k] = entropi - hentro[k];
                        label6.Text += Math.Round(gain[k], 3).ToString() + "  ";
                    }
                }

                for (int i = 0; i < dataGridView1.ColumnCount - 1; i++)
                {
                    if (dataGridView1.Columns[i].DefaultCellStyle.BackColor != Color.DarkTurquoise)
                    {
                        if (gain[i] > max)
                        {
                            max = gain[i];
                            dmax = i;
                        }
                    }
                }
                int[] dursay = new int[ytut];
                for (int i = 0; i < ytut; i++)
                {
                    for (int j = 0; j < ytut; j++)
                    {
                        if (say2[dmax, i, j] != 0)
                            dursay[i] += 1;
                    }
                }
                for (int i = 0; i < ytut; i++)
                {
                    if (dursay[i] == 1)
                    {
                        for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                        {
                            if (dataGridView1.Rows[j].Cells[dmax].Value.ToString() == kyt[dmax, i])
                            {
                                //dataGridView1.Rows.RemoveAt(j);
                                if (dataGridView1.Rows[j].Cells[dataGridView1.ColumnCount - 1].Value.ToString()
                                    == kyt[dataGridView1.ColumnCount - 1, i] && say2[dmax, i, i] != 0)
                                    frm2durum[i] = dataGridView1.Rows[j].Cells[dataGridView1.ColumnCount - 1].Value.ToString();
                                else
                                {
                                    for (int k = 0; k < ytut; k++)
                                    {
                                        if (say2[dmax, i, k] != 0)
                                            frm2durum[i] = kyt[dataGridView1.ColumnCount - 1, k];
                                    }
                                }
                                dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.DarkTurquoise;
                            }
                        }

                        dataGridView1.Columns[dmax].DefaultCellStyle.BackColor = Color.DarkTurquoise;
                        //dataGridView1.Columns.RemoveAt(dmax);
                    }
                }
                label1.Text += "  |    ";
                label3.Text += "  |    ";
                label6.Text += "  |    ";
                max = 0;


                if (f == null || f.IsDisposed)
                {
                    f = new Form2();
                    f.Show();
                    f.ciz();
                }
                else
                {
                    f.Focus();
                    f.ciz();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Dosyası |*.xlsx| Excel Dosyası|*.xls";
            file.Title = "Excel Dosyası Seçiniz..";
            file.FilterIndex = 1;
            file.RestoreDirectory = true;         
            if (file.ShowDialog() == DialogResult.OK)
            {
                string dosyayolu = file.FileName;
                textBox1.Text = dosyayolu;
                baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dosyayolu + "; Extended Properties='Excel 12.0 xml;HDR=YES;'");
                baglanti.Open();
                da = new OleDbDataAdapter("SELECT * FROM [Sayfa1$]", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                baglanti.Close();
            }
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            dataGridView1.Columns[i].DefaultCellStyle.BackColor = Color.White;
            label1.Text = "";
            label3.Text = "";
            label6.Text = "";
        }
    }
}
