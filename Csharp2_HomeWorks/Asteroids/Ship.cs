using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace Asteroids
{
    class Ship:GalaxyObjects
    {
        private int _energy = 100;
        public static event Message MessageDie;
        public static event Message ShootDown;
        public int Energy => _energy;
        
        public void EnergyLow(int n) //метод уменьшения энергии при столкновении с астероидом
        {
            _energy -= n;
        }

        public void EnergyUp(int n) //метод увеличения энергии при столкновении с аптечкой
        {
           if(_energy<100) _energy += n;
        }

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.Aquamarine, pos.X, pos.Y, size.Width, size.Height);
            Game.Buffer.Graphics.FillRectangle(Brushes.Wheat, pos.X, pos.Y,size.Width, size.Height);
           // Rectangle rect = new Rectangle(pos.X, pos.Y, size.Width, size.Height);
            //Game.Buffer.Graphics.DrawImage(_image, rect);
        }
        public override void Update()
        {
        }
        public void Up()
        {
            if (pos.Y > 0) pos.Y = pos.Y - dir.Y;
        }
        public void Down(Galaxy galaxy)
        {
            if (pos.Y < galaxy.galaxyHeight - 12) pos.Y = pos.Y + dir.Y;
        }

        public void Right(Galaxy galaxy)
        {
            if (pos.X < galaxy.galaxyWidth - 12) pos.X = pos.X + dir.X;
        }
        public void Left()
        {
            if (pos.X > 0) pos.X = pos.X - dir.X;
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }
        public void ShootDownAsteroid()
        {
            ShootDown?.Invoke();
        }
    }
}
