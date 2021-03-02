using System;
using System.Windows;

namespace AlarmClock
{
    /// <summary>
    /// Interaction logic for AlarmSnoozeWindow.xaml
    /// </summary>
    public partial class AlarmSnoozeWindow : Window
    {

        public int DelayMinutes { get; set; }
        public int DelayHours { get; set; }
        public int DelaySeconds { get; set; }

        public AlarmSnoozeWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (snoozeHours.Text != "")
            {
                DelayHours = Convert.ToInt32(snoozeHours.Text);
            }
            else
                DelayHours = 0;
            if (snoozeMinutes.Text != "")
            {
                DelayMinutes = Convert.ToInt32(snoozeMinutes.Text);
            }
            else
                DelayMinutes = 0;

            DelaySeconds = Convert.ToInt32(snoozeSeconds.Text);

            this.Close();
        }
    }
}
