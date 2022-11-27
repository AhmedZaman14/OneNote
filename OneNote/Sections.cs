using System;
using System.Windows.Forms;

namespace OneNote
{
    public partial class Sections : Form
    {
        public Sections()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //so that back icon is clicked the user go back to the same OneNote Form:
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Pages eduform = new Pages();
            this.Hide();
            eduform.ShowDialog();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Pages eduform = new Pages();
            this.Hide();
            eduform.ShowDialog();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Pages eduform = new Pages();
            this.Hide();
            eduform.ShowDialog();
            this.Close();
        }
    }
}
