using System;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс Исключения при создании объекта размера меньше 0
    /// </summary>
    class GameObjectSizeException : Exception
    {
        /// <summary>
        /// Объект который не получилось создать, в примере для выделения тэга
        /// </summary>
        public BaseObject gameObject;
        /// <summary>
        /// конструктор исключения
        /// </summary>
        /// <param name="message">сообщение о произошедшем связанном с размерами</param>
        /// <param name="obj">объект создание которого не получилось выполнить, пример не очень корретный, проверку удобнее было бы делать в конструкторе объекта</param>
        public GameObjectSizeException(string message, BaseObject obj) : base(message)
        {
            gameObject = obj;
        }
    }
}
