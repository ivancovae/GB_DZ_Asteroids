using System;
using System.Drawing;

namespace HW_Asteroids
{
    class ButtonObject : BaseObject
    {
        public ButtonObject(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

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
            // пока что все кнопки делают одно действие
            // думаю либо от класса кнопки наследовать разные классы кнопок
            // или добавить название кнопки и делегат на событие
            Game.changeScreen();
        }

        public override void LoadImage()
        {
            if (Tag == "Button_Start")
            {
                _image = Properties.Resources.btnStart;
            }
            if (Tag == "Button_Record")
            {
                _image = Properties.Resources.btnRecord;
            }
            if (Tag == "Button_Exit")
            {
                _image = Properties.Resources.btnExit;
            }
        }
    }
}
