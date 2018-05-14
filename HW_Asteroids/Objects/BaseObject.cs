using System;
using System.Drawing;
using System.Linq;

namespace HW_Asteroids
{
    /// <summary>
    /// Базовый класс сущности объект на сцене
    /// </summary>
    abstract class BaseObject : ICollision
    {
        public delegate void Message();
        protected Point Pos;
        protected Size Size;
        protected Image _image;
        /// <summary>
        /// Свойство состояния видимости и взаимодействия объекта
        /// </summary>
        public bool IsShow { get; set; } = true;
        /// <summary>
        /// Свойство названия тэга
        /// </summary>
        public string Tag => _tag.ToString();
        protected string _tag;
        /// <summary>
        /// Прямоугольник объекта(от точки Pos до точки Pos + Size)
        /// </summary>
        public Rectangle Frame => new Rectangle(Pos, Size);

        protected Point Dir;
        /// <summary>
        /// Базовый конструктор инициализации объекта
        /// </summary>
        /// <param name="pos">Позиция объекта(левый верхний край) на экране</param>
        /// <param name="dir">Вектор направления движения на экране</param>
        /// <param name="size">Размер объекта на экране</param>
        /// <param name="tag">Название или тэг объекта</param>
        public BaseObject(Point pos, Point dir, Size size, string tag)
        {
            _tag = tag;
            Pos = pos;
            Dir = dir;
            // to do убрать после домашнего задания
            // проверка должна быть не через исключения, а проверкой и заданием минимального размера, например (1px)х(1px)
            if(size.Width <= 0 || size.Height <= 0)
            {
                throw new GameObjectSizeException("Размер объекта не может быть меньше 0", this);
            }
            Size = size;
            LoadImage();
        }

        /// <summary>
        /// Абстрактная функция инициализации изображения объекта
        /// Вызывается в базовом конструкторе, инициализирует изображение объекта по тэгу
        /// </summary>
        public abstract void LoadImage();
        /// <summary>
        /// Виртуальный метод отрисовки объекта при новом цикле игры
        /// </summary>
        public virtual void Draw()
        {
            if (_image != null)
            {
                Game.Buffer.Graphics.DrawImage(_image, Pos.X, Pos.Y, Size.Width, Size.Height);
            }
        }
        /// <summary>
        /// Абстрактная функция обновления объекта при новом цикле игры
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Реализация интерфейса проверки столкновения
        /// </summary>
        /// <param name="obj">объект, пересечение с которым проверяем</param>
        /// <returns></returns>
        public bool isCollision(ICollision obj) => obj.Frame.IntersectsWith(Frame);
        /// <summary>
        /// Метод "оживления" базового объекта
        /// </summary>
        public virtual void Respawn(Point newPoint)
        {
            Pos = newPoint;
            IsShow = true;
        }
    }
}
