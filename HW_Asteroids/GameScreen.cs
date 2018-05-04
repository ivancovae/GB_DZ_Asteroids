using System;
using System.Drawing;

namespace HW_Asteroids
{
    class GameScreen : IScreenState
    {
        public static Random _random;
        public static BaseObject[] _objs;

        public void Load()
        {
            _random = new Random();            
            _objs = new BaseObject[31];
            _objs[0] = new BaseObject(new Point(0, 0), new Point(0, 0), new Size(Game.Width, Game.Height), Properties.Resources.space_00);

            var size = 0;
            var positionX = 0;
            var positionY = 0;
            var dir = 0;

            for (int i = 1; i < _objs.Length / 2; i++)
            {
                size = _random.Next(10, 30);
                positionX = _random.Next(0, Game.Width);
                positionY = _random.Next(0, Game.Height);
                dir = _random.Next(1, 5);
                _objs[i] = new BaseObject(new Point(positionX, positionY), new Point(dir, 0), new Size(size, size), Properties.Resources.meteor_1);
            }
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
            {
                size = _random.Next(10, 30);
                positionX = _random.Next(0, Game.Width);
                positionY = _random.Next(0, Game.Height);
                dir = _random.Next(1, 5);
                _objs[i] = new Star(new Point(positionX, positionY), new Point(dir, 0), new Size(size, size), Properties.Resources.star_1);
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
    }
}
