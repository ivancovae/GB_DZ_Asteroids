using System;
using System.Drawing;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс объекта пули
    /// </summary>
    class Bullet : BaseObject
    {
        /// <summary>
        /// Конструктор создания объекта пули
        /// </summary>
        /// <param name="pos">объект позиции</param>
        /// <param name="dir">объект направления</param>
        /// <param name="size">объект размера</param>
        /// <param name="tag">тег или название группы</param>
        public Bullet(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

        }
        /// <summary>
        /// Переопределение метода загрузки картинки по тэгу
        /// </summary>
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
        /// <summary>
        /// Метод поведения астеройда на экране
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X > Game.Width + Size.Width)
            {
                Respawn();
            }
        }
        /// <summary>
        /// Метод "оживления" пули
        /// </summary>
        public override void Respawn()
        {
            Pos.X = 0;
            Pos.Y = Game._random.Next(0, Game.Height);
        }
    }
}
