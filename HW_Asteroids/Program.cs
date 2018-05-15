using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HW_Asteroids
{
    static class Program
    {
        static void Main(string[] args)
        {
            List<char> list = new List<char> { '1', '2', '4', '2', '5', '6', '1', '4', '2', '6', '3', '5', '7', '8', '3', '7', '3', '7', '4', '1', '7', '2', '5', '3' };
            var countUniqueElem = list.GetCountRepeat('4');
            var countUniqueIndex = list.GetCountRepeat(5);
            var UniqueAll = list.GetUniques();
            var countUniqueAll = list.GetAllCountRepeatLinq();
            Console.WriteLine(1);

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
