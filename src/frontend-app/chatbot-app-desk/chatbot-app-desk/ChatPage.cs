using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace chatbot_app_desk
{

    public partial class ChatPage : Form
    {

        private readonly int _currentUserId;
        private readonly string _username;
        private readonly List<Conversation> _conversations = new List<Conversation>();
        public ChatPage(int currentUserId, string username)
        {
            InitializeComponent();

            lstbxChats.DrawMode = DrawMode.OwnerDrawFixed;
            lstbxChats.DrawItem += lstbxChats_DrawItem;
            lstbxChats.ItemHeight = 40;

            _currentUserId = currentUserId;
            _username = username;

            //lstbxChats.Items.Add(new ChatItem 
            //{ Text = "Your Chat Bot", 
            //  BackColor = Color.DarkKhaki,
            //  ForeColor = Color.Black,
            //  Font = new Font("Arial", 20, FontStyle.Italic)
            //});

            // Example conversations
            var bob = new Conversation { PersonName = "Bob" };
            bob.Messages.Add(new ChatMessage { IsMe = true, Text = "Hi Bob!" });
            bob.Messages.Add(new ChatMessage { IsMe = false, Text = "Hey :)" });

            var alice = new Conversation { PersonName = "Alice" };
            alice.Messages.Add(new ChatMessage { IsMe = false, Text = "Hello!" });

            _conversations.Add(bob);
            _conversations.Add(alice);

            lstbxChats.DataSource = _conversations;
        }

        static HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://d3pnxez72y4km9.cloudfront.net")
        };

        private async Task<string> SendToLlmAsync(string userMessage, string userId)
        {
            var req = new LlmChatRequest
            {
                message = userMessage,
                userid = userId,
                timestamp = DateTime.UtcNow.ToString("o")  // ISO 8601
            };

            string json = JsonSerializer.Serialize(req);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/llm/chat", content);
            string respJson = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                // Try to read error message
                var err = JsonSerializer.Deserialize<LlmChatResponse>(respJson);
                throw new Exception(err?.error ?? $"API error: {response.StatusCode}");
            }

            var result = JsonSerializer.Deserialize<LlmChatResponse>(respJson);
            return result?.reply ?? "";
        }

        private void ChatPage_Load(object sender, EventArgs e)
        {

        }

        private void lstbxChats_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!(lstbxChats.SelectedItem is Conversation conv))
                return;


            pnlMessageItems.Visible = true;
            lblChatName.Text = conv.PersonName;

            flowpnlChat.Controls.Clear();

            // Load messages for selected conversation
            foreach (var m in conv.Messages)
            {
                var lbl = new Label();
                lbl.AutoSize = true;
                lbl.MaximumSize = new Size(flowpnlChat.ClientSize.Width - 40, 0); // wrap text
                lbl.Text = m.Text;
                lbl.Padding = new Padding(8);
                lbl.BorderStyle = BorderStyle.FixedSingle;

                if (m.IsMe)
                {
                    // Right-aligned bubble
                    lbl.BackColor = Color.LightGreen;
                    lbl.TextAlign = ContentAlignment.MiddleRight;
                    lbl.Anchor = AnchorStyles.Right;
                    lbl.Margin = new Padding(50, 5, 5, 5);
                }
                else
                {
                    // Left-aligned bubble
                    lbl.BackColor = Color.White;
                    lbl.TextAlign = ContentAlignment.MiddleLeft;
                    lbl.Margin = new Padding(5, 5, 50, 5);
                }

                flowpnlChat.Controls.Add(lbl);
            }

            if (flowpnlChat.Controls.Count > 0)
            {
                flowpnlChat.ScrollControlIntoView(flowpnlChat.Controls[flowpnlChat.Controls.Count - 1]);
            }
        }


        private void lstbxChats_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var obj = lstbxChats.Items[e.Index];

            if (!(obj is Conversation conv))
            {
                // fallback drawing
                e.DrawBackground();
                TextRenderer.DrawText(e.Graphics,
                                      obj?.ToString() ?? string.Empty,
                                      lstbxChats.Font,
                                      e.Bounds,
                                      lstbxChats.ForeColor,
                                      TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                e.DrawFocusRectangle();
                return;
            }

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            var back = new SolidBrush(selected ? SystemColors.Highlight : Color.LightBlue);
            e.Graphics.FillRectangle(back, e.Bounds);

            TextRenderer.DrawText(e.Graphics,
                                  conv.PersonName,
                                  lstbxChats.Font,
                                  e.Bounds,
                                  selected ? SystemColors.HighlightText : Color.Black,
                                  TextFormatFlags.VerticalCenter | TextFormatFlags.Left);

            e.DrawFocusRectangle();
        }


        private void btnProfile_Click(object sender, EventArgs e)
        {

        }
        private async void btnSend_Click_1(object sender, EventArgs e)
        {
            var text = txtbxMessage.Text.Trim();
            if (!(lstbxChats.SelectedItem is Conversation conv)) return;
            if (string.IsNullOrWhiteSpace(txtbxMessage.Text)) return;

            // 1) Add my message to the conversation
            var msg = new ChatMessage
            {
                IsMe = true,
                Text = text,
                Time = DateTime.Now
            };

            conv.Messages.Add(msg);
            txtbxMessage.Clear();
            RenderConversation(conv);

            try
            {
                // 2) Send to API
                string reply = await SendToLlmAsync(text, _currentUserId.ToString());

                // 3) Add bot reply and re-render
                conv.Messages.Add(new ChatMessage
                {
                    IsMe = false,
                    Text = reply,
                    Time = DateTime.Now
                });
                RenderConversation(conv);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calling API: " + ex.Message);
            }

            // Re-render current conversation
            lstbxChats_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void RenderConversation(Conversation conv)
        {
            if (conv == null) return;

            // 1) Set header
            lblChatName.Text = conv.PersonName;

            // 2) Clear old messages
            flowpnlChat.SuspendLayout();
            flowpnlChat.Controls.Clear();

            // 3) Add a bubble for each message
            foreach (var m in conv.Messages)
            {
                var bubble = new Label();

                bubble.AutoSize = true;
                // limit width so text wraps
                bubble.MaximumSize = new Size(flowpnlChat.ClientSize.Width - 40, 0);
                bubble.Text = m.Text;
                bubble.Padding = new Padding(8);
                bubble.BorderStyle = BorderStyle.FixedSingle;

                if (m.IsMe)
                {
                    // right side – "me"
                    bubble.BackColor = Color.LightGreen;
                    bubble.TextAlign = ContentAlignment.MiddleRight;
                    bubble.Margin = new Padding(60, 4, 4, 4); // more space on left
                }
                else
                {
                    // left side – other person
                    bubble.BackColor = Color.WhiteSmoke;
                    bubble.TextAlign = ContentAlignment.MiddleLeft;
                    bubble.Margin = new Padding(4, 4, 60, 4); // more space on right
                }

                flowpnlChat.Controls.Add(bubble);
            }

            // 4) Scroll to bottom
            if (flowpnlChat.Controls.Count > 0)
                flowpnlChat.ScrollControlIntoView(
                    flowpnlChat.Controls[flowpnlChat.Controls.Count - 1]);

            flowpnlChat.ResumeLayout();
        }

    }

    //public class ChatItem
    //{
    //    public string Text { get; set; }
    //    public Color BackColor { get; set; } = Color.LightBlue;
    //    public Color ForeColor { get; set; } = Color.Black;
    //    public Font Font { get; set; } = SystemFonts.DefaultFont;

    //    public override string ToString() => Text; // use for debugger
    //}

    public class ChatMessage
    {
        public bool IsMe { get; set; }      // true = you, false = other person
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }

    public class Conversation
    {
        public string PersonName { get; set; }
        public List<ChatMessage> Messages { get; } = new List<ChatMessage>();

        public override string ToString() => PersonName;   // what shows in lstbxChats
    }

    public class LlmChatRequest
    {
        public string message { get; set; }
        public string userid { get; set; }
        public string timestamp { get; set; }
    }

    public class LlmChatResponse
    {
        public string userid { get; set; }
        public string timestamp { get; set; }
        public string message { get; set; }
        public string reply { get; set; }

        public string error { get; set; }  // if your API returns {"error": "..."}
    }

}
