using System;
using System.Drawing;


namespace HW_Asteroids
{
    class Alien : BaseObject
    {
        public Alien(Point pos, Point dir, Size size, Image image) : base(pos, dir, size, image)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y + Convert.ToInt32(Math.Sin(Pos.X/6)*5);
            if (Pos.X < -Size.Width) Pos.X = Game.Width + Size.Width;
        }
    }
}
