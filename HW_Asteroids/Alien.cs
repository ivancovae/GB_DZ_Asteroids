using System;
using System.Drawing;


namespace HW_Asteroids
{
    class Alien : BaseObject
    {
        public Alien(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

        }
        
        public override void LoadImage()
        {
            if (Tag == "Alien00")
            {
                _image = Properties.Resources.alien_1;
            }
            if (Tag == "Alien01")
            {
                _image = Properties.Resources.alien_2;
            }
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y + Convert.ToInt32(Math.Sin(Pos.X/6)*5);
            if (Pos.X < -Size.Width)
            {
                Respown();
            }
        }
        public override void Respown()
        {
            Pos.X = Game.Width + Size.Width;
            Pos.Y = Game._random.Next(0, Game.Height);
        }
    }
}
