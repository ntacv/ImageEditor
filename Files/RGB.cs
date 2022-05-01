using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA2S4
{
    public class RGB
    {
        #region Properties

        byte red;
        byte green;
        byte blue;
        
        public byte Red
        {
            get { return red; }
            set { this.red = value; }
        }
        public byte Green 
        { 
            get { return green;}
            set { this.green = value; }
        }
        public byte Blue 
        { 
            get { return blue;}
            set { this.blue = value; }
        }

        #endregion

        /// <summary>
        /// Constructeurs définissant les couleurs pour un pixel
        /// </summary>
        /// <param name="pixel"></param>
        public RGB()
        {
            this.red = 0;
            this.green = 0;
            this.blue = 0;
        }
        #region Constructors
        public RGB(byte[] pixel) //3 values of colors
        {
            this.red = pixel[0];
            this.green = pixel[1];
            this.blue = pixel[2];

        }
        public RGB(byte red, byte green, byte blue) //3 values of colors
        {
            this.red = red;
            this.green = green;
            this.blue = blue;

        }
        public RGB(int red, int green, int blue) //3 values of colors
        {
            this.red = (byte)red;
            this.green = (byte)green;
            this.blue = (byte)blue;

        }
        public RGB(double red, double green, double blue) //3 values of colors
        {
            this.red = (byte)red;
            this.green = (byte)green;
            this.blue = (byte)blue;

        }
        #endregion

        #region Functions
        /// <summary>
        /// Write the three color values
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return " "+red.ToString()+" "+green.ToString()+" "+blue.ToString()+" ";
        }
        /// <summary>
        /// Retourne les valeurs des trois couleurs
        /// </summary>
        /// <returns></returns>
        public byte[] ToByte()
        {
            return new byte[] { red, green, blue };
        }
        /// <summary>
        /// retourne 0 si le pixel est noir sinon retourne 1
        /// </summary>
        /// <returns></returns>
        public int ToBinary()
        {
            if (red == 0 && green == 0 && blue == 0)
            {
                return 0;
            }
            else return 1;
        }
        /// <summary>
        /// retourne la valeur moyenne du pixel
        /// </summary>
        /// <returns></returns>
        public int Luminosity()
        {
            int lum = 0;
            for(int i = 0; i < 3; i++)
            {
                lum += this.ToByte()[i];
            }
            lum /= 3;
            return lum;
        }
        /// <summary>
        /// Compare deux pixels
        /// </summary>
        /// <param name="pixel"></param>
        /// <returns>true si les deux pixels ont la meme couleur</returns>
        public bool Equal(RGB pixel)
        {
            if (red == pixel.Red && green == pixel.Green && blue == pixel.Blue)
            {
                return true;
            }
            else return false;
        }
        public bool Equal(int _red, int _green, int _blue)
        {
            if (red == _red && green == _green && blue == _blue)
            {
                return true;
            }
            else return false;
        }
        #endregion
        #region Effets/Filtres
        /// <summary>
        /// Inverse les couleurs du pixel
        /// </summary>
        public void Negatif()
        {
            int oldRed = this.red;
            int oldGreen = this.green;
            int oldBlue = this.blue;

            this.red = (byte)(255 - oldRed);
            this.green = (byte)(255 - oldGreen);
            this.blue = (byte)(255 - oldBlue);
        }

        #endregion
    }
}
