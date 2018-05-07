﻿using System;
using System.Drawing;

namespace HW_Asteroids
{
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

        }

        public override void LoadImage()
        {
            if (Tag == "Star00")
            {
                _image = Properties.Resources.star_1;
            }
            if (Tag == "Star01")
            {
                _image = Properties.Resources.star_2;
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
