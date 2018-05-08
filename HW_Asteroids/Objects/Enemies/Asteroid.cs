using System;
using System.Drawing;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс объекта Астеройд
    /// </summary>
    class Asteroid : BaseObject, ICloneable
    {
        /// <summary>
        /// Свойство мощности астеройда
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        /// Конструктор создания объекта астеройд
        /// </summary>
        /// <param name="pos">объект позиции</param>
        /// <param name="dir">объект направления</param>
        /// <param name="size">объект размера</param>
        /// <param name="tag">тег или название группы</param>
        public Asteroid(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {
            Power = 1;
        }
        /// <summary>
        /// Переопределение метода загрузки картинки по тэгу
        /// </summary>
        public override void LoadImage()
        {
            if (Tag == "Meteor00")
            {
                _image = Properties.Resources.meteor_1;
            }
            if (Tag == "Meteor01")
            {
                _image = Properties.Resources.meteor_2;
            }
            if (Tag == "Meteor02")
            {
                _image = Properties.Resources.meteor_3;
            }
        }
        /// <summary>
        /// Метод поведения астеройда на экране
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
        /// Клонирование объекта
        /// </summary>
        /// <returns>копия объекта</returns>
        public object Clone()
        {
            var clone = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height), Tag.Clone() as string);
            clone.Power = Power;
            return clone;
        }
        /// <summary>
        /// Метод "оживления" астеройда
        /// </summary>
        public override void Respawn()
        {
            Pos.X = Game.Width + Size.Width;
            Pos.Y = Game._random.Next(0, Game.Height);
        }
    }
}
