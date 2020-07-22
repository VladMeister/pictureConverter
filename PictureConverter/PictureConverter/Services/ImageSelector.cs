using Microsoft.Win32;

namespace PictureConverter.Services
{
    public static class ImageSelector
    {
        public static string SuccessfullSelect()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select a picture";
            dialog.Filter = "*.jpg; *.jpeg; *.gif; *.bmp|*.jpg; *.jpeg; *.gif; *.bmp";

            if (dialog.ShowDialog() == true)
            {
                return dialog.FileName;
            }

            return null;
        }
    }
}
