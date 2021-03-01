using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AlarmClock
{
    /// <summary>
    /// Interaction logic for SoundSettingsWindow.xaml
    /// </summary>
    public partial class SoundSettingsWindow : Window
    {
        //List<AlarmClocks> alarms = new List<AlarmClocks>();
        //private List<AlarmClocks> LoadCollectionData()
        //{
        //    List<AlarmClocks> authors = new List<AlarmClocks>();
        //    authors.Add(new AlarmClocks()
        //    {
        //        alarmMinutes = 11,
        //        alarmDate = Convert.ToDateTime("12/10/2002"),
        //        alarmHours = 15
        //    }) ;



        //    return authors;
        //}
        MainWindow main = new MainWindow();

        public SoundSettingsWindow()
        {
            InitializeComponent();
            //dataGrid1.ItemsSource = main.alarmclock; // устанавливаем привязку к кэшу

            //alarms.Add(new AlarmClocks { alarmMinutes = 11, alarmDate = Convert.ToDateTime("12/10/2002"), alarmHours = 15 });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //dataGrid1.ItemsSource = main.alarmclock; // устанавливаем привязку к кэшу
            //MessageBox.Show(main.test.ToString());
            //foreach (var al in main.alarmclock)
            //{
            //    MessageBox.Show(al.alarmHours.ToString());

            //}
            
            //MessageBox.Show(main.alarmclock1[0].alarmMinutes.ToString());
            //dataGrid1.ItemsSource = main.; // устанавливаем привязку к кэшу

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainWindow main = new MainWindow();
            ((MainWindow)Application.Current.MainWindow).sound.Volume = sondslider.Value;
        }

        private void themeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string audioname = selectedItem.Name.ToString();
            switch (audioname)
            {
                case "theme1":
                    ((MainWindow)Application.Current.MainWindow).sound.Open(new Uri(@"C:\Users\irini\OneDrive\Робочий стіл\AlarmClockProject\basic2.wav"));
                    MessageBox.Show(selectedItem.Content.ToString());
                    break;
                case "theme2":
                    ((MainWindow)Application.Current.MainWindow).sound.Open(new Uri(@"C:\Users\irini\OneDrive\Робочий стіл\AlarmClockProject\basic.wav"));
                    MessageBox.Show(selectedItem.Content.ToString());
                    break;
                case "theme3":
                    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                    dlg.FileName = "Audio"; // Default file name
                    dlg.DefaultExt = ".wav"; // Default file extension
                    dlg.Filter = "Audio (.wav)|*.wav"; // Filter files by extension

                    // Show open file dialog box
                    Nullable<bool> result = dlg.ShowDialog();

                    // Process open file dialog box results
                    if (result == true)
                    {
                        // Open document
                        string filename = dlg.FileName;
                        ((MainWindow)Application.Current.MainWindow).sound.Open(new Uri(filename));
                    }
                    break;
                default:
                    ((MainWindow)Application.Current.MainWindow).sound.Open(new Uri(@"C:\Users\irini\OneDrive\Робочий стіл\AlarmClockProject\basic.wav"));
                    MessageBox.Show(selectedItem.Content.ToString());
                    break;
            }
           
        }
    }
}
