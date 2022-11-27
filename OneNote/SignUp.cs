using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OneNote
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private Boolean check_existing_email(String email)
        {
            //chech if the email entered already exists in database or not?
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();

            SqlCommand sqlCommand = new SqlCommand("Select email from [User] where email = '" + email + "' ", sqlCon);
            String em_check = (string)sqlCommand.ExecuteScalar();
            if (em_check != null)
            {
                if (em_check.Equals(email))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //make user account and check if the email already exists or not
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();

            String firstname = textBox1.Text;
            String lastname = textBox2.Text;
            String email = textBox3.Text;
            String password = textBox4.Text;

            if (textBox3.Text.Contains(" "))
            {
                // for the email
                MessageBox.Show("No Spaces allowed in email");
                textBox3.Text = null;
                email = "";
            }

            if (firstname == "" || lastname == "" || email == "" || password == "")
            {
                MessageBox.Show("Plz enter all the details correctly:");
            }
            else
            {
                if (check_existing_email(email) == true)
                {
                    MessageBox.Show("Sorry: Entered email already exists in database:");
                }
                else
                {
                    String query = "insert into [User](name,lastname,email,password)" +
                   " values('" + firstname + "','" + lastname + "','" + email + "', '" + password + "')";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                    sqlCommand.Connection = sqlCon;
                    sqlCommand.CommandType = CommandType.Text;
                    int a = sqlCommand.ExecuteNonQuery();
                    if (a != -1)
                    {
                        MessageBox.Show("Account Created Successfully:");
                        LogIn login = new LogIn();
                        this.Hide();
                        login.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error: Account can not be created");
                    }

                    //Now add the firstname and user_id to the OneNote table
                    // first save the user_id into a variable

                    add_data_to_NoteBookTable(firstname, email);

                }


            }


        }

        //method to add the add the data into the NoteBook Table
        private void add_data_to_NoteBookTable(String firstname, String email)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();
            // first save the user_id into a variable
            SqlCommand sqlCommand = new SqlCommand("Select user_id from [User] where email = '" + email + "' ", sqlCon);
            int user_id = (int)sqlCommand.ExecuteScalar();

            if (user_id >= 0)
            {
                String queryOneNote = "insert into NoteBook(name,user_id) values('" + firstname + "', '" + user_id + "')";
                SqlCommand sqlCommand2 = new SqlCommand(queryOneNote, sqlCon);
                sqlCommand2.Connection = sqlCon;
                sqlCommand2.CommandType = CommandType.Text;
                int b = sqlCommand2.ExecuteNonQuery();
                if (b != -1)
                {
                    MessageBox.Show("data added to NoteBook Successfully:");
                    LogIn login = new LogIn();
                    this.Hide();
                    login.ShowDialog();
                    this.Close();
                }
                else
                {
                    Console.Write("Error in signup class buton1 ");
                }

            }
            else
            {
                Console.Write("Error in signup class buton1 ");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
