using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{/// <summary>
/// Интерфейс обработки столкновений объектов
/// </summary>
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
    /// <summary>
    /// Базовый класс космических объектов
    /// </summary>
    /// 
    public delegate void Message();

    abstract class GalaxyObjects : ICollision
    {
        public Point pos;
        public Point dir;
        public Size size;
        public virtual Size Size { get { return size; } set { size = value; } }
        
        public GalaxyObjects(Point _pos, Point _dir, Size _size)
        {
            pos = _pos;
            dir = _dir;
            Size = _size;
        }
        public abstract void Draw();
        public abstract void Update();
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(pos, size);

    }
}
