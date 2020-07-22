using PictureConverter.Services;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PictureConverter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            DisableConvertButton();
            EnableSelectImageButton();

            //Converter.GetImage(ImageBox.Source);
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ImageBox.Source = null;
            AsciiOutputBox.Text = null;

            EnableSelectImageButton();
            DisableConvertButton();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            string fileName = ImageSelector.SuccessfullSelect();

            if (fileName != null)
            {
                ImageBox.Source = new BitmapImage(new Uri(fileName));

                EnableConvertButton();
                DisableSelectImageButton();
            }
        }

        private void EnableConvertButton()
        {
            ConvertButton.IsEnabled = true;
            ConvertButton.Foreground = Brushes.White;
        }

        private void EnableSelectImageButton()
        {
            SelectImageButton.IsEnabled = true;
            SelectImageButton.Foreground = Brushes.White;
        }

        private void DisableConvertButton()
        {
            ConvertButton.IsEnabled = false;
            ConvertButton.Foreground = Brushes.DarkGray;
        }

        private void DisableSelectImageButton()
        {
            SelectImageButton.IsEnabled = false;
            SelectImageButton.Foreground = Brushes.DarkGray;
        }
    }
}
