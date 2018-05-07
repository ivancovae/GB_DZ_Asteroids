using System;

namespace HW_Asteroids
{
    class GameObjectSizeException : Exception
    {
        public BaseObject gameObject;
        public GameObjectSizeException(string message, BaseObject obj) : base(message)
        {
            gameObject = obj;
        }
    }
}
