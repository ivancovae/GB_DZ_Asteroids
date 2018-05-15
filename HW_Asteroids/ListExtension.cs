using System;
using System.Collections.Generic;
using System.Linq;

namespace HW_Asteroids
{
    public static class MyExtention
    {
        /// <summary>
        /// Получить количество повторения для элемента в обобщеном списке
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Исключение, которое выдается, если значение аргумента не соответствует допустимому диапазону значений, установленному вызванным методом</exception>
        /// <typeparam name="T">обобщенный тип</typeparam>
        /// <param name="list">метод расширяет класс List<T></param>
        /// <param name="forElement">элемент, для которого ищутся повторения</param>
        /// <returns>количество повторений</returns>
        public static int GetCountRepeat<T>(this List<T> list, T forElement) where T:IEquatable<T>
        {
            if(list.IndexOf(forElement) == -1)
                throw new ArgumentOutOfRangeException($"forElement", $"Элемент не найден в коллекции");

            int count = 0;
            foreach (T val in list)
            {
                if ((val as IEquatable<T>).Equals(forElement))
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// Получить количество повторения для элемента в обобщеном списке по индексу
        /// </summary>
        /// <exception cref="ArgumentNullException">Исключение, которое создается при передаче пустой ссылки методу, который не принимает ее как допустимый аргумент</exception>
        /// <exception cref="ArgumentOutOfRangeException">Исключение, которое выдается, если значение аргумента не соответствует допустимому диапазону значений, установленному вызванным методом</exception>
        /// <typeparam name="T">обобщенный тип</typeparam>
        /// <param name="list">метод расширяет класс List<T></param>
        /// <param name="forIndex">индекс элемента, для которого ищутся повторения</param>
        /// <returns>количество повторений</returns>
        public static int GetCountRepeat<T>(this List<T> list, int forIndex) where T : IEquatable<T>
        {
            return list.GetCountRepeat<T>(list.ElementAt(forIndex));
        }
        /// <summary>
        /// Получить список уникальных элементов
        /// </summary>
        /// <typeparam name="T">обобщенный тип</typeparam>
        /// <param name="list">метод расширяет класс List<T></param>
        /// <returns>коллекцию уникальных элементов списка</returns>
        public static ICollection<T> GetUniques<T>(this List<T> list)
        {
            var found = new Dictionary<T, bool> { };
            List<T> uniques = new List<T> { };
            foreach (T val in list)
            {
                if (!found.ContainsKey(val))
                {
                    found[val] = true;
                    uniques.Add(val);
                }
            }
            return uniques;
        }
        /// <summary>
        /// Получить словарь количества повторений элементов в обобщенном списке
        /// </summary>
        /// <typeparam name="T">обобщенный тип</typeparam>
        /// <param name="list">метод расширяет класс List<T></param>
        /// <returns>словарь с парой ключ\значение, где ключ ссылка на объект, значение количество повторений в списке</returns>
        public static Dictionary<T, int> GetAllCountRepeat<T>(this List<T> list) where T : IEquatable<T>
        {
            var listUniques = list.GetUniques();
            var result = new Dictionary<T, int> { };
            foreach(T val in listUniques)
            {
                result[val] = list.GetCountRepeat<T>(val);
            }
            return result;
        }

        /// <summary>
        /// Получить словарь количества повторений элементов в обобщенном списке с помощью Linq
        /// </summary>
        /// <typeparam name="T">обобщенный тип</typeparam>
        /// <param name="list">метод расширяет класс List<T></param>
        /// <returns>словарь с парой ключ\значение, где ключ ссылка на объект, значение количество повторений в списке</returns>
        public static Dictionary<T, int> GetAllCountRepeatLinq<T>(this List<T> list) where T : IEquatable<T>
        {
            return list.GroupBy(e => e)
                       .Select(g => new { Element = g.Key, Counter = g.Count() })
                       .ToDictionary(g => g.Element, g => g.Counter);
        }


    }
}
