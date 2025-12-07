using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot_app_desk
{
    public class ChatMessage
    {
        public bool IsMe { get; set; }      // true = you, false = other person
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}
