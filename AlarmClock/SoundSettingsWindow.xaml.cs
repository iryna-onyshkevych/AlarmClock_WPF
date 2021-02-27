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
    }
}
