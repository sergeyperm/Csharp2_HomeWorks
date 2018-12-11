using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroids
{
    /// <summary>
    /// Класс планета
    /// </summary>
    class Planet:GalaxyObjects
    {
        Image planetImage;
        Bitmap _image;
        public Planet(Point pos, Point dir, Size size, Image _planetImage) : base(pos, dir, size)
        {
            planetImage = _planetImage;
            _image=new Bitmap(planetImage);
        }
       
        
        public override void Draw()
        {
            Rectangle rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.DrawImage(_image, rect);
        }
        public override void Update()
        {
            throw new NotImplementedException();
        }

    }
}
