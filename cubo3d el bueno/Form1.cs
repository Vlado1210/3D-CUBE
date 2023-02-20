using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Numerics;


namespace cubo3d_el_bueno
{
    public partial class Form1 : Form
    {

        Bitmap bmp;
        Graphics g;
        private Point l1, l2, l3, l4;
        private int width, height, wMid, hMid;
        private Point origen;
        private PointF squareA, squareB, squareC, squareD, squareE, squareF, squareG, squareH;

        Matrix projectionMatrix = new Matrix();
        int[] P1 = new int[3];
        int[] P2 = new int[3];
        int[] P3 = new int[3];
        int[] P4 = new int[3];
        int[] P5 = new int[3];
        int[] P6 = new int[3];
        int[] P7 = new int[3];
        int[] P8 = new int[3];

        float[] P1r, P2r, P3r, P4r;
        float[] P5r, P6r, P7r, P8r;

        float[] P1p, P2p, P3p, P4p;
        float[] P5p, P6p, P7p, P8p;

        double angle = 0;
        double angleConverted;

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
            timer3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            timer1.Enabled = false;
            timer3.Enabled = false;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            timer3.Enabled = true;
            timer2.Enabled = false;
            timer1.Enabled = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            P1[0] = -1; P1[1] = -1; P1[2] = 1;

            P2[0] = 1; P2[1] = -1; P2[2] = 1;

            P3[0] = 1; P3[1] = 1; P3[2] = 1;

            P4[0] = -1; P4[1] = 1; P4[2] = 1;

            P5[0] = -1; P5[1] = -1; P5[2] = -1;

            P6[0] = 1; P6[1] = -1; P6[2] = -1;

            P7[0] = 1; P7[1] = 1; P7[2] = -1;

