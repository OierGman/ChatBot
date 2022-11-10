using Google.Cloud.Speech.V1;
using Google.Type;
using NAudio.Wave;
using static Google.Rpc.Context.AttributeContext.Types;
using static System.Net.Mime.MediaTypeNames;

namespace Chatbot
{
    public partial class Form1 : Form
    {
        private BufferedWaveProvider bwp;
        String TaskHolder;
        List<String> TaskList = new List<String>();
        WaveIn waveIn;
        WaveOut waveOut;
        WaveFileWriter writer;
        WaveFileReader reader;
        string output = "audio.raw";
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
            waveOut = new WaveOut();
            waveIn = new WaveIn();

            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
            bwp = new BufferedWaveProvider(waveIn.WaveFormat);
            bwp.DiscardOnBufferOverflow = true;
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            #region TaskDummyData
            TaskList.Add("Prepare for OOP Mocks, 05/12/22");
            TaskList.Add("Complete Database Logbooks, 16/12/22");
            TaskList.Add("Complete OOP Assignment 1, 10/01/23");
            #endregion
        }
        // user message button click event
        public void messageButton_Click(object sender, EventArgs e)
        {
            TextBox message = new TextBox()
            {
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Multiline = true,
                Text = userInputBox.Text,
            };
            userInputBox.Text = "";
            ChatLogController(message, 1);
            ChatDecider(message.Text);
            // ChatBotEngine.BankHolidays();
            // ChatBotEngine.Joke();
        }
        /// <summary>
        /// The user input is filtered, and tasks/methods called depending on keywords.
        /// </summary>
        /// <param name="messageText">User input.</param>
        private async void ChatDecider(string messageText)
        {
            // convert user input to lower case to remove capitilisation errors 
            messageText = messageText.ToLower();
            if (messageText.Contains("play"))
            {
                string keyWord = messageText.Remove(0, 5);
                YouTubeAPI(keyWord);
            }
            // search user input for to do list key words in order to add task 
            else if (messageText.Contains("task"))
            {
                ToDoList();
            }
            // search for a combination of keywords to display to do list
            else if (messageText.Contains("show") && messageText.Contains("to do"))
            {
                ShowToDoList();
            }
            else
            {
                await ChatBotEngine.MrChat(messageText);
                BotResponse(null);
            }

        }

        private void ShowToDoList()
        {
            
            int TaskCount = TaskList.Count;
            for (int i = 0; i < TaskCount; i++)
            {
                
                TextBox ShowListMessage = new TextBox()
                {
                    ReadOnly = true,
                    Dock = DockStyle.Fill,
                    Multiline = true,
                };
                TaskHolder = TaskList[i].ToString();
                ShowListMessage.Text = TaskHolder;
                ChatLogController(ShowListMessage,0);
                
            }
            
        }

        public async void ToDoList()
        {
            /*String Task;
            Task= messageText.Remove(0, 7) ;
            TaskList.Add(Task);
            TextBox Message = new TextBox()
            {
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Multiline = true,
            };
            Message.Text = "Task successfully added";
            ChatLogController(Message, 0);*/
            
            TextBox BotMessage = new TextBox();
            BotMessage.Text = "What would you like to call this task?";
            BotMessage.ReadOnly = true;
            BotMessage.Dock = DockStyle.Fill;
            BotMessage.Multiline = true;
            ChatLogController(BotMessage,0);

            
        }
       

        /// <summary>
        /// Chatty will respond with a result, depending on which method called it.
        /// </summary>
        /// <param name="response">Response from method call.</param>
        public async Task BotResponse(string response)
        {
            TextBox message1 = new TextBox()
            {
                ReadOnly = true,
                Dock = DockStyle.Fill,
                Multiline = true,
            };
            if (response != null)
            {
                message1.Text = response;
                ChatLogController(message1, 0);
            }
            else
            {
                message1.Text = APIObjects.MrChat.chat[0].result;
                ChatLogController(message1, 0);
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
        }
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);

        }
        /// <summary>
        /// Records voice audio file on mouse click down.
        /// </summary>
        private void btnRecordVoice_MouseDown(object sender, MouseEventArgs e)
        {
            if (NAudio.Wave.WaveIn.DeviceCount < 1)
            {
                Console.WriteLine("No microphone.");
                return;
            }
            waveIn = new WaveIn();
            waveOut = new WaveOut();
            waveIn = new WaveIn();
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
            bwp = new BufferedWaveProvider(waveIn.WaveFormat);
            bwp.DiscardOnBufferOverflow = true;
            waveIn.StartRecording();
        }
        /// <summary>
        /// Sends audio file to Google Cloud Speech-to-Text API for transcription.
        /// </summary>
        private void btnRecordVoice_MouseUp(object sender, MouseEventArgs e)
        {
            waveIn.StopRecording();

            if (File.Exists("audio.raw"))
                File.Delete("audio.raw");

            writer = new WaveFileWriter(output, waveIn.WaveFormat);

            byte[] buffer = new byte[bwp.BufferLength];
            int offset = 0;
            int count = bwp.BufferLength;

            var read = bwp.Read(buffer, offset, count);
            if (count > 0)
            {
                writer.Write(buffer, offset, read);
            }

            waveIn.Dispose();
            waveIn = null;
            writer.Close();
            writer = null;

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