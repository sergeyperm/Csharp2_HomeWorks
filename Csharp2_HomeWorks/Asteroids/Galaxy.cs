using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{/// <summary>
/// Класс создания галактики
/// </summary>
    class Galaxy
    {
        public int galaxyWidth { get; set; }
        public int galaxyHeight { get; set; }
        public List<Star> stars;
        public List<Planet> planets;
       
        public Galaxy(int _galaxyWidth, int _galaxyHeight)
        {
            galaxyWidth = _galaxyWidth;
            galaxyHeight = _galaxyHeight;
        }

        public void GalaxyCreate()
        {
            Random rand = new Random();
            int starPositionX;
            int starPositionY;
            stars = new List<Star>();
            planets = new List<Planet>();
            for (int i = 0; i < 800; i++)
            {
                starPositionX = rand.Next(galaxyWidth);
                starPositionY = rand.Next(galaxyHeight);
                stars.Add(new Star(new Point(starPositionX, starPositionY), new Point(10, 10), new Size(2, 2)));
            }
            planets.Add(new Planet(new Point(500, 200), new Point(10, 10), new Size(150, 150), Properties.Resources.Earth));
            planets.Add(new Planet(new Point(800, 100), new Point(10, 10), new Size(50, 50), Properties.Resources.Luna));
            planets.Add(new Planet(new Point(25, 25), new Point(10, 10), new Size(200, 200), Properties.Resources.sun));
            

        }

        public void GalaxyShow()
        {

            foreach (Star star in stars)
            {
                star.Draw();
            }
            foreach (Planet planet in planets)
            {
                planet.Draw();
            }
            
        }
    }

}
