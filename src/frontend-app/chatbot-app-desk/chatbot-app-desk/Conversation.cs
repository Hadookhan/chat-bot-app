using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot_app_desk
{
    public class Conversation
    {
        public string PersonName { get; set; }
        public List<ChatMessage> Messages { get; } = new List<ChatMessage>();

        public override string ToString() => PersonName;   // what shows in lstbxChats
    }
}
