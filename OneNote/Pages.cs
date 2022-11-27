using System;
using System.Windows.Forms;

namespace OneNote
{
    public partial class Pages : Form
    {
        public Pages()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Sections sections = new Sections();
            this.Hide();
            sections.ShowDialog();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Notes note = new Notes();
            this.Hide();
            note.ShowDialog();
            this.Close();
        }

        private void Education_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Notes note = new Notes();
            this.Hide();
            note.ShowDialog();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Notes note = new Notes();
            this.Hide();
            note.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            // make pages visibile  i have placed 10 pages so after each click make 1 visible
            //each page will have  a note
        }
    }
}
