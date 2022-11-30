using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OneNote
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }


        private void LogIn_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp signupform = new SignUp();
            this.Hide();
            signupform.ShowDialog();
            this.Close();
        }

        private Boolean check_Account_existance(String email,SqlConnection sqlConnection)
        {
            //chech if the email entered already exists in database or not?
            

            SqlCommand sqlCommand = new SqlCommand("Select email from [User] where email = '" + email + "' ",sqlConnection);
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

        private Boolean check_password(String email, String pass,SqlConnection sqlCon)
        {
            //check if the entered password for that email is correct
            
            SqlCommand sqlCommand = new SqlCommand("Select password from [User] where email = '" + email + "' ", sqlCon);
            String pass_chech = (string)sqlCommand.ExecuteScalar();
            if (pass_chech != null)
            {
                if (pass_chech.Equals(pass))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Password does not matches");
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        private String throw_NoteBookName = "";
        private String getUserName(String email,SqlConnection sqlCon)
        {
           

            String query = "Select [name] from [User] where email = '" + email + "' ";
            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            String name = (string)sqlCommand.ExecuteScalar();
            if (name != null)
            {

                return name;
            }
            else
            {

                return "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //also will have to add a specific method so if the email is of Admin he
            //wil be directed to the Admin's Form

            String email = textBox1.Text.TrimEnd();
            String pass = textBox2.Text.TrimEnd();

            //first varify if the entered acccount exists or not
            if (email == "" || pass == "")
            {
                MessageBox.Show("Plz enter all the details correctly:");
            }
            else
            {
                //now check the account exists or not
                SqlConnection sqlCon = new SqlConnection();
                sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
                sqlCon.Open();

                if (check_Account_existance(email,sqlCon) == true)
                {
                    //now check if the passwor entered for this email is correct.
                    if (check_password(email, pass,sqlCon) == true)
                    {
                        //done
                        //now user will be directed to the main page of application 
                        //and lorem's NoteBook Text should change into usrs's Notebook on the OneNote Form

                        String throw_email = email;

                        throw_NoteBookName = getUserName(throw_email,sqlCon);
                        
                        OneNote one = new OneNote();
                        this.Hide();
                        one.notebookName = throw_NoteBookName;
                        one.ShowDialog();
                        this.Close();
                        
                    }

                }
                else
                {
                    sqlCon.Close();
                    MessageBox.Show("No Account found with this email");
                }



            }

        }
    }
}
