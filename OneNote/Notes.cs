using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OneNote
{
    public partial class Notes : Form
    {
        public Notes()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            // first save the notes then go back.
            saveNote();
            this.Close();
        }

        //method to save the text written in richtextbox 
        public void saveNote()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();

            SqlCommand sqlCommand = new SqlCommand("update Note set text = '"+richTextBox1.Text+"'  where note_id = '" + NOTEid + "'", sqlCon);
            sqlCommand.Connection = sqlCon;
            sqlCommand.CommandType = CommandType.Text;
            int b = (int)sqlCommand.ExecuteNonQuery();
            if (b != -1)
            {
              //  MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Error");
            }


        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            NoteLayout layout = new NoteLayout();
            this.Hide();
            layout.ShowDialog();
            this.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            checkedListBox1.Visible = true;

        }
        private const int CP_NOCLOSE_BUTTON = 0x200;

        //to disable the close button
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        //so that when note loads it displays the clicked/dersired note.
        public int NOTEid;

        private void Notes_Load(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();
            
            SqlCommand sqlCommand = new SqlCommand("select text from Note where note_id = '"+NOTEid+"'",sqlCon);
            sqlCommand.Connection = sqlCon;
            sqlCommand.CommandType = CommandType.Text;
            richTextBox1.Text= sqlCommand.ExecuteScalar().ToString();


            //to get NoteName \(noteName = paganame)
            SqlCommand sqlCommand1 = new SqlCommand("select pageTitle from [Page] where note_id = '" + NOTEid + "'", sqlCon);
            sqlCommand1.Connection = sqlCon;
            sqlCommand1.CommandType = CommandType.Text;
            label1.Text = sqlCommand1.ExecuteScalar().ToString();

            //to getDate of Page Creation
            SqlCommand sqlCommand2 = new SqlCommand("select creationDate from [Note] where note_id = '" + NOTEid + "'", sqlCon);
            sqlCommand2.Connection = sqlCon;
            sqlCommand2.CommandType = CommandType.Text;
            label4.Text = sqlCommand2.ExecuteScalar().ToString();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure", "Delete Note", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                deleteNote();
                this.Close();
                //to close previous form so that it can reload.
                Pages obj = (Pages)Application.OpenForms["Pages"];
                obj.Close();

                //delete the note/page

            }
            else if (MessageBox.Show("Are you sure", "Delete Note", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                //do not delete
                checkedListBox1.Visible = false;
            }
        }

        private void deleteNote()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();

            SqlCommand sqlCommand = new SqlCommand("delete from Page  where note_id = '" + NOTEid + "'", sqlCon);
            sqlCommand.Connection = sqlCon;
            sqlCommand.CommandType = CommandType.Text;
            int b = (int)sqlCommand.ExecuteNonQuery();
            if (b != -1)
            {
                SqlCommand sqlCommand1 = new SqlCommand("delete from Note  where note_id = '" + NOTEid + "'", sqlCon);
                sqlCommand1.Connection = sqlCon;
                sqlCommand1.CommandType = CommandType.Text;
                int a = (int)sqlCommand1.ExecuteNonQuery();
                if (a!=-1)
                {
                    //  MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("Not Deleted from Note");
                }

            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

