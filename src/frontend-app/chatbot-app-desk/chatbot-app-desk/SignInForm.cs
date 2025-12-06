using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace chatbot_app_desk
{
    public partial class SignInForm : Form
    {

        static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://d3pnxez72y4km9.cloudfront.net")
        }; // going to use to make requests to API
        bool viewPass = true;

        public SignInForm()
        {
            InitializeComponent();

            txtbxEmail.Text = "Enter Email...";

            txtbxEmail.GotFocus += RemoveEmail;
            txtbxEmail.LostFocus += AddText;

            txtbxPass.Text = "Enter Password...";

            txtbxPass.GotFocus += RemovePassword;
            txtbxPass.LostFocus += AddText;
        }

        private void txtbxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        public void RemoveEmail(object sender, EventArgs e)
        {
            if (txtbxEmail.Text == "Enter Email...")
            {
                txtbxEmail.Text = "";
            }
        }

        public void RemovePassword(object sender, EventArgs e)
        {
            if (txtbxPass.Text == "Enter Password...")
            {
                txtbxPass.Text = "";
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbxEmail.Text))
            {
                txtbxEmail.Text = "Enter Email...";
            }
            if (string.IsNullOrWhiteSpace(txtbxPass.Text))
            {
                txtbxPass.UseSystemPasswordChar = false;
                txtbxPass.Text = "Enter Password...";
            }
        }

        private void lnklblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var signUpForm = new SignUpForm())
            {
                this.Hide();
                signUpForm.ShowDialog();
                this.Close();
            }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbxEmail.Text) || txtbxEmail.Text == "Enter Email...")
            {
                MessageBox.Show("Invalid Email");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtbxPass.Text) || txtbxPass.Text == "Enter Password...")
            {
                MessageBox.Show("Invalid Password");
                return;
            }

            User user = new User
            {
                email = txtbxEmail.Text,
                password = txtbxPass.Text,
            };

            try
            {
                var location = await LoginUser(user);
                MessageBox.Show("Login successful!");
                using (var chatPage = new ChatPage())
                {
                    this.Hide();
                    chatPage.ShowDialog();
                    this.Close();
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}");
            }
        }

        static async Task<Uri> LoginUser(User user)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync("/api/login", user);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
    }
}
