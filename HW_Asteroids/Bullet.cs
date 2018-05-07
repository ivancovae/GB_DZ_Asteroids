using System;
using System.Drawing;

namespace HW_Asteroids
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

        }
        
        public override void LoadImage()
        {
            if (Tag == "Bullet00")
            {
                _image = Properties.Resources.bullet_01;
            }
            if (Tag == "Bullet01")
            {
                _image = Properties.Resources.bullet_02;
            }
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X > Game.Width + Size.Width)
            {
                Respown();
            }
        }
        public override void Respown()
        {
            Pos.X = 0;
            Pos.Y = Game._random.Next(0, Game.Height);
        }
    }
}
