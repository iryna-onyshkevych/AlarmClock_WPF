using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AlarmClock
{
    /// <summary>
    /// Interaction logic for SoundSettingsWindow.xaml
    /// </summary>
    public partial class SoundSettingsWindow : Window
    {
        public SoundSettingsWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((MainWindow)Application.Current.MainWindow).sound.Volume = soundslider.Value;
        }

        private void ThemeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string audioname = selectedItem.Name.ToString();

            switch (audioname)
            {
                case "theme1":
                    ((MainWindow)Application.Current.MainWindow).sound.Open(new Uri("sounds/basic2.wav", UriKind.Relative));
                    MessageBox.Show(selectedItem.Content.ToString());
                    break;
                case "theme2":
                    ((MainWindow)Application.Current.MainWindow).sound.Open(new Uri("sounds/basic.wav", UriKind.Relative));
                    MessageBox.Show(selectedItem.Content.ToString());
                    break;
                case "theme3":
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.FileName = "Audio";
                    dlg.DefaultExt = ".wav";
                    dlg.Filter = "Audio (.wav)|*.wav";
                    Nullable<bool> result = dlg.ShowDialog();
                    if (result == true)
                    {
                        string filename = dlg.FileName;
                        ((MainWindow)Application.Current.MainWindow).sound.Open(new Uri(filename));
                    }
                    break;
            }
        }
    }
}
