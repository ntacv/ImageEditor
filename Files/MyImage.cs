using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectA2S4;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ProjectA2S4
{
    /// <summary>
    /// Class bitmap to manipulate images
    /// </summary>
    public class MyImage
    {

        #region Properties
        byte[] voidByte = new byte[] {0, 0, 0, 0};

        string path;//chemin de l'image
        string pathFolder;
        //byte[] data;
        RGB[,] imgMatrix;

        byte[] format;//66 77 = BMP
        int fileSize; //imgSize + headerSize
        int headerSize;//54 bytes
        int imgSize;//width * height * 3colors
        int width;
        int height;
        int bitpercolor;//=8 bits/color => 24 bits/pixel

        public byte[] Format { get { return format; } }
        public int FileSize { get { return fileSize; } }
        public int Width { get { return width; } }
        public int Height { get { return height;} }
        public int HeaderSize { get { return headerSize;} }
        public int ImageSize { get { return imgSize; } }
        public RGB[,] ImgMatrix { get { return imgMatrix; } }
        

        #endregion

        /// <summary>
        /// Constructor that takes a bitmap image
        /// </summary>
        /// <param name="path">path to the input bitmap image</param>
        public MyImage(string path)
        {
            this.path = path;

            string[] folders = path.Split('/');
            for(int i = 0; i < folders.Length-1; i++)
            {
                this.pathFolder += folders[i]+"/";
            }

            byte[] data = File.ReadAllBytes(path);
            byte[] formatBytes = new byte[2] { 66, 77 };

            if (formatBytes[0] == data[0] && formatBytes[1] == data[1])
            {
                this.format = formatBytes;
            }
            else this.format = new byte[2];
            this.fileSize = ProgramImage.ReadBytes(data[2..6]);
            this.imgSize = ProgramImage.ReadBytes(data[34..38]);
            this.width = ProgramImage.ReadBytes(data[18..22]);
            this.height = ProgramImage.ReadBytes(data[22..26]);
            this.headerSize = ProgramImage.ReadBytes(data[10..14]);

            this.bitpercolor = ProgramImage.ReadBytes(data[28..30])/3;

            byte[] imgData = data[headerSize..(data.Length)];

            
            this.imgMatrix = new RGB[height, width];
            int k = 0;
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    byte[] pixelData = new byte[3] { imgData[k], imgData[k + 1], imgData[k + 2] };
                    RGB rgb = new RGB(pixelData);
                    k += 3;
                    imgMatrix[i, j] = rgb;
                }
            }
        }
        /// <summary>
        /// Make a bitmap file based on the input image and the modifications applied to it
        /// </summary>
        /// <param name="fileName">path to the output file</param>
        public void From_Image_To_File(string fileName, bool openFile=false)
        {
            //From website
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                // Create a new file     
                StreamWriter sw = new StreamWriter(fileName); //path
                imgSize = height * width;
                sw.BaseStream.Write(this.format, 0, this.format.Length);//fomat 
                sw.BaseStream.Write(Convertir_Int_To_Endian(imgSize+headerSize), 0, 4);//fileSize
                sw.BaseStream.Write(voidByte,0,4);
                sw.BaseStream.Write(Convertir_Int_To_Endian(headerSize),0,4);
                sw.BaseStream.Write(Convertir_Int_To_Endian(headerSize-14), 0, 4);
                sw.BaseStream.Write(Convertir_Int_To_Endian(width), 0, 4);
                sw.BaseStream.Write(Convertir_Int_To_Endian(height), 0, 4);
                sw.BaseStream.Write(new byte[] { 1, 0 }, 0, 2);
                sw.BaseStream.Write(Convertir_Int_To_Endian(bitpercolor*3), 0, 2);
                sw.BaseStream.Write(voidByte, 0, 4);
                sw.BaseStream.Write(Convertir_Int_To_Endian(imgSize), 0, 4);//imgSize
                sw.BaseStream.Write(voidByte, 0, 4);
                sw.BaseStream.Write(voidByte, 0, 4);
                sw.BaseStream.Write(voidByte, 0, 4);
                sw.BaseStream.Write(voidByte, 0, 4);
                
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if(imgMatrix[i, j] == null)
                        {
                            imgMatrix[i, j] = new RGB( new byte[3] { 0, 255, 0 });
                            sw.BaseStream.Write(imgMatrix[i,j].ToByte(), 0, 3);
                        }
                        sw.BaseStream.Write(imgMatrix[i, j].ToByte(), 0, 3);
                    }
                }
                sw.Close();
                if(openFile) OpenFile(pathFolder + fileName);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

        #region Functions
        
        /// <summary>
        /// Return all the data about the image
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = "Image data: \n";

            if (66 == format[0] && 77 == format[1])
            //36609 == Program.ReadBytes(new byte[] { data[0], data[1] })
            {
                str += format + "\n";
            }
            str += "Size: " + ProgramImage.ShortSize(fileSize) + "\n";
            str += "Img size: " + ProgramImage.ShortSize(imgSize) + "\n";
            str += "Header size: " + ProgramImage.ShortSize(headerSize) + "\n";
            str += "Width: " + width.ToString() + " pixels\n";
            str += "Heigth: " + height.ToString() + " pixels\n";
            str += "bit/color: " + bitpercolor.ToString() + "\n";

            return str;
        }
        /// <summary>
        /// Open the bitmap image in the photo app
        /// </summary>
        /// <param name="fileName"></param>
        public static void OpenFile(string fileName)
        {

            try
            {
                Process.Start(fileName);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {fileName}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", fileName);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", fileName);
                }
                else
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// Affiche les données brutes de l'image
        /// </summary>
        /// <returns></returns>
        public string ImageToString()
        {
            
            if (imgMatrix == null) return " none ";
            string str = "";
            /*
            for (int i = 0; i < data.Length; i++)
            {
                if (i == 14) str+="\n";
                if (i == 54) str += "\n";
                if (i % 60 == 0) str += "\n";
                str += Program.AlignString(data[i].ToString(), 3) + " ";
            }
            */
            return str;
        }
        /// <summary>
        /// Affiche la matrice en 0 et 1, 0 si le pixel et noir 
        /// </summary>
        /// <returns></returns>
        public string PrintMatrixBinary()
        {
            string str = "";
            int pixelsPoints = this.ImgMatrix.Length;
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    Console.Write(this.ImgMatrix[i, j].ToBinary() + " ; ");
                }
                Console.WriteLine();
            }
            return str;

        }
        /// <summary>
        /// Convertion binaire Little Endian vers valeur numérique
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int Convertir_Endian_To_Int(byte[] data)
        {
            int sum = 0;

            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i] * Convert.ToInt32(Math.Pow(256, i));
            }

            return sum;
        }
        public static double Convertir_Binary_To_Double(int[] data)
        {
            double sum = 0;

            for (int i = 0; i < data.Length; i++)
            {
                sum += data[data.Length -1 - i] * Convert.ToInt32(Math.Pow(2, i));
            }

            return sum;
        }
        /// <summary>
        /// Conversion valeur numerique vers binaire Little Endian
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte[] Convertir_Int_To_Endian(int val)
        {
            byte[] data = new byte[4];

            data[0] = (byte)val;
            data[1] = (byte)(((uint)val >> 8) & 0xFF);
            data[2] = (byte)(((uint)val >> 16) & 0xFF);
            data[3] = (byte)(((uint)val >> 24) & 0xFF);

            //data[1] = (byte)((int)val >>8 & 255);

            return data;
        }
        #endregion

        #region Traitement
        /// <summary>
        /// inverse le sens de l'image 
        /// </summary>
        /// <param name="axisXorY">x or y, choose which axis to apply the effect</param>
        public void Mirror(char axisXorY='x')
        {

            RGB[,] tempMatrix = new RGB[height, width];

            if (axisXorY == 'x')
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        tempMatrix[i, width - 1 - j] = imgMatrix[i, j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        tempMatrix[height -1 - i, j] = imgMatrix[i, j];
                    }
                }
            }
            imgMatrix = tempMatrix;
        }
        /// <summary>
        /// rotate the image based on the degree angle input
        /// </summary>
        /// <param name="deg"></param>
        public void Rotate(double deg)
        {
            /*
            PI = 3.1415
            c = cos(angle_degre/180*PI)
            s = sin(angle_degre / 180 * PI)
            Pour tout pixel j 0 ET x0 ET y<hauteur Alors
                   destination(i, j) = source(x, y)
                Sinon
                    destination(i, j) = couleur fond
               Fin
            Fin
            */
            //Calculer l'hypoténuse et recadre l'image a la taille max avant de la rotate
            double radian = ProgramImage.ToRadian(deg);

            RGB[,] tempMatrix;
            /*
            switch (deg)
            {
                case 90: 
                    tempMatrix = new RGB[height, width];
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            tempMatrix[i, width - 1 - j] = imgMatrix[i, j];
                        }
                    }
                    return;

                case 180:
                    tempMatrix = new RGB[height, width];
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            tempMatrix[height - 1 - i, width - 1 - j] = imgMatrix[i, j];
                        }
                    }
                    return;

                case 270:
                    tempMatrix = new RGB[height, width];
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            tempMatrix[height - 1 - i, j] = imgMatrix[i, j];
                        }
                    }
                    return;
            }
            */
            tempMatrix = new RGB[height, width];
            
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tempMatrix[i, j] = new RGB(new byte[] {0,0,0});
                }
            }

            //                  [ cos(A) sin(A)]
            //[X Y] =  [x y] *  [-sin(A) cos(A)]
            double[,] matRotation = new double[2, 2] {
                { Math.Cos(radian),Math.Sin(radian)},
                { -Math.Sin(radian), Math.Cos(radian)}};
            
            
            int center_x = width/ 2;
            int center_y = height/ 2;

            //int xp = (int)((x - center_x) * Math.Cos(radian) - (y - center_y) * Math.Sin(radian) + center_x) ;
            //int yp = (int)((x - center_x) * Math.Sin(radian) + (y - center_y) * Math.Cos(radian) + center_y) ;
            int xp = 0; int yp = 0;

            for (int x = 0; x < height; ++x)
            {
                for(int y = 0; y < width; ++y)
                {
                    xp = (int)( (x-center_x) * Math.Cos(radian) - (y-center_y) * Math.Sin(radian)+center_x);
                    yp = (int)( (x-center_x) * Math.Sin(radian) + (y-center_y) * Math.Cos(radian)+center_y);
                    if (xp < tempMatrix.GetLength(0) && yp < tempMatrix.GetLength(1) && xp >= 0 && yp >= 0)
                    {
                        tempMatrix[xp, yp] = imgMatrix[x, y];
                    }
                }
            }

            imgMatrix = tempMatrix;
        }
        /// <summary>
        /// Tord l'image selon un axe pour un degrée donné
        /// </summary>
        /// <param name="deg"></param>
        /// <param name="axis"></param>
        public void Shear(int deg, char axis='x')
        {
            double radian = ProgramImage.ToRadian(deg);
            RGB[,] tempMatrix = new RGB[height, width];

            double[,] shear1 = new double[2, 2] {
                { 1 , -Math.Tan(radian/2)},
                { 0, 1}};

            double[,] shear2 = new double[2, 2] {
                {1, 0 },
                {Math.Sin(radian), 1 } };

            //double[,] shear3 = shear1;
            int xp = 0; int yp = 0;

            for (int x = 0; x < height; ++x)
            {
                for (int y = 0; y < width; ++y)
                {
                    double[,] xy = new double[2, 1] { { x }, { y } };
                    double[,] new_xy = new double[2, 1];
                    //new_xy = Program.matrixMult(shear1, xy);

                    new_xy[0, 0] = shear1[0, 0] * xy[0, 0] + shear1[0, 1] * xy[1, 0];
                    new_xy[1, 0] = shear1[1, 0] * xy[0, 0] + shear1[1, 1] * xy[1, 0];

                    xp = Convert.ToInt32(new_xy[0,0]);
                    yp = Convert.ToInt32(new_xy[1,0]);

                    if (xp >= 0 && yp >= 0 && xp < tempMatrix.GetLength(0) && yp < tempMatrix.GetLength(1))
                    {
                        tempMatrix[xp, yp] = imgMatrix[x, y];
                    }
                }
            }
            imgMatrix = tempMatrix;
        }
        /// <summary>
        /// Applique un effet de nuance de gris sur l'image
        /// </summary>
        public void GreyScale()
        {


            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {

                    byte grey = (byte)(imgMatrix[i,j].Red * 0.299 + imgMatrix[i,j].Green * 0.587 + imgMatrix[i,j].Blue * 0.114 );

                    imgMatrix[i, j] = new RGB(new byte[] { grey, grey, grey });
                }
            }


        }
        /// <summary>
        /// Applique un effet de noir et blanc sur l'image
        /// </summary>
        public void ToBlackAndWhite()
        {

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int newColor = 0;
                    int meanColor = 0;


                    for (int k=0; k<3; k++)
                    {
                        meanColor += imgMatrix[i, j].ToByte()[k];
                    }
                    meanColor /= 3;

                    newColor = Convert.ToInt32(Math.Round((Convert.ToDouble(meanColor) / Convert.ToDouble(255))));

                    if(newColor == 0)
                    {
                        imgMatrix[i, j] = new RGB(new byte[] { 0,0,0 });
                    }
                    else { imgMatrix[i, j] = new RGB(new byte[] { 255,255,255 }); }
                    
                }
            }

        }
        /// <summary>
        /// Tentative de réduction du nombre de couleur par pixel
        /// </summary>
        public void _8to4bit()
        {
            this.bitpercolor = bitpercolor / 2;
            this.imgSize = imgSize / 2;
            this.fileSize = headerSize + imgSize;
            byte red;
            byte green;
            byte blue;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    red = (byte)(imgMatrix[i, j].Red / 16);
                    green = (byte)(imgMatrix[i,j].Green / 16);
                    blue = (byte)(imgMatrix[i,j].Blue / 16);
                    
                    imgMatrix[i, j] = new RGB(new byte[] { red, green, blue });
                }
            }

        }
        /// <summary>
        /// réduit la luminosité de l'image
        /// </summary>
        /// <param name="percent">valeur en pourcentage</param>
        public void Luminosity(int percent)
        {
            if (percent < 0 || percent>100) return;

            percent = percent / 100;

            byte red;
            byte green;
            byte blue;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    red = (byte)(imgMatrix[i, j].Red * percent);
                    green = (byte)(imgMatrix[i, j].Green * percent);
                    blue = (byte)(imgMatrix[i, j].Blue * percent);

                    imgMatrix[i, j] = new RGB(new byte[] { red, green, blue });
                }
            }

        }
        /// <summary>
        /// Applique un effet d'inversion des couleurs sur l'image
        /// </summary>
        public void Negatif()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                { 
                    imgMatrix[i,j].Negatif();
                }
            }
        }
        /// <summary>
        /// Augmente le nombre de pixels dans l'image par un facteur entier
        /// </summary>
        /// <param name="factor"></param>
        public void Agrandissement(double factor)
        {
            if (factor <= 0 || factor ==1) return;
            if(factor > 1)
            {
                int factorInt = (int)(Math.Truncate(factor));

                int height = imgMatrix.GetLength(0);//row
                int width = imgMatrix.GetLength(1);//column

                RGB[,] newMatrix = new RGB[height * factorInt, width * factorInt];
                //change the size of the image in the header
                this.height = height * factorInt;
                this.width = width * factorInt;
                
                for (int i = 0; i < height; i++)//row
                {
                    for (int j = 0; j < width; j++)//column
                    {

                        for (int k = 0; k < factorInt; k++){

                            for (int l = 0; l < factorInt; l++)
                            {
                                newMatrix[factorInt * i + k, factorInt * j + l] = imgMatrix[i, j];
                            }
                        }
                        
                    }
                    
                }
                imgMatrix = newMatrix;
            }
        }
        /// <summary>
        /// Réduit le nombre de pixels dans l'image par un facteur entier
        /// </summary>
        /// <param name="factor"></param>
        public void Retrecir(int factor)
        {
            //change the size of the image in the header
            int reminder = imgMatrix.GetLength(1) % 4;
            this.height = imgMatrix.GetLength(0) / factor;
            this.width = imgMatrix.GetLength(1) / factor + 4 - reminder;

            RGB[,] newMatrix = new RGB[height, width];
            for(int i = 0; i < height; i++)
            {
                for(int j=0; j <width; j++)
                {
                    newMatrix[i, j] = new RGB(0, 0, 0);
                }
            }

            for(int i = 0; i < imgMatrix.GetLength(0) / factor; i++)
            {
                for( int j = 0; j < imgMatrix.GetLength(1) / factor; j++)
                {
                    newMatrix[i, j] = imgMatrix[i*factor, j*factor];
                }
            }
            
            imgMatrix = newMatrix;
        }

        #endregion

        #region Convolution

        public void Indicatrice()
        {
            double[,] indicatrice = new double[3, 3] { { 0, 0, 0 }, { 0, 1, 0}, { 0, 0, 0} };

            Convolution(indicatrice);
        }
        /// <summary>
        /// Convolution : apparition des contours
        /// </summary>
        public void Contours()
        {
            double[,] matContours = new double[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };
            GreyScale();
            Convolution(matContours);
        }
        /// <summary>
        /// Convolution : floutage de l'image
        /// </summary>
        public void Blur(double factor=1/9)
        {
            double[,] matBlur = new double[3, 3] { { factor, factor, factor }, { factor, factor, factor }, { factor, factor, factor } };

            Convolution(matBlur);
        }
        /// <summary>
        /// Convolution : affine les coutours pour améliorer la netteté
        /// </summary>
        public void Sharpen()
        {
            double[,] matSharp = new double[3, 3] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };

            Convolution(matSharp);
        }
        /// <summary>
        /// Convolution pour noyau de taille 3 et 5
        /// </summary>
        /// <param name="kernel"></param>
        public void Convolution(double[,] kernel)
        {
            RGB[,] output = new RGB[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int sumR = 0;
                    int sumG = 0;
                    int sumB = 0;
                    int debutK = 0;
                    int finK = 0;
                    int decalage = 0;
                    if (kernel.GetLength(0) == 3)
                    {
                        debutK = -1;
                        finK = 1;
                        decalage = 1;
                    }
                    else if (kernel.GetLength(0) == 5)
                    {
                        debutK = -2;
                        finK = 2;
                        decalage = 2;
                    }
                    for (int i2 = debutK; i2 <= finK; i2++)
                    {
                        for (int j2 = debutK; j2 <= finK; j2++)
                        {
                            int position_i = i + i2;
                            int position_j = j + j2;
                            if (position_i >= 0 && position_j >= 0 && position_i < height && position_j < width)
                            {
                                sumR += (int)(kernel[i2 + decalage, j2 + decalage] * imgMatrix[position_i, position_j].Red);
                                sumG += (int)(kernel[i2 + decalage, j2 + decalage] * imgMatrix[position_i, position_j].Green);
                                sumB += (int)(kernel[i2 + decalage, j2 + decalage] * imgMatrix[position_i, position_j].Blue);
                            }
                        }
                    }

                    if (i == 0 || i == height || j == width || j == 0)
                    {
                        sumR = 0;
                        sumG = 0;
                        sumB = 0;
                    }

                    sumR = Math.Max(0, Math.Min(255, sumR));
                    sumG = Math.Max(0, Math.Min(255, sumG));
                    sumB = Math.Max(0, Math.Min(255, sumB));

                    output[i, j] = new RGB(sumR, sumG, sumB);
                }
            }
            imgMatrix = output;
        }
        /// <summary>
        /// Applique un filtre de convolution selon une matrice noyeau quelconque
        /// </summary>
        /// <param name="kernel"></param>
        public void ConvolutionTry(int[,] kernel)
        {
            if (kernel != null && kernel.GetLength(0) == kernel.GetLength(1))
            //matrice dim impaires /!\
            {
                RGB[,] newMatrix = new RGB[height, width];

                int kernelMiddleY = kernel.GetLength(0) / 2;
                int kernelMiddleX = kernel.GetLength(1) / 2;

                for (int imageY = 1/*kernelMiddle*/; imageY < imgMatrix.GetLength(0) - 1; imageY++)
                {
                    for (int imageX = 1; imageX < imgMatrix.GetLength(1) - 1; imageX++)
                    {
                        int newR = 0;
                        int newG = 0;
                        int newB = 0;

                        for (int kernelY = 0; kernelY < kernel.GetLength(0); kernelY++)
                        {
                            for (int kernelX = 0; kernelX < kernel.GetLength(1); kernelX++)
                            {
                                /*
                                pos_dx -= kernelMiddleX;
                                pos_dy -= kernelMiddleY;
                                */

                                int pos_dy = imageY + kernelY - 1;//-kernelmiddle
                                int pos_dx = imageX + kernelX - 1;

                                //sumR += kernel[matriceY, matriceX] * imgMatrix[imageY-1 + matriceY, imageX -1 + matriceX].Red;
                                //sumG += kernel[matriceY, matriceX] * imgMatrix[imageY -1 + matriceY, imageX -1 + matriceX].Green;
                                //sumB += kernel[matriceY, matriceX] * imgMatrix[imageY -1 + matriceY, imageX -1 + matriceX].Blue;

                                float factor = kernel[kernelY, kernelX];
                                RGB rgb = imgMatrix[pos_dy, pos_dx];


                                newR += (int)(factor * rgb.Red);
                                newG += (int)(factor * rgb.Green);
                                newB += (int)(factor * rgb.Blue);

                            }
                        }

                        //newR = Math.Min(0, Math.Max(255, newR));
                        //newG = Math.Min(0, Math.Max(255, newG));
                        //dnewB = Math.Min(0, Math.Max(255, newB));

                        newMatrix[imageY, imageX] = new RGB(newR, newG, newB);

                    }
                }
                imgMatrix = newMatrix;
            }
            else return;
        }
        /// <summary>
        /// autre testes de convolution
        /// </summary>
        /// <param name="image"></param>
        /// <param name="Noyau"></param>
        /// <returns></returns>
        public static int[,] Convolution(int[,] image, int[,] Noyau)
        {
            int hauteur = image.GetLength(0);
            int largeur = image.GetLength(1);
            int[,] result = new int[hauteur, largeur]; //résultat de la convolution

            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++)
                {
                    result[i, j] = Somme(image, Noyau, i, j);
                }
            }
            return result;
        }
        public static int Somme(int[,] matrice, int[,] noyau, int ligne, int colonne)
        {
            int somme = 0;
            int ligneNoyau = noyau.GetLength(0);
            int colonneNoyau = noyau.GetLength(1);

            for (int i = 0; i < ligneNoyau; i++)
            {
                for (int j = 0; j < colonneNoyau; j++)
                {
                    int x = i + (ligne - ligneNoyau / 2);
                    if (x < 0)
                    {
                        x += matrice.GetLength(0);
                        //x = 0;
                    }
                    if (x >= matrice.GetLength(0))
                    {
                        x -= matrice.GetLength(0);
                        //x = matrice.GetLength(0) - 1;
                    }

                    int y = j + (colonne - colonneNoyau / 2);
                    if (y < 0)
                    {
                        y += matrice.GetLength(1);
                        //y = 0;
                    }
                    if (y >= matrice.GetLength(1))
                    {
                        y -= matrice.GetLength(1);
                        //y = matrice.GetLength(1) - 1;
                    }

                    somme += matrice[x, y] * noyau[i, j];
                }
            }
            return somme;
        }

        #endregion

        #region Innovation
        /// <summary>
        /// applique un filtre flou sur un seul pixel
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>nouveau pixel flouté</returns>
        public static RGB ConvolutionPixel(RGB[,] matrix, int i, int j)
        {
            RGB newPixel = new RGB(0, 0, 0);
            int[,] matBlur = new int[,] { { 1 / 9, 1 / 9, 1 / 9 }, { 1 / 9, 1 / 9, 1 / 9 }, { 1 / 9, 1 / 9, 1 / 9 } };
            double productR = 0;
            double productG = 0;
            double productB = 0;

            if (i > 1 && j > 1 && i < matrix.GetLength(0) - 1 && j < matrix.GetLength(1) - 1)
            {
                for (int k = -1; k <= 1; k++)
                {
                    for (int l = -1; l <= 1; l++)
                    {
                        int red = matrix[i + k, j + l].Red;
                        int green = matrix[i + k, j + l].Green;
                        int blue = matrix[i + k, j + l].Blue;
                        productR += red / 9;
                        productG += green / 9;
                        productB += blue / 9;
                    }
                }
            }
            newPixel = new RGB(productR, productG, productB);
            return newPixel;
        }
        /// <summary>
        /// applique un filtre flou seulement sur un partie de l'image à partir de mots de code
        /// </summary>
        /// <param name="input"></param>
        public void BlurZone(string input)
        {
            RGB[,] newrgb = new RGB[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    newrgb[i, j] = imgMatrix[i, j];
                }
            }
            if (input.Contains("portrait"))
            {
                MyImage portrait = new MyImage(pathFolder + "portrait.bmp");
                int factor = height / portrait.Height;
                portrait.Agrandissement(factor);
                int maringLeft = (width-portrait.Width)/2 ;

                for (int i = 0; i < imgMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < imgMatrix.GetLength(1); j++)
                    {
                        if (i < portrait.Height && j < portrait.Width)
                        {
                            if (portrait.imgMatrix[i, j].Equal(0, 0, 0))
                            {
                                newrgb[i, j] = ConvolutionPixel(imgMatrix, i, j);
                            }
                        }
                        else newrgb[i, j] = ConvolutionPixel(imgMatrix, i, j);
                    }
                }
            }
            if(input.Contains("line"))
            imgMatrix = newrgb;
        }

        #endregion

        #region Création d'image

        /// <summary>
        /// retourne un tableau de pourcentage du nombre de pixels selon les valeurs rouge 
        /// </summary>
        /// <returns></returns>
        public double[] NumberOfRed()
        {
            double[] reds = new double[256];
            int NumberOfPixel = height * width;

            for (int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    int pixelRed = imgMatrix[i, j].Red;
                    reds[pixelRed]++;
                }
            }
            double max = ProgramImage.Max(reds);
            for (int i = 0; i < reds.Length; i++)
            {
                reds[i] = reds[i] / (max);
            }
            return reds;
        }
        /// <summary>
        /// retourne un tableau de pourcentage du nombre de pixels selon les valeurs vert
        /// </summary>
        /// <returns></returns>
        public double[] NumberOfGreen()
        {
            double[] green = new double[256];
            int NumberOfPixel = height * width;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int pixelGreen = imgMatrix[i, j].Green;
                    green[pixelGreen]++;
                }
            }
            double max = ProgramImage.Max(green);
            for (int i = 0; i < green.Length; i++)
            {
                green[i] = green[i] / (max);
            }
            return green;
        }
        /// <summary>
        /// retourne un tableau de pourcentage du nombre de pixels selon les valeurs blue
        /// </summary>
        /// <returns></returns>
        public double[] NumberOfBlue()
        {
            double[] reds = new double[256];
            int NumberOfPixel = height * width;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int pixelRed = imgMatrix[i, j].Blue;
                    reds[pixelRed]++;
                }
            }
            double max = ProgramImage.Max(reds);
            for (int i = 0; i < reds.Length; i++)
            {
                reds[i] = reds[i] / (max);
            }
            return reds;
        }
        /// <summary>
        /// Transforme l'image en histogramme de couleur 
        /// </summary>
        public void Histogram()//input image different than output image(histogram)
        {
            RGB[,] histo = new RGB[256,256];

            double[] reds = NumberOfRed();
            double[] greens = NumberOfGreen();
            double[] blues = NumberOfBlue();
            

            for (int i = 0; i < histo.GetLength(0); i++)
            {
                for (int j = 0; j < histo.GetLength(1); j++)
                { 
                    histo[i, j] = new RGB(new byte[] { 0, 0, 0});
                } 
            }

            for(int j=0; j< histo.GetLength(1); j++)
            {
                for(int i=0; i< histo.GetLength(0) && i< (reds[j]*255); i++)
                {
                    histo[i, j].Red = 255;
                    //histo[i, j] = new RGB ( new byte[] { 0, 0, 255 } );
                }
            }
            for (int j = 0; j < histo.GetLength(1); j++)
            {
                for (int i = 0; i < histo.GetLength(0) && i < (greens[j] * 255); i++)
                {
                    histo[i, j].Green = 255;
                    //histo[i, j] = new RGB ( new byte[] { 0, 0, 255 } );
                }
            }
            for (int j = 0; j < histo.GetLength(1); j++)
            {
                for (int i = 0; i < histo.GetLength(0) && i < (blues[j] * 255); i++)
                {
                    histo[i, j].Blue = 255;
                    //histo[i, j] = new RGB ( new byte[] { 0, 0, 255 } );
                }
            }

            height = histo.GetLength(0);
            width = histo.GetLength(1);
            imgMatrix = histo;
        }
        /// <summary>
        /// Transforme l'image en histogramme des moyennes des couleurs
        /// </summary>
        public void HistogramLuminosity()//input image different than output image(histogram)
        {
            RGB[,] histo = new RGB[256, 256];

            double[] luminosity = new double[256];
            int NumberOfPixel = height * width;

            for (int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    int pixelRed = imgMatrix[i, j].Luminosity();
                    luminosity[pixelRed]++;
                }
            }
            double max = ProgramImage.Max(luminosity);
            for (int i = 0; i < luminosity.Length; i++)
            {
                luminosity[i] = luminosity[i] / (max);
            }

            for (int i = 0; i < histo.GetLength(0); i++)
            {
                for (int j = 0; j < histo.GetLength(1); j++)
                {
                    histo[i, j] = new RGB(new byte[] { 0, 0, 0 });
                }
            }

            for (int j = 0; j < histo.GetLength(1); j++)
            {
                for (int i = 0; i < histo.GetLength(0) && i < (luminosity[j] * 255); i++)
                {
                    
                    histo[i, j] = new RGB ( new byte[] { 255, 255, 255 } );
                }
            }

            height = histo.GetLength(0);
            width = histo.GetLength(1);
            imgMatrix = histo;
        }
        /// <summary>
        /// Dessine un fractale de Mandelbrot
        /// </summary>
        public void Mandelbrot()
        {
            RGB[,] mandel = new RGB[256, 256];
            for (int i = 0; i < mandel.GetLength(0); i++)
            {
                for (int j = 0; j < mandel.GetLength(1); j++)
                {
                    mandel[i, j] = new RGB(new byte[] { 0, 0, 0 });
                }
            }

            double x1 = -2.1;
            double x2 = 0.6;
            double y1 = -1.2;
            double y2 = 1.2;
            double imgX = 270;
            double imgY = 240;
            int iteration = 50;

            double sizeX = imgX / (x2 - x1);
            double sizeY = imgY / (y2 - y1);

            for(int x=0; x<imgX; x++)
            {
                for(int y=0; y<imgY; y++)
                {
                    double cr = x / sizeX + x1;
                    double ci = y/sizeY + y1;
                    double zr = 0;
                    double zi = 0;
                    double i = 0;

                    do
                    {
                        double tmp = zr;
                        zr = zr * zr - zi * zi + cr;
                        zi = 2 * zi * tmp + ci;
                        i++;
                    } while (zr * zr + zi * zi < 4 && i < iteration);

                    if(i == iteration)
                    {
                        mandel[y,x] = new RGB(new byte[] { 114, 255, 89 });
                    }
                }
            }



            height = mandel.GetLength(0);
            width = mandel.GetLength(1);
            imgMatrix = mandel;
        }

        public void HideImage()//and a parameter to choose wich image to hide in
        {
            //the instance is the image to hide
            MyImage hiding = new MyImage(path + "NoWayHome.bmp");
            
            if(hiding.Height > this.height && hiding.Width > this.width)
            {
                for(int i=0; i<this.height; i++)
                {
                    for(int j=0; j<this.width; j++)
                    {


                        
                    }
                }
            }


        }
        //public void CombineImage()


        #endregion

        #region QRCode
        /// <summary>
        /// Remplie les données du QR code dans une image de pixel noir et blanc
        /// </summary>
        /// <param name="dataMatrix"></param>
        public void QRModif(int[,] dataMatrix)
        {

            for (int i = 0; i < dataMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < dataMatrix.GetLength(1); j++)
                {
                    if (dataMatrix[i, j] == 1)
                    {
                        imgMatrix[i, j] = new RGB(0, 0, 0);
                    }
                    else
                    {
                        imgMatrix[i, j] = new RGB(255, 255, 255);
                    }
                }
            }
        }
        /// <summary>
        /// Remplie les données du QR code dans une image de pixel avec des zones de couleur
        /// </summary>
        /// <param name="dataMatrix"></param>
        public void QRModifColor(int[,] dataMatrix)
        {

            for (int i = 0; i < dataMatrix.GetLength(0); i++)
            {
                for (var j = 0; j < dataMatrix.GetLength(1); j++)
                {
                    if (dataMatrix[i, j] == 1)
                    {
                        if (imgMatrix[i, j].Equal(new RGB(0, 255, 0)))
                        {
                            imgMatrix[i, j] = new RGB(0, 155, 0);
                        }
                        else
                        {
                            if (imgMatrix[i, j].Equal(new RGB(255, 0, 0)))
                            {
                                imgMatrix[i, j] = new RGB(0, 0, 155);
                            }
                            else { imgMatrix[i, j] = new RGB(0, 0, 0); }
                        }
                    }
                    else
                    {
                        if (imgMatrix[i, j].Equal(new RGB(0, 255, 0)))
                        {
                            imgMatrix[i, j] = new RGB(100, 255, 100);
                        }
                        else
                        {
                            if (imgMatrix[i, j].Equal(new RGB(255, 0, 0)))
                            {
                                imgMatrix[i, j] = new RGB(100, 100, 255);
                            }
                            else { imgMatrix[i, j] = new RGB(255, 255, 255); }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Applique un masque (i+j)%2 au données du QR code
        /// </summary>
        /// <param name="dataMatrix"></param>
        /// <returns></returns>
        public int[,] Masking(int[,] dataMatrix)
        {
            for (int i = 0; i < dataMatrix.GetLength(0) -1  ; i++)
            {
                for (int j = 0; j < dataMatrix.GetLength(1) -1 ; j++)
                {
                    if (imgMatrix[i+1, j + 1].Equal(0, 255, 0))
                    {
                        if ((i + 1 + j + 1) % 2 == 0)
                        {
                            //dataMatrix[i+1, j+1] = 2;
                            //QRCode.printMatrix(dataMatrix);

                            dataMatrix[i + 1, j + 1] = ToggleBit(dataMatrix[i + 1, j + 1]);
                        }
                    }
                }
            }
            return dataMatrix;
        }
        /// <summary>
        /// Inverse les valeurs binaire
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToggleBit(int value)
        {

            if (value == 0) return 1;
            if (value == 1) return 0;

            return -1;

        }

        #endregion

    }
}