using System;
using System.Drawing;
using System.Windows.Forms;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс объекта экрана меню
    /// </summary>
    class MainMenuScreen : IScreenState
    {
        /// <summary>
        /// Перечисление типов объектов сцены
        /// </summary>
        public enum TypeObject
        {
            Background = 0,
            Logo = 1,
            ButtonStart = 2,
            ButtonRecord = 3,
            ButtonExit = 4
        };

        /// <summary>
        /// Объекты на сцене
        /// </summary>
        public static BaseObject[] _objs;
        private BaseObject LoadObject(Point pos, Point dir, Size size, TypeObject type)
        {
            BaseObject obj = null;
            switch (type)
            {
                case TypeObject.Background:
                    {
                        obj = new BackgroundObject(new Point(0, 0), new Point(0, 0), new Size(Game.Width, Game.Height), "Space01");
                    } break;
                case TypeObject.Logo:
                    {
                        obj = new LogoObject(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), "Logo00");
                    }
                    break;
                case TypeObject.ButtonStart:
                    {
                        obj = new ButtonObject(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), "Button_Start");
                    } break;
                case TypeObject.ButtonRecord:
                    {
                        obj = new ButtonObject(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), "Button_Record");
                    } break;
                case TypeObject.ButtonExit:
                    {
                        obj = new ButtonObject(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), "Button_Exit");
                    } break;
                default:
                    break;
            }
            return obj;
        }
        /// <summary>
        /// Метод загузки ресурсов выбранного экрана
        /// </summary>
        public void Load()
        {
            _objs = new BaseObject[5];
            _objs[0] = LoadObject(new Point(0, 0), new Point(0, 0), new Size(Game.Width, Game.Height), TypeObject.Background);
            _objs[1] = LoadObject(new Point(Game.Width / 2 - 200, 20), new Point(0, 0), new Size(400, 200), TypeObject.Logo);
            _objs[2] = LoadObject(new Point(Game.Width / 2 - 100, Game.Height / 2 - 25), new Point(1, 0), new Size(200, 50), TypeObject.ButtonStart);
            _objs[3] = LoadObject(new Point(Game.Width / 2 - 100, Game.Height / 2 + 50 - 25), new Point(2, 0), new Size(200, 50), TypeObject.ButtonRecord);
            _objs[4] = LoadObject(new Point(Game.Width / 2 - 100, Game.Height / 2 + 100 - 25), new Point(3, 0), new Size(200, 50), TypeObject.ButtonExit);
        }
        /// <summary>
        /// Метод отрисовки выбранного экрана
        /// </summary>
        public void Draw()
        {
            foreach (BaseObject obj in _objs)
                obj.Draw();
        }
        /// <summary>
        /// Метод обновления объектов выбранного экрана
        /// </summary>
        public void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
        /// <summary>
        /// Проверка точки клика на экране
        /// </summary>
        /// <param name="e">событие клика мышкой</param>
        public void CheckMouseClick(MouseEventArgs e)
        {
            Point mousePt = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
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
        /// <summary>
        /// Обработка нажатия клавиши
        /// </summary>
        public void KeyDown(KeyEventArgs e)
        {
            
        }
    }
}
