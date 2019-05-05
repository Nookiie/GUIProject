using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на дисплейната система.
	/// </summary>
	public class DisplayProcessor
	{
		#region Constructor
		
		public DisplayProcessor()
		{
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Списък с всички елементи формиращи изображението.
		/// </summary>
		private List<Shape> shapeList = new List<Shape>();		
		public List<Shape> ShapeList {
			get { return shapeList; }
			set { shapeList = value; }
		}

        public List<Bitmap> imageList = new List<Bitmap>();
        public List<Bitmap> ImageList
        {
            get { return imageList; }
            set { imageList = value; }
        }

		#endregion
		
		#region Drawing
		
		/// <summary>
		/// Прерисува всички елементи в shapeList върху e.Graphics
		/// </summary>
		public void ReDraw(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Draw(e.Graphics);
		}

        public void Remove(object sender, PaintEventArgs e, Shape item)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Remove(e.Graphics,item);
        }

        public void ReRotate(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rotate(e.Graphics);
        }

		/// <summary>
		/// Визуализация.
		/// Обхождане на всички елементи в списъка и извикване на визуализиращия им метод.
		/// </summary>
		/// <param name="grfx">Къде да се извърши визуализацията.</param>
		public virtual void Draw(Graphics grfx)
		{
			foreach (Shape item in ShapeList){
				DrawShape(grfx, item);
			}
		}
		
        public virtual void Remove(Graphics grfx, Shape item)
        {
            shapeList.Remove(item);
        }

        public virtual void RemoveLast()
        {
            if(shapeList.Count != 0)
                shapeList.RemoveAt(0);
        }

        public virtual void RemoveAll()
        {
            shapeList.RemoveAll(x => x.Size == x.Size);
        }

        public virtual void RemoveSelected(Shape item)
        {
            shapeList.Remove(item);
        }

		/// <summary>
		/// Визуализира даден елемент от изображението.
		/// </summary>
		/// <param name="grfx">Къде да се извърши визуализацията.</param>
		/// <param name="item">Елемент за визуализиране.</param>
		public virtual void DrawShape(Graphics grfx, Shape item)
		{
			item.DrawSelf(grfx);
		}

        public virtual void Rotate(Graphics grfx)
        {
            foreach(Shape item in ShapeList)
            {
                RotateShape(grfx, item);
            }
        }

        public virtual void RotateShape(Graphics grfx, Shape item)
        {
            item.Rotate(grfx);
        }

        public virtual void Paint(Color color, Shape item)
        {
            item.FillColor = color;
        }
		#endregion
	}
}
