using System;
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

        public HackProgram()
        {
            InitializeComponent();
        }

        private void btnHack_Click(object sender, EventArgs e)
        {
            progressBarTimer.Start();
            btnCheckVersion.Enabled = false;
            btnHack.Enabled = false;
        }

        private void progressBarTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Increment(1);
            if (progressBar.Value == 450)
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
                Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
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
    }
}
