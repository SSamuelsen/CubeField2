using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;                //required to be able to save and read a file

namespace Cubefield
{
    public partial class Form1 : Form
    {

        public int Level { get; set; }


        int score = 0;              //used for level advancement
        public int speed = 10;             //used to adjust the speed of the game
        public int playerSpeed = 6;
        bool moveRight;
        bool moveLeft;
        bool hitBarrier = false;


        private static Random randomNumber = new Random();      //create new random object
        private DateTime secondTimer = DateTime.Now;

        menuScreen menuObject= new menuScreen();        //create object of menuScreen class

        Levels levelNum = new Levels();             //create object of Levels class

        //https://www.mooict.com/c-tutorial-create-a-full-space-invaders-game-using-visual-studio/  //used this for reference on how to make objects move down screen and for keypresses

        public Form1()
        {
            
            InitializeComponent();

            LevelCount.Hide();                  //hides the level count 

            //inverts the colors if over a certain score
            if(menuObject.specialImage == true) {           //checks to see if property is true

                this.BackColor = Color.Black;
                playerCube.BackColor = Color.White;
                scoreCount.BackColor = Color.White;
                


                foreach (Control x in this.Controls)         //loops through each barrier
                {
                    if (x is PictureBox && x.Tag == "barriers")
                    {
                        x.BackColor = Color.White;
                    }
                }
                
            }
            else
            {
              
                //resets the colors back to normal
                this.BackColor = Color.White;
                playerCube.BackColor = Color.Black;
                scoreCount.BackColor = Color.White;

                foreach (Control x in this.Controls)         //loops through each barrier
                {
                    if (x is PictureBox && x.Tag == "barriers")
                    {
                        x.BackColor = Color.Gray;
                    }
                }
            }

            countdown();



        }

        
        



        private void countdown()
        {

            StartingTimer.Enabled = true;       //enables the starting timer


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void updateScore()
        {
            int updateInterval = 1000;              //updates the score every second
            if (DateTime.Now.Subtract(secondTimer) > TimeSpan.FromMilliseconds(updateInterval))
            {
                scoreCount.Text += 1;
            }
        }




        private void gameTime_Tick(object sender, EventArgs e)
        {







            if(score < 15)
            {
                Level = 1;
            }

            if(score == 15)                     //increases level when score is over certain number
            {
                speed = 15;
                LevelCountLabel.Text = "2";
                //Level = 2;
                levelNum.Level = 2;
                LevelCount.Text = "Level 2! Speed up!";

                levelNum.displayLevelCount();               //call the function to disply the next level title

                if(levelNum.displayLevelTitle == true)
                {
                    LevelCount.Show();
                }

                changeBarrierColor();              //calls the function to change all barrier colors for each level

                

            }

            else if(score == 16)
            {
                levelNum.hideLevelCount();              //rehide the level count label

                if(levelNum.displayLevelTitle == false)
                {
                    LevelCount.Hide();
                }
                    
            }

            else if (score == 25)
            {
                speed = 20;
                LevelCountLabel.Text = "3";
                //Level = 3;
                levelNum.Level = 3;
                LevelCount.Text = "Level 3! Speed up!";

                levelNum.displayLevelCount();               //call the function to disply the next level title

                if (levelNum.displayLevelTitle == true)
                {
                    LevelCount.Show();
                }
            }

            else if (score == 26)
            {
                levelNum.hideLevelCount();              //rehide the level count label

                if (levelNum.displayLevelTitle == false)
                {
                    LevelCount.Hide();
                }

            }

            else if (score == 35)
            {
                speed = 25;
                LevelCountLabel.Text = "4";
                levelNum.Level = 4;
                LevelCount.Text = "Level 4! Keep it up!";

                levelNum.displayLevelCount();               //call the function to disply the next level title

                if (levelNum.displayLevelTitle == true)
                {
                    LevelCount.Show();
                }
            }

            else if (score == 36)
            {
                levelNum.hideLevelCount();              //rehide the level count label

                if (levelNum.displayLevelTitle == false)
                {
                    LevelCount.Hide();
                }

            }

            else if (score == 45)
            {
                speed = 30;
                LevelCountLabel.Text = "5";
                levelNum.Level = 5;
                LevelCount.Text = "Level 5! Good Luck!";

                levelNum.displayLevelCount();               //call the function to disply the next level title

                if (levelNum.displayLevelTitle == true)
                {
                    LevelCount.Show();
                }
            }

            else if (score == 46)
            {
                levelNum.hideLevelCount();              //rehide the level count label

                if (levelNum.displayLevelTitle == false)
                {
                    LevelCount.Hide();
                }

            }

            else if (score == 55)
            {
                speed = 40;
                LevelCountLabel.Text = "6";
                levelNum.Level = 6;
                LevelCount.Text = "Level 6! Almost to the end!";

                levelNum.displayLevelCount();               //call the function to disply the next level title

                if (levelNum.displayLevelTitle == true)
                {
                    LevelCount.Show();
                }
            }
            else if (score == 56)
            {
                levelNum.hideLevelCount();              //rehide the level count label

                if (levelNum.displayLevelTitle == false)
                {
                    LevelCount.Hide();
                }

            }

            else if (score == 65)
            {
                speed = 60;
                LevelCountLabel.Text = "Final Level!";
                levelNum.Level = 7;
                LevelCount.Text = "Final Level! Impossible...";

                levelNum.displayLevelCount();               //call the function to disply the next level title

                if (levelNum.displayLevelTitle == true)
                {
                    LevelCount.Show();
                }
            }

            else if (score == 66)
            {
                levelNum.hideLevelCount();              //rehide the level count label

                if (levelNum.displayLevelTitle == false)
                {
                    LevelCount.Hide();
                }

            }



            if (hitBarrier == false)            //checks to see if player hits barrier first
            {

                if (moveLeft)
                {
                    playerCube.Left -= playerSpeed;             //moves left by number that is set in player speed

                }
                else if (moveRight)
                {
                    playerCube.Left += playerSpeed;         //moves right by number that is set in player speed
                }

                foreach (Control x in this.Controls)         //loops through each barrier
                {
                    if (x is PictureBox && x.Tag == "barriers")
                    {
                        if (x.Bounds.IntersectsWith(playerCube.Bounds))
                        {
                            hitBarrier = true;              //change hitBarrier variable
                            this.Controls.Remove(playerCube);       //removes the player from the screen
                            gameOver();             //call the gameOver function
                                                    //System.Threading.Thread.Sleep(1000);
                            return;
                        }

                        x.Top += speed;

                        if (x.Top > 500)                        //resets the barriers back to the top
                        {
                            x.Top = 0;
                            x.Left = randomNumber.Next(0, 1400);         //randomly position the blocks
                        }
                    }
                }
            }
        }



        public void changeBarrierColor()
        {
            foreach (Control x in this.Controls)         //loops through each barrier
            {
                if (x is PictureBox && x.Tag == "barriers")
                {
                    x.BackColor = Color.FromName(levelNum.barrierColor);                    //removes all barriers
                    //barrier.BackColor = Color.FromName(levelNum.barrierColor);
                }
            }
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)       //called when key is pressed down
        {

            if (e.KeyCode == Keys.Left)         //left arrow key pressed 
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)            //rigth arrow key pressed
            {
                moveRight = true;
            }


        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;           // stop moving when key is not pressed
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }


        }




