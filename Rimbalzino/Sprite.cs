using System;
using System.Windows.Forms;
using System.Drawing;

namespace Rimbalzino
{
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
