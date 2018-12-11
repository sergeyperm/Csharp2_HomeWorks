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
        private static Ship _ship = new Ship(new Point(500, 200), new Point(5, 5), new Size(10, 10));
        public static Galaxy galaxy;
        public static Sputnic sputnic = new Sputnic(new Point(100, 200), new Point(5, 5), new Size(20, 20), Properties.Resources.sputnik);
        private static Timer timer = new Timer();
        private static List<Asteroid> asteroids;
        private static Bullet bullet;
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
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey) bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(10, 0), new Size(5, 1));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down(galaxy);
            if (e.KeyCode == Keys.Left) _ship.Left();
            if (e.KeyCode == Keys.Right) _ship.Right(galaxy);
        }

        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("Game Over", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 400, 200);
            Buffer.Render();
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
            _ship.Draw();
            sputnic.Draw();
            //for (var i = 0; i < asteroids.Capacity; i++)
            //{
            //    if(asteroids[i]!=null) asteroids[i].Draw();
            //}

            foreach (Asteroid a in asteroids) a.Draw();
            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
            }

            bullet?.Draw();
            Buffer.Render();
        }

        public static void Load()
        {
            galaxy.GalaxyCreate();
            galaxy.GalaxyShow();
            asteroids = new List<Asteroid>();
          
            for (var i = 0; i < 30; i++)
            {
                int r = rand.Next(5, 20);
      
                asteroids.Add(new Asteroid(new Point(rand.Next(0, galaxy.galaxyWidth), rand.Next(0, galaxy.galaxyHeight)), new Point(5, 5), new Size(r, r)));
            }
        }

        /// <summary>
        /// Метод обновления объектов игры
        /// </summary>
        public static void Update()
        {
            sputnic.Update();
            bullet?.Update();
            foreach (Asteroid a in asteroids)
            {
                
                    a.Update();
                    if (bullet != null)
                    {
                        //Столкновение пули и астероида
                        if (a.Collision(bullet))
                        {
                            System.Media.SystemSounds.Beep.Play();
                            asteroids.Remove(a);
                            bullet = null;
                            break;
                        }
                        
                    }

                //Столкновение космического корабля и астероида
                if (_ship.Collision(a))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    _ship?.EnergyLow(5);
                }

            }

        }


    }
}
