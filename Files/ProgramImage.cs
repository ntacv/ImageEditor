using System;
using System.IO;
using System.Threading;
using System.Media;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Text;
using ReedSolomon;

namespace ProjectA2S4
{
    public class ProgramImage
    {
        
        //static void (string[] args)
        static void Start()
        {
            string path = "../../../Files/";

            //MyImage nwh = new MyImage(path + "NoWayHome.bmp");
            
            //nwh.From_Image_To_File("Output.bmp", true);

            string txt = "hello world";
            
            //QRCode link = new QRCode(txt);
            
            
            /* useful tips
            var array = new int[] { 1, 2, 3, 4, 5 };
            var slice1 = array[2..4];    // array[new Range(2, new Index(3, fromEnd: true))]
            var slice2 = array[..^3];     // array[Range.EndAt(new Index(3, fromEnd: true))]
            var slice3 = array[2..];      // array[Range.StartAt(2)]
            var slice4 = array[..];       // array[Range.All]
            */
        }

        #region Functions
        /// <summary>
        /// Convert Little Endian to decimal
        /// </summary>
        /// <param name="data">bytes array in little endian</param>
        /// <returns>decimal value</returns>
        public static int ReadBytes(byte[] data)
        {
            int sum = 0;

            for (int i = 0; i < data.Length; i++)
            {
                sum += data[i] * Convert.ToInt32(Math.Pow(256,i));
            }

            return sum;
        }
        /// <summary>
        /// ajoute des espaces devant un string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length">le nombre de char après l'ajout d'espace</param>
        /// <returns></returns>
        public static string AlignString(string str, int length)
        {
            if (str != null)
            {
                if (str.Length < length)
                {
                    str = String.Concat(Enumerable.Repeat(" ", length - str.Length)) + str;
                }
            }
            else str = "";
            return str;
        }
        /// <summary>
        /// permet d'afficher un tableau dans la console
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string ArrayToString(int[] arr)
        {
            if (arr == null) return "";
            string str = "";
            for (int i = 0; i < arr.Length; i++) str += arr[i] + " ";
            return str;
        }
        /// <summary>
        /// tableau de byte vers string pour affichage console
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string ByteToString(byte[] arr)
        {
            if (arr == null) return "";
            string str = "";
            for (int i = 0; i < arr.Length; i++) str += arr[i] + " ";
            return str;
        }
        /// <summary>
        /// multiplication matricielle à valeures double
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns>la matrice produit</returns>
        public static double[,] matrixMult(double[,] mat1, double[,] mat2)
        {
            if(mat1 == null || mat2 == null || mat1.GetLength(0)!=mat2.GetLength(1)) return null;

            double[,] result = new double[mat1.GetLength(0),mat2.GetLength(1)];

            for(int i=0; i<mat1.GetLength(0); i++)
            {
                for(int j=0; j<mat2.GetLength(0); j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < mat1.GetLength(1); k++)
                    {
                        result[i, j] += mat1[i, k] * mat2[k, j];
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// convertion d'un angle, de degrée à radian
        /// </summary>
        /// <param name="degre"></param>
        /// <returns></returns>
        public static double ToRadian(double degre)
        {
            double radian = 0;

            if (degre > 0)
            {

                radian = degre / 180 * Math.PI;

            }
            return radian;
        }
        /// <summary>
        /// simplifie l'écriture d'une taille de fichier en octet
        /// </summary>
        /// <param name="size">taille du fichier</param>
        /// <returns></returns>
        public static string ShortSize(int size)
        {
            string str = "";
            if (size > 0)
            {

                if (size > 1000000)
                {
                    str = size.ToString()[0..^6] + " Mb";
                    return str;
                }
                if (size > 2000)
                {
                    str = size.ToString()[0..^3] + " kb";
                    return str;
                }
                if (size > 1)
                {
                    str = size.ToString() + " bytes";
                    return str;
                }
                if (size == 1)
                {
                    str = "1 byte";
                    return str;
                }
                str = size.ToString()+ " bytes ";
                
                
            }
            return str;
        }
        /// <summary>
        /// détermine le maximum d'un tableau de double
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>
        public static double Max(double[] tab)
        {
            double max = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                max = Math.Max(max, tab[i]);
            }
            return max;
        }

        /// <summary>
        /// return true si tous les char sont alphanumériques
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static bool Alphanumeric(string txt)
        {
            //bool fullAlph = true;
            /*
            //@"^[!#$%&'()*+,-./:;?@[\]^_]*$"
            */
            txt = txt.ToUpper();
            Regex rg = new Regex(@"^[$%*+-./:A-Z0-9\s,]*$");//@"^[$%*+-./:A-Z0-9\s,]*$");
            /*if (rg.IsMatch(txt))
            {
                Regex rg2 = new Regex(@"^[A-Z0-9\s,]*$");
                if (rg2.IsMatch(txt))
                {
                    return true;
                }
            }*/
            return rg.IsMatch(txt);
            

        }

        /// <summary>
        /// Code Alphanumerique
        /// 0 -> 0 … 9->9 
        /// A -> 10 … Z ->35 
        /// Espace -> 36 
        /// $ -> 37, % -> 38, *-> 39, + ->40, - -> 41, . -> 42, / -> 43, : -> 44
        /// </summary>
        /// <param name="str"></param>
        /// <returns>les valeurs alphanumériques d'un string</returns>
        public static int[] alphaToInt(string str)
        {
            str = str.ToUpper();
            int[] result = new int[str.Length];
            
            for(int i = 0; i < str.Length; i++)
            {
                if (Alphanumeric(""+str[i]))
                {
                    if (str[i] - '0' < 10 && str[i] - '0' >= 0)
                    {
                        result[i] = str[i] - '0';
                    }
                    if (str[i] - 'A' <= 35 && str[i] - 'A' >= 0)
                    {
                        result[i] = str[i] - 'A' + 10;
                    }
                    if (str[i] == ' ') result[i] = 36;
                    switch (str[i])
                    {
                        case '$':
                            result[i] = 37;
                            break;
                        case '%':
                            result[i] = 38;
                            break;
                        case '*':
                            result[i] = 39;
                            break;
                        case '+':
                            result[i] = 40;
                            break;
                        case '-':
                            result[i] = 41;
                            break;
                        case '.':
                            result[i] = 42;
                            break;
                        case '/':
                            result[i] = 43;
                            break;
                        case ':':
                            result[i] = 44;
                            break;
                    }
                }
            }

            return result;
        }
        /// <summary>
        /// convertion valeur numérique vers 11 bits
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] intArrToBinary11(int[] input)
        {
            int[] result;
            //int indexBinary = 0;
            int[] binaries;
            int Length = 0;

            if(input.Length % 2 == 0)
            {
                Length = input.Length / 2;
                binaries = new int[Length*11];
            }
            else
            {
                Length = input.Length / 2 + 1;
                binaries = new int[Length*11 -11+6];
            }

            result = new int[Length];

            for (int i = 0; i < input.Length/2; i++)
            {
                //HE = 45 ^ 1 * 17 + 45 ^ 0 * 14 = 779-> 01100001011
                result[i] = input[2*i] * 45 + input[2*i+1];
                
            }
            if(input.Length % 2 == 1)
            {
                result[result.Length - 1] = input[input.Length - 1];
            }

            for (int i = 0; i < input.Length/2; i++)
            {
                string binaryInt = Convert.ToString(result[i], 2);
                while (binaryInt.Length < 11)
                {
                    binaryInt = "0" + binaryInt;
                }
                for(int j=0; j<11; j++)
                {
                    binaries[11*i+j] = Convert.ToInt32(binaryInt[j] - 48);
                }
            }
            if(input.Length % 2 == 1)
            {
                string binaryInt = Convert.ToString(result[result.Length-1], 2);
                while (binaryInt.Length < 6)
                {
                    binaryInt = "0" + binaryInt;
                }
                for (int j = 0; j < 6; j++)
                {
                    binaries[(result.Length-1)*11 + j] = Convert.ToInt32(binaryInt[j] - 48);
                }
            }

            return binaries;
        }
        /// <summary>
        /// convertion valeur numérique vers 8 bits
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] _intArrToBinary8(int[] textByte)
        {
            int[] binaries = new int[textByte.Length*8];
            for (int i = 0; i < textByte.Length; i++)
            {
                //int[] bytetmp = textByte[(8 * i)..(8 * i + 7)];
                //binaries[i] = (int)(MyImage.Convertir_Binary_To_Double(bytetmp));

                for(int j = 0; j < 8; j++)
                {
                    binaries[8 * i + j] = intToBinary(textByte[i], 8)[j];
                }

            }
            return binaries;
        }
        /// <summary>
        /// convertion valeur binaire 8bits vers valeur numérique
        /// </summary>
        /// <param name="binaries"></param>
        /// <returns></returns>
        public static int[] binary8ToInt(int[] binaries)
        {
            int[] textbyte = new int[binaries.Length / 8];
            for (int i = 0; i < textbyte.Length; i++)
            {
                int[] bytetmp = binaries[(8 * i)..(8 * i + 8)];
                Console.WriteLine(MyImage.Convertir_Binary_To_Double(bytetmp));
                textbyte[i] = (int)(MyImage.Convertir_Binary_To_Double(bytetmp));

            }
            return textbyte;
        }
        /// <summary>
        /// convertion valeur numérique vers binaire avec des 0s devant selon la taille demandée
        /// </summary>
        /// <param name="input"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static int[] intToBinary(int input, int size)
        {
            int[] result = new int[size];
            string binaryInt = Convert.ToString(input, 2);
            while (binaryInt.Length < size)
            {
                binaryInt = "0" + binaryInt;
            }
            for(int i = 0; i < size; i++)
            {
                result[i] = Convert.ToInt32(binaryInt[i])-48;
            }
            return result;
        }
        /// <summary>
        /// convertit un string de 0 et 1 en un tableau de int
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static int[] strToInt(string txt)
        {
            int[] result = new int[txt.Length];
            for(int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToInt32(txt[i])-48;
            }
            return result;
        }
        public static double strInputToDouble(string input)
        {
            double result = 0;
            if (input == null) return result;
            if (input.Length > 0)
            {
                result = Convert.ToDouble(input);
            }
            return result;
        }
        /// <summary>
        /// combine deux int array dans l'ordre des parametres
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public static int[] intArrFusion(int[] arr1, int[] arr2)
        {
            int[] result = new int[arr1.Length+arr2.Length];
            for(int j = 0; j < arr1.Length; j++)
            {
                result[j] = arr1[j];
            }
            for(int k = 0; k < arr2.Length; k++)
            {
                result[arr1.Length+k] = arr2[k];
            }
            return result;
        }
        /// <summary>
        /// conversion tableau byte vers tableau int
        /// </summary>
        /// <param name="byteInput"></param>
        /// <returns></returns>
        public static int[] byteToInt(byte[] byteInput)
        {
            //not all 01s
            int[] result = new int[byteInput.Length];
            for(int i=0; i < result.Length; i++)
            {
                result[i] = Convert.ToInt32(byteInput[i]);
            }

            return result;
        }



