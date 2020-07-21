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

        public static string GetImage(Image image)
        {
            StringBuilder html = new StringBuilder();
            Bitmap bmp = null;

            try
            {
                bmp = new Bitmap(image);

                html.Append("&lt;br/&rt;");

                for (int y = 0; y < bmp.Height / 100; y++)
                {
                    for (int x = 0; x < bmp.Width / 100; x++)
                    {
                        Color col = bmp.GetPixel(x, y);

                        col = Color.FromArgb((col.R + col.G + col.B) / 3,
                            (col.R + col.G + col.B) / 3,
                            (col.R + col.G + col.B) / 3);

                        int rValue = int.Parse(col.R.ToString());

                        html.Append(GetGrayShade(rValue));

                        if (x == bmp.Width - 1)
                            html.Append("&lt;br/&rt");
                    }
                }

                html.Append("&lt;/p&rt;");

                return html.ToString();
            }
            catch (Exception exc)
            {
                return exc.ToString();
            }
            finally
            {
                bmp.Dispose();
            }
        }

        private static string GetGrayShade(int redValue)
        {
            string asciival = " ";

            if (redValue >= 230)
            {
                asciival = WHITE;
            }
            else if (redValue >= 200)
            {
                asciival = LIGHTGRAY;
            }
            else if (redValue >= 180)
            {
                asciival = SLATEGRAY;
            }
            else if (redValue >= 160)
            {
                asciival = GRAY;
            }
            else if (redValue >= 130)
            {
                asciival = MEDIUM;
            }
            else if (redValue >= 100)
            {
                asciival = MEDIUMGRAY;
            }
            else if (redValue >= 70)
            {
                asciival = DARKGRAY;
            }
            else if (redValue >= 50)
            {
                asciival = CHARCOAL;
            }
            else
            {
                asciival = BLACK;
            }

            return asciival;
        }
    }
}
