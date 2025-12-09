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
using Microsoft.Web.WebView2;
using Microsoft.Web.WebView2.WinForms;

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

            // Preset LLM conversations
            var personalisable = new Conversation { PersonName = "Personalisable" };
            var bob = new Conversation { PersonName = "Bob" };
            var alice = new Conversation { PersonName = "Alice" };
            var mrsWong = new Conversation { PersonName = "Mrs Wong" };

            _conversations.Add(personalisable);
            _conversations.Add(bob);
            _conversations.Add(alice);
            _conversations.Add(mrsWong);

            lstbxChats.DataSource = _conversations;
        }

        

        private async Task LoadConversationHistoryAsync(Conversation conv)
        {
            var url = $"/api/llm/chat/logs/{_currentUserId}/{conv.PersonName}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return;
            }

            var json = await response.Content.ReadAsStringAsync();
            var logs = JsonSerializer.Deserialize<List<ChatLogEntry>>(json);

            if (logs == null) return;

            conv.Messages.Clear();

            foreach (var log in logs)
            {
                // user message
                if (!string.IsNullOrWhiteSpace(log.user_message))
                {
                    conv.Messages.Add(new ChatMessage
                    {
                        IsMe = true,
                        Text = log.user_message,
                        Time = DateTime.TryParse(log.timestamp, out var t1) ? t1 : DateTime.Now
                    });
                }

                // bot reply
                if (!string.IsNullOrWhiteSpace(log.bot_reply))
                {
                    conv.Messages.Add(new ChatMessage
                    {
                        IsMe = false,
                        Text = log.bot_reply,
                        Time = DateTime.TryParse(log.timestamp, out var t2) ? t2 : DateTime.Now
                    });
                }
                if (!string.IsNullOrWhiteSpace(log.system_prompt) && (log.bot_name == "Personalisable"))
                {
                    txtBoxPersonalise.Text = log.system_prompt;
                    txtBoxPersonalise.ReadOnly = true;
                }
            }
        }


        static HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://d3pnxez72y4km9.cloudfront.net")
        };

        private async Task<string> SendToLlmAsync(string userMessage, string userId, string botName)
        {
            var req = new LlmChatRequest
            {
                message = userMessage,
                userid = userId,
                timestamp = DateTime.UtcNow.ToString("o"),
                system_prompt = botName == "Personalisable"
                    ? txtBoxPersonalise.Text
                    : null
            };

            string json = JsonSerializer.Serialize(req);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            if (botName == "Bob")
            {
                content.Headers.Add("X-Bot-Name", "Bob");
            }
            else if (botName == "Alice")
            {
                content.Headers.Add("X-Bot-Name", "Alice");
            }
            else if (botName == "Mrs Wong")
            {
                content.Headers.Add("X-Bot-Name", "Mrs Wong");
            }
            else if (botName == "Personalisable")
            {
                content.Headers.Add("X-Bot-Name", "Personalisable");
            }

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

        private async void ChatPage_Load(object sender, EventArgs e)
        {
            // Load history for each conversation on startup
            foreach (var conv in _conversations)
            {
                await LoadConversationHistoryAsync(conv);
            }

            // Select the first conversation and render it
            if (_conversations.Count > 0)
            {
                lstbxChats.SelectedIndex = 0;
                RenderConversation(_conversations[0]);
            }

            flowpnlChat.HorizontalScroll.Maximum = 0;
            flowpnlChat.HorizontalScroll.Visible = false;
            flowpnlChat.HorizontalScroll.Enabled = false;

            flowpnlChat.AutoScroll = false;
            flowpnlChat.AutoScroll = true;
        }

        private void lstbxChats_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (!(lstbxChats.SelectedItem is Conversation conv))
                return;

            pnlMessageItems.Visible = true;
            flowpnlChat.AutoScroll = true;
            lblChatName.Text = conv.PersonName;
            pnlPersonalisation.Visible = false;

            flowpnlChat.Controls.Clear();

            if (conv.PersonName == "Personalisable")
            {
                pnlPersonalisation.Visible = true;
            }

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
            if (string.IsNullOrWhiteSpace(txtBoxPersonalise.Text))
            {
                MessageBox.Show("Please enter a personalise prompt.");
                return;
            }

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
                string reply = await SendToLlmAsync(text, _currentUserId.ToString(), conv.PersonName);

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

        private void btnSetPrompt_Click(object sender, EventArgs e)
        {
            txtBoxPersonalise.ReadOnly = true;
        }

        private async void btnResetPrompt_Click(object sender, EventArgs e)
        {
            txtBoxPersonalise.Text = "";
            txtBoxPersonalise.ReadOnly = false;

            var req = new
            {
                userid = _currentUserId.ToString(),
                bot_name = (lstbxChats.SelectedItem as Conversation)?.PersonName
            };

            string json = JsonSerializer.Serialize(req);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/llm/chat/clear", content);
            response.EnsureSuccessStatusCode();

            if (lstbxChats.SelectedItem is Conversation conv)
            {
                conv.Messages.Clear();
                RenderConversation(conv);
            }
        }

        private async void btnClearChat_Click(object sender, EventArgs e)
        {
            txtBoxPersonalise.Text = "";
            txtBoxPersonalise.ReadOnly = false;

            var req = new
            {
                userid = _currentUserId.ToString(),
                bot_name = (lstbxChats.SelectedItem as Conversation)?.PersonName
            };

            string json = JsonSerializer.Serialize(req);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/llm/chat/clear", content);
            response.EnsureSuccessStatusCode();

            if (lstbxChats.SelectedItem is Conversation conv)
            {
                conv.Messages.Clear();
                RenderConversation(conv);
            }
        }

        private void txtBoxPersonalise_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxPersonalise.ReadOnly == false)
            {
                txtBoxPersonalise.Cursor = Cursors.Default;
            }
            else {
                txtBoxPersonalise.Cursor = Cursors.IBeam;
            }

                if (txtBoxPersonalise.Text == "")
            {
                lblExamplePrompt.Visible = true;
            }
            else
                lblExamplePrompt.Visible = false;
        }

        private void lblExamplePrompt_Click(object sender, EventArgs e)
        {
            lblExamplePrompt.Visible = false;
        }

        private void btnAddLLM_Click(object sender, EventArgs e)
        {
            using (var addCustomBot = new AddCustomBot(_conversations, _currentUserId, _httpClient))
            {
                addCustomBot.ShowDialog();
            }
        }
    }
}
