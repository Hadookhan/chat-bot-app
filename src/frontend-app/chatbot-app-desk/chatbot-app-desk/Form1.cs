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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

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
                txtbxPass.Text = "Enter Password...";
            }
        }

        private void txtbxEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
