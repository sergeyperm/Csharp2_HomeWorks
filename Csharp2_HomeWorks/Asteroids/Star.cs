using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{/// <summary>
/// Класс звезда
/// </summary>
    class Star:GalaxyObjects
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.FillEllipse(Brushes.White, pos.X, pos.Y, size.Width, size.Height);
        }
        public override void Update()
        {
            pos.X = pos.X + dir.X * 2;
            pos.Y = pos.Y + dir.Y * 2;
        }
        public void Move(Galaxy galaxy)
        {
            Update();
            Draw();
        }

    }
}
