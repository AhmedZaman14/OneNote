using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

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

            SqlCommand sqlCommand = new SqlCommand("update Note set text = '" + richTextBox1.Text + "'  where note_id = '" + NOTEid + "'", sqlCon);
            sqlCommand.Connection = sqlCon;
            sqlCommand.CommandType = CommandType.Text;
            int b = (int)sqlCommand.ExecuteNonQuery();
            if (b != -1)
            {
                addCategoryToNote(NOTEid,sqlCon);
                //  MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Error");
            }


        }

        private void setFont(int Noteid, SqlConnection sqlCon)
        {

            String fontName, textcolor;
            SqlCommand sqlCommand = new SqlCommand("Select fontname from [NoteLayout] where note_id = '" + Noteid + "' ", sqlCon);
            fontName = (string)sqlCommand.ExecuteScalar();
            if (fontName != null)
            {
                if (fontName.Equals("Calibri"))
                {

                    richTextBox1.Font = new Font("Calibri", 9);
                }
                else if (fontName.Equals("Arial"))
                {
                    richTextBox1.Font = new Font("Arial", 9);
                }
            }
            else
            {
                richTextBox1.Font = new Font("Georgia", 9);
            }
        }

        private void setColor(int Noteid, SqlConnection sqlCon)
        {

            String textcolor;
            SqlCommand sqlCommand = new SqlCommand("Select textColor from [NoteLayout] where note_id = '" + Noteid + "' ", sqlCon);
            textcolor = (string)sqlCommand.ExecuteScalar();
            if (textcolor != null)
            {
                if (textcolor.Equals("Blue"))
                {

                    richTextBox1.ForeColor = Color.Blue;
                }
                else if (textcolor.Equals("Purple"))
                {
                    richTextBox1.ForeColor = Color.Purple;
                }
            }
            else
            {
                richTextBox1.ForeColor = Color.Black;
            }
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            saveNote();

            NoteLayout layout = new NoteLayout();
            this.Close();
            layout.NOTEID = NOTEid;
            layout.ShowDialog();



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

            SqlCommand sqlCommand = new SqlCommand("select text from Note where note_id = '" + NOTEid + "'", sqlCon);
            sqlCommand.Connection = sqlCon;
            sqlCommand.CommandType = CommandType.Text;
            richTextBox1.Text = sqlCommand.ExecuteScalar().ToString();


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

            setFont(NOTEid, sqlCon);
            setColor(NOTEid, sqlCon);
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
                SqlCommand sqlCommand11 = new SqlCommand("delete from NoteLayout  where note_id = '" + NOTEid + "'", sqlCon);
                sqlCommand11.Connection = sqlCon;
                sqlCommand11.CommandType = CommandType.Text;
                int c = (int)sqlCommand11.ExecuteNonQuery();

                if (c != -1)
                {
                    SqlCommand sqlCommand1 = new SqlCommand("delete from Note  where note_id = '" + NOTEid + "'", sqlCon);
                    sqlCommand1.Connection = sqlCon;
                    sqlCommand1.CommandType = CommandType.Text;
                    int a = (int)sqlCommand1.ExecuteNonQuery();
                    if (a != -1)
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


        private void addCategoryToNote(int note_id, SqlConnection sqlCon)
        {
            String category = getCategoryfromText(note_id, sqlCon);
            String query;
            if (category.Equals("School"))
            {
                query = "update Note set category_id = 1 where note_id ='"+note_id+"'";
            }
            else if (category.Equals("work"))
            {
                query = "update Note set category_id = 2 where note_id ='" + note_id + "'";
            }
            else if (category.Equals("Domiciliary"))
            {
                query = "update Note set category_id = 3 where note_id ='" + note_id + "'";
            }
            else
            {
                query = "update Note set category_id = 4 where note_id ='" + note_id + "'";
            }

            SqlCommand cmd = new SqlCommand(query,sqlCon);
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.Text;
            int b = (int)cmd.ExecuteNonQuery();
            if (b != -1)
            {

              //  MessageBox.Show("Category  added");
            }
            else
            {
                MessageBox.Show("Category not added");
            }
        }

        //keywords to categorize (just ignore these)
        String[] School = { "assignment", "quiz", "homework", "class", "education", "teacher", "course" };
        String[] work = { "project", "team", "boss", "email" };
        String[] Domiciliary = { "groceries", "food", "bills", "car","family" ,"whatever" };
        private string getCategoryfromText(int note_id, SqlConnection sqlCon)
        {
            for (int i=0;i<School.Length;i++) {
                if (richTextBox1.Text.Contains(School[i])) 
                {
                    
                    return "School";

                }
                

            }
            for (int i = 0; i < work.Length; i++)
            {
                if (richTextBox1.Text.Contains(work[i])) 
                {
                    return "Work";

                }

            }

            for (int i = 0; i < Domiciliary.Length; i++)
            {
                if (richTextBox1.Text.Contains(Domiciliary[i])) 
                {
                    return "Domiciliary";

                }

            }

            return "other";

           

        }
    }
}

