using System;
using System.Timers;
using System.Drawing;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс корабля
    /// </summary>
    class Ship : BaseObject
    {
        public static event Message MessageDie;
        private int _energy = 100;
        private Timer _cooldown = new Timer() { Interval = 1000, Enabled = false };
        /// <summary>
        /// Свойство состояния энергии корабля(readonly)
        /// </summary>
        public int Energy => _energy;

        /// <summary>
        /// Уменьшение значения энергии
        /// </summary>
        /// <param name="n">количество потерянной энергии</param>
        public void EnergyLow(int n)
        {
            _energy -= n;
            if (_energy < 0)
            {
                Die();
            }
        }

        /// <summary>
        /// Обработка бонуса
        /// </summary>
        /// <param name="bonus">объект бонуса, могут быть с разными целями</param>
        public void GetBonus(BaseObject bonus)
        {
            if(bonus is FirstKit)
            {
                var firstKit = bonus as FirstKit;
                _energy += firstKit.HealingPoint;
            }
        }

        /// <summary>
        /// Конструктор создания объекта корабль
        /// </summary>
        /// <param name="pos">объект позиции</param>
        /// <param name="dir">объект направления</param>
        /// <param name="size">объект размера</param>
        /// <param name="tag">тег или название группы</param>
        public Ship(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {
            _cooldown.Elapsed += Cooldown_Elapsed;
        }

        /// <summary>
        /// Переопределение метода загрузки картинки по тэгу
        /// </summary>
        public override void LoadImage()
        {
            if (Tag == "Ship00")
            {
                _image = Properties.Resources.ship_1;
            }
            if (Tag == "Ship01")
            {
                _image = Properties.Resources.ship_2;
            }
            if (Tag == "Ship02")
            {
                _image = Properties.Resources.ship_3;
            }
        }
        /// <summary>
        /// Метод поведения корабля на экране
        /// </summary>
        public override void Update()
        {
            
        }

        /// <summary>
        /// Движение вверх корабля
        /// </summary>
        public void MoveUp()
        {
            if (Pos.Y > 0) Pos.Y -= Dir.Y;
        }
        /// <summary>
        /// Движение вниз корабля
        /// </summary>
        public void MoveDown()
        {
            if (Pos.Y + Size.Height < Game.Height - Size.Height) Pos.Y += Dir.Y;
        }
        /// <summary>
        /// Генерация выстрела
        /// </summary>
        public Bullet PressFire()
        {
            if (!_cooldown.Enabled)
            {
                _cooldown.Enabled = true;
                return new Bullet(new Point(Pos.X + Size.Width, Pos.Y + Size.Height / 2), new Point(Dir.X + 3, Dir.Y), new Size(10, 5), "Bullet0" + Game._random.Next(0, 2).ToString());
            }
            return null;
        }

        private void Cooldown_Elapsed(object sender, ElapsedEventArgs e)
        {
            _cooldown.Enabled = false;
        }

        /// <summary>
        /// Поражение корабля
        /// </summary>
        public void Die()
        {
            MessageDie?.Invoke();
        }
    }
}
