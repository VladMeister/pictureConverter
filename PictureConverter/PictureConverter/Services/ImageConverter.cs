using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PictureConverter.Services
{
    public static class ImageConverter
    {
        public static void ConvertAndSaveImage(string htmlString)
        {
            if (!string.IsNullOrEmpty(htmlString))
            {
                var converter = new CoreHtmlToImage.HtmlConverter();
                var bytes = converter.FromHtmlString(htmlString);
                Directory.CreateDirectory("D:\\HtmlImages");
                //save window
                File.WriteAllBytes("D:\\HtmlImages\\image.jpg", bytes);
            }
        }
    }
}
