using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Draw
{
    /// <summary>
    /// Класът ... е основен примитив, който е наследник на базовия Shape.
    /// </summary>
    public class EllipseShape : Shape
    {
        #region Constructor

        public EllipseShape(RectangleF rect) : base(rect)
        {
                
        }

        public EllipseShape(EllipseShape rectangle) : base(rectangle)
        {
           
        }

        public EllipseShape(Pen pen, float centerX,float centerY,float radius) 
        {
                
        }

        #endregion

        public HashSet<int> hash = new HashSet<int>();

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
            float radiusX = Rectangle.Width / 2;
            float radiusY = Rectangle.Height / 2;

            float centerX = Rectangle.Left + radiusX;
            float centerY = Rectangle.Top + radiusY;

            /*      //For Circle!                              

             double compare=Math.Sqrt(Math.Pow((point.X - centerX), 2)+Math.Pow((point.Y-centerY),2));  //For circle

             if(compare<=radiusX)  //For circle
            */
            // (x - h) ^ 2 / a ^ 2 + (y - k) ^ 2 / b ^ 2 <= 1   //Used Formula for ellipse
            float a = radiusX;
            float b = radiusY;

            double compare = Math.Pow((point.X - centerX), 2) / Math.Pow(a, 2) + Math.Pow((point.Y - centerY), 2) / Math.Pow(b, 2);

            if (compare<=1)
                return true;    
            else
                return false;  

        }

        /// <summary>
        /// Частта, визуализираща конкретния примитив.
        /// </summary>
        public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
            
            grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawEllipse(new Pen(BorderColor == Color.Empty ? Color.Black : BorderColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
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
