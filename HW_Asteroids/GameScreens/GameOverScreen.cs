using System;
using System.Drawing;
using System.Windows.Forms;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс объекта экрана конца игры
    /// </summary>
    class GameOverScreen : IScreenState
    {
        public static BaseObject[] _objs;
        public void CheckMouseClick(MouseEventArgs e)
        {
            
        }
        /// <summary>
        /// Метод отрисовки выбранного экрана
        /// </summary>
        public void Draw()
        {
            foreach (BaseObject obj in _objs)
                obj.Draw();

            Game.Buffer.Graphics.DrawString($"Game Over", SystemFonts.DefaultFont, Brushes.White, Game.Width / 2, Game.Height / 2);
        }
        /// <summary>
        /// Обработка нажатия клавиши
        /// </summary>
        public void KeyDown(KeyEventArgs e)
        {
            
        }
        /// <summary>
        /// Метод загузки ресурсов выбранного экрана
        /// </summary>
        public void Load()
        {
            _objs = new BaseObject[1];
            _objs[0] = new BackgroundObject(new Point(0, 0), new Point(0, 0), new Size(Game.Width, Game.Height), "Space01");
        }
        /// <summary>
        /// Метод обновления объектов выбранного экрана
        /// </summary>
        public void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
    }
}
