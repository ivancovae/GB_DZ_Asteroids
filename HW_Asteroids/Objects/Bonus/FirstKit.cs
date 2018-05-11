using System;
using System.Drawing;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс объекта аптечка
    /// </summary>
    class FirstKit : BaseObject, ICollision
    {
        private int healingPoint = 10;
        public int HealingPoint => healingPoint;
        /// <summary>
        /// Конструктор создания объект аптечка
        /// </summary>
        /// <param name="pos">Позиция на экране</param>
        /// <param name="dir">Направление движения</param>
        /// <param name="size">Размер противника</param>
        /// <param name="tag">Тэг или название группы противников</param>
        public FirstKit(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {
        }
        /// <summary>
        /// Переопределение метода загрузки картинки по тэгу
        /// </summary>
        public override void LoadImage()
        {
            if (Tag == "Energy00")
            {
                _image = Properties.Resources.power_up_4;
            }
        }
        /// <summary>
        /// Метод поведения аптечки на экране
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < -Size.Width)
            {
                Respawn();
            }
        }

        /// <summary>
        /// Метод "оживления" аптечки
        /// </summary>
        public override void Respawn()
        {
            Pos.X = Game.Width + Size.Width;
            Pos.Y = Game._random.Next(0, Game.Height);
        }
    }
}
