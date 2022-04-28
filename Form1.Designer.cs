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
            this.blurFlouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greyScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageCreationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fractalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelChooseBtn = new System.Windows.Forms.Panel();
            this.panelInputText = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelChooseBtn.SuspendLayout();
            this.panelInputText.SuspendLayout();
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
            this.chooseImageToolStripMenuItem.Size = new System.Drawing.Size(142, 29);
            this.chooseImageToolStripMenuItem.Text = "Choose Image";
            this.chooseImageToolStripMenuItem.Click += new System.EventHandler(this.chooseImageToolStripMenuItem_Click);
            // 
            // effectsToolStripMenuItem
            // 
            this.effectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurFlouToolStripMenuItem});
            this.effectsToolStripMenuItem.Name = "effectsToolStripMenuItem";
            this.effectsToolStripMenuItem.Size = new System.Drawing.Size(142, 29);
            this.effectsToolStripMenuItem.Text = "Effects";
            // 
            // blurFlouToolStripMenuItem
            // 
            this.blurFlouToolStripMenuItem.Name = "blurFlouToolStripMenuItem";
            this.blurFlouToolStripMenuItem.Size = new System.Drawing.Size(185, 34);
            this.blurFlouToolStripMenuItem.Text = "Blur/Flou";
            this.blurFlouToolStripMenuItem.Click += new System.EventHandler(this.blurFlouToolStripMenuItem_Click);
            // 
            // imageEditorToolStripMenuItem
            // 
            this.imageEditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.greyScaleToolStripMenuItem,
            this.rotationToolStripMenuItem});
            this.imageEditorToolStripMenuItem.Name = "imageEditorToolStripMenuItem";
            this.imageEditorToolStripMenuItem.Size = new System.Drawing.Size(142, 29);
            this.imageEditorToolStripMenuItem.Text = "Image Editor";
            // 
            // greyScaleToolStripMenuItem
            // 
            this.greyScaleToolStripMenuItem.Name = "greyScaleToolStripMenuItem";
            this.greyScaleToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.greyScaleToolStripMenuItem.Text = "GreyScale";
            this.greyScaleToolStripMenuItem.Click += new System.EventHandler(this.GreyScale);
            // 
            // rotationToolStripMenuItem
            // 
            this.rotationToolStripMenuItem.Name = "rotationToolStripMenuItem";
            this.rotationToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.rotationToolStripMenuItem.Text = "Rotation";
            this.rotationToolStripMenuItem.Click += new System.EventHandler(this.rotationToolStripMenuItem_Click);
            // 
            // imageCreationToolStripMenuItem
            // 
            this.imageCreationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramToolStripMenuItem,
            this.fractalToolStripMenuItem});
            this.imageCreationToolStripMenuItem.Name = "imageCreationToolStripMenuItem";
            this.imageCreationToolStripMenuItem.Size = new System.Drawing.Size(142, 29);
            this.imageCreationToolStripMenuItem.Text = "Image Creation";
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.histogramToolStripMenuItem.Text = "Histogram";
            // 
            // fractalToolStripMenuItem
            // 
            this.fractalToolStripMenuItem.Name = "fractalToolStripMenuItem";
            this.fractalToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.fractalToolStripMenuItem.Text = "Fractal";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
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
            this.panel3.Controls.Add(this.panelChooseBtn);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(899, 672);
            this.panel3.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WinFormsApp1.Properties.Resources.NoWayHome1;
            this.pictureBox1.Location = new System.Drawing.Point(334, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(598, 716);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(41, 258);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(112, 34);
            this.button6.TabIndex = 1;
            this.button6.Text = "button1";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(41, 182);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(112, 34);
            this.button8.TabIndex = 1;
            this.button8.Text = "Output";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(41, 106);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(112, 34);
            this.button9.TabIndex = 1;
            this.button9.Text = "qrGreen";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(41, 37);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(112, 34);
            this.button10.TabIndex = 1;
            this.button10.Text = "NWH";
            this.button10.UseVisualStyleBackColor = true;
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
            this.tabPage2.Size = new System.Drawing.Size(874, 678);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "QR Code";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(868, 672);
            this.panel2.TabIndex = 6;
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
            this.pictureBox2.Image = global::WinFormsApp1.Properties.Resources.NoWayHome1;
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
            // panelChooseBtn
            // 
            this.panelChooseBtn.Controls.Add(this.panelInputText);
            this.panelChooseBtn.Controls.Add(this.button10);
            this.panelChooseBtn.Controls.Add(this.button9);
            this.panelChooseBtn.Controls.Add(this.button6);
            this.panelChooseBtn.Controls.Add(this.button8);
            this.panelChooseBtn.Location = new System.Drawing.Point(61, 85);
            this.panelChooseBtn.Name = "panelChooseBtn";
            this.panelChooseBtn.Size = new System.Drawing.Size(199, 364);
            this.panelChooseBtn.TabIndex = 2;
            // 
            // panelInputText
            // 
            this.panelInputText.Controls.Add(this.textBox2);
            this.panelInputText.Controls.Add(this.button2);
            this.panelInputText.Location = new System.Drawing.Point(0, 0);
            this.panelInputText.Name = "panelInputText";
            this.panelInputText.Size = new System.Drawing.Size(199, 364);
            this.panelInputText.TabIndex = 3;
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(21, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(143, 31);
            this.textBox2.TabIndex = 2;
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelChooseBtn.ResumeLayout(false);
            this.panelInputText.ResumeLayout(false);
            this.panelInputText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem imageEditorToolStripMenuItem;
        private ToolStripMenuItem greyScaleToolStripMenuItem;
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
        private Button button6;
        private Button button8;
        private Button button9;
        private Button button10;
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
    }
}