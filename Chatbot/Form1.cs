using Google.Cloud.Speech.V1;
using NAudio.Wave;

namespace Chatbot
{
    public partial class Form1 : Form
    {
        private BufferedWaveProvider bwp;

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

            btnRecordVoice.Enabled = true;
            btnSave.Enabled = false;
            btnSpeechInfo.Enabled = false;
        }
        // user message button click event
        private async void messageButton_Click(object sender, EventArgs e)
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
            await ChatBotEngine.MrChat(message.Text);
        }

        private void ChatDecider(string messageText)
        {
            if (messageText.Contains("play") | messageText.Contains("Play"))
            {
                string keyWord = messageText.Remove(0, 5);
                YouTubeAPI(keyWord);
            }
        }

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

        public async void YouTubeAPI(string keyWord)
        {
            try
            {
                string test = await new ChatBotEngine().YouTubeMusic(keyWord);
                BotResponse(test);
            }
            catch (AggregateException ex)
            {
                BotResponse("Sorry I couldn't find that");
            }
        }

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
            ChatLogController(message, 1);
        }

        private void btnRecordVoice_Click(object sender, EventArgs e)
        {
            if (NAudio.Wave.WaveIn.DeviceCount < 1)
            {
                Console.WriteLine("No microphone!");
                return;
            }

            waveIn.StartRecording();

            btnRecordVoice.Enabled = false;
            btnSave.Enabled = true;
            btnSpeechInfo.Enabled = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            waveIn.StopRecording();

            if (File.Exists("audio.raw"))
                File.Delete("audio.raw");

            writer = new WaveFileWriter(output, waveIn.WaveFormat);

            btnRecordVoice.Enabled = false;
            btnSave.Enabled = false;
            btnSpeechInfo.Enabled = true;

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

            reader = new WaveFileReader("audio.raw"); // (new MemoryStream(bytes));
            waveOut.Init(reader);
            waveOut.PlaybackStopped += new EventHandler<StoppedEventArgs>(waveOut_PlaybackStopped);
            waveOut.Play();


        }
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);

        }
        private void waveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            waveOut.Stop();
            reader.Close();
            reader = null;
        }

        private void btnSpeechInfo_Click(object sender, EventArgs e)
        {

            btnRecordVoice.Enabled = true;
            btnSave.Enabled = false;
            btnSpeechInfo.Enabled = false;

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

                if (userInputBox.Text.Length == 0)
                    userInputBox.Text = "No Data ";

            }
            else
            {

                userInputBox.Text = "Audio File Missing ";

            }


        }

        private void btnPlayAudio_Click(object sender, EventArgs e)
        {
            if (File.Exists("audio.raw"))
            {
                reader = new WaveFileReader("audio.raw");
                waveOut.Init(reader);
                waveOut.Play();
            }
            else
            {
                MessageBox.Show("No Audio File Found");
            }
        }

    }
}