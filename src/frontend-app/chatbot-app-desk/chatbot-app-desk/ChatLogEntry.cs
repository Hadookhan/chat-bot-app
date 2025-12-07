using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot_app_desk
{
    public class ChatLogEntry
    {
        public string user_id { get; set; }
        public string bot_name { get; set; }
        public string timestamp { get; set; }
        public string user_message { get; set; }
        public string bot_reply { get; set; }
    }
}
