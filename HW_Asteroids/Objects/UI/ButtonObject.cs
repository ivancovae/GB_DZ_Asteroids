using System;
using System.Drawing;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс кнопки на экране
    /// </summary>
    class ButtonObject : BaseObject
    {
        /// <summary>
        /// Конструктор создания объекта кнопки
        /// </summary>
        /// <param name="pos">объект позиции</param>
        /// <param name="dir">объект направления</param>
        /// <param name="size">объект размера</param>
        /// <param name="tag">тег или название группы</param>
        public ButtonObject(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

        }
        /// <summary>
        /// Метод поведения кнопки на экране
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            var min = Game.Width / 4;
            var max = Game.Width / 2;
            if (Pos.X < min || Pos.X > max) Dir.X = - Dir.X;
        }
        /// <summary>
        /// Метод проверки клика мыши по кнопке
        /// </summary>
        /// <param name="mousePoint">объект точки клика мышкой</param>
        /// <returns>находится ли курсор при клике на кнопке</returns>
        public virtual bool CheckContains(Point mousePoint) => Frame.Contains(mousePoint);

        /// <summary>
        /// Действие при нажатие по кнопке
        /// </summary>
        public virtual void Action()
        {
            // пока что все кнопки делают одно действие
            // думаю либо от класса кнопки наследовать разные классы кнопок
            // или добавить название кнопки и делегат на событие
            Game.changeScreen(new GameScreen());
        }
        /// <summary>
        /// Переопределение метода загрузки картинки по тэгу
        /// </summary>
        public override void LoadImage()
        {
            if (Tag == "Button_Start")
            {
                _image = Properties.Resources.btnStart;
            }
            if (Tag == "Button_Record")
            {
                _image = Properties.Resources.btnRecord;
            }
            if (Tag == "Button_Exit")
            {
                _image = Properties.Resources.btnExit;
            }
        }
    }
}
