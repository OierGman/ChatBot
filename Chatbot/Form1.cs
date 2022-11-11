using Chatbot.APIObjects;
using Google.Cloud.Speech.V1;
using NAudio.Wave;
using System.Speech.Synthesis;

namespace Chatbot
{
    public partial class Form1 : Form
    {
        private BufferedWaveProvider _bwp;
        public WaveIn In { get; private set; }
        public WaveOut Out { get; private set; }

        private WaveFileWriter _writer;

        private TextBox _message = new TextBox();
        private TextBox _messageBot = new TextBox();

        private const string Output = "audio.raw";

        public Form1()
        {
            InitializeComponent();
            // initialize with welcome chatbot message
            Out = new WaveOut();
            In = new WaveIn();
            In.DataAvailable += waveIn_DataAvailable;
            In.WaveFormat = new WaveFormat(16000, 1);
            _bwp = new BufferedWaveProvider(In.WaveFormat);
            _bwp.DiscardOnBufferOverflow = true;
            BotResponse("Hello! I'm Chatty, your personal assistant! How can I help?");
        }
        // user message button click event
        private void messageButton_Click(object sender, EventArgs e)
        {
            _message.ReadOnly = true;
            _message.Dock = DockStyle.Fill;
            _message.Multiline = true;
            _message.Text = userInputBox.Text;
            if (_message.Text == "")
            {
                return;
            } else if (_message.Text == "Say something")
            {
                return;
            }

            userInputBox.Text = "";
            ChatLogController(_message, 1);
            ChatDecider(_message.Text);
        }
        /// <summary>
        /// The user input is filtered, and tasks/methods called by depending on keywords.
        /// </summary>
        /// <param name="messageText">User input.</param>
        private async void ChatDecider(string messageText)
        {
            if (messageText.Contains("play") || messageText.Contains("Play"))
            {
                string keyWord = messageText.Remove(0, 5);
                YouTubeAPI(keyWord);
            } else if (messageText.Contains("bank holiday"))
            {
                await ChatBotEngine.BankHolidays();
                string str = null;
                foreach (var eEvent in BankHolidays.bankHolidays)
                {
                    str += eEvent.date + " " + eEvent.title + "\r\n";    //store the holiday events in the string
                }
                BotResponse("Here are all the confirmed bank holidays I know of");
                MessageBox.Show(str);
            }
            else
            {
                if (MrChat.chat.Count == 0)
                {
                    await ChatBotEngine.MrChat(messageText);
                    BotResponse(null);
                }
                else
                {
                    // try catch
                    try
                    {
                        await ChatBotEngine.Converse(messageText, MrChat.chat[0].conversationID, MrChat.chat[0].host);
                        BotResponse(null);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// Chatty will respond with a result, depending on which method called it.
        /// </summary>
        /// <param name="response">Response from method call.</param>
        public void BotResponse(string response)
        {
            _messageBot.ReadOnly = true;
            _messageBot.Dock = DockStyle.Fill;
            _messageBot.Multiline = true;

            if (response != null)
            {
                _messageBot.Text = response;
                ChatLogController(_messageBot, 0);
            }
            else
            {
                if (MrChat.chat[0].result == null)
                {
                    _messageBot.Text = "Sorry, I do not understand, could you ask me differently?";
                    ChatLogController(_messageBot, 0);
                }
                else
                {
                    _messageBot.Text = MrChat.chat[0].result;
                    ChatLogController(_messageBot, 0);
                }
            }
            
        }
        /// <summary>
        /// This method takes a string and parses to the youtube api, returns title of video, as well as opening youtube link via Task.
        /// </summary>
        /// <param name="keyWord">The keywords of the request to play</param>
        public async void YouTubeAPI(string keyWord)
        {
            try
            {
                string title = await new ChatBotEngine().YouTubeMusic(keyWord);
                BotResponse("Ok! I have found the most appropriate to your request! " + title);
            }
            catch (AggregateException ex)
            {
                BotResponse("Sorry I couldn't find anything for your request!");
            }
        }
        /// <summary>
        /// This creates and displays the chatlog functionality.
        /// </summary>
        /// <param name="message">A message as a Textbox</param>
        /// <param name="i">Index of message.</param>
        private void ChatLogController(TextBox message, int i)
        {
            var botMessageOne = chatLogTable.GetControlFromPosition(0, 3);
            var botMessageTwo = chatLogTable.GetControlFromPosition(0, 2);
            var botMessageThree = chatLogTable.GetControlFromPosition(0, 1);
            chatLogTable.Controls.Remove(chatLogTable.GetControlFromPosition(0, 0));
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
                chatLogTable.Controls.Add(userMessageTwo, 1, 1);
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

            chatLogTable.Controls.Add(message, i, 3);
            if (i == 0)
            {
                SpeechSynthesizer speechSynthesis = new SpeechSynthesizer();
                speechSynthesis.Speak(_messageBot.Text);
            }
        }
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            _bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);

        }
        /// <summary>
        /// Records voice audio file on mouse click down.
        /// </summary>
        private void btnRecordVoice_MouseDown(object sender, MouseEventArgs e)
        {
            if (WaveIn.DeviceCount < 1)
            {
                Console.WriteLine("No microphone.");
                return;
            }
            In = new WaveIn();
            Out = new WaveOut();
            In.DataAvailable += waveIn_DataAvailable;
            In.WaveFormat = new WaveFormat(16000, 1);
            _bwp = new BufferedWaveProvider(In.WaveFormat);
            _bwp.DiscardOnBufferOverflow = true;
            In.StartRecording();
        }
        /// <summary>
        /// Sends audio file to Google Cloud Speech-to-Text API for transcription.
        /// </summary>
        private void btnRecordVoice_MouseUp(object sender, MouseEventArgs e)
        {
            In.StopRecording();

            if (File.Exists("audio.raw"))
                File.Delete("audio.raw");

            _writer = new WaveFileWriter(Output, In.WaveFormat);

            byte[] buffer = new byte[_bwp.BufferLength];
            int offset = 0;
            int count = _bwp.BufferLength;

            var read = _bwp.Read(buffer, offset, count);
            if (count > 0)
            {
                _writer.Write(buffer, offset, read);
            }

            In.Dispose();
            In = null;
            _writer.Close();
            _writer = null;

            if (File.Exists("audio.raw"))
            {
                string fileName = "core-spring-367614-171243f0ad13.json";
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
                string path = Path.Combine(projectDirectory, fileName);
                string credential_path = path;
                System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);
                var speech = SpeechClient.Create();
                var response = speech.Recognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    SampleRateHertz = 16000,
                    LanguageCode = "en",
                }, RecognitionAudio.FromFile("audio.raw"));


                userInputBox.Text = "";

                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        userInputBox.Text = userInputBox.Text + " " + alternative.Transcript;
                    }
                }
            }

            messageButton_Click(this, e);
        }
    }
}