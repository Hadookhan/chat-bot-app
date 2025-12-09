namespace chatbot_app_desk
{
    partial class AddCustomBot
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
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCustomBotHead = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblExamplePrompt = new System.Windows.Forms.Label();
            this.txtBoxPersonalise = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbxName
            // 
            this.txtbxName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbxName.Location = new System.Drawing.Point(76, 110);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(196, 20);
            this.txtbxName.TabIndex = 0;
            this.txtbxName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(150, 92);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 15);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblCustomBotHead
            // 
            this.lblCustomBotHead.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCustomBotHead.AutoSize = true;
            this.lblCustomBotHead.Font = new System.Drawing.Font("Cascadia Mono", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomBotHead.Location = new System.Drawing.Point(50, 0);
            this.lblCustomBotHead.Name = "lblCustomBotHead";
            this.lblCustomBotHead.Size = new System.Drawing.Size(239, 70);
            this.lblCustomBotHead.TabIndex = 2;
            this.lblCustomBotHead.Text = "CREATE YOUR\r\nCUSTOM CHATBOT";
            this.lblCustomBotHead.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Prompt";
            // 
            // lblExamplePrompt
            // 
            this.lblExamplePrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExamplePrompt.AutoSize = true;
            this.lblExamplePrompt.BackColor = System.Drawing.SystemColors.Window;
            this.lblExamplePrompt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblExamplePrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamplePrompt.Location = new System.Drawing.Point(74, 170);
            this.lblExamplePrompt.Name = "lblExamplePrompt";
            this.lblExamplePrompt.Size = new System.Drawing.Size(198, 63);
            this.lblExamplePrompt.TabIndex = 11;
            this.lblExamplePrompt.Text = "e.g. You are a Puerto Rican clown. STEPS TO FOLLOW:\r\n1. Treat the user as your\r\nq" +
    "ueen.\r\n2. Speak in broken english.\r\n3. Crack a few clown jokes.\r\n4. Summarise yo" +
    "ur response in\r\n10 words or less\r\n";
            this.lblExamplePrompt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblExamplePrompt.Click += new System.EventHandler(this.lblExamplePrompt_Click);
            // 
            // txtBoxPersonalise
            // 
            this.txtBoxPersonalise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxPersonalise.Location = new System.Drawing.Point(44, 169);
            this.txtBoxPersonalise.Multiline = true;
            this.txtBoxPersonalise.Name = "txtBoxPersonalise";
            this.txtBoxPersonalise.Size = new System.Drawing.Size(254, 67);
            this.txtBoxPersonalise.TabIndex = 10;
            this.txtBoxPersonalise.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBoxPersonalise.TextChanged += new System.EventHandler(this.txtBoxPersonalise_TextChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCreate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(122, 258);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(101, 37);
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // AddCustomBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 325);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblExamplePrompt);
            this.Controls.Add(this.txtBoxPersonalise);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCustomBotHead);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtbxName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCustomBot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCustomBot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCustomBotHead;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblExamplePrompt;
        private System.Windows.Forms.TextBox txtBoxPersonalise;
        private System.Windows.Forms.Button btnCreate;
    }
}