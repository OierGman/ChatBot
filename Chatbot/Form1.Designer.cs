namespace Chatbot
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.userInputBox = new System.Windows.Forms.TextBox();
            this.messageButton = new System.Windows.Forms.Button();
            this.chatLogTable = new System.Windows.Forms.TableLayoutPanel();
            this.round1 = new Chatbot.Round();
            this.round2 = new Chatbot.Round();
            this.btnRecordVoice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chatLogTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // userInputBox
            // 
            this.userInputBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.userInputBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userInputBox.Location = new System.Drawing.Point(10, 342);
            this.userInputBox.Margin = new System.Windows.Forms.Padding(2, 3, 3, 2);
            this.userInputBox.Multiline = true;
            this.userInputBox.Name = "userInputBox";
            this.userInputBox.PlaceholderText = "Say Something";
            this.userInputBox.Size = new System.Drawing.Size(280, 100);
            this.userInputBox.TabIndex = 1;
            this.userInputBox.Text = "hello";
            // 
            // messageButton
            // 
            this.messageButton.Location = new System.Drawing.Point(383, 342);
            this.messageButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.messageButton.Name = "messageButton";
            this.messageButton.Size = new System.Drawing.Size(87, 99);
            this.messageButton.TabIndex = 2;
            this.messageButton.Text = "Send Message";
            this.messageButton.UseVisualStyleBackColor = true;
            this.messageButton.Click += new System.EventHandler(this.messageButton_Click);
            // 
            // chatLogTable
            // 
            this.chatLogTable.BackColor = System.Drawing.Color.LightBlue;
            this.chatLogTable.ColumnCount = 2;
            this.chatLogTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.chatLogTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.chatLogTable.Controls.Add(this.round1, 1, 0);
            this.chatLogTable.Controls.Add(this.round2, 1, 1);
            this.chatLogTable.Location = new System.Drawing.Point(10, 28);
            this.chatLogTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chatLogTable.Name = "chatLogTable";
            this.chatLogTable.RowCount = 4;
            this.chatLogTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chatLogTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chatLogTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chatLogTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chatLogTable.Size = new System.Drawing.Size(459, 310);
            this.chatLogTable.TabIndex = 3;
            // 
            // round1
            // 
            this.round1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.round1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.round1.Location = new System.Drawing.Point(232, 3);
            this.round1.Multiline = true;
            this.round1.Name = "round1";
            this.round1.Size = new System.Drawing.Size(224, 71);
            this.round1.TabIndex = 0;
            // 
            // round2
            // 
            this.round2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.round2.Location = new System.Drawing.Point(232, 80);
            this.round2.Name = "round2";
            this.round2.Size = new System.Drawing.Size(224, 23);
            this.round2.TabIndex = 1;
            // 
            // btnRecordVoice
            // 
            this.btnRecordVoice.Location = new System.Drawing.Point(296, 342);
            this.btnRecordVoice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRecordVoice.Name = "btnRecordVoice";
            this.btnRecordVoice.Size = new System.Drawing.Size(82, 99);
            this.btnRecordVoice.TabIndex = 4;
            this.btnRecordVoice.Text = "Voice";
            this.btnRecordVoice.UseVisualStyleBackColor = true;
            this.btnRecordVoice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRecordVoice_MouseDown);
            this.btnRecordVoice.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRecordVoice_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mr Chatty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(441, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "You";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(487, 459);
            this.panel1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(482, 456);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRecordVoice);
            this.Controls.Add(this.chatLogTable);
            this.Controls.Add(this.messageButton);
            this.Controls.Add(this.userInputBox);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(498, 495);
            this.MinimumSize = new System.Drawing.Size(498, 495);
            this.Name = "Form1";
            this.Text = "Chatty";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.chatLogTable.ResumeLayout(false);
            this.chatLogTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox userInputBox;
        private Button messageButton;
        private TableLayoutPanel chatLogTable;
        private Button btnRecordVoice;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private Round round1;
        private Round round2;
    }
}