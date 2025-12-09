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

        List<Conversation> _convs;
        int _userID;
        HttpClient _client;

        public AddCustomBot(List<Conversation> convs, int userID, HttpClient client)
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

            var request = new HttpRequestMessage(HttpMethod.Post, "/llm/chat");
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

                MessageBox.Show("Custom bot created (and first message sent)!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating custom bot: {ex.Message}");
            }
        }


        private async Task GetCustomChatBot()
        {
            var url = $"/api/llm/users/bots/{_userID}";

            HttpResponseMessage response;
            try
            {
                response = await _client.GetAsync(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling bots API: {ex.Message}");
                return;
            }

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Bot API returned {response.StatusCode}");
                return;
            }

            var json = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(json) || json == "null")
            {
                return;
            }

            List<AddBotRequest> bots;
            try
            {
                bots = JsonSerializer.Deserialize<List<AddBotRequest>>(
                    json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing bots JSON: {ex.Message}");
                return;
            }

            if (bots == null || bots.Count == 0)
            {
                return;
            }

            // Build a fast lookup of existing conversation names
            var existingNames = new HashSet<string>(
                _convs.Select(c => c.PersonName),
                StringComparer.OrdinalIgnoreCase
            );

            foreach (var bot in bots)
            {
                if (string.IsNullOrWhiteSpace(bot.bot_name))
                    continue;

                if (!existingNames.Add(bot.bot_name))
                    continue;

                var conv = new Conversation
                {
                    PersonName = bot.bot_name
                };

                _convs.Add(conv);
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
            
            await GetCustomChatBot();

            MessageBox.Show($"{botName} added to your chat list!");

            this.Close();

        }
    }
}
