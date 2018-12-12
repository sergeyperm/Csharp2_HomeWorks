using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;


namespace Asteroids
{

  
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            timer1.Interval = 100; // 100 миллисекунд
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += timer1_Tick;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            if (progressBar1.Value == 100) timer1.Stop();
        }
    }
}
