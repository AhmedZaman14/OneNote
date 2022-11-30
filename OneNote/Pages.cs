using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace OneNote
{
    public partial class Pages : Form
    {
        public Pages()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Notes note = new Notes();
            this.Hide();
            note.ShowDialog();
            this.Close();
        }
        public String PagesFormHeading;
        private void Education_Load(object sender, EventArgs e)
        {
            label1.Text = PagesFormHeading;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Notes note = new Notes();
            this.Hide();
            note.ShowDialog();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            
           

            //make these components visible so that page can be added
            // now head to the buttonAddpage event/method.
            textBox1.Visible = true;
            label111.Visible = true;
            buttonAddPage.Visible = true;
            button1.Visible = true;
          
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        // count to keep track of the pages added.
        int count =0;
        String pagename = "";
        private void buttonAddPage_Click(object sender, EventArgs e)
        {

            // make pages visibile- i have placed 10 pages so after each click make 1 visible
            //each page will have  a note

            pagename = textBox1.Text.Trim();
            if (pagename.Equals(""))
            {
                MessageBox.Show("Plz enter the Name For your Note");
            }
            else
            {
                count++;
                //first set visibility to false.
                textBox1.Visible = false;
                label111.Visible = false;
                buttonAddPage.Visible = false;
                button1.Visible = false;

                //depending on count make each page visible 
                //and also add them to database on table Pages(sectios_id) and PageTitle(titlez)

                 if (count == 1)
                 {
                     pagename = textBox1.Text.TrimEnd();
                     labelpage1.Visible = true;
                     labelpage1.Text = pagename.ToUpper();

                 }
                 if (count == 2)
                 {
                     pagename = textBox1.Text.TrimEnd();
                     labelpage2.Visible = true;
                     labelpage2.Text = pagename.ToUpper(); 
                 }
                 if(count == 3)
                 {
                    

                    pagename = textBox1.Text.TrimEnd();
                    labelpage3.Visible = true;
                    labelpage3.Text = pagename.ToUpper();
                }
                if (count==4)
                {
                    pagename = textBox1.Text.TrimEnd();
                    labelpage4.Visible = true;
                    labelpage4.Text = pagename.ToUpper();
                }
                if (count == 5)
                {
                    pagename = textBox1.Text.TrimEnd();
                    labelpage5.Visible = true;
                    labelpage5.Text = pagename.ToUpper();
                }
                if (count == 6)
                {
                    pagename = textBox1.Text.TrimEnd();
                    labelpage6.Visible = true;
                    labelpage6.Text = pagename.ToUpper();
                }
                if (count == 7)
                {
                    pagename = textBox1.Text.TrimEnd();
                    labelpage7.Visible = true;
                    labelpage7.Text = pagename.ToUpper();
                }
                if (count == 8)
                {
                    pagename = textBox1.Text.TrimEnd();
                    labelpage8.Visible = true;
                    labelpage8.Text = pagename.ToUpper();
                }
                if (count == 9)
                {
                    pagename = textBox1.Text.TrimEnd();
                    labelpage9.Visible = true;
                    labelpage9.Text = pagename.ToUpper();
                }
                if (count == 10)
                {
                    pagename = textBox1.Text.TrimEnd();
                    labelpage10.Visible = true;
                    labelpage10.Text = pagename.ToUpper();
                }
                if (count>10)
                {
                    MessageBox.Show("Only 10 Pages Are Allowed In Each Section");
                }



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
    }
}
