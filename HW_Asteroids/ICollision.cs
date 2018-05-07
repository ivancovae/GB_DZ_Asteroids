using System;
using System.Drawing;

namespace HW_Asteroids
{
    interface ICollision
    {
        bool isCollision(ICollision obj);
        Rectangle Frame { get; }
    }
}
