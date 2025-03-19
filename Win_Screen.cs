using System;
using System.Windows.Forms;

namespace ChessTimer
{
    public partial class WinScreen : Form
    {
        public WinScreen(string winner)
        {
            InitializeComponent();
            Label winLabel = new Label
            {
                Console.WriteLine ($"{winner} wins!") // make this work with the gui using Black_wins and White_wins or Draw_wins
            };
            this.Controls.Add(winLabel);
        }
}