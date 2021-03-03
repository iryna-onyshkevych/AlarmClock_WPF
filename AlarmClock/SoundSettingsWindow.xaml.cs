using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        private void SoundStream(UnmanagedMemoryStream stream)
        {
            ((MainWindow)Application.Current.MainWindow).sound.Stream = stream;
        }

        private void ThemeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<UnmanagedMemoryStream> paths = new List<UnmanagedMemoryStream>();
            paths.Add(Properties.Resources.basic);
            paths.Add(Properties.Resources.basic2);
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string audioname = selectedItem.Name.ToString();

            switch (audioname) { 

            case "theme1":
                SoundStream(paths[0]);
                    break;
            case "theme2":
                SoundStream(paths[1]);
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
                    ((MainWindow)Application.Current.MainWindow).sound.SoundLocation = filename;
                }
                    break;
            }
        
        }
    }
}
