using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot_app_desk
{
    public class LlmChatResponse
    {
        public string userid { get; set; }
        public string timestamp { get; set; }
        public string message { get; set; }
        public string reply { get; set; }

        public string error { get; set; }  // if your API returns {"error": "..."}
    }
}
