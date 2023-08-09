using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy
{
    public partial class Form : System.Windows.Forms.Form
    {
        int pipeSpeed = 10;
        int gravity = 8;
        int score = 0;
        bool gameOver = false;
        Random rnd = new Random();
       
        public Form()
        {
            InitializeComponent();
            ground.Controls.Add(scoreText);
            scoreText.BackColor = Color.Transparent;
            scoreText.Parent = ground;
            scoreText.Left = 20;
            scoreText.Top = 25;
            resetImage.Enabled = false;
            resetImage.Visible = false;

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if(pipeBottom.Left < -50)
            {
                pipeBottom.Left = rnd.Next(1200, 1400);
                score++;
            }

            if(pipeTop.Left < -80)
            {
                pipeTop.Left = rnd.Next(1200, 1600);
                score++;
            }

            if(flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds)||
                    (flappyBird.Top < -25))
            {
                endGame();
            }
            if(score > 5)
            {
                  pipeSpeed = 15;
            }
            if(score > 25)
            {
                pipeSpeed = 30;
            }

           
           
            
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }

            if(e.KeyCode == Keys.R && gameOver == true)
            {
                resetGame();
            }

        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!!! Press R";
            gameOver = true;
            resetImage.Enabled = true;
            resetImage.Visible = true;
        }

        private void resetGame()
        {
            pipeSpeed = 10;
            gravity = 8;
            score = 0;
            gameOver = false;
            resetImage.Enabled = false;
            resetImage.Visible = false;
            scoreText.Text = "Score: " + score;
            flappyBird.Top = 100;
            pipeBottom.Left = 800;
            pipeTop.Left = 1000;
            gameTimer.Start();
            
        }

        private void RestartClickEvent(object sender, EventArgs e)
        {
            resetGame();
        }
    }
}