        private void gameOver()                     //function to end game
        {

            foreach (Control x in this.Controls)         //loops through each barrier
            {
                if (x is PictureBox && x.Tag == "barriers")
                {
                    this.Controls.Remove(x);                    //removes all barriers
                }
            }


            if (hitBarrier == true)             //checks first to see if barrier is hit
            {


                string highScore = File.ReadAllText("scores.txt");           //make string equal to number in file
                Convert.ToInt32(highScore);

                if (Convert.ToInt32(highScore) < Convert.ToInt32(scoreCount.Text))  //check to see if number in file is less than the most recent score 
                {
                    File.WriteAllText("scores.txt", scoreCount.Text);        //write to high score file
                }




                


            }


            this.Controls.Remove(player);           //removes the player picture box
            this.Hide();                //hides the game form
            

            menuScreen menu = new menuScreen();     //create new object of the menyScreen form

       
            menu.Show();            //show the menu screen form


        }

        private void scoreTime_Tick(object sender, EventArgs e) //called every second to add 1 to score
        {
            if (hitBarrier == false)
            {

                //https://stackoverflow.com/questions/23310437/how-to-make-a-label-increment-by-1-every-second

                var num = int.Parse(scoreCount.Text);
                scoreCount.Text = (num + 1).ToString();
                score += 1;     //increments by one every second
            }

            




        }

        private void StartingTimer_Tick(object sender, EventArgs e)
        {


            var num = int.Parse(countdownLabel.Text);
            countdownLabel.Text = (num - 1).ToString();

            if(countdownLabel.Text == "0")
            {
                this.Enabled = false;
                countdownLabel.Hide();      //hides the label when its done
                gameTime.Enabled = true;            //start the barriers moving 
                scoreTime.Enabled = true;           //start the score clock
            }

        }

        

        private void playerCube_Click(object sender, EventArgs e)
        {

        }
    }
}
