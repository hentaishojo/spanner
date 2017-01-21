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

namespace BitmapEdit
{
    public partial class Form1 : Form
    {
        int step = 0;
        Point[] pt = new Point[2];
        Bitmap bmp;
        Point Xp1;
        Point Xp2;
        Point Yp1;
        Point Yp2;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(Properties.Resources.dice);
            PbxMain.Image = bmp;
        }

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            if(step == 0)
            {
                pt[0] = e.Location;
                step++;
            }
            else if (step == 1)
            {
                pt[1] = e.Location;
                step++;
            }
        }

        private void BtnOutput_Click(object sender, EventArgs e)
        {
            if (step == 2)
            {
                Bitmap cloned = bmp.Clone(new System.Drawing.Rectangle(pt[0].X, pt[0].Y, pt[1].X - pt[0].X, pt[1].Y - pt[0].Y), bmp.PixelFormat);
                PbxMain.Image = cloned;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Xp1 = new Point(-1000, e.Y);
            Xp2 = new Point(1000, e.Y);
            Yp1 = new Point(e.X, -1000);
            Yp2 = new Point(e.X, 1000);
            PbxMain.Refresh();
            //Point XMouseLoc = new Point(e.X - 1000, e.Y + 13);
            //Point YMouseLoc = new Point(e.X + 13, e.Y - 1000 );
            //Xaxis.Location = XMouseLoc;
            //Yaxis.Location = YMouseLoc;
            //if (Xaxis.Location != XMouseLoc || Yaxis.Location != YMouseLoc)
            //{
            //    Xaxis.Location = XMouseLoc;
            //    Yaxis.Location = YMouseLoc;
            //    refreshCounter--;
            //}

            //if (refreshCounter <= 0)
            //{
            //    this.Refresh();
            //    refreshCounter = 5;
            //}
        }


        private void PbxMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Red, Xp1, Xp2);
            e.Graphics.DrawLine(Pens.Red, Yp1, Yp2);
        }
    }
}
