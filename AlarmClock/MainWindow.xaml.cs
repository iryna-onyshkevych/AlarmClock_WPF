﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AlarmClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer1 = new DispatcherTimer();
        SoundPlayer sound = new SoundPlayer();

        public MainWindow()
        {
            InitializeComponent();
            sound.SoundLocation = @"C:\Users\irini\OneDrive\Робочий стіл\AlarmClockProject\basic.wav";
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer1.Interval = TimeSpan.FromSeconds(1);
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            TimeLabel.Content = DateTime.Now.ToLongTimeString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            MessageBox.Show("Timer is started", "Starting...");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            sound.Stop();
            MessageBox.Show("Your timer is stopped", "Stopping...");
        }
       

        void timer_Tick(object sender, EventArgs e)
        {
          
            DateTime currentTime = DateTime.Now;
            DateTime userTime = new DateTime();
            TimeSpan ts = new TimeSpan(Convert.ToInt32(Hours.Text), Convert.ToInt32(Minutes.Text), 0);
            userTime = userTime.Date + ts;
            if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Date == (Calendar.SelectedDate))
            {
                timer.Stop();
                try
                {
                   
                    sound.Play();
                    MessageBox.Show("Time!");
                }
                catch
                {
                    MessageBox.Show("finished!");
                }
            }
        }
        private void btnHoursUp_Click(object sender, RoutedEventArgs e)
        {
            var buff = int.Parse(this.Hours.Text);

            buff++;
            if (buff > 23)
            {
                buff = 0;
                this.Hours.Text = buff.ToString();
            }

            this.Hours.Text = buff.ToString();
        }

        private void btnHoursDown_Click(object sender, RoutedEventArgs e)
        {
            var buff = int.Parse(this.Hours.Text);
            buff--;
            if (buff < 0)
            {
                buff = 23;
                this.Hours.Text = buff.ToString();
            }

            this.Hours.Text = buff.ToString();
        }

        private void btnMinUp_Click(object sender, RoutedEventArgs e)
        {
            var buff = int.Parse(this.Minutes.Text);
            buff++;
            if (buff > 59)
            {
                buff = 0;
                this.Minutes.Text = buff.ToString();
            }

            this.Minutes.Text = buff.ToString();
        }

        private void btnMinDown_Click(object sender, RoutedEventArgs e)
        {
            var buff = int.Parse(this.Minutes.Text);
            buff--;
            if (buff < 0)
            {
                buff = 59;
                this.Minutes.Text = buff.ToString();
            }

            this.Minutes.Text = buff.ToString();
        }

    }
}
