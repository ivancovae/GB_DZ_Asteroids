using System;
using System.Drawing;

namespace HW_Asteroids
{
    /// <summary>
    /// Базовый класс сущности объект на сцене
    /// </summary>
    abstract class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        protected Image _image;
        protected string Tag;

        /// <summary>
        /// Базовый конструктор инициализации объекта
        /// </summary>
        /// <param name="pos">Позиция объекта(левый верхний край) на экране</param>
        /// <param name="dir">Вектор направления движения на экране</param>
        /// <param name="size">Размер объекта на экране</param>
        /// <param name="tag">Название или тэг объекта</param>
        public BaseObject(Point pos, Point dir, Size size, string tag)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            Tag = tag;
            LoadImage();
        }

        /// <summary>
        /// Абстрактная функция инициализации изображения объекта
        /// </summary>
        public abstract void LoadImage();
        /// <summary>
        /// Виртуальный метод отрисовки объекта при новом цикле приложения
        /// </summary>
        public virtual void Draw()
        {
            if (_image != null)
            {
                Game.Buffer.Graphics.DrawImage(_image, Pos.X, Pos.Y, Size.Width, Size.Height);
            }
        }
        /// <summary>
        /// Абстрактная функция обновленая объекта при новом цикле приложения
        /// </summary>
        public abstract void Update();
    }
}
