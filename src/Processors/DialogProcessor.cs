using Draw.src.Model;
using Draw.src.Processors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Draw
{
    /// <summary>
    /// Класът, който ще бъде използван при управляване на диалога.
    /// </summary>
    public class DialogProcessor : GeometricProcessor
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

        private string fileName;
        public virtual string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private Color borderColor;
        public virtual Color ColorBorder
        {
            get { return borderColor; }
            set { borderColor = value; }
        }

        private Color ColorFill;
        public virtual Color FillColor
        {
            get { return ColorFill; }
            set { ColorFill = value; }
        }

        private PointF pt1;
        public virtual PointF PointStart
        {
            get { return pt1; }
            set { pt1 = value; }
        }

        private PointF pt2;
        public virtual PointF PointEnd
        {
            get { return pt2; }
            set { pt2 = value; }
        }

        private float rotation;
        public virtual float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        /// <summary>
        /// Дали в момента диалога е в състояние на "влачене" на избрания елемент.
        /// </summary>
        private bool isDragging;
        public virtual bool IsDragging
        {
            get { return isDragging; }
            set { isDragging = value; }
        }

        /// <summary>
        /// Последна позиция на мишката при "влачене".
        /// Използва се за определяне на вектора на транслация.
        /// </summary>
        private PointF lastLocation;
        public virtual PointF LastLocation
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
            custom.Edges(p1x, p1y, p2x, p2y, p3x, p3y, p4x, p4y, p5x, p5y, p6x, p6y, p7x, p7y);

            custom.FillColor = ColorFill;
            custom.Rotation = Rotation;
            custom.BorderColor = ColorBorder;

            ShapeList.Add(custom);

        }

        public void AddRandomTriangle()
        {
            Random rnd = new Random();

            int x = rnd.Next(100, 1000);    //Generate random position for the rectangle
            int y = rnd.Next(100, 600);
            float p1x = 0;              //Left most x in the rectangle
                                        //////    float p1y = 100;  //Manually  
                                        //////    float p2x = 150;  //Manually
                                        //////    float p2y = 100;             // the top most Y edge of the rectangle
            float p2x = 150; // Changes size

            float p3x = (p2x + p1x) / 2;
            float p3y = 0;

            float p1y = (float)Math.Sqrt(p2x * p2x - (p2x / 2) * (p2x / 2));

            //////    float p2y = 100;  //Manually
            float p2y = (float)Math.Sqrt(p2x * p2x - (p2x / 2) * (p2x / 2));

            float[] edges = new float[3];

            edges[0] = p1x;
            edges[1] = p2x;
            edges[2] = p3x;

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
            TriangleShape trape = new TriangleShape(new Rectangle(x, y, x2, y2));
            trape.edges(p1x, p1y, p2x, p2y, p3x, p3y);

            trape.FillColor = ColorFill;
            trape.Rotation = Rotation;
            trape.BorderColor = ColorBorder;
            // triangle.Size = p2x;

            ShapeList.Add(trape);
        }

        public void AddRandomTrape()
        {
            Random rnd = new Random();

            int x = rnd.Next(100, 1000);    //Generate random position for the rectangle
            int y = rnd.Next(100, 600);

            PointF p1 = new PointF();
            PointF p2 = new PointF();
            PointF p3 = new PointF();
            PointF p4 = new PointF();

            p1.X = 200;
            p1.Y = 100;
            p2.X = 50;
            p2.Y = 100;
            p3.X = 0;
            p3.Y = 250;
            p4.X = 250;
            p4.Y = 250;

            PointF[] edges = new PointF[4];

            edges[0] = p1;
            edges[1] = p2;
            edges[2] = p3;
            edges[3] = p4;

            int x1 = 10000; //leftmost x Unused
            int x2 = 0; //rightmost x

            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i].X < x1)
                {
                    x1 = (Int32)edges[i].X;
                }
                if (edges[i].X > x2)
                {
                    x2 = (Int32)edges[i].X;
                }
            }

            int y1 = 10000;//top y Unused
            int y2 = 0;//bottom y
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i].Y < y1)
                {
                    y1 = (Int32)edges[i].Y;
                }
                if (edges[i].Y > y2)
                {
                    y2 = (Int32)edges[i].Y;
                }
            }
            TrapezoidShape triangle = new TrapezoidShape(new Rectangle(x, y, x2, y2));
            triangle.Edges(p1, p2, p3, p4);

            triangle.FillColor = ColorFill;
            triangle.Rotation = Rotation;
            triangle.BorderColor = ColorBorder;
            // triangle.Size = p2x;

            ShapeList.Add(triangle);
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

        public void ShowPanelInfo(string caption, string[] infoText)
        {
            /*
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
            */
            Form prompt = new Form()
            {
                Width = 250,
                Height = 250,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            List<Label> listLabel = new List<Label>();
            for (int i = 0; i < infoText.Length; i++)
                listLabel.Add(new Label() { Text = infoText[i] });

            Button confirm = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirm.Click += (sender, e) => { prompt.Close(); };

            foreach (var label in listLabel)
                prompt.Controls.Add(label);

            prompt.Controls.Add(confirm);
            prompt.AcceptButton = confirm;
            prompt.ShowDialog();
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
            if (Selection != null)
            {
                foreach (var item in Selection)
                {
                    using (Matrix m = new Matrix())
                    {
                        m.RotateAt(item.Rotation, new PointF(item.Rectangle.Left + (item.Rectangle.Width / 2), item.Rectangle.Top + (item.Rectangle.Height / 2)));
                        grfx.Transform = m;

                        grfx.DrawRectangle(new Pen(ColorBorder == Color.Empty ? Color.Black : ColorBorder), item.Location.X - 3, item.Location.Y - 3, item.Width + 6, item.Height + 6);
                    }
                }
                base.Draw(grfx);
            }
        }

        public void SpawnByPanel(List<Shape> shapePanel)
        {
            foreach (var item in shapePanel)
            {
                ShapeList.Add(item);
            }
        }

        public void SelectAll()
        {
            Selection = new List<Shape>(ShapeList);
        }

        public void FindByName()
        {
            string name = ShowDialog("Find by name", "Find Shapes");

            foreach (var shape in ShapeList)
            {
                if (shape.Name == name)
                {
                    Selection.Add(shape);
                }
            }
        }

        public void FindByShapeEllipse()
        {
            foreach (var shape in ShapeList)
            {
                if (shape.GetType() == typeof(EllipseShape))
                {
                    Selection.Add(shape);
                }
            }
        }

        public void FindByShapeRectangle()
        {
            foreach (var shape in ShapeList)
            {
                if (shape.GetType() == typeof(RectangleShape))
                {
                    Selection.Add(shape);
                }
            }
        }

        public void FindByShapeCustomShape()
        {
            foreach (var shape in ShapeList)
            {
                if (shape.GetType() == typeof(CustomShape))
                {
                    Selection.Add(shape);
                }
            }
        }

        public void FindByShapeGroupShape()
        {
            foreach (var shape in ShapeList)
            {
                if (shape.GetType() == typeof(GroupShape))
                {
                    Selection.Add(shape);
                }
            }
        }

        public void FindByPanel(List<Shape> shapePanel)
        {
            foreach (var shape in ShapeList)
            {
                if (shapePanel.Contains(shape))
                {
                    Selection.Add(shape);
                }
            }
        }

        public void DeselectAll()
        {
            Selection.Clear();
        }

        public void GroupSelection()
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

        public void Rename()
        {
            if (Selection.Count != 0)
            {
                string name = ShowDialog("Input name", "Shape Name");

                Selection.ForEach(x => x.Name = name);
            }
        }

        public void SaveAs(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            /* Some problems: Some classes can not be serialized, Solution #1: make a class inheriting the other class and make it serializable
			 * Solution #2: Using surrogate classes, create a matrix surrogate class for instance
			 * 
			 */

            FileName = fileName;
            bf.Serialize(fs, ShapeList); // Use Deserialize for reading files
            fs.Close();
        }

        public void Open(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            ShapeList = (List<Shape>)bf.Deserialize(fs);
            fs.Close();
        }

        public void New(string fileName)
        {
            SaveAs(fileName);
        }

        public void Save()
        {
            if (FileName == null)
                return;

            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, ShapeList);
            fs.Close();
        }

        public void PopulatePanel(List<Shape> shapePanel)
        {
            shapePanel.Clear();
            foreach (var item in ShapeList.ToList())
            {
                shapePanel.Add(item);
            }
        }
        #endregion
    }
}