using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot_app_desk
{
    public class LlmChatRequest
    {
        public string message { get; set; }
        public string userid { get; set; }
        public string timestamp { get; set; }
        public string system_prompt { get; set; }  // for personalisable bot
    }
}
