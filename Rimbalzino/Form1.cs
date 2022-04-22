using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rimbalzino
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            //ShowLogs(btn_logs, EventArgs.Empty);
        }

        private void Start(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                return;

            timer1.Start();
            logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - Ho fatto partire il timer");

            foreach (var o in panel1.Controls)
                (o as Sprite).Stop = false;

            logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - Gli sprites hanno iniziato a muoversi");

            var a = new Sprite("quadrato", panel1);
            panel1.Controls.Add(a);
            int n = int.Parse(txt_num.Text);
            txt_num.Text = (n + 1).ToString();
            logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + $" - Ho generato un nuovo quadrato in posizione ({a.Location.X};{a.Location.Y})");
            a.Click += (o, evento) => this.Clicked(a, e);
            a.OnBounce += (o, evento) => this.OutOfBounces(a, e);

            foreach (var o in panel1.Controls)
                Task.Run(() => (o as Sprite).Run());

            btn_start.Enabled = false;
            btn_clear.Enabled = true;
            btn_stop.Enabled = true;
            btn_timer.Enabled = true;



        }

        private void StopAll(object sender, EventArgs e)
        {
            timer1.Stop();
            logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - Ho fermato la generazione dei quadrati");
            foreach (var o in panel1.Controls)
                (o as Sprite).Stop = true;

            logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - Ho fermato tutti gli sprites");

            btn_start.Enabled = true;
            btn_stop.Enabled = false;
            btn_timer.Enabled = btn_stop.Enabled;
        }

        private void Clear(object sender, EventArgs e)
        {
            bool running = timer1.Enabled;
            timer1.Stop();
            logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - Ho fermato la generazione degli sprites");

            bool primo = true;
            foreach (var o in panel1.Controls)
            {
                if (primo && !(o as Sprite).Stop)
                {
                    logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - Ho fermato tutti gli sprites");
                    primo = false;
                }
                (o as Sprite).Stop = true;
            }

            do
            {
                Control[] ele = new Control[panel1.Controls.Count];
                int i = 0;
                foreach (var o in panel1.Controls)
                {
                    ele[i] = o as Control;
                    panel1.Controls.Remove(o as Control);
                    i++;
                }

                for (int j = 0; j < i; j++)
                    ele[j].Dispose();
            } while (panel1.Controls.Count != 0);
            logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - Ho eliminato tutti gli sprites");
            txt_num.Text = "0";
            if (running)
            {
                timer1.Start();
                logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - Ho fatto ripartire la generazione degli sprites");
            }

            btn_start.Enabled = !running;
            btn_clear.Enabled = false;
            btn_stop.Enabled = running;
            btn_timer.Enabled = running;
        }

        private void btn_timer_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + " - Ho fermato la generazione degli sprites");

            btn_start.Enabled = true;
            btn_stop.Enabled = true;
            btn_timer.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var a = new Sprite("quadrato", panel1);
            panel1.Controls.Add(a);
            Task.Run(() => a.Run());
            a.Click += new EventHandler((o, evento) => this.Clicked(a, e));
            a.OnBounce += new EventHandler((o, evento) => this.OutOfBounces(a, e));
            int n = int.Parse(txt_num.Text);
            txt_num.Text = (n + 1).ToString();
            logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + $" - Ho generato un nuovo quadrato in posizione ({a.Location.X};{a.Location.Y})");

            btn_clear.Enabled = true;
        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            var speed = int.Parse(txt_speed.Text);
            speed += 1;
            if (speed <= 5)
                txt_speed.Text = speed.ToString();
            if (speed == 5)
                btn_plus.Enabled = false;
            btn_minus.Enabled = true;

            Sprite.Speed = speed;
            logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + $" - Ho cambiato la velocità a {speed}");
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            var speed = int.Parse(txt_speed.Text);
            speed -= 1;
            if (speed >= 1)
                txt_speed.Text = speed.ToString();
            if (speed == 1)
                btn_minus.Enabled = false;
            btn_plus.Enabled = true;

            Sprite.Speed = speed;
            logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + $" - Ho cambiato la velocità a {speed}");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            foreach (var o in panel1.Controls)
                (o as Sprite).Stop = true;
        }

        private void Clicked(object sender, EventArgs e)
        {
            (sender as Sprite).Stop = true;
            System.Threading.Thread nuovo = new System.Threading.Thread(() =>
            {
                (sender as Sprite).Dispose();
                int n = int.Parse(txt_num.Text);
                txt_num.Text = (n - 1).ToString();
                logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + $" - Hai eliminato un quadrato");
            });
            nuovo.Start();
        }

        private void OutOfBounces(object sender, EventArgs e)
        {
            int n = int.Parse(txt_num.Text);
            txt_num.Text = (n - 1).ToString();
            logs.Items.Add(DateTime.Now.ToString("HH:mm:ss") + $" - Un quadrato è uscito dallo schermo");
        }

        private void Resize(object sender, EventArgs e)
        {
            panel1.Height = ClientSize.Height - panel1.Location.Y;
            logs.Height = ClientSize.Height - logs.Location.Y;

            if(logs.Visible)
            {
                logs.Location = new Point(ClientSize.Width - logs.Width, logs.Location.Y);
                panel1.Width = ClientSize.Width - logs.Width;
            }
            else
            {
                panel1.Width = ClientSize.Width;
            }
        }

        private void ShowLogs(object sender, EventArgs e)
        {
            if(logs.Visible)
            {
                logs.Visible = false;
                panel1.Width = ClientSize.Width;
            }
            else
            {
                logs.Visible = true;
                panel1.Width = ClientSize.Width - logs.Width;
                logs.Location = new Point(panel1.Width, logs.Location.Y);
            }
        }
    }
}
