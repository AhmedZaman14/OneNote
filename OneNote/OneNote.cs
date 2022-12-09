using System;
using System.Windows.Forms;

namespace OneNote
{

    public partial class OneNote : Form
    {

        public String notebookName;
        public int notebookID;
        public OneNote()
        {
            InitializeComponent();


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry Each Account can Have only one NoteBook For now");
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            var sections = new Sections();
            sections.heading = notebookName;
            sections.NOTEBOOKID = notebookID;
            sections.ShowDialog();

        }


        private void OneNote_Load(object sender, EventArgs e)
        {
            //here u will do this 
            // lorem's NoteBook Text should change into usrs's name Notebook on the OneNote Form:
           
            labelNoteBook.Text = notebookName + "'s NoteBook";

        }



        private void ovalPictureBox1_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            this.Hide();
            login.ShowDialog();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

}

