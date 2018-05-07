using System;
using System.Drawing;

namespace HW_Asteroids
{
    class Asteroid : BaseObject, ICloneable
    {
        public int Power { get; set; }
        public Asteroid(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {
            Power = 1;
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
                Respown();
            }
        }

        public object Clone()
        {
            var clone = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height), Tag.Clone() as string);
            clone.Power = Power;
            return clone;
        }
        public override void Respown()
        {
            Pos.X = Game.Width + Size.Width;
            Pos.Y = Game._random.Next(0, Game.Height);
        }
    }
}
