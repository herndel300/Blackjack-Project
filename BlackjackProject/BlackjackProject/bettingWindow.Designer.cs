namespace BlackjackProject
{
    partial class bettingWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.acceptButton = new System.Windows.Forms.Button();
            this.desiredWagerUpDown = new System.Windows.Forms.NumericUpDown();
            this.currentChipsTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.desiredWagerUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Amount of Chips";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Desired Wager";
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(138, 259);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 4;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // desiredWagerUpDown
            // 
            this.desiredWagerUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desiredWagerUpDown.Location = new System.Drawing.Point(95, 167);
            this.desiredWagerUpDown.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.desiredWagerUpDown.Name = "desiredWagerUpDown";
            this.desiredWagerUpDown.Size = new System.Drawing.Size(179, 38);
            this.desiredWagerUpDown.TabIndex = 5;
            // 
            // currentChipsTextBox
            // 
            this.currentChipsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentChipsTextBox.Location = new System.Drawing.Point(95, 81);
            this.currentChipsTextBox.Name = "currentChipsTextBox";
            this.currentChipsTextBox.Size = new System.Drawing.Size(179, 38);
            this.currentChipsTextBox.TabIndex = 0;
            // 
            // bettingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 346);
            this.Controls.Add(this.desiredWagerUpDown);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentChipsTextBox);
            this.Name = "bettingWindow";
            this.Text = "Blackjack";
            ((System.ComponentModel.ISupportInitialize)(this.desiredWagerUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button acceptButton;
        public System.Windows.Forms.NumericUpDown desiredWagerUpDown;
        public System.Windows.Forms.TextBox currentChipsTextBox;
    }
}