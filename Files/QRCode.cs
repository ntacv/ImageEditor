using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA2S4
{
    internal class QRCode
    {


        #region Properties
        string path;
        string pathOutput;
        int[] mode;
        int correction;
        int maxByte;
        string inputText;

        int[] parameters;//0 11101 1111000100 mask and error parameters
        int[] supply = new int[] { 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 };//to add at the end of the data if there is too much space

        RGB[,] img;
        int[,] data;
        int[] textByte;
        int[] txt;



        int[] motif1 = new int[49];
        //int[] motif1 = strToIntArr(motif1str, 49);
        //1111111 1000001 1011101 1011101 1011101 1000001 1111111

        public int[] Mode
        {
            get { return mode; }

        }
        public int Correction
        {
            get { return correction; }
        }
        #endregion

        public QRCode(string inputText, string path)
        {
            this.correction = 7;
            this.path = path;
            this.pathOutput = path;

            if (!ProgramImage.Alphanumeric(inputText))
            {
                return;
            }
            else
            {
                this.inputText = inputText.ToUpper();
                this.correction = 7;//percentage
                parameters = new int[15] { 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0 };
                //0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0
                //1,1,1,0,1,1,1,1,1,0,0,0,1,0,0

                string motif1str = "1111111100000110111011011101101110110000011111111";
                //motif1 = strToIntArr(motif1str);
                
                //textByte = RandomData();


                if (inputText.Length > 47) return;
                if(inputText.Length < 25){
                    mode = new int[] {0,0,1,0};
                    path += "qrCode1Green.bmp";
                    maxByte = 19;//26-7 bytes
                    //Hello world : 10(data) + 9(supply) + 7(EC) = 26 bytes
                }
                else
                {
                    mode = new int[] {0,0,1,1};
                    path += "qrCode2Green.bmp";
                    maxByte = 34;//+10 EC bytes
                }

                MyImage qr = new MyImage(path);
                
                img = qr.ImgMatrix;
                this.data = new int[img.GetLength(0),img.GetLength(1)];
                DataFormating();
                FileToData();
                Parameters();
                WriteText();
                data = qr.Masking(data);

                qr.QRModif(data);
                qr.Agrandissement(30);
                qr.From_Image_To_File(pathOutput+"qrOutput.bmp");
            }



        }

        public void FileToData()
        {
            int index = 0;


            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    index++;
                    if (img[i, j].Equal(0, 0, 0)) //Black
                    {
                        data[i, j] = 1;
                    }
                    else data[i, j] = 0;
                }
            }

        }

        public static bool isAlpha(string str)
        {
            if (str == null || str.Length == 0) return false;
            else {
                for (int i = 0; i < str.Length; i++) {
                    //if (str[i])
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        public static int[] strToIntArr(string value)
        {
            int size = value.Length;
            int[] arr = new int[size];

            if (value.Length <= size)
            {
                for (int i = 0; i < size; i++)
                {
                    int valint = value[i] - '0'; 
                    arr[i] = valint;
                }
            }
            
            return arr;
        }
        public int[] RandomData()
        {
            textByte = new int[500];
            Random rnd = new Random();
            int number = rnd.Next(1, 10);
            for (int i = 0; i < textByte.Length; i++)
            {
                if (rnd.Next(0, 2) == 1)
                {
                    textByte[i] = 1;
                }
                else textByte[i] = 0;
            }
            return textByte;
        }
        
        public void Parameters()
        {

            int column = 8 + 1;
            int row = data.GetLength(1)-1 - (8+2);//13
            int indexParam = 0;

            for(int i = 0; i < data.GetLength(0); i++)
            {
                if (img[i, column].Equal(255, 0, 0) && indexParam < parameters.Length)
                {
                    data[i, column] = parameters[indexParam];
                    indexParam++;
                }
            }
            indexParam = 0;
            for (int i = 0; i < data.GetLength(1); i++)
            {
                if (img[row, i].Equal(255, 0, 0) && indexParam<=7)
                {
                    data[row, i] = parameters[indexParam];
                    indexParam++;
                }
            }
            indexParam = 7;
            for(int i = 10; i < data.GetLength(1); i++)
            {
                if(img[row, i].Equal(255, 0, 0) && indexParam < parameters.Length)
                {
                    data[row, i] = parameters[indexParam];
                    indexParam++;
                }
            }

            /*
            for(int i=0; i<7; i++)
            {
                data[i, 8+1] = parameters[i]; //partant du bas
                if(i<6) data[data.GetLength(0) - 9, i] = parameters[i];
            }

            for(int j=0; j<7; j++) //13-20
            {
                data[data.GetLength(0) - 9, j + data.GetLength(1) -3 -7] = parameters[j];
            }

            data[data.GetLength(0) - 9, 7] = parameters[6];
            data[data.GetLength(0) - 9, 8] = parameters[7];
            data[data.GetLength(0) - 8, 8] = parameters[8];

            for(int k=0; k<6; k++)
            {
                data[data.GetLength(0) - 6 + k, 8] = parameters[k + 9];
            }
            */

        }

        public void DataFormating()
        {

            int[] numberChar = ProgramImage.intToBinary(inputText.Length, 9);

            textByte = ProgramImage.alphaToInt(inputText);
            textByte = ProgramImage.intArrToBinary11(textByte);

            //adding mode bytes and length bytes to the beginning of the data array
            textByte = ProgramImage.intArrFusion(numberChar, textByte);
            textByte = ProgramImage.intArrFusion(mode, textByte);
            
            //adding 0s to the end of the data array to complete bytes
            if (textByte.Length < maxByte * 8)
            {
                for(int i=4; i >0; i--)
                {
                    if(textByte.Length <= (maxByte * 8 - i))
                    {
                        textByte = ProgramImage.intArrFusion(textByte, new int[i]);
                        break;
                    }
                }
                //textByte = Program.intArrFusion(textByte, new int[] { 0, 0, 0, 0 });

                int reminderTmp = textByte.Length % 8;//between 0 and 7
                for (int i = 0; i < 7; i++)
                {
                    if (reminderTmp == i)
                    {
                        textByte = ProgramImage.intArrFusion(textByte, new int[8-i]);
                        break;
                    }
                }
            }
            else
            {

            }
            /*
            int reminder = textByte.Length % 8;
            if (reminder < 8)
            {
                int[] textByteTmp = new int[textByte.Length + (8 - reminder)];
                for (int i = 0; i < textByte.Length; i++)
                {
                    textByteTmp[i] = textByte[i];
                }
                for (int i = 0; i <= (8 - reminder); i++)
                {
                    textByteTmp[textByteTmp.Length - 1 - i] = 0;
                }
                textByte = textByteTmp;
            }*/
            
            int reminderByte = (maxByte * 8 - textByte.Length) /8;
            while(reminderByte > 0)
            {
                if (reminderByte == 1)
                {
                    textByte = ProgramImage.intArrFusion(textByte, ProgramImage.intToBinary(236, 8));
                    break;
                }
                // reminder >=2
                textByte = ProgramImage.intArrFusion(textByte, ProgramImage.intToBinary(236, 8));
                textByte = ProgramImage.intArrFusion(textByte, ProgramImage.intToBinary(17, 8));
                reminderByte = (maxByte * 8 - textByte.Length) / 8;
            }
            
            int[] EC = ProgramImage.ECbits(textByte);
            int[] ECBinary = ProgramImage._intArrToBinary8(EC);
            for (int i = 0; i < ECBinary.Length; i++)
            {
                //Console.Write(ECBinary[i]+" ");
            }
            Console.WriteLine();
            //printIntArray(ECBinary);

            textByte = ProgramImage.intArrFusion(textByte, ECBinary);
            
            //printIntArray(textByte);

        }

        public void WriteText()
        {
            //data order : mode(4)length(9)text(8* )end(4)more(0-4)completers(8-16)EC(7*8)
            //timing pattern vertical must be jumped
            int indexText = 0;

            //redo for the version2
            for (int indexJ = 0; indexJ < data.GetLength(1)-4; indexJ += 2)
            {
                for (int i = 0; i < data.GetLength(0); i++)//from bottom
                {
                    for (int j = data.GetLength(1) - 3 - indexJ; j > data.GetLength(1) - 5 - indexJ; j--)
                    {
                        //data[i, j] = 2;
                        //printMatrix();
                        
                        if (img[i, j].Equal(0, 255, 0))
                        {
                            if (indexText < textByte.Length)
                            {
                                data[i, j] = textByte[indexText];
                                indexText++;
                            }
                        }
                        
                    }
                }
                indexJ += 2;
                for (int i = data.GetLength(0)-1; i >= 0; i--)//from top
                {
                    for (int j = data.GetLength(1) - 3 - indexJ; j > data.GetLength(1) - 5 - indexJ; j--)
                    {
                        //data[i, j] = 2;
                        //printMatrix();

                        if (img[i, j].Equal(0, 255, 0))
                        {

                            if (indexText < textByte.Length)
                            {
                                data[i, j] = textByte[indexText];
                                indexText++;
                            }
                        }
                    }
                }
                
            }
        }


        public void printMatrix()
        {
            Console.Clear();
            for(int i = 0; i < data.GetLength(0); i++)
            {
                for(int j=0; j<data.GetLength(1); j++)
                {
                    Console.Write(data[i, j].ToString());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Thread.Sleep(100);
        }
        public static void printMatrix(int[,] data)
        {
            Console.Clear();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    Console.Write(data[i, j].ToString());
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Thread.Sleep(100);
        }
        public void printArray(int[] arr)
        {
            //Console.Clear();
            for (int i = 0; i < arr.Length; i++)
            {
                
                    Console.Write(arr[i].ToString() + ", ");
                
            }
            Console.WriteLine();
            Thread.Sleep(100);
        }
        public static void printIntArray(int[] textByte)
        {
            for(int i=0; i<textByte.Length/8; i++)
            {
                int[] bytetmp = textByte[(8*i)..(8*i+7)];

                Console.WriteLine(MyImage.Convertir_Binary_To_Double(bytetmp));

            }

        }

    }
}
