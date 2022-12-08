using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace OneNote
{
    public partial class UsersInfo : Form
    {

      
        public UsersInfo()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //by clicking on it admin will be able to delete the user 
            show1.Visible = true;
            show2.Visible = true;
            show3.Visible = true;
            show4.Visible = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       private int buttonClickCOunt=0;
        private void UsersInfo_Load(object sender, EventArgs e)
        {
            buttonClickCOunt=0;
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();
            int user_id = getFirstUserid();
            getColumns(user_id, sqlCon);
        }

        private void getColumns(int user_id, SqlConnection sqlCon)
        {
            try
            {

                String query = "select user_id,CONCAT([User].name,'" + " " + "' ,lastname),email,count(page_id) from [User]" +
                    "\r\njoin Section on Section.notebookID=[User].NotebookID\r\n" +
                    "join Page on Page.section_id = Section.section_id \r\ngroup by user_id,[User].name," +
                    "lastname,email\r\nhaving user_id ='" + user_id + "'";
                SqlCommand cmd = new SqlCommand(query, sqlCon);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows == true)
                {
                    reader.Read();
                    String space = new String(' ', 25);

                    firstcolumn.Text = (string)reader[0].ToString() + "'" + space + "'" + (string)reader[1].ToString() + "'" + space + "'"
                        + (string)reader[2].ToString() + "'" + space + "'" + (string)reader[3].ToString();
                }
                else
                {
                    reader.Close();
                    String query2 = "select user_id,CONCAT([User].name,'" + " " + "' ,lastname),email from [User]" +
                        "where user_id= '" + user_id + "'";
                    SqlCommand cmd2 = new SqlCommand(query2, sqlCon);

                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    reader2.Read();
                    String space = new String(' ', 25);

                    firstcolumn.Text = (string)reader2[0].ToString() + "'" + space + "'" + (string)reader2[1].ToString() + "'" + space + "'"
                        + (string)reader2[2].ToString();
                }
            }
            catch(Exception e)
            {
                return;
            }
        }

        private static int getFirstUserid()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();
            try
            {
                //it will bring the first userid to display
                SqlCommand sqlCommand = new SqlCommand("Select Min(user_id) from [User] ", sqlCon);
                int userId = (int)sqlCommand.ExecuteScalar();
                if (userId != -1)
                {
                    return userId;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
               
                
                 return -1;
            }
        }


        private static int getLastUserid()
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();
            try
            {
                //to get last userid so to stop displaying userinfo
                SqlCommand sqlCommand = new SqlCommand("Select Max(user_id) from [User] ", sqlCon);
                int maxUserId = (int)sqlCommand.ExecuteScalar();
                if (maxUserId != -1)
                {
                    return maxUserId;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();
            
            buttonClickCOunt++;
            int USERID = getFirstUserid();
            USERID =USERID + buttonClickCOunt;
            if (USERID <= getLastUserid())
                getColumns(USERID, sqlCon);
            else
                MessageBox.Show("End of List");
            
        }

        private void show4_Click(object sender, EventArgs e)
        {
            show1.Visible = false;
            show2.Visible = false;
            show3.Visible = false;
            show4.Visible = false;

        }

        private void show3_Click(object sender, EventArgs e)
        {
            if (show2.Text.Equals(""))
            {
                MessageBox.Show("Enter User_id");
            }
            else
            {
                String user_id = show2.Text.ToString();
                for (int i = 0; i < user_id.Length; i++)
                {
                    if (!char.IsNumber(user_id[i]))
                    {
                        MessageBox.Show("Please enter a valid number");
                        show2.Text = "";
                        user_id = "-1";
                    }

                }

                if (!user_id.Equals("-1")) { 
                SqlConnection sqlCon = new SqlConnection();
                sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True ;MultipleActiveResultSets=true";
                sqlCon.Open();


                  
                        SqlCommand sqlCommand = new SqlCommand("IF exists (Select user_id from [User] where user_id= '" + user_id + "') select 1 else select -1 ", sqlCon);
                        int a =(int) sqlCommand.ExecuteScalar();

                        if (a != -1)
                        {
                            int USER_ID = int.Parse(user_id);

                            //delete user
                            //  deleteUser(USER_ID, sqlCon);
                            deleteAllDataofThisUser(USER_ID, sqlCon);


                        }
                        else
                        {

                            MessageBox.Show("Userid '" + user_id + "' not exists");

                        }
                    
                  
                    
                    }
                   
             }
            }
        



        private int getNotebookId(int user_id , SqlConnection sqlCon)
        {
            SqlCommand sqlCommand = new SqlCommand("Select notebookid from Notebook where email=" +
                "(select email from [User] where user_id = '"+user_id+"') ", sqlCon);
            int notebookId = (int)sqlCommand.ExecuteScalar();
            return notebookId;
        }

        private void deleteNotebookId(int NoteBookid,SqlConnection sqlCon)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete from Notebook where notebookid ='"+NoteBookid+"'", sqlCon);
            sqlCommand.ExecuteNonQuery();   
        }

        private int getSectionId(int user_id,int noteBookid,SqlConnection sqlCon)
        {
            
            String query = "select section_id from Section where notebookID ='"+noteBookid+ "' and name='Education/Work'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
            return (int)sqlCommand.ExecuteScalar();
        }

        private int PageCountOfthisUser(int user_id, int sectionId, SqlConnection sqlCon)
        {
                String query = "if exists (select page_id from [Page] where Section_id ='" + sectionId + "' or Section_id = '" + (sectionId + 1) + "'  or Section_id = '" + (sectionId + 2) + "') " +
                "Select count(page_id) from [Page] where Section_id ='" + sectionId + "' or Section_id = '" + (sectionId + 1) + "'  or Section_id = '" + (sectionId + 2) + "' ELSE Select 0";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                return (int)sqlCommand.ExecuteScalar();
            
                
           
        }


        private int[] getPageId(int user_id, int sectionId, int pageCount, SqlConnection sqlCon)
        {
           
            int[] page_id_arr = new int[pageCount];
            if (pageCount > 0)
            {
                
                String query = "select page_id from [Page] where Section_id ='" + sectionId + "' or Section_id = '" + (sectionId + 1) + "'  or Section_id = '" + (sectionId + 2) + "' ";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                

                
                    for (int i = 0; i < pageCount; i++)
                    {
                    reader.Read();
                    page_id_arr[i] = (int)reader[0];
                    
                    }

                    return page_id_arr;
                
            }
            else
            {
               
                return page_id_arr;
            }
        }

        private int[] getNoteid(int[] pageids, SqlConnection sqlCon)
        {
            int[] noteids = new int[pageids.Length];

           for (int i = 0;i<pageids.Length;i++) { 
            SqlCommand sqlCommand = new SqlCommand("select note_id from Page where page_id= '" + pageids[i] +"'", sqlCon);
                noteids[i]=(int)sqlCommand.ExecuteScalar();
               
           
            }


            return noteids;
        }

        private int[] getNoteLayoutids(int[] noteids, SqlConnection sqlCon)
        {
            int[] notelayoutIds = new int[noteids.Length];
            for (int i = 0; i < noteids.Length; i++)
            {
                SqlCommand sqlCommand = new SqlCommand("select layout_id from NoteLayout where note_id='" + noteids[i] +"'", sqlCon);
                notelayoutIds[i] = (int)sqlCommand.ExecuteScalar();

            }
            return notelayoutIds;

        }

        private void deleteAllDataofThisUser(int userid,SqlConnection sqlCon)
        {
            int Notebookid =    getNotebookId(userid,sqlCon);
            int Sectionid = getSectionId(userid,Notebookid,sqlCon);
            int pageCount =PageCountOfthisUser(userid, Sectionid, sqlCon);
            int[] pageid = getPageId(userid, Sectionid,pageCount ,sqlCon);
            int[] Noteid = getNoteid(pageid,sqlCon);
            int[] NoteLayoutid = getNoteLayoutids(Noteid,sqlCon);
            
            
            deleteNoteLayout(NoteLayoutid,sqlCon);
            deletePage(Sectionid, userid, sqlCon);
            deleteNotes(Noteid,sqlCon);
            deleteSection(Sectionid,sqlCon);
            deleteUser(userid,sqlCon);
            deleteNotebookId(Notebookid, sqlCon);
            

            
            

        }

        private void deleteNotes(int[] noteids,SqlConnection sqlCon)
        {
          
            for (int i = 0; i < noteids.Length; i++)
            {
                SqlCommand sqlCommand = new SqlCommand("delete from Note where note_id='" + noteids[i] + "'", sqlCon);
                sqlCommand.ExecuteNonQuery();
            }
        }

        
        private void deleteNoteLayout(int[] notelayoutids ,SqlConnection sqlCon)
        {
            for (int i = 0; i < notelayoutids.Length; i++)
            {
                SqlCommand sqlCommand = new SqlCommand("delete from NoteLayout where layout_id='" + notelayoutids[i] + "'", sqlCon);
                sqlCommand.ExecuteNonQuery();

            }
        }

        private void deleteSection(int sectionid ,SqlConnection sqlCon)
        {
          
                SqlCommand sqlCommand = new SqlCommand("delete from Section where section_id='" +sectionid+ "' or section_id='" +(sectionid+1)+ "' or section_id='" +(sectionid+2)+ "'  ", sqlCon);
                sqlCommand.ExecuteNonQuery();

            
        }



        private void deleteUser(int user_id, SqlConnection sqlCon)
        {
            SqlCommand sqlCommand = new SqlCommand("Delete  from [User] where user_id= '" + user_id + "' ", sqlCon);
            int a = (int)sqlCommand.ExecuteNonQuery();
            if (a!=-1)
            {

                MessageBox.Show("User Deleted");
            }
            else
            {
                MessageBox.Show("Error while deleting user");
            }
        }

        private void deletePage(int Sectionid,int user_id, SqlConnection sqlCon)
        {
           
                SqlCommand sqlCommand = new SqlCommand("delete from Page where section_id = '" + Sectionid + "' Or  section_id = '" + (Sectionid + 1) + "' Or  section_id = '" + (Sectionid + 2) + "'  ", sqlCon);
                sqlCommand.ExecuteNonQuery();
            
               
        }
    }
    
}
