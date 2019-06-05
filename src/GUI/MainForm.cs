using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Drawing.Drawing2D;
using Draw.src.Processors;
using Draw.src.Model;

namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{

		/// <summary>
		/// Създаване на линии с цветове
		/// </summary>
		Graphics g;

		int x = -1;
		int y = -1;
		bool isMoving = false;
		Pen pen;

		int generalCounter = 1;

		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();

		private GeometricProcessor geometricProcessor = new GeometricProcessor();

		public MainForm()
		{
			//  
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			// g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			g = panelColor.CreateGraphics();

			pen = new Pen(Color.Black, 5);
			pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		#region Shapes
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			// dialogProcessor.ReRotate(sender, e);
			dialogProcessor.ReDraw(sender, e);

			// dialogProcessor.ReDrawSelection(e.Graphics);

			if (removeButton.Checked)
			{
				foreach (var item in dialogProcessor.Selection)
					dialogProcessor.Remove(sender, e, item);

				statusBar.Items[0].Text = "Последно действие: Изтриване на примитив";
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle();

			statusBar.Items[0].Text = "Последно действие: Добавяне на правоъгълник";

			viewPort.Invalidate();
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomEllipse();

			statusBar.Items[0].Text = "Последно действие: Добавяне на елипса";

			viewPort.Invalidate();

		} // Adding Ellipse using the Viewtool Icon

		private void toolStripButton1_Click_1(object sender, EventArgs e)
		{
			statusBar.Items[0].Text = "Последно действие: Добавяне на линия";

			viewPort.Invalidate();
		}
		private void DrawTriangleSpeedButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomTriangle();

			statusBar.Items[0].Text = "Последно действие: Добавяне на триъгълник";

			viewPort.Invalidate();
		}

		/// <summary>
		/// Image Insertion Method
		/// Needs to be completed
		/// </summary>
		private void importImageButton_Click(object sender, EventArgs e) // Needs to be draggable, entity of type Bitmap
		{
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				String imagePath = openFileDialog1.FileName;
				var pictureBox = new PictureBox
				{
					BackColor = Color.Empty,
					ImageLocation = imagePath,
					Location = new Point(100, 200),
					Size = new Size(540, 540),
				};

				this.Controls.Add(pictureBox);
				pictureBox.BringToFront();

				statusBar.Items[0].Text = "Последно действие: Въвеждане на избрана снимка (" + imagePath + ")";
				viewPort.Invalidate();
			}
		}

		private void addRectangleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DrawRectangleSpeedButtonClick(sender, e);
		}

		private void addEllipseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			toolStripButton1_Click(sender, e);
		}

		private void importToolStripMenuItem_Click(object sender, EventArgs e)
		{
			importImageButton_Click(sender, e);
		}

		#endregion

		#region ViewportMenu
		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>

		void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (selectButton.Checked)
			{
				var sel = dialogProcessor.ContainsPoint(e.Location);
				if (sel == null)
					return;

				if (dialogProcessor.Selection.Contains(sel))
				{
					if (unselectButton.Checked)
					{
						dialogProcessor.Selection.Remove(sel);
					}
				}
				else
				{
					dialogProcessor.Selection.Add(sel);
				}

				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.No;
				if (dialogProcessor.Selection != null)
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.SizeAll;
					statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
					dialogProcessor.IsDragging = true;
					dialogProcessor.LastLocation = e.Location;
					viewPort.Invalidate();
				}
			}
			if (unselectButton.Checked)
			{
				var sel = dialogProcessor.ContainsPoint(e.Location);
				if (sel == null)
					return;

				if (dialogProcessor.Selection != null)
				{
					if (dialogProcessor.Selection.Contains(sel))
					{
						dialogProcessor.Selection.Remove(sel);
					}
				}
			}
			if (paintButton.Checked)
			{
				var sel = dialogProcessor.ContainsPoint(e.Location);
				if (sel == null)
					return;

				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.No;
				if (dialogProcessor.Selection != null)
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Cross;
					statusBar.Items[0].Text = "Последно действие: Рисуване на примитив";

					foreach (var item in dialogProcessor.Selection)
					{
						item.FillColor = dialogProcessor.FillColor;
						item.BorderColor = dialogProcessor.ColorBorder;
					}
					sel.FillColor = dialogProcessor.FillColor;
					sel.BorderColor = dialogProcessor.ColorBorder;

					viewPort.Invalidate();
				}
			}
			if (sizeButton.Checked)
			{
				var sel = dialogProcessor.ContainsPoint(e.Location);
				if (sel == null)
					return;

				dialogProcessor.Selection.Add(sel);

				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.No;
				if (dialogProcessor.Selection != null)
				{
					string value;

					value = dialogProcessor.ShowDialog("Въведете ширина на примитив: ", "Промяна на размер");
					int.TryParse(value, out int width);

					value = dialogProcessor.ShowDialog("Въведете височина на примитив", "Промяна на размер");
					int.TryParse(value, out int height);

					if (dialogProcessor.Selection != null)
					{
						foreach (var item in dialogProcessor.Selection)
							item.Size = new Size(width, height);
					}
					else if (width == 0 || height == 0)
						MessageBox.Show("Височина или Ширина имат грешни стойности", "Грешка");

					statusBar.Items[0].Text = "Последно действие: Промяна на размерите на примитив";

					viewPort.Invalidate();
				}
			}
			if (removeButton.Checked)
			{
				/*
                var sel = dialogProcessor.ContainsPoint(e.Location);
                if (sel == null)
                    return;

                if (dialogProcessor.Selection.Contains(sel))
                    dialogProcessor.Selection.Remove(sel);
                else
                    dialogProcessor.Selection.Add(sel);

                */
				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.No;

				var sel = dialogProcessor.ContainsPoint(e.Location);
				if (sel != null)
				{
					dialogProcessor.RemoveSpecific(dialogProcessor.ContainsPoint(e.Location));

					dialogProcessor.RemoveSelected();

					statusBar.Items[0].Text = "Последно действие: Изтриване на примитив";

					viewPort.Invalidate();
				}
			}
			if (lineButton.Checked)
			{
				generalCounter++;

				System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
				if (generalCounter % 2 == 0)
				{
					System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Cross;
					dialogProcessor.PointStart = e.Location;
				}
				else
				{
					dialogProcessor.PointEnd = e.Location;
					dialogProcessor.AddRandomLine();

					statusBar.Items[0].Text = "Последно действие: Чертане на линия";
					viewPort.Invalidate();
				}

			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Made by Viktor Ivanov and Ivan Dobrev (Software Engineering) for Computer Graphics and GUI (II Course)");
		}

		#endregion

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режм на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging && !removeButton.Checked)
			{
				if (dialogProcessor.Selection != null)
					statusBar.Items[0].Text = "Последно действие: Влачене (" + e.X + " " + e.Y + " )";

				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
			else if (dialogProcessor.IsDragging)
			{

			}

		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

		private void fileToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void viewPort_Load(object sender, EventArgs e)
		{

		}

		#region MenuColors

		private void pictureRed_Click(object sender, EventArgs e)
		{
			dialogProcessor.SelectFillColor(Color.Red);

			dialogProcessor.FillColor = Color.Red;

			statusBar.Items[0].Text = "Последно действие: Избран цвят - червено";

			viewPort.Invalidate();
		}

		private void pictureBlue_Click_1(object sender, EventArgs e)
		{
			dialogProcessor.SelectFillColor(Color.Blue);

			dialogProcessor.FillColor = Color.Blue;

			statusBar.Items[0].Text = "Последно действие: Избран цвят - синьо";

			viewPort.Invalidate();
		}

		private void pictureYellow_Click_1(object sender, EventArgs e)
		{
			dialogProcessor.SelectFillColor(Color.Yellow);

			dialogProcessor.FillColor = Color.Yellow;

			statusBar.Items[0].Text = "Последно действие: Избран цвят - жълто";

			viewPort.Invalidate();
		}

		private void pictureGreen_Click_1(object sender, EventArgs e)
		{
			dialogProcessor.SelectFillColor(Color.LightGreen);

			dialogProcessor.FillColor = Color.LightGreen;

			statusBar.Items[0].Text = "Последно действие: Избран цвят - зелено";

			viewPort.Invalidate();
		}

		private void pictureBlack_Click_1(object sender, EventArgs e)
		{
			dialogProcessor.SelectFillColor(Color.Black);

			dialogProcessor.FillColor = Color.Black;

			statusBar.Items[0].Text = "Последно действие: Избран цвят - черно";

			viewPort.Invalidate();
		}

		private void pictureCyan_Click(object sender, EventArgs e)
		{
			dialogProcessor.SelectFillColor(Color.White);

			dialogProcessor.FillColor = Color.White;

			statusBar.Items[0].Text = "Последно действие: Избран цвят - бяло";

			viewPort.Invalidate();
		}

		private void pictureOrange_Click(object sender, EventArgs e)
		{
			dialogProcessor.SelectFillColor(Color.Orange);

			dialogProcessor.FillColor = Color.Orange;

			statusBar.Items[0].Text = "Последно действие: Избран цвят - оранжево";

			viewPort.Invalidate();
		}

		private void picturePurple_Click(object sender, EventArgs e)
		{
			dialogProcessor.SelectFillColor(Color.HotPink);

			dialogProcessor.FillColor = Color.HotPink;

			statusBar.Items[0].Text = "Последно действие: Избран цвят - лилаво";

			viewPort.Invalidate();
		}

		private void pictureAll_Click(object sender, EventArgs e)

		{
			PictureBox p = (PictureBox)sender;
			pen.Color = p.BackColor;

		}

		#endregion

		#region Pen
		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			isMoving = false;
			x = e.X;
			y = e.Y;
		}

		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (isMoving && x != -1 && y != -1)
			{
				g.DrawLine(pen, new Point(x, y), e.Location);
				x = e.X;
				y = e.Y;
			}
		}

		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			isMoving = false;
			x = -1;
			y = -1;
		}
		#endregion

		#region Color
		private void fillColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.SelectFillColor(colorDialog1.Color);
				statusBar.Items[0].Text = "Последно действие: Избиране на цвят на фигура";
				viewPort.Invalidate();
			}
		}

		private void borderColorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.SelectBorderColor(colorDialog1.Color);
				statusBar.Items[0].Text = "Последно действие: Избиране на цвят на границата на фигура";
				viewPort.Invalidate();
			}
		}

		#endregion

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		#region Rotate

		private void rotateSelectedShapeToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			if (dialogProcessor.Selection != null)
			{
				float.TryParse(dialogProcessor.ShowDialog("Въведете ъгъл на ротация", "Ротация на примитив"), out float rotation);

				foreach (var item in dialogProcessor.Selection)
				{
					item.Rotation = rotation;
				}

				statusBar.Items[0].Text = "Последно действие: Ротация на избрана фигура";
				viewPort.Invalidate();
			}
			else
			{
				statusBar.Items[0].Text = "Грешка: Няма избрана фигура";
				viewPort.Invalidate();
			}

		}

		private void degreesToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			if (dialogProcessor.Selection != null)
			{
				foreach (var item in dialogProcessor.Selection)
					item.Rotation = 90F;

				statusBar.Items[0].Text = "Последно действие: Ротация на избрана фигура";
				viewPort.Invalidate();
			}
			else
			{
				statusBar.Items[0].Text = "Грешка: Няма избрана фигура";
				viewPort.Invalidate();
			}
		}

		private void degreesToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (dialogProcessor.Selection != null)
			{
				foreach (var item in dialogProcessor.Selection)
					item.Rotation = 180F;

				statusBar.Items[0].Text = "Последно действие: Ротация на избрана фигура";
				viewPort.Invalidate();
			}
			else
			{
				statusBar.Items[0].Text = "Грешка: Няма избрана фигура";
				viewPort.Invalidate();
			}
		}

		private void degreesToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			if (dialogProcessor.Selection != null)
			{
				foreach (var item in dialogProcessor.Selection)
					item.Rotation = 270F;

				statusBar.Items[0].Text = "Последно действие: Ротация на избрана фигура";
				viewPort.Invalidate();
			}
			else
			{
				statusBar.Items[0].Text = "Грешка: Няма избрана фигура";
				viewPort.Invalidate();
			}
		}

		#endregion

		private void resizeSelectedShapeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string value;

			value = dialogProcessor.ShowDialog("Please input width: ", "Changing Width");
			int.TryParse(value, out int width);

			value = dialogProcessor.ShowDialog("Please input height: ", "Changing Height");
			int.TryParse(value, out int height);

			if (dialogProcessor.Selection != null)
				foreach (var item in dialogProcessor.Selection)
				{
					item.Size = new Size(width, height);

					if(item.GetType() == typeof(TriangleShape)) // Change the variable X of Triangle to change shape
					{
						
					}
				}

			else if (width == 0 || height == 0)
				MessageBox.Show("Width AND / OR Height are invalid", "Error");

			viewPort.Invalidate();
		}

		private void speedMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void penButton_Click(object sender, EventArgs e)
		{

		}

		private void selectButton_Click(object sender, EventArgs e)
		{

		}

		private void removeButton_Click(object sender, EventArgs e)
		{

		}

		private void removeSelectedShapeToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void lastShapeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.RemoveLast();
			viewPort.Invalidate();
		}

		private void allShapesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.RemoveAll();
			viewPort.Invalidate();
		}

		private void removeGroupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.GroupDeselection();

			viewPort.Invalidate();
		}

		private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.GroupSelection();

			statusBar.Items[0].Text = "Последно действие: Създаване на група";
			viewPort.Invalidate();
		}

		private void selectionToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void toolStripButton1_Click_2(object sender, EventArgs e)
		{

		}

		private void selectedShapeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.RemoveSelected();

			viewPort.Invalidate();
		}

		private void customShapeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomCustomShape();

			viewPort.Invalidate();
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.SelectAll();


			viewPort.Invalidate();
		}

		private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.DeselectAll();

			viewPort.Invalidate();
		}

		private void renameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.Rename();

			viewPort.Invalidate();
		}

		private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.FindByName();

			viewPort.Invalidate();
		}

		private void byShapeToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void rectangleToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			dialogProcessor.FindByShapeRectangle();

			viewPort.Invalidate();
		}

		private void ellipseToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			dialogProcessor.FindByShapeEllipse();

			viewPort.Invalidate();
		}

		private void customShapeToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			dialogProcessor.FindByShapeCustomShape();

			viewPort.Invalidate();
		}

		private void groupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dialogProcessor.FindByShapeGroupShape();

			viewPort.Invalidate();
		}

		private void paintButton_Click(object sender, EventArgs e)
		{

		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.SaveAs(saveFileDialog1.FileName);
			}

			viewPort.Invalidate();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				dialogProcessor.Open(openFileDialog1.FileName);
			}

			viewPort.Invalidate();
		}
	}
}
