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
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.hitButton = new System.Windows.Forms.Button();
            this.dealButton = new System.Windows.Forms.Button();
            this.playerHandTotalTextBox = new System.Windows.Forms.TextBox();
            this.dealerHandTotalTextBox = new System.Windows.Forms.TextBox();
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(865, 266);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 46);
            this.button3.TabIndex = 7;
            this.button3.Text = "Double Down";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(865, 338);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 46);
            this.button4.TabIndex = 8;
            this.button4.Text = "Split";
            this.button4.UseVisualStyleBackColor = true;
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
            this.playerHandTotalTextBox.Size = new System.Drawing.Size(218, 31);
            this.playerHandTotalTextBox.TabIndex = 11;
            // 
            // dealerHandTotalTextBox
            // 
            this.dealerHandTotalTextBox.BackColor = System.Drawing.SystemColors.MenuText;
            this.dealerHandTotalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dealerHandTotalTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.dealerHandTotalTextBox.Location = new System.Drawing.Point(743, 609);
            this.dealerHandTotalTextBox.Name = "dealerHandTotalTextBox";
            this.dealerHandTotalTextBox.Size = new System.Drawing.Size(218, 31);
            this.dealerHandTotalTextBox.TabIndex = 12;
            // 
            // onePlayerGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(962, 713);
            this.Controls.Add(this.dealerHandTotalTextBox);
            this.Controls.Add(this.playerHandTotalTextBox);
            this.Controls.Add(this.dealButton);
            this.Controls.Add(this.hitButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.stayButton);
            this.Name = "onePlayerGame";
            this.Text = "Blackjack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button stayButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button hitButton;
        private System.Windows.Forms.Button dealButton;
        private System.Windows.Forms.TextBox playerHandTotalTextBox;
        private System.Windows.Forms.TextBox dealerHandTotalTextBox;
    }
}