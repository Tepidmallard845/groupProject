using System;
using System.Windows.Forms;

namespace ChessTimer
{
    public partial class ChessTimerForm : Form
    {
        private Timer whiteTimer = new Timer();
        private Timer blackTimer = new Timer();
        private int whiteTimeLeft = 900;
        private int blackTimeLeft = 900;
        private bool isWhiteTurn = true;

        public ChessTimerForm()
        {
            InitializeComponent();

            whiteTimer.Interval = 1000;
            whiteTimer.Tick += WhiteTimer_Tick;

            blackTimer.Interval = 1000;
            blackTimer.Tick += BlackTimer_Tick;

            Label whiteLabel = new Label { Text = "White: 15:00", Location = new System.Drawing.Point(50, 100), AutoSize = true, Name = "whiteLabel" };
            Label blackLabel = new Label { Text = "Black: 15:00", Location = new System.Drawing.Point(250, 100), AutoSize = true, Name = "blackLabel" };
            this.Controls.Add(whiteLabel);
            this.Controls.Add(blackLabel);

            // Add Start Button
            Button startButton = new Button { Text = "Start", Location = new System.Drawing.Point(50, 200), AutoSize = true };
            startButton.Click += StartButton_Click;
            this.Controls.Add(startButton);

            // Add Switch Turn Button (for manual testing, optional)
            Button switchTurnButton = new Button { Text = "Switch Turn", Location = new System.Drawing.Point(150, 200), AutoSize = true };
            switchTurnButton.Click += SwitchTurnButton_Click;
            this.Controls.Add(switchTurnButton);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            whiteTimer.Start();
            isWhiteTurn = true;
        }

        private void SwitchTurnButton_Click(object sender, EventArgs e)
        {
            SwitchTurn();
        }

        private void WhiteTimer_Tick(object sender, EventArgs e)
        {
            if (whiteTimeLeft > 0)
            {
                whiteTimeLeft--;
                UpdateLabel("White", whiteTimeLeft);
            }
            else
            {
                whiteTimer.Stop();
                ShowWinScreen("Black");
            }
        }

        private void BlackTimer_Tick(object sender, EventArgs e)
        {
            if (blackTimeLeft > 0)
            {
                blackTimeLeft--;
                UpdateLabel("Black", blackTimeLeft);
            }
            else
            {
                blackTimer.Stop();
                ShowWinScreen("White");
            }
        }

        private void UpdateLabel(string team, int timeLeft)
        {
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;
            string timeText = $"{minutes:D2}:{seconds:D2}";
            Label labelToUpdate = team == "White" ? (Label)this.Controls["whiteLabel"] : (Label)this.Controls["blackLabel"];
            labelToUpdate.Text = $"{team}: {timeText}";
        }

        public void OnMoveMade()
        {
            // Automatically switch turns after a move
            SwitchTurn();
        }

        public void SwitchTurn()
        {
            if (isWhiteTurn)
            {
                whiteTimer.Stop();
                blackTimer.Start();
            }
            else
            {
                blackTimer.Stop();
                whiteTimer.Start();
            }
            isWhiteTurn = !isWhiteTurn;
        }

        private void ShowWinScreen(string winner)
        {
            MessageBox.Show($"{winner} wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}