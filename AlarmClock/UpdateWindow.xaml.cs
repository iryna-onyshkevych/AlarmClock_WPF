using System;
using System.Windows;

namespace AlarmClock
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public int NewMinutes { get; set; }
        public int NewHours { get; set; }
        public DateTime NewDay { get; set; }
        public string NewMessage { get; set; }

        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            NewMinutes = Convert.ToInt32(alminute.Text);
            NewHours = Convert.ToInt32(alhour.Text);
            NewDay = Convert.ToDateTime(alday.Text);
            NewMessage = almessage.Text;
            this.Close();
        }
    }
}
