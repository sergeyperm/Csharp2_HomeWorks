using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class Bullet:GalaxyObjects
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.Red, pos.X, pos.Y, size.Width, size.Height);
        }
        public override void Update()
        {
            pos.X = pos.X - dir.X * 2;
            if (pos.X < 0) pos.X = Game.galaxy.galaxyWidth;
        }
        public void Move()
        {
            Update();
            Draw();
        }

    }
}
