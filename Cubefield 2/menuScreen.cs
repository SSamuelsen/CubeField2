using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Cubefield
{
    public partial class menuScreen : Form
    {

        string highScore;

        public bool specialImage { get; set; }



        SaveScores makeFile = new SaveScores();             //create new object of SaveScores class

        public menuScreen()
        {


            makeFile.createSaveFile();                  //create the save file if needed



            InitializeComponent();

            if (File.Exists("scores.txt"))              //if file created in the program class exsits
            {
                highScore = File.ReadAllText("scores.txt"); //set high score to the contents of the file

                if(Convert.ToInt32(highScore) >= 20)
                {
                    specialImage = true;                //makes specialImage true if you get score 20
                }
                

            }
            

            
            Convert.ToInt32(highScore);


            if (highScore != null)                  //makes sure that highscore is not empty
            {

                if (highScoreCount.Text != null)        //if the high score label is not empty
                {

                    if (Convert.ToInt32(highScore) > Convert.ToInt32(highScoreCount.Text))
                    {
                        highScoreCount.Text = highScore;        //sets the high score label to the number in the file
                    }

                }

            }
            else
            {
                highScore = Convert.ToString(0);
                if (Convert.ToInt32(highScore) > Convert.ToInt32(highScoreCount.Text))
                {
                    highScoreCount.Text = highScore;
                }
            }




        }

        private void button1_Click(object sender, EventArgs e)  //play game button
        {

            this.Hide();
            User gameForm = new User();
            gameForm.Show();                                //displays the game form when pressed



        }

        private void button2_Click(object sender, EventArgs e)      //exit button
        {

            Application.Exit();                                 //closes entire application when exit button pressed



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)      //reset button pressed
        {

            File.WriteAllText("scores.txt", "0");        //reset the score back to 0
            highScoreCount.Text = "0";
        }
    }
}
