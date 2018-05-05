using System;
using System.Drawing;

namespace HW_Asteroids
{
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size, Image image) : base(pos, dir, size, image)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < -Size.Width)
            {
                Pos.X = Game.Width + Size.Width;
                Pos.Y = Game._random.Next(0, Game.Height);
            }
        }
    }
}
