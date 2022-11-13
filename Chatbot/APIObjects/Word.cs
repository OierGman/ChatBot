using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatbot.APIObjects
{
    internal class Word
    {
        public static List<Word.Root> word = new List<Word.Root>();
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Root
        {
            public List<string> MyArray { get; set; }
        }
    }
}
