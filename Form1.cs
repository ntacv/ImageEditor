using ProjectA2S4;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        string path;
        string output;
        string pathQr;
        MyImage image;

        public Form1()
        {
            InitializeComponent();


            Icon ico = Icon.ExtractAssociatedIcon("../../../Files/other/pixels.ico");
            this.Icon = ico;

            path = "../../../Files/Img/NoWayHome.bmp";
            output = "../../../Files/Img/Output.bmp";
            pathQr = "../../../Files/Img/";

            this.image = new MyImage(path);

            panel1.BringToFront();
            panelChooseBtn.BringToFront();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void ChangeImg(object sender, EventArgs e)
        {
            path = "../../../Files/Img/NoWayHome.bmp";
            pictureBox1.ImageLocation = path;
            this.image = new MyImage(path);
        }


        private void ChangeImg2(object sender, EventArgs e)
        {
            path = "../../../Files/Img/qrCode1Green.bmp";
            pictureBox1.ImageLocation = path;
            this.image = new MyImage(path);
        }

        private void ChangeImg3(object sender, EventArgs e)
        {
            //path = "../../../Files/Img/qrCode1Green.bmp";
            pictureBox1.ImageLocation = output;
            this.image = new MyImage(path);
        }



        private void chooseImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelChooseBtn.BringToFront();
            this.image = new MyImage(path);


        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //Generate QrCode
            string input = textBox1.Text;

            QRCode qrCode = new QRCode(input, pathQr);
            pictureBox2.ImageLocation = output;
        }


        #region Effects

        private void GreyScale(object sender, EventArgs e)
        {
            image.GreyScale();
            image.From_Image_To_File(output);
            pictureBox1.ImageLocation = output;

        }


        #endregion

        private void blurFlouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            image.Blur();
            image.From_Image_To_File(output);
            pictureBox1.ImageLocation = output;
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyImage.OpenImage(output);
        }

        private void rotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //panelChooseBtn.Enabled = false;
            panelInputText.BringToFront();

            if (textBox2.Text.Length > 0)
            {
                image.Rotation(ProgramImage.strInputToDouble(textBox2.Text));
                image.From_Image_To_File(output);
                pictureBox1.ImageLocation = output;
            }

        }
    }
}