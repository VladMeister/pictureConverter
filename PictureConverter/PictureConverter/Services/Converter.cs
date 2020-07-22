using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Media.Imaging;

namespace PictureConverter.Services
{
    public static class Converter
    {
        public static void GetImage(BitmapImage bitMapImg)
        {
            BitmapSource img = bitMapImg;

            int stride = img.PixelWidth * 4;
            int size = img.PixelHeight * stride;
            byte[] pixels = new byte[size];
            img.CopyPixels(pixels, stride, 0);

            for (int y = 0; y < img.PixelHeight; y++)
            {
                for (int x = 0; x < img.PixelWidth; x++)
                {
                    int index = y * stride + 4 * x;

                    byte red = pixels[index];
                    byte green = pixels[index + 1];
                    byte blue = pixels[index + 2];
                    byte alpha = pixels[index + 3];
                }
            }
        }
    }
}
