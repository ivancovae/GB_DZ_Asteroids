using System;
using System.Drawing;

namespace HW_Asteroids
{
    class Asteroid : BaseObject
    {
        public Asteroid(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

        }

        public override void LoadImage()
        {
            if (Tag == "Meteor00")
            {
                _image = Properties.Resources.meteor_1;
            }
            if (Tag == "Meteor01")
            {
                _image = Properties.Resources.meteor_2;
            }
            if (Tag == "Meteor02")
            {
                _image = Properties.Resources.meteor_3;
            }
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
