using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Asteroids
{
   /// <summary>
   /// Класс игра
   /// </summary>
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        public static Galaxy galaxy;
        public static Sputnic sputnic = new Sputnic(new Point(100, 200), new Point(5, 5), new Size(20, 20), Properties.Resources.sputnik);
        private static Timer timer = new Timer();
        private static Asteroid[] asteroids;
        private static Bullet bullet= new Bullet(new Point(100, 300), new Point(5, 5), new Size(7, 1));
        private static Random rand = new Random();
        /// <summary>
        /// Метод инициализации класса Игра 
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
            Graphics g;
            galaxy = new Galaxy(form.ClientSize.Width, form.ClientSize.Height);
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Buffer = _context.Allocate(g, new Rectangle(0, 0, galaxy.galaxyWidth, galaxy.galaxyHeight));
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            galaxy.GalaxyShow();
            sputnic.Draw();
            for (var i = 0; i < asteroids.Length; i++)
            {
                if(asteroids[i]!=null) asteroids[i].Draw();
            }
            bullet.Draw();
            Buffer.Render();
        }

        public static void Load()
        {
            galaxy.GalaxyCreate();
            galaxy.GalaxyShow();
            asteroids = new Asteroid[20];
          
            for (var i = 0; i < asteroids.Length; i++)
            {
                int r = rand.Next(5, 20);
                asteroids[i] = new Asteroid(new Point(rand.Next(0, galaxy.galaxyWidth), rand.Next(0, galaxy.galaxyHeight)),new Point(5, 5), new Size(r, r));
            }
        }

        /// <summary>
        /// Метод обновления объектов игры
        /// </summary>
        public static void Update()
        {
            sputnic.Update();
            bullet.Update();
            for (var i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] != null)
                {
                    asteroids[i].Update();
                    //Столкновение пули и астероида
                    if (asteroids[i].Collision(bullet))
                    {
                        System.Media.SystemSounds.Hand.Play();
                        bullet = null;
                        asteroids[i] = null;
                        bullet = new Bullet(new Point(galaxy.galaxyWidth, 300), new Point(5, 5), new Size(7, 1));
                        int r = rand.Next(5, 20);
                        // asteroids[i] = new Asteroid(new Point(rand.Next(0, galaxy.galaxyWidth), rand.Next(0, galaxy.galaxyHeight)), new Point(5, 5), new Size(r, r));
                    }
                }
            }
            
        }


    }
}
