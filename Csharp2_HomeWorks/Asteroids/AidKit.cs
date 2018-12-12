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
    class AidKit:GalaxyObjects
    {
        public AidKit(Point pos, Point dir, Size size) : base(pos, dir, size)
        { }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.Red, pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.FillRectangle(Brushes.Red, pos.X, pos.Y, size.Width, size.Height);
        }
        public override void Update()
        {
        }
    }
}
