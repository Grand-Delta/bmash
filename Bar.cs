using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBrick
{
    /// <summary>
    /// Bar Class
    /// </summary>
    class Bar
    {
        public Rectangle Rectangle { get; set; }
        private const int Step = 10;
        private const int BarWidth = 200;
        private int _gameWidth;

        public Bar(int gameWidth)
        {
            _gameWidth = gameWidth;
            Rectangle = new Rectangle((_gameWidth-BarWidth)/2, 600, BarWidth, 25);
        }
        /// <summary>
        /// Draw Bar
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Blue), Rectangle);
        }

        public void KeyDown(String key)
        {
            int newX = Rectangle.X;

            if (key == "A")
            {
                newX -= Step;
                //Prevent left out of bounds
                if (newX < 0)
                    newX = 0;

            }

            if (key == "D")
            {
                newX += Step;
                if (newX + BarWidth > _gameWidth)
                    newX = _gameWidth - BarWidth;
            }

            Rectangle = new Rectangle(newX,
                Rectangle.Y,
                Rectangle.Width,
                Rectangle.Height);


        }
    }
}
