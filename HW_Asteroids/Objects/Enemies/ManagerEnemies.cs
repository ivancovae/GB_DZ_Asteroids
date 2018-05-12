using System;

namespace HW_Asteroids
{
    class ManagerEnemies
    {
        public static BaseObject getAsteroid()
        {
            return new Asteroid(Game.GenerateRandomPointOnScreen(), Game.GenerateRandomDir(), Game.GenerateRandomSize(20, 50), "Meteor0" + Game._random.Next(0, 2).ToString());
        }
        public static BaseObject getAlien()
        {
            return new Alien(Game.GenerateRandomPointOnScreen(), Game.GenerateRandomDir(), Game.GenerateRandomSize(), "Alien0" + Game._random.Next(0, 2).ToString());
        }
    }
}
