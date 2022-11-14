using System.ComponentModel;
using Timer = System.Windows.Forms.Timer;

namespace Chatbot
{
    partial class AlarmTimer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TimerTextLabel = new System.Windows.Forms.Label();
            this.TimerCountLabel = new System.Windows.Forms.Label();
            this.TimerButton = new System.Windows.Forms.Button();
            this.TimerTextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.AlarmTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AlarmLabel = new System.Windows.Forms.Label();
            this.SetAlarmButton = new System.Windows.Forms.Button();
            this.StopAlarmButton = new System.Windows.Forms.Button();
            this.AlarmRunningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TimerTextLabel
            // 
            this.TimerTextLabel.AutoSize = true;
            this.TimerTextLabel.Location = new System.Drawing.Point(78, 85);
            this.TimerTextLabel.Name = "TimerTextLabel";
            this.TimerTextLabel.Size = new System.Drawing.Size(172, 15);
            this.TimerTextLabel.TabIndex = 1;
            this.TimerTextLabel.Text = "Enter your timer duration here: ";
            // 
            // TimerCountLabel
            // 
            this.TimerCountLabel.AutoSize = true;
            this.TimerCountLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TimerCountLabel.Location = new System.Drawing.Point(96, 18);
            this.TimerCountLabel.Name = "TimerCountLabel";
            this.TimerCountLabel.Size = new System.Drawing.Size(132, 65);
            this.TimerCountLabel.TabIndex = 2;
            this.TimerCountLabel.Text = "0000";
            // 
            // TimerButton
            // 
            this.TimerButton.Location = new System.Drawing.Point(123, 132);
            this.TimerButton.Name = "TimerButton";
            this.TimerButton.Size = new System.Drawing.Size(75, 23);
            this.TimerButton.TabIndex = 3;
            this.TimerButton.Text = "Start Timer";
            this.TimerButton.UseVisualStyleBackColor = true;
            this.TimerButton.Click += new System.EventHandler(this.TimerButton_Click);
            // 
            // TimerTextBox
            // 
            this.TimerTextBox.Location = new System.Drawing.Point(96, 103);
            this.TimerTextBox.Name = "TimerTextBox";
            this.TimerTextBox.Size = new System.Drawing.Size(132, 23);
            this.TimerTextBox.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AlarmTimePicker
            // 
            this.AlarmTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.AlarmTimePicker.Location = new System.Drawing.Point(96, 192);
            this.AlarmTimePicker.Name = "AlarmTimePicker";
            this.AlarmTimePicker.Size = new System.Drawing.Size(132, 23);
            this.AlarmTimePicker.TabIndex = 5;
            // 
            // AlarmLabel
            // 
            this.AlarmLabel.AutoSize = true;
            this.AlarmLabel.Location = new System.Drawing.Point(34, 174);
            this.AlarmLabel.Name = "AlarmLabel";
            this.AlarmLabel.Size = new System.Drawing.Size(263, 15);
            this.AlarmLabel.TabIndex = 6;
            this.AlarmLabel.Text = "Set and Alarm using the dropdown menu below:";
            // 
            // SetAlarmButton
            // 
            this.SetAlarmButton.Location = new System.Drawing.Point(63, 239);
            this.SetAlarmButton.Name = "SetAlarmButton";
            this.SetAlarmButton.Size = new System.Drawing.Size(96, 23);
            this.SetAlarmButton.TabIndex = 7;
            this.SetAlarmButton.Text = "Set Alarm";
            this.SetAlarmButton.UseVisualStyleBackColor = true;
            this.SetAlarmButton.Click += new System.EventHandler(this.SetAlarmButton_Click);
            // 
            // StopAlarmButton
            // 
            this.StopAlarmButton.Location = new System.Drawing.Point(165, 239);
            this.StopAlarmButton.Name = "StopAlarmButton";
            this.StopAlarmButton.Size = new System.Drawing.Size(96, 23);
            this.StopAlarmButton.TabIndex = 8;
            this.StopAlarmButton.Text = "Stop Alarm";
            this.StopAlarmButton.UseVisualStyleBackColor = true;
            this.StopAlarmButton.Click += new System.EventHandler(this.StopAlarmButton_Click);
            // 
            // AlarmRunningLabel
            // 
            this.AlarmRunningLabel.AutoSize = true;
            this.AlarmRunningLabel.Location = new System.Drawing.Point(136, 221);
            this.AlarmRunningLabel.Name = "AlarmRunningLabel";
            this.AlarmRunningLabel.Size = new System.Drawing.Size(48, 15);
            this.AlarmRunningLabel.TabIndex = 9;
            this.AlarmRunningLabel.Text = "Status...";
            // 
            // AlarmTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(333, 294);
            this.Controls.Add(this.AlarmRunningLabel);
            this.Controls.Add(this.StopAlarmButton);
            this.Controls.Add(this.SetAlarmButton);
            this.Controls.Add(this.AlarmLabel);
            this.Controls.Add(this.AlarmTimePicker);
            this.Controls.Add(this.TimerTextBox);
            this.Controls.Add(this.TimerButton);
            this.Controls.Add(this.TimerCountLabel);
            this.Controls.Add(this.TimerTextLabel);
            this.Name = "AlarmTimer";
            this.Text = "AlarmTimer";
            this.Load += new System.EventHandler(this.AlarmTimer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label TimerTextLabel;
        private Label TimerCountLabel;
        private Button TimerButton;
        private TextBox TimerTextBox;
        private Timer timer1;
        private DateTimePicker AlarmTimePicker;
        private Label AlarmLabel;
        private Button SetAlarmButton;
        private Button StopAlarmButton;
        private Label AlarmRunningLabel;
    }
}