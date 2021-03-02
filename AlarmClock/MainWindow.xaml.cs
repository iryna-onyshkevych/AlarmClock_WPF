using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Serialization;
using System.Configuration;

namespace AlarmClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer1 = new DispatcherTimer();
        public MediaPlayer sound = new MediaPlayer();
        public ObservableCollection<AlarmClocks> alarmclock = new ObservableCollection<AlarmClocks>();

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer1.Interval = TimeSpan.FromSeconds(1);
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        void Timer1_Tick(object sender, EventArgs e)
        {
            TimeLabel.Content = DateTime.Now.ToLongTimeString();
        }

        private void AlClockOn_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            MessageBox.Show("Alarm Clock's are on", "Starting...");
        }

        private void SoundOff_Click(object sender, RoutedEventArgs e)
        {
            sound.Stop();
        }

        private void AddAlClock_Click(object sender, RoutedEventArgs e)
        {
            alarmclock.Add(new AlarmClocks() { alarmMinutes = Convert.ToInt32(Minutes.Text), alarmHours = Convert.ToInt32(Hours.Text), alarmDate = Convert.ToDateTime(Calendar.SelectedDate),
            alarmMessage = message.Text});
            MessageBox.Show("New alarm clock added!");
            
            //XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<AlarmClocks>));
            //using (FileStream fs = new FileStream("alarmClocks.xml", FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, alarmclock);
            //}
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<AlarmClocks>));

            TextWriter txtWriter = new StreamWriter(@"C:\Users\irini\OneDrive\Робочий стіл\AlarmClockProject\AlarmClock\AlarmClock\bin\Debug\personsone.xml");

            xs.Serialize(txtWriter, alarmclock);

            txtWriter.Close();
            string xmlString = (@"C:\Users\irini\OneDrive\Робочий стіл\AlarmClockProject\AlarmClock\AlarmClock\bin\Debug\personsone.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<AlarmClocks>));
            StreamReader reader = new StreamReader(xmlString);
            alarmclock = (ObservableCollection<AlarmClocks>)serializer.Deserialize(reader);
            reader.Close();
            dataGrid1.ItemsSource = alarmclock;
        }
        
        void Timer_Tick(object sender, EventArgs e)
        {

            DateTime currentTime = DateTime.Now;
            foreach (var al in alarmclock.ToList<AlarmClocks>())
            {
                if (currentTime.Hour == al.alarmHours && currentTime.Minute == al.alarmMinutes && currentTime.Date == al.alarmDate)
                {
                    try
                    {
                        if (sound.Source == null)
                        {
                            sound.Open(new Uri("sounds/basic.wav", UriKind.Relative));

                        }
                        sound.Play();
                        if (al.alarmMessage != "")
                        {
                            MessageBox.Show(al.alarmMessage);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("finished!");
                    }
                    alarmclock.Remove(al);
                }
            }

        }

        private void HoursUp_Click(object sender, RoutedEventArgs e)
        {
            var curHour = int.Parse(this.Hours.Text);

            curHour++;
            if (curHour > 23)
            {
                curHour = 0;
                this.Hours.Text = curHour.ToString();
            }

            this.Hours.Text = curHour.ToString();
        }

        private void HoursDown_Click(object sender, RoutedEventArgs e)
        {
            var curHour = int.Parse(this.Hours.Text);
            curHour--;
            if (curHour < 0)
            {
                curHour = 23;
                this.Hours.Text = curHour.ToString();
            }

            this.Hours.Text = curHour.ToString();
        }

        private void MinutesUp_Click(object sender, RoutedEventArgs e)
        {
            var curMinute = int.Parse(this.Minutes.Text);
            curMinute++;
            if (curMinute > 59)
            {
                curMinute = 0;
                this.Minutes.Text = curMinute.ToString();
            }

            this.Minutes.Text = curMinute.ToString();
        }

        private void MinutesDown_Click(object sender, RoutedEventArgs e)
        {
            var curMinute = int.Parse(this.Minutes.Text);
            curMinute--;
            if (curMinute < 0)
            {
                curMinute = 59;
                this.Minutes.Text = curMinute.ToString();
            }

            this.Minutes.Text = curMinute.ToString();
        }

        private void SettingsWindow_Click(object sender, RoutedEventArgs e)
        {
            SoundSettingsWindow settingsWindow = new SoundSettingsWindow();
            settingsWindow.Show();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            if (dataGrid1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < dataGrid1.SelectedItems.Count; i++)
                {
                    AlarmClocks clocks = dataGrid1.SelectedItems[i] as AlarmClocks;

                    if (clocks != null)
                    {
                        alarmclock.Remove(clocks);
                    }
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow updateWindow = new UpdateWindow();
            updateWindow.ShowDialog();
            int newminutes = updateWindow.newminutes;
            int newhours = updateWindow.newhours;
            string newmessage = updateWindow.newmessage;
            DateTime newday = updateWindow.newdays;
            if (dataGrid1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < dataGrid1.SelectedItems.Count; i++)
                {
                    AlarmClocks clocks = dataGrid1.SelectedItems[i] as AlarmClocks;

                    if (clocks != null)
                    {
                        clocks.alarmMinutes = newminutes;
                        clocks.alarmHours = newhours;
                        clocks.alarmDate = newday;
                        clocks.alarmMessage = newmessage;
                        XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<AlarmClocks>));
                        using (FileStream fs = new FileStream("alarmClocks.xml", FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, alarmclock);
                        }
                    }
                }
            }
        }

        private void ThemeWindow_Click(object sender, RoutedEventArgs e)
        {
            ThemeSettingsWindow themeSettings = new ThemeSettingsWindow();
            themeSettings.Show();
        }
    }

}