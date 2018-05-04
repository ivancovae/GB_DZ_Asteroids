using System;
using System.Drawing;
using System.Windows.Forms;

namespace HW_Asteroids
{
    class MainMenuScreen : IScreenState
    {
        public enum TypeObject
        {
            Background = 0,
            Logo = 1,
            ButtonStart = 2,
            ButtonRecord = 3,
            ButtonExit = 4
        };

        public static BaseObject[] _objs;
        private BaseObject LoadObject(Point pos, Point dir, Size size, TypeObject type)
        {
            BaseObject obj = null;
            switch (type)
            {
                case TypeObject.Background:
                    {
                        obj = new BaseObject(new Point(0, 0), new Point(0, 0), new Size(Game.Width, Game.Height), Properties.Resources.space_01);
                    } break;
                case TypeObject.Logo:
                    {
                        obj = new BaseObject(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), Properties.Resources.bckgLogoSpace);
                    }
                    break;
                case TypeObject.ButtonStart:
                    {
                        obj = new ButtonObject(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), Properties.Resources.btnStart);
                    } break;
                case TypeObject.ButtonRecord:
                    {
                        obj = new ButtonObject(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), Properties.Resources.btnRecord);
                    } break;
                case TypeObject.ButtonExit:
                    {
                        obj = new ButtonObject(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), Properties.Resources.btnExit);
                    } break;
                default:
                    break;
            }
            return obj;
        }

        public void Load()
        {
            _objs = new BaseObject[5];
            _objs[0] = LoadObject(new Point(0, 0), new Point(0, 0), new Size(Game.Width, Game.Height), TypeObject.Background);
            _objs[1] = LoadObject(new Point(Game.Width / 2 - 200, 20), new Point(0, 0), new Size(400, 200), TypeObject.Logo);
            _objs[2] = LoadObject(new Point(Game.Width / 2 - 100, Game.Height / 2 - 25), new Point(1, 0), new Size(200, 50), TypeObject.ButtonStart);
            _objs[3] = LoadObject(new Point(Game.Width / 2 - 100, Game.Height / 2 + 50 - 25), new Point(2, 0), new Size(200, 50), TypeObject.ButtonRecord);
            _objs[4] = LoadObject(new Point(Game.Width / 2 - 100, Game.Height / 2 + 100 - 25), new Point(3, 0), new Size(200, 50), TypeObject.ButtonExit);
        }

        public void Draw()
        {
            foreach (BaseObject obj in _objs)
                obj.Draw();
        }

        public void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

        public void CheckMouseClick(MouseEventArgs e)
        {
            Point mousePt = new Point(e.X, e.Y);
            foreach (BaseObject obj in _objs)
            {
                if (obj is ButtonObject)
                {
                    var btn = (obj as ButtonObject);
                    if (btn.CheckContains(mousePt))
                    {
                        btn.Action();
                    }
                }
            }
            
        }
    }
}
