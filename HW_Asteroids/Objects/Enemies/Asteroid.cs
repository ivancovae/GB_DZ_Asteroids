using System;
using System.Drawing;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс объекта Астеройд
    /// </summary>
    class Asteroid : BaseObject, ICloneable, IComparable<Asteroid>
    {
        /// <summary>
        /// Свойство мощности астеройда
        /// </summary>
        public int Power { get; set; } = 3;
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
                Respawn(new Point(Game.Width + Size.Width, Game._random.Next(0, Game.Height)));
            }
        }

        /// <summary>
        /// Клонирование объекта
        /// </summary>
        /// <returns>копия объекта</returns>
        public object Clone() => new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X, Dir.Y), new Size(Size.Width, Size.Height), Tag.Clone() as string) { Power = Power };
        /// <summary>
        /// Метод "оживления" астеройда
        /// </summary>
        public override void Respawn(Point newPoint)
        {
            base.Respawn(newPoint);
        }

        int IComparable<Asteroid>.CompareTo(Asteroid other)
        {
            if (Power > other.Power)
                return 1;
            if (Power < other.Power)
                return -1;
            else
                return 0;
        }
    }
}
