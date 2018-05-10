using System;
using System.Windows.Forms;

namespace HW_Asteroids
{
    interface IScreenState
    {
        void CheckMouseClick(MouseEventArgs e);
        void KeyDown(KeyEventArgs e);
        void Draw();
        void Load();
        void Update();
    }
}
