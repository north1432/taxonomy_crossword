using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WMPLib;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        WindowsMediaPlayer sometest = new WindowsMediaPlayer();
        int closed = 0;
        public Form2()
        {
            InitializeComponent();
            sometest.settings.volume = 100;
            sometest.URL = @"data\Lost_and_Forgotten.mp3";
            sometest.controls.play();
            sometest.settings.setMode("shuffle", true);
            sometest.settings.setMode("loop", true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            closed = 1;
            this.Close();
            sometest.controls.stop();
            new Form1().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closed == 0)
                Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }
    }
}
