using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;



namespace Asteroids
{
    /// <summary>
    /// Класс игра
    /// </summary>
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        private static Ship _ship = new Ship(new Point(500, 200), new Point(5, 5), new Size(20, 20));
        public static Galaxy galaxy;
        public static Sputnic sputnic = new Sputnic(new Point(100, 200), new Point(5, 5), new Size(20, 20), Properties.Resources.sputnik);
        private static Timer timer = new Timer();
        private static Timer timer1 = new Timer() {Interval=10000};//таймер появления аптечки
        private static AidKit aidKit;//аптечка
        private static List<Asteroid> asteroids;//список астероидов
        private static Random rand = new Random();
        private static List<Bullet> bullets;//список снярядов
        public static int countAsteroids = 0;
        public delegate void Direction();
        public static Dictionary<Bullet, Direction> bulletDirections;




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
            timer1.Start();
            timer1.Tick += Timer1_Tick;
            timer.Tick += Timer_Tick;
            form.KeyDown += Form_KeyDown;//подписка на собятие нажатия клавиши на клаиатуре
            Ship.MessageDie += Finish;//подписка на событие при смерти корабля
            Ship.ShootDown += Ship_ShootDown;//подписка на событие при сбитии кораблем астероида
            
        }

        /// <summary>
        /// Запись в файл информации о сбитом астероиде с указанием времени и даты
        /// </summary>
        private static void Ship_ShootDown()
        {
            File.AppendAllText(Application.StartupPath + "Log.txt", "Корабль сбил астероид "+DateTime.Now+"\n");
                

        }

        /// <summary>
        /// Таймер периодического появления аптечки
        /// </summary>

        private static void Timer1_Tick(object sender, EventArgs e)
        {
            if (aidKit==null) aidKit = new AidKit(new Point(rand.Next(10, 500), rand.Next(10, 400)), new Point(5, 5), new Size(10, 10));
        }

        /// <summary>
        /// Метод обработки нажатия клавиши на клавиатуре
        /// </summary>
       
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            //При нажатии кнопки CTRL создается снаряд и добавляется в коллекцию
            if (e.KeyCode == Keys.ControlKey)
            {
                Bullet newBullet=new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(10, 0), new Size(5, 1));
                bullets.Add(newBullet);
            }

            //if (e.KeyCode == Keys.A)
            //{
            //    Bullet newBullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(10, 0), new Size(5, 1));
            //    Direction newbulletDirection = newBullet.Left;
            //    bulletDirections.Add(newBullet, newbulletDirection);
            //}
            //if (e.KeyCode == Keys.D)
            //{
            //    Bullet newBullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(10, 0), new Size(5, 1));
            //    Direction newbulletDirection = newBullet.Right;
            //    bulletDirections.Add(newBullet, newbulletDirection);
            //}
            //if (e.KeyCode == Keys.W)
            //{
            //    Bullet newBullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(10, 0), new Size(5, 1));
            //    Direction newbulletDirection = newBullet.Up;
            //    bulletDirections.Add(newBullet, newbulletDirection);
            //}
            //if (e.KeyCode == Keys.S)
            //{
            //    Bullet newBullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(10, 0), new Size(5, 1));
            //    Direction newbulletDirection = newBullet.Down;
            //    bulletDirections.Add(newBullet, newbulletDirection);
            //}
            //Задание направления движения корабля
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down(galaxy);
            if (e.KeyCode == Keys.Left) _ship.Left();
            if (e.KeyCode == Keys.Right) _ship.Right(galaxy);
        }

        /// <summary>
        /// Метод окончания игры если энергия корабля меньше нуля
        /// </summary>
        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("Game Over", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 400, 200);
            Buffer.Render();
        }

        /// <summary>
        /// Метод работы при вызове таймера
        /// </summary>
        
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        /// <summary>
        /// Метод рисования элементов
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            galaxy?.GalaxyShow();
            _ship?.Draw();
            sputnic?.Draw();
            aidKit?.Draw();
            foreach (Asteroid a in asteroids) a.Draw();
            foreach (Bullet b in bullets) b.Draw();
            //Вывод на экран информации о энергии корабля и количестве сбитых астероидов
            if (_ship != null)
            {
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0, 0);
                Buffer.Graphics.DrawString("Points for asteroids:" + countAsteroids, SystemFonts.DefaultFont, Brushes.White, 100, 0);
            }
            
            Buffer.Render();
        }

        public static void Load()
        {
            galaxy.GalaxyCreate();
            galaxy.GalaxyShow();
            asteroids = new List<Asteroid>();
            bullets = new List<Bullet>();
            for (var i = 0; i < 30; i++)
            {
                int r = rand.Next(5, 20);

                asteroids.Add(new Asteroid(new Point(rand.Next(0, galaxy.galaxyWidth), rand.Next(0, galaxy.galaxyHeight)), new Point(5, 5), new Size(r, r)));
            }
        }

        /// <summary>
        /// //Проверка столкновения множества снарядов с множеством астероидов
        /// </summary>
       
        public static void CheckCollisionsAstBull()
        {
            
            foreach (Bullet b in bullets)
            {
                foreach (Asteroid a in asteroids)
                {
                    //Столкновение пули и астероида
                    if (a.Collision(b))
                    {
                        System.Media.SystemSounds.Beep.Play();
                        asteroids.Remove(a);
                        _ship.ShootDownAsteroid();//активация события сбития кораблем астероида
                        countAsteroids++;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Метод обновления состояния объектов игры
        /// </summary>
        public static void Update()
        {
            sputnic.Update();
            foreach (Bullet b in bullets)
            {
                b.Update();
            }

            //if (bulletDirections != null)
            //{
            //    foreach (KeyValuePair<Bullet, Direction> keyValue in bulletDirections)
            //    {
            //        keyValue.Value.Invoke();
            //    }
            //}

            foreach (Asteroid a in asteroids)
            {
                a.Update();
                //Столкновение космического корабля и астероида
                if (_ship.Collision(a))
                {
                    System.Media.SystemSounds.Asterisk.Play();
                    _ship?.EnergyLow(5);
                }
            }
            CheckCollisionsAstBull();//Провека столкновений астероида и снаряда
            if (_ship.Energy <= 0) _ship.Die();
            if (aidKit != null)
            {
                if (_ship.Collision(aidKit))
                {
                    _ship.EnergyUp(5);
                    aidKit = null;
                }
            }
        }
    }
}
