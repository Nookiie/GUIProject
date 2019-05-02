using System;
using System.Drawing;

namespace Draw
{
	/// <summary>
	/// Базовия клас на примитивите, който съдържа общите характеристики на примитивите.
	/// </summary>
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

		public Shape(PointF pt)
        {
            point = pt;
        }

		public Shape(Shape shape)
		{
			this.Height = shape.Height;
			this.Width = shape.Width;
			this.Location = shape.Location;
			this.rectangle = shape.rectangle;
            this.Rotation = shape.Rotation;

			this.FillColor =  shape.FillColor;
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
		/// Обхващащ правоъгълник на елемента.
		/// </summary>
		private RectangleF rectangle;		
		public virtual RectangleF Rectangle {
			get { return rectangle; }
			set { rectangle = value; }
		}

        private PointF point;
        public virtual PointF Point {
            get { return point; }
            set { point = value; }
        }
       
		/// <summary>
		/// Широчина на елемента.
		/// </summary>
		public virtual float Width {
			get { return Rectangle.Width; }
			set { rectangle.Width = value; }
		} 
		
		/// <summary>
		/// Височина на елемента.
		/// </summary>
		public virtual float Height {
			get { return Rectangle.Height; }
			set { rectangle.Height = value; }
		}

        public virtual SizeF Size{
            get { return Rectangle.Size; }
            set { rectangle.Size = value; }
        }
       
        public virtual float Rotation { get; set; } // Needs to be set correctly later on

		/// <summary>
		/// Горен ляв ъгъл на елемента.
		/// </summary>
		public virtual PointF Location {
			get { return Rectangle.Location; }
			set { rectangle.Location = value; }
		}

        /// <summary>
        /// Цвят на елемента.
        /// </summary>
        private Color fillColor;		
		public virtual Color FillColor {
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
			return Rectangle.Contains(point.X, point.Y); // Drawable
		}
		
		/// <summary>
		/// Визуализира елемента.
		/// </summary>
		/// <param name="grfx">Къде да бъде визуализиран елемента.</param>
		public virtual void DrawSelf(Graphics grfx)
		{
             // Rotate(grfx);
            // shape.Rectangle.Inflate(shape.BorderWidth, shape.BorderWidth);
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
            // grfx.TranslateTransform((float)rectangle.Width / 2, (float)rectangle.Height / 2);
            grfx.RotateTransform(Rotation);
            // grfx.TranslateTransform(-(float)rectangle.Width / 2, -(float)rectangle.Height / 2);
            // grfx.DrawRectangleOrShape.....   
        }
        #endregion
    }
}
