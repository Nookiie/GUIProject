using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Draw.src.Model
{
    class CustomShape : Shape
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

        #endregion

        public HashSet<int> hash = new HashSet<int>();

        public PointF[] Polygon { get; set; }

        #region Methods
        /// <summary>
        /// Проверка за принадлежност на точка point към правоъгълника.
        /// В случая на правоъгълник този метод може да не бъде пренаписван, защото
        /// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
        /// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
        /// елемента в този случай).
        /// </summary>
        public override bool Contains(PointF[] polygon, PointF point)
        {
            polygon = Polygon;
            return base.Contains(polygon, point);
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);

            // Create points that define polygon.
            PointF point1 = new PointF(50.0F, 50.0F);
            PointF point2 = new PointF(100.0F, 25.0F);
            PointF point3 = new PointF(200.0F, 5.0F);
            PointF point4 = new PointF(250.0F, 50.0F);
            PointF point5 = new PointF(300.0F, 100.0F);
            PointF point6 = new PointF(350.0F, 200.0F);
            PointF point7 = new PointF(250.0F, 250.0F);
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
            grfx.FillPolygon(new SolidBrush(FillColor), curvePoints);
        }

        public override void Remove(Graphics grfx)
        {
            base.Remove(grfx);
        }

        public override void Rotate(Graphics grfx)
        {
            base.Rotate(grfx);
        }

        public override GraphicsPath GetPath(Rectangle bounds)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddEllipse(bounds);
            return path;
        }
        #endregion
    }
}
