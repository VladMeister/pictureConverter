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

                        int redValue = int.Parse(color.R.ToString());
                        int greenValue = int.Parse(color.G.ToString());
                        int blueValue = int.Parse(color.B.ToString());

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
            var random = new Random();
            int randomNumber = random.Next(0, 2);

            return $"<font size='3' color=rgb({redValue},{greenValue},{blueValue})>{randomNumber}</font>";
        }
    }
}
