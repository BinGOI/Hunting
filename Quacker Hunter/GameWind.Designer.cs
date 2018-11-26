namespace Quacker_Hunter
{
    partial class GameWind
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWind));
            this.canvas = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Aimer = new System.Windows.Forms.Label();
            this.canvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackgroundImage = global::Quacker_Hunter.Properties.Resources.background;
            this.canvas.Controls.Add(this.label3);
            this.canvas.Controls.Add(this.label2);
            this.canvas.Controls.Add(this.label1);
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1056, 527);
            this.canvas.TabIndex = 1;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_Click);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calisto MT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(733, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 41);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hard";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calisto MT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(412, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "Medium";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LawnGreen;
            this.label1.Location = new System.Drawing.Point(135, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Easy";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Aimer
            // 
            this.Aimer.AutoSize = true;
            this.Aimer.BackColor = System.Drawing.Color.Transparent;
            this.Aimer.Image = ((System.Drawing.Image)(resources.GetObject("Aimer.Image")));
            this.Aimer.Location = new System.Drawing.Point(416, 177);
            this.Aimer.Name = "Aimer";
            this.Aimer.Size = new System.Drawing.Size(25, 26);
            this.Aimer.TabIndex = 0;
            this.Aimer.Text = "      \r\n \r\n";
            this.Aimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameWind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 527);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.Aimer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameWind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Quacker Hunter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameWind_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameWind_KeyUp);
            this.canvas.ResumeLayout(false);
            this.canvas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Aimer;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

