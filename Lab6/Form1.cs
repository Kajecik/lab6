using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Web.Helpers;

namespace Lab6
{
    public partial class Form1 : Form
    {
        private int[] red = null;
        private int[] green = null;
        private int[] blue = null;

    
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Otwórz obraz";
            dlg.Filter = "Obrazy (*.jpg;*.gif;*.png;*.bmp)|*.jpg;*.gif;*.png;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = new Bitmap(dlg.OpenFile());
                pictureBox1.Height = pictureBox1.Image.Height;
                pictureBox1.Width = pictureBox1.Image.Width;
                this.ClientSize = new System.Drawing.Size(Math.Max(pictureBox1.Width + 30, 345), pictureBox1.Height + 155);

               }
            dlg.Dispose();
        }

        
        

        private void button2_Click(object sender, EventArgs e)
        {

            red = new int[256];
            green = new int[256];
            blue = new int[256];
            for (int x = 0; x < pictureBox1.Width; x++)
            {
                for (int y = 0; y < pictureBox1.Height; y++)
                {
                    Color pixel = ((Bitmap)pictureBox1.Image).GetPixel(x, y);
                    red[pixel.R]++;
                    green[pixel.G]++;
                    blue[pixel.B]++;
                }
            }


            chart1.Series["red"].Points.Clear();
            chart1.Series["green"].Points.Clear();
            chart1.Series["blue"].Points.Clear();
            for (int i = 0; i < 256; i++)
            {
                chart1.Series["red"].Points.AddXY(i, red[i]);
                chart1.Series["green"].Points.AddXY(i, green[i]);
                chart1.Series["blue"].Points.AddXY(i, blue[i]);
            }
            chart1.Invalidate();

        }

        

       

        
    }
    
}
