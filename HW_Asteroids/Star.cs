using System;
using System.Drawing;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс объекта звезда
    /// </summary>
    class Star : BaseObject
    {
        /// <summary>
        /// Конструктор создания объекта звезда
        /// </summary>
        /// <param name="pos">объект позиции</param>
        /// <param name="dir">объект направления</param>
        /// <param name="size">объект размера</param>
        /// <param name="tag">тег или название группы</param>
        public Star(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

        }
        /// <summary>
        /// Переопределение метода загрузки картинки по тэгу
        /// </summary>
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
        /// <summary>
        /// Метод поведения звезды на экране
        /// </summary>
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
