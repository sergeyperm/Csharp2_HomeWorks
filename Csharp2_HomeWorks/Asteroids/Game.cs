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
            Buffer.Render();
        }

        public static void Load()
        {
            galaxy.GalaxyCreate();
            galaxy.GalaxyShow();
        }

        public static void Update()
        {
            sputnic.Update();
           
        }


    }
}
