using Microsoft.Win32;

namespace PictureConverter.Services
{
    public static class ImageSelector
    {
        public static string GetFileName()
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "Select a picture";
            dialog.Filter = "*.jpg; *.jpeg; *.png; *.bmp|*.jpg; *.jpeg; *.png; *.bmp";

            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }

            return null;
        }
    }
}
