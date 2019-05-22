using Draw.src.Model;
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

        private Dictionary<Shape,Shape> selectionCheck = new Dictionary<Shape, Shape>();
        public Dictionary<Shape, Shape> SelectionCheck
        {
            get { return selectionCheck; }
            set { selectionCheck = value; }
        }

        private PointF[] polygon;
        public PointF[] Polygon
        {
            get { return polygon; }
            set { polygon = value; }
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

            int x = rnd.Next(100, 1000);
            int y = rnd.Next(100, 600);

            float xMax = float.NegativeInfinity;
            float yMax = float.NegativeInfinity;

            float xMin = float.PositiveInfinity;
            float yMin = float.PositiveInfinity;

            // Create points that define polygon.
            PointF point1 = new PointF(x, y);
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

            foreach (var p in curvePoints)
            {
                if (xMax < p.X)
                    xMax = p.X;

                if (xMin > p.X)
                    xMin = p.X;

                if (yMax < p.Y)
                    yMax = p.Y;

                if (yMin > p.Y)
                    yMin = p.Y;
            }
            int width = (int)(xMax - xMin);
            int height = (int)(yMax - yMin);

            CustomShape custom = new CustomShape(new Rectangle(x,y,width,height));
            
            ShapeList.Add(custom);

        }
        
        public void RotateSelection(Graphics grfx)
        {
            foreach(var item in Selection)
                item.Rotate(grfx);
        }

        public void PaintOnAdd()
        {
            if (Selection != null)
            {
                foreach(var item in Selection)
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

        public Shape ContainsPoint(PointF[] polygon, PointF point)
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

        /// <summary>
        /// Транслация на избраният елемент на вектор определен от <paramref name="p>p</paramref>
        /// </summary>
        /// <param name="p">Вектор на транслация.</param>
        public void TranslateTo(PointF p)
        {
            if(Selection.Count == 1)
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

                if(Selection != null)
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
                foreach(var item in Selection)
                {
                    grfx.DrawRectangle(new Pen(ColorBorder == Color.Empty ? Color.Black : ColorBorder), item.Location.X - 3, item.Location.Y - 3, item.Width + 6, item.Height + 6);
                }
                 
            }
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
            foreach(var item in Selection.ToArray())
            {
                if(item.GetType() == typeof(GroupShape))
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
                foreach(var item in Selection.ToArray())
                {
                    if (item == ShapeList[0])
                        Selection.Remove(item);
                }
                ShapeList.RemoveAt(0);
            }
        }

        public void RemoveAll()
        {
            if(ShapeList.Count != 0)
            {
                Selection.Clear();
                ShapeList.Clear();
            }
        }

        public void RemoveSelected()
        {
            if(ShapeList.Count != 0)
            {
                foreach(var item in ShapeList.ToArray())
                {
                    if(Selection.Contains(item))
                    {
                        Selection.Remove(item);
                        ShapeList.Remove(item);
                    }
                }
            }
        }

        public void RemoveSpecific(Shape selected)
        {
            if(ShapeList.Count != 0)
            {
                Selection.RemoveAll(x => x == selected);
                ShapeList.RemoveAll(x => x == selected);
            }
        }

        #endregion
    }
}