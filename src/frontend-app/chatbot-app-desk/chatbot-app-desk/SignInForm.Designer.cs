namespace chatbot_app_desk
{
    partial class SignInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignInForm));
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.lnklblSignUp = new System.Windows.Forms.LinkLabel();
            this.txtbxPass = new System.Windows.Forms.TextBox();
            this.txtbxEmail = new System.Windows.Forms.TextBox();
            this.lblSignIn = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLogo
            // 
            this.imgLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLogo.BackColor = System.Drawing.Color.Transparent;
            this.imgLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.imgLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("imgLogo.ErrorImage")));
            this.imgLogo.ImageLocation = "0,0";
            this.imgLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgLogo.InitialImage")));
            this.imgLogo.Location = new System.Drawing.Point(194, -1);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(337, 485);
            this.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgLogo.TabIndex = 13;
            this.imgLogo.TabStop = false;
            // 
            // lnklblSignUp
            // 
            this.lnklblSignUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnklblSignUp.AutoSize = true;
            this.lnklblSignUp.Location = new System.Drawing.Point(58, 455);
            this.lnklblSignUp.Name = "lnklblSignUp";
            this.lnklblSignUp.Size = new System.Drawing.Size(81, 26);
            this.lnklblSignUp.TabIndex = 12;
            this.lnklblSignUp.TabStop = true;
            this.lnklblSignUp.Text = "New?\r\nCreate Account";
            this.lnklblSignUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnklblSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblSignUp_LinkClicked);
            // 
            // txtbxPass
            // 
            this.txtbxPass.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxPass.Location = new System.Drawing.Point(20, 219);
            this.txtbxPass.Name = "txtbxPass";
            this.txtbxPass.Size = new System.Drawing.Size(157, 20);
            this.txtbxPass.TabIndex = 11;
            this.txtbxPass.Text = "Enter Password";
            this.txtbxPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtbxEmail
            // 
            this.txtbxEmail.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxEmail.Location = new System.Drawing.Point(20, 157);
            this.txtbxEmail.Name = "txtbxEmail";
            this.txtbxEmail.Size = new System.Drawing.Size(157, 20);
            this.txtbxEmail.TabIndex = 10;
            this.txtbxEmail.Text = "Enter Email";
            this.txtbxEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbxEmail.TextChanged += new System.EventHandler(this.txtbxEmail_TextChanged);
            // 
            // lblSignIn
            // 
            this.lblSignIn.AutoSize = true;
            this.lblSignIn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 30F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignIn.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            this.lblSignIn.Location = new System.Drawing.Point(12, 80);
            this.lblSignIn.Name = "lblSignIn";
            this.lblSignIn.Size = new System.Drawing.Size(175, 46);
            this.lblSignIn.TabIndex = 8;
            this.lblSignIn.Text = "SIGN IN";
            this.lblSignIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(53, 270);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(90, 35);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Login";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // SignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(531, 484);
            this.Controls.Add(this.imgLogo);
            this.Controls.Add(this.lnklblSignUp);
            this.Controls.Add(this.txtbxPass);
            this.Controls.Add(this.txtbxEmail);
            this.Controls.Add(this.lblSignIn);
            this.Controls.Add(this.btnSubmit);
            this.MaximizeBox = false;
            this.Name = "SignInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignInForm";
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLogo;
        private System.Windows.Forms.LinkLabel lnklblSignUp;
        private System.Windows.Forms.TextBox txtbxPass;
        private System.Windows.Forms.TextBox txtbxEmail;
        private System.Windows.Forms.Label lblSignIn;
        private System.Windows.Forms.Button btnSubmit;
    }
}