using System;
using System.Drawing;

namespace HW_Asteroids
{
    class LogoObject : BaseObject
    {
        public LogoObject(Point pos, Point dir, Size size, string tag) : base(pos, dir, size, tag)
        {

        }

        public override void LoadImage()
        {
            if (Tag == "Logo00")
            {
                _image = Properties.Resources.bckgLogoSpace;
            }
        }

        public override void Update()
        {

        }
    }
}
