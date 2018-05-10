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
        private static Ship _ship;
        private static List<BaseObject> _neitralObjects = new List<BaseObject>();
        private static List<BaseObject> _enemiesObjects = new List<BaseObject>();
        private static List<BaseObject> _bullets = new List<BaseObject>();
        /// <summary>
        /// Метод загузки ресурсов выбранного экрана
        /// </summary>
        public void Load()
        {
            // Корабль
            _ship = new Ship(new Point(10, Game.Height / 2), new Point(0, 5), new Size(40, 40), "Ship0" + Game._random.Next(0, 3).ToString());
            // Нейтральные объекты
            _neitralObjects.Add(new BackgroundObject(new Point(0, 0), new Point(0, 0), new Size(Game.Width, Game.Height), "Space00"));
            for (int i = 0; i < 20; i++)
            {
                _neitralObjects.Add(new Star(Game.GenerateRandomPointOnScreen(), Game.GenerateRandomDir(), Game.GenerateRandomSize(), "Star0" + Game._random.Next(0, 2).ToString()));
            }

            // Враждебные объекты
            for (int i = 0; i < 10; i++)
            {
                BaseObject asteroid = null;
                try
                {
                    asteroid = new Asteroid(Game.GenerateRandomPointOnScreen(), Game.GenerateRandomDir(), Game.GenerateRandomSize(20, 50), "Meteor0" + Game._random.Next(0, 2).ToString());
                }
                catch (GameObjectSizeException gose)
                {
                    MessageBox.Show(gose.Message + Environment.NewLine + gose.gameObject.Tag, "Error");
                    asteroid = new Asteroid(Game.GenerateRandomPointOnScreen(), Game.GenerateRandomDir(), Game.GenerateRandomSize(20, 50), "Meteor0" + Game._random.Next(0, 2).ToString());
                }
                finally
                {
                    _enemiesObjects.Add(asteroid);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                _enemiesObjects.Add(new Alien(Game.GenerateRandomPointOnScreen(), Game.GenerateRandomDir(), Game.GenerateRandomSize(), "Alien0" + Game._random.Next(0, 2).ToString()));
            }
            // Полезные объекты
            //_friendlyObjects.Add(new Bullet(new Point(0, Game._random.Next(0, Game.Height)), new Point(20, 0), new Size(10, 5), "Bullet0" + Game._random.Next(0, 2).ToString()));
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
            _ship.Draw();
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
                        }
                    }

                    if (enemy.isCollision(_ship))
                    {
                        _ship.EnergyLow(10);
                    }
                }
            }
            foreach (BaseObject obj in _bullets.ToArray())
            {
                obj.Update();
                if(obj is Bullet)
                {
                    var temp = obj as Bullet;
                    if(!temp.IsAlive)
                    {
                        _bullets.Remove(obj);
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
