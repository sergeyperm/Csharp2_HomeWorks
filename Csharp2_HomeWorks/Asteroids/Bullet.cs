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
        public Bullet(Point pos, Point dir, Size Size) : base(pos, dir, Size)
        {

        }
        /// <summary>
        /// Свойство Size контроль создания размеров пули
        /// </summary>
        public override Size Size
        {
            get { return size; }
            
            set
            {
                if ((value.Height < 0 || value.Width < 0) || (value.Height > 1 || value.Width > 7))
                {
                    throw new GameObjectException("Неверно заданы параметры пули!!");
                }
                else
                {
                    size = value;
                }
            }
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.Red, pos.X, pos.Y, size.Width, size.Height);
        }
        public override void Update()
        {
            pos.X = pos.X - dir.X * 3;
            if (pos.X < 0) pos.X = -10;
        }
        public void Move()
        {
            Update();
            Draw();
        }

    }
}
