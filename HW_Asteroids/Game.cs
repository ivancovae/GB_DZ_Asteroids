using System;
using System.Windows.Forms;
using System.Drawing;

namespace HW_Asteroids
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        public static int Width { get; set; }
        public static int Height { get; set; }

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

            _currentScreen = new GameScreen();

            Load();
            // для обеспечения 60 кадров в секунду - 60 срабатываний за 1000(1 секунда) 
            // 1000 / 60 = 16,(6) для плавности интервал нужен 16
            Timer timer = new Timer { Interval = 16 };
            timer.Start();
            timer.Tick += Timer_Tick;
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
