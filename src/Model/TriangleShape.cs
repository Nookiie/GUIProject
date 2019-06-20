using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    [Serializable]
    public class TriangleShape : Shape
    {
        #region Constructor

        public TriangleShape(RectangleF rect) : base(rect)
        {

        }

        public TriangleShape(EllipseShape rectangle) : base(rectangle)
        {

        }

        public TriangleShape(Pen pen, float centerX, float centerY, float radius)
        {

        }

        #endregion

        #region Methods

        public HashSet<int> hash = new HashSet<int>();

        PointF point1 { get; set; }

        PointF point2 { get; set; }

        PointF point3 { get; set; }

        public PointF[] Polygon { get; set; }

        float x1, x2, x3, y1, y2, y3;
        /* public override GraphicsPath GetPath(Rectangle bounds)
         {
             GraphicsPath path = new GraphicsPath();

             Point top = new Point(bounds.X + bounds.Width / 2, bounds.Y);
             Point right = new Point(bounds.X + bounds.Width, bounds.Y + bounds.Height);
             Point left = new Point(bounds.X, bounds.Y + bounds.Height);

             path.AddPolygon(new Point[]
             {
             top,
             right,
             left
             });
             return path;
         }*/

        public override bool Contains(PointF point)
        {
            double radians = Rotation * Math.PI / 180;
            PointF center = new PointF(Rectangle.Left + Rectangle.Width / 2, Rectangle.Top + Rectangle.Height / 2);

            float newPointX = point.X - center.X;
            float newPointY = point.Y - center.Y;
            double rotationPointX = newPointX * Math.Cos(-radians) - newPointY * Math.Sin(-radians);
            double rotationPointY = newPointY * Math.Cos(-radians) + newPointX * Math.Sin(-radians);

            PointF translatedPoint = new PointF((float)(rotationPointX + center.X), (float)(rotationPointY + center.Y));

            PointF[] polygon = Polygon;
            bool isInside = false;
            for (int i = 0, j = Polygon.Length - 1; i < Polygon.Length; j = i++)
            {
                if (((Polygon[i].Y > translatedPoint.Y) != (Polygon[j].Y > translatedPoint.Y)) &&
                (translatedPoint.X < (Polygon[j].X - Polygon[i].X) * (translatedPoint.Y - Polygon[i].Y) / (Polygon[j].Y - Polygon[i].Y) + Polygon[i].X))
                {
                    isInside = !isInside;
                }
            }
            return isInside;
        }

        public override void Rotate(Graphics grfx)
        {
            base.Rotate(grfx);
        }

        public void Edges(float x1, float y1, float x2, float y2, float x3,
           float y3)
        {
            this.x1 = x1;   //Place value from dialogProcessor AddRandomTriangle                          
            this.x2 = x2;   //into TriangleShape floats
            this.x3 = x3;
            this.y1 = y1;
            this.y2 = y2;
            this.y3 = y3;
        }

        public override void DrawSelf(Graphics grfx)
        { // Create points that define polygon.
            base.DrawSelf(grfx);

            
            x2 = TriangleSize;
            x3 = (x2 + x1) / 2;
            y1 = (float)Math.Sqrt(x2 * x2 - (x2 / 2) * (x2 / 2));
            y2 = (float)Math.Sqrt(x2 * x2 - (x2 / 2) * (x2 / 2));

            Size = new SizeF(x2, y1);

            if (IsBeingResized)
            {
                x1 *= PercentX;
                x2 *= PercentX;
                x3 *= PercentX;

                y1 *= PercentY;
                y2 *= PercentY;
                y3 *= PercentY;
            }
            IsBeingResized = false;

            PointF point1 = new PointF(Rectangle.X + x1, Rectangle.Y + y1);
            PointF point2 = new PointF(Rectangle.X + x2, Rectangle.Y + y2);
            PointF point3 = new PointF(Rectangle.X + x3, Rectangle.Y + y3);

            PointF[] curvePoints =
            {
                 point1,
                 point2,
                 point3,
            };
            Polygon = curvePoints;

            grfx.DrawPolygon(new Pen(BorderColor == Color.Empty ? Color.Black : BorderColor), curvePoints);
            grfx.FillPolygon(new SolidBrush(FillColor), curvePoints);
        }
        #endregion
    }
}
