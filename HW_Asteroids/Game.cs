using System;
using System.Windows.Forms;
using System.Drawing;

namespace HW_Asteroids
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static int _width;
        private static int _height;
        // Свойства
        public static int Width
        {
            get
            {
                return _width;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Ширина");
                if (value > 1000)
                    throw new ArgumentOutOfRangeException("Ширина");
                _width = value;
            }
        }
        public static int Height
        {
            get
            {
                return _height;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Высота");
                if (value > 1000)
                    throw new ArgumentOutOfRangeException("Высота");
                _height = value;
            }
        }
        public static Random _random;

        public static IScreenState _currentScreen;

        static Game() { }

        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики
            Graphics graphics;
            // Предоставляет доступ к главному 
            //  буферу графического контекства для текущего приложения
            _context = BufferedGraphicsManager.Current;
            graphics = form.CreateGraphics(); // Создаем объект - поверхность рисования и связываем его с формой

            // Запоминаем размеры формы
            Width = form.Width;
            Height = form.Height;
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

        public static void changeScreen()
        {
            _currentScreen = new GameScreen();
            _currentScreen.Load();
        }

        public static Point GenerateRandomPointOnScreen()
        {
            var posX = _random.Next(0, Width);
            var posY = _random.Next(0, Height);
            return new Point(posX, posY);
        }
        public static Point GenerateRandomDir(int maxDir = 5)
        {
            var dirX = _random.Next(1, maxDir);
            return new Point(dirX, 0);
        }
        public static Size GenerateRandomSize(int min = 10, int max = 30)
        {
            var size = _random.Next(min, max); ;
            return new Size(size, size);
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            _currentScreen.Draw();
            Buffer.Render();
        }

        public static void Load()
        {
            _currentScreen.Load();
        }

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
