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
    public class MyImage
    {

        #region Properties
        byte[] voidByte = new byte[] {0, 0, 0, 0};

        string path;
        byte[] data;
        byte[] imgData;
        //RGB[] imgPixels;
        RGB[,] imgMatrix;

        byte[] format;//66 77 = BMP
        int fileSize; //imgSize + headerSize
        int headerSize;//54
        int imgSize;//width * height * 3colors
        int width;//20
        int height;//20
        int bitpercolor;//8, 24 bit/pixels

        public byte[] Format { get { return format; } }
        public int FileSize { get { return fileSize; } }
        public int Width { get { return width; } }
        public int Height { get { return height;} }
        public int HeaderSize { get { return headerSize;} }
        public int ImageSize { get { return imgSize; } }
        public byte[] ImgData { get { return imgData; } }
        public RGB[,] ImgMatrix { get { return imgMatrix; } }
        

        #endregion


        public MyImage(string path)
        {
            this.path = path;
            this.data = File.ReadAllBytes(path);
            byte[] formatBytes = new byte[2] { 66, 77 };

            if (formatBytes[0] == data[0] && formatBytes[1] == data[1])
            {
                this.format = formatBytes;
            }
            this.fileSize = ProgramImage.ReadBytes(data[2..6]);
            this.imgSize = ProgramImage.ReadBytes(data[34..38]);
            this.width = ProgramImage.ReadBytes(data[18..22]);
            this.height = ProgramImage.ReadBytes(data[22..26]);
            this.headerSize = ProgramImage.ReadBytes(data[10..14]);

            this.bitpercolor = ProgramImage.ReadBytes(data[28..30])/3;

            this.imgData = data[headerSize..(data.Length)];

            
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

            /*
            this.imgMatrix = new RGB[width, height];
            int x = 0;//along height, 20
            int y = 0;//along width, 24
            int lenData = imgData.Length;

            
            for(int i=0; i<lenData/3  ; i++)
            {

                byte[] pixelData = new byte[3] { imgData[i * 3+2 ], imgData[i * 3+1], imgData[i * 3] };

                RGB pixel = new RGB(pixelData);


                this.imgMatrix[(height-1-x), y] = pixel;


                if (y < width) y++;//24
                if (x < height && y == width) { //19 && 20
                    x++;//20
                    y = 0;//0
                }
            }*/

        }

        public void From_Image_To_File(string fileName)
        {

            fileName = "../../../Files/Img/Output.bmp";

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

                Console.WriteLine(Data());


            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

        }

        public static void OpenImage(string fileName)
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

        #region Functions
        

        public override string ToString()
        {
            string str = "";
            for(int i=headerSize; i<this.data.Length; i+=3)
            {
                if ((i % width) == 0) str += "\n";
                if (data[i] != 0) str += "1";
                else str+=data[i];
            }
            return str;
        }

        public string Data()
        {
            string str = "Image data: \n";

            if (66 == data[0] && 77 == data[1] )
            //36609 == Program.ReadBytes(new byte[] { data[0], data[1] })
            {
                str += format+"\n";
            }
            str+= "Size: " + ProgramImage.ShortSize(fileSize)+"\n";
            str+= "Img size: " + ProgramImage.ShortSize(imgSize)+"\n";
            str+= "Header size: " + ProgramImage.ShortSize(headerSize)+"\n";
            str+= "Width: " + width.ToString()+" pixels\n";
            str+= "Heigth: " + height.ToString()+" pixels\n";
            str += "bit/color: " + bitpercolor.ToString() + "\n";

            return str;
        }

        public string ImageToString()
        {
            if (data == null) return " none ";
            string str = "";

            for (int i = 0; i < data.Length; i++)
            {
                if (i == 14) str+="\n";
                if (i == 54) str += "\n";
                if (i % 60 == 0) str += "\n";
                str += ProgramImage.AlignString(data[i].ToString(), 3) + " ";
            }

            return str;
        }
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
        public string HeaderToString()
        {
            if (data == null) return " none ";
            string str = "";

            for (int i = 0; i < headerSize; i++)
            {
                if (i == 14) str += "\n";
                if (i == 54) str += "\n";
                str += data[i].ToString() + " ";
            }

            return str;
        }
        public string AllBytes()
        {
            if (data == null) return " none ";
            string str = "Image Header: ";

            for (int i = 0; i < data.Length; i++)
            {
                if (i == 14) str += "\n";
                if (i == 54) str += "\nImage Data: \n";
                if (i % 60 == 0) str += "\n";
                str += data[i].ToString() + " ";
            }

            return str;
        }
        public string AllBytesAlign()
        {
            if (data == null) return " none ";
            string str = "Image Header: ";

            for (int i = 0; i < data.Length; i++)
            {
                if (i == 14) str += "\n";
                if (i == 54) str += "\nImage Data: \n";
                if (i % 60 == 0) str += "\n";
                str += ProgramImage.AlignString(data[i].ToString(), 3) + " ";
            }

            return str;
        }

        
        /// <summary>
        /// Convert 
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

        public void Miroir()
        {

            RGB[,] tempMatrix = new RGB[height, width];


            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tempMatrix[i, width-1-j] =  imgMatrix[i, j];
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    imgMatrix[i,j] = tempMatrix[i, j];
                }
            }


        }

        public void RotationHoraire(int deg)
        {
            
            if (deg == 0) return;
            if (deg < 0) return;

            int newWidth = 0 ;
            int newHeight = 0;

            RGB[,] tempMatrix = null;
            int temp = 0;

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
                    break;

                case 180:

                    tempMatrix = new RGB[height, width];

                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            tempMatrix[height -1 -i, width - 1 - j] = imgMatrix[i, j];

                        }

                    }
                    break;

                case 270:

                    tempMatrix = new RGB[height, width];

                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            tempMatrix[ height - 1- i, j] = imgMatrix[i, j];

                        }

                    }
                    break;

            }



            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    imgMatrix[i, j] = tempMatrix[i, j];
                }
            }
        }

        public void Rotation (double deg)
        {
            //Calcul l'hypoténuse et recadre l'image a la taille max avant de la rotate

            double radian = ProgramImage.ToRadian(deg);

            RGB[,] tempMatrix = new RGB[height, width];

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

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    imgMatrix[i, j] = tempMatrix[i, j];
                }
            }

            /*
            PI = 3.1415
            c = cos(angle_degre/180*PI)             //Précalcul du cosinus 
            s = sin(angle_degre / 180 * PI)             // Précalcul du sinus 
            Pour tout pixel j 0 ET x0 ET y<hauteur Alors
                   destination(i, j) = source(x, y)
                Sinon
                    destination(i, j) = couleur fond
               Fin
            Fin
            */


        }
        
        public void RotationShear(int deg)
        {
            /*
            RGB[,] tempMatrix = new RGB[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tempMatrix[i, j] = imgMatrix[i,j];
                }
            }

            //                  [ cos(A) sin(A)]
            //[X Y] =  [x y] *  [-sin(A) cos(A)]
            double[,] matRotation = new double[2, 2] {
                { Math.Cos(radian),Math.Sin(radian)},
                { -Math.Sin(radian), Math.Cos(radian)}};


            int center_x = width / 2;
            int center_y = height / 2;

            //int xp = (int)((x - center_x) * Math.Cos(radian) - (y - center_y) * Math.Sin(radian) + center_x) ;
            //int yp = (int)((x - center_x) * Math.Sin(radian) + (y - center_y) * Math.Cos(radian) + center_y) ;
            int xp = 0; int yp = 0;

            for (int x = 0; x < height; ++x)
            {
                for (int y = 0; y < width; ++y)
                {
                    xp = (int)((x - center_x) * Math.Cos(radian) - (y - center_y) * Math.Sin(radian) + center_x);
                    yp = (int)((x - center_x) * Math.Sin(radian) + (y - center_y) * Math.Cos(radian) + center_y);
                    if (xp < tempMatrix.GetLength(0) && yp < tempMatrix.GetLength(1) && xp >= 0 && yp >= 0)
                    {
                        tempMatrix[xp, yp] = imgMatrix[x, y];
                    }
                }
            }

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    imgMatrix[i, j] = tempMatrix[i, j];
                }
            }
            */
        }

        public void Cisaillement(int deg, char axe)
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
                /*
                for (int i = 0; i < height*factorInt; i++)//row
                {
                    for (int j = 0; j < width; j++)//column
                    {

                        for(int l=0; l < factorInt; l++)
                        {
                            newMatrix[factorInt * i + ,factorInt * j + l] = imgMatrix[i, j];
                        }
                    }
                }*/
                
                imgMatrix = newMatrix;

            }

        }

        public void Retrecir(int coef)
        {
            
            RGB[,] newMatrix = new RGB[imgMatrix.GetLength(0)/coef, imgMatrix.GetLength(1)/coef];
            for(int i = 0; i < imgMatrix.GetLength(0) / coef; i++)
            {
                for( int j = 0; j < imgMatrix.GetLength(1) / coef; j++)
                {
                    newMatrix[i, j] = imgMatrix[i*coef, j*coef];
                }
            }
            //change the size of the image in the header
            this.height = imgMatrix.GetLength(0) / coef;
            this.width = imgMatrix.GetLength(1) / coef;
            imgMatrix = newMatrix;
        }

        #endregion

        #region Convolution

        public void ConvolutionTry( int[,] mat33)
        {
            if (mat33 != null && mat33.GetLength(0) == mat33.GetLength(1))
            {
                RGB[,] newMatrix = new RGB[height, width];

                int kernelMiddleY = mat33.GetLength(0)/2;
                int kernelMiddleX = mat33.GetLength(1)/2;

                for(int imageY= 1; imageY < imgMatrix.GetLength(0) -1; imageY++)
                {
                    for(int imageX = 1; imageX < imgMatrix.GetLength(1) -1; imageX++)
                    {
                        int newR = 0;
                        int newG = 0;
                        int newB = 0;

                        for (int matriceY = 0; matriceY < mat33.GetLength(0); matriceY++) 
                        {
                            for (int matriceX = 0; matriceX < mat33.GetLength(1); matriceX++)
                            {
                                int pos_dy = imageY + matriceY;
                                int pos_dx = imageX + matriceX;

                                pos_dx -= kernelMiddleX;
                                pos_dy -= kernelMiddleY;

                                //sumR += mat33[matriceY, matriceX] * imgMatrix[imageY-1 + matriceY, imageX -1 + matriceX].Red;
                                //sumG += mat33[matriceY, matriceX] * imgMatrix[imageY -1 + matriceY, imageX -1 + matriceX].Green;
                                //sumB += mat33[matriceY, matriceX] * imgMatrix[imageY -1 + matriceY, imageX -1 + matriceX].Blue;
                                
                                float factor = mat33[matriceY, matriceX];
                                RGB rgb = imgMatrix[pos_dy, pos_dx];


                                newR += (int)(factor*rgb.Red);
                                newG += (int)(factor*rgb.Green);
                                newB += (int)(factor*rgb.Blue);

                            } 
                        }

                        //newR = Math.Min(0, Math.Max(255, newR));
                        //newG = Math.Min(0, Math.Max(255, newG));
                        //dnewB = Math.Min(0, Math.Max(255, newB));

                        newMatrix[imageY, imageX] = new RGB(new byte[] { (byte)(newR), (byte)(newG), (byte)(newB) });

                    }
                }

                imgMatrix = newMatrix;

            }
            else return;

            /*
            for (int filterY = 0; filterY < filter.Size; filterY++) {
                int pk = (filterY + x - offset <= 0) ? 0 :
                    (filterY + x - offset >= map.Width - 1) ? map.Width - 1 : filterY + x - offset;
                for (int filterX = 0; filterX < filter.Size; filterX++) {
                    int pl = (filterX + y - offset <= 0) ? 0 :
                        (filterX + y - offset >= map.Height - 1) ? map.Height - 1 : filterX + y - offset;

                    colorMap[filterY, filterX] = map.GetPixel(pk, pl);
                }
            }

            result.SetPixel(x, y, colorMap * filter);
            */

        }

        public void Blur()
        {

            int[,] matBlur = new int[3, 3] { { 1 / 9, 1 / 9, 1 / 9 }, { 1 / 9, 1 / 9, 1 / 9 }, { 1 / 9, 1 / 9, 1 / 9 } };

            //Convolution(matBlur);
        }
        public void Indicatrice()
        {

            int[,] matBlur = new int[3, 3] { { 0, 0, 0 }, { 0, 1, 0}, { 0, 0, 0} };

            //Convolution(matBlur);
        }
        public void Contours()
        {
            int[,] matContours = new int[3, 3] { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };

            imgMatrix = Produit_Matrice_Convolution(matContours, true);
        }

        public void BlurKev()
        {
            int[,] matBlur = new int[3, 3] { { 1 / 9, 1 / 9, 1 / 9 }, { 1 / 9, 1 / 9, 1 / 9 }, { 1 / 9, 1 / 9, 1 / 9 } }; 
            
            int[,] mat1 = new int[3, 3] { { 1, 1 ,1 }, { 1, 1, 1 }, { 1 , 1 , 1 } };

            imgMatrix = Produit_Matrice_Convolution(mat1, true);

            //ConvolutionKev(matBlur);

        }

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

        public RGB[,] Produit_Matrice_Convolution(int[,] kernel, bool flou)
        {
            int hauteur = imgMatrix.GetLength(0);
            int largeur = imgMatrix.GetLength(1);   // on créer des variables pour la hauteur et 
            RGB[,] output = new RGB[hauteur, largeur];    //la matrice de sortie est de la même taille que celle d'entrée
            for (int i = 0; i < hauteur; i++)
            {
                for (int j = 0; j < largeur; j++) //on parcours les emplacements, auquelles seront affectés les valeurs à output
                {
                    int sommeR = 0;  //on applique le kernel pour chaque position, on réinitialise donc la somme à chaque fois
                    int sommeG = 0;
                    int sommeB = 0; //on applique kernel pour chaque couleur

                    int positionKerneli = 0;
                    int positionKernelj = 0;
                    int debutK = 0;
                    int finK = 0;
                    int decalage = 0;
                    if (kernel.GetLength(0) == 3)   //selon la taille du kernel, le milieu ne sera pas identique
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
                        for (int j2 = debutK; j2 <= finK; j2++)   //on parcours la matrice autour de l'emplacement, auquel on applique la matrice Kernel
                        {
                            int position_i = i + i2;
                            int position_j = j + j2;
                            if (position_i >= 0 && position_j >= 0 && position_i < hauteur && position_j < largeur)
                            {
                                sommeR += kernel[i2 + decalage, j2 + decalage] * imgMatrix[position_i, position_j].Red;
                                sommeG += kernel[i2 + decalage, j2 + decalage] * imgMatrix[position_i, position_j].Green;
                                sommeB += kernel[i2 + decalage, j2 + decalage] * imgMatrix[position_i, position_j].Blue;
                            }
                        }
                    }

                    if (i == 0 && i == hauteur && j == largeur || j == 0)    //cas sur les bords qu'on ne peut pas traiter avec kernel
                    {
                        sommeR = 0;
                        sommeG = 0;
                        sommeB = 0;
                    }
                            if (flou)
                    {
                        sommeR /= 9;
                        sommeG /= 9;
                        sommeB /= 9;
                    }

                    if (sommeR < 0) sommeR = 1;
                    if (sommeG < 0) sommeG = 1;
                    if (sommeB < 0) sommeB = 1;
                    if (sommeR > 255) sommeR = 254;
                    if (sommeG > 255) sommeG = 254;
                    if (sommeB > 255) sommeB = 254;
                    output[i, j] = new RGB((byte)sommeR, (byte)sommeG, (byte)sommeB);

                }
            }
            return output;
        }

#endregion

        #region Création d'image

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

                        string Rnew = "";
                        string Gnew = "";
                        string Bnew = "";

                        byte R1 = imgMatrix[i,j].Red;
                        byte G1 = imgMatrix[i,j].Green;
                        byte B1 = imgMatrix[i,j].Blue;

                        
                    }
                }
            }


        }
        //public void CombineImage()


        #endregion

        #region QRCode

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

        public static int ToggleBit(int value)
        {

            if (value == 0) return 1;
            if (value == 1) return 0;

            return -1;

        }

        #endregion

    }
}