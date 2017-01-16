using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicEngine;

namespace GraphicEngine
{
    public partial class GE : Form
    {
        GraphicModule01 GM01;
        ParticalModule01 PM01;
        Observer ob;
        Point LastMouseP;

        public GE()
        {
            InitializeComponent();
            double[] d = {1,2,3,0,1,4,5,6,0};
            Matrix3D m = new Matrix3D(d);
            m = m.Inverse();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.None, Keys.W);
            HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.None, Keys.A);
            HotKey.RegisterHotKey(Handle, 103, HotKey.KeyModifiers.None, Keys.S);
            HotKey.RegisterHotKey(Handle, 104, HotKey.KeyModifiers.None, Keys.D);

            //ob = new Observer(new Point3D(300, 0, 0), new Vector3D(-1, 0, 0), new Vector3D(1, 1, 0));
            ob = new Observer(new Point3D(0, -300, 0), new Vector3D(0, 1, 0), new Vector3D(0, 0, 1));
            //ob = new Observer(new Point3D(100, 100, 100), new Vector3D(-1, -1, -1), new Vector3D(-1, -1, 1));
            ob.moveMultiplier = 3;
            ob.rotateMultiplier = 0.1;

            GM01 = new GraphicModule01(ob, new Point(this.Width / 2, this.Height / 2), 1);

            PM01 = new ParticalModule01();

            //PM01.AddLine(new Dpoint(30, 0, 0), new Dpoint(0, 40, 0));
            PM01.AddLine(new Point3D(30, 30, 30), new Point3D(30, 30, -30));
            PM01.AddLine(new Point3D(20, 30, -30), new Point3D(30, 30, -30));
            PM01.AddLine(new Point3D(20, 30, 30), new Point3D(20, 30, -30));
            PM01.AddLine(new Point3D(10, 30, 30), new Point3D(20, 30, 30));
            PM01.AddLine(new Point3D(10, 30, 30), new Point3D(10, 30, -30));
            PM01.AddLine(new Point3D(0, 30, -30), new Point3D(10, 30, -30));
            PM01.AddLine(new Point3D(0, 30, 30), new Point3D(0, 30, -30));
            PM01.AddLine(new Point3D(-10, 30, 30), new Point3D(0, 30, 30));
            PM01.AddLine(new Point3D(-10, 30, -30), new Point3D(-10, 30, 30));

            Timer timer = new Timer();
            timer.Interval = (1 * 100); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GM01.PaintE(e, PM01);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Cursor.Position != LastMouseP)
            {
                ob.RotateX(Cursor.Position.X - LastMouseP.X);
                ob.RotateY(Cursor.Position.Y - LastMouseP.Y);
                //(Cursor.Position.X - LastMouseP.X) * ob.up + 
                LastMouseP = Cursor.Position;
            }
            this.Refresh();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            PM01.GlobalRotate(new Vector3D(0, 0, 0.5), new Point3D(10, 0, 0));
            this.Refresh();

            //ob.RotateX(1);
            //ob.RotateY(1);
            //this.Refresh();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 101://W
                            ob.Move(ob.forward.Normalize());
                            break;

                        case 102://A
                            ob.Move(-Vector3D.Cross(ob.forward, ob.up).Normalize());
                            break;

                        case 103://S
                            ob.Move(-ob.forward.Normalize());
                            break;

                        case 104://D
                            ob.Move(Vector3D.Cross(ob.forward, ob.up).Normalize());
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
    }

    
}
