using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatbot
{
    public partial class AlarmTimer : Form
    {
        int seconds;
        System.Timers.Timer timer;

        public AlarmTimer()
        {
            InitializeComponent();
        }

        private void AlarmTimer_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime userTime = AlarmTimePicker.Value;

            if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Second == userTime.Second)
            {
                timer.Stop();
                MessageBox.Show("Ring Ring Ring");
            }
        }

        private void SetAlarmButton_Click(object sender, EventArgs e)
        {
            //Add small change to display the current set alarm time
            timer.Start();
            AlarmRunningLabel.Text = ("Alarm set for ");
        }

        private void StopAlarmButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            AlarmRunningLabel.Text = "Alarm not set.";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds = Convert.ToInt32(TimerTextBox.Text);
            TimerTextBox.Enabled = false;
            timer1.Start();
        }

        private void TimerButton_Click(object sender, EventArgs e)
        {
            TimerCountLabel.Text = seconds--.ToString();

            if(seconds <= 0)
            {
                timer1.Stop();
                TimerTextBox.Enabled = true;
                MessageBox.Show("Ring Ring Ring");
            }
        }
    }
}
