using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;



namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private List<Rectangle> shapes;

        public Form1()
        {
            InitializeComponent();
            shapes = new List<Rectangle>();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }
        private void btn_rectangle_Click(object sender, EventArgs e)
        {
            shapes.Add(new RectangleShape(new Point(10, 10), new Size(50, 50)));
            Invalidate();
        }

        public abstract class Shape
        {
            protected Point location;
            protected Size size;

            public Shape(Point location, Size size)
            {
                this.location = location;
                this.size = size;
            }

            public abstract double CalculateArea();

            public abstract void Draw(Graphics graphics);

            public virtual void Move(int x, int y)
            {
                location.X += x;
                location.Y += y;
            }
        }
        public class RectangleShape : Shape
        {
           

            public RectangleShape(Point location, Size size) : base(location, size)
            {

            }

            public override double CalculateArea()
            {
                return size.Width * size.Height;
            }

            public override void Draw(Graphics graphics)
            {
                graphics.DrawRectangle(Pens.Black, new Rectangle(location, size));
            }
        }
        private void btn_color_picker_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            
            
        }

        private void btn_triangle_Click(object sender, EventArgs e)
        {

        }

        
    }
}

