﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс объекта игрового экрана
    /// </summary>
    class GameScreen : IScreenState
    {
        private static int _score = 0;
        private static Ship _ship;
        private static List<BaseObject> _neitralObjects = new List<BaseObject>(0);
        private static List<BaseObject> _enemiesObjects = new List<BaseObject>(0);
        private static List<BaseObject> _bullets = new List<BaseObject>(0);
        private static List<BaseObject> _bonuses = new List<BaseObject>(0);
        /// <summary>
        /// Метод загузки ресурсов выбранного экрана
        /// </summary>
        public void Load()
        {
            // Корабль
            _ship = new Ship(new Point(10, Game.Height / 2), new Point(0, 5), new Size(40, 40), "Ship0" + Game._random.Next(0, 3).ToString());
            Ship.MessageDie += Ship_MessageDie;

            // Нейтральные объекты
            _neitralObjects.Add(new BackgroundObject(new Point(0, 0), new Point(0, 0), new Size(Game.Width, Game.Height), "Space00"));
            for (int i = 0; i < 20; i++)
            {
                _neitralObjects.Add(new Star(Game.GenerateRandomPointOnScreen(), Game.GenerateRandomDir(), Game.GenerateRandomSize(), "Star0" + Game._random.Next(0, 2).ToString()));
            }

            // Враждебные объекты
            for (int i = 0; i < 10; i++)
            {
                BaseObject asteroid = new Asteroid(Game.GenerateRandomPointOnScreen(), Game.GenerateRandomDir(), Game.GenerateRandomSize(20, 50), "Meteor0" + Game._random.Next(0, 2).ToString());
                _enemiesObjects.Add(asteroid);
            }
            for (int i = 0; i < 10; i++)
            {
                _enemiesObjects.Add(new Alien(Game.GenerateRandomPointOnScreen(), Game.GenerateRandomDir(), Game.GenerateRandomSize(), "Alien0" + Game._random.Next(0, 2).ToString()));
            }
            
            for (int i = 0; i < 5; i++)
            {
                _bonuses.Add(new FirstKit(Game.GenerateRandomPointOnScreen(), Game.GenerateRandomDir(), new Size(20, 20), "Energy0" + Game._random.Next(0, 1).ToString()));
            }
        }

        private void Ship_MessageDie()
        {
            Game.changeScreen(new GameOverScreen());
        }

        /// <summary>
        /// Метод отрисовки выбранного экрана
        /// </summary>
        public void Draw()
        {
            foreach (BaseObject obj in _neitralObjects)
                obj.Draw();
            foreach (BaseObject obj in _enemiesObjects)
                obj.Draw();
            foreach (BaseObject obj in _bullets)
                obj.Draw();
            foreach (BaseObject obj in _bonuses)
                obj.Draw();
            _ship.Draw();

            Game.Buffer.Graphics.DrawString($"Energy: " + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            Game.Buffer.Graphics.DrawString($"Score: " + _score, SystemFonts.DefaultFont, Brushes.White, 0, 20);
        }
        /// <summary>
        /// Метод обновления объектов выбранного экрана
        /// </summary>
        public void Update()
        {
            foreach (BaseObject obj in _neitralObjects)
                obj.Update();
            foreach (BaseObject enemy in _enemiesObjects.ToArray())
            {
                enemy.Update();
                if (_bullets.Count > 0)
                {
                    foreach (BaseObject bullet in _bullets.ToArray())
                    {
                        if (enemy.isCollision(bullet))
                        {
                            enemy.Respawn();
                            _bullets.Remove(bullet);
                            _score++;
                            Log.AddMessage($"Пуля {bullet.Tag} уничтожила {enemy.Tag}");
                        }
                    }
                }

                if (enemy.isCollision(_ship))
                {
                    _ship.EnergyLow(10);
                    enemy.Respawn();
                    Log.AddMessage($"Корабль поврежден объектом {enemy.Tag}");
                }
            }
            foreach (BaseObject bonus in _bonuses.ToArray())
            {
                bonus.Update();
                if (bonus.isCollision(_ship))
                {
                    _ship.GetBonus(bonus);
                    bonus.Respawn();
                    Log.AddMessage($"Корабль получил бонус {bonus.Tag}");
                }
            }
            foreach (BaseObject bullet in _bullets.ToArray())
            {
                bullet.Update();
                if(bullet is Bullet)
                {
                    var temp = bullet as Bullet;
                    if(!temp.IsAlive)
                    {
                        Log.AddMessage($"Дальность полета пули привышена {bullet.Tag}");
                        _bullets.Remove(bullet);
                    }
                }
            }
                
        }
        /// <summary>
        /// Проверка точки клика на экране
        /// </summary>
        /// <param name="e">событие клика мышкой</param>
        public void CheckMouseClick(MouseEventArgs e)
        {
            Point mousePt = new Point(e.X, e.Y);
        }

        /// <summary>
        /// Обработка нажатия клавиши
        /// </summary>
        /// <param name="e"></param>
        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    {
                        BaseObject bullet = _ship.PressFire();
                        if (bullet != null)
                            _bullets.Add(bullet);
                    }
                    break;
                case Keys.Up:
                    {
                        _ship.MoveUp();
                    }
                    break;
                case Keys.Down:
                    {
                        _ship.MoveDown();
                    }
                    break;
            }
        }
    }
}
