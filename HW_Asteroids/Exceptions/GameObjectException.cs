using System;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс Исключения при создании объекта
    /// </summary>
    class GameObjectException : Exception
    {
        /// <summary>
        /// Конструктор исключения в целом
        /// </summary>
        /// <param name="message">сообщение о произошедшем</param>
        public GameObjectException(string message) : base(message)
        {

        }
    }
}
