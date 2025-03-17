using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging.Effects;

namespace ChessGameGUI
{
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
// size of play button: 16*32, size of pieces: 16*16, king and queen 16*24
        Text = "PvP Chess Game";
        Width = 512;
        Height = 538;
        Image screen = Image.FromFile("Assets/OtherAssets/PlayScreen.png");
        Image resizedScreen = new Bitmap(screen, new Size(500,500));
        this.BackgroundImage = resizedScreen;
        Image play = Image.FromFile("Assets/OtherAssets/PlayButton.png");
        Image resizedPlay = new Bitmap(play, new Size(128,64));
        Image hoverPlay = new Bitmap(play, new Size(154,76));
        
        var openGameButton = new Button()
        {
            Location = new System.Drawing.Point(186,240),
            Width = 130,
            Height = 66,
            Image = resizedPlay,
        };

        openGameButton.BackColor = ColorTranslator.FromHtml("#aaaaaa");
        openGameButton.FlatStyle = FlatStyle.Flat;
        openGameButton.FlatAppearance.BorderSize = 0;

        openGameButton.MouseEnter += (sender, e) =>
        {
            openGameButton.Size = new Size(156,78);
            openGameButton.Image = hoverPlay;
            openGameButton.Location = new System.Drawing.Point(173,234);
            openGameButton.BackColor = ColorTranslator.FromHtml("#aaaaaa");
        };

        openGameButton.MouseLeave += (sender, e) =>
        {
            openGameButton.Size = new Size(130,66);
            openGameButton.Image = resizedPlay;
            openGameButton.Location = new System.Drawing.Point(186,240);
        };

        openGameButton.Click += (sender, e) =>
        {
            var newWindow = new GameWindow();
            newWindow.Show();
            this.Hide();
        };

        Controls.Add(openGameButton);
    }
}

public class GameWindow : Form
{
    public GameWindow()
    {
        Text = "Game Window";
        Width = 530;
        Height = 550;
        string[] tiles = ["0","1","2","3","4","5","6","7"];
        bool colour = true;
        int tile = 0;
        for (int x = 0; x<8; x++)
        {
            for (int y = 0; y<8; y++)
            {
                int xcoord = 64*x;
                int ycoord = 64*y;
                
                var thisButton = new Button()
                {
                    Tag = tiles[x] + tiles[y],
                    Location = new System.Drawing.Point(xcoord,ycoord),
                    Width = 64,
                    Height = 64,
                };
                thisButton.Click += (sender, e) => MessageBox.Show(thisButton.Tag.ToString());
                thisButton.FlatStyle = FlatStyle.Flat;
                thisButton.FlatAppearance.BorderSize = 0;
                Controls.Add(thisButton);
                if (colour)
                {
                    thisButton.BackColor = System.Drawing.Color.White;
                    thisButton.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    thisButton.BackColor = System.Drawing.Color.Black;
                    thisButton.ForeColor = System.Drawing.Color.Black;
                }
                colour = !colour;
                tile++;
            }
            colour = !colour;
        }
    }
}
}