        #endregion

        #region QRCode
        /// <summary>
        /// utilise l'algorithme ReedSolomon pour retourner des valeurs de correction d'erreur
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public static int[] EC(string inputText)
        {
            Encoding u8 = Encoding.UTF8;
            
            //string a = "HELLO WORD AND ALL";
            //int iBC = u8.GetByteCount(a);
            byte[] bytes = u8.GetBytes(inputText);
            //string b = "HELIO WORX AND OLL";
            //byte[] bytesb = u8.GetBytes(b);
            //byte[] result = ReedSolomonAlgorithm.Encode(bytesa, 7);


            //Privilégiez l'écriture suivante car par défaut le type choisi est DataMatrix 
            byte[] result = ReedSolomonAlgorithm.Encode(bytes, 7, ErrorCorrectionCodeType.QRCode);
            //byte[] result1 = ReedSolomonAlgorithm.Decode(bytesb, result, ErrorCorrectionCodeType.QRCode);


            int[] resultInt = new int[result.Length];
            resultInt = byteToInt(result);
            
            for (int i = 0; i < resultInt.Length; i++)
            {
                //Console.WriteLine(resultInt[i]);
            }
            return resultInt;
        }
        /// <summary>
        /// utilise l'algorithme ReedSolomon pour retourner des valeurs de correction d'erreur
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public static int[] ECbits(int[] inputText, int size=7)
        {
            Encoding u8 = Encoding.UTF8;
            inputText = binary8ToInt(inputText);
            int[] resultInt = null;
            byte[] bitsArr = new byte[inputText.Length];
            for(int j=0; j < bitsArr.Length; j++)
            {
                bitsArr[j] = (byte)(inputText[j]);
            }
            if (size > 0)
            {
                //Privilégiez l'écriture suivante car par défaut le type choisi est DataMatrix 
                byte[] result = ReedSolomonAlgorithm.Encode(bitsArr, size, ErrorCorrectionCodeType.QRCode);

                resultInt = new int[result.Length];
                resultInt = byteToInt(result);
            }
            return resultInt;
        }
        /// <summary>
        /// compare deux tableau de bits
        /// </summary>
        /// <param name="binary1"></param>
        /// <param name="binary2"></param>
        /// <returns></returns>
        public static string BinaryEqual(int[] binary1, int[] binary2)
        {
            string result = "not the same";
            if(binary1.Length == binary2.Length)
            {
                result = "is the same";
                for(int i=0; i < binary1.Length; i++)
                {
                    if(binary1[i] != binary2[i])
                    {
                        result = "not the same";
                        return result;
                    }
                }
            }
            return result;
        }
        #endregion
    }
}