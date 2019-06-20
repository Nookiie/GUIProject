using System;
using System.Collections.Generic;
using System.Drawing;

namespace Draw
{
    /// <summary>
    /// Класът ... е основен примитив, който е наследник на базовия Shape.
    /// </summary>
	[Serializable]
    public class LineShape : Shape
    {
        #region Constructor

        public LineShape(PointF pt1, PointF pt2) : base(pt1, pt2)
        {

        }

        public LineShape(LineShape line) : base(line)
        {

        }

        public LineShape(RectangleF rect) : base(rect)
        {

        }

        #endregion

        #region Properties
        #endregion
        /*   PointF point1 { get; set; }
           PointF point2 { get; set; }
           PointF point3 { get; set; }
           PointF point4 { get; set; }
         */
        PointF pointStart { get; set; }
        PointF pointEnd { get; set; }
        /*  public PointF[] ContainsPolygon { get; set; }
          float x1, x2, x3,x4, y1, y2, y3,y4;
          */
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
           /*
            //WE USE THE SURROUNDING RECTANGLE FOR CONTAINS THROUGH BASE!
            double radians = Rotation * Math.PI / 180;
            PointF center = new PointF(Rectangle.Left + Rectangle.Width / 2, Rectangle.Top + Rectangle.Height / 2);
            float newPointX = point.X - center.X;
            float newPointY = point.Y - center.Y;
            //  PointF newMousePoint = new PointF(newPointX, newPointY);
            double rotationPointX = newPointX * Math.Cos(-radians) - newPointY * Math.Sin(-radians);
            double rotationPointY = newPointY * Math.Cos(-radians) + newPointX * Math.Sin(-radians);
            PointF translatedPoint = new PointF((float)(rotationPointX + center.X), (float)(rotationPointY + center.Y));
            point = translatedPoint;
            */
            if (base.Contains(point))
                return true; /// <-----
            else
                return false;
        }
        public void edges(float x1, float y1, float x2, float y2)
        {
            this.x1 = x1;
            this.x2 = x2;

            this.y1 = y1;
            this.y2 = y2;
            this.pointStart = new PointF(x1, y1);
            this.pointEnd = new PointF(x2, y2);
        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
         
            if (IsBeingResized == true)
            {
                y2 *= PercentY;

            }
            IsBeingResized = false;

            pointStart = new PointF(Rectangle.X + x1, Rectangle.Y + y1);
            pointEnd = new PointF(Rectangle.X + x2, Rectangle.Y + y2);


            //   base.DrawSelf(grfx,pointStart,pointEnd);
            grfx.DrawLine(new Pen(BorderColor == Color.Empty ? Color.Black : BorderColor), pointStart, pointEnd);

        }

        /*    public override void DrawSelf(Graphics grfx, PointF pt1, PointF pt2)
            {
                base.DrawSelf(grfx, pt1, pt2);
            }
            */
        ///<summary>
        ///X,Y X1,Y1, X2,Y2 Formula to Select the LineShape comes from the EllipseShape as well as for Rotation
        ///</summary>
        #endregion
    }
}