namespace Chatbot
{
    partial class AlarmTimer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.SuspendLayout();
            // 
            // TimerTextLabel
            // 
            this.TimerTextLabel.AutoSize = true;
            this.TimerTextLabel.Location = new System.Drawing.Point(56, 309);
            this.TimerTextLabel.Name = "TimerTextLabel";
            this.TimerTextLabel.Size = new System.Drawing.Size(172, 15);
            this.TimerTextLabel.TabIndex = 1;
            this.TimerTextLabel.Text = "Enter your timer duration here: ";
            // 
            // TimerCountLabel
            // 
            this.TimerCountLabel.AutoSize = true;
            this.TimerCountLabel.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TimerCountLabel.Location = new System.Drawing.Point(235, 188);
            this.TimerCountLabel.Name = "TimerCountLabel";
            this.TimerCountLabel.Size = new System.Drawing.Size(132, 65);
            this.TimerCountLabel.TabIndex = 2;
            this.TimerCountLabel.Text = "0000";
            // 
            // TimerButton
            // 
            this.TimerButton.Location = new System.Drawing.Point(373, 305);
            this.TimerButton.Name = "TimerButton";
            this.TimerButton.Size = new System.Drawing.Size(75, 23);
            this.TimerButton.TabIndex = 3;
            this.TimerButton.Text = "Start";
            this.TimerButton.UseVisualStyleBackColor = true;
            // 
            // TimerTextBox
            // 
            this.TimerTextBox.Location = new System.Drawing.Point(234, 306);
            this.TimerTextBox.Name = "TimerTextBox";
            this.TimerTextBox.Size = new System.Drawing.Size(133, 23);
            this.TimerTextBox.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // AlarmTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(600, 445);
            this.Controls.Add(this.TimerTextBox);
            this.Controls.Add(this.TimerButton);
            this.Controls.Add(this.TimerCountLabel);
            this.Controls.Add(this.TimerTextLabel);
            this.Name = "AlarmTimer";
            this.Text = "AlarmTimer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label TimerTextLabel;
        private Label TimerCountLabel;
        private Button TimerButton;
        private TextBox TimerTextBox;
        private System.Windows.Forms.Timer timer1;
    }
}