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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="Please enter your name" || String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("You cannot play the game without entering your name.\nPlease enter your name!", "Error-WoundedWarriors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Game frm = new Game();
                this.Hide();
                frm.name = textBox1.Text;
                frm.Show();

                
            }
           

        }
      
        private void btnExit_Click(object sender, EventArgs e)
        {
          
            this.Close();
            Environment.Exit(0);
            Application.Exit();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void lblTeamInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
