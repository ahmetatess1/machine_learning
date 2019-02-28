using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TreeGenerator;
using System.Xml;

namespace Makpro1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private TreeBuilder myTree = null;
        private void ShowTree()
        {
            picTree.Image = Image.FromStream(myTree.GenerateTree(-1, -1, "1", System.Drawing.Imaging.ImageFormat.Bmp));
        }
        private void SetControlValues()
        {
            if (myTree != null)
            {
                //lblBGColor.BackColor = myTree.BGColor;
                // lblBoxFillColor.BackColor = myTree.BoxFillColor;
                // lblFontColor.BackColor = myTree.FontColor;
                // lblLineColor.BackColor = myTree.LineColor;
                nudBoxHeight.Value = Convert.ToDecimal(myTree.BoxHeight);
                nudBoxWidth.Value = Convert.ToDecimal(myTree.BoxWidth);
                nudFontSize.Value = Convert.ToDecimal(myTree.FontSize);
                nudHorizontalSpace.Value = Convert.ToDecimal(myTree.HorizontalSpace);
                nudLineWidth.Value = Convert.ToDecimal(myTree.LineWidth);
                nudMargin.Value = Convert.ToDecimal(myTree.Margin);
                nudVerticalSpace.Value = Convert.ToDecimal(myTree.VerticalSpace);


            }

        }

        private void lblFontColor_Click_1(object sender, EventArgs e)
        {
            DialogResult result;

            result = colorDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            myTree.FontColor = colorDialog1.Color;
            ShowTree();
        }

        private void lblBoxFillColor_Click_1(object sender, EventArgs e)
        {
            DialogResult result;

            result = colorDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            myTree.BoxFillColor = colorDialog1.Color;
            ShowTree();
        }

        private void lblLineColor_Click_1(object sender, EventArgs e)
        {
            DialogResult result;

            result = colorDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            myTree.LineColor = colorDialog1.Color;
            ShowTree();
        }

        private void lblBGColor_Click_1(object sender, EventArgs e)
        {
            DialogResult result;

            result = colorDialog1.ShowDialog();

            if (result == DialogResult.Cancel)
                return;

            myTree.BGColor = colorDialog1.Color;
            ShowTree();
        }

        private void nudFontSize_ValueChanged_1(object sender, EventArgs e)
        {
            myTree.FontSize = (int)nudFontSize.Value;
            ShowTree();
        }

        private void nudVerticalSpace_ValueChanged_1(object sender, EventArgs e)
        {
            myTree.VerticalSpace = (int)nudVerticalSpace.Value;
            ShowTree();
        }

        private void nudHorizontalSpace_ValueChanged_1(object sender, EventArgs e)
        {
            myTree.HorizontalSpace = (int)nudHorizontalSpace.Value;
            ShowTree();
        }

        private void nudMargin_ValueChanged_1(object sender, EventArgs e)
        {
            myTree.Margin = (int)nudMargin.Value;
            ShowTree();
        }

        private void nudBoxHeight_ValueChanged(object sender, EventArgs e)
        {
            myTree.BoxHeight = (int)nudBoxHeight.Value;
            ShowTree();
        }

        private void nudBoxWidth_ValueChanged(object sender, EventArgs e)
        {
            myTree.BoxWidth = (int)nudBoxWidth.Value;
            ShowTree();
        }

        private void Form2_Load(object sender, EventArgs e)
        {                 
        }
        int y = 0,i=2;

        public static Form1 fr1 = (Form1)Application.OpenForms["Form1"];
        string[,] yazi= new string[fr1.dataGridView1.ColumnCount, 9];
        string[,] tut= new string[fr1.dataGridView1.ColumnCount, 9];
        string[,] tut2 = new string[fr1.dataGridView1.ColumnCount, 9];
        int[] fay = new int[9];
        int[] ktut = new int[9];
        int[] onceki = new int[9];
        int[] tutk = new int[9];
        private TreeData.TreeDataTableDataTable GetTreeData()
        {
            TreeData.TreeDataTableDataTable dt = new TreeData.TreeDataTableDataTable();
            dt.AddTreeDataTableRow("1", "", "1 2 3 4 5 6 7 8 9 10", "");
            /*dt.AddTreeDataTableRow("1", "", "Localhost", "This is your Local Server");
            dt.AddTreeDataTableRow("2", "1", "Child 1", "This is the first child.");
            dt.AddTreeDataTableRow("3", "1", "Child 2", "This is the second child.");
            dt.AddTreeDataTableRow("4", "1", "Child 3", "This is the third child.");
            dt.AddTreeDataTableRow("5", "2", "GrandChild 1", "This is the only Grandchild.");*/
            int z = 0;
            
            fay[y] = Form1.frm2ayirma;
                for (int k = 0; k < Form1.frm2ayirma; k++)
                {
                if (Form1.kyt[Form1.dmax, k] != null)
                    yazi[y, k] = Form1.kyt[Form1.dmax, k];
                else
                    yazi[y, k] = "";

                tut[y, k] = fr1.dataGridView1.Columns[Form1.dmax].HeaderText.ToString();
                if (Form1.frm2durum[k] != null)
                {
                    tut2[y, k] = Form1.frm2durum[k];
                        onceki[y+1] += 1;
                    if (y != 0)
                    {
                        ktut[y] = onceki[y - 1] + tutk[y - 1];
                    }
                }
                else
                {
                    tut2[y, k] = "";
                    if (y != 0)
                    {
                        ktut[y] = onceki[y-1]+tutk[y-1];
                    }
                    else
                    {
                        ktut[y] = 1;
                    }
                    onceki[y+1] +=1;
                    tutk[y] = k + 2;
                }
                }
            for (int l = 0; l < y + 1; l++)
            {
                for (int k = 0; k < fay[l]; k++)
                {
                   
                    dt.AddTreeDataTableRow(i.ToString(), ktut[l].ToString(), tut[l, z].ToString() + "= ", yazi[l, z].ToString() + " = " + tut2[l, z].ToString());
                    i++;
                    z++;
                    
                }
                z = 0;
            }
            i = 2;
            y++; 
            return dt;
        }

        public void ciz()
        {
            myTree = new TreeBuilder(GetTreeData());
            SetControlValues();
            ShowTree();
        }

        private void nudLineWidth_ValueChanged_1(object sender, EventArgs e)
        {
            myTree.LineWidth = (float)nudLineWidth.Value;
            ShowTree();
        }

    }
}