            P8[0] = -1; P8[1] = 1; P8[2] = -1;
        }        
        private void timer1_Tick(object sender, EventArgs e)
        {
            angle -= 1;
            angleConverted = angle * (Math.PI / 180);

            InitializePictureBox(width, height);
            //Front side
            P1r = projectionMatrix.rotationX(P1, angleConverted);
            P2r = projectionMatrix.rotationX(P2, angleConverted);
            P3r = projectionMatrix.rotationX(P3, angleConverted);
            P4r = projectionMatrix.rotationX(P4, angleConverted);

            //Back side
            P5r = projectionMatrix.rotationX(P5, angleConverted);
            P6r = projectionMatrix.rotationX(P6, angleConverted);
            P7r = projectionMatrix.rotationX(P7, angleConverted);
            P8r = projectionMatrix.rotationX(P8, angleConverted);

            //Front side
            P1p = projectionMatrix.multiply(P1r, 3);
            P2p = projectionMatrix.multiply(P2r, 3);
            P3p = projectionMatrix.multiply(P3r, 3);
            P4p = projectionMatrix.multiply(P4r, 3);

            //Back side
            P5p = projectionMatrix.multiply(P5r, 3);
            P6p = projectionMatrix.multiply(P6r, 3);
            P7p = projectionMatrix.multiply(P7r, 3);
            P8p = projectionMatrix.multiply(P8r, 3);

            // Points to draw the square, front side
            squareA = new PointF(P1p[0] * 100, P1p[1] * 100);
            squareB = new PointF(P2p[0] * 100, P2p[1] * 100);
            squareC = new PointF(P3p[0] * 100, P3p[1] * 100);
            squareD = new PointF(P4p[0] * 100, P4p[1] * 100);

            // Points to draw the square, back side
            squareE = new PointF(P5p[0] * 100, P5p[1] * 100);
            squareF = new PointF(P6p[0] * 100, P6p[1] * 100);
            squareG = new PointF(P7p[0] * 100, P7p[1] * 100);
            squareH = new PointF(P8p[0] * 100, P8p[1] * 100);

            ///Draw the square, front side
            Render(squareA, squareB, 0);
            Render(squareB, squareC, 0);
            Render(squareC, squareD, 0);
            Render(squareD, squareA, 0);

            //Draw the square, back side
            Render(squareE, squareF, 0);
            Render(squareF, squareG, 0);
            Render(squareG, squareH, 0);
            Render(squareH, squareE, 0);

            //Draw the square, interconect lines
            Render(squareA, squareE, 0);
            Render(squareB, squareF, 0);
            Render(squareC, squareG, 0);
            Render(squareD, squareH, 0);
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            angle -= 1;
            angleConverted = angle * (Math.PI / 180);

            InitializePictureBox(width, height);
            //Front side
            P1r = projectionMatrix.rotationY(P1, angleConverted);
            P2r = projectionMatrix.rotationY(P2, angleConverted);
            P3r = projectionMatrix.rotationY(P3, angleConverted);
            P4r = projectionMatrix.rotationY(P4, angleConverted);

            //Back side
            P5r = projectionMatrix.rotationY(P5, angleConverted);
            P6r = projectionMatrix.rotationY(P6, angleConverted);
            P7r = projectionMatrix.rotationY(P7, angleConverted);
            P8r = projectionMatrix.rotationY(P8, angleConverted);

            //Front side
            P1p = projectionMatrix.multiply(P1r, 3);
            P2p = projectionMatrix.multiply(P2r, 3);
            P3p = projectionMatrix.multiply(P3r, 3);
            P4p = projectionMatrix.multiply(P4r, 3);

            //Back side
            P5p = projectionMatrix.multiply(P5r, 3);
            P6p = projectionMatrix.multiply(P6r, 3);
            P7p = projectionMatrix.multiply(P7r, 3);
            P8p = projectionMatrix.multiply(P8r, 3);

            // Points to draw the square, front side
            squareA = new PointF(P1p[0] * 100, P1p[1] * 100);
            squareB = new PointF(P2p[0] * 100, P2p[1] * 100);
            squareC = new PointF(P3p[0] * 100, P3p[1] * 100);
            squareD = new PointF(P4p[0] * 100, P4p[1] * 100);

            // Points to draw the square, back side
            squareE = new PointF(P5p[0] * 100, P5p[1] * 100);
            squareF = new PointF(P6p[0] * 100, P6p[1] * 100);
            squareG = new PointF(P7p[0] * 100, P7p[1] * 100);
            squareH = new PointF(P8p[0] * 100, P8p[1] * 100);

            ///Draw the square, front side
            Render(squareA, squareB, 0);
            Render(squareB, squareC, 0);
            Render(squareC, squareD, 0);
            Render(squareD, squareA, 0);

            //Draw the square, back side
            Render(squareE, squareF, 0);
            Render(squareF, squareG, 0);
            Render(squareG, squareH, 0);
            Render(squareH, squareE, 0);

            //Draw the square, interconect lines
            Render(squareA, squareE, 0);
            Render(squareB, squareF, 0);
            Render(squareC, squareG, 0);
            Render(squareD, squareH, 0);
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            angle -= 1;
            angleConverted = angle * (Math.PI / 180);

            InitializePictureBox(width, height);
            //Front side
            P1r = projectionMatrix.rotationZ(P1, angleConverted);
            P2r = projectionMatrix.rotationZ(P2, angleConverted);
            P3r = projectionMatrix.rotationZ(P3, angleConverted);
            P4r = projectionMatrix.rotationZ(P4, angleConverted);

            //Back side
            P5r = projectionMatrix.rotationZ(P5, angleConverted);
            P6r = projectionMatrix.rotationZ(P6, angleConverted);
            P7r = projectionMatrix.rotationZ(P7, angleConverted);
            P8r = projectionMatrix.rotationZ(P8, angleConverted);

            //Front side
            P1p = projectionMatrix.multiply(P1r, 3);
            P2p = projectionMatrix.multiply(P2r, 3);
            P3p = projectionMatrix.multiply(P3r, 3);
            P4p = projectionMatrix.multiply(P4r, 3);

            //Back side
            P5p = projectionMatrix.multiply(P5r, 3);
            P6p = projectionMatrix.multiply(P6r, 3);
            P7p = projectionMatrix.multiply(P7r, 3);
            P8p = projectionMatrix.multiply(P8r, 3);

            // Points to draw the square, front side
            squareA = new PointF(P1p[0] * 100, P1p[1] * 100);
            squareB = new PointF(P2p[0] * 100, P2p[1] * 100);
            squareC = new PointF(P3p[0] * 100, P3p[1] * 100);
            squareD = new PointF(P4p[0] * 100, P4p[1] * 100);

            // Points to draw the square, back side
            squareE = new PointF(P5p[0] * 100, P5p[1] * 100);
            squareF = new PointF(P6p[0] * 100, P6p[1] * 100);
            squareG = new PointF(P7p[0] * 100, P7p[1] * 100);
            squareH = new PointF(P8p[0] * 100, P8p[1] * 100);

            ///Draw the square, front side
            Render(squareA, squareB, 0);
            Render(squareB, squareC, 0);
            Render(squareC, squareD, 0);
            Render(squareD, squareA, 0);

            //Draw the square, back side
            Render(squareE, squareF, 0);
            Render(squareF, squareG, 0);
            Render(squareG, squareH, 0);
            Render(squareH, squareE, 0);

            //Draw the square, interconect lines
            Render(squareA, squareE, 0);
            Render(squareB, squareF, 0);
            Render(squareC, squareG, 0);
            Render(squareD, squareH, 0);
        }
        
        public Form1()
        {
            InitializeComponent();
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            wMid = width / 2;
            hMid = height / 2;
            origen = new Point(wMid, hMid);
            InitializePictureBox(width, height);
            angleConverted = angle * (Math.PI / 180);

        }

        private void InitializePictureBox(int width, int height)
        {
            bmp = new Bitmap(width, height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);
            l1 = new Point(origen.X, 0);
            l2 = new Point(origen.X, height);
            l3 = new Point(0, origen.Y);
            l4 = new Point(width, origen.Y);
            g.DrawLine(Pens.Pink, l1, l2);
            g.DrawLine(Pens.Pink, l3, l4);
           
        }



        private void Render(PointF a, PointF b, double angle)
        {
            PointF a2, b2;

            a2 = new PointF(origen.X + a.X, origen.Y - a.Y);
            b2 = new PointF(origen.X + b.X, origen.Y - b.Y);

            // Equations to rotate
            a2.X = origen.X + (float)((a.X * Math.Cos(angle)) - (a.Y * Math.Sin(angle)));
            a2.Y = origen.Y - (float)((a.X * Math.Sin(angle)) + (a.Y * Math.Cos(angle)));

            b2.X = origen.X + (float)((b.X * Math.Cos(angle)) - (b.Y * Math.Sin(angle)));
            b2.Y = origen.Y - (float)((b.X * Math.Sin(angle)) + (b.Y * Math.Cos(angle)));

            // Draw line
            g.DrawLine(Pens.MediumTurquoise, a2, b2);

            pictureBox1.Invalidate();
        }
    }
}
