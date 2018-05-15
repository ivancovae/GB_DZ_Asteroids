using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HW_Asteroids
{
    static class Program
    {
        static int OrderBy_Method(KeyValuePair<string, int> pair)
        {
            return pair.Value;
        }
        static void Main(string[] args)
        {
            // Проверка для задания 2 - 
            //            Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в
            //                  данной коллекции.
            //              а) для целых чисел;
            //              б) *для обобщенной коллекции;
            //              в)**используя Linq.
            List<char> list = new List<char> { '1', '2', '4', '2', '5', '6', '1', '4', '2', '6', '3', '5', '7', '8', '3', '7', '3', '7', '4', '1', '7', '2', '5', '3' };
            // количество для элемента
            var countUniqueElem = list.GetCountRepeat('4');
            // количество для индекса
            var countUniqueIndex = list.GetCountRepeat(5);
            // все уникальные
            var UniqueAll = list.GetUniques();
            // количество повторений для всех элементов через Linq
            var countUniqueAll = list.GetAllCountRepeatLinq();

            // Задание 3 - Дан фрагмент программы:
            //            а) Свернуть обращение к OrderBy с использованием лямбда - выражения$
            //            б) *Развернуть обращение к OrderBy с использованием делегата Predicate<T>. Исправления условия преподователем - "заменить Predicate<T> на Func<KeyValuePair<string, int>, int>"

            Dictionary<string, int> dict = new Dictionary<string, int>
            {
                { "four", 4 },
                { "two", 2 },
                { "one", 1 },
                { "three", 3 },
            };

            // Вариант из методички 
            #region old
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            #endregion

            // через лямбда-выражения
            #region task_3_A
            var d_3_A = dict.OrderBy(pair => pair.Value);
            #endregion
            
            // развернутый вариант через Func<KeyValuePair<string, int>, int>
            #region task_3_B
            Func<KeyValuePair<string, int>, int> d1 = new Func<KeyValuePair<string, int>, int>(OrderBy_Method);
            var d_3_B = dict.OrderBy(d1);
            #endregion

            foreach (var pair in d_3_B)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Log.OnChangeMessage += ChangeMessage;
            FileLog.Start();
            Form form = new Form
            {
                Width = 800,//Width = Screen.PrimaryScreen.Bounds.Width,
                Height = 600//Height = Screen.PrimaryScreen.Bounds.Height
            };

            Game.Init(form);            
            form.Show();
            Game.Load();            
            Game.Draw();
            Application.Run(form);
        }

        private static void ChangeMessage(string message, DateTime time)
        {
            Console.WriteLine($"{time}: {message}");
        }
    }
}
