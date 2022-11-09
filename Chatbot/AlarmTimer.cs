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

        public AlarmTimer()
        {
            InitializeComponent();
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
        }
    }
}
