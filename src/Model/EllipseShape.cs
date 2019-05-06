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
            if (Rectangle.Width == Rectangle.Height) // Формула само и единствено за кръг
            {
                float radiusX = Rectangle.Width / 2;
                float radiusY = Rectangle.Height / 2;

                float centerX = Rectangle.Left + radiusX;
                float centerY = Rectangle.Top + radiusY;

                double compare = Math.Sqrt(Math.Pow((point.X - centerX), 2) + Math.Pow((point.Y - centerY), 2));

                // double ResultFormula = (Math.Pow(radiusY,2) * Math.Pow(point.X,2)) + (Math.Pow(radiusX,2) * Math.Pow(point.Y,2)) - (Math.Pow(radiusX,2) * Math.Pow(radiusY,2));
                /*
                * 
                 * geeksforgeeks.org/midpoint-ellipse-drawing-algorithm - Може да ни е от полза
                 */
                // if (point.X*point.X*radiusY*radiusY + point.Y*radiusX*radiusX <= radiusX*radiusX*radiusY*radiusY) // Something similiar needed for the algorithm
                //if (ResultFormula<=0)
                
                if (compare <= radiusX)
                    return true;
                else
                    return false;
            }
            else if (base.Contains(point))
            {
                return true;
            }
            else
            {
                return false;
            }
                

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
