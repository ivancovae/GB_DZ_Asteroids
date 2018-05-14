using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
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
        private static List<BaseObject> _neitralObjects = new List<BaseObject>();
        private static List<BaseObject> _enemiesObjects = new List<BaseObject>();
        private static List<BaseObject> _bullets = new List<BaseObject>();
        private static List<BaseObject> _bonuses = new List<BaseObject>();
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
            for (int i = 0; i < 5; i++)
            {
                _enemiesObjects.Add(ManagerEnemies.getAsteroid());
            }
            for (int i = 0; i < 5; i++)
            {
                _enemiesObjects.Add(ManagerEnemies.getAlien());
            }
            
            for (int i = 0; i < 5; i++)
            {
                _bonuses.Add(new FirstKit(Game.GenerateRandomPointOnScreen(), Game.GenerateRandomDir(), new Size(20, 20), "Energy0" + Game._random.Next(0, 1).ToString()));
            }

            for (int i = 0; i < 2; i++)
            {
                _bullets.Add(new Bullet(new Point(Game.Width, Game.Height), new Point(3, 0), new Size(10, 5), "Bullet0" + Game._random.Next(0, 2).ToString()));
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
            {
                if (obj.IsShow)
                {
                    obj.Draw();
                }
            }

            foreach (BaseObject obj in _bullets)
            {
                if (obj.IsShow)
                {
                    obj.Draw();
                }
            }
            foreach (BaseObject obj in _bonuses)
            {
                if (obj.IsShow)
                {
                    obj.Draw();
                }
            }
            _ship.Draw();

            Game.Buffer.Graphics.DrawString($"Energy: " + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            Game.Buffer.Graphics.DrawString($"Score: " + _score, SystemFonts.DefaultFont, Brushes.White, 0, 20);
        }
        /// <summary>
        /// Метод обновления объектов выбранного экрана
        /// </summary>
        public void Update()
        {
            int index = _enemiesObjects.FindIndex(e => e.IsShow);
            if (index == -1)
            {
                Log.AddMessage($"Все противники уничтожены. Новый уровень.");
                foreach (BaseObject enemy in _enemiesObjects)
                {
                    enemy.Respawn(Game.GenerateRandomPointBehindScreen());
                }
                if (Game._random.Next(0, 2) == 1)
                {
                    _enemiesObjects.Add(ManagerEnemies.getAsteroid());
                }
                else
                {
                    _enemiesObjects.Add(ManagerEnemies.getAlien());
                }
                foreach (BaseObject bonus in _bonuses)
                {
                    bonus.Respawn(Game.GenerateRandomPointBehindScreen());
                }
            }

            foreach (BaseObject obj in _neitralObjects)
                obj.Update();
            foreach (BaseObject enemy in _enemiesObjects)
            {
                if(enemy.IsShow)
                {
                    enemy.Update();
                    foreach (BaseObject bullet in _bullets)
                    {
                        if (bullet.IsShow && enemy.isCollision(bullet))
                        {
                            enemy.IsShow = false;
                            bullet.IsShow = false;
                            _score++;
                            Log.AddMessage($"Пуля {bullet.Tag} уничтожила {enemy.Tag}");
                        }
                    }

                    if (enemy.isCollision(_ship))
                    {
                        _ship.EnergyLow(10);
                        enemy.IsShow = false;
                        Log.AddMessage($"Корабль поврежден объектом {enemy.Tag}");
                    }
                }
            }
            foreach (BaseObject bonus in _bonuses)
            {
                if (bonus.IsShow)
                {
                    bonus.Update();
                    if (bonus.isCollision(_ship))
                    {
                        _ship.GetBonus(bonus);
                        bonus.IsShow = false;
                        Log.AddMessage($"Корабль получил бонус {bonus.Tag}");
                    }
                }
            }
            foreach (BaseObject bullet in _bullets)
            {
                if (bullet.IsShow)
                {
                    bullet.Update();
                    if (bullet is Bullet)
                    {
                        var temp = bullet as Bullet;
                        if (!temp.IsAlive)
                        {
                            Log.AddMessage($"Дальность полета пули привышена {bullet.Tag}");
                            bullet.IsShow = false;
                        }
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
                        Point? bulletPos = _ship.PressFire();
                        if (bulletPos.HasValue)
                        {
                            int index = _bullets.FindIndex(b => !b.IsShow);
                            if(index != -1)
                            {
                                _bullets[index].Respawn(bulletPos.Value);
                            }
                            
                        }
                            
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
