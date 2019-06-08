using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBrick
{
    /// <summary>
    /// Ball
    /// </summary>
    class Ball
    {
        public Rectangle Rectangle { get; set; }

        private int SpeedX;
        private int SpeedY;

        public Ball(Rectangle rec)
        {
            Rectangle = rec;
            SpeedX = -20;
            SpeedY = -20;

        }

        public void Draw(Graphics g)
        {
            g.DrawImage(Properties.Resources.ball, Rectangle);
        }

        public void Move(Size size)
        {
            this.Rectangle = new Rectangle(this.Rectangle.X+SpeedX,
                 this.Rectangle.Y+SpeedY, Rectangle.Width, Rectangle.Height);
            //left
            if(this.Rectangle.X <0)
            {
                this.Rectangle = new Rectangle(0,
                    this.Rectangle.Y, Rectangle.Width, Rectangle.Height);
                SpeedX *= -1;
            }
            //right
            if(this.Rectangle.X + this.Rectangle.Width > size.Width)
            {
                this.Rectangle = new Rectangle(size.Width - this.Rectangle.Width,
                    this.Rectangle.Y, Rectangle.Width, Rectangle.Height);
                SpeedX *= -1;
            }
            //up
            if(this.Rectangle.Y <0)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X,
                    0, Rectangle.Width, Rectangle.Height);
                SpeedY *= -1;
            }
            //down
            if(this.Rectangle.Y+this.Rectangle.Height>size.Height)
            {
                this.Rectangle = new Rectangle(this.Rectangle.X,
                                   size.Height-this.Rectangle.Height, Rectangle.Width, Rectangle.Height);
                SpeedY *= -1;
            }
        
        }


        /// <summary>
        /// Change the ball direction on Y-axis
        /// </summary>
        public void ChangeVerDiction()
        {
            SpeedY *= -1;
        }
    }
}
