using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OneNote
{
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            UsersInfo users = new UsersInfo();
            this.Hide();
            this.Close();
            users.ShowDialog();
            Administrator administrator = new Administrator();
            administrator.ShowDialog();

        }

        private void Administrator_Load(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();

            totalUserLabel.Text = totalUsers(sqlCon).ToString();
            totalNotesLabel.Text = totalNotes(sqlCon).ToString();
            categoryLabel.Text = totalCategories(sqlCon).ToString();
        }

        private int totalCategories(SqlConnection sqlCon)
        {
            return 4;
        }
        private int totalNotes(SqlConnection sqlCon)
        {

            SqlCommand sqlCommand = new SqlCommand("Select Count(note_id) from [Note]", sqlCon);
            int t_Notes = (int)sqlCommand.ExecuteScalar();
            if (t_Notes != -1)
            {
                return t_Notes;
            }
            else
            {

                return 0;
            }
        }

        private int totalUsers(SqlConnection sqlCon)
        {
            SqlCommand sqlCommand = new SqlCommand("Select Count(user_id) from [User]", sqlCon);
            int t_Users = (int)sqlCommand.ExecuteScalar();
            if (t_Users != -1)
            {
                return t_Users;
            }
            else
            {

                return 0;
            }
        }
    }
}
