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

    public partial class Form1 : Form
    {

        static HttpClient client = new HttpClient(); // going to use to make requests to API
        bool viewPass = true;

        public Form1()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("https://d3pnxez72y4km9.cloudfront.net");

            txtbxUsername.Text = "Enter Username...";

            txtbxUsername.GotFocus += RemoveUsername;
            txtbxUsername.LostFocus += AddText;

            txtbxEmail.Text = "Enter Email...";

            txtbxEmail.GotFocus += RemoveEmail;
            txtbxEmail.LostFocus += AddText;

            txtbxPass.Text = "Enter Password...";

            txtbxPass.GotFocus += RemovePassword;
            txtbxPass.LostFocus += AddText;
        }

        private void txtbxUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtbxPass_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtbxEmail_TextChanged(object sender, EventArgs e)
        {
        }

        public void RemoveUsername(object sender, EventArgs e)
        {
            if (txtbxUsername.Text == "Enter Username...")
            {
                txtbxUsername.Text = "";
            }
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

        // Adds placeholder text for any empty fields
        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbxUsername.Text))
            {
                txtbxUsername.Text = "Enter Username...";
            }
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

        private async void btnSubmit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtbxUsername.Text) || txtbxUsername.Text == "Enter Username...")
            {
                MessageBox.Show("Invalid Username");
                return;
            }
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

            // The actual user data
            User newUser = new User
            {
                username = txtbxUsername.Text,
                email = txtbxEmail.Text,
                password = txtbxPass.Text,
            };

            try
            {
                var location = await CreateUserAsync(newUser);
                MessageBox.Show("Signup successful!");
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Signup failed: {ex.Message}");
            }

            ShowUser(newUser); // displays to logs
        }

        static void ShowUser(User user)
        {
            Console.WriteLine($"Name: {user.username}\tEmail: " +
                $"{user.email}\tPassword: {user.password}");
        }

        static async Task<Uri> CreateUserAsync(User user)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync("/api/signup", user);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
    }
}
