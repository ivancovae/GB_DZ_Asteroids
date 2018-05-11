using System;
using System.Collections.Generic;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс журналирования
    /// </summary>
    class Log
    {
        private static List<string> messages = new List<string>();

        /// <summary>
        /// Делегат добавления нового сообщения с передачей времени добавления
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="time">время добавления сообщения</param>
        public delegate void ChangeMessage(string message, DateTime time);
        /// <summary>
        /// событие изменения журнала
        /// </summary>
        public static event ChangeMessage OnChangeMessage;
        /// <summary>
        /// Добавление сообщения в журнал
        /// </summary>
        /// <param name="message">сообщение</param>
        public static void AddMessage(string message)
        {
            messages.Add(message);
            OnChangeMessage?.Invoke(message, DateTime.Now);
        }
    }
}
