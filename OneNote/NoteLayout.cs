using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OneNote
{
    public partial class NoteLayout : Form
    {
        public NoteLayout()
        {
            InitializeComponent();
        }

        private void NoteLayout_Load(object sender, EventArgs e)
        {

        }

        public int NOTEID;
        public void selectColor(String color)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();


            SqlCommand sqlCommand = new SqlCommand("update NoteLayout set textcolor= '" + color + "' where note_id = '" + NOTEID + "'", sqlCon);
            sqlCommand.Connection = sqlCon;
            sqlCommand.CommandType = CommandType.Text;
            int b = (int)sqlCommand.ExecuteNonQuery();
            if (b != -1)
            {

                MessageBox.Show("color added");
            }
            else
            {
                MessageBox.Show("color not set");
            }

        }

        public void selectFont(String fontName)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();


            SqlCommand sqlCommand = new SqlCommand("update NoteLayout set fontname= '" + fontName + "' where note_id = '" + NOTEID + "'", sqlCon);
            sqlCommand.Connection = sqlCon;
            sqlCommand.CommandType = CommandType.Text;
            int b = (int)sqlCommand.ExecuteNonQuery();
            if (b != -1)
            {

                MessageBox.Show("Font Applied");
            }
            else
            {
                MessageBox.Show("font not set");
            }

        }






        private void label7_Click(object sender, EventArgs e)
        {
            selectColor("Blue");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            selectColor("Purple");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            selectColor("Black");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("Georgia"))
            {
                selectFont("Georgia");
            }
            else if (comboBox1.SelectedItem.Equals("Arial"))
            {
                selectFont("Arial");
            }
            else
            {
                selectFont("Calibri");
            }

        }
    }
}

