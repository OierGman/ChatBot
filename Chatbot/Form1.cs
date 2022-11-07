using System.Speech.Recognition;
using System.Threading;
using System.Globalization;

namespace Chatbot
{
    public partial class Form1 : Form
    {
        private static bool completed;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an in-process speech recognizer for the en-US locale.  
            using (SpeechRecognitionEngine recognizer =
                   new SpeechRecognitionEngine(
                       new System.Globalization.CultureInfo("en-US")))
            {

                // Create and load a dictation grammar.
                Grammar testGrammar =  
                new Grammar(new GrammarBuilder("what is the weather today"));
                testGrammar.Name = "Test Grammar";

                recognizer.LoadGrammar(testGrammar);

                // Configure input to the speech recognizer.  
                recognizer.SetInputToDefaultAudioDevice();

                // Modify the initial silence time-out value.  
                recognizer.InitialSilenceTimeout = TimeSpan.FromSeconds(3);

                // Start synchronous speech recognition.  
                RecognitionResult result = recognizer.Recognize();

                if (result != null)
                {
                    MessageBox.Show("detected");
                }
                else
                {
                    MessageBox.Show("No recognition result available.");
                }
            }
        }

        private void recognizer_SpeechRecognized(RecognitionResult result)
        {
            Search.YouTubeAPI(result.Text);
        }
    }
}
