using System;
using System.Drawing;

namespace HW_Asteroids
{
    class BackgroundObject : BaseObject
    {
        public BackgroundObject(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

        }

        public override void LoadImage()
        {
            if (Tag == "Space00")
            {
                _image = Properties.Resources.space_00;
            }
            if (Tag == "Space01")
            {
                _image = Properties.Resources.space_01;
            }
        }

        public override void Update()
        {
            
        }
    }
}
