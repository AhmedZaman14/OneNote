﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Pages pages = new Pages();
            this.Hide();
            pages.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            NoteLayout layout = new NoteLayout();
            this.Hide();
            layout.ShowDialog();
            this.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            checkedListBox1.Visible = true;

        }

        private void Notes_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure", "Delete Note",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Pages pages = new Pages();
                this.Hide();
                pages.ShowDialog();
                this.Close();
                //delete the note/page

            }
            else if (MessageBox.Show("Are you sure", "Delete Note", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                //do not delete
                checkedListBox1.Visible = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

