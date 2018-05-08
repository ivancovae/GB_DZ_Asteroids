using System;
using System.Drawing;


namespace HW_Asteroids
{
    /// <summary>
    /// Класс объекта противника
    /// </summary>
    class Alien : BaseObject
    {
        /// <summary>
        /// Конструктор создания объект противника
        /// </summary>
        /// <param name="pos">Позиция на экране</param>
        /// <param name="dir">Направление движения</param>
        /// <param name="size">Размер противника</param>
        /// <param name="tag">Тэг или название группы противников</param>
        public Alien(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

        }
        
        /// <summary>
        /// Переопределение метода загрузки картинки по тэгу
        /// </summary>
        public override void LoadImage()
        {
            if (Tag == "Alien00")
            {
                _image = Properties.Resources.alien_1;
            }
            if (Tag == "Alien01")
            {
                _image = Properties.Resources.alien_2;
            }
        }

        /// <summary>
        /// Метод поведения противника на экране
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y + Convert.ToInt32(Math.Sin(Pos.X/6)*5);
            if (Pos.X < -Size.Width)
            {
                Respawn();
            }
        }
        /// <summary>
        /// Метод "оживления" противника
        /// </summary>
        public override void Respawn()
        {
            Pos.X = Game.Width + Size.Width;
            Pos.Y = Game._random.Next(0, Game.Height);
        }
    }
}
