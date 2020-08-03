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
        private readonly Converter _converter;

        public MainWindow()
        {
            InitializeComponent();

            _converter = new Converter();
        }

        private void ConvertToGrayButton_Click(object sender, RoutedEventArgs e)
        {
            DisableConvertToGrayButton();
            DisableSizeComboBox();
            OptimizeFontSize();

            AsciiOutputTextBox.AppendText(_converter.GetAsciiString(FileName, SizeComboBox.Text));

            AsciiOutputTextBox.IsEnabled = true;
        }

        private void ConvertToColorButton_Click(object sender, RoutedEventArgs e)
        {
            DisableConvertToColorButton();
            DisableSizeComboBox();
            EnableWebBrowserOutput();

            WebBrowserOutput.NavigateToString($"<html><head></head><body>{HtmlConverter.GetHtmlColoredString(FileName)}</body></html>");
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ImageBox.Source = null;
            AsciiOutputTextBox.Text = null;
            SizeComboBox.Text = null;
            AsciiOutputTextBox.IsEnabled = false;
            WebBrowserOutput.Source = null;

            EnableSelectImageButton();
            DisableConvertToGrayButton();
            DisableConvertToColorButton();
            DisableWebBrowserOutput();
            EnableSizeComboBox();
            OptimizeFontSize();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            FileName = ImageSelector.GetFileName();

            if (FileName != null)
            {
                ImageBox.Source = new BitmapImage(new Uri(FileName));

                EnableConvertToGrayButton();
                EnableConvertToColorButton();
                DisableSelectImageButton();
            }
        }

        private void EnableConvertToGrayButton()
        {
            ConvertToGrayButton.IsEnabled = true;
            ConvertToGrayButton.Foreground = Brushes.White;
        }

        private void EnableConvertToColorButton()
        {
            ConvertToColorButton.IsEnabled = true;
            ConvertToColorButton.Foreground = Brushes.White;
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

        private void EnableWebBrowserOutput()
        {
            WebBrowserOutput.IsEnabled = true;
            WebBrowserOutput.Visibility = Visibility.Visible;
            AsciiOutputTextBox.Visibility = Visibility.Hidden;
        }

        private void DisableConvertToGrayButton()
        {
            ConvertToGrayButton.IsEnabled = false;
            ConvertToGrayButton.Foreground = Brushes.DarkGray;
        }

        private void DisableConvertToColorButton()
        {
            ConvertToColorButton.IsEnabled = false;
            ConvertToColorButton.Foreground = Brushes.DarkGray;
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

        private void DisableWebBrowserOutput()
        {
            WebBrowserOutput.IsEnabled = false;
            WebBrowserOutput.Visibility = Visibility.Hidden;
            AsciiOutputTextBox.Visibility = Visibility.Visible;
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
