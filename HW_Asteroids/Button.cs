using System;
using System.Drawing;

namespace HW_Asteroids
{
    class ButtonObject : BaseObject
    {
        public ButtonObject(Point pos, Point dir, Size size, Image image) : base(pos, dir, size, image)
        {

        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            var min = Game.Width / 4;
            var max = Game.Width / 2;
            if (Pos.X < min || Pos.X > max) Dir.X = - Dir.X;
        }
        public virtual bool CheckContains(Point mousePoint)
        {
            Rectangle rect = new Rectangle(Pos.X, Pos.Y, Size.Width, Size.Height);
            return rect.Contains(mousePoint);
        }

        public virtual void Action()
        {
            Game.changeScreen();
        }
    }
}
