using System;
using System.Drawing;
using System.Text;

namespace PictureConverter.Services
{
    public class HtmlConverter
    {
        public string GetHtmlColoredString(string fileName)
        {
            var result = new StringBuilder();
            Bitmap bitmap = null;

            try
            {
                bitmap = new Bitmap(fileName);

                for (int y = 0; y < bitmap.Height; y+=16)
                {
                    for (int x = 0; x < bitmap.Width; x+=9)
                    {
                        var color = bitmap.GetPixel(x, y);

                        var redValue = int.Parse(color.R.ToString());
                        var greenValue = int.Parse(color.G.ToString());
                        var blueValue = int.Parse(color.B.ToString());

                        result.Append(SetSymbolShade(redValue, greenValue, blueValue));

                        if (x >= bitmap.Width - 9)
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

        private string SetSymbolShade(int redValue, int greenValue, int blueValue)
        {
            var randomNumber = new Random().Next(0, 10);

            return $"<font size='3' color=rgb({redValue},{greenValue},{blueValue})>{randomNumber}</font>";
        }
    }
}
