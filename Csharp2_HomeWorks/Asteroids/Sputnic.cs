using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
    /// <summary>
    /// Класс спутник
    /// </summary>
    class Sputnic:GalaxyObjects
    {
        public static int r = 110;
        public static int x0 = 570;
        public static int y0 = 270;
        public static double fi = 0.0;
        Bitmap _image;
        Image sputnicImage;
        public Sputnic(Point pos, Point dir, Size size,  Image _sputnicImage) : base(pos, dir, size)
        {
            sputnicImage = _sputnicImage;
            _image=new Bitmap(sputnicImage);
        }
        
        public override void Draw()
        {
            Rectangle rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.DrawImage(_image, rect);
        }
        /// <summary>
        /// Метод движения спутника по кругу
        /// </summary>
        public override void Update()
        {
            fi += 0.1;
            if (fi > 2 * Math.PI) fi = 0.0;
            pos.X = (int)(r * Math.Cos(fi) + x0);
            pos.Y = (int)(r * Math.Sin(fi) + y0);
        }

    }
}
