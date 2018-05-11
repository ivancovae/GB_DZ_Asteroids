using System;
using System.IO;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс записи в файл журнала
    /// </summary>
    class FileLog
    {
        private static string _fileName = AppDomain.CurrentDomain.BaseDirectory + "log.txt";
        /// <summary>
        /// Свойство имя файла для журналирования
        /// </summary>
        public static string FileName { set { _fileName = value; } get { return _fileName; } }

        /// <summary>
        /// Начать писать журнал в файл
        /// </summary>
        public static void Start()
        {
            Log.OnChangeMessage += ChangeMessage;
        }
        /// <summary>
        /// Прекратить писать журнал в файл
        /// </summary>
        public static void Stop()
        {
            Log.OnChangeMessage -= ChangeMessage;
        }

        private static void ChangeMessage(string message, DateTime time)
        {
            using (StreamWriter file = new StreamWriter(_fileName, true))
            {
                file.WriteLine($"{time}: {message}");
            }
        }
    }
}
