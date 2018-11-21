using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

/// <summary>
/// A rock, paper, scissors game that utilizes basic methods
/// for repetitive tasks.
/// </summary>

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, cpuChoice;
        int wins = 0;
        int losses = 0;
        int ties = 0;
        int choicePause = 1000;
        int outcomePause = 3000;

        Random randGen = new Random();

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        Image rockImage = Properties.Resources.rock168x280;
        Image paperImage = Properties.Resources.paper168x280;
        Image scissorImage = Properties.Resources.scissors168x280;
        Image winImage = Properties.Resources.winTrans;
        Image loseImage = Properties.Resources.loseTrans;
        Image tieImage = Properties.Resources.tieTrans;

        Point playerLocation = new Point(168, 70);
        Point cpuLocation = new Point(360, 70);
        Point outcomeLocation = new Point(225, 5);


        Graphics g;

        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void rockButton_Click(object sender, EventArgs e)
        {
            /// TODO Set the playerchoice value, draw the appropriate image,
            /// play a sound, wait for a second; repeat for the computer turn 

            playerChoice = "Rock";
            g.DrawImage(rockImage, playerLocation);
            jabPlayer.Play();

            computerChoice();

            if (cpuChoice == "rock")
            {
                ties++;
                tiesLabel.Text = "Ties: " + ties;
                g.DrawImage(tieImage, outcomeLocation);
            }
            else if (cpuChoice == "paper")
            {
                losses++;
                lossesLabel.Text = "Losses: " + losses;
                g.DrawImage(loseImage, outcomeLocation);
            }
            else
            {
                wins++;
                winsLabel.Text = "Wins: " + wins;
                g.DrawImage(winImage, outcomeLocation);
            }

            gongPlay();
        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            g.DrawImage(paperImage, playerLocation);
            jabPlayer.Play();

            computerChoice();

            if (cpuChoice == "paper")
            {
                ties++;
                tiesLabel.Text = "Ties: " + ties;
                g.DrawImage(tieImage, outcomeLocation);
            }
            else if (cpuChoice == "scissor")
            {
                losses++;
                lossesLabel.Text = "Losses: " + losses;
                g.DrawImage(loseImage, outcomeLocation);
            }
            else
            {
                wins++;
                winsLabel.Text = "Wins: " + wins;
                g.DrawImage(winImage, outcomeLocation);
            }
            gongPlay();
        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            playerChoice = "scissor";
            g.DrawImage(scissorImage, playerLocation);
            jabPlayer.Play();
            
            computerChoice();

            if (cpuChoice == "scissor")
            {
                ties++;
                tiesLabel.Text = "Ties: " + ties;
                g.DrawImage(tieImage, outcomeLocation);
            }
            else if (cpuChoice == "rock")
            {
                losses++;
                lossesLabel.Text = "Losses: " + losses;
                g.DrawImage(loseImage, outcomeLocation);
            }
            else
            {
                wins++;
                winsLabel.Text = "Wins: " + wins;
                g.DrawImage(winImage, outcomeLocation);
            }

            gongPlay();
        }

        public void computerChoice()
        {
            int choice = randGen.Next(1, 4);

            if (choice == 1)
            {
                cpuChoice = "rock";
                g.DrawImage(rockImage, cpuLocation);
            }

            else if (choice == 2)
            {
                cpuChoice = "paper";
                g.DrawImage(paperImage, cpuLocation);
            }

            else
            {
                cpuChoice = "scissors";
                g.DrawImage(scissorImage, cpuLocation);
            }
            jabPlayer.Play();
            Thread.Sleep(choicePause);
        }

        public void gongPlay()
        {
            gongPlayer.Play();
            Thread.Sleep(outcomePause);
            Refresh();
        }

        public void determineWinner()
        {

        }
    }
}