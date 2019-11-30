using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris;
namespace Sem_SO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            iniciarTImer();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FormMusic form = new FormMusic();
            form.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            TetrisGame game = new TetrisGame();
            game.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void iniciarTImer()
        {
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(Timer1_Tick);

        }
        public void getTime()
        {
            string fecha = DateTime.Now.ToString("HH:mm:ss");
            hora.Text = fecha;

        }
        public void getBatteryStatus()
        {
            PowerStatus status = SystemInformation.PowerStatus;
            string porS = status.BatteryLifePercent.ToString("P0");
            //jaja.Text = porS;
            string[] por = porS.Split();
            int porInt = Int32.Parse(por[0]);
            battery.Value = porInt;

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            getTime();
            getBatteryStatus();
        }



    }

}

