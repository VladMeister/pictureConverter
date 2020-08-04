using System;
using System.Drawing;
using System.Text;

namespace PictureConverter.Services
{
    public class GrayConverter
    {
        private int _heightSkip;
        private int _widthSkip;

        private const string BLACK = "@";
        private const string CHARCOAL = "#";
        private const string DARKGRAY = "8";
        private const string MEDIUMGRAY = "&";
        private const string MEDIUM = "o";
        private const string GRAY = ":";
        private const string SLATEGRAY = "*";
        private const string LIGHTGRAY = ".";
        private const string WHITE = " ";

        public string GetAsciiString(string fileName, string sizeOption)
        {
            var result = new StringBuilder();
            Bitmap bitmap = null;

            SetSizeSkipers(sizeOption);

            try
            {
                bitmap = new Bitmap(fileName);
                OptimizeImageSize(bitmap.Height, bitmap.Width);

                for (int y = 0; y < bitmap.Height; y += _heightSkip)
                {
                    for (int x = 0; x < bitmap.Width; x += _widthSkip)
                    {
                        var color = bitmap.GetPixel(x, y);

                        color = Color.FromArgb((color.R + color.G + color.B) / 3,
                            (color.R + color.G + color.B) / 3,
                            (color.R + color.G + color.B) / 3);

                        int redValue = int.Parse(color.R.ToString());

                        result.Append(GetGrayShade(redValue));

                        if (x >= bitmap.Width - _widthSkip)
                        {
                            result.Append('\n');
                        }
                    }
                }

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

        private void SetSizeSkipers(string sizeOption)
        {
            switch (sizeOption)
            {
                case "Large":
                    _heightSkip = 2;
                    _widthSkip = 1;
                    break;
                case "Small":
                    _heightSkip = 16;
                    _widthSkip = 9;
                    break;
                default:
                    _heightSkip = 10;
                    _widthSkip = 5;
                    break;
            }
        }

        private string GetGrayShade(int redValue)
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

        private void OptimizeImageSize(int height, int width)
        {
            if (height >= 1080 && width > 1920
                && height < 2160 && width <= 3840)
            {
                _heightSkip *= 2;
                _widthSkip *= 2;
            }
            else if (height >= 2160 && width > 3840)
            {
                _heightSkip *= 4;
                _widthSkip *= 4;
            }
        }
    }
}
