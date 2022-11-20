using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            OneNote onenoteform = new OneNote();
            this.Hide();
            onenoteform.ShowDialog();
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
