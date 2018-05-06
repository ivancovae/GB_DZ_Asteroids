using System;
using System.Drawing;

namespace HW_Asteroids
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

        }
        
        public override void LoadImage()
        {
            if (Tag == "Bullet00")
            {
                _image = Properties.Resources.space_00;
            }
            if (Tag == "Bullet01")
            {
                _image = Properties.Resources.space_01;
            }
        }

        public override void Update()
        {
            
        }
    }
}
