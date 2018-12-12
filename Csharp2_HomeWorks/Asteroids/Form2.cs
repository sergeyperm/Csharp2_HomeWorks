using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            InitializeComponent();
            timer1.Interval = 50; // 50 миллисекунд
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += Timer1_Tick;

        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            if (progressBar1.Value == 100) timer1.Stop();
        }

    }
}
