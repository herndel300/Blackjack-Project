namespace BlackjackProject
{
    partial class howToPlayMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(howToPlayMenu));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.backToMenuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Green;
            this.richTextBox1.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Gold;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1182, 759);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // backToMenuButton
            // 
            this.backToMenuButton.Location = new System.Drawing.Point(1073, 12);
            this.backToMenuButton.Name = "backToMenuButton";
            this.backToMenuButton.Size = new System.Drawing.Size(79, 45);
            this.backToMenuButton.TabIndex = 1;
            this.backToMenuButton.Text = "Back";
            this.backToMenuButton.UseVisualStyleBackColor = true;
            this.backToMenuButton.Click += new System.EventHandler(this.backToMenuButton_Click);
            // 
            // howToPlayMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1183, 759);
            this.Controls.Add(this.backToMenuButton);
            this.Controls.Add(this.richTextBox1);
            this.Name = "howToPlayMenu";
            this.Text = "Blackjack";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button backToMenuButton;
    }
}