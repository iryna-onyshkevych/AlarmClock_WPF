using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

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

        public const int maxHours = 23;
        public static int maxMinutes = 59;
        public UpdateWindow()
        {
            InitializeComponent();
        }
        
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                int tryint;
                DateTime trydatetime;
                if ((!int.TryParse(alminute.Text, out tryint)||(Convert.ToInt32(alminute.Text) > maxMinutes)))
                {
                    MessageBox.Show("Incorrect Minutes input! Try again ");
                }
                else if (!int.TryParse(alhour.Text, out tryint) || (Convert.ToInt32(alhour.Text) > maxHours))
                {
                    MessageBox.Show("Incorrect Hour input! Try again ");

                }
                else if (!DateTime.TryParse(alday.Text, out trydatetime))
                {
                    MessageBox.Show("Incorrect Day input! Try again ");
                }
                else
                {
                    NewMinutes = Convert.ToInt32(alminute.Text);
                    NewHours = Convert.ToInt32(alhour.Text);
                    NewDay = Convert.ToDateTime(alday.Text);
                    NewMessage = almessage.Text;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
