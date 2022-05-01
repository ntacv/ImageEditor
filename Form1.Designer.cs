namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chooseImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.effectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.greyScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negatifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurFlouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luminosityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mirrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yAxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aggrandirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInRéduirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contourDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurFlouToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contourDetectionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenNetteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageCreationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luminosityToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fractalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelChooseBtn = new System.Windows.Forms.Panel();
            this.lenaBtn = new System.Windows.Forms.Button();
            this.spiderBtn = new System.Windows.Forms.Button();
            this.carBtn = new System.Windows.Forms.Button();
            this.parisBtn = new System.Windows.Forms.Button();
            this.panelInputText = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.bringInput2 = new System.Windows.Forms.Button();
            this.bringChoose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelChooseBtn.SuspendLayout();
            this.panelInputText.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseImageToolStripMenuItem,
            this.effectsToolStripMenuItem,
            this.imageEditorToolStripMenuItem,
            this.imageCreationToolStripMenuItem,
            this.openImageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(155, 716);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chooseImageToolStripMenuItem
            // 
            this.chooseImageToolStripMenuItem.Name = "chooseImageToolStripMenuItem";
            this.chooseImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.chooseImageToolStripMenuItem.Size = new System.Drawing.Size(142, 29);
            this.chooseImageToolStripMenuItem.Text = "Choose Image";
            this.chooseImageToolStripMenuItem.Click += new System.EventHandler(this.chooseImageToolStripMenuItem_Click);
            // 
            // effectsToolStripMenuItem
            // 
            this.effectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.greyScaleToolStripMenuItem,
            this.negatifToolStripMenuItem,
            this.blurFlouToolStripMenuItem});
            this.effectsToolStripMenuItem.Name = "effectsToolStripMenuItem";
            this.effectsToolStripMenuItem.Size = new System.Drawing.Size(142, 29);
            this.effectsToolStripMenuItem.Text = "Effects";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(240, 34);
            this.toolStripMenuItem1.Text = "Black and White";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.blackWhiteToolStripMenuItem_Click);
            // 
            // greyScaleToolStripMenuItem
            // 
            this.greyScaleToolStripMenuItem.Name = "greyScaleToolStripMenuItem";
            this.greyScaleToolStripMenuItem.Size = new System.Drawing.Size(240, 34);
            this.greyScaleToolStripMenuItem.Text = "GreyScale";
            this.greyScaleToolStripMenuItem.Click += new System.EventHandler(this.GreyScale);
            // 
            // negatifToolStripMenuItem
            // 
            this.negatifToolStripMenuItem.Name = "negatifToolStripMenuItem";
            this.negatifToolStripMenuItem.Size = new System.Drawing.Size(240, 34);
            this.negatifToolStripMenuItem.Text = "Negatif";
            this.negatifToolStripMenuItem.Click += new System.EventHandler(this.negatifToolStripMenuItem_Click);
            // 
            // blurFlouToolStripMenuItem
            // 
            this.blurFlouToolStripMenuItem.Name = "blurFlouToolStripMenuItem";
            this.blurFlouToolStripMenuItem.Size = new System.Drawing.Size(240, 34);
            this.blurFlouToolStripMenuItem.Text = "Blur/Flou";
            this.blurFlouToolStripMenuItem.Click += new System.EventHandler(this.blurFlouToolStripMenuItem_Click);
            // 
            // imageEditorToolStripMenuItem
            // 
            this.imageEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.luminosityToolStripMenuItem,
            this.mirrorToolStripMenuItem,
            this.aggrandirToolStripMenuItem,
            this.zoomInRéduirToolStripMenuItem,
            this.rotationToolStripMenuItem,
            this.shearToolStripMenuItem,
            this.contourDetectionToolStripMenuItem});
            this.imageEditorToolStripMenuItem.Name = "imageEditorToolStripMenuItem";
            this.imageEditorToolStripMenuItem.Size = new System.Drawing.Size(142, 29);
            this.imageEditorToolStripMenuItem.Text = "Image Editor";
            this.imageEditorToolStripMenuItem.Click += new System.EventHandler(this.imageEditorToolStripMenuItem_Click);
            // 
            // luminosityToolStripMenuItem
            // 
            this.luminosityToolStripMenuItem.Name = "luminosityToolStripMenuItem";
            this.luminosityToolStripMenuItem.Size = new System.Drawing.Size(278, 34);
            this.luminosityToolStripMenuItem.Text = "Luminosity";
            this.luminosityToolStripMenuItem.Click += new System.EventHandler(this.luminosityToolStripMenuItem_Click);
            // 
            // mirrorToolStripMenuItem
            // 
            this.mirrorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xAxisToolStripMenuItem,
            this.yAxisToolStripMenuItem});
            this.mirrorToolStripMenuItem.Name = "mirrorToolStripMenuItem";
            this.mirrorToolStripMenuItem.Size = new System.Drawing.Size(278, 34);
            this.mirrorToolStripMenuItem.Text = "Mirror";
            // 
            // xAxisToolStripMenuItem
            // 
            this.xAxisToolStripMenuItem.Name = "xAxisToolStripMenuItem";
            this.xAxisToolStripMenuItem.Size = new System.Drawing.Size(159, 34);
            this.xAxisToolStripMenuItem.Text = "X axis";
            this.xAxisToolStripMenuItem.Click += new System.EventHandler(this.xAxisToolStripMenuItem_Click);
            // 
            // yAxisToolStripMenuItem
            // 
            this.yAxisToolStripMenuItem.Name = "yAxisToolStripMenuItem";
            this.yAxisToolStripMenuItem.Size = new System.Drawing.Size(159, 34);
            this.yAxisToolStripMenuItem.Text = "Y axis";
            this.yAxisToolStripMenuItem.Click += new System.EventHandler(this.yAxisToolStripMenuItem_Click);
            // 
            // aggrandirToolStripMenuItem
            // 
            this.aggrandirToolStripMenuItem.Name = "aggrandirToolStripMenuItem";
            this.aggrandirToolStripMenuItem.Size = new System.Drawing.Size(278, 34);
            this.aggrandirToolStripMenuItem.Text = "ZoomOut / Agrandir";
            this.aggrandirToolStripMenuItem.Click += new System.EventHandler(this.aggrandirToolStripMenuItem_Click);
            // 
            // zoomInRéduirToolStripMenuItem
            // 
            this.zoomInRéduirToolStripMenuItem.Name = "zoomInRéduirToolStripMenuItem";
            this.zoomInRéduirToolStripMenuItem.Size = new System.Drawing.Size(278, 34);
            this.zoomInRéduirToolStripMenuItem.Text = "ZoomIn / Réduir";
            this.zoomInRéduirToolStripMenuItem.Click += new System.EventHandler(this.zoomInRéduirToolStripMenuItem_Click);
            // 
            // rotationToolStripMenuItem
            // 
            this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
            this.rotationToolStripMenuItem.Size = new System.Drawing.Size(278, 34);
            this.rotationToolStripMenuItem.Text = "Rotation";
            this.rotationToolStripMenuItem.Click += new System.EventHandler(this.rotationToolStripMenuItem_Click);
            // 
            // shearToolStripMenuItem
            // 
            this.shearToolStripMenuItem.Name = "shearToolStripMenuItem";
            this.shearToolStripMenuItem.Size = new System.Drawing.Size(278, 34);
            this.shearToolStripMenuItem.Text = "Shear / Cisaillement";
            this.shearToolStripMenuItem.Click += new System.EventHandler(this.shearToolStripMenuItem_Click);
            // 
            // contourDetectionToolStripMenuItem
            // 
            this.contourDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurFlouToolStripMenuItem1,
            this.contourDetectionToolStripMenuItem1,
            this.sharpenNetteToolStripMenuItem});
            this.contourDetectionToolStripMenuItem.Name = "contourDetectionToolStripMenuItem";
            this.contourDetectionToolStripMenuItem.Size = new System.Drawing.Size(278, 34);
            this.contourDetectionToolStripMenuItem.Text = "Convolution";
            this.contourDetectionToolStripMenuItem.Click += new System.EventHandler(this.contourDetectionToolStripMenuItem_Click);
            // 
            // blurFlouToolStripMenuItem1
            // 
            this.blurFlouToolStripMenuItem1.Name = "blurFlouToolStripMenuItem1";
            this.blurFlouToolStripMenuItem1.Size = new System.Drawing.Size(258, 34);
            this.blurFlouToolStripMenuItem1.Text = "Blur / Flou";
            this.blurFlouToolStripMenuItem1.Click += new System.EventHandler(this.blurFlouToolStripMenuItem1_Click);
            // 
            // contourDetectionToolStripMenuItem1
            // 
            this.contourDetectionToolStripMenuItem1.Name = "contourDetectionToolStripMenuItem1";
            this.contourDetectionToolStripMenuItem1.Size = new System.Drawing.Size(258, 34);
            this.contourDetectionToolStripMenuItem1.Text = "Contour detection";
            this.contourDetectionToolStripMenuItem1.Click += new System.EventHandler(this.contourDetectionToolStripMenuItem1_Click);
            // 
            // sharpenNetteToolStripMenuItem
            // 
            this.sharpenNetteToolStripMenuItem.Name = "sharpenNetteToolStripMenuItem";
            this.sharpenNetteToolStripMenuItem.Size = new System.Drawing.Size(258, 34);
            this.sharpenNetteToolStripMenuItem.Text = "Sharpen / Nette";
            this.sharpenNetteToolStripMenuItem.Click += new System.EventHandler(this.sharpenNetteToolStripMenuItem_Click);
            // 
            // imageCreationToolStripMenuItem
            // 
            this.imageCreationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramToolStripMenuItem,
            this.fractalToolStripMenuItem});
            this.imageCreationToolStripMenuItem.Name = "imageCreationToolStripMenuItem";
            this.imageCreationToolStripMenuItem.Size = new System.Drawing.Size(142, 29);
            this.imageCreationToolStripMenuItem.Text = "Image Creation";
            this.imageCreationToolStripMenuItem.Click += new System.EventHandler(this.imageCreationToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorsToolStripMenuItem,
            this.luminosityToolStripMenuItem1});
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(200, 34);
            this.colorsToolStripMenuItem.Text = "Colors";
            this.colorsToolStripMenuItem.Click += new System.EventHandler(this.colorsToolStripMenuItem_Click);
            // 
            // luminosityToolStripMenuItem1
            // 
            this.luminosityToolStripMenuItem1.Name = "luminosityToolStripMenuItem1";
            this.luminosityToolStripMenuItem1.Size = new System.Drawing.Size(200, 34);
            this.luminosityToolStripMenuItem1.Text = "Luminosity";
            this.luminosityToolStripMenuItem1.Click += new System.EventHandler(this.luminosityToolStripMenuItem1_Click);
            // 
            // fractalToolStripMenuItem
            // 
            this.fractalToolStripMenuItem.Name = "fractalToolStripMenuItem";
            this.fractalToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.fractalToolStripMenuItem.Text = "Fractal";
            this.fractalToolStripMenuItem.Click += new System.EventHandler(this.fractalToolStripMenuItem_Click);
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(142, 29);
            this.openImageToolStripMenuItem.Text = "Open Image";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.openImageToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(913, 716);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(905, 678);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Image Editor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panelChooseBtn);
            this.panel3.Controls.Add(this.panelInputText);
            this.panel3.Controls.Add(this.bringInput2);
            this.panel3.Controls.Add(this.bringChoose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(899, 672);
            this.panel3.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Location = new System.Drawing.Point(360, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(539, 672);
            this.panel4.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::WinFormsApp1.Properties.Resources.Jesko;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(539, 672);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelChooseBtn
            // 
            this.panelChooseBtn.Controls.Add(this.lenaBtn);
            this.panelChooseBtn.Controls.Add(this.spiderBtn);
            this.panelChooseBtn.Controls.Add(this.carBtn);
            this.panelChooseBtn.Controls.Add(this.parisBtn);
            this.panelChooseBtn.Location = new System.Drawing.Point(61, 85);
            this.panelChooseBtn.Name = "panelChooseBtn";
            this.panelChooseBtn.Size = new System.Drawing.Size(199, 364);
            this.panelChooseBtn.TabIndex = 2;
            // 
            // lenaBtn
            // 
            this.lenaBtn.Location = new System.Drawing.Point(41, 37);
            this.lenaBtn.Name = "lenaBtn";
            this.lenaBtn.Size = new System.Drawing.Size(112, 34);
            this.lenaBtn.TabIndex = 1;
            this.lenaBtn.Text = "Lena";
            this.lenaBtn.UseVisualStyleBackColor = true;
            this.lenaBtn.Click += new System.EventHandler(this.ChangeImg2);
            // 
            // spiderBtn
            // 
            this.spiderBtn.Location = new System.Drawing.Point(41, 106);
            this.spiderBtn.Name = "spiderBtn";
            this.spiderBtn.Size = new System.Drawing.Size(112, 34);
            this.spiderBtn.TabIndex = 1;
            this.spiderBtn.Text = "SpiderMan";
            this.spiderBtn.UseVisualStyleBackColor = true;
            this.spiderBtn.Click += new System.EventHandler(this.ChangeImg);
            // 
            // carBtn
            // 
            this.carBtn.Location = new System.Drawing.Point(41, 258);
            this.carBtn.Name = "carBtn";
            this.carBtn.Size = new System.Drawing.Size(112, 34);
            this.carBtn.TabIndex = 1;
            this.carBtn.Text = "Sport car";
            this.carBtn.UseVisualStyleBackColor = true;
            this.carBtn.Click += new System.EventHandler(this.ChangeImgCar);
            // 
            // parisBtn
            // 
            this.parisBtn.Location = new System.Drawing.Point(41, 182);
            this.parisBtn.Name = "parisBtn";
            this.parisBtn.Size = new System.Drawing.Size(112, 34);
            this.parisBtn.TabIndex = 1;
            this.parisBtn.Text = "Paris";
            this.parisBtn.UseVisualStyleBackColor = true;
            this.parisBtn.Click += new System.EventHandler(this.ChangeImg3);
            // 
            // panelInputText
            // 
            this.panelInputText.Controls.Add(this.textBox2);
            this.panelInputText.Controls.Add(this.button2);
            this.panelInputText.Location = new System.Drawing.Point(58, 88);
            this.panelInputText.Name = "panelInputText";
            this.panelInputText.Size = new System.Drawing.Size(199, 364);
            this.panelInputText.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(143, 31);
            this.textBox2.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "Generate";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // bringInput2
            // 
            this.bringInput2.Location = new System.Drawing.Point(118, 532);
            this.bringInput2.Name = "bringInput2";
            this.bringInput2.Size = new System.Drawing.Size(112, 34);
            this.bringInput2.TabIndex = 3;
            this.bringInput2.Text = "bringInput";
            this.bringInput2.UseVisualStyleBackColor = true;
            this.bringInput2.Visible = false;
            this.bringInput2.Click += new System.EventHandler(this.bringInput);
            // 
            // bringChoose
            // 
            this.bringChoose.Location = new System.Drawing.Point(118, 586);
            this.bringChoose.Name = "bringChoose";
            this.bringChoose.Size = new System.Drawing.Size(112, 34);
            this.bringChoose.TabIndex = 3;
            this.bringChoose.Text = "bringchoose";
            this.bringChoose.UseVisualStyleBackColor = true;
            this.bringChoose.Visible = false;
            this.bringChoose.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(905, 678);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "QR Code";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(899, 672);
            this.panel2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 25);
            this.label3.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 66);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 31);
            this.textBox1.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WinFormsApp1.Properties.Resources.QRcode;
            this.pictureBox2.Location = new System.Drawing.Point(334, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(598, 716);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(101, 133);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(112, 34);
            this.button7.TabIndex = 1;
            this.button7.Text = "Generate";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(155, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(913, 716);
            this.panel1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 716);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelChooseBtn.ResumeLayout(false);
            this.panelInputText.ResumeLayout(false);
            this.panelInputText.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem imageEditorToolStripMenuItem;
        private ToolStripMenuItem rotationToolStripMenuItem;
        private ToolStripMenuItem effectsToolStripMenuItem;
        private ToolStripMenuItem blurFlouToolStripMenuItem;
        private ToolStripMenuItem imageCreationToolStripMenuItem;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private ToolStripMenuItem fractalToolStripMenuItem;
        private ToolStripMenuItem chooseImageToolStripMenuItem;
        private PageSetupDialog pageSetupDialog1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Button carBtn;
        private Button parisBtn;
        private Button spiderBtn;
        private Button lenaBtn;
        private Label label1;
        private TabPage tabPage2;
        private Panel panel2;
        private TextBox textBox1;
        private PictureBox pictureBox2;
        private Button button7;
        private Label label2;
        private Panel panel1;
        private ToolStripMenuItem openImageToolStripMenuItem;
        private Panel panelChooseBtn;
        private Panel panelInputText;
        private TextBox textBox2;
        private Button button2;
        private Button bringChoose;
        private Button bringInput2;
        private Label label3;
        private ToolStripMenuItem negatifToolStripMenuItem;
        private ToolStripMenuItem luminosityToolStripMenuItem;
        private ToolStripMenuItem aggrandirToolStripMenuItem;
        private ToolStripMenuItem zoomInRéduirToolStripMenuItem;
        private ToolStripMenuItem mirrorToolStripMenuItem;
        private ToolStripMenuItem xAxisToolStripMenuItem;
        private ToolStripMenuItem yAxisToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem greyScaleToolStripMenuItem;
        private ToolStripMenuItem luminosityToolStripMenuItem1;
        private ToolStripMenuItem shearToolStripMenuItem;
        private ToolStripMenuItem contourDetectionToolStripMenuItem;
        private ToolStripMenuItem blurFlouToolStripMenuItem1;
        private ToolStripMenuItem contourDetectionToolStripMenuItem1;
        private ToolStripMenuItem sharpenNetteToolStripMenuItem;
        private Panel panel4;
        private ToolStripMenuItem colorsToolStripMenuItem;
    }
}