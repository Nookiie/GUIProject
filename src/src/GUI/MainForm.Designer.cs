namespace Draw
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borderColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEllipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateSelectedShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeSelectedShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.currentStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.speedMenu = new System.Windows.Forms.ToolStrip();
            this.drawRectangleSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.lineButton = new System.Windows.Forms.ToolStripButton();
            this.drawEllipseSpeedButton = new System.Windows.Forms.ToolStripButton();
            this.selectButton = new System.Windows.Forms.ToolStripButton();
            this.unselectButton = new System.Windows.Forms.ToolStripButton();
            this.paintButton = new System.Windows.Forms.ToolStripButton();
            this.sizeButton = new System.Windows.Forms.ToolStripButton();
            this.importImageButton = new System.Windows.Forms.ToolStripButton();
            this.removeButton = new System.Windows.Forms.ToolStripButton();
            this.panelColor = new System.Windows.Forms.Panel();
            this.pictureBlack = new System.Windows.Forms.PictureBox();
            this.pictureCyan = new System.Windows.Forms.PictureBox();
            this.pictureOrange = new System.Windows.Forms.PictureBox();
            this.picturePurple = new System.Windows.Forms.PictureBox();
            this.pictureGreen = new System.Windows.Forms.PictureBox();
            this.pictureYellow = new System.Windows.Forms.PictureBox();
            this.pictureBlue = new System.Windows.Forms.PictureBox();
            this.pictureRed = new System.Windows.Forms.PictureBox();
            this.pictureAll = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            this.viewPort = new Draw.DoubleBufferedPanel();
            this.customShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.speedMenu.SuspendLayout();
            this.panelColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCyan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOrange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePurple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAll)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(693, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectColorToolStripMenuItem,
            this.addShapeToolStripMenuItem,
            this.rotateSelectedShapeToolStripMenuItem,
            this.resizeSelectedShapeToolStripMenuItem,
            this.selectionToolStripMenuItem,
            this.removeSelectedShapeToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // selectColorToolStripMenuItem
            // 
            this.selectColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillColorToolStripMenuItem,
            this.borderColorToolStripMenuItem});
            this.selectColorToolStripMenuItem.Name = "selectColorToolStripMenuItem";
            this.selectColorToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.selectColorToolStripMenuItem.Text = "Open Color Palette";
            // 
            // fillColorToolStripMenuItem
            // 
            this.fillColorToolStripMenuItem.Name = "fillColorToolStripMenuItem";
            this.fillColorToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.fillColorToolStripMenuItem.Text = "Fill Color";
            this.fillColorToolStripMenuItem.Click += new System.EventHandler(this.fillColorToolStripMenuItem_Click);
            // 
            // borderColorToolStripMenuItem
            // 
            this.borderColorToolStripMenuItem.Name = "borderColorToolStripMenuItem";
            this.borderColorToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.borderColorToolStripMenuItem.Text = "Border Color";
            this.borderColorToolStripMenuItem.Click += new System.EventHandler(this.borderColorToolStripMenuItem_Click);
            // 
            // addShapeToolStripMenuItem
            // 
            this.addShapeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRectangleToolStripMenuItem,
            this.addEllipseToolStripMenuItem,
            this.customShapeToolStripMenuItem});
            this.addShapeToolStripMenuItem.Name = "addShapeToolStripMenuItem";
            this.addShapeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addShapeToolStripMenuItem.Text = "Add Shape";
            // 
            // addRectangleToolStripMenuItem
            // 
            this.addRectangleToolStripMenuItem.Name = "addRectangleToolStripMenuItem";
            this.addRectangleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addRectangleToolStripMenuItem.Text = "Add Rectangle";
            this.addRectangleToolStripMenuItem.Click += new System.EventHandler(this.addRectangleToolStripMenuItem_Click);
            // 
            // addEllipseToolStripMenuItem
            // 
            this.addEllipseToolStripMenuItem.Name = "addEllipseToolStripMenuItem";
            this.addEllipseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addEllipseToolStripMenuItem.Text = "Add Ellipse";
            this.addEllipseToolStripMenuItem.Click += new System.EventHandler(this.addEllipseToolStripMenuItem_Click);
            // 
            // rotateSelectedShapeToolStripMenuItem
            // 
            this.rotateSelectedShapeToolStripMenuItem.Name = "rotateSelectedShapeToolStripMenuItem";
            this.rotateSelectedShapeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.rotateSelectedShapeToolStripMenuItem.Text = "Rotate Selected Shape";
            this.rotateSelectedShapeToolStripMenuItem.Click += new System.EventHandler(this.rotateSelectedShapeToolStripMenuItem_Click_1);
            // 
            // resizeSelectedShapeToolStripMenuItem
            // 
            this.resizeSelectedShapeToolStripMenuItem.Name = "resizeSelectedShapeToolStripMenuItem";
            this.resizeSelectedShapeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.resizeSelectedShapeToolStripMenuItem.Text = "Resize Selected Shape";
            this.resizeSelectedShapeToolStripMenuItem.Click += new System.EventHandler(this.resizeSelectedShapeToolStripMenuItem_Click);
            // 
            // selectionToolStripMenuItem
            // 
            this.selectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGroupToolStripMenuItem,
            this.removeGroupToolStripMenuItem});
            this.selectionToolStripMenuItem.Name = "selectionToolStripMenuItem";
            this.selectionToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.selectionToolStripMenuItem.Text = "Selection";
            this.selectionToolStripMenuItem.Click += new System.EventHandler(this.selectionToolStripMenuItem_Click);
            // 
            // addGroupToolStripMenuItem
            // 
            this.addGroupToolStripMenuItem.Name = "addGroupToolStripMenuItem";
            this.addGroupToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addGroupToolStripMenuItem.Text = "Add Group";
            this.addGroupToolStripMenuItem.Click += new System.EventHandler(this.addGroupToolStripMenuItem_Click);
            // 
            // removeGroupToolStripMenuItem
            // 
            this.removeGroupToolStripMenuItem.Name = "removeGroupToolStripMenuItem";
            this.removeGroupToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.removeGroupToolStripMenuItem.Text = "Remove Group";
            this.removeGroupToolStripMenuItem.Click += new System.EventHandler(this.removeGroupToolStripMenuItem_Click);
            // 
            // removeSelectedShapeToolStripMenuItem
            // 
            this.removeSelectedShapeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastShapeToolStripMenuItem,
            this.allShapesToolStripMenuItem,
            this.selectedShapeToolStripMenuItem});
            this.removeSelectedShapeToolStripMenuItem.Name = "removeSelectedShapeToolStripMenuItem";
            this.removeSelectedShapeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.removeSelectedShapeToolStripMenuItem.Text = "Remove";
            this.removeSelectedShapeToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedShapeToolStripMenuItem_Click);
            // 
            // lastShapeToolStripMenuItem
            // 
            this.lastShapeToolStripMenuItem.Name = "lastShapeToolStripMenuItem";
            this.lastShapeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.lastShapeToolStripMenuItem.Text = "Last Shape";
            this.lastShapeToolStripMenuItem.Click += new System.EventHandler(this.lastShapeToolStripMenuItem_Click);
            // 
            // allShapesToolStripMenuItem
            // 
            this.allShapesToolStripMenuItem.Name = "allShapesToolStripMenuItem";
            this.allShapesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.allShapesToolStripMenuItem.Text = "All Shapes";
            this.allShapesToolStripMenuItem.Click += new System.EventHandler(this.allShapesToolStripMenuItem_Click);
            // 
            // selectedShapeToolStripMenuItem
            // 
            this.selectedShapeToolStripMenuItem.Name = "selectedShapeToolStripMenuItem";
            this.selectedShapeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.selectedShapeToolStripMenuItem.Text = "Selected Shape";
            this.selectedShapeToolStripMenuItem.Click += new System.EventHandler(this.selectedShapeToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentStatusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 401);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(693, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // speedMenu
            // 
            this.speedMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.speedMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawRectangleSpeedButton,
            this.lineButton,
            this.drawEllipseSpeedButton,
            this.selectButton,
            this.unselectButton,
            this.paintButton,
            this.sizeButton,
            this.importImageButton,
            this.removeButton});
            this.speedMenu.Location = new System.Drawing.Point(0, 24);
            this.speedMenu.Name = "speedMenu";
            this.speedMenu.Size = new System.Drawing.Size(693, 27);
            this.speedMenu.TabIndex = 3;
            this.speedMenu.Text = "toolStrip1";
            this.speedMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.speedMenu_ItemClicked);
            // 
            // drawRectangleSpeedButton
            // 
            this.drawRectangleSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawRectangleSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawRectangleSpeedButton.Image")));
            this.drawRectangleSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawRectangleSpeedButton.Name = "drawRectangleSpeedButton";
            this.drawRectangleSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawRectangleSpeedButton.Text = "Draw Rectangle";
            this.drawRectangleSpeedButton.Click += new System.EventHandler(this.DrawRectangleSpeedButtonClick);
            // 
            // lineButton
            // 
            this.lineButton.CheckOnClick = true;
            this.lineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineButton.Image = ((System.Drawing.Image)(resources.GetObject("lineButton.Image")));
            this.lineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineButton.Name = "lineButton";
            this.lineButton.Size = new System.Drawing.Size(24, 24);
            this.lineButton.Text = "Line";
            this.lineButton.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // drawEllipseSpeedButton
            // 
            this.drawEllipseSpeedButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drawEllipseSpeedButton.Image = ((System.Drawing.Image)(resources.GetObject("drawEllipseSpeedButton.Image")));
            this.drawEllipseSpeedButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drawEllipseSpeedButton.Name = "drawEllipseSpeedButton";
            this.drawEllipseSpeedButton.Size = new System.Drawing.Size(24, 24);
            this.drawEllipseSpeedButton.Text = "Draw Ellipse";
            this.drawEllipseSpeedButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // selectButton
            // 
            this.selectButton.CheckOnClick = true;
            this.selectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectButton.Image = ((System.Drawing.Image)(resources.GetObject("selectButton.Image")));
            this.selectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(24, 24);
            this.selectButton.Text = "Select";
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // unselectButton
            // 
            this.unselectButton.CheckOnClick = true;
            this.unselectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.unselectButton.Image = ((System.Drawing.Image)(resources.GetObject("unselectButton.Image")));
            this.unselectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.unselectButton.Name = "unselectButton";
            this.unselectButton.Size = new System.Drawing.Size(24, 24);
            this.unselectButton.Text = "Unselect ";
            this.unselectButton.Click += new System.EventHandler(this.toolStripButton1_Click_2);
            // 
            // paintButton
            // 
            this.paintButton.CheckOnClick = true;
            this.paintButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.paintButton.Image = ((System.Drawing.Image)(resources.GetObject("paintButton.Image")));
            this.paintButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paintButton.Name = "paintButton";
            this.paintButton.Size = new System.Drawing.Size(24, 24);
            this.paintButton.Text = "Paint";
            // 
            // sizeButton
            // 
            this.sizeButton.CheckOnClick = true;
            this.sizeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sizeButton.Image = ((System.Drawing.Image)(resources.GetObject("sizeButton.Image")));
            this.sizeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sizeButton.Name = "sizeButton";
            this.sizeButton.Size = new System.Drawing.Size(24, 24);
            this.sizeButton.Text = "toolStripButton1";
            this.sizeButton.Click += new System.EventHandler(this.penButton_Click);
            // 
            // importImageButton
            // 
            this.importImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importImageButton.Image = ((System.Drawing.Image)(resources.GetObject("importImageButton.Image")));
            this.importImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importImageButton.Name = "importImageButton";
            this.importImageButton.Size = new System.Drawing.Size(24, 24);
            this.importImageButton.Text = "Import Image";
            this.importImageButton.Click += new System.EventHandler(this.importImageButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.CheckOnClick = true;
            this.removeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeButton.Image = ((System.Drawing.Image)(resources.GetObject("removeButton.Image")));
            this.removeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(24, 24);
            this.removeButton.Text = "toolStripButton1";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // panelColor
            // 
            this.panelColor.Controls.Add(this.pictureBlack);
            this.panelColor.Controls.Add(this.pictureCyan);
            this.panelColor.Controls.Add(this.pictureOrange);
            this.panelColor.Controls.Add(this.picturePurple);
            this.panelColor.Controls.Add(this.pictureGreen);
            this.panelColor.Controls.Add(this.pictureYellow);
            this.panelColor.Controls.Add(this.pictureBlue);
            this.panelColor.Controls.Add(this.pictureRed);
            this.panelColor.Controls.Add(this.pictureAll);
            this.panelColor.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelColor.Location = new System.Drawing.Point(619, 51);
            this.panelColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(74, 350);
            this.panelColor.TabIndex = 5;
            // 
            // pictureBlack
            // 
            this.pictureBlack.BackColor = System.Drawing.Color.Black;
            this.pictureBlack.Location = new System.Drawing.Point(10, 295);
            this.pictureBlack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBlack.Name = "pictureBlack";
            this.pictureBlack.Size = new System.Drawing.Size(52, 36);
            this.pictureBlack.TabIndex = 8;
            this.pictureBlack.TabStop = false;
            this.pictureBlack.Click += new System.EventHandler(this.pictureBlack_Click_1);
            // 
            // pictureCyan
            // 
            this.pictureCyan.BackColor = System.Drawing.Color.White;
            this.pictureCyan.Location = new System.Drawing.Point(10, 254);
            this.pictureCyan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureCyan.Name = "pictureCyan";
            this.pictureCyan.Size = new System.Drawing.Size(52, 36);
            this.pictureCyan.TabIndex = 7;
            this.pictureCyan.TabStop = false;
            this.pictureCyan.Click += new System.EventHandler(this.pictureCyan_Click);
            // 
            // pictureOrange
            // 
            this.pictureOrange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pictureOrange.Location = new System.Drawing.Point(10, 214);
            this.pictureOrange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureOrange.Name = "pictureOrange";
            this.pictureOrange.Size = new System.Drawing.Size(52, 36);
            this.pictureOrange.TabIndex = 6;
            this.pictureOrange.TabStop = false;
            this.pictureOrange.Click += new System.EventHandler(this.pictureOrange_Click);
            // 
            // picturePurple
            // 
            this.picturePurple.BackColor = System.Drawing.Color.Fuchsia;
            this.picturePurple.Location = new System.Drawing.Point(10, 173);
            this.picturePurple.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picturePurple.Name = "picturePurple";
            this.picturePurple.Size = new System.Drawing.Size(52, 36);
            this.picturePurple.TabIndex = 5;
            this.picturePurple.TabStop = false;
            this.picturePurple.Click += new System.EventHandler(this.picturePurple_Click);
            // 
            // pictureGreen
            // 
            this.pictureGreen.BackColor = System.Drawing.Color.Lime;
            this.pictureGreen.Location = new System.Drawing.Point(10, 132);
            this.pictureGreen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureGreen.Name = "pictureGreen";
            this.pictureGreen.Size = new System.Drawing.Size(52, 36);
            this.pictureGreen.TabIndex = 4;
            this.pictureGreen.TabStop = false;
            this.pictureGreen.Click += new System.EventHandler(this.pictureGreen_Click_1);
            // 
            // pictureYellow
            // 
            this.pictureYellow.BackColor = System.Drawing.Color.Yellow;
            this.pictureYellow.Location = new System.Drawing.Point(10, 92);
            this.pictureYellow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureYellow.Name = "pictureYellow";
            this.pictureYellow.Size = new System.Drawing.Size(52, 36);
            this.pictureYellow.TabIndex = 3;
            this.pictureYellow.TabStop = false;
            this.pictureYellow.Click += new System.EventHandler(this.pictureYellow_Click_1);
            // 
            // pictureBlue
            // 
            this.pictureBlue.BackColor = System.Drawing.Color.Blue;
            this.pictureBlue.Location = new System.Drawing.Point(10, 51);
            this.pictureBlue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBlue.Name = "pictureBlue";
            this.pictureBlue.Size = new System.Drawing.Size(52, 36);
            this.pictureBlue.TabIndex = 2;
            this.pictureBlue.TabStop = false;
            this.pictureBlue.Click += new System.EventHandler(this.pictureBlue_Click_1);
            // 
            // pictureRed
            // 
            this.pictureRed.BackColor = System.Drawing.Color.Red;
            this.pictureRed.Location = new System.Drawing.Point(10, 11);
            this.pictureRed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureRed.Name = "pictureRed";
            this.pictureRed.Size = new System.Drawing.Size(52, 36);
            this.pictureRed.TabIndex = 1;
            this.pictureRed.TabStop = false;
            this.pictureRed.Click += new System.EventHandler(this.pictureRed_Click);
            // 
            // pictureAll
            // 
            this.pictureAll.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureAll.Location = new System.Drawing.Point(6, 0);
            this.pictureAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureAll.Name = "pictureAll";
            this.pictureAll.Size = new System.Drawing.Size(68, 350);
            this.pictureAll.TabIndex = 0;
            this.pictureAll.TabStop = false;
            this.pictureAll.Click += new System.EventHandler(this.pictureAll_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 51);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 350);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(2, 51);
            this.splitter2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(2, 350);
            this.splitter2.TabIndex = 7;
            this.splitter2.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // viewPort
            // 
            this.viewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPort.Location = new System.Drawing.Point(0, 51);
            this.viewPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.viewPort.Name = "viewPort";
            this.viewPort.Size = new System.Drawing.Size(693, 350);
            this.viewPort.TabIndex = 4;
            this.viewPort.Load += new System.EventHandler(this.viewPort_Load);
            this.viewPort.Paint += new System.Windows.Forms.PaintEventHandler(this.ViewPortPaint);
            this.viewPort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseDown);
            this.viewPort.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseMove);
            this.viewPort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ViewPortMouseUp);
            // 
            // customShapeToolStripMenuItem
            // 
            this.customShapeToolStripMenuItem.Name = "customShapeToolStripMenuItem";
            this.customShapeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customShapeToolStripMenuItem.Text = "Custom Shape";
            this.customShapeToolStripMenuItem.Click += new System.EventHandler(this.customShapeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 423);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panelColor);
            this.Controls.Add(this.viewPort);
            this.Controls.Add(this.speedMenu);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Draw";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.speedMenu.ResumeLayout(false);
            this.speedMenu.PerformLayout();
            this.panelColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCyan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureOrange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePurple)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAll)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		
		private System.Windows.Forms.ToolStripStatusLabel currentStatusLabel;
		private Draw.DoubleBufferedPanel viewPort;
		private System.Windows.Forms.ToolStripButton selectButton;
		private System.Windows.Forms.ToolStripButton drawRectangleSpeedButton;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStrip speedMenu;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripButton drawEllipseSpeedButton;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.PictureBox picturePurple;
        private System.Windows.Forms.PictureBox pictureGreen;
        private System.Windows.Forms.PictureBox pictureYellow;
        private System.Windows.Forms.PictureBox pictureBlue;
        private System.Windows.Forms.PictureBox pictureRed;
        private System.Windows.Forms.PictureBox pictureAll;
        private System.Windows.Forms.PictureBox pictureBlack;
        private System.Windows.Forms.PictureBox pictureCyan;
        private System.Windows.Forms.PictureBox pictureOrange;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolStripButton paintButton;
        private System.Windows.Forms.ToolStripButton sizeButton;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem selectColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEllipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fillColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borderColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton lineButton;
        private System.Windows.Forms.ToolStripMenuItem rotateSelectedShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton importImageButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem resizeSelectedShapeToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ColorDialog colorDialog3;
        private System.Windows.Forms.ToolStripButton removeButton;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allShapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton unselectButton;
        private System.Windows.Forms.ToolStripMenuItem customShapeToolStripMenuItem;
    }
}
