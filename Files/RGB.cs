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


        public override string ToString()
        {
            return red.ToString()+" "+green.ToString()+" "+blue.ToString();
        }

        public byte[] ToByte()
        {
            return new byte[] { red, green, blue };
        }

        public int ToBinary()
        {
            if (red == 0 && green == 0 && blue == 0)
            {
                return 0;
            }
            else return 1;
        }

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

        #region Effets/Filtres

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
