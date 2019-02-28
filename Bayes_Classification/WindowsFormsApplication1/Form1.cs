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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti;
        OleDbDataAdapter da;

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
        }

        public static int toplam;
        public static int[,] toplam2;
        public static int[,,] say2;
        public static string[,] kyt;

        private void button1_Click(object sender, EventArgs e)
        {
            kyt = new string[dataGridView1.ColumnCount, dataGridView1.RowCount];
            int ytut = 0, y = 0, kontrol = 0;
            toplam = 0;            

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
                { ytut = y;}

                y = 0;
            }


            int[] say = new int[ytut];
            toplam2 = new int[dataGridView1.ColumnCount, ytut];
            say2 = new int[dataGridView1.ColumnCount, ytut, ytut];
            double[] pxson = new double[ytut];
            double[] px = new double[ytut];

            for (int k = dataGridView1.ColumnCount - 1; k >= 0; k--)
            {
                for (int m = 0; m < ytut; m++)
                {
                    for (int j = 0; j < ytut; j++)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count - 2; i++)
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
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < dataGridView1.ColumnCount - 1; i++)
            {
                for (int k = 0; k < ytut; k++)
                {
                    for (int j = 0; j < ytut; j++)
                    {
                        toplam2[i, k] += say2[i, j, k];
                    }
                }
            }

                int z = 0;
            for (int i = 0; i < ytut; i++)
            {
                px[i] = 1;
                for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                {
                    for (int k = 0; k < dataGridView1.RowCount- 2; k++)
                    {
                        if (kyt[j, k] == null)
                            break;
                        else if (dataGridView1.Rows[dataGridView1.RowCount -2].Cells[j].Value.ToString() == kyt[j, k].ToString())
                        {
                            px[i] =((double)px[i]*((double)say2[j, k, z] / toplam2[j, z]));
                        }

                    }
                }
                pxson[i] =(double) px[i] * say[i] / toplam;
                z++;
            }
            double max = 0;
            int tuti = 0;
            for (int i = 0; i < ytut; i++)
            {
                if (pxson[i] > max)
                {
                    max = pxson[i];
                    tuti = i;
                }
            }
            label1.Font = new Font(label1.Font.FontFamily, 36f, label1.Font.Style);
            label1.Text = "X Girdisi "+kyt[dataGridView1.ColumnCount - 1, tuti]+"'dir.";

            timer1.Start();
            



            }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int a = rand.Next(0, 255);
            int b = rand.Next(0, 255);
            int c = rand.Next(0, 255);
            label1.ForeColor = Color.FromArgb(a,b,c);
        }
    }
}
