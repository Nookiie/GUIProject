using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    [Serializable]
    public class CustomShape : Shape
    {
        #region Constructor

        public CustomShape(RectangleF rect) : base(rect)
        {

        }

        public CustomShape(EllipseShape rectangle) : base(rectangle)
        {

        }

        public CustomShape(Pen pen, float centerX, float centerY, float radius)
        {

        }

        /*
        public CustomShape(PointF pt1, PointF pt2, PointF pt3, PointF pt4, PointF pt5,
            PointF pt6, PointF pt7) : base( pt1,  pt2,  pt3, pt4,  pt5,  pt6, pt7)
        {
            this.point1 = pt1;
            this.point2 = pt2;
            this.point3 = pt3;
            this.point4 = pt4;
            this.point5 = pt5;
            this.point6 = pt6;
            this.point7 = pt7;
        }
        */
        #endregion

        public HashSet<int> hash = new HashSet<int>();

        PointF point1 { get; set; }
        PointF point2 { get; set; }
        PointF point3 { get; set; }
        PointF point4 { get; set; }
        PointF point5 { get; set; }
        PointF point6 { get; set; }
        PointF point7 { get; set; }

        public PointF[] Polygon { get; set; }

        float x1, x2, x3, x4, x5, x6, x7;
        float y1, y2, y3, y4, y5, y6, y7;

        static int numberOfPoints = 7;
        float[] x = new float[numberOfPoints];
        float[] y = new float[numberOfPoints];

        PointF[] points = new PointF[numberOfPoints];
        #region Methods
        /// <summary>
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// </summary>
        public override bool Contains(PointF point)
        {
            PointF[] polygon = Polygon;
            bool isInside = false;
            for (int i = 0, j = Polygon.Length - 1; i < Polygon.Length; j = i++)
            {
                if (((Polygon[i].Y > point.Y) != (Polygon[j].Y > point.Y)) &&
                (point.X < (Polygon[j].X - Polygon[i].X) * (point.Y - Polygon[i].Y) / (Polygon[j].Y - Polygon[i].Y) + Polygon[i].X))
                {
                    isInside = !isInside;
                }
            }
            return isInside;
            //  return base.Contains(polygon, point);
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        ///
        /*public void edges(PointF pt1, PointF pt2, PointF pt3, PointF pt4, PointF pt5,
            PointF pt6, PointF pt7)*/

        public void Edges(float x1, float y1, float x2, float y2, float x3,
            float y3, float x4, float y4, float x5, float y5, float x6, float y6, float x7, float y7)
        {
            this.x1 = x1;   //Place value from dialogProcessor AddRandomCustomShape                           
            this.x2 = x2;   //into CustomShape floats
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
            this.x6 = x6;
            this.x7 = x7;

            this.y1 = y1;
            this.y2 = y2;
            this.y3 = y3;
            this.y4 = y4;
            this.y5 = y5;
            this.y6 = y6;
            this.y7 = y7;
            /*
            point1 = new PointF(Rectangle.X + x1, Rectangle.Y + y1);
            point2 = new PointF(Rectangle.X + x2, Rectangle.Y + y2);
            point3 = new PointF(Rectangle.X + x3, Rectangle.Y + y3);
            point4 = new PointF(Rectangle.X + x4, Rectangle.Y + y4);
            point5 = new PointF(Rectangle.X + x5, Rectangle.Y + y5);
            point6 = new PointF(Rectangle.X + x6, Rectangle.Y + y6);
            point7 = new PointF(Rectangle.X + x7, Rectangle.Y + y7);*/
        }

        /// <summary>
        /// Възможност за оптимизация на алгоритъма с по-лесно добавяне на повече точки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void EdgesOptimised(float[] x, float[] y)
        {
            this.x = x;
            this.y = y;
        }

        public override void DrawSelf(Graphics grfx)
        {
            // Create points that define polygon.
            base.DrawSelf(grfx);

            /*  
            int x1 = (Int32)Rectangle.X;
            int x2 = (Int32)(Rectangle.X + Rectangle.Width);
            int y1 = (Int32)Rectangle.Y;
            int y2 = (Int32)(Rectangle.Y + Rectangle.Height);
            */

            PointF point1 = new PointF(Rectangle.X + x1, Rectangle.Y + y1);
            PointF point2 = new PointF(Rectangle.X + x2, Rectangle.Y + y2);
            PointF point3 = new PointF(Rectangle.X + x3, Rectangle.Y + y3);
            PointF point4 = new PointF(Rectangle.X + x4, Rectangle.Y + y4);
            PointF point5 = new PointF(Rectangle.X + x5, Rectangle.Y + y5);
            PointF point6 = new PointF(Rectangle.X + x6, Rectangle.Y + y6);
            PointF point7 = new PointF(Rectangle.X + x7, Rectangle.Y + y7);

            for (int i = 0; i < numberOfPoints; i++)
            {
                points[i].X = Rectangle.X + x.ElementAt(i);
                points[i].Y = Rectangle.Y + y.ElementAt(i);
            }

            /*
             PointF point1 = new PointF(Rectangle.X + 10, Rectangle.Y + 10);   //Would work for
             PointF point2 = new PointF(Rectangle.X + 90, Rectangle.Y + 30);   //manual placing
             PointF point3 = new PointF(Rectangle.X + 47, Rectangle.Y + 70);
             PointF point4 = new PointF(Rectangle.X + 30, Rectangle.Y + 20);
             PointF point5 = new PointF(Rectangle.X + 87, Rectangle.Y + 50);
             PointF point6 = new PointF(Rectangle.X + 10, Rectangle.Y + 10);
             PointF point7 = new PointF(Rectangle.X + 10, Rectangle.Y + 10);

             PointF point1 = new PointF(p1x, p1y);
             PointF point2 = new PointF(p2x, p2y);
             PointF point3 = new PointF(p3x, p3y);
             PointF point4 = new PointF(p4x, p4y);
             PointF point5 = new PointF(p5x, p5y);
             PointF point6 = new PointF(p6x, p6y);
             PointF point7 = new PointF(p7x, p7y);
             */

            PointF[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5,
                 point6,
                 point7
             };

            Polygon = curvePoints;

            grfx.DrawPolygon(new Pen(BorderColor == Color.Empty ? Color.Black : BorderColor), curvePoints);
            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Transparency, FillColor.R, FillColor.G, FillColor.B)), curvePoints);
        }

        public override void Remove(Graphics grfx)
        {
            base.Remove(grfx);
        }

        public override void Rotate(Graphics grfx)
        {
            base.Rotate(grfx);
        }

        /* public override GraphicsPath GetPath(Rectangle bounds)
         {
             GraphicsPath path = new GraphicsPath();

            // path.AddEllipse(bounds);
             return path;
         }*/
        #endregion
    }
}
