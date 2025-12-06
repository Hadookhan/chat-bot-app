using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatbot_app_desk
{

    public partial class ChatPage : Form
    {

        private readonly List<Conversation> _conversations = new List<Conversation>();
        public ChatPage()
        {
            InitializeComponent();

            lstbxChats.DrawMode = DrawMode.OwnerDrawFixed;
            lstbxChats.DrawItem += lstbxChats_DrawItem;
            lstbxChats.ItemHeight = 40;

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

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!(lstbxChats.SelectedItem is Conversation conv)) return;
            if (string.IsNullOrWhiteSpace(txtbxMessage.Text)) return;

            var msg = new ChatMessage
            {
                IsMe = true,
                Text = txtbxMessage.Text,
                Time = DateTime.Now
            };

            conv.Messages.Add(msg);
            txtbxMessage.Clear();

            // Re-render current conversation
            lstbxChats_SelectedIndexChanged(null, EventArgs.Empty);
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
}
