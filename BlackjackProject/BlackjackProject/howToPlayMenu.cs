using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackjackProject
{
    public partial class howToPlayMenu : Form
    {
        public howToPlayMenu()
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
            this.MaximizeBox = false;
            //backToMenuButton.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void backToMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }
    }
}
