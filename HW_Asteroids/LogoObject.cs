using System;
using System.Drawing;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс Лого
    /// </summary>
    class LogoObject : BaseObject
    {
        /// <summary>
        /// Конструктор создания игрового лого
        /// </summary>
        /// <param name="pos">объект позиции</param>
        /// <param name="dir">объект направления</param>
        /// <param name="size">объект размера</param>
        /// <param name="tag">тег или название группы</param>
        public LogoObject(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

        }
        /// <summary>
        /// Переопределение метода загрузки картинки по тэгу
        /// </summary>
        public override void LoadImage()
        {
            if (Tag == "Logo00")
            {
                _image = Properties.Resources.bckgLogoSpace;
            }
        }
        /// <summary>
        /// Метод поведения лого на экране
        /// </summary>
        public override void Update()
        {

        }
    }
}
