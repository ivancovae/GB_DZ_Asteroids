using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace HW_Asteroids
{
    class GameScreen : IScreenState
    {
        private static List<BaseObject> _neitralObjects = new List<BaseObject>();
        private static List<BaseObject> _enemiesObjects = new List<BaseObject>();
        private static List<BaseObject> _friendlyObjects = new List<BaseObject>();
        
        public void Load()
        {
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
                    asteroid = new Asteroid(Game.GenerateRandomPointOnScreen(), Game.GenerateRandomDir(), Game.GenerateRandomSize(0, 2), "Meteor0" + Game._random.Next(0, 2).ToString());
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
            _friendlyObjects.Add(new Bullet(new Point(0, Game._random.Next(0, Game.Height)), new Point(20, 0), new Size(10, 5), "Bullet0" + Game._random.Next(0, 2).ToString()));
        }
        public void Draw()
        {
            foreach (BaseObject obj in _neitralObjects)
                obj.Draw();
            foreach (BaseObject obj in _enemiesObjects)
                obj.Draw();
            foreach (BaseObject obj in _friendlyObjects)
                obj.Draw();
        }

        public void Update()
        {
            foreach (BaseObject obj in _neitralObjects)
                obj.Update();
            foreach (BaseObject obj in _enemiesObjects)
            {
                obj.Update();
                if (_friendlyObjects.Count > 0)
                {
                    if (obj.isCollision(_friendlyObjects[0]))
                    {
                        obj.Respown();
                        _friendlyObjects[0].Respown();
                    }
                }
            }
            foreach (BaseObject obj in _friendlyObjects)
                obj.Update();
        }
        public void CheckMouseClick(MouseEventArgs e)
        {
            Point mousePt = new Point(e.X, e.Y);
        }
    }
}
