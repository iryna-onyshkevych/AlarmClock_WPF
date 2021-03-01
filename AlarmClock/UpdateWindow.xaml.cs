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

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            newminutes = Convert.ToInt32(alminute.Text);
            newhours = Convert.ToInt32(alhour.Text);
            newdays = Convert.ToDateTime(alday.Text);
            newmessage = almessage.Text;
            this.Close();
        }
    }
}
