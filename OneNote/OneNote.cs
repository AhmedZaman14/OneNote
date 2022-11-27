using System;
using System.Windows.Forms;

namespace OneNote
{

    public partial class OneNote : Form
    {

        public String notebookName;
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
            sections.ShowDialog();

        }





        private void OneNote_Load(object sender, EventArgs e)
        {
            //here u will do this 
            // lorem's NoteBook Text should change into usrs's name Notebook on the OneNote Form:
            //Now first retreive the email of the User from database
            // and then add that NoteBook Name and user_id to the NoteBook table.

            //All done on the login.cs 
            //here write how u did it 




            
            //labelNoteBook.BackColor= Color.Black;
            labelNoteBook.Text = notebookName + "'s NoteBook";

        }
    }

}

