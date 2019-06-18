using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;

namespace Draw
{
    /// <summary>
    /// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
    /// </summary>
	[Serializable]
    public abstract class Shape
    {
        #region Constructors
        public Shape()
        {

        }

        public Shape(RectangleF rect)
        {
            rectangle = rect;
        }

        public Shape(PointF pt1, PointF pt2)
        {
            point1 = pt1;
            point2 = pt2;
        }

        public Shape(Shape shape)
        {
            this.Height = shape.Height;
            this.Width = shape.Width;
            this.Location = shape.Location;
            this.rectangle = shape.rectangle;
            this.Rotation = shape.Rotation;

            this.FillColor = shape.FillColor;
            this.BorderColor = shape.BorderColor;
        }

        public Shape(Bitmap image)
        {
            this.Height = image.Height;
            this.Width = image.Width;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Име на елемента
        /// </summary>
        private string name;
        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// ВНИМАНИЕ: ТОЗИ АТРИБУТ ИМА ПРОБЛЕМИ СЪС СЕРИАЛИЗАЦИЯТА
        /// Ротационна матрица, която е ползвана за правилната ротация на примитив и неговият hitbox
        /// </summary>
        /*
        private Matrix rotationMatix;
        public virtual Matrix RotationMatrix
        {
            get { return rotationMatix; }
            set { rotationMatix = value; }
        }
        */

        /// <summary>
        /// Обхващащ правоъгълник на елемента.
        /// </summary>
        private RectangleF rectangle;
        public RectangleF Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }

        private PointF point1;
        public PointF Point1
        {
            get { return point1; }
            set { point1 = value; }
        }

        private PointF point2;
        public PointF Point2
        {
            get { return point2; }
            set { point2 = value; }
        }

        /// <summary>
        /// Широчина на елемента.
        /// </summary>
        public float Width
        {
            get { return Rectangle.Width; }
            set { rectangle.Width = value; }
        }

        /// <summary>
        /// Височина на елемента.
        /// </summary>
        public float Height
        {
            get { return Rectangle.Height; }
            set { rectangle.Height = value; }
        }

        public virtual SizeF Size
        {
            get { return Rectangle.Size; }
            set { rectangle.Size = value; }
        }

        public virtual float Rotation { get; set; } // Needs to be set correctly later on

        /// <summary>
        /// Горен ляв ъгъл на елемента.
        /// </summary>
        public virtual PointF Location
        {
            get { return Rectangle.Location; }
            set { rectangle.Location = value; }
        }

        /// <summary>
        /// Цвят на елемента.
        /// </summary>
        private Color fillColor;
        public virtual Color FillColor
        {
            get { return fillColor; }
            set { fillColor = value; }
        }

        private Color borderColor;
        public virtual Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Проверка дали точка point принадлежи на елемента.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Връща true, ако точката принадлежи на елемента и
        /// false, ако не пренадлежи</returns>
        public virtual bool Contains(PointF point)
        {
            if (Rotation != 0)
            {
                double radians = Rotation * Math.PI / 180;
                PointF center = new PointF(Rectangle.Left + Rectangle.Width / 2, Rectangle.Top + Rectangle.Height / 2);

                float newPointX = point.X - center.X;
                float newPointY = point.Y - center.Y;
                double rotationPointX = newPointX * Math.Cos(-radians) - newPointY * Math.Sin(-radians);
                double rotationPointY = newPointY * Math.Cos(-radians) + newPointX * Math.Sin(-radians);
                PointF translatedPoint = new PointF((float)(rotationPointX + center.X), (float)(rotationPointY + center.Y));

                return Rectangle.Contains(translatedPoint);
            }
            return Rectangle.Contains(point); // Drawable
        }

        public virtual bool Contains(PointF[] Polygon, PointF point)
        {
            if (Rotation != 0)
            {
                double radians = Rotation * Math.PI / 180;
                PointF center = new PointF(Rectangle.Left + Rectangle.Width / 2, Rectangle.Top + Rectangle.Height / 2);

                float newPointX = point.X - center.X;
                float newPointY = point.Y - center.Y;
                double rotationPointX = newPointX * Math.Cos(-radians) - newPointY * Math.Sin(-radians);
                double rotationPointY = newPointY * Math.Cos(-radians) + newPointX * Math.Sin(-radians);

                PointF translatedPoint = new PointF((float)(rotationPointX + center.X), (float)(rotationPointY + center.Y));
            }

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
        }

        /// <summary>
        /// Визуализира елемента.
        /// </summary>
        /// <param name="grfx">Къде да бъде визуализиран елемента.</param>
        public virtual void DrawSelf(Graphics grfx)
        {
            //  shape.Rectangle.Inflate(shape.BorderWidth, shape.BorderWidth);

            // grfx.Transform = new Matrix();
            // grfx.RotateTransform(Rotation); // From the Center;
        }

        public virtual void DrawSelf(Graphics grfx, PointF pt1, PointF pt2)
        {
            grfx.DrawLine(new Pen(BorderColor == Color.Empty ? Color.Black : BorderColor), pt1, pt2);
        }

        /// <summary>
        /// Изтрива елемента
        /// </summary>
        /// <param name="grfx"></param>
        public virtual void Remove(Graphics grfx)
        {
            grfx.Dispose();
        }

        public virtual void Rotate(Graphics grfx)
        {
            grfx.Transform.Rotate(Rotation); // From the Center
        }

        public virtual GraphicsPath GetPath(Rectangle bounds)
        {
            GraphicsPath path = new GraphicsPath();

            return path;
        }

        #endregion
    }
}