﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FakeHackApplication
{
    public partial class HackProgram : Form
    {
        private bool updateReleased;
        private bool textFieldUsername;
        private bool textFieldPassword;

        public HackProgram()
        {
            InitializeComponent();
        }

        private void btnHack_Click(object sender, EventArgs e)
        { //It's a mess but it works
            if (textFieldUsername == false) //This checks if the thing is empty by checking if it changes default (What)
            { //You can still make it empty if you fill stuff then empty it
                if (textFieldPassword == false)
                {
                    MessageBox.Show("You need to set a username and password.","Set Username and Password",MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("You need to set a username.", "Set Username", MessageBoxButtons.OK);
                }
            }
            else if (textFieldPassword == false)
            {
                if (textFieldUsername == true)
                {
                    MessageBox.Show("You need to set a password.", "Set Password", MessageBoxButtons.OK);
                }
                else
                {
                }
            }
            else
            {
                //This starts the progress bar and disable the buttons
                progressBarTimer.Start();
                btnCheckVersion.Enabled = false;
                btnHack.Enabled = false;
            }
        }

        private void progressBarTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Increment(3);
            if (progressBar.Value == 990)
            {
                updateReleased = true;
                progressBarTimer.Stop();
                NewVersionMessage(false);
                btnCheckVersion.Enabled = true;
            }
        }
        public void NewVersionMessage(bool exit)
        {
            if (MessageBox.Show("A new version has been released. Please update the program to continue.", "New Update", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ"); //Don't tell anyone
            }
            else
            {
                if (exit == true)
                {
                    System.Windows.Forms.Application.Exit();
                }
            }
        }

        private void btnCheckVersion_Click(object sender, EventArgs e)
        {
            if (updateReleased == false)
            {
                MessageBox.Show("You are up to date.", "Version Check", MessageBoxButtons.OK);
            }
            else
            {
                NewVersionMessage(false);
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            textFieldUsername = true;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            textFieldPassword = true;
        }
    }
}
