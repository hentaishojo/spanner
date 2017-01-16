using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GraphicEngine
{
    public class M
    {
        static public double sq(double input)
        {
            return input * input;
        }
        static public int sq(int input)
        {
            return input * input;
        }
        
        static public double vMag(Point3D start, Point3D end)
        {
            return Math.Sqrt(M.sq(start.X) + M.sq(start.Y) + M.sq(start.Z));
        }

        static public double Acos(double input)
        {
            if (double.IsNaN(Math.Acos(input)))
            {
                return 0;
            }
            return Math.Acos(input);
        }
    }

    public class Point3D
    {
        public double X;
        public double Y;
        public double Z;

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        static public Point3D Rotate(Vector3D v, Point3D refpt, Point3D p)
        {
            //double t = (v.X * (pt.X - refpt.X) + v.Y * (pt.Y - refpt.Y) + v.Z * (pt.Z - refpt.Z)) / (M.sq(v.X) + M.sq(v.Y) + M.sq(v.Z));
            //Dpoint projectionRef = new Dpoint(refpt.X + v.X * t, refpt.Y + v.Y * t, refpt.Z + v.Z * t);


            p = p - refpt;
            p = Matrix3D.matrixXpoint(Matrix3D.RotX(v.X), p);
            p = Matrix3D.matrixXpoint(Matrix3D.RotY(v.Y), p);
            p = Matrix3D.matrixXpoint(Matrix3D.RotZ(v.Z), p);
            //p = Matrix3D.matrixXpoint(Matrix3D.RotEuler(v.X, v.Y, v.Z), p);
            p = p + refpt;

            return p;
        }

        public static Point3D operator +(Point3D p1, Point3D p2)
        {
            return new Point3D(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
        }

        public static Point3D operator -(Point3D p1, Point3D p2)
        {
            return new Point3D(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
        }

        public static Point3D operator *(double d, Point3D pt)
        {
            return new Point3D(d * pt.X, d * pt.Y, d * pt.Z);
        }

        public static Point3D operator -(Point3D pt)
        {
            return new Point3D(-pt.X, -pt.Y, -pt.Z);
        }

    }

    public class Vector3D
    {
        public double X;
        public double Y;
        public double Z;

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3D(Point3D start, Point3D end)
        {
            X = end.X - start.X;
            Y = end.Y - start.Y;
            Z = end.Z - start.Z;
        }

        public double Mag()
        {
            if (X == 0 && Y == 0 && Z == 0)
            {
                return 0;
            }
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public Vector3D Normalize()
        {
            return new Vector3D(X / Mag(), Y / Mag(), Z / Mag());
        }

        public Point3D ToPoint()
        {
            return new Point3D(X,Y,Z);
        }

        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector3D operator *(double d, Vector3D v)
        {
            return new Vector3D(d * v.X, d * v.Y, d * v.Z);
        }

        public static Vector3D operator -(Vector3D v1)
        {
            return new Vector3D(-v1.X, -v1.Y, -v1.Z);
        }

        static public double Dot(Vector3D v1, Vector3D v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        static public Vector3D Cross(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.Y * v2.Z - v1.Z * v2.Y, v1.Z * v2.X - v1.X * v2.Z, v1.X * v2.Y - v1.Y * v2.X);
        }

        static public Vector3D Rotate(Vector3D refv, Vector3D v)
        {
            v = Matrix3D.matrixXvector(Matrix3D.RotX(refv.X), v);
            v = Matrix3D.matrixXvector(Matrix3D.RotY(refv.Y), v);
            v = Matrix3D.matrixXvector(Matrix3D.RotZ(refv.Z), v);
            return v;
            //return Matrix3D.matrixXvector(Matrix3D.RotEuler(refv.X, refv.Y, refv.Z), v);
        }
    }

    public class Line3D
    {
        public Point3D[] p = new Point3D[2];

        public Line3D(Point3D p1, Point3D p2)
        {
            p[0] = p1;
            p[1] = p2;
        }
    }

    public class Circle3D
    {
        public Point3D p;
        public double r;
        public Vector3D n;

        public Circle3D(Point3D p, double r, Vector3D n)
        {
            this.p = p;
            this.r = r;
            this.n = n;
        }
    }

    public class Matrix2D
    {
        public double[,] cells = new double[2, 2];

        public Matrix2D(double[] cells)
        {
            for (int i = 0; i < 4; i++)
            {
                this.cells[i / 2, i % 2] = cells[i];
            }
        }

        public Matrix2D(double[,] cells)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    this.cells[i, j] = cells[i, j];
                }
            }
        }

        public double Det()
        {
            return cells[0, 0] * cells[1, 1] - cells[1, 0] * cells[0, 1];
        }

        public Matrix2D Transpose()
        {
            double[,] cells = new double[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    cells[i, j] = this.cells[j, i];
                }
            }
            return new Matrix2D(cells);
        }

        public Matrix2D Inverse()
        {
            double[] cells = { -this.cells[1, 1], this.cells[1, 0], this.cells[0, 1], -this.cells[0, 0] };
            return new Matrix2D(cells);
        }

        static public Matrix2D O
        {
            get
            {
                double[] cells = { 0, 0, 0, 0 };
                return new Matrix2D(cells);
            }
        }

        static public Matrix2D I
        {
            get
            {
                double[] cells = { 1, 0, 0, 1 };
                return new Matrix2D(cells);
            }
        }

        static public Matrix3D RotEuler(double theta)
        {
            double[] cells = { Math.Cos(theta), -Math.Sin(theta), Math.Sin(theta), Math.Cos(theta) };
            return new Matrix3D(cells);
        }

        public static Matrix2D operator +(Matrix2D m1, Matrix2D m2)
        {
            double[,] cells = new double[3, 3];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    cells[i, j] = m1.cells[i, j] + m2.cells[i, j];
                }
            }
            return new Matrix2D(cells);
        }

        public static Matrix2D operator -(Matrix2D m1, Matrix2D m2)
        {
            double[,] cells = new double[3, 3];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    cells[i, j] = m1.cells[i, j] - m2.cells[i, j];
                }
            }
            return new Matrix2D(cells);
        }
    }

    public class Matrix3D
    {
        public double[,] cells = new double[3,3];

        public Matrix3D(double[] cells)
        {
            for (int i = 0; i < 9; i++)
            {
                this.cells[i / 3, i % 3] = cells[i];
            }
        }

        public Matrix3D(double[,] cells)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.cells[i, j] = cells[i, j];
                }
            }
        }

        public double Det2D(int p, int q)
        {
            if (p == 0 && q == 0)
                return cells[1, 1] * cells[2, 2] - cells[2, 1] * cells[1, 2];
            else if (p == 0 && q == 1)
                return cells[2, 2] * cells[1, 0] - cells[1, 2] * cells[2, 0];
            else if (p == 0 && q == 2)
                return cells[1, 0] * cells[2, 1] - cells[2, 0] * cells[1, 1];
            else if (p == 1 && q == 0)
                return cells[0, 1] * cells[2, 2] - cells[2, 1] * cells[0, 2];
            else if (p == 1 && q == 1)
                return cells[2, 2] * cells[0, 0] - cells[0, 2] * cells[2, 0];
            else if (p == 1 && q == 2)
                return cells[0, 0] * cells[2, 1] - cells[2, 0] * cells[0, 1];
            else if (p == 2 && q == 0)
                return cells[0, 1] * cells[1, 2] - cells[1, 1] * cells[0, 2];
            else if (p == 2 && q == 1)
                return cells[1, 2] * cells[0, 0] - cells[0, 2] * cells[1, 0];
            else if (p == 2 && q == 2)
                return cells[0, 0] * cells[1, 1] - cells[1, 0] * cells[0, 1];
            else
                return 0;
        }

        public double Det3D()
        {
            return cells[0, 0] * cells[1, 1] * cells[2, 2] + cells[0, 1] * cells[1, 2] * cells[2, 0] + cells[0, 2] * cells[1, 0] * cells[2, 1] -
                   cells[2, 0] * cells[1, 1] * cells[0, 2] - cells[2, 1] * cells[1, 2] * cells[0, 0] - cells[2, 2] * cells[1, 0] * cells[0, 1];
        }

        public Matrix3D Transpose()
        {
            double[,] cells = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cells[i, j] = this.cells[j, i];
                }
            }
            return new Matrix3D(cells);
        }

        public Matrix3D Inverse()
        {
            //check inverse exist
            double c1 = this.cells[0, 0] * this.Det2D(0, 0);
            double c2 = this.cells[0, 1] * this.Det2D(0, 1);
            double c3 = this.cells[0, 2] * this.Det2D(0, 2);

            if(c1+c2+c3 == 0)
                return Matrix3D.O;

            //calc
            Matrix3D t = this.Transpose();
            double[,] cells = new double[3, 3];
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((i + j) % 2 == 0)
                        cells[i, j] = t.Det2D(i, j) / t.Det3D();                        
                    else
                        cells[i, j] = -t.Det2D(i, j) / t.Det3D();
                }
            }
            return new Matrix3D(cells);
        }

        static public Matrix3D O
        {
            get {
                double[] cells = {0,0,0,0,0,0,0,0,0};
                return new Matrix3D(cells);
            }
        }

        static public Matrix3D I
        {
            get
            {
                double[] cells = { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
                return new Matrix3D(cells);
            }
        }

        static public Point3D matrixXpoint(Matrix3D mx, Point3D p)
        {
            return new Point3D(p.X * mx.cells[0, 0] + p.Y * mx.cells[0, 1] + p.Z * mx.cells[0, 2],
                              p.X * mx.cells[1, 0] + p.Y * mx.cells[1, 1] + p.Z * mx.cells[1, 2],
                              p.X * mx.cells[2, 0] + p.Y * mx.cells[2, 1] + p.Z * mx.cells[2, 2]);
        }

        static public Vector3D matrixXvector(Matrix3D mx, Vector3D v)
        {
            return new Vector3D(v.X * mx.cells[0, 0] + v.Y * mx.cells[0, 1] + v.Z * mx.cells[0, 2],
                                v.X * mx.cells[1, 0] + v.Y * mx.cells[1, 1] + v.Z * mx.cells[1, 2],
                                v.X * mx.cells[2, 0] + v.Y * mx.cells[2, 1] + v.Z * mx.cells[2, 2]);
        }

        static public Matrix3D RotX(double theta)
        {
            double[] cells = { 1, 0, 0, 0, Math.Cos(theta), -Math.Sin(theta), 0, Math.Sin(theta), Math.Cos(theta) };
            return new Matrix3D(cells);
        }

        static public Matrix3D RotY(double theta)
        {
            double[] cells = { Math.Cos(theta), 0, Math.Sin(theta), 0, 1, 0, -Math.Sin(theta), 0, Math.Cos(theta) };
            return new Matrix3D(cells);
        }

        static public Matrix3D RotZ(double theta)
        {
            double[] cells = { Math.Cos(theta), -Math.Sin(theta), 0, Math.Sin(theta), Math.Cos(theta), 0, 0, 0, 1 };
            return new Matrix3D(cells);
        }

        static public Matrix3D RotEuler(double alpha, double beta, double gamma)
        {
            //has some unsolved issue
            double[] cells = { Math.Cos(alpha)*Math.Cos(gamma) - Math.Cos(beta)*Math.Sin(alpha)*Math.Sin(gamma), -Math.Cos(beta)*Math.Cos(gamma)*Math.Sin(alpha) - Math.Cos(alpha)*Math.Sin(gamma), Math.Sin(alpha)*Math.Sin(beta), 
                               Math.Cos(gamma)*Math.Sin(alpha) + Math.Cos(alpha)*Math.Cos(beta)*Math.Sin(gamma), Math.Cos(alpha)*Math.Cos(beta)*Math.Cos(gamma) - Math.Sin(alpha)*Math.Sin(gamma), -Math.Cos(alpha)*Math.Sin(beta), 
                               Math.Sin(beta)*Math.Sin(gamma), Math.Cos(gamma)*Math.Sin(beta), Math.Cos(beta)};
            return new Matrix3D(cells);
        }

        public static Matrix3D operator +(Matrix3D m1, Matrix3D m2)
        {
            double[,] cells = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cells[i, j] = m1.cells[i, j] + m2.cells[i, j];
                }
            }
            return new Matrix3D(cells);
        }

        public static Matrix3D operator -(Matrix3D m1, Matrix3D m2)
        {
            double[,] cells = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cells[i, j] = m1.cells[i, j] - m2.cells[i, j];
                }
            }
            return new Matrix3D(cells);
        }
    }

    public class Observer
    {
        public Point3D pos;
        public Vector3D forward;
        public Vector3D up;
        public Vector3D right { get { return Vector3D.Cross(forward, up).Normalize(); } }

        public double moveMultiplier = 1;
        public double rotateMultiplier = 1;

        public Observer(Point3D pos, Vector3D forward, Vector3D up)
        {
            this.pos = pos;
            this.forward = forward.Normalize();
            this.up = up.Normalize();
        }

        public void Move(Vector3D v)
        {
            pos += moveMultiplier * v.ToPoint();
        }

        public void RotateX(double theta)
        {
            forward = Vector3D.Rotate(theta * rotateMultiplier * up, forward);
        }

        public void RotateY(double theta)
        {
            Vector3D right = this.right;
            up = Vector3D.Rotate(theta * rotateMultiplier * right, up);
            forward = Vector3D.Rotate(theta * rotateMultiplier * right, forward);
        }
    }

    public class GraphicModule01 //solve projection + rect vision
    {
        public Observer observ;
        public Point offset;
        public double zoom;

        public Point[] outputLine;
        public bool isDraw = false;

        public GraphicModule01(Observer observ, Point offset, double zoom)
        {
            // rect view

            this.observ = observ;
            this.offset = offset;
            this.zoom = zoom;

            outputLine = new Point[2];
        }

        Point TransToScreen(Point3D inputP)
        {
            double t = (observ.forward.X * (observ.pos.X - inputP.X) + observ.forward.Y * (observ.pos.Y - inputP.Y) + observ.forward.Z * (observ.pos.Z - inputP.Z)) / (M.sq(observ.forward.X) + M.sq(observ.forward.Y) + M.sq(observ.forward.Z));
            if (t <= 0)
                isDraw = false;
            Point3D projection = new Point3D(inputP.X + observ.forward.X * t, inputP.Y + observ.forward.Y * t, inputP.Z + observ.forward.Z * t);
            Vector3D OP = new Vector3D(observ.pos, projection);
            double theta = M.Acos(Vector3D.Dot(OP, observ.up) / OP.Mag());
            if (Vector3D.Dot(Vector3D.Cross(observ.up, OP), observ.forward) < 0)
                theta = -theta;
            double a = Math.Round(zoom * OP.Mag() * Math.Sin(theta));

            return new Point(offset.X + Convert.ToInt32(Math.Round(zoom * OP.Mag() * Math.Sin(theta))), offset.Y - Convert.ToInt32(Math.Round(zoom * OP.Mag() * Math.Cos(theta))));
        }

        public void PaintE(PaintEventArgs e, ParticalModule01 PM)
        {
            e.Graphics.DrawLine(Pens.Black, new Point(5000 + offset.X, offset.Y), new Point(-5000 + offset.X, offset.Y));
            e.Graphics.DrawLine(Pens.Black, new Point(offset.X, 5000 + offset.Y), new Point(offset.X, -5000 + offset.Y));

            foreach (Line3D line in PM.lines)
            {
                isDraw = true;
                int p0x = TransToScreen(line.p[0]).X;
                int p0y = TransToScreen(line.p[0]).Y;
                int p1x = TransToScreen(line.p[1]).X;
                int p1y = TransToScreen(line.p[1]).Y;
                if(true)
                    e.Graphics.DrawLine(Pens.Red, TransToScreen(line.p[0]), TransToScreen(line.p[1]));
            }
        }
    }

    public class GraphicModule02 //matrix projection + rect vision
    {
        public Observer observ;
        public Point offset;
        public double zoom;

        public Point[] outputLine;

        public GraphicModule02(Observer observ, Point offset, double zoom)
        {
            // rect view

            this.observ = observ;
            this.offset = offset;
            this.zoom = zoom;

            outputLine = new Point[2];
        }

        Point Projection(Point3D inputP)
        {
            double t = (observ.forward.X * (observ.pos.X - inputP.X) + observ.forward.Y * (observ.pos.Y - inputP.Y) + observ.forward.Z * (observ.pos.Z - inputP.Z)) / (M.sq(observ.forward.X) + M.sq(observ.forward.Y) + M.sq(observ.forward.Z));
            Point3D projection = new Point3D(inputP.X + observ.forward.X * t, inputP.Y + observ.forward.Y * t, inputP.Z + observ.forward.Z * t);
            Vector3D OP = new Vector3D(observ.pos, projection);
            double theta = M.Acos(Vector3D.Dot(OP, observ.up) / OP.Mag());
            if (Vector3D.Dot(Vector3D.Cross(observ.up, OP), observ.forward) < 0)
                theta = -theta;
            double a = Math.Round(zoom * OP.Mag() * Math.Sin(theta));

            return new Point(offset.X + Convert.ToInt32(Math.Round(zoom * OP.Mag() * Math.Sin(theta))), offset.Y - Convert.ToInt32(Math.Round(zoom * OP.Mag() * Math.Cos(theta))));
        }

        public void PaintE(PaintEventArgs e, ParticalModule01 PM)
        {
            e.Graphics.DrawLine(Pens.Black, new Point(5000 + offset.X, offset.Y), new Point(-5000 + offset.X, offset.Y));
            e.Graphics.DrawLine(Pens.Black, new Point(offset.X, 5000 + offset.Y), new Point(offset.X, -5000 + offset.Y));

            foreach (Line3D line in PM.lines)
            {
                int p0x = Projection(line.p[0]).X;
                int p0y = Projection(line.p[0]).Y;
                int p1x = Projection(line.p[1]).X;
                int p1y = Projection(line.p[1]).Y;
                e.Graphics.DrawLine(Pens.Red, Projection(line.p[0]), Projection(line.p[1]));
            }
        }
    }

    public class ParticalModule01
    {
        public List<Point3D> points;
        public List<Line3D> lines;


        public ParticalModule01()
        {
            lines = new List<Line3D>();
        }

        public void AddLine(Point3D p1, Point3D p2)
        {
            lines.Add(new Line3D(p1, p2));
        }

        public void GlobalRotate(Vector3D v, Point3D refpt)
        {
            //for (int i = 0; i < points.Count; i++)
            //{
            //    points[i] = Dpoint.Rotate(v, refpt, points[i]);
            //}
            foreach (Line3D line in lines){
                line.p[0] = Point3D.Rotate(v, refpt, line.p[0]);
                line.p[1] = Point3D.Rotate(v, refpt, line.p[1]);
            }
        }

        
    }


}
