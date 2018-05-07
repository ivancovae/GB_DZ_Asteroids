using System;
using System.Drawing;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс фона
    /// </summary>
    class BackgroundObject : BaseObject
    {
        /// <summary>
        /// Конструктор создания фона игровой сцены
        /// </summary>
        /// <param name="pos">объект позиции</param>
        /// <param name="dir">объект направления</param>
        /// <param name="size">объект размера</param>
        /// <param name="tag">тег или название группы</param>
        public BackgroundObject(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

        }
        /// <summary>
        /// Переопределение метода загрузки картинки по тэгу
        /// </summary>
        public override void LoadImage()
        {
            if (Tag == "Space00")
            {
                _image = Properties.Resources.space_00;
            }
            if (Tag == "Space01")
            {
                _image = Properties.Resources.space_01;
            }
        }
        /// <summary>
        /// Метод поведения фона на экране
        /// </summary>
        public override void Update()
        {
            
        }
    }
}
