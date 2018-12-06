using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Asteroids
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashScreen splashScreen = new SplashScreen();
            splashScreen.Show();
            while(splashScreen.progressBar1.Value<100)
            {
                Application.DoEvents();
            }
            splashScreen.Close();
            splashScreen.Dispose();
            Form form = new Form();
            form.Width = 1000;
            form.Height = 600;
            form.Text = "ASTEROIDS";
            form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Game.Init(form);
            Game.Load();
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
