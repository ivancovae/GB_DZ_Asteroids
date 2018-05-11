using System;
using System.Windows.Forms;

namespace HW_Asteroids
{
    static class Program
    {
        static void Main(string[] args)
        {
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
