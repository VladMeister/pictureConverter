using PictureConverter.Services;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PictureConverter
{
    public partial class MainWindow : Window
    {
        public string FileName { get; set; }
        private readonly Converter _converter;

        public MainWindow()
        {
            InitializeComponent();

            _converter = new Converter();
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            DisableConvertButton();
            DisableSizeComboBox();
            OptimizeFontSize();

            AsciiOutputTextBox.AppendText(_converter.GetAsciiString(FileName, SizeComboBox.Text));

            AsciiOutputTextBox.IsEnabled = true;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ImageBox.Source = null;
            AsciiOutputTextBox.Text = null;
            SizeComboBox.Text = null;

            EnableSelectImageButton();
            DisableConvertButton();
            EnableSizeComboBox();
            OptimizeFontSize();
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

        private void EnableSizeComboBox()
        {
            SizeComboBox.IsEnabled = true;
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

        private void DisableSizeComboBox()
        {
            SizeComboBox.IsEnabled = false;
        }

        private void OptimizeFontSize()
        {
            if (SizeComboBox.Text == "Large")
            {
                AsciiOutputTextBox.FontSize = 1;
            }
            else if (SizeComboBox.Text == "Small")
            {
                AsciiOutputTextBox.FontSize = 7.9;
            }
            else
            {
                AsciiOutputTextBox.FontSize = 5;
            }
        }
    }
}
