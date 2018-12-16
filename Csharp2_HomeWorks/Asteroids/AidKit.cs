using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{/// <summary>
/// Класс Аптечка
/// </summary>
/// 
    class AidKit:GalaxyObjects
    {
        Bitmap _image;
        Image aidKitImage;
        public AidKit(Point pos, Point dir, Size size, Image _aidKitImage) : base(pos, dir, size)
        {
            aidKitImage = _aidKitImage;
            _image = new Bitmap(aidKitImage);

        }

        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawRectangle(Pens.Red, pos.X, pos.Y, size.Width, size.Height);
            //Game.Buffer.Graphics.FillRectangle(Brushes.Red, pos.X, pos.Y, size.Width, size.Height);
            Rectangle rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.DrawImage(_image, rect);
        }
        public override void Update()
        {
        }
    }
}
