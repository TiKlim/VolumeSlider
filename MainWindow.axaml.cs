using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using System;

namespace VolumeSlider
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.FindControl<Slider>("VolumeSlider").ValueChanged += VolumeSlider_ValueChanged;
        }
        // Start
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double volume)
            {
                return (volume / 100) * 360; // Преобразование значения в угол
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        // Finish
        private void VolumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            var slider = sender as Slider;
            var volumeValue = this.FindControl<TextBlock>("VolumeValue");
            volumeValue.Text = $"Громкость: {slider.Value:F0}%";
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}