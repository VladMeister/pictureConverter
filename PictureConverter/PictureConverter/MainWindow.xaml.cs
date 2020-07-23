using PictureConverter.Services;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PictureConverter
{
    public partial class MainWindow : Window
    {
        public string FileName { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            DisableConvertButton();
            EnableSelectImageButton();

            AsciiOutputBox.Text = Converter.GetAsciiString(FileName);

            AsciiOutputBox.IsEnabled = true;
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
            FileName = ImageSelector.GetFileName();

            if (FileName != null)
            {
                ImageBox.Source = new BitmapImage(new Uri(FileName));

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
