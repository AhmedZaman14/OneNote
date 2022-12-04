using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace OneNote
{
    public partial class Pages : Form
    {

        public int NOTEBOOKid;
        public Pages()
        {
            InitializeComponent();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            this.Close();
        }


        public String PagesFormHeading;

        int countOfPage = 0;
        private void Education_Load(object sender, EventArgs e)
        {
            label1.Text = PagesFormHeading;



            //depending on sectionID and name make pages visible if user already have pages.
            //first through notebookid save the sectionid.
            int sectionID = -1;
            int notebookId = NOTEBOOKid;
            

            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();
            if (notebookId != -1)
            {
                //MessageBox.Show(""+notebookId);
                SqlCommand sqlCommand = new SqlCommand("Select section_id from [Section] where notebookID= '" + notebookId + "' and name = '" + PagesFormHeading + "' ", sqlCon);
                sectionID = (int)sqlCommand.ExecuteScalar();
                if (sectionID != -1)
                {
                    // now u have sectionid inside which the user is currently in.
                    //so save the count of the pages inside that section.
                    //i am saving the count of noteid not the pageid becouse it will help later.

                    countOfPage =getPageCount(sectionID,sqlCon);
                    displaypages(countOfPage,sectionID,  sqlCon);
                }
                else {
                    MessageBox.Show("sectionid couldnot be found: pagesload()");
                }


            }
            else
            {
                MessageBox.Show("NotebookID could not be found in Pages.cs");
            }




        }

        private int getNoteId(int sectionId,String pageTitle, SqlConnection sqlCon)
        {
            SqlCommand cmd = new SqlCommand("Select note_id from [Page] where section_id='" + sectionId + "' and pageTitle = '" + pageTitle + "' ", sqlCon);
            int noteId = (int)cmd.ExecuteScalar();
            if (noteId!=-1)
            {
                return noteId;
            }
            else
            {
                MessageBox.Show("getNoteId error:");
                return -1;
            }
            
        }

        public List<int> NOTEID_list = new List<int>();     
        private void displaypages(int countofpage,int sectionID,SqlConnection sqlCon){
            if (countofpage>=1)
            {
                SqlCommand cmd = new SqlCommand("select pagetitle from [Page] where section_id ='"+sectionID+"'", sqlCon);

                SqlDataReader reader = cmd.ExecuteReader();

                

                if (countofpage==1)
                {
                    reader.Read();
                    labelpage1.Text = (string)reader[0].ToString();
                    
                    labelpage1.Visible = true;
                    reader.Close();
                    NOTEID_list.Add(getNoteId(sectionID, labelpage1.Text, sqlCon)) ;
                }
                if (countofpage==2)
                {
                    reader.Read();
                    labelpage1.Text = (string)reader[0].ToString();
                    labelpage1.Visible = true;
                    reader.Read();
                    labelpage2.Text = (string)reader[0].ToString();
                    labelpage2.Visible = true;
                    reader.Close();
                    NOTEID_list.Add(getNoteId(sectionID, labelpage1.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage2.Text, sqlCon));
                }
                if (countofpage==3)
                {
                    reader.Read();
                    labelpage1.Text = (string)reader[0].ToString();
                    labelpage1.Visible = true;
                    reader.Read();
                    labelpage2.Text = (string)reader[0].ToString();
                    labelpage2.Visible = true;
                    reader.Read();
                    labelpage3.Text = (string)reader[0].ToString();
                    labelpage3.Visible = true;
                    reader.Close();
                    NOTEID_list.Add(getNoteId(sectionID, labelpage1.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage2.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID,labelpage3.Text,sqlCon));
                }
                if (countofpage == 4)
                {
                    reader.Read();
                    labelpage1.Text = (string)reader[0].ToString();
                    labelpage1.Visible = true;
                    reader.Read();
                    labelpage2.Text = (string)reader[0].ToString();
                    labelpage2.Visible = true;
                    reader.Read();
                    labelpage3.Text = (string)reader[0].ToString();
                    labelpage3.Visible = true;
                    reader.Read();
                    labelpage4.Text = (string)reader[0].ToString();
                    labelpage4.Visible = true;
                    reader.Close();
                    NOTEID_list.Add(getNoteId(sectionID, labelpage1.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage2.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage3.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage4.Text, sqlCon));
                }
                if (countofpage == 5)
                {
                    reader.Read();
                    labelpage1.Text = (string)reader[0].ToString();
                    labelpage1.Visible = true;
                    reader.Read();
                    labelpage2.Text = (string)reader[0].ToString();
                    labelpage2.Visible = true;
                    reader.Read();
                    labelpage3.Text = (string)reader[0].ToString();
                    labelpage3.Visible = true;
                    reader.Read();
                    labelpage4.Text = (string)reader[0].ToString();
                    labelpage4.Visible = true;
                    reader.Read();
                    labelpage5.Text = (string)reader[0].ToString();
                    labelpage5.Visible = true;
                    reader.Close();
                    NOTEID_list.Add(getNoteId(sectionID, labelpage1.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage2.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage3.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage4.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage5.Text, sqlCon));
                }
                if (countofpage == 6)
                {
                    reader.Read();
                    labelpage1.Text = (string)reader[0].ToString();
                    labelpage1.Visible = true;
                    reader.Read();
                    labelpage2.Text = (string)reader[0].ToString();
                    labelpage2.Visible = true;
                    reader.Read();
                    labelpage3.Text = (string)reader[0].ToString();
                    labelpage3.Visible = true;
                    reader.Read();
                    labelpage4.Text = (string)reader[0].ToString();
                    labelpage4.Visible = true;
                    reader.Read();
                    labelpage5.Text = (string)reader[0].ToString();
                    labelpage5.Visible = true;
                    reader.Read();
                    labelpage6.Text = (string)reader[0].ToString();
                    labelpage6.Visible = true;
                    reader.Close();
                    NOTEID_list.Add(getNoteId(sectionID, labelpage1.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage2.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage3.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage4.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage5.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage6.Text, sqlCon));
                }
                if (countofpage == 7)
                {
                    reader.Read();
                    labelpage1.Text = (string)reader[0].ToString();
                    labelpage1.Visible = true;
                    reader.Read();
                    labelpage2.Text = (string)reader[0].ToString();
                    labelpage2.Visible = true;
                    reader.Read();
                    labelpage3.Text = (string)reader[0].ToString();
                    labelpage3.Visible = true;
                    reader.Read();
                    labelpage4.Text = (string)reader[0].ToString();
                    labelpage4.Visible = true;
                    reader.Read();
                    labelpage5.Text = (string)reader[0].ToString();
                    labelpage5.Visible = true;
                    reader.Read();
                    labelpage6.Text = (string)reader[0].ToString();
                    labelpage6.Visible = true;
                    reader.Read();
                    labelpage7.Text = (string)reader[0].ToString();
                    labelpage7.Visible = true;
                    reader.Close();
                    NOTEID_list.Add(getNoteId(sectionID, labelpage1.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage2.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage3.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage4.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage5.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage6.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage7.Text, sqlCon));
                }
                if (countofpage == 8)
                {
                    reader.Read();
                    labelpage1.Text = (string)reader[0].ToString();
                    labelpage1.Visible = true;
                    reader.Read();
                    labelpage2.Text = (string)reader[0].ToString();
                    labelpage2.Visible = true;
                    reader.Read();
                    labelpage3.Text = (string)reader[0].ToString();
                    labelpage3.Visible = true;
                    reader.Read();
                    labelpage4.Text = (string)reader[0].ToString();
                    labelpage4.Visible = true;
                    reader.Read();
                    labelpage5.Text = (string)reader[0].ToString();
                    labelpage5.Visible = true;
                    reader.Read();
                    labelpage6.Text = (string)reader[0].ToString();
                    labelpage6.Visible = true;
                    reader.Read();
                    labelpage7.Text = (string)reader[0].ToString();
                    labelpage7.Visible = true;
                    reader.Read();
                    labelpage8.Text = (string)reader[0].ToString();
                    labelpage8.Visible = true;
                    reader.Close();
                    NOTEID_list.Add(getNoteId(sectionID, labelpage1.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage2.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage3.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage4.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage5.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage6.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage7.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage8.Text, sqlCon));
                }
                if (countofpage == 9)
                {
                    reader.Read();
                    labelpage1.Text = (string)reader[0].ToString();
                    labelpage1.Visible = true;
                    reader.Read();
                    labelpage2.Text = (string)reader[0].ToString();
                    labelpage2.Visible = true;
                    reader.Read();
                    labelpage3.Text = (string)reader[0].ToString();
                    labelpage3.Visible = true;
                    reader.Read();
                    labelpage4.Text = (string)reader[0].ToString();
                    labelpage4.Visible = true;
                    reader.Read();
                    labelpage5.Text = (string)reader[0].ToString();
                    labelpage5.Visible = true;
                    reader.Read();
                    labelpage6.Text = (string)reader[0].ToString();
                    labelpage6.Visible = true;
                    reader.Read();
                    labelpage7.Text = (string)reader[0].ToString();
                    labelpage7.Visible = true;
                    reader.Read();
                    labelpage8.Text = (string)reader[0].ToString();
                    labelpage8.Visible = true;
                    reader.Read();
                    labelpage9.Text = (string)reader[0].ToString();
                    labelpage9.Visible = true;
                    reader.Close();
                    NOTEID_list.Add(getNoteId(sectionID, labelpage1.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage2.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage3.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage4.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage5.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage6.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage7.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage8.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage9.Text, sqlCon));
                }
                if (countofpage == 10)
                {
                    reader.Read();
                    labelpage1.Text = (string)reader[0].ToString();
                    labelpage1.Visible = true;
                    reader.Read();
                    labelpage2.Text = (string)reader[0].ToString();
                    labelpage2.Visible = true;
                    reader.Read();
                    labelpage3.Text = (string)reader[0].ToString();
                    labelpage3.Visible = true;
                    reader.Read();
                    labelpage4.Text = (string)reader[0].ToString();
                    labelpage4.Visible = true;
                    reader.Read();
                    labelpage5.Text = (string)reader[0].ToString();
                    labelpage5.Visible = true;
                    reader.Read();

                    labelpage6.Text = (string)reader[0].ToString();
                    labelpage6.Visible = true;
                    reader.Read();
                    labelpage7.Text = (string)reader[0].ToString();
                    labelpage7.Visible = true;
                    reader.Read();
                    labelpage8.Text = (string)reader[0].ToString();
                    labelpage8.Visible = true;
                    reader.Read();
                    labelpage9.Text = (string)reader[0].ToString();
                    labelpage9.Visible = true;
                    reader.Read();
                    labelpage10.Text = (string)reader[0].ToString();
                    labelpage10.Visible = true;
                    reader.Close();
                    NOTEID_list.Add(getNoteId(sectionID, labelpage1.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage2.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage3.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage4.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage5.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage6.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage7.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage8.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage9.Text, sqlCon));
                    NOTEID_list.Add(getNoteId(sectionID, labelpage10.Text, sqlCon));
                }
                else
                {
                     reader.Close();
                }
            }
            else
            {
                // MessageBox.Show("");
            }
        }

        public int NOTE_ID;

        public void addDataToNote(int pageid,SqlConnection sqlCon)
        {

            DateTime creationDate = DateTime.Now; //some DateTime value, e.g. DateTime.Now;
            SqlCommand sqlCmd= new SqlCommand("INSERT INTO Note (creationDate,text) VALUES (@value , '')", sqlCon);
            sqlCmd.Parameters.AddWithValue("@value", creationDate);
           
          
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandType = CommandType.Text;
            int b = sqlCmd.ExecuteNonQuery();
            if (b != -1)
            {
                SqlCommand cmd2 = new SqlCommand("select max(note_id) from Note  ",sqlCon);
                NOTE_ID= (int)cmd2.ExecuteScalar();
                addNoteID_to_Page(NOTE_ID,pageid, sqlCon);
                //MessageBox.Show("data added to Notes Table Successfully:");
            }
            else
            {
                MessageBox.Show("Error in Pages class data could not be added: method-->adddatatoNOte ");
            }
        }



        private void addNoteID_to_Page(int noteId,int pageid,SqlConnection sqlCon)
        {
            SqlCommand sqlCmd = new SqlCommand("update  Page set note_id = '"+noteId+"' where page_id = '"+pageid+"'", sqlCon);
            sqlCmd.Connection = sqlCon;
            sqlCmd.CommandType = CommandType.Text;
            int b = sqlCmd.ExecuteNonQuery();
            if (b!=-1)
            {
               // MessageBox.Show("addNoteID_to_Page Success");
            }
            else
            {
                MessageBox.Show("addNoteID_to_Page error");
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            var note1 = new Notes();
            note1.NOTEid= NOTEID_list[0];
            note1.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            var note3 = new Notes();
           
            note3.NOTEid=NOTEID_list[2];
            
            note3.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            //make these components visible so that page can be added
            
            textBox1.Visible = true;
            label111.Visible = true;
            buttonAddPage.Visible = true;
            button1.Visible = true;
          
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            var note2 = new Notes();
            
            note2.NOTEid=NOTEID_list[1];
            note2.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

       
        private void addData_to_Pages(String pageTitle,int sectionID,SqlConnection sqlcon)
        {
           

            String query = "insert into [Page](pageTitle,section_id) values('" + pageTitle + "' , '"+sectionID+"')";
            SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
            sqlCmd.Connection = sqlcon;
            sqlCmd.CommandType = CommandType.Text;
            int b = sqlCmd.ExecuteNonQuery();
            if (b != -1)
            {
                SqlCommand sqlCmd2 = new SqlCommand("select max(page_id) from Page", sqlcon);
                int pageid = (int)sqlCmd2.ExecuteScalar();
                addDataToNote(pageid,sqlcon);
               

               
               // MessageBox.Show("data added to Pages Table Successfully:");
            }
            else
            {
                MessageBox.Show("Error in Pages class data could not be added method-->add_datatopages ");
            }

        }

        private int getPageCount(int sectionID, SqlConnection sqlCon)
        {
            SqlCommand sqlCommand1 = new SqlCommand("Select count(note_id) from [Page] where section_id='" + sectionID + "' ", sqlCon);
            int countOfpage = (int)sqlCommand1.ExecuteScalar();
            return countOfpage;
        }

   

        // count to keep track of the pages added.
        
        String pagename = "";
        int count = 0;
        private void buttonAddPage_Click(object sender, EventArgs e)
        {

            //this not working..........> it worked
            
            int notebookId = NOTEBOOKid;
            ///////////////////////
            int sectionID=-1;
            //to know in which section user is making pages:
            //first save the section name inside which user is 
            //then save the notebookid for that section
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DESKTOP-3MGQIPF\\UNIQUENAME;Initial Catalog=OneNote;Integrated Security=True";
            sqlCon.Open();
            if (notebookId != -1)
            {
                //MessageBox.Show(""+notebookId);
                SqlCommand sqlCommand = new SqlCommand("Select section_id from [Section] where notebookID= '"+notebookId+"' and name = '" +PagesFormHeading+"' ", sqlCon);
                sectionID = (int)sqlCommand.ExecuteScalar();
            }
            else {
                MessageBox.Show("NotebookID could not be found in Pages.cs");
                 }

            // make pages visibile- i have placed 10 pages so after each click make 1 visible
            //each page will have  a note
            //insert data into Table--> Page.




            pagename = textBox1.Text.Trim();
            if (pagename.Equals(""))
            {
                MessageBox.Show("Plz enter the Name For your Note");
            }
            else if (checkPageExistance(sectionID,pagename,sqlCon))
            {
                //add a method so that no page with same name can be created
                MessageBox.Show("Page with this name already exists in "+PagesFormHeading);
            }
            else
            {
                
                //first set visibility to false.
                textBox1.Visible = false;
                label111.Visible = false;
                buttonAddPage.Visible = false;
                button1.Visible = false;

                //depending on count make each page visible 
                
                
                if (sectionID != -1)
                {
                   
                    count = getPageCount(sectionID, sqlCon)+ 1;
                    if (count == 1)
                    {
                      

                        

                            labelpage1.Text = pagename.ToUpper();
                            labelpage1.Visible = true;
                            addData_to_Pages(pagename,sectionID,sqlCon);
                            

                            this.Close();
                       
                    }
                    if (count == 2 )
                    {
                       
                       

                        labelpage2.Text = pagename.ToUpper();
                        labelpage2.Visible = true;
                        addData_to_Pages(pagename, sectionID, sqlCon);
                        this.Close();

                    }
                    if (count == 3 )
                    {


                        labelpage3.Text = pagename.ToUpper();
                        labelpage3.Visible = true;
                        addData_to_Pages(pagename, sectionID, sqlCon);
                        this.Close();
                       
                        

                    }
                    if (count == 4 )
                    {
                        

                        labelpage4.Text = pagename.ToUpper();
                        labelpage4.Visible = true;
                        addData_to_Pages(pagename, sectionID, sqlCon);
                        this.Close();


                    }
                    if (count == 5)
                    {
                       
                        labelpage5.Text = pagename.ToUpper();
                        labelpage5.Visible = true;
                        addData_to_Pages(pagename, sectionID, sqlCon);
                        this.Close();
                        

                    }
                    if (count == 6 )
                    {
                        labelpage6.Text = pagename.ToUpper();
                        labelpage6.Visible = true;
                        addData_to_Pages(pagename, sectionID, sqlCon);
                        this.Close();


                    }
                    if (count == 7 )
                    {
                        
                        labelpage7.Text = pagename.ToUpper();
                        labelpage7.Visible = true;
                        addData_to_Pages(pagename, sectionID, sqlCon);
                        this.Close();

                    }
                    if (count == 8 )
                    {
                        labelpage8.Text = pagename.ToUpper();
                        labelpage8.Visible = true;
                        addData_to_Pages(pagename, sectionID, sqlCon);
                        this.Close();

                    }
                    if (count == 9)
                    {
                        labelpage9.Text = pagename.ToUpper();
                        labelpage9.Visible = true;
                        addData_to_Pages(pagename, sectionID, sqlCon);
                        this.Close();
                    }
                    if (count == 10 )
                    {
                        
                        labelpage10.Text = pagename.ToUpper();
                        labelpage10.Visible = true;
                        addData_to_Pages(pagename, sectionID, sqlCon);
                        this.Close();


                    }
                    if (count > 10 )
                    {
                        
                            MessageBox.Show("Only 10 Pages Are Allowed In Each Section");
                      
                    }
                   
                }
                else
                {
                    MessageBox.Show("Sorry: Section not Specified");
                }



            }

        }

        private Boolean checkPageExistance(int sectionID, string pagename, SqlConnection sqlCon)
        {
            SqlCommand sqlCommand = new SqlCommand("Select pageTitle from [Page] where section_id = '" + sectionID + "' and pageTitle='"+pagename+"'", sqlCon);
            String page_check = (string)sqlCommand.ExecuteScalar();
            if (page_check != null)
            {
                if (page_check.Equals(pagename))
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
            textBox1.Visible = false;
            label111.Visible = false;
            buttonAddPage.Visible = false;
            button1.Visible = false;
        }






        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelpage4_Click(object sender, EventArgs e)
        {
            var note4 = new Notes();
            note4.NOTEid = NOTEID_list[3];
            note4.ShowDialog();
        }

        private void labelpage5_Click(object sender, EventArgs e)
        {
            var note5 = new Notes();
            note5.NOTEid = NOTEID_list[4];
            note5.ShowDialog();
        }

        private void labelpage6_Click(object sender, EventArgs e)
        {
            var note6 = new Notes();
            note6.NOTEid = NOTEID_list[5];
            note6.ShowDialog();
        }

        private void labelpage7_Click(object sender, EventArgs e)
        {
            var note7 = new Notes();
            note7.NOTEid = NOTEID_list[6];
            note7.ShowDialog();
        }

        private void labelpage8_Click(object sender, EventArgs e)
        {
            var note8 = new Notes();
            note8.NOTEid = NOTEID_list[7];
            note8.ShowDialog();
        }

        private void labelpage9_Click(object sender, EventArgs e)
        {
            var note9 = new Notes();
            note9.NOTEid = NOTEID_list[8];
            note9.ShowDialog();
        }

        private void labelpage10_Click(object sender, EventArgs e)
        {
            var note10 = new Notes();
            note10.NOTEid = NOTEID_list[9];
            note10.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
