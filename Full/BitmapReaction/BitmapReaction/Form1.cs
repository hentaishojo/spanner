using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace BitmapReaction //Conway's Game of Life
{
    public partial class Form1 : Form
    {
        PictureBox pb;
        Timer t = new Timer();
        //Graphics g;
        Bitmap bmp = new Bitmap(900, 900, PixelFormat.Format24bppRgb);
        Random r = new Random();
        int counter;
        int i, j;

        bool[,] b_s = new bool[100, 100];
        bool[,] b = new bool[900, 900];
        bool[,] clone = new bool[100, 100];

        public Form1()
        {
            InitializeComponent();
            pb = pictureBox1;
            pb.Image = bmp;
            pb.Refresh();
            this.BackColor = Color.Black;

            for (i = 0; i < 100;i++ )
            {
                for (j = 0; j < 100; j++)
                {
                    b_s[i, j] = false;

                    
                    
                    
                }
            }

            for (i = 1; i < 99; i++)
            {
                for (j = 1; j < 99; j++)
                {
                    if (r.Next(1, 4) == 1)
                    {
                        b_s[i, j] = true;

                    }
                    else
                    {
                        b_s[i, j] = false;
                    }
                }
            }
            //b[r.Next(1, 899), r.Next(1, 899)] = true;
            //b_s[1, 1] = true;
            //b_s[2, 1] = true;
            //b_s[1, 2] = true;
            //b_s[2, 2] = true;
            //b_s[1, 3] = true;


            t.Interval = 1000;  
            t.Tick += new EventHandler(this.t_Tick);
            string a = bmp.PixelFormat.ToString();
            t.Start();
            
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //g = Graphics.FromImage(bmp);

            for (i = 0; i < 100; i++)
            {
                for (j = 0; j < 100; j++)
                {

                    clone[i, j] = b_s[i, j];
                }
            }

            for (i = 1; i < 99; i++)
            {
                for (j = 1; j < 99; j++)
                {
                    counter = 0;
                    //b[i + 1, j] = true;
                    //b[i - 1, j] = true;
                    //b[i, j + 1] = true;
                    //b[i, j - 1] = true;
                    if (clone[i + 1, j] == true)
                    {
                        counter++;
                    }
                    if (clone[i - 1, j] == true)
                    {
                        counter++;
                    }
                    if (clone[i, j + 1] == true)
                    {
                        counter++;
                    }
                    if (clone[i, j - 1] == true)
                    {
                        counter++;
                    }
                    if (clone[i + 1, j + 1] == true)
                    {
                        counter++;
                    }
                    if (clone[i - 1, j + 1] == true)
                    {
                        counter++;
                    }
                    if (clone[i - 1, j - 1] == true)
                    {
                        counter++;
                    }
                    if (clone[i + 1, j - 1] == true)
                    {
                        counter++;
                    }
                    //------------------
                    if (clone[i, j]==true)
                    {
                        if (counter == 2)
                        {
                            b_s[i, j] = true;
                        }
                        else if(counter == 3)
                        {
                            b_s[i, j] = true;
                        }
                        else
                        {
                            b_s[i, j] = false;
                        }  
                    }
                    else
                    {
                        if( counter == 3)
                        {
                            b_s[i, j] = true;
                        }
                        else
                        {
                            b_s[i, j] = false;
                        }
                    }
                   

                }
            }

            for (i = 0; i < 100; i++)
            {
                for (j = 0; j <100; j++)
                {
                    if(b_s[i,j]==true)
                    {
                        b[3 * i + 1, 3 * j + 1] = true;
                        b[3 * i + 2, 3 * j + 1] = true;
                        b[3 * i + 3, 3 * j + 1] = true;
                        b[3 * i + 1, 3 * j + 2] = true;
                        b[3 * i + 2, 3 * j + 2] = true;
                        b[3 * i + 3, 3 * j + 2] = true;
                        b[3 * i + 1, 3 * j + 3] = true;
                        b[3 * i + 2, 3 * j + 3] = true;
                        b[3 * i + 3, 3 * j + 3] = true;
                    }
                    else
                    {
                        b[3 * i + 1, 3 * j + 1] = false;
                        b[3 * i + 2, 3 * j + 1] = false;
                        b[3 * i + 3, 3 * j + 1] = false;
                        b[3 * i + 1, 3 * j + 2] = false;
                        b[3 * i + 2, 3 * j + 2] = false;
                        b[3 * i + 3, 3 * j + 2] = false;
                        b[3 * i + 1, 3 * j + 3] = false;
                        b[3 * i + 2, 3 * j + 3] = false;
                        b[3 * i + 3, 3 * j + 3] = false;
                    }
                }
            }
                

            write_bmp(b);

            //g.Clear(Color.White);
            //g.DrawLine(new Pen(Color.Gray, 3f), new Point(0, 0), new Point(r.Next(0, 899), r.Next(0, 899)));
            pb.Refresh();
        }

        unsafe void write_bmp(bool[,] bo)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = data.Stride;
            byte* ptr = (byte*)data.Scan0;

            for (int y = 0; y < 900; y++)
            {
                for (int x = 0; x < 900; x++)
                {

                    if(bo[x,y]==true)
                    {
                        ptr[(x * 3) + y * stride] = 0xFF;
                        ptr[(x * 3) + y * stride + 1] = 0xFF;
                        ptr[(x * 3) + y * stride + 2] = 0xFF;
                    }
                    else
                    {
                        ptr[(x * 3) + y * stride] = 0x00;
                        ptr[(x * 3) + y * stride + 1] = 0x00;
                        ptr[(x * 3) + y * stride + 2] = 0x00;
                    }

                    // layer.GetBitmap().SetPixel(x, y, m_colour);
                    
                }
            }
            bmp.UnlockBits(data);
        }
    }
}
