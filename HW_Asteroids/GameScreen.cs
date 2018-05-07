using System;
using System.Drawing;
using System.Windows.Forms;

namespace HW_Asteroids
{
    class GameScreen : IScreenState
    {
        public enum TypeObject {
            Background = 0,
            Meteor00 = 1,
            Meteor01 = 2,
            Star00 = 3,
            Star01 = 4,
            Alien00 = 5,
            Alien01 = 6
        };

        public static BaseObject[] _objs;

        private BaseObject LoadObject(Point pos, Point dir, Size size, TypeObject type)
        {
            BaseObject obj = null;
            switch(type)
            {
                case TypeObject.Background:
                    {
                        obj = new BackgroundObject(new Point(0, 0), new Point(0, 0), new Size(Game.Width, Game.Height), "Space00");
                    } break;
                case TypeObject.Meteor00:
                    {
                        obj = new Asteroid(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), "Meteor00");
                    } break;
                case TypeObject.Meteor01:
                    {
                        obj = new Asteroid(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), "Meteor02");
                    } break;
                case TypeObject.Star00:
                    {
                        obj = new Star(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), "Star00");
                    } break;
                case TypeObject.Star01:
                    {
                        obj = new Star(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), "Star01");
                    } break;
                case TypeObject.Alien00:
                    {
                        obj = new Alien(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), "Alien00");
                    }
                    break;
                case TypeObject.Alien01:
                    {
                        obj = new Alien(new Point(pos.X, pos.Y), new Point(dir.X, dir.Y), new Size(size.Width, size.Height), "Alien01");
                    }
                    break;
                default:
                    break;
            }
            return obj;
        }
        
        public void Load()
        {            
            _objs = new BaseObject[31];
            _objs[0] = LoadObject(new Point(0, 0), new Point(0, 0), new Size(Game.Width, Game.Height), TypeObject.Background);

            for (int i = 1; i < _objs.Length; i++)
            {
                _objs[i] = LoadObject(Game.GenerateRandomPointOnScreen(), Game.GenerateRandomDir(), Game.GenerateRandomSize(), (TypeObject)Game._random.Next(1, 7));
            }
          
        }
        public void Draw()
        {
            foreach (BaseObject obj in _objs)
                obj.Draw();
        }

        public void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
        public void CheckMouseClick(MouseEventArgs e)
        {
            Point mousePt = new Point(e.X, e.Y);
        }
    }
}
