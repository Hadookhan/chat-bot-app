namespace chatbot_app_desk
{
    partial class ChatPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatPage));
            this.lstbxChats = new System.Windows.Forms.ListBox();
            this.textChatbackground = new System.Windows.Forms.PictureBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.pnlMessageItems = new System.Windows.Forms.Panel();
            this.btnClearChat = new System.Windows.Forms.Button();
            this.flowpnlChat = new System.Windows.Forms.FlowLayoutPanel();
            this.lblChatName = new System.Windows.Forms.Label();
            this.chatBack = new System.Windows.Forms.PictureBox();
            this.txtbxMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtBoxPersonalise = new System.Windows.Forms.TextBox();
            this.pnlPersonalisation = new System.Windows.Forms.Panel();
            this.lblExamplePrompt = new System.Windows.Forms.Label();
            this.btnResetPrompt = new System.Windows.Forms.Button();
            this.btnSetPrompt = new System.Windows.Forms.Button();
            this.lblEnterPersonalisation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.textChatbackground)).BeginInit();
            this.pnlMessageItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chatBack)).BeginInit();
            this.pnlPersonalisation.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstbxChats
            // 
            this.lstbxChats.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lstbxChats.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstbxChats.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbxChats.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lstbxChats.FormattingEnabled = true;
            this.lstbxChats.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.lstbxChats.ItemHeight = 5;
            this.lstbxChats.Location = new System.Drawing.Point(-1, -1);
            this.lstbxChats.Name = "lstbxChats";
            this.lstbxChats.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lstbxChats.ScrollAlwaysVisible = true;
            this.lstbxChats.Size = new System.Drawing.Size(287, 544);
            this.lstbxChats.TabIndex = 0;
            this.lstbxChats.SelectedIndexChanged += new System.EventHandler(this.lstbxChats_SelectedIndexChanged);
            // 
            // textChatbackground
            // 
            this.textChatbackground.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textChatbackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textChatbackground.Location = new System.Drawing.Point(292, -1);
            this.textChatbackground.Name = "textChatbackground";
            this.textChatbackground.Size = new System.Drawing.Size(579, 539);
            this.textChatbackground.TabIndex = 1;
            this.textChatbackground.TabStop = false;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.Location = new System.Drawing.Point(981, 12);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(63, 54);
            this.btnProfile.TabIndex = 2;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // pnlMessageItems
            // 
            this.pnlMessageItems.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlMessageItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMessageItems.Controls.Add(this.btnClearChat);
            this.pnlMessageItems.Controls.Add(this.flowpnlChat);
            this.pnlMessageItems.Controls.Add(this.lblChatName);
            this.pnlMessageItems.Controls.Add(this.chatBack);
            this.pnlMessageItems.Controls.Add(this.txtbxMessage);
            this.pnlMessageItems.Controls.Add(this.btnSend);
            this.pnlMessageItems.Location = new System.Drawing.Point(293, -1);
            this.pnlMessageItems.Name = "pnlMessageItems";
            this.pnlMessageItems.Size = new System.Drawing.Size(577, 538);
            this.pnlMessageItems.TabIndex = 3;
            this.pnlMessageItems.Visible = false;
            // 
            // btnClearChat
            // 
            this.btnClearChat.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearChat.Location = new System.Drawing.Point(440, 15);
            this.btnClearChat.Name = "btnClearChat";
            this.btnClearChat.Size = new System.Drawing.Size(121, 41);
            this.btnClearChat.TabIndex = 8;
            this.btnClearChat.Text = "Clear Chat";
            this.btnClearChat.UseVisualStyleBackColor = true;
            this.btnClearChat.Click += new System.EventHandler(this.btnClearChat_Click);
            // 
            // flowpnlChat
            // 
            this.flowpnlChat.AutoScroll = true;
            this.flowpnlChat.BackColor = System.Drawing.Color.Gainsboro;
            this.flowpnlChat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowpnlChat.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowpnlChat.Location = new System.Drawing.Point(10, 83);
            this.flowpnlChat.Name = "flowpnlChat";
            this.flowpnlChat.Size = new System.Drawing.Size(557, 389);
            this.flowpnlChat.TabIndex = 7;
            this.flowpnlChat.WrapContents = false;
            // 
            // lblChatName
            // 
            this.lblChatName.AutoSize = true;
            this.lblChatName.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblChatName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblChatName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChatName.Location = new System.Drawing.Point(3, 12);
            this.lblChatName.Name = "lblChatName";
            this.lblChatName.Size = new System.Drawing.Size(227, 45);
            this.lblChatName.TabIndex = 6;
            this.lblChatName.Text = "chatPerson";
            this.lblChatName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chatBack
            // 
            this.chatBack.BackColor = System.Drawing.Color.Gainsboro;
            this.chatBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatBack.Location = new System.Drawing.Point(-1, 70);
            this.chatBack.Name = "chatBack";
            this.chatBack.Size = new System.Drawing.Size(577, 413);
            this.chatBack.TabIndex = 6;
            this.chatBack.TabStop = false;
            // 
            // txtbxMessage
            // 
            this.txtbxMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbxMessage.Location = new System.Drawing.Point(45, 493);
            this.txtbxMessage.Multiline = true;
            this.txtbxMessage.Name = "txtbxMessage";
            this.txtbxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxMessage.Size = new System.Drawing.Size(430, 33);
            this.txtbxMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(492, 489);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 41);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click_1);
            // 
            // txtBoxPersonalise
            // 
            this.txtBoxPersonalise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxPersonalise.Location = new System.Drawing.Point(18, 24);
            this.txtBoxPersonalise.Multiline = true;
            this.txtBoxPersonalise.Name = "txtBoxPersonalise";
            this.txtBoxPersonalise.Size = new System.Drawing.Size(154, 250);
            this.txtBoxPersonalise.TabIndex = 4;
            this.txtBoxPersonalise.TextChanged += new System.EventHandler(this.txtBoxPersonalise_TextChanged);
            // 
            // pnlPersonalisation
            // 
            this.pnlPersonalisation.Controls.Add(this.lblExamplePrompt);
            this.pnlPersonalisation.Controls.Add(this.btnResetPrompt);
            this.pnlPersonalisation.Controls.Add(this.btnSetPrompt);
            this.pnlPersonalisation.Controls.Add(this.lblEnterPersonalisation);
            this.pnlPersonalisation.Controls.Add(this.txtBoxPersonalise);
            this.pnlPersonalisation.Location = new System.Drawing.Point(872, 198);
            this.pnlPersonalisation.Name = "pnlPersonalisation";
            this.pnlPersonalisation.Size = new System.Drawing.Size(184, 340);
            this.pnlPersonalisation.TabIndex = 6;
            this.pnlPersonalisation.Visible = false;
            // 
            // lblExamplePrompt
            // 
            this.lblExamplePrompt.AutoSize = true;
            this.lblExamplePrompt.BackColor = System.Drawing.SystemColors.Window;
            this.lblExamplePrompt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblExamplePrompt.Location = new System.Drawing.Point(20, 27);
            this.lblExamplePrompt.Name = "lblExamplePrompt";
            this.lblExamplePrompt.Size = new System.Drawing.Size(150, 143);
            this.lblExamplePrompt.TabIndex = 9;
            this.lblExamplePrompt.Text = resources.GetString("lblExamplePrompt.Text");
            this.lblExamplePrompt.Click += new System.EventHandler(this.lblExamplePrompt_Click);
            // 
            // btnResetPrompt
            // 
            this.btnResetPrompt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPrompt.Location = new System.Drawing.Point(18, 286);
            this.btnResetPrompt.Name = "btnResetPrompt";
            this.btnResetPrompt.Size = new System.Drawing.Size(63, 33);
            this.btnResetPrompt.TabIndex = 8;
            this.btnResetPrompt.Text = "Reset";
            this.btnResetPrompt.UseVisualStyleBackColor = true;
            this.btnResetPrompt.Click += new System.EventHandler(this.btnResetPrompt_Click);
            // 
            // btnSetPrompt
            // 
            this.btnSetPrompt.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetPrompt.Location = new System.Drawing.Point(109, 286);
            this.btnSetPrompt.Name = "btnSetPrompt";
            this.btnSetPrompt.Size = new System.Drawing.Size(63, 33);
            this.btnSetPrompt.TabIndex = 7;
            this.btnSetPrompt.Text = "Set";
            this.btnSetPrompt.UseVisualStyleBackColor = true;
            this.btnSetPrompt.Click += new System.EventHandler(this.btnSetPrompt_Click);
            // 
            // lblEnterPersonalisation
            // 
            this.lblEnterPersonalisation.AutoSize = true;
            this.lblEnterPersonalisation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterPersonalisation.Location = new System.Drawing.Point(0, 2);
            this.lblEnterPersonalisation.Name = "lblEnterPersonalisation";
            this.lblEnterPersonalisation.Size = new System.Drawing.Size(186, 16);
            this.lblEnterPersonalisation.TabIndex = 6;
            this.lblEnterPersonalisation.Text = "Enter your custom prompt!";
            this.lblEnterPersonalisation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ChatPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1056, 538);
            this.Controls.Add(this.pnlPersonalisation);
            this.Controls.Add(this.pnlMessageItems);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.textChatbackground);
            this.Controls.Add(this.lstbxChats);
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "ChatPage";
            this.Text = "ChatPage";
            this.Load += new System.EventHandler(this.ChatPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textChatbackground)).EndInit();
            this.pnlMessageItems.ResumeLayout(false);
            this.pnlMessageItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chatBack)).EndInit();
            this.pnlPersonalisation.ResumeLayout(false);
            this.pnlPersonalisation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstbxChats;
        private System.Windows.Forms.PictureBox textChatbackground;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Panel pnlMessageItems;
        private System.Windows.Forms.TextBox txtbxMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblChatName;
        private System.Windows.Forms.PictureBox chatBack;
        private System.Windows.Forms.FlowLayoutPanel flowpnlChat;
        private System.Windows.Forms.TextBox txtBoxPersonalise;
        private System.Windows.Forms.Panel pnlPersonalisation;
        private System.Windows.Forms.Label lblEnterPersonalisation;
        private System.Windows.Forms.Button btnResetPrompt;
        private System.Windows.Forms.Button btnSetPrompt;
        private System.Windows.Forms.Button btnClearChat;
        private System.Windows.Forms.Label lblExamplePrompt;
    }
}