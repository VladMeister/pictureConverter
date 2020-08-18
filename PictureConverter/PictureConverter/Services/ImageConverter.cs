using Microsoft.Win32;
using System.IO;

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

                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = "defaultName";
                saveFileDialog.Title = "Save image";
                saveFileDialog.Filter = "Image file (*.jpg)|*.jpg";

                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllBytes(saveFileDialog.FileName, bytes);
                }
            }
        }
    }
}
