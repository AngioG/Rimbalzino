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
            a.Click += new EventHandler((o, evento) => this.Clicked(a, e));
            a.OnBounce += new EventHandler((o, evento) => this.OutOfBounces(a, e));

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

        public class Sprite : PictureBox
        {
            #region static fields
            public static int Speed = 1;
            private static Random random = new Random();
            private static Color[] colors = new Color[15];
            private static bool firstInstance = true;
            #endregion

            #region attributes
            private int bouncesLefts;
            private bool nord = false;
            private bool est = false;
            private Control parent;
            private bool toDispose = false;
            public event EventHandler OnBounce;
            public bool Stop = false;
            #endregion

            #region Constructor
            public Sprite(string name, Control par)
            {
                if (firstInstance)
                {
                    colors[0] = Color.Red;
                    colors[1] = Color.Blue;
                    colors[2] = Color.Green;
                    colors[3] = Color.Yellow;
                    colors[4] = Color.Black;
                    colors[5] = Color.Orange;
                    colors[6] = Color.Purple;
                    colors[7] = Color.Pink;
                    colors[8] = Color.Chocolate;
                    colors[9] = Color.Aqua;
                    colors[10] = Color.Gold;
                    colors[11] = Color.BlueViolet;
                    colors[12] = Color.PaleVioletRed;
                    colors[13] = Color.DarkOliveGreen;
                    colors[14] = Color.SandyBrown;
                }

                base.Name = name;
                parent = par;
                int color = random.Next(0, 15);
                base.BackColor = colors[color];
                int size = random.Next(20, 81);
                base.Location = new Point(random.Next(0, parent.Width - this.Width), random.Next(0, parent.Height - this.Height));
                base.Size = new Size(size, size);
                this.bouncesLefts = random.Next(2, 8);
                nord = random.Next(0, 2) == 0 ? false : true;
                est = random.Next(0, 2) == 0 ? false : true;

                //Roba grafica
                this.DoubleBuffered = true;
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.UpdateStyles();
                //this.Click += click;
            }
            #endregion

            #region Methods
            public void Run()
            {
                parent = this.Parent;
                while (!Stop && !toDispose)
                {
                    this.Step();
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(15);
                }

                if (toDispose)
                    this.Dispose(true);
            }
            private void Step()
            {
                bool bounced = false;
                int y = this.nord ? -Speed : Speed;
                int x = this.est ? -Speed : Speed;
                Location = new Point(Location.X + x, Location.Y + y);

                if (bouncesLefts != 0)
                {
                    if (Location.Y >= parent.Size.Height - Size.Height || Location.Y <= 0)
                    {
                        nord = !nord;
                        bounced = true;
                    }
                    if (Location.X >= parent.Size.Width - Size.Width || Location.X <= 0)
                    {
                        est = !est;
                        bounced = true;
                    }

                    if (bounced)
                        bouncesLefts -= 1;
                }

                if (Location.Y <= -(Size.Width) || Location.Y >= parent.Size.Height + Size.Height || Location.X <= -(Size.Width) || Location.X >= parent.Size.Width + Size.Width)
                {
                    onBounce(EventArgs.Empty);
                    toDispose = true;
                }


            }

            private void onBounce(EventArgs e)
            {
                EventHandler handler = OnBounce;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
            #endregion
        }
    }
}
