using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace photoshop
{
   
    public partial class Form1 : Form
    {
        float R;
        float G;
        float B;
        PictureBox pcRamka;
        PictureBox pcBlck;
        Button cancel;
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            bmp = new Bitmap(Properties.Resources._3f86b7510cf889bc55aa466d5d28c4c8);
            pictureBox1.Width = bmp.Width;
            pictureBox1.Height = bmp.Height;
            BackColor = Color.White;

            pictureBox1.Image = bmp;

            Bitmap bmp2 = new Bitmap(30, 30);
            pcRamka = new PictureBox();
            pcRamka.Location = new Point(bmp.Width + 15, 2);

            pcRamka.Size = new Size(30, 30);

            pcRamka.Image = bmp2;

            Controls.Add(pcRamka);

            cancel = new Button
            {
                Location = new Point(bmp.Width + 90,2),
                Text = "C",
                Size = new Size(30,30)
            };
            cancel.Click += Cancel_Click;
            Controls.Add(cancel);

            pcBlck = new PictureBox
            {
                Location = new Point(bmp.Width + 50, 2),
                Size = new Size(30, 30)
            };

            Controls.Add(pcBlck);
            Bitmap bnc = new Bitmap(30, 30);
            pcBlck.Image = bnc;
            pcBlck.Click += PcBlck_Click;
            pcBlck.BackColor = Color.Black;

            for (int i = 0; i < pcRamka.Width; i++)
            {
                for (int j = 0; j < pcRamka.Height; j++)
                {
                    if (j <= 3)
                    {
                        bmp2.SetPixel(i, j, Color.Black);
                    }
                }
            }

            for (int i = 0; i < pcRamka.Width; i++)
            {
                for (int j = 0; j < pcRamka.Height; j++)
                {
                    if (j >= 26)
                    {
                        bmp2.SetPixel(i, j, Color.Black);
                    }
                }
            }

            for (int i = 0; i < pcRamka.Width; i++)
            {
                for (int j = 0; j < pcRamka.Height; j++)
                {
                    if (i <= 3)
                    {
                        bmp2.SetPixel(i, j, Color.Black);
                    }
                }
            }

            for (int i = 0; i < pcRamka.Width; i++)
            {
                for (int j = 0; j < pcRamka.Height; j++)
                {
                    if (i >= 26)
                    {
                        bmp2.SetPixel(i, j, Color.Black);
                    }
                }
            }

            pcRamka.Click += PcRamka_Click;


            Button Blur = new Button
            {
                Location = new Point(bmp.Width + 130, 2),
                Text = "Blur",
                Size = new Size(50, 30)
            };
            Controls.Add(Blur);
            Blur.Click += Blur_Click;
        }

        private void Blur_Click(object sender, EventArgs e)
        {
            Bitmap nBmp = new Bitmap(Properties.Resources._3f86b7510cf889bc55aa466d5d28c4c8);
            Graphics gr = Graphics.FromImage(nBmp);

            gr.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int R = 0, G = 0, B = 0;
                    int count = 0;

                    for (int x = i; (x < i + 3 && x < bmp.Width); x++)
                    {
                        for (int y = j; (y < j + 3 && y < bmp.Height); y++)
                        {
                            R += bmp.GetPixel(x, y).R;
                            G += bmp.GetPixel(x, y).G;
                            B += bmp.GetPixel(x, y).B;

                            count++;
                        }
                    }

                    R /= count;
                    G = G / count;
                    B = B / count;
                   

                    for (int k = i; (k < i + 3 && k < bmp.Width); k++)
                    {
                        for (int m = j; (m < j + 3 && m < bmp.Height); m++)
                        {
                            bmp.SetPixel(k, m, Color.FromArgb(R, G, B));
                        }
                    }

                }
            }
            pictureBox1.Image = bmp;
        }





        private void Cancel_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(Properties.Resources._3f86b7510cf889bc55aa466d5d28c4c8);
            pictureBox1.Image = bmp;
        }

        private void PcBlck_Click(object sender, EventArgs e)
        {
        
            

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    float R = bmp.GetPixel(i, j).R;
                    float B = bmp.GetPixel(i, j).B;
                    float G = bmp.GetPixel(i, j).G;

                    R = G = B = (R + G + B) / 3;
                    bmp.SetPixel(i, j, Color.FromArgb((int)R,(int)G,(int)B));
                }
            }

            pictureBox1.Image = bmp;
        }

        private void PcRamka_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (j <= 15)
                    {
                        bmp.SetPixel(i, j, Color.Black);
                    }
                }
            }

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (j > 785)
                    {
                        bmp.SetPixel(i, j, Color.Black);
                    }
                }
            }

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (i <= 15)
                    {
                        bmp.SetPixel(i, j, Color.Black);
                    }
                }
            }

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (i > 549)
                    {
                        bmp.SetPixel(i, j, Color.Black);
                    }
                }
            }

            pictureBox1.Image = bmp;
        }



    }
}
