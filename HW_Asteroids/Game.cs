using System;
using System.Windows.Forms;
using System.Drawing;

namespace HW_Asteroids
{
    /// <summary>
    /// Класс игрового процесса
    /// </summary>
    class Game
    {
        private static BufferedGraphicsContext _context;
        /// <summary>
        /// Буфер графики
        /// </summary>
        public static BufferedGraphics Buffer;
        private static int _width;
        private static int _height;
        // Свойства
        /// <summary>
        /// Свойство ширины активной области
        /// </summary>
        public static int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value < 0 || value > 1000)
                    throw new ArgumentOutOfRangeException("Ширина");
                _width = value;
            }
        }
        /// <summary>
        /// Свойство высоты активной области
        /// </summary>
        public static int Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value < 0 || value > 1000)
                    throw new ArgumentOutOfRangeException("Высота");
                _height = value;
            }
        }
        /// <summary>
        /// Объект генератор случайных чисел
        /// </summary>
        public static Random _random;

        /// <summary>
        /// Текущий сцена, которая управляет перерисовкой
        /// </summary>
        public static IScreenState _currentScreen;

        static Game() { }

        /// <summary>
        /// Инициализация объекта игры и связывание с размером формы
        /// </summary>
        /// <param name="form">объект формы</param>
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics graphics;
            // Предоставляет доступ к главному 
            //  буферу графического контекства для текущего приложения
            _context = BufferedGraphicsManager.Current;
            graphics = form.CreateGraphics(); // Создаем объект - поверхность рисования и связываем его с формой

            try
            {
                // Запоминаем размеры формы
                Width = form.Width;
                Height = form.Height;
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show(e.Message, "Error");
                Width = 800;
                Height = 600;
            }
            // Связываем буфер в памяти с графическим объектом
            // для того, чтобы рисовать в буфере
            Buffer = _context.Allocate(graphics, new Rectangle(0, 0, Width, Height));
            _random = new Random();

            _currentScreen = new MainMenuScreen();

            // для обеспечения 60 кадров в секунду - 60 срабатываний за 1000(1 секунда) 
            // 1000 / 60 = 16,(6) для плавности интервал нужен 16
            Timer timer = new Timer { Interval = 16 };
            timer.Start();
            timer.Tick += Timer_Tick;

            form.MouseUp += new MouseEventHandler(Form_MouseUp);
        }
        private static void Form_MouseUp(object sender, MouseEventArgs e)
        {
            _currentScreen.CheckMouseClick(e);
        }

        /// <summary>
        /// Метод переключения текущей сцены, обеспечивает переход между объектами сцен
        /// </summary>
        public static void changeScreen()
        {
            _currentScreen = new GameScreen();
            _currentScreen.Load();
        }

        /// <summary>
        /// Метод генерации случайной точки на экране
        /// </summary>
        /// <returns>объект точка</returns>
        public static Point GenerateRandomPointOnScreen()
        {
            var posX = _random.Next(0, Width);
            var posY = _random.Next(0, Height);
            return new Point(posX, posY);
        }
        /// <summary>
        /// Генерация случайного направления для противника
        /// </summary>
        /// <param name="maxDir">объект точка направления</param>
        /// <returns>объект точка</returns>
        public static Point GenerateRandomDir(int maxDir = 5)
        {
            var dirX = _random.Next(1, maxDir);
            return new Point(dirX, 0);
        }
        /// <summary>
        /// Генерация случайного размера объекта - квадрата
        /// </summary>
        /// <param name="min">минимальный размер(по умолчанию = 10)</param>
        /// <param name="max">максимальный размер(по умолчанию = 30)</param>
        /// <returns>объект размера</returns>
        public static Size GenerateRandomSize(int min = 10, int max = 30)
        {
            var size = _random.Next(min, max); ;
            return new Size(size, size);
        }

        /// <summary>
        /// Метод отрисовки в буфер с последующим отображением на форме
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            _currentScreen.Draw();
            Buffer.Render();
        }

        /// <summary>
        /// Метод загузки ресурсов выбранной сцены
        /// </summary>
        public static void Load()
        {
            _currentScreen.Load();
        }
        /// <summary>
        /// Метод обновления ресурсов выбранной сцены
        /// </summary>
        public static void Update()
        {
            _currentScreen.Update();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
    }
}
