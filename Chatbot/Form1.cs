namespace Chatbot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // initialize with welcome chatbot message
            chatLogTable.Controls.Add(new TextBox()
            {
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Multiline = true,
                Text = "Hello! I'm Chatty, your personal assistant! How can I help?"
            }, 0, 3);
        }
        // user message button click event
        private void messageButton_Click(object sender, EventArgs e)
        {
            TextBox message = new TextBox()
            {
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Multiline = true,
                Text = userInputBox.Text,
            };
            userInputBox.Text = "";
            ChatLogController(message);

            ChatApiDecider(message.Text);

            //ChatBotEngine.BankHolidays().Wait();

        }

        private void ChatApiDecider(string messageText)
        {
            if(messageText.Contains("play"))
            {
                string keyWord = messageText.Remove(0,5);
                YouTubeAPI(keyWord);
            ChatBotEngine.Joke();
            }
        }

        public static void YouTubeAPI(string keyWord)
        {
            try
            {
                new ChatBotEngine().YouTubeMusic(keyWord);
            }
            catch (AggregateException ex)
            {
                
            }
        }

        private void ChatLogController(TextBox message)
        {
            var botMessageOne = chatLogTable.GetControlFromPosition(0, 3);
            var botMessageTwo = chatLogTable.GetControlFromPosition(0, 2);
            var botMessageThree = chatLogTable.GetControlFromPosition(0, 1);
            chatLogTable.Controls.Remove(chatLogTable.GetControlFromPosition(0,0));
            var userMessageOne = chatLogTable.GetControlFromPosition(1, 3);
            var userMessageTwo = chatLogTable.GetControlFromPosition(1, 2);
            var userMessageThree = chatLogTable.GetControlFromPosition(1, 1);
            chatLogTable.Controls.Remove(chatLogTable.GetControlFromPosition(1, 0));
            // no 1 2, 0 3, 0 2, 0 0
            chatLogTable.Controls.Clear();
            try
            {
                chatLogTable.Controls.Add(botMessageOne, 0, 2);
            }
            catch (Exception ex)
            {

            }

            try
            {
                chatLogTable.Controls.Add(botMessageTwo, 0, 1);
            }
            catch (Exception ex)
            {

            }
            try
            {
                chatLogTable.Controls.Add(botMessageThree, 0, 0);
            }
            catch (Exception ex)
            {

            }
            try
            {
                chatLogTable.Controls.Add(userMessageOne, 1, 2);
            }
            catch (Exception ex)
            {

            }

            try
            {
                chatLogTable.Controls.Add(userMessageTwo, 1,1);
            }
            catch (Exception ex)
            {

            }
            try
            {
                chatLogTable.Controls.Add(userMessageThree, 1, 0);
            }
            catch (Exception ex)
            {

            }

            chatLogTable.Controls.Add(message, 1, 3);
        }

        private void userInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) // guard statement to return early
            {
                return;
            }
            TextBox message = new TextBox()
            {
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Multiline = true,
                Text = userInputBox.Text,
            };
            userInputBox.Text = "";
            ChatLogController(message);
        }
    }
}