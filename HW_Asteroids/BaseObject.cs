using System;
using System.Drawing;

namespace HW_Asteroids
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected Image _image;

        public BaseObject(Point pos, Point dir, Size size, Image image)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            _image = image;
        }

        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public virtual void Update()
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
