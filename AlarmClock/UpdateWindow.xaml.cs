using System;
using System.Windows;

namespace AlarmClock
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public int newminutes { get; set; }
        public int newhours { get; set; }
        public DateTime newdays { get; set; }
        public string newmessage { get; set; }

        public UpdateWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            newminutes = Convert.ToInt32(alminute.Text);
            newhours = Convert.ToInt32(alhour.Text);
            newdays = Convert.ToDateTime(alday.Text);
            newmessage = almessage.Text;
            this.Close();
        }
    }
}
