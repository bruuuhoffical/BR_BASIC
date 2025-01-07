namespace BR_BASIC
{
    partial class MessageBoxControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel = new Guna.UI2.WinForms.Guna2Panel();
            this.testbar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.msglbl = new System.Windows.Forms.Label();
            this.progresstimer = new System.Windows.Forms.Timer(this.components);
            this.msgelispe = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.BorderColor = System.Drawing.Color.White;
            this.panel.BorderRadius = 5;
            this.panel.BorderThickness = 2;
            this.panel.Controls.Add(this.testbar);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.msglbl);
            this.panel.ForeColor = System.Drawing.Color.White;
            this.panel.Location = new System.Drawing.Point(2, 1);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(177, 52);
            this.panel.TabIndex = 1;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // testbar
            // 
            this.testbar.FillColor = System.Drawing.Color.Black;
            this.testbar.ForeColor = System.Drawing.Color.Black;
            this.testbar.Location = new System.Drawing.Point(3, 47);
            this.testbar.Maximum = 5;
            this.testbar.Name = "testbar";
            this.testbar.ProgressBrushMode = Guna.UI2.WinForms.Enums.BrushMode.Solid;
            this.testbar.ProgressColor = System.Drawing.Color.Red;
            this.testbar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.testbar.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.testbar.Size = new System.Drawing.Size(172, 2);
            this.testbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.testbar.TabIndex = 1;
            this.testbar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.testbar.Value = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(159, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "X";
            // 
            // msglbl
            // 
            this.msglbl.AutoSize = true;
            this.msglbl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msglbl.ForeColor = System.Drawing.Color.White;
            this.msglbl.Location = new System.Drawing.Point(4, 18);
            this.msglbl.Name = "msglbl";
            this.msglbl.Size = new System.Drawing.Size(70, 16);
            this.msglbl.TabIndex = 7;
            this.msglbl.Text = "Activating";
            // 
            // progresstimer
            // 
            this.progresstimer.Enabled = true;
            this.progresstimer.Tick += new System.EventHandler(this.progresstimer_Tick);
            // 
            // msgelispe
            // 
            this.msgelispe.BorderRadius = 5;
            this.msgelispe.TargetControl = this;
            // 
            // MessageBoxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.Name = "MessageBoxControl";
            this.Size = new System.Drawing.Size(182, 55);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel;
        private Guna.UI2.WinForms.Guna2ProgressBar testbar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label msglbl;
        private System.Windows.Forms.Timer progresstimer;
        private Guna.UI2.WinForms.Guna2Elipse msgelispe;
    }
}
