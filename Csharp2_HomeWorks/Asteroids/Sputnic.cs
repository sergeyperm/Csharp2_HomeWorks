using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    class Sputnic:GalaxyObjects
    {
        string sputnikPath;
        public static int r = 110;
        public static int x0 = 570;
        public static int y0 = 270;
        public static double fi = 0.0;
        public Sputnic(Point pos, Point dir, Size size, string _sputnikPath) : base(pos, dir, size)
        {
            sputnikPath = _sputnikPath;
        }
        public override void Draw()
        {
            Bitmap _image = new Bitmap(Application.StartupPath + sputnikPath);
            Rectangle rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.DrawImage(_image, rect);
        }

        public override void Update()
        {
            fi += 0.1;
            if (fi > 2 * Math.PI) fi = 0.0;
            pos.X = (int)(r * Math.Cos(fi) + x0);
            pos.Y = (int)(r * Math.Sin(fi) + y0);
        }

    }
}
