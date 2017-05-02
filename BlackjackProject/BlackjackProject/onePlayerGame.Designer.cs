namespace BlackjackProject
{
    partial class onePlayerGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(onePlayerGame));
            this.stayButton = new System.Windows.Forms.Button();
            this.doubledownButton = new System.Windows.Forms.Button();
            this.hitButton = new System.Windows.Forms.Button();
            this.dealButton = new System.Windows.Forms.Button();
            this.playerHandTotalTextBox = new System.Windows.Forms.TextBox();
            this.dealerHandTotalTextBox = new System.Windows.Forms.TextBox();
            this.splitButton = new System.Windows.Forms.Button();
            this.splitHitButton = new System.Windows.Forms.Button();
            this.splitStayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stayButton
            // 
            this.stayButton.Location = new System.Drawing.Point(865, 197);
            this.stayButton.Name = "stayButton";
            this.stayButton.Size = new System.Drawing.Size(75, 46);
            this.stayButton.TabIndex = 6;
            this.stayButton.Text = "Stay";
            this.stayButton.UseVisualStyleBackColor = true;
            this.stayButton.Click += new System.EventHandler(this.stayButton_Click);
            // 
            // doubledownButton
            // 
            this.doubledownButton.Location = new System.Drawing.Point(865, 266);
            this.doubledownButton.Name = "doubledownButton";
            this.doubledownButton.Size = new System.Drawing.Size(75, 46);
            this.doubledownButton.TabIndex = 7;
            this.doubledownButton.Text = "Double Down";
            this.doubledownButton.UseVisualStyleBackColor = true;
            this.doubledownButton.Click += new System.EventHandler(this.doubledownButton_Click);
            // 
            // hitButton
            // 
            this.hitButton.Location = new System.Drawing.Point(865, 126);
            this.hitButton.Name = "hitButton";
            this.hitButton.Size = new System.Drawing.Size(75, 46);
            this.hitButton.TabIndex = 9;
            this.hitButton.Text = "Hit";
            this.hitButton.UseVisualStyleBackColor = true;
            this.hitButton.Click += new System.EventHandler(this.hitButton_Click);
            // 
            // dealButton
            // 
            this.dealButton.Location = new System.Drawing.Point(834, 561);
            this.dealButton.Name = "dealButton";
            this.dealButton.Size = new System.Drawing.Size(106, 46);
            this.dealButton.TabIndex = 10;
            this.dealButton.Text = "Deal";
            this.dealButton.UseVisualStyleBackColor = true;
            this.dealButton.Click += new System.EventHandler(this.dealButton_Click);
            // 
            // playerHandTotalTextBox
            // 
            this.playerHandTotalTextBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.playerHandTotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerHandTotalTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.playerHandTotalTextBox.Location = new System.Drawing.Point(1, 609);
            this.playerHandTotalTextBox.Name = "playerHandTotalTextBox";
            this.playerHandTotalTextBox.Size = new System.Drawing.Size(236, 31);
            this.playerHandTotalTextBox.TabIndex = 11;
            // 
            // dealerHandTotalTextBox
            // 
            this.dealerHandTotalTextBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.dealerHandTotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dealerHandTotalTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.dealerHandTotalTextBox.Location = new System.Drawing.Point(730, 609);
            this.dealerHandTotalTextBox.Name = "dealerHandTotalTextBox";
            this.dealerHandTotalTextBox.Size = new System.Drawing.Size(231, 31);
            this.dealerHandTotalTextBox.TabIndex = 12;
            // 
            // splitButton
            // 
            this.splitButton.Location = new System.Drawing.Point(865, 335);
            this.splitButton.Name = "splitButton";
            this.splitButton.Size = new System.Drawing.Size(75, 46);
            this.splitButton.TabIndex = 13;
            this.splitButton.Text = "Split";
            this.splitButton.UseVisualStyleBackColor = true;
            this.splitButton.Click += new System.EventHandler(this.splitButton_Click);
            // 
            // splitHitButton
            // 
            this.splitHitButton.Location = new System.Drawing.Point(865, 126);
            this.splitHitButton.Name = "splitHitButton";
            this.splitHitButton.Size = new System.Drawing.Size(75, 46);
            this.splitHitButton.TabIndex = 14;
            this.splitHitButton.Text = "Hit2";
            this.splitHitButton.UseVisualStyleBackColor = true;
            this.splitHitButton.Click += new System.EventHandler(this.splitHitButton_Click);
            // 
            // splitStayButton
            // 
            this.splitStayButton.Location = new System.Drawing.Point(865, 197);
            this.splitStayButton.Name = "splitStayButton";
            this.splitStayButton.Size = new System.Drawing.Size(75, 46);
            this.splitStayButton.TabIndex = 15;
            this.splitStayButton.Text = "Stay2";
            this.splitStayButton.UseVisualStyleBackColor = true;
            this.splitStayButton.Click += new System.EventHandler(this.splitStayButton_Click);
            // 
            // onePlayerGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(962, 713);
            this.Controls.Add(this.splitStayButton);
            this.Controls.Add(this.splitHitButton);
            this.Controls.Add(this.splitButton);
            this.Controls.Add(this.dealerHandTotalTextBox);
            this.Controls.Add(this.playerHandTotalTextBox);
            this.Controls.Add(this.dealButton);
            this.Controls.Add(this.hitButton);
            this.Controls.Add(this.doubledownButton);
            this.Controls.Add(this.stayButton);
            this.Name = "onePlayerGame";
            this.Text = "Blackjack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button stayButton;
        private System.Windows.Forms.Button doubledownButton;
        private System.Windows.Forms.Button hitButton;
        private System.Windows.Forms.Button dealButton;
        private System.Windows.Forms.TextBox playerHandTotalTextBox;
        private System.Windows.Forms.TextBox dealerHandTotalTextBox;
        private System.Windows.Forms.Button splitButton;
        private System.Windows.Forms.Button splitHitButton;
        private System.Windows.Forms.Button splitStayButton;
    }
}