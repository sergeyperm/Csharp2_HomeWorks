using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class Asteroid:GalaxyObjects
    {
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.Orange, pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.FillEllipse(Brushes.Orange, pos.X, pos.Y, size.Width, size.Height);
        }
        
        /// <summary>
        /// Метод обновления координат астероида
        /// </summary>
       public override void Update()
        {
            pos.X = pos.X + dir.X;
            pos.Y = pos.Y + dir.Y;
            if (pos.X > Game.galaxy.galaxyWidth) pos.X = -10;
            if (pos.Y > Game.galaxy.galaxyHeight) pos.Y = -10;
        }
        public void Move()
        {
            Update();
            Draw();
        }

    }
}
