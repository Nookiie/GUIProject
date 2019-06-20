using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    public class TrapezoidShape : Shape
    {
        #region Constructor

        public TrapezoidShape(RectangleF rect) : base(rect)
        {

        }

        public TrapezoidShape(EllipseShape rectangle) : base(rectangle)
        {

        }

        public TrapezoidShape(Pen pen, float centerX, float centerY, float radius)
        {

        }

        #endregion

        #region Methods

        public HashSet<int> hash = new HashSet<int>();

        PointF point1 { get; set; }
        PointF point2 { get; set; }
        PointF point3 { get; set; }

        PointF a, b, c, d;

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

        public void Edges(PointF a, PointF b, PointF c, PointF d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public override void DrawSelf(Graphics grfx)
        { // Create points that define polygon.
            base.DrawSelf(grfx);

            PointF point1 = new PointF(Rectangle.X + a.X, Rectangle.Y + a.Y);
            PointF point2 = new PointF(Rectangle.X + b.X, Rectangle.Y + b.Y);
            PointF point3 = new PointF(Rectangle.X + c.X, Rectangle.Y + c.Y);
            PointF point4 = new PointF(Rectangle.X + d.X, Rectangle.Y + d.Y);

            PointF[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
                 point4
             };
            Polygon = curvePoints;

            grfx.DrawPolygon(new Pen(BorderColor == Color.Empty ? Color.Black : BorderColor), curvePoints);
            grfx.FillPolygon(new SolidBrush(Color.FromArgb(Transparency, FillColor.R, FillColor.G, FillColor.B)), curvePoints);
        }
        #endregion
    }
}
