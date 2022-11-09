﻿namespace Chatbot
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
            this.btnRecordVoice = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userInputBox
            // 
            this.userInputBox.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userInputBox.Location = new System.Drawing.Point(12, 456);
            this.userInputBox.Multiline = true;
            this.userInputBox.Name = "userInputBox";
            this.userInputBox.Size = new System.Drawing.Size(320, 132);
            this.userInputBox.TabIndex = 1;
            this.userInputBox.Text = "Say something";
            // 
            // messageButton
            // 
            this.messageButton.Location = new System.Drawing.Point(438, 456);
            this.messageButton.Name = "messageButton";
            this.messageButton.Size = new System.Drawing.Size(99, 132);
            this.messageButton.TabIndex = 2;
            this.messageButton.Text = "Send Message";
            this.messageButton.UseVisualStyleBackColor = true;
            this.messageButton.Click += new System.EventHandler(this.messageButton_Click);
            // 
            // chatLogTable
            // 
            this.chatLogTable.ColumnCount = 2;
            this.chatLogTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.chatLogTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.chatLogTable.Location = new System.Drawing.Point(12, 37);
            this.chatLogTable.Name = "chatLogTable";
            this.chatLogTable.RowCount = 4;
            this.chatLogTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chatLogTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chatLogTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chatLogTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chatLogTable.Size = new System.Drawing.Size(525, 413);
            this.chatLogTable.TabIndex = 3;
            // 
            // btnRecordVoice
            // 
            this.btnRecordVoice.Location = new System.Drawing.Point(338, 456);
            this.btnRecordVoice.Name = "btnRecordVoice";
            this.btnRecordVoice.Size = new System.Drawing.Size(94, 132);
            this.btnRecordVoice.TabIndex = 4;
            this.btnRecordVoice.Text = "Voice";
            this.btnRecordVoice.UseVisualStyleBackColor = true;
            this.btnRecordVoice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRecordVoice_MouseDown);
            this.btnRecordVoice.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRecordVoice_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mr Chatty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(504, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "You";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(549, 600);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRecordVoice);
            this.Controls.Add(this.chatLogTable);
            this.Controls.Add(this.messageButton);
            this.Controls.Add(this.userInputBox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(567, 647);
            this.MinimumSize = new System.Drawing.Size(567, 647);
            this.Name = "Form1";
            this.Text = "Chatty";
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
    }
}