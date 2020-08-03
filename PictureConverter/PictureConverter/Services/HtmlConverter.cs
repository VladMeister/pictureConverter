using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PictureConverter.Services
{
    public static class HtmlConverter
    {
        public static string GetHtmlColoredString(string fileName)
        {
            var result = new StringBuilder();
            Bitmap bitmap = null;

            try
            {
                bitmap = new Bitmap(fileName);

                for (int y = 0; y < bitmap.Height; y += 10)
                {
                    for (int x = 0; x < bitmap.Width; x += 5)
                    {
                        var color = bitmap.GetPixel(x, y);

                        color = Color.FromArgb((color.R + color.G + color.B) / 3,
                            (color.R + color.G + color.B) / 3,
                            (color.R + color.G + color.B) / 3);

                        int redValue = int.Parse(color.R.ToString());

                        result.Append(GetColorShade(redValue));

                        if (x >= bitmap.Width - 5)
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

        private static string GetColorShade(int redValue)
        {
            string color = string.Empty;

            if (redValue >= 230)
            {
                color = "white";
            }
            else if (redValue >= 200)
            {
                color = "NavajoWhite";
            }
            else if (redValue >= 180)
            {
                color = "LightGoldenrodYellow";
            }
            else if (redValue >= 160)
            {
                color = "LightYellow";
            }
            else if (redValue >= 130)
            {
                color = "NavajoWhite";
            }
            else if (redValue >= 115)
            {
                color = "green";
            }
            else if (redValue >= 100)
            {
                color = "DeepSkyBlue";
            }
            else if (redValue >= 70)
            {
                color = "purple";
            }
            else if (redValue >= 50)
            {
                color = "DarkOliveGreen";
            }
            else
            {
                color = "black";
            }

            return $"<font size='1' color={color}>1</font>"; ;
        }
    }
}
