using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chatbot_app_desk
{
    public partial class AddCustomBot : Form
    {

        BindingList<Conversation> _convs;
        int _userID;
        HttpClient _client;

        public AddCustomBot(BindingList<Conversation> convs, int userID, HttpClient client)
        {
            InitializeComponent();

            _convs = convs;
            _userID = userID;
            _client = client;
        }

        public async Task CreateCustomBot()
        {
            string botName = txtbxName.Text.Trim();
            string personalisePrompt = txtBoxPersonalise.Text.Trim();

            if (string.IsNullOrWhiteSpace(botName))
            {
                MessageBox.Show("Please enter a bot name.");
                return;
            }
            if (string.IsNullOrWhiteSpace(personalisePrompt))
            {
                MessageBox.Show("Please enter a personalise prompt.");
                return;
            }

            var reqBody = new
            {
                userid = _userID.ToString(),
                message = "Initialising custom bot.",   // dummy first message
                system_prompt = personalisePrompt,
                timestamp = DateTime.UtcNow.ToString("o")
            };

            string json = JsonSerializer.Serialize(reqBody);

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/llm/chat");
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            request.Headers.Add("X-Bot-Name", botName);

            try
            {
                var response = await _client.SendAsync(request);
                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error from server: {response.StatusCode}\n{error}");
                    return;
                }
                _convs.Add(new Conversation { PersonName = botName });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating custom bot: {ex.Message}");
            }
        }


        private void txtBoxPersonalise_TextChanged(object sender, EventArgs e)
        {
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

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            string botName = txtbxName.Text.Trim();
            string personalisePrompt = txtBoxPersonalise.Text.Trim();

            if (string.IsNullOrWhiteSpace(botName))
            {
                MessageBox.Show("Please enter a bot name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(personalisePrompt))
            {
                MessageBox.Show("Please enter a personalise prompt.");
                return;
            }

            await CreateCustomBot();

            MessageBox.Show($"{botName} added to your chat list!");

            this.Close();

        }
    }
}
