using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace AlarmClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly DispatcherTimer clockTimer = new DispatcherTimer();
        readonly DispatcherTimer timer = new DispatcherTimer();
        public SoundPlayer sound = new SoundPlayer();
        public ObservableCollection<AlarmClocks> alarmclock = new ObservableCollection<AlarmClocks>();

        public MainWindow()
        {
            InitializeComponent();
            
            clockTimer.Interval = TimeSpan.FromSeconds(1);
            clockTimer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer1_Tick;
            timer.Start();
        }

        void Timer1_Tick(object sender, EventArgs e)
        {
            TimeLabel.Content = DateTime.Now.ToLongTimeString();
        }

        private void AlClockOn_Click(object sender, RoutedEventArgs e)
        {
            clockTimer.Start();
            MessageBox.Show("Alarm Clock's are on", "Starting...");
        }

        private void SoundOff_Click(object sender, RoutedEventArgs e)
        {
            sound.Stop();
        }
        
        private void AddAlClock_Click(object sender, RoutedEventArgs e)
        {
            alarmclock.Add(new AlarmClocks() { AlarmMinutes = Convert.ToInt32(Minutes.Text), AlarmHours = Convert.ToInt32(Hours.Text), AlarmSeconds = Convert.ToInt32(Seconds.Text), AlarmDate = Convert.ToDateTime(Calendar.SelectedDate),
            AlarmMessage = message.Text});
            MessageBox.Show("New alarm clock added!");
            dataGrid.ItemsSource = alarmclock;
        }
        
        void Timer_Tick(object sender, EventArgs e)
        {

            DateTime currentTime = DateTime.Now;
            foreach (var al in alarmclock.ToList<AlarmClocks>())
            {
                if (currentTime.Hour == al.AlarmHours && currentTime.Minute == al.AlarmMinutes && currentTime.Date == al.AlarmDate && currentTime.Second == al.AlarmSeconds)
                {
                    try
                    {
                        if (sound.Stream == null)
                        {
                            sound.Stream = Properties.Resources.basic;
                        }
                        sound.PlayLooping();

                        dataGrid.Items.Refresh();
                        if (al.AlarmMessage != "")
                        {
                            MessageBox.Show(al.AlarmMessage);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("finished!");
                    }
                    al.AlarmIsCalled = true;
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

            if (dataGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    AlarmClocks clocks = dataGrid.SelectedItems[i] as AlarmClocks;
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
            //int newminutes = updateWindow.NewMinutes;
            //int newhours = updateWindow.NewHours;
            //string newmessage = updateWindow.NewMessage;
            //DateTime newday = updateWindow.NewDay;
            if (dataGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                {
                    AlarmClocks clocks = dataGrid.SelectedItems[i] as AlarmClocks;

                    if (clocks != null)
                    {
                        clocks.AlarmMinutes = updateWindow.NewMinutes;
                        clocks.AlarmHours = updateWindow.NewHours;
                        clocks.AlarmDate = updateWindow.NewDay;
                        clocks.AlarmMessage = updateWindow.NewMessage;
                    }
                }
            }
           dataGrid.Items.Refresh();
        }

        private void SaveList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<AlarmClocks>));
                TextWriter tw = new StreamWriter("alarmClocks.xml");
                formatter.Serialize(tw, alarmclock);
                tw.Close();
                MessageBox.Show("List saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<AlarmClocks>));

                string xmlString = "alarmClocks.xml";
                StreamReader reader =  new StreamReader(xmlString);
                alarmclock = (ObservableCollection<AlarmClocks>)formatter.Deserialize(reader);
                reader.Close();
                dataGrid.ItemsSource = alarmclock;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AlarmSnooze_Click(object sender, RoutedEventArgs e)
        {
            AlarmSnoozeWindow snoozeWindow = new AlarmSnoozeWindow();
            snoozeWindow.ShowDialog();
            //int sMinutes = snoozeWindow.DelayMinutes;
            //int sHours = snoozeWindow.DelayHours;
            //int sSeconds = snoozeWindow.DelaySeconds;
            DateTime currentTime = DateTime.Now;

            alarmclock.Add(new AlarmClocks()
            {
                AlarmMinutes = currentTime.Minute + snoozeWindow.DelayMinutes,
                AlarmSeconds = currentTime.Second + snoozeWindow.DelaySeconds,
                AlarmHours = currentTime.Hour + snoozeWindow.DelayHours,
                AlarmDate = currentTime.Date,
            });
            sound.Stop();
            MessageBox.Show("Alarm Clock is snoozed!");
            dataGrid.ItemsSource = alarmclock;
            clockTimer.Start();
        }
    }
}