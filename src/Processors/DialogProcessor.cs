﻿using System;
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
		private Shape selection;

        // public Color BorderColor;

		public Shape Selection {
			get { return selection; }
			set { selection = value; }
		}

        private Color borderColor;
        public Color ColorBorder{
            get { return borderColor; }
            set { borderColor = value; }
        }

        private Color ColorFill;
        public Color FillColor{
            get { return ColorFill; }
            set { ColorFill = value; }
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
		public bool IsDragging {
			get { return isDragging; }
			set { isDragging = value; }
		}
		
		/// <summary>
		/// Последна позиция на мишката при "влачене".
		/// Използва се за определяне на вектора на транслация.
		/// </summary>
		private PointF lastLocation;
		public PointF LastLocation {
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
			int x = rnd.Next(100,1000);
			int y = rnd.Next(100,600);
			
			RectangleShape rect = new RectangleShape(new Rectangle(x,y,100,200));
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
            GraphicsPath path = new GraphicsPath();

            ShapeList.Add(ellipse);
        }

        public void AddRandomLine()
        {
            Random rnd = new Random();
            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            LineShape line = new LineShape(new PointF());
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

        public void RotateSelection(Graphics grfx)
        {
            selection.Rotate(grfx);
        }

        public void PaintOnAdd()
        {
            if(selection != null)
            {
                selection.FillColor = ColorFill;
                selection.BorderColor = ColorBorder;
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
			for(int i = ShapeList.Count - 1; i >= 0; i--){
				if (ShapeList[i].Contains(point)){
					// ShapeList[i].FillColor = Color.Red; 

					return ShapeList[i];
				}	
			}
			return null;
		}
		
		/// <summary>
		/// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
		/// </summary>
		/// <param name="p">Вектор на транслация.</param>
		public void TranslateTo(PointF p)
		{
			if (selection != null) {
				selection.Location = new PointF(selection.Location.X + p.X - lastLocation.X, selection.Location.Y + p.Y - lastLocation.Y);
				lastLocation = p;
			}
		}

        public void SelectFillColor(Color color)
        {
            if(color != null)
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

        #endregion

    }
}
