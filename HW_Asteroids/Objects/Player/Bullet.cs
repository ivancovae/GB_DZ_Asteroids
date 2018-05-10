﻿using System;
using System.Timers;
using System.Drawing;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс пули
    /// </summary>
    class Bullet : BaseObject
    {
        private Timer _timerAlive = new Timer(5000);
        public bool IsAlive => _timerAlive.Enabled;
        /// <summary>
        /// Конструктор создания пули
        /// </summary>
        /// <param name="pos">позиция, левый верхний край</param>
        /// <param name="dir">направление движения объекта</param>
        /// <param name="size">размер объекта, ширина и высота</param>
        /// <param name="tag">тег пули, нужен для выбора вида пули</param>
        public Bullet(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {
            _timerAlive.Elapsed += TimerLife_Elapsed;
            _timerAlive.Enabled = true;
        }

        private void TimerLife_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timerAlive.Enabled = false;
            _timerAlive.Stop();
        }

        /// <summary>
        /// Загрузка изображения пули по тэгу
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
        /// Обновление позиции и динамики пули на экране
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            //if (Pos.X > Game.Width + Size.Width)
            //{
            //    Respawn();
            //}
        }
        /// <summary>
        /// Перерождение пули
        /// </summary>
        public override void Respawn()
        {
            Pos.X = 0;
            Pos.Y = Game._random.Next(0, Game.Height);
        }
    }
}
