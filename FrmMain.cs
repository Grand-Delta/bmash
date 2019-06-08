using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoBrick
{
    public partial class FrmMain : Form
    {
        private Game game;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void gameArea_Load(object sender, EventArgs e)
        {
            //initialization
            game = new Game();
            game.gameChanged += Game_gameChanged;
        }

        private void Game_gameChanged()
        {
            if (game != null)
            {
                gameArea.Invalidate();
            }
        }

        private void gameArea_Paint(object sender, PaintEventArgs e)
        {
            if (game != null)
            {
                game.Draw(e.Graphics, this.gameArea.Size);
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if(game != null)
            {
                //Transfer case value to Game
                game.KeyDown(e.KeyCode.ToString());
                gameArea.Invalidate();
                if(game.IsGameOver())
                {
                    MessageBox.Show("Game Over!");
                }
            }
        }

        private void gameStart_Click(object sender, EventArgs e)
        {
            game = new Game();
            this.gameArea.Invalidate();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            FrmAboutme frm = new FrmAboutme();
            frm.Show();
        }
    }
}
