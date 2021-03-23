using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuntingGame1
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }
        public string name { get; set; }
        private void Game_Load(object sender, EventArgs e)
        {
            picBox.Visible = false;

            this.radioEasy.TabStop = false;
            this.radioMedium.TabStop = false;
            this.radioHard.TabStop = false;
            lblGameOver.Visible = false;
            lblOverScore.Visible = false;
            lblName.Text = name;
            #region if name is so loooooong :)
            while (lblName.Width < System.Windows.Forms.TextRenderer.MeasureText(lblName.Text,
     new Font(lblName.Font.FontFamily, lblName.Font.Size, lblName.Font.Style)).Width)
            {
                lblName.Font = new Font(lblName.Font.FontFamily, lblName.Font.Size - 0.5f, lblName.Font.Style);
            }
            #endregion


        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            double countDown = Convert.ToDouble(lblCountDown.Text);
            if (countDown == 0)
            {
                picBox.Visible = false;
                timerTime.Stop();
                lblGameOver.Visible = true;
                lblOverScore.Text = lblScoreCount.Text;
                lblOverScore.Visible = true;
                RestartGame();
            }
            else
            {
                countDown -= 0.1;
            }
            lblCountDown.Text = countDown.ToString();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            
            lblGameOver.Visible = false;
            lblOverScore.Visible = false;

            if (radioEasy.Checked || radioMedium.Checked || radioHard.Checked)
            {

                picBox.Visible = true;
                timerTime.Start();
                radioEasy.Enabled = false;
                radioMedium.Enabled = false;
                radioHard.Enabled = false;
                btnStart.Enabled = false;
            }
            else { MessageBox.Show("Please choose difficulty!", "Error | WoundedWarriors", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            lblScoreCount.Text = "0";
            RestartGame();
        }

        private void TimerScore_Tick(object sender, EventArgs e)
        {
            double countScore = Convert.ToDouble(lblScoreCount.Text);
            countScore++;
            lblScoreCount.Text = countScore.ToString();
            TimerScore.Stop();
           
        }
        private void DifficultyControl()
        {
            if (radioEasy.Checked==true)
            {
                lblCountDown.Text = "12";
            }
            else if (radioMedium.Checked==true)
            {
                lblCountDown.Text = "9,5";
            }
            else if (radioHard.Checked==true)
            {
                lblCountDown.Text = "7";
            }
            
        }
        private void picBox_Click(object sender, EventArgs e)
        {
            
            Random newLocation = new Random();
            TimerScore.Start();
            int x;
            int y;
            Bitmap emoji1= Properties.Resources.emojiLevel1;
            Bitmap emoji2 = Properties.Resources.emojiLevel2;
            Bitmap emoji3 = Properties.Resources.emojiLevel3;
            Bitmap emoji4 = Properties.Resources.emojiLevel4;
            Bitmap emoji5 = Properties.Resources.emojiLevel5;


            if (Convert.ToDouble(lblScoreCount.Text) <= 10)
            {
               

                x = newLocation.Next(117, 451);
                y = newLocation.Next(0, 354);
                picBox.Location = new Point(x, y);
                if (Convert.ToDouble(lblScoreCount.Text) == 10)
                {
                    picBox.Height -= 15;
                    picBox.Width -= 15;
                    this.Height += 40;
                    this.Width += 40;
                    DifficultyControl();
                    picBox.Image = emoji2;

                }


            }
            else if (Convert.ToDouble(lblScoreCount.Text) > 10 && Convert.ToDouble(lblScoreCount.Text) <= 20)
            {

                x = newLocation.Next(117, 531);
                y = newLocation.Next(0, 436);
                picBox.Location = new Point(x, y);
                if (Convert.ToDouble(lblScoreCount.Text) == 20)
                {

                    picBox.Height -= 15;
                    picBox.Width -= 15;
                    this.Height += 40;
                    this.Width += 40;
                    DifficultyControl();
                    picBox.Image = emoji3;

                }

            }
            else if (Convert.ToDouble(lblScoreCount.Text) > 20 && Convert.ToDouble(lblScoreCount.Text) <= 30)
            {

                x = newLocation.Next(117, 571);
                y = newLocation.Next(0, 476);
                picBox.Location = new Point(x, y);
                if (Convert.ToDouble(lblScoreCount.Text) == 30)
                {
                    picBox.Height -= 13;
                    picBox.Width -= 13;
                    this.Height += 40;
                    this.Width += 40;
                    DifficultyControl();
                    picBox.Image = emoji4;

                }

            }
            else if (Convert.ToDouble(lblScoreCount.Text) > 30 && Convert.ToDouble(lblScoreCount.Text) <= 40)
            {

                x = newLocation.Next(117, 661);
                y = newLocation.Next(0, 516);
                picBox.Location = new Point(x, y);
                if (Convert.ToDouble(lblScoreCount.Text) == 40)
                {
                    picBox.Height -= 12;
                    picBox.Width -= 12;
                    this.Height += 40;
                    this.Width += 40;
                    DifficultyControl();
                    picBox.Image = emoji5;

                }

            }
            else if (Convert.ToDouble(lblScoreCount.Text) > 40 && Convert.ToDouble(lblScoreCount.Text) <= 50)
            {

                x = newLocation.Next(117, 701);
                y = newLocation.Next(0, 556);
                picBox.Location = new Point(x, y);
                if (Convert.ToDouble(lblScoreCount.Text) == 50)
                {
                    picBox.Height -= 10;
                    picBox.Width -= 10;
                    this.Height += 40;
                    this.Width += 40;
                    DifficultyControl();
                    

                }
            }
            else if (Convert.ToDouble(lblScoreCount.Text) > 50)
            {
                x = newLocation.Next(117, 701);
                y = newLocation.Next(0, 556);
                picBox.Location = new Point(x, y);
            }
            
        }
        private void RestartGame()
        {
            if (lblGameOver.Visible == true)
            {
                radioEasy.Enabled = true;
                radioMedium.Enabled = true;
                radioHard.Enabled = true;
                btnStart.Enabled = true;
                radioEasy.Checked = false;
                radioMedium.Checked = false;
                radioHard.Checked = false;

            }
            lblScoreCount.Text = "0";
            this.Size = new Size(558, 488);
            Size picBoxDefaultSize = new Size(94, 89);
            picBox.Size = picBoxDefaultSize;
            Bitmap defaultEmoji = Properties.Resources.emojiLevel1;
            picBox.Image = defaultEmoji;
        }


        private void radioEasy_CheckedChanged(object sender, EventArgs e)
        {
            lblCountDown.Text = "12";
        }

        private void radioMedium_CheckedChanged(object sender, EventArgs e)
        {
            lblCountDown.Text = "9,5";
        }

        private void radioHard_CheckedChanged(object sender, EventArgs e)
        {
            lblCountDown.Text = "7";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit from Hunting Game?", "Exit | Wounded Warriors", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Environment.Exit(1);

                Application.Exit();
            }
           
           
        }
    }
}
