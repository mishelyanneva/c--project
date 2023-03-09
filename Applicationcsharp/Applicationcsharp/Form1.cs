using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Applicationcsharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Width = 750;
            this.Height= 410;
            bm = new Bitmap(pic.Width, pic.Height);
            g=Graphics.FromImage(bm);
            g.Clear(Color.White);
            pic.Image = bm;
        }

        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);
        Pen eraser = new Pen(Color.White, 10);
        int index;
        int x, y, sX, sY, cX, cY;
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        private void Form1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pic_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            paint= true;
            py= e.Location;

            cX = e.X; 
            cY = e.Y;
        }
        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                if(index==1)
                {
                    px = e.Location;
                    g.DrawLine(p,px, py);
                    py = px;
                }

                if (index == 2)
                {
                    px = e.Location;
                    g.DrawLine(eraser, px, py);
                    py = px;
                }
            
                pic.Refresh();
                x= e.X; 
                y= e.Y;
                sX= e.X-cX;
                sY= e.Y-cY;
            }
        }

        private void pic_Click(object sender, EventArgs e)
        {

        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            paint= false;

            sX = x - cX;
            sY = y - cY;

            if (index == 3)
            {
                g.DrawEllipse(p,cX,cY,sX,sY);
            }
            if (index == 4)
            {
                g.DrawRectangle(p, cX, cY, sX, sY);
            }
            if (index == 5)
            {
                g.DrawLine(p, cX, cY, x, y);
            }
        }
        private void btn_pencil_Click(object sender, EventArgs e)
        {
            index= 1;

        }
        private void btn_eraser_click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void btn_ellipse_Click(object sender, EventArgs e)
        {
            index = 3;
        }
        private void btn_rectangle_Click(object sender, EventArgs e)
        {
            index = 4;
        }
        private void btn_line_Click(object sender, EventArgs e)
        {
            index = 5;
        }

    }
}
