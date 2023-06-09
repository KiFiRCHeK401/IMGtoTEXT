using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string sous;
        string result;
        int weight = 0;
        int height = 0;
        byte[,] sous_matrx;
        int correct = 1;
        int size = 0;
        public Form1()
        {
            InitializeComponent();
            result = "../../../result.txt";
            //textBox3.ScrollBars = ScrollBars.Horizontal;
            trackBar1.Value = correct;
            textBox2.Text=result;
            trackBar2.Value = size;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Png Image|*.png|JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            openFile.ShowDialog();
            sous = openFile.FileName;
            textBox1.Text = sous;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            correct = trackBar1.Value;
            size = trackBar2.Value;
            pictureBox1.Image = Image.FromFile(sous);
            Bitmap sous_image = (Bitmap) pictureBox1.Image;
            
            weight= (int)sous_image.Width;
            height = (int)sous_image.Height;

            string string1=""; //= Convert.ToString(weight);
            //string1 += Environment.NewLine;
            //string1 = Convert.ToString(height);
            //string1 += Environment.NewLine;
            
            sous_matrx = new byte[weight, height];
            Console.WriteLine(Convert.ToString(weight * height));
            label4.Text=Convert.ToString(height)+"x"+Convert.ToString(weight);
            for(int i = 0; i < height; i=i+correct+1+size)
            {
                for (int j = 0; j < weight; j=j+1+size)
                {
                    System.Drawing.Color p = sous_image.GetPixel(j, i);
                    int r = Convert.ToInt32(p.R);
                    int g = Convert.ToInt32(p.G);
                    int b = Convert.ToInt32(p.B);
                    int s = (r + g + b) / 3/26;

                    //sous_matrx[i, j] = Convert.ToByte(s);

                    //string1 += Convert.ToString(s);
                    //string1 += Convert.ToString(s);
                    //string1 += "";

                    //int rest = 5;
                    if (s <1) { string1 += "@@"; }
                    else if (s < 2) { string1 += "&&"; }
                    else if (s < 3) { string1 += "##"; }
                    else if (s < 4) { string1 += "=="; }
                    else if (s < 5) { string1 += "**"; }
                    else if (s < 6) { string1 += "~~"; }
                    else if (s < 7) { string1 += "||"; }
                    else if (s < 8) { string1 += ";;"; }
                    else if (s < 9) { string1 += ".."; }
                    else if (s < 10) { string1 += "  "; }
                    else { string1 += "  "; }



                }
                int prosent = 0;
                if(prosent+1 < (i * 100 / height))
                {
                    prosent = i * 100 / height;
                    progressBar1.Value = prosent;
                    this.Text = (Convert.ToString(prosent) + "%");
                    Console.WriteLine(Convert.ToString(prosent) + "%");
                    Console.WriteLine(Convert.ToString(i * weight) + "/" + Convert.ToString(weight * height));
                }

                string1 += Environment.NewLine;
            }
            textBox3.Text = string1;

            using (var WriteInFile = File.AppendText(result))
            {
                WriteInFile.WriteLine(string1);
            }
            
            
            Console.WriteLine("Done");
            this.Text = ("Done");
            progressBar1.Value = 100;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFile = new FolderBrowserDialog();
            openFile.ShowDialog();
            result = openFile.SelectedPath.ToString()+ "\\result.txt";
            textBox2.Text = result; ;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.Delete(result);
        }
    }
}
