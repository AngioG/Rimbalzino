
namespace Rimbalzino
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_timer = new System.Windows.Forms.Button();
            this.logs = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_minus = new System.Windows.Forms.Button();
            this.txt_speed = new System.Windows.Forms.TextBox();
            this.btn_plus = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_num = new System.Windows.Forms.TextBox();
            this.btn_logs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1221, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "RIMBALZINO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 415);
            this.panel1.TabIndex = 1;
            // 
            // btn_stop
            // 
            this.btn_stop.Enabled = false;
            this.btn_stop.Location = new System.Drawing.Point(400, 58);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(200, 35);
            this.btn_stop.TabIndex = 2;
            this.btn_stop.Text = "FREEZE";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.StopAll);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(0, 58);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(200, 35);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.Start);
            // 
            // btn_clear
            // 
            this.btn_clear.Enabled = false;
            this.btn_clear.Location = new System.Drawing.Point(599, 58);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(200, 35);
            this.btn_clear.TabIndex = 4;
            this.btn_clear.Text = "CLEAR";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.Clear);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_timer
            // 
            this.btn_timer.Enabled = false;
            this.btn_timer.Location = new System.Drawing.Point(200, 58);
            this.btn_timer.Name = "btn_timer";
            this.btn_timer.Size = new System.Drawing.Size(200, 35);
            this.btn_timer.TabIndex = 5;
            this.btn_timer.Text = "STOP SPAWNING";
            this.btn_timer.UseVisualStyleBackColor = true;
            this.btn_timer.Click += new System.EventHandler(this.btn_timer_Click);
            // 
            // logs
            // 
            this.logs.FormattingEnabled = true;
            this.logs.Location = new System.Drawing.Point(799, 101);
            this.logs.Name = "logs";
            this.logs.Size = new System.Drawing.Size(422, 407);
            this.logs.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(806, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Velocità:";
            // 
            // btn_minus
            // 
            this.btn_minus.Enabled = false;
            this.btn_minus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btn_minus.Location = new System.Drawing.Point(900, 50);
            this.btn_minus.Name = "btn_minus";
            this.btn_minus.Size = new System.Drawing.Size(30, 46);
            this.btn_minus.TabIndex = 9;
            this.btn_minus.Text = "-";
            this.btn_minus.UseVisualStyleBackColor = true;
            this.btn_minus.Click += new System.EventHandler(this.btn_minus_Click);
            // 
            // txt_speed
            // 
            this.txt_speed.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txt_speed.Location = new System.Drawing.Point(930, 50);
            this.txt_speed.Name = "txt_speed";
            this.txt_speed.ReadOnly = true;
            this.txt_speed.Size = new System.Drawing.Size(30, 45);
            this.txt_speed.TabIndex = 10;
            this.txt_speed.Text = "1";
            this.txt_speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_plus
            // 
            this.btn_plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btn_plus.Location = new System.Drawing.Point(960, 50);
            this.btn_plus.Name = "btn_plus";
            this.btn_plus.Size = new System.Drawing.Size(31, 46);
            this.btn_plus.TabIndex = 11;
            this.btn_plus.Text = "+";
            this.btn_plus.UseVisualStyleBackColor = true;
            this.btn_plus.Click += new System.EventHandler(this.btn_plus_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(1007, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Quadrati:";
            // 
            // txt_num
            // 
            this.txt_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txt_num.Location = new System.Drawing.Point(1106, 51);
            this.txt_num.Name = "txt_num";
            this.txt_num.ReadOnly = true;
            this.txt_num.Size = new System.Drawing.Size(38, 45);
            this.txt_num.TabIndex = 13;
            this.txt_num.Text = "0";
            this.txt_num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_logs
            // 
            this.btn_logs.Location = new System.Drawing.Point(1152, 58);
            this.btn_logs.Name = "btn_logs";
            this.btn_logs.Size = new System.Drawing.Size(57, 35);
            this.btn_logs.TabIndex = 5;
            this.btn_logs.Text = "LOGS";
            this.btn_logs.UseVisualStyleBackColor = true;
            this.btn_logs.Click += new System.EventHandler(this.ShowLogs);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 508);
            this.Controls.Add(this.btn_logs);
            this.Controls.Add(this.txt_num);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_plus);
            this.Controls.Add(this.txt_speed);
            this.Controls.Add(this.btn_minus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.btn_timer);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResizeEnd += new System.EventHandler(this.Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_timer;
        private System.Windows.Forms.ListBox logs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_minus;
        private System.Windows.Forms.TextBox txt_speed;
        private System.Windows.Forms.Button btn_plus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_num;
        private System.Windows.Forms.Button btn_logs;
    }
}

