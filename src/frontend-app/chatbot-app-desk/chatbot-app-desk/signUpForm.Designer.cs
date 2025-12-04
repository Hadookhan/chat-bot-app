namespace chatbot_app_desk
{
    partial class SignUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpForm));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblSignUp = new System.Windows.Forms.Label();
            this.txtbxEmail = new System.Windows.Forms.TextBox();
            this.txtbxPass = new System.Windows.Forms.TextBox();
            this.lnklblSignIn = new System.Windows.Forms.LinkLabel();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.txtbxUsername = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(48, 334);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(106, 35);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "Create account";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblSignUp
            // 
            this.lblSignUp.AutoSize = true;
            this.lblSignUp.Font = new System.Drawing.Font("Arial Rounded MT Bold", 30F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignUp.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            this.lblSignUp.Location = new System.Drawing.Point(12, 81);
            this.lblSignUp.Name = "lblSignUp";
            this.lblSignUp.Size = new System.Drawing.Size(189, 46);
            this.lblSignUp.TabIndex = 1;
            this.lblSignUp.Text = "SIGN UP";
            this.lblSignUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSignUp.Click += new System.EventHandler(this.lblSignUp_Click);
            // 
            // txtbxEmail
            // 
            this.txtbxEmail.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxEmail.Location = new System.Drawing.Point(25, 221);
            this.txtbxEmail.Name = "txtbxEmail";
            this.txtbxEmail.Size = new System.Drawing.Size(157, 20);
            this.txtbxEmail.TabIndex = 3;
            this.txtbxEmail.Text = "Enter Email";
            this.txtbxEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbxEmail.TextChanged += new System.EventHandler(this.txtbxEmail_TextChanged);
            // 
            // txtbxPass
            // 
            this.txtbxPass.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxPass.Location = new System.Drawing.Point(25, 283);
            this.txtbxPass.Name = "txtbxPass";
            this.txtbxPass.Size = new System.Drawing.Size(157, 20);
            this.txtbxPass.TabIndex = 4;
            this.txtbxPass.Text = "Enter Password";
            this.txtbxPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbxPass.TextChanged += new System.EventHandler(this.txtbxPass_TextChanged);
            // 
            // lnklblSignIn
            // 
            this.lnklblSignIn.AutoSize = true;
            this.lnklblSignIn.Location = new System.Drawing.Point(53, 456);
            this.lnklblSignIn.Name = "lnklblSignIn";
            this.lnklblSignIn.Size = new System.Drawing.Size(96, 26);
            this.lnklblSignIn.TabIndex = 5;
            this.lnklblSignIn.TabStop = true;
            this.lnklblSignIn.Text = "Have an account?\r\nSign in";
            this.lnklblSignIn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnklblSignIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblSignIn_LinkClicked);
            // 
            // imgLogo
            // 
            this.imgLogo.BackColor = System.Drawing.Color.Transparent;
            this.imgLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("imgLogo.ErrorImage")));
            this.imgLogo.ImageLocation = "0,0";
            this.imgLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgLogo.InitialImage")));
            this.imgLogo.Location = new System.Drawing.Point(196, 1);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(337, 485);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgLogo.TabIndex = 6;
            this.imgLogo.TabStop = false;
            // 
            // txtbxUsername
            // 
            this.txtbxUsername.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxUsername.Location = new System.Drawing.Point(25, 161);
            this.txtbxUsername.Name = "txtbxUsername";
            this.txtbxUsername.Size = new System.Drawing.Size(157, 20);
            this.txtbxUsername.TabIndex = 2;
            this.txtbxUsername.Text = "Enter Username";
            this.txtbxUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbxUsername.TextChanged += new System.EventHandler(this.txtbxUsername_TextChanged);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(532, 486);
            this.Controls.Add(this.imgLogo);
            this.Controls.Add(this.lnklblSignIn);
            this.Controls.Add(this.txtbxPass);
            this.Controls.Add(this.txtbxEmail);
            this.Controls.Add(this.txtbxUsername);
            this.Controls.Add(this.lblSignUp);
            this.Controls.Add(this.btnSubmit);
            this.Name = "SignUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign Up";
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblSignUp;
        private System.Windows.Forms.TextBox txtbxEmail;
        private System.Windows.Forms.TextBox txtbxPass;
        private System.Windows.Forms.LinkLabel lnklblSignIn;
        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.TextBox txtbxUsername;
    }
}

