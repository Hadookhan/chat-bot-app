namespace chatbot_app_desk
{
    partial class Form1
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblSignUp = new System.Windows.Forms.Label();
            this.txtbxUsername = new System.Windows.Forms.TextBox();
            this.txtbxEmail = new System.Windows.Forms.TextBox();
            this.txtbxPass = new System.Windows.Forms.TextBox();
            this.lnklblSignIn = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(203, 314);
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
            this.lblSignUp.Location = new System.Drawing.Point(167, 52);
            this.lblSignUp.Name = "lblSignUp";
            this.lblSignUp.Size = new System.Drawing.Size(189, 46);
            this.lblSignUp.TabIndex = 1;
            this.lblSignUp.Text = "SIGN UP";
            this.lblSignUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbxUsername
            // 
            this.txtbxUsername.Location = new System.Drawing.Point(180, 132);
            this.txtbxUsername.Name = "txtbxUsername";
            this.txtbxUsername.Size = new System.Drawing.Size(157, 20);
            this.txtbxUsername.TabIndex = 2;
            this.txtbxUsername.Text = "Enter Username";
            this.txtbxUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbxUsername.TextChanged += new System.EventHandler(this.txtbxUsername_TextChanged);
            // 
            // txtbxEmail
            // 
            this.txtbxEmail.Location = new System.Drawing.Point(180, 192);
            this.txtbxEmail.Name = "txtbxEmail";
            this.txtbxEmail.Size = new System.Drawing.Size(157, 20);
            this.txtbxEmail.TabIndex = 3;
            this.txtbxEmail.Text = "Enter Email";
            this.txtbxEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtbxEmail.TextChanged += new System.EventHandler(this.txtbxEmail_TextChanged);
            // 
            // txtbxPass
            // 
            this.txtbxPass.Location = new System.Drawing.Point(180, 254);
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
            this.lnklblSignIn.Location = new System.Drawing.Point(235, 352);
            this.lnklblSignIn.Name = "lnklblSignIn";
            this.lnklblSignIn.Size = new System.Drawing.Size(39, 13);
            this.lnklblSignIn.TabIndex = 5;
            this.lnklblSignIn.TabStop = true;
            this.lnklblSignIn.Text = "Sign in";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(532, 486);
            this.Controls.Add(this.lnklblSignIn);
            this.Controls.Add(this.txtbxPass);
            this.Controls.Add(this.txtbxEmail);
            this.Controls.Add(this.txtbxUsername);
            this.Controls.Add(this.lblSignUp);
            this.Controls.Add(this.btnSubmit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblSignUp;
        private System.Windows.Forms.TextBox txtbxUsername;
        private System.Windows.Forms.TextBox txtbxEmail;
        private System.Windows.Forms.TextBox txtbxPass;
        private System.Windows.Forms.LinkLabel lnklblSignIn;
    }
}

