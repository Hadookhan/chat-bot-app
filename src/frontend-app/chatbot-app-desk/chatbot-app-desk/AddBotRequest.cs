using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot_app_desk
{
    public class AddBotRequest
    {
        public string bot_name { get; set; }
        public string user_id { get; set; }
        public string time_created { get; set; }
        public string system_prompt { get; set; }
    }
}
