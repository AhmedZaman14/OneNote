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
        //to add data into the User(NotebookId)

        private void set_NoteBookID_in_Userr(String email)
        {



            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();

            giveUser3Sections(email, sqlCon);


            // first save the user_id into a variable(userid==notebookid always i guess)
            SqlCommand sqlCommand = new SqlCommand("Select Notebookid from [Notebook] where email = '" + email + "' ", sqlCon);
            int NotebookID = (int)sqlCommand.ExecuteScalar();
            // Pages pages = new Pages();
            // pages.notebookId = NotebookID;

            String queryOneNote = "update [User] set NotebookId = '" + NotebookID + "' where email = '" + email + "'";
            SqlCommand sqlCommand2 = new SqlCommand(queryOneNote, sqlCon);
            sqlCommand2.Connection = sqlCon;
            sqlCommand2.CommandType = CommandType.Text;
            int b = sqlCommand2.ExecuteNonQuery();
            if (b != -1)
            {
                Console.Write("data added to Useer(NotebookId) Successfully:");

            }
            else
            {
                Console.Write("Error in set_noteBookId ");
            }

        }


        private void giveUser3Sections(String email, SqlConnection sqlcon)
        {
            //first save notebookID 
            SqlCommand sqlCommand = new SqlCommand("Select NotebookId from [NoteBook] where email = '" + email + "' ", sqlcon);

            int notebookID = (int)sqlCommand.ExecuteScalar();

            var pages = new Pages();

            if (notebookID != -1)
            {

                String query = "insert into Section(name,notebookId) values('Education/Work','" + notebookID + "')," +
                    "('Weekend','" + notebookID + "'),('Imp','" + notebookID + "')";
                SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                sqlCmd.Connection = sqlcon;
                sqlCmd.CommandType = CommandType.Text;
                int b = sqlCmd.ExecuteNonQuery();
                if (b != -1)
                {

                    Console.Write("sections added:");

                }
                else
                {
                    MessageBox.Show("sections nooooot added:");
                }

            }
            else
            {
                MessageBox.Show("Error in signup class giveuser3section---");
            }

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



            // check if the email already exists or not
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();

            String firstname = textBox1.Text.Trim();
            String lastname = textBox2.Text.Trim();
            String email = textBox3.Text.Trim();
            String password = textBox4.Text.Trim();

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
                this.Hide();
                this.Close();
                SignUp signUp = new SignUp();
                signUp.ShowDialog();
            }
            else
            {
                if (check_existing_email(email) == true)
                {
                    MessageBox.Show("Sorry: Entered email already exists:");
                    this.Hide();
                    this.Close();
                    SignUp signUp = new SignUp();
                    signUp.ShowDialog();
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
                        add_data_to_NoteBookTable(firstname, email, sqlCon);
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


                }


            }


        }

        //method to add the data into the NoteBook Table
        private void add_data_to_NoteBookTable(String firstname, String email, SqlConnection sqlCon)
        {
            String queryOneNote = "insert into NoteBook(name,email) values('" + firstname + "' ,'" + email + "')";
            SqlCommand sqlCommand2 = new SqlCommand(queryOneNote, sqlCon);
            sqlCommand2.Connection = sqlCon;
            sqlCommand2.CommandType = CommandType.Text;
            int b = sqlCommand2.ExecuteNonQuery();
            if (b != -1)
            {
                set_NoteBookID_in_Userr(email);
                Console.WriteLine("data added to NoteBook Successfully:");
            }
            else
            {
                MessageBox.Show("Error in signup class buton1---add_data_toNotebookmethod ");
            }

        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
