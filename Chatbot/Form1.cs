using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using Chatbot.APIObjects;
using Google.Cloud.Speech.V1;
using NAudio.Wave;

namespace Chatbot
{
    public partial class Form1 : Form
    {
        private string _taskHolder;
        private readonly List<string> _taskList = new List<string>();
        bool _taskCheck;
        int _count;
        string _task;
        private BufferedWaveProvider _bwp;
        public WaveIn In { get; private set; }
        public WaveOut Out { get; private set; }
        private WaveFileWriter _writer;
        string _messageBot;
        private const string _output = "audio.raw";
        bool _talkingBot;
        SpeechSynthesizer speechSynthesis = new SpeechSynthesizer();

        public Form1()
        {
            InitializeComponent();
            AllocConsole();
            // initialize with welcome chatbot message
            chatLogTable.Controls.Add(new Round
            {
                ReadOnly = true,
                Multiline = true,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightBlue,
                TextAlign = HorizontalAlignment.Center,
                Dock = DockStyle.Fill,
                Text = "\r\n" + "Hello! I'm Chatty, your personal assistant! How can I help?"
            }, 0, 3);

            Out = new WaveOut();
            In = new WaveIn();

            In.DataAvailable += waveIn_DataAvailable;
            In.WaveFormat = new WaveFormat(16000, 1);
            _bwp = new BufferedWaveProvider(In.WaveFormat)
            {
                DiscardOnBufferOverflow = true
            };
        }
        private void userInputBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                messageButton.PerformClick();
            }
        }
        // user message button click event
        public void messageButton_Click(object sender, EventArgs e)
        {
            if (_taskCheck)
            {
                ToDoList();
            }


            if (userInputBox.Text == "")
            {
                return;
            }

            if (userInputBox.Text == "Say something")
            {
                return;
            }

            ChatLogController(new Round
            {
                ReadOnly = true,
                Multiline = true,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                TextAlign = HorizontalAlignment.Center,
                Size = new Size(257, 97),
                BackColor = Color.LimeGreen,
                Text = "\r\n" + userInputBox.Text
            }, 1);
            string str = userInputBox.Text;
            var charsToRemove = new string[] { "#" };
            foreach (var c in charsToRemove)
            {
                str = str.Replace(c, string.Empty);
            }

            ChatDecider(str);
            userInputBox.Text = "";
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
            else if (messageText.Contains("speak to me"))
            {
                _talkingBot = true;
                BotResponse("Ok, I will start speaking to you");
            }
            else if (messageText.Contains("stop speaking"))
            {
                BotResponse("Ok, I will stop speaking to you");
                _talkingBot = false;
            }
            else if (messageText.Contains("word") && messageText.Contains("day"))
            {
                await ChatBotEngine.Word();
                //await ChatBotEngine.GetDef("pie");

                while (true)
                {
                    await ChatBotEngine.Word();

                    try
                    {
                        await ChatBotEngine.GetDef(Word.word[0]);
                        Console.WriteLine(Definitions.Defs[0].definitions[0].definition);
                        break;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                BotResponse(Word.word[0]);
                BotResponse(Definitions.Defs[0].definitions[0].definition);
            }
            else if (messageText.Contains("timer"))
            {
                AlarmTimer x = new AlarmTimer();
                x.Show();
                // clear input & return message
                userInputBox.Text = "";
                BotResponse("Here is the timer system I have");
            }
            else if (messageText.Contains("bank holiday"))
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
            // search user input for to do list key words in order to add TaskCheck 
            else if (messageText.Contains("task"))
            {
                ToDoList();
                userInputBox.Text = "";
            }
            // search for a combination of keywords to display to do list
            else if (messageText.Contains("show") && messageText.Contains("to do"))
            {
                ShowToDoList();
                userInputBox.Text = "";
            }
            else
            {
                if (MrChat.Chat.Count == 0)
                {
                    await ChatBotEngine.MrChat(messageText);
                    BotResponse(null);
                }
                else
                {
                    // try catch
                    try
                    {
                        await ChatBotEngine.Converse(messageText, MrChat.Chat[0].conversationID, MrChat.Chat[0].host);
                        BotResponse(null);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }

        }

        private void ShowToDoList()
        {
            int taskCount = _taskList.Count;
            for (int i = 0; i < taskCount; i++)
            {
                _taskHolder = _taskList[i];
                ChatLogController(new Round
                {
                    ReadOnly = true,
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    TextAlign = HorizontalAlignment.Center,
                    Size = new Size(257, 97),
                    BackColor = Color.LightBlue,
                    Text = "\r\n" + _taskHolder
                }, 0);
                userInputBox.Text = "";
            }

        }

        public void ToDoList()
        {
            _taskCheck = true;

            if (_count == 0)
            {
                ChatLogController(new Round
                {
                    ReadOnly = true,
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    TextAlign = HorizontalAlignment.Center,
                    Size = new Size(257, 97),
                    BackColor = Color.LightBlue,
                    Text = "\r\n" + "What would you like to call this task?"
                }, 0);
                
                _messageBot = "What would you like to call this task?";
                /*
                if (_talkingBot)
                {
                    speechSynthesis.Speak(_messageBot);
                }
                */
                userInputBox.Text = "";
            }
            else if (_count == 1)
            {
                _task = userInputBox.Text;
                ChatLogController(new Round
                {
                    ReadOnly = true,
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    TextAlign = HorizontalAlignment.Center,
                    Size = new Size(257, 97),
                    BackColor = Color.LimeGreen,
                    Text = "\r\n" + userInputBox.Text
                }, 1);

                ChatLogController(new Round
                {
                    ReadOnly = true,
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    TextAlign = HorizontalAlignment.Center,
                    Size = new Size(257, 97),
                    BackColor = Color.LightBlue,
                    Text = "\r\n" + "When is this task due?"
                }, 0);
                _messageBot = "When is this task due?";
                /*
                if (_talkingBot)
                {
                    speechSynthesis.Speak(_messageBot);
                }
                */
                userInputBox.Text = "";

            }
            else
            {
                _task = _task + ", " + userInputBox.Text;
                _taskList.Add(_task);


                ChatLogController(new Round
                {
                    ReadOnly = true,
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    TextAlign = HorizontalAlignment.Center,
                    Size = new Size(257, 97),
                    BackColor = Color.LimeGreen,
                    Text = "\r\n" + userInputBox.Text
                }, 1);
                userInputBox.Text = "";

                ChatLogController(new Round
                {
                    ReadOnly = true,
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    TextAlign = HorizontalAlignment.Center,
                    Size = new Size(257, 97),
                    BackColor = Color.LightBlue,
                    Text = "\r\n" + "Task Added successfully!"
                }, 0);
                _messageBot = "Task Added successfully!";
                _taskCheck = false;
                userInputBox.Text = "";
            }
            if (_talkingBot)
            {
                speechSynthesis.Speak(_messageBot);
            }
            ++_count;
        }


        /// <summary>
        /// Chatty will respond with a result, depending on which method called it.
        /// </summary>
        /// <param name="response">Response from method call.</param>
        public Task? BotResponse(string response)
        {
            if (response != null)
            {
                _messageBot = response;
                ChatLogController(new Round
                {
                    ReadOnly = true,
                    Multiline = true,
                    Dock = DockStyle.Fill,
                    BorderStyle = BorderStyle.None,
                    TextAlign = HorizontalAlignment.Center,
                    Size = new Size(257, 97),//224,71,
                    BackColor = Color.LightBlue,
                    Text = "\r\n" + response
                }, 0);
            }
            else
            {
                if (MrChat.Chat[0].result == null)
                {
                    _messageBot = "Sorry, I do not understand, could you ask me differently?";
                    ChatLogController(new Round
                    {
                        ReadOnly = true,
                        Multiline = true,
                        Dock = DockStyle.Fill,
                        BorderStyle = BorderStyle.None,
                        TextAlign = HorizontalAlignment.Center,
                        Size = new Size(257, 97),//224,71,
                        BackColor = Color.LightBlue,
                        Text = "\r\n" + "Sorry, I do not understand, could you ask me differently?"
                    }, 0);
                }
                else
                {
                    _messageBot = MrChat.Chat[0].result;

                    if (MrChat.Chat[0].result.Length > 95)
                    {
                        string i = MrChat.Chat[0].result.Substring(95);
                        int x = i.IndexOf(' ');
                        string y = MrChat.Chat[0].result.Substring(0, 95 + x);
                        string z = MrChat.Chat[0].result.Substring(95 + x);
                        if (i.Length > 95)
                        {
                            string j = z.Substring(95);
                            int k = j.IndexOf(' ');
                            string l = MrChat.Chat[0].result.Substring(0, 95 + x);
                            string m = z.Substring(0, 95 + k);
                            string n = z.Substring(95 + k);

                            ChatLogController(new Round
                            {
                                ReadOnly = true,
                                Multiline = true,
                                Dock = DockStyle.Fill,
                                BorderStyle = BorderStyle.None,
                                TextAlign = HorizontalAlignment.Center,
                                Size = new Size(257, 97),//224,71,
                                BackColor = Color.LightBlue,
                                Text = "\r\n" + l
                            }, 0);
                            ChatLogController(new Round
                            {
                                ReadOnly = true,
                                Multiline = true,
                                Dock = DockStyle.Fill,
                                BorderStyle = BorderStyle.None,
                                TextAlign = HorizontalAlignment.Center,
                                Size = new Size(257, 97),//224,71,
                                BackColor = Color.LightBlue,
                                Text = "\r\n" + m
                            }, 0);
                            ChatLogController(new Round
                            {
                                ReadOnly = true,
                                Multiline = true,
                                Dock = DockStyle.Fill,
                                BorderStyle = BorderStyle.None,
                                TextAlign = HorizontalAlignment.Center,
                                Size = new Size(257, 97),//224,71,
                                BackColor = Color.LightBlue,
                                Text = "\r\n" + n
                            }, 0);
                        }
                        else
                        {
                        ChatLogController(new Round
                        {
                            ReadOnly = true,
                            Multiline = true,
                            Dock = DockStyle.Fill,
                            BorderStyle = BorderStyle.None,
                            TextAlign = HorizontalAlignment.Center,
                            Size = new Size(257, 97),//224,71,
                            BackColor = Color.LightBlue,
                            Text = "\r\n" + y
                        }, 0);

                        ChatLogController(new Round
                        {
                            ReadOnly = true,
                            Multiline = true,
                            Dock = DockStyle.Fill,
                            BorderStyle = BorderStyle.None,
                            TextAlign = HorizontalAlignment.Center,
                            Size = new Size(257, 97),//224,71,
                            BackColor = Color.LightBlue,
                            Text = "\r\n" + z
                        }, 0);
                        }
                        //string i = MrChat.Chat[0].result.Substring(100, MrChat.Chat[0].result.Length);
                        Console.WriteLine(y);
                        Console.WriteLine(z);
                        
                    }
                    else
                    {
                        ChatLogController(new Round
                        {
                            ReadOnly = true,
                            Multiline = true,
                            Dock = DockStyle.Fill,
                            BorderStyle = BorderStyle.None,
                            TextAlign = HorizontalAlignment.Center,
                            Size = new Size(257, 97),//224,71,
                            BackColor = Color.LightBlue,
                            Text = "\r\n" + MrChat.Chat[0].result
                        }, 0);
                        Console.WriteLine(MrChat.Chat[0].result.Length);
                    }
                    /*
                    ChatLogController(new Round
                    {
                        ReadOnly = true,
                        Multiline = true,
                        Dock = DockStyle.Fill,
                        BorderStyle = BorderStyle.None,
                        TextAlign = HorizontalAlignment.Center,
                        Size = new Size(257, 97),//224,71,
                        BackColor = Color.LightBlue,
                        Text = "\r\n" + MrChat.Chat[0].result
                    }, 0);
                    Console.WriteLine(MrChat.Chat[0].result.Length);
                    */
                    // 103 is max characters of 3 lines
                    // then generate a method that checks this 
                    // and split in two different chat boxes
                }
            }
            if (_talkingBot)
            {
                speechSynthesis.Speak(_messageBot);
            }
            userInputBox.Text = "";
            return null;
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
        private void ChatLogController(Round message, int i)
        {
            var botMessageOne = (Round)chatLogTable.GetControlFromPosition(0, 3);
            var botMessageTwo = (Round)chatLogTable.GetControlFromPosition(0, 2);
            var botMessageThree = (Round)chatLogTable.GetControlFromPosition(0, 1);
            chatLogTable.Controls.Remove(chatLogTable.GetControlFromPosition(0, 0));
            var userMessageOne = (Round)chatLogTable.GetControlFromPosition(1, 3);
            var userMessageTwo = (Round)chatLogTable.GetControlFromPosition(1, 2);
            var userMessageThree = (Round)chatLogTable.GetControlFromPosition(1, 1);
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
            _bwp = new BufferedWaveProvider(In.WaveFormat)
            {
                DiscardOnBufferOverflow = true
            };
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

            _writer = new WaveFileWriter(_output, In.WaveFormat);

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
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);
                var speech = SpeechClient.Create();
                var response = speech.Recognize(new RecognitionConfig
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
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
    }
}