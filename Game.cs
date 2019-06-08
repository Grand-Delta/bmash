using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBrick
{
    class Game
    {
        private const int GameWidth = 1000;
        private const int GameHeight = 700;
        private List<Brick> Bricks { get; set; }
        /// <summary>
        /// The timer that comes with the game
        /// </summary>
        private System.Timers.Timer Timer { get; set; }

        //Define delegation
        public delegate void GameChanged();
        //Define event
        public event GameChanged gameChanged;


        private Point[] _brickPoints = 
        {
            new Point (100,100),
            new Point (250,100),
            new Point (400,100),
            new Point (550,100),
            new Point (700,100),
            new Point (850,100),
            new Point (100,300),
            new Point (250,300),
            new Point (400,300),
            new Point (550,300),
            new Point (700,300),
            new Point (850,300),
        };

        private Bar _bar;
        private Ball _ball;

        public Game()
        {
            _bar = new Bar(GameWidth);
            _ball = new Ball(new Rectangle(500 - 25, 600-50, 50,50 ));
            //Initialize Bricks
            Bricks = new List<Brick>();
            foreach(var brickPoint in _brickPoints)
            {
                Brick brick = new Brick(new Rectangle(brickPoint, new Size(50, 20)));
                Bricks.Add(brick);
            }
            //Initialize Clock
            Timer= new System.Timers.Timer();
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start(); 
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Process clock program
            _ball.Move(new Size(GameWidth,GameHeight));
            //Process collision
            HandleTouch();
            //Notify game form changed
            gameChanged();
        }

        /// <summary>
        /// Process collision
        /// </summary>
        private void HandleTouch()
        {
            if (_ball.Rectangle.IntersectsWith(_bar.Rectangle))
            {
                //The ball hit the bar
                _ball.ChangeVerDiction();
            }

            Brick brickNow = null;
            foreach (var brick in Bricks)
            {
                if (_ball.Rectangle.IntersectsWith(brick.Rectangle))
                {
                    //The ball hit the brick
                    _ball.ChangeVerDiction();
                    brickNow = brick; //Record
                    break;
                }
            }
            if (brickNow != null)
            {
                Bricks.Remove(brickNow);
            }
        }

        /// <summary>
        /// Drawing game Scene
        /// </summary>
        /// <param name="g"></param>
        /// <param name="size"></param>
        public void Draw(Graphics g, Size size)
        {
            //Define a blank map
            Image img = new Bitmap(GameWidth, GameHeight);

            Graphics _g = Graphics.FromImage(img);
            //Define a rectangle, length and width are predefined
            Rectangle rec = new Rectangle(new Point(0, 0), new Size(GameWidth, GameHeight));

            _g.DrawImage(Properties.Resources.bg, rec);

            _bar.Draw(_g);

            _ball.Draw(_g);

            foreach(var brick in Bricks)
            {
                brick.Draw(_g);
            }

            //todo

            g.DrawImage(img, new Rectangle(new Point(0, 0), size));

        }

        /// <summary>
        /// Process keyboard
        /// </summary>
        /// <param name="key"></param>
        public void KeyDown(String key)
        {
            _bar.KeyDown(key);
        }

        /// <summary>
        /// Define if game finished
        /// </summary>
        /// <param name="brick">The brick that causes the game state to change</param>
        /// <returns>if game finishes, true for finish</returns>
        public bool IsGameOver(Brick brick)
        {
            return false;
        }
    }
}
