using System;
using System.Windows.Forms;

namespace OneNote
{
    public partial class Sections : Form
    {
        public int NOTEBOOKID;
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
            var OFedu = new Pages();
            OFedu.PagesFormHeading = "Education/Work";
            OFedu.NOTEBOOKid = NOTEBOOKID;
            OFedu.ShowDialog();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            var OFweekend = new Pages();
            OFweekend.PagesFormHeading = "Weekend";
            OFweekend.NOTEBOOKid = NOTEBOOKID;
            OFweekend.ShowDialog();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            var OFimp = new Pages();
            OFimp.PagesFormHeading = "Imp";
            OFimp.NOTEBOOKid = NOTEBOOKID;
            OFimp.ShowDialog();

        }
        public String heading = "";
        private void Sections_Load(object sender, EventArgs e)
        {
            //first display the name above
            label1heading.Text = heading + "'s NoteBook";
        }
    }
}
