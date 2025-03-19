using System;
using System.Windows.Forms;

namespace WinScreen
{
    public partial class WinScreen : Form
    {
        public WinScreen(string winner)
        {
            InitializeComponent();

            Label winLabel = new Label
            {
                Text = $"{winner} wins!",
                Location = new System.Drawing.Point(50, 50),
                AutoSize = true, 
                Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold)
            };

            this.Controls.Add(winLabel);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Name = "WinScreen";
            this.Text = "Game Over";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
    }
}