using System;
using System.Drawing;
using System.Text;

namespace PictureConverter.Services
{
    public static class Converter
    {
        private const string BLACK = "@";
        private const string CHARCOAL = "#";
        private const string DARKGRAY = "8";
        private const string MEDIUMGRAY = "&";
        private const string MEDIUM = "o";
        private const string GRAY = ":";
        private const string SLATEGRAY = "*";
        private const string LIGHTGRAY = ".";
        private const string WHITE = " ";

        public static string GetAsciiString(string fileName)
        {
            StringBuilder result = new StringBuilder();
            Bitmap bitmap = null;

            try
            {
                bitmap = new Bitmap(fileName);

                result.Append("<br/>");

                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color col = bitmap.GetPixel(x, y);

                        col = Color.FromArgb((col.R + col.G + col.B) / 3,
                            (col.R + col.G + col.B) / 3,
                            (col.R + col.G + col.B) / 3);

                        int redValue = int.Parse(col.R.ToString());

                        result.Append(GetGrayShade(redValue));

                        if (x == bitmap.Width - 1)
                        {
                            result.Append("<br/>");
                        }
                    }
                }

                result.Append("<br/>");

                return result.ToString();
            }
            catch (Exception exc)
            {
                return exc.ToString();
            }
            finally
            {
                bitmap.Dispose();
            }
        }

        private static string GetGrayShade(int redValue)
        {
            string value = " ";

            if (redValue >= 230)
            {
                value = WHITE;
            }
            else if (redValue >= 200)
            {
                value = LIGHTGRAY;
            }
            else if (redValue >= 180)
            {
                value = SLATEGRAY;
            }
            else if (redValue >= 160)
            {
                value = GRAY;
            }
            else if (redValue >= 130)
            {
                value = MEDIUM;
            }
            else if (redValue >= 100)
            {
                value = MEDIUMGRAY;
            }
            else if (redValue >= 70)
            {
                value = DARKGRAY;
            }
            else if (redValue >= 50)
            {
                value = CHARCOAL;
            }
            else
            {
                value = BLACK;
            }

            return value;
        }
    }
}
