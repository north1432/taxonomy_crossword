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
    public partial class Form1 : Form
    {
        //
        // Global variable define
        //
        WindowsMediaPlayer music = new WindowsMediaPlayer(); // music player
        
        int baseline,boxcount,current_stage=0,score=0;
        int[] stage = new int[20];     // What stage does it random in each level
        List<TextBox> list = new List<TextBox>();   // list of textbox for answer
        List<char> ans = new List<char>();          // list of correct answer for check the answer
        List<Label> hor_question = new List<Label>(); // list of horizontal question
        List<Label> ver_question = new List<Label>(); // list of vertical question
        string[] s = File.ReadAllLines(@"data\Data.txt"); // string that read from file
        string[] OptionData = File.ReadAllLines(@"data\Option.txt"); // string that read option data
        int horizontal_question_amount; // numbers of horizontal question
        int vertical_question_amount; // numbers of vertical question
        int pause_time=0;    // check current pause time for FREEZE TIME helper
        int closed = 0;      // check are you closed this form from x button or return to menu button
        int count1 = 3, count2 = 3;     // check number if times you used helper
        int number_of_wrong = 0;  // check number of wrong
        //
        // End Global variable define
        //
        public void getDataBase()
        {
            int i;
            Random rand = new Random();
            // Fisher-Yates Shuffle
            int[] arr = new int[20];
            for (i = 0; i < 20; i++)
            {
                arr[i] = i;
            }
            for (i=20; i>0; i--)
            {
                int num = rand.Next() % i;
                stage[20-i] = arr[num];
                arr[num] = arr[i-1];
            }
            // end of algorithm
            Score.Text = score.ToString() + " pts";
            read_level(); // start read level 1
        }

        // Initializing Data, Playing Music, Bla bla bla...
        public Form1()
        {
            InitializeComponent();
            getDataBase();
            // music
            music.settings.volume = Int32.Parse(OptionData[0]);
            int data = Int32.Parse(OptionData[1]);
            if (data == 0 || data == 1) music.currentPlaylist.appendItem(music.newMedia(@"data\Raindrops_of_a_Dream.mp3"));
            if (data == 0 || data == 2) music.currentPlaylist.appendItem(music.newMedia(@"data\Above_the_Sky.mp3"));
            if (data == 0 || data == 3) music.currentPlaylist.appendItem(music.newMedia(@"data\Snow_Waltz.mp3"));
            if (data == 0 || data == 4) music.currentPlaylist.appendItem(music.newMedia(@"data\Sisters_of_Snow_Dissent.mp3"));
            if (data == 0 || data == 5) music.currentPlaylist.appendItem(music.newMedia(@"data\Four_Brave_Champion.mp3"));
            music.settings.setMode("shuffle", true);
            music.settings.setMode("loop", true);
            music.controls.next();
            music.controls.next();
            music.controls.next();
            music.controls.next();
            music.controls.next();
            music.controls.play(); // play the music !!
        }

        public void win_or_lose(int chose) // 0 = lose , 1 = win
        {
            // You lose
            int i = 0;
            timer1.Stop();
            if (chose == 0) this.Text = "Game Over";
            else this.Text = "You Win !!";
            for (i = 0; i < boxcount; i++)
            {
                list[i].Dispose();
                this.panel5.Controls.Remove(list[i]);
            }
            for (i = 0; i < horizontal_question_amount; i++)
            {
                hor_question[i].Dispose();
                this.panel3.Controls.Remove(hor_question[i]);
            }
            for (i = 0; i < vertical_question_amount; i++)
            {
                ver_question[i].Dispose();
                this.panel4.Controls.Remove(ver_question[i]);
            }
            list.Clear();
            hor_question.Clear();
            ver_question.Clear();
            // remove almost everything from this form
            this.Controls.Remove(panel1);
            this.Controls.Remove(panel2);
            this.Controls.Remove(progressBar1);

            // create panel
            Panel end = new Panel();
            end.Size = new Size(600, 210);
            end.Location = new Point(150, 150);
            end.BackColor = Color.WhiteSmoke;
            this.Controls.Add(end);

            // create game over text
            Label endtext = new Label();
            endtext.AutoSize = true;
            if (chose == 0) endtext.Text = "GAME OVER!";
            else endtext.Text = "You Win !!";
            endtext.Font = new Font("Arial", 65, FontStyle.Bold);
            if (chose == 0) endtext.Location = new Point(10, 20);
            else endtext.Location = new Point(80, 20);
            end.Controls.Add(endtext);

            // create your score text
            Label yourscore = new Label();
            yourscore.AutoSize = true;
            yourscore.Text = "Your score: ";
            yourscore.Font = new Font("Arial", 20);
            yourscore.Location = new Point(170, 130);
            end.Controls.Add(yourscore);

            // display your score
            Score.Font = new Font("Arial", 20);
            Score.Location = new Point(325, 130);
            end.Controls.Add(Score);
        }

        //change level
        public void read_level()
        {
            int i = 0;
            baseline = (100 * stage[current_stage]) + 1;
            boxcount = Int32.Parse(s[baseline - 1]);
            for (i = baseline; i < baseline + boxcount; i++)
            {
                int x, y;
                string[] read = s[i].Split(' ');
                list.Add(new TextBox());
                x = Int32.Parse(read[0]);
                y = Int32.Parse(read[1]);
                ans.Add(char.Parse(read[2]));
                list[i - baseline].Location = new Point((x - 1) * 21 + 15, (y - 1) * 25 + 8);
                list[i - baseline].Size = new Size(15, 50);
                list[i - baseline].MaxLength = 1;
                this.panel5.Controls.Add(list[i - baseline]);
            }
            horizontal_question_amount = Int32.Parse(s[i]);
            for (i = baseline + boxcount + 1; i < baseline + boxcount + horizontal_question_amount + 1; i++)
            {
                hor_question.Add(new Label());
                hor_question[i - baseline - boxcount - 1].AutoSize = false;
                hor_question[i - baseline - boxcount - 1].Font = new Font("Angsana New", 14);
                hor_question[i - baseline - boxcount - 1].Location = new Point(10, (i - baseline - boxcount - 1) * 20 + 25);
                hor_question[i - baseline - boxcount - 1].Size = new Size(355, 21);
                hor_question[i - baseline - boxcount - 1].Text = s[i];
                this.panel3.Controls.Add(hor_question[i - baseline - boxcount - 1]);
            }
            vertical_question_amount = Int32.Parse(s[i]);
            for (i = baseline + boxcount + horizontal_question_amount + 1; i < baseline + boxcount + horizontal_question_amount + vertical_question_amount + 1; i++)
            {
                ver_question.Add(new Label());
                ver_question[i - baseline - boxcount - horizontal_question_amount - 1].AutoSize = false;
                ver_question[i - baseline - boxcount - horizontal_question_amount - 1].Font = new Font("Angsana New", 14);
                ver_question[i - baseline - boxcount - horizontal_question_amount - 1].Location = new Point(10, (i - baseline - boxcount - horizontal_question_amount - 1) * 20 + 25);
                ver_question[i - baseline - boxcount - horizontal_question_amount - 1].Size = new Size(355, 21);
                ver_question[i - baseline - boxcount - horizontal_question_amount - 1].Text = s[i + 1];
                this.panel4.Controls.Add(ver_question[i - baseline - boxcount - horizontal_question_amount - 1]);
            }
            this.Text = "Taxonommy Crossword - Level " + (current_stage + 1);
            // time count
            timer1.Start();
            TimeFreeze_Button.Enabled = true;
            if (count2 == 0) TimeFreeze_Button.Enabled = false;
            TimeFreeze_Button.Text = "Time Freeze x " + count2.ToString();
        }

        // Clear level
        public void clear_level(int chose)
        {
            int i = 0;
            for (i = 0; i < boxcount; i++)
            {
                list[i].Dispose();
                this.panel5.Controls.Remove(list[i]);
            }
            for (i = 0; i < horizontal_question_amount; i++)
            {
                hor_question[i].Dispose();
                this.panel3.Controls.Remove(hor_question[i]);
            }
            for (i = 0; i < vertical_question_amount; i++)
            {
                ver_question[i].Dispose();
                this.panel4.Controls.Remove(ver_question[i]);
            }
            Time_Freeze.Stop();
            list.Clear();
            ans.Clear();
            hor_question.Clear();
            ver_question.Clear();
            current_stage++;
            if (chose == 1) score += (current_stage * 25) + (progressBar1.Value / 27) + 1;
            Score.Text = score.ToString() + " pts";
            progressBar1.Maximum = 96 * progressBar1.Maximum / 100;
            progressBar1.Value = progressBar1.Maximum;
        }

        // Closing program
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closed == 0) // check if you closed from x button or return to menu button
            Application.Exit();
        }

        // Clicking Submit Button
        private void button4_Click(object sender, EventArgs e)     
        {
            int i;
            for (i=0;i<boxcount;i++)
            {
                if (list[i].Text != ans[i].ToString()) // Wrong Answer !!!!!!!!!
                {
                    number_of_wrong++;
                    break;
                }
            }
            if (number_of_wrong > 0)
            {
                if (progressBar1.Value > 301) progressBar1.Value -= 300;
                else progressBar1.Value = 0;
                if (score > 50) score -= 50;
                else score = 0;
                Score.Text = score.ToString() + " pts";
                number_of_wrong = 0;
                goto end_of_answer_function;
            }
            //
            // Correct Answer
            //
            clear_level(1);
            timer1.Stop();
            if (current_stage < 20)
            {
                // read next level
                read_level();
            }  
            else
            {
                win_or_lose(1);
                // You win !!
            }
        end_of_answer_function: ;
        }

        // Ticking event occurs every 0.01 seconds
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value > 0) progressBar1.Value--;
            if (progressBar1.Value == 0) // Life goes out
            {
                // YOU LOSE !!
                win_or_lose(0);
            }
        }
        
        // Time Extend
        private void button1_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value <= progressBar1.Maximum * 92 / 100) progressBar1.Value += 8 * progressBar1.Maximum / 100;
            else progressBar1.Value = progressBar1.Maximum;
            count1--;
            if (count1 == 0) ExtendedTime_Button.Enabled = false;
            ExtendedTime_Button.Text = "Extended time x " + count1.ToString();
        }

        // Freeze Time
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Time_Freeze.Interval = 1000;
            Time_Freeze.Start();
            TimeFreeze_Button.Enabled = false;
            count2--;
            
        }

        // Just another freeze time event helper for counting time until 20 second
        private void Time_Freeze_Tick(object sender, EventArgs e)
        {
            pause_time++;
            if (pause_time == 20)
            {
                timer1.Start();
                Time_Freeze.Stop();
                TimeFreeze_Button.Enabled = true;
                if (count2 == 0) TimeFreeze_Button.Enabled = false;
                TimeFreeze_Button.Text = "Time Freeze x " + count2.ToString();
                pause_time = 0;
            }
        }

        // Skip Question
        private void button3_Click(object sender, EventArgs e)
        {
            SkipQuestion_Button.Enabled = false;
            timer1.Stop();
            clear_level(0);
            if (current_stage < 16)
            {
                read_level();
            }
            else
            {
                // You Absolutely Win !!!
                win_or_lose(1);
            }
            TimeFreeze_Button.Enabled = true;
            if (count2 == 0) TimeFreeze_Button.Enabled = false;
            TimeFreeze_Button.Text = "Time Freeze x " + count2.ToString();
            timer1.Start();
        }

        // clicking "return to menu" button
        private void button5_Click(object sender, EventArgs e)
        {
            closed = 1;
            music.controls.stop();
            this.Close();
            new Form2().Show();
        }
    }
}


