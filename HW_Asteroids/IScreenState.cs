using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW_Asteroids
{
    interface IScreenState
    {
        void Draw();
        void Load();
        void Update();
    }
}
