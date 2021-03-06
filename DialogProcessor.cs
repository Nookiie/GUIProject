﻿using Draw.src.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Draw
{
	/// <summary>
	/// Класът, който ще бъде използван при управляване на диалога.
	/// </summary>
	public class DialogProcessor : DisplayProcessor
	{
		#region Constructor

		public DialogProcessor()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// Избран елемент.
		/// </summary>

		// public Color BorderColor;

		private List<Shape> selection = new List<Shape>();
		public List<Shape> Selection
		{
			get { return selection; }
			set { selection = value; }
		}

		private Color borderColor;
		public Color ColorBorder
		{
			get { return borderColor; }
			set { borderColor = value; }
		}

		private Color ColorFill;
		public Color FillColor
		{
			get { return ColorFill; }
			set { ColorFill = value; }
		}

		private PointF pt1;
		public PointF PointStart
		{
			get { return pt1; }
			set { pt1 = value; }
		}

		private PointF pt2;
		public PointF PointEnd
		{
			get { return pt2; }
			set { pt2 = value; }
		}

		private float rotation;
		public float Rotation
		{
			get { return rotation; }
			set { rotation = value; }
		}

		/// <summary>
		/// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
		/// </summary>
		private bool isDragging;
		public bool IsDragging
		{
			get { return isDragging; }
			set { isDragging = value; }
		}

		/// <summary>
		/// Последна позиция на мишката при "влачене".
		/// Използва се за определяне на вектора на транслация.
		/// </summary>
		private PointF lastLocation;
		public PointF LastLocation
		{
			get { return lastLocation; }
			set { lastLocation = value; }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Добавя примитив - правоъгълник на произволно място върху клиентската област.
		/// </summary>
		public void AddRandomRectangle()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			RectangleShape rect = new RectangleShape(new Rectangle(x, y, 100, 200));
			rect.FillColor = ColorFill;
			rect.Rotation = Rotation;
			rect.BorderColor = ColorBorder;

			ShapeList.Add(rect);
		}

		public void AddRandomEllipse()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			EllipseShape ellipse = new EllipseShape(new Rectangle(x, y, 200, 200));

			ellipse.FillColor = ColorFill;
			ellipse.Rotation = Rotation;
			ellipse.BorderColor = ColorBorder;

			ShapeList.Add(ellipse);
		}

		public void AddRandomLine()
		{
			// Random rnd = new Random();

			LineShape line = new LineShape(PointStart, PointEnd);

			line.BorderColor = ColorBorder;

			ShapeList.Add(line);
		}

		public void AddRandomImage()
		{
			Random rnd = new Random();
			int x = rnd.Next(100, 1000);
			int y = rnd.Next(100, 600);

			Bitmap image = new Bitmap(new Bitmap("image.jpg"));
			ImageList.Add(image);
		}

		public void AddRandomCustomShape()
		{
			Random rnd = new Random();

			int x = rnd.Next(100, 1000);    //Generate random position for the rectangle
			int y = rnd.Next(100, 600);
			float p1x = 0;             //Left most x in the rectangle
			float p1y = rnd.Next(0, 200);

			float p2x = rnd.Next(0, 200);
			float p2y = 0;             // the top most Y edge of the rectangle

			float p3x = rnd.Next(0, 200);
			float p3y = rnd.Next(0, 200);

			float p4x = rnd.Next(0, 200);
			float p4y = rnd.Next(0, 200);

			float p5x = rnd.Next(0, 200);
			float p5y = rnd.Next(0, 200);

			float p6x = rnd.Next(0, 200);
			float p6y = rnd.Next(0, 200);

			float p7x = rnd.Next(0, 200);
			float p7y = rnd.Next(0, 200);
			float[] edges = new float[7];

			edges[0] = p1x;
			edges[1] = p2x;
			edges[2] = p3x;
			edges[3] = p4x;
			edges[4] = p5x;
			edges[5] = p6x;
			edges[6] = p7x;
			int x1 = 10000;//leftmost x Unused
			int x2 = 0;//rightmost x
			for (int i = 0; i < edges.Length; i++)
			{
				if (edges[i] < x1)
				{
					x1 = (Int32)edges[i];
				}
				if (edges[i] > x2)
				{
					x2 = (Int32)edges[i];
				}
			}

			edges[0] = p1y;
			edges[1] = p2y;
			edges[2] = p3y;
			edges[3] = p4y;
			edges[4] = p5y;
			edges[5] = p6y;
			edges[6] = p7y;

			int y1 = 10000;//top y Unused
			int y2 = 0;//bottom y
			for (int i = 0; i < edges.Length; i++)
			{
				if (edges[i] < y1)
				{
					y1 = (Int32)edges[i];
				}
				if (edges[i] > y2)
				{
					y2 = (Int32)edges[i];
				}
			}
			CustomShape custom = new CustomShape(new Rectangle(x, y, x2, y2));
			// custom.edges(point1, point2, point3, point4, point5, point6, point7);
			custom.edges(p1x, p1y, p2x, p2y, p3x, p3y, p4x, p4y, p5x, p5y, p6x, p6y, p7x, p7y);

			custom.FillColor = ColorFill;
			custom.Rotation = Rotation;
			custom.BorderColor = ColorBorder;

			ShapeList.Add(custom);

		}

		public void RotateSelection(Graphics grfx)
		{
			foreach (var item in Selection)
				item.Rotate(grfx);
		}

		public void PaintOnAdd()
		{
			if (Selection != null)
			{
				foreach (var item in Selection)
				{
					item.FillColor = ColorFill;
					item.BorderColor = ColorBorder;
				}
			}

		}
		/*
        public void AddRandomTriangle()
        {
        }
        public void Resize()
        {
        }
        public void Export()
        {
        }
        public void Save()
        {
        }
        public void SaveAs()
        {
        }
        */
		/// <summary>
		/// Проверява дали дадена точка е в елемента.
		/// Обхожда в ред обратен на визуализацията с цел намиране на
		/// "най-горния" елемент т.е. този който виждаме под мишката.
		/// </summary>
		/// <param name="point">Указана точка</param>
		/// <returns>Елемента на изображението, на който принадлежи дадената точка.</returns>
		public Shape ContainsPoint(PointF point)
		{
			for (int i = ShapeList.Count - 1; i >= 0; i--)
			{
				if (ShapeList[i].Contains(point))
				{
					// ShapeList[i].FillColor = Color.Red; 
					return ShapeList[i];
				}
			}
			return null;
		}

		/* public Shape ContainsPoint(PointF[] polygon, PointF point)
         {
             for (int i = ShapeList.Count - 1; i >= 0; i--)
             {
                 if (ShapeList[i].Contains(polygon, point))
                 {
                     // ShapeList[i].FillColor = Color.Red; 
                     return ShapeList[i];
                 }
             }
             return null;
         }
         */

		/// <summary>
		/// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
		/// </summary>
		/// <param name="p">Вектор на транслация.</param>
		public void TranslateTo(PointF p)
		{
			if (Selection.Count == 1)
			{
				Selection[0].Location = new PointF(Selection[0].Location.X + p.X - lastLocation.X, Selection[0].Location.Y + p.Y - lastLocation.Y);
				lastLocation = p;
			}
			else
			{
				foreach (var item in Selection)
				{
					item.Location = new PointF(item.Location.X + p.X - lastLocation.X, item.Location.Y + p.Y - lastLocation.Y);
					// lastLocation = p;
				}

				if (Selection != null)
				{
					lastLocation = p;
				}
			}
			/*
            if (Selection != null)
            {
                Selection.Location = new PointF(Selection.Location.X + p.X - lastLocation.X, item.Location.Y + p.Y - lastLocation.Y);
                lastLocation = p;
            }
            */

		}

		public void SelectFillColor(Color color)
		{
			if (color != null)
				FillColor = color;
		}

		public void SelectRotation(float rotation)
		{
			Rotation = rotation;
		}

		public string ShowDialog(string text, string caption)
		{
			Form prompt = new Form()
			{
				Width = 500,
				Height = 150,
				FormBorderStyle = FormBorderStyle.FixedDialog,
				Text = caption,
				StartPosition = FormStartPosition.CenterScreen
			};
			Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
			TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
			Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
			confirmation.Click += (sender, e) => { prompt.Close(); };
			prompt.Controls.Add(textBox);
			prompt.Controls.Add(confirmation);
			prompt.Controls.Add(textLabel);
			prompt.AcceptButton = confirmation;
			return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
		}

		public void SelectBorderColor(Color color)
		{
			if (color != null)
				ColorBorder = color;
			if (color == Color.White)
				ColorBorder = Color.Black;
		}

		public override void Draw(Graphics grfx)
		{
			base.Draw(grfx);
			if (Selection != null)
			{
				foreach (var item in Selection)
				{
					grfx.DrawRectangle(new Pen(ColorBorder == Color.Empty ? Color.Black : ColorBorder), item.Location.X - 3, item.Location.Y - 3, item.Width + 6, item.Height + 6);
				}

			}
		}

		public void SelectAll()
		{
			Selection = new List<Shape>(ShapeList);
		}

		public void DeselectAll()
		{
			Selection.Clear();
		}

		public void GroupSelection() // 
		{
			if (Selection.Count < 2)
				return;

			float minX = float.PositiveInfinity;
			float minY = float.PositiveInfinity;

			float maxX = float.NegativeInfinity;
			float maxY = float.NegativeInfinity;

			foreach (var item in Selection)
			{
				if (minX > item.Location.X)
					minX = item.Location.X;

				if (minY > item.Location.Y)
					minY = item.Location.Y;

				if (maxX < item.Location.X + item.Width)
					maxX = item.Location.X + item.Width;

				if (maxY < item.Location.Y + item.Width)
					maxY = item.Location.Y + item.Width;
			}

			GroupShape group = new GroupShape(new RectangleF(minX, minY, maxX - minX, maxY - minY));

			group.SubShapes = Selection;

			Selection = new List<Shape>();
			Selection.Add(group);

			foreach (var item in group.SubShapes)
			{
				ShapeList.Remove(item);
			}

			ShapeList.Add(group); // The opposite happens during off selection
		}

		public void GroupDeselection()
		{
			foreach (var item in Selection.ToArray())
			{
				if (item.GetType() == typeof(GroupShape))
				{
					GroupShape group = (GroupShape)item;
					if (group.SubShapes.Count <= 1)
						return;

					foreach (var shape in group.SubShapes)
					{
						ShapeList.Add(shape);
					}

					Selection.Remove(item);
					ShapeList.Remove(item);
				}
			}


		}

		public void RemoveLast()
		{
			if (ShapeList.Count != 0)
			{
				foreach (var item in Selection.ToArray())
				{
					if (item == ShapeList[0])
						Selection.Remove(item);
				}
				ShapeList.RemoveAt(0);
			}
		}

		public void RemoveAll()
		{
			if (ShapeList.Count != 0)
			{
				Selection.Clear();
				ShapeList.Clear();
			}
		}

		public void RemoveSelected()
		{
			if (ShapeList.Count != 0)
			{
				foreach (var item in ShapeList.ToArray())
				{
					if (Selection.Contains(item))
					{
						Selection.Remove(item);
						ShapeList.Remove(item);
					}
				}
			}
		}

		public void RemoveSpecific(Shape selected)
		{
			if (ShapeList.Count != 0)
			{
				Selection.RemoveAll(x => x == selected);
				ShapeList.RemoveAll(x => x == selected);
			}
		}

		#endregion
	}
}