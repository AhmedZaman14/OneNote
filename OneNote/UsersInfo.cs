﻿using System;
using System.Windows.Forms;

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
            Administrator administrator = new Administrator();
            this.Hide();
            administrator.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //by clicking on it admin will be able to delete the user 

        }
    }
}
