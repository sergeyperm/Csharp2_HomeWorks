using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroids
{
    class Planet:GalaxyObjects
    {
        string planetPath;
        public Planet(Point pos, Point dir, Size size, string _planetPath) : base(pos, dir, size)
        {
            planetPath = _planetPath;
        }

        public override void Draw()
        {
            Bitmap _image = new Bitmap(Application.StartupPath + planetPath);
            Rectangle rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.DrawImage(_image, rect);
        }
        public override void Update()
        {
            throw new NotImplementedException();
        }

    }
}
