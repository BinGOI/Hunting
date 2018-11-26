using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Diagnostics;


namespace Quacker_Hunter
{
    public partial class GameWind : Form
    {

        private Game game;
        Boolean levelSelected = false;

        public GameWind(DataModel records)
        {
            InitializeComponent();
            game = new Game(records);
        }

        public GameWind()
        {
            InitializeComponent();
            game = new Game();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (!game.areGraphicsStartarted && levelSelected)
            {
                Graphics f = canvas.CreateGraphics();
                game.startGraphics(f);
            }
        }

        private void GameWind_KeyDown(object sender, KeyEventArgs e)
        {
            game.onKeyPress( e );
        }

        private void GameWind_KeyUp(object sender, KeyEventArgs e)
        {
            game.onKeyRelease( e );
        }



        // Select Easy
        private void label1_Click(object sender, EventArgs e)
        {
            Game.DUCK_MIN_MOVE_SPEED = 10;
            Game.DUCK_MAX_MOVE_SPEED = 18;
            Game.DUCK_CREATE_SPEED = 700;
            levelSelected = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            this.Refresh();
        }

        // Select medium
        private void label2_Click(object sender, EventArgs e)
        {
            Game.DUCK_MIN_MOVE_SPEED = 13;
            Game.DUCK_MAX_MOVE_SPEED = 20;
            Game.DUCK_CREATE_SPEED = 600;
            levelSelected = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            this.Refresh();
        }

        // Select hard
        private void label3_Click(object sender, EventArgs e)
        {
            Game.DUCK_MIN_MOVE_SPEED = 18;
            Game.DUCK_MAX_MOVE_SPEED = 25;
            Game.DUCK_CREATE_SPEED = 400;
            levelSelected = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            this.Refresh();
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Game.AIMER_X = e.X-10;
            Game.AIMER_Y = e.Y-10;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void canvas_Click(object sender, MouseEventArgs e)
        {
            game.onWeaponFire();
           // MessageBox.Show("canvas_Click");
        }
    }
}