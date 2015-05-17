using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        string[] s = File.ReadAllLines(@"data\Option.txt");
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            VolumeEdit.Value = Int32.Parse(s[0]);
            comboBox1.SelectedIndex = Int32.Parse(s[1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(@"data\Option.txt",s);
            this.Close();
        }

        private void VolumeEdit_Scroll(object sender, EventArgs e)
        {
            s[0] = VolumeEdit.Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            s[1] = comboBox1.SelectedIndex.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
