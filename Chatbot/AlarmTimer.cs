using System.Timers;
using Timer = System.Timers.Timer;

namespace Chatbot
{
    public partial class AlarmTimer : Form
    {
        private int _seconds;
        private Timer _timer;

        public AlarmTimer()
        {
            InitializeComponent();
        }

        private void AlarmTimer_Load(object sender, EventArgs e)
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            DateTime userTime = AlarmTimePicker.Value;

            if (currentTime.Hour == userTime.Hour && currentTime.Minute == userTime.Minute && currentTime.Second == userTime.Second)
            {
                _timer.Stop();
                MessageBox.Show("Ring Ring Ring");
            }
        }

        private void SetAlarmButton_Click(object sender, EventArgs e)
        {
            //Add small change to display the current set alarm time
            _timer.Start();
            AlarmRunningLabel.Text = ("Alarm set for ");
        }

        private void StopAlarmButton_Click(object sender, EventArgs e)
        {
            _timer.Stop();
            AlarmRunningLabel.Text = "Alarm not set.";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _seconds = Convert.ToInt32(TimerTextBox.Text);
            TimerTextBox.Enabled = false;
            timer1.Start();
        }

        private void TimerButton_Click(object sender, EventArgs e)
        {
            TimerCountLabel.Text = _seconds--.ToString();

            if (_seconds <= 0)
            {
                timer1.Stop();
                TimerTextBox.Enabled = true;
                MessageBox.Show("Ring Ring Ring");
            }
        }
    }
}
