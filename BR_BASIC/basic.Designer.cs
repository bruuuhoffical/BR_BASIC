namespace BR_BASIC
{
    partial class basic
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
            this.components = new System.ComponentModel.Container();
            this.kill = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mainpanel = new Guna.UI2.WinForms.Guna2Panel();
            this.savestate = new Guna.UI2.WinForms.Guna2CustomRadioButton();
            this.dcrpc = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.guest = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.streammode = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chamsmenuv2 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chamsmenuv1 = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ss = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ssc = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.aimbotdrag = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.aimbothead = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.basicborder = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.particles = new System.Windows.Forms.Timer(this.components);
            this.drag1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.drag2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.drag3 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.mainpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // kill
            // 
            this.kill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kill.Animated = true;
            this.kill.BackColor = System.Drawing.Color.Transparent;
            this.kill.FillColor = System.Drawing.Color.Transparent;
            this.kill.ForeColor = System.Drawing.Color.Red;
            this.kill.IconColor = System.Drawing.Color.Red;
            this.kill.Location = new System.Drawing.Point(343, 3);
            this.kill.Name = "kill";
            this.kill.Size = new System.Drawing.Size(29, 21);
            this.kill.TabIndex = 4;
            this.kill.Click += new System.EventHandler(this.kill_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Nevan RUS", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 43);
            this.label1.TabIndex = 3;
            this.label1.Text = "BRUUUH CHEATS";
            // 
            // mainpanel
            // 
            this.mainpanel.BackColor = System.Drawing.Color.Transparent;
            this.mainpanel.BorderColor = System.Drawing.Color.Red;
            this.mainpanel.BorderRadius = 5;
            this.mainpanel.BorderThickness = 2;
            this.mainpanel.Controls.Add(this.savestate);
            this.mainpanel.Controls.Add(this.dcrpc);
            this.mainpanel.Controls.Add(this.label11);
            this.mainpanel.Controls.Add(this.guest);
            this.mainpanel.Controls.Add(this.label2);
            this.mainpanel.Controls.Add(this.streammode);
            this.mainpanel.Controls.Add(this.label10);
            this.mainpanel.Controls.Add(this.chamsmenuv2);
            this.mainpanel.Controls.Add(this.label9);
            this.mainpanel.Controls.Add(this.chamsmenuv1);
            this.mainpanel.Controls.Add(this.label8);
            this.mainpanel.Controls.Add(this.ss);
            this.mainpanel.Controls.Add(this.label7);
            this.mainpanel.Controls.Add(this.ssc);
            this.mainpanel.Controls.Add(this.label6);
            this.mainpanel.Controls.Add(this.aimbotdrag);
            this.mainpanel.Controls.Add(this.label5);
            this.mainpanel.Controls.Add(this.aimbothead);
            this.mainpanel.Controls.Add(this.label4);
            this.mainpanel.Location = new System.Drawing.Point(12, 139);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(348, 353);
            this.mainpanel.TabIndex = 5;
            // 
            // savestate
            // 
            this.savestate.Animated = true;
            this.savestate.CheckedState.BorderThickness = 0;
            this.savestate.CheckedState.FillColor = System.Drawing.Color.Red;
            this.savestate.CheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.savestate.Location = new System.Drawing.Point(189, 311);
            this.savestate.Name = "savestate";
            this.savestate.Size = new System.Drawing.Size(20, 20);
            this.savestate.TabIndex = 29;
            this.savestate.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.savestate.UncheckedState.BorderThickness = 2;
            this.savestate.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.savestate.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.savestate.CheckedChanged += new System.EventHandler(this.savestate_CheckedChanged);
            // 
            // dcrpc
            // 
            this.dcrpc.Animated = true;
            this.dcrpc.BackColor = System.Drawing.Color.Transparent;
            this.dcrpc.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dcrpc.CheckedState.BorderRadius = 2;
            this.dcrpc.CheckedState.BorderThickness = 0;
            this.dcrpc.CheckedState.FillColor = System.Drawing.Color.Red;
            this.dcrpc.Location = new System.Drawing.Point(18, 274);
            this.dcrpc.Name = "dcrpc";
            this.dcrpc.Size = new System.Drawing.Size(23, 23);
            this.dcrpc.TabIndex = 28;
            this.dcrpc.UncheckedState.BorderRadius = 2;
            this.dcrpc.UncheckedState.BorderThickness = 0;
            this.dcrpc.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dcrpc.Click += new System.EventHandler(this.dcrpc_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gray;
            this.label11.Location = new System.Drawing.Point(50, 276);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(169, 19);
            this.label11.TabIndex = 27;
            this.label11.Text = "Disable Discord RPC";
            // 
            // guest
            // 
            this.guest.Animated = true;
            this.guest.BackColor = System.Drawing.Color.Transparent;
            this.guest.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guest.CheckedState.BorderRadius = 2;
            this.guest.CheckedState.BorderThickness = 0;
            this.guest.CheckedState.FillColor = System.Drawing.Color.Red;
            this.guest.Location = new System.Drawing.Point(18, 238);
            this.guest.Name = "guest";
            this.guest.Size = new System.Drawing.Size(23, 23);
            this.guest.TabIndex = 26;
            this.guest.UncheckedState.BorderRadius = 2;
            this.guest.UncheckedState.BorderThickness = 0;
            this.guest.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guest.Click += new System.EventHandler(this.guna2CustomCheckBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(50, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 19);
            this.label2.TabIndex = 25;
            this.label2.Text = "Reset Guest";
            // 
            // streammode
            // 
            this.streammode.Animated = true;
            this.streammode.BackColor = System.Drawing.Color.Transparent;
            this.streammode.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.streammode.CheckedState.BorderRadius = 2;
            this.streammode.CheckedState.BorderThickness = 0;
            this.streammode.CheckedState.FillColor = System.Drawing.Color.Red;
            this.streammode.Location = new System.Drawing.Point(18, 310);
            this.streammode.Name = "streammode";
            this.streammode.Size = new System.Drawing.Size(23, 23);
            this.streammode.TabIndex = 24;
            this.streammode.UncheckedState.BorderRadius = 2;
            this.streammode.UncheckedState.BorderThickness = 0;
            this.streammode.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.streammode.Click += new System.EventHandler(this.streammode_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(50, 312);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 19);
            this.label10.TabIndex = 23;
            this.label10.Text = "Streamers Mode";
            // 
            // chamsmenuv2
            // 
            this.chamsmenuv2.Animated = true;
            this.chamsmenuv2.BackColor = System.Drawing.Color.Transparent;
            this.chamsmenuv2.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chamsmenuv2.CheckedState.BorderRadius = 2;
            this.chamsmenuv2.CheckedState.BorderThickness = 0;
            this.chamsmenuv2.CheckedState.FillColor = System.Drawing.Color.Red;
            this.chamsmenuv2.Location = new System.Drawing.Point(18, 202);
            this.chamsmenuv2.Name = "chamsmenuv2";
            this.chamsmenuv2.Size = new System.Drawing.Size(23, 23);
            this.chamsmenuv2.TabIndex = 22;
            this.chamsmenuv2.UncheckedState.BorderRadius = 2;
            this.chamsmenuv2.UncheckedState.BorderThickness = 0;
            this.chamsmenuv2.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chamsmenuv2.Click += new System.EventHandler(this.chamsmenuv2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(50, 204);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(181, 19);
            this.label9.TabIndex = 21;
            this.label9.Text = "Chams Menu (Overlay)";
            // 
            // chamsmenuv1
            // 
            this.chamsmenuv1.Animated = true;
            this.chamsmenuv1.BackColor = System.Drawing.Color.Transparent;
            this.chamsmenuv1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chamsmenuv1.CheckedState.BorderRadius = 2;
            this.chamsmenuv1.CheckedState.BorderThickness = 0;
            this.chamsmenuv1.CheckedState.FillColor = System.Drawing.Color.Red;
            this.chamsmenuv1.Location = new System.Drawing.Point(18, 166);
            this.chamsmenuv1.Name = "chamsmenuv1";
            this.chamsmenuv1.Size = new System.Drawing.Size(23, 23);
            this.chamsmenuv1.TabIndex = 20;
            this.chamsmenuv1.UncheckedState.BorderRadius = 2;
            this.chamsmenuv1.UncheckedState.BorderThickness = 0;
            this.chamsmenuv1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chamsmenuv1.Click += new System.EventHandler(this.chamsmenuv1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(50, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 19);
            this.label8.TabIndex = 19;
            this.label8.Text = "Chams Menu (Normal)";
            // 
            // ss
            // 
            this.ss.Animated = true;
            this.ss.BackColor = System.Drawing.Color.Transparent;
            this.ss.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ss.CheckedState.BorderRadius = 2;
            this.ss.CheckedState.BorderThickness = 0;
            this.ss.CheckedState.FillColor = System.Drawing.Color.Red;
            this.ss.Location = new System.Drawing.Point(18, 130);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(23, 23);
            this.ss.TabIndex = 18;
            this.ss.UncheckedState.BorderRadius = 2;
            this.ss.UncheckedState.BorderThickness = 0;
            this.ss.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ss.Click += new System.EventHandler(this.ss_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(50, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "Sniper Switch";
            // 
            // ssc
            // 
            this.ssc.Animated = true;
            this.ssc.BackColor = System.Drawing.Color.Transparent;
            this.ssc.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ssc.CheckedState.BorderRadius = 2;
            this.ssc.CheckedState.BorderThickness = 0;
            this.ssc.CheckedState.FillColor = System.Drawing.Color.Red;
            this.ssc.Location = new System.Drawing.Point(18, 94);
            this.ssc.Name = "ssc";
            this.ssc.Size = new System.Drawing.Size(23, 23);
            this.ssc.TabIndex = 16;
            this.ssc.UncheckedState.BorderRadius = 2;
            this.ssc.UncheckedState.BorderThickness = 0;
            this.ssc.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ssc.Click += new System.EventHandler(this.ssc_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(50, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "Sniper Scope";
            // 
            // aimbotdrag
            // 
            this.aimbotdrag.Animated = true;
            this.aimbotdrag.BackColor = System.Drawing.Color.Transparent;
            this.aimbotdrag.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.aimbotdrag.CheckedState.BorderRadius = 2;
            this.aimbotdrag.CheckedState.BorderThickness = 0;
            this.aimbotdrag.CheckedState.FillColor = System.Drawing.Color.Red;
            this.aimbotdrag.Location = new System.Drawing.Point(18, 58);
            this.aimbotdrag.Name = "aimbotdrag";
            this.aimbotdrag.Size = new System.Drawing.Size(23, 23);
            this.aimbotdrag.TabIndex = 14;
            this.aimbotdrag.UncheckedState.BorderRadius = 2;
            this.aimbotdrag.UncheckedState.BorderThickness = 0;
            this.aimbotdrag.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aimbotdrag.Click += new System.EventHandler(this.aimbotdrag_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(50, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Aimbot Drag V2 - F5";
            // 
            // aimbothead
            // 
            this.aimbothead.Animated = true;
            this.aimbothead.BackColor = System.Drawing.Color.Transparent;
            this.aimbothead.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.aimbothead.CheckedState.BorderRadius = 2;
            this.aimbothead.CheckedState.BorderThickness = 0;
            this.aimbothead.CheckedState.FillColor = System.Drawing.Color.Red;
            this.aimbothead.Location = new System.Drawing.Point(18, 22);
            this.aimbothead.Name = "aimbothead";
            this.aimbothead.Size = new System.Drawing.Size(23, 23);
            this.aimbothead.TabIndex = 12;
            this.aimbothead.UncheckedState.BorderRadius = 2;
            this.aimbothead.UncheckedState.BorderThickness = 0;
            this.aimbothead.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aimbothead.Click += new System.EventHandler(this.aimbothead_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(50, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Aimbot Drag V1 - F4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(30, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "BASIC PANEL V1.1";
            // 
            // basicborder
            // 
            this.basicborder.AnimateWindow = true;
            this.basicborder.BorderRadius = 10;
            this.basicborder.ContainerControl = this;
            this.basicborder.DockForm = false;
            this.basicborder.DockIndicatorTransparencyValue = 0.6D;
            this.basicborder.ResizeForm = false;
            this.basicborder.ShadowColor = System.Drawing.Color.Red;
            this.basicborder.TransparentWhileDrag = true;
            // 
            // particles
            // 
            this.particles.Enabled = true;
            this.particles.Interval = 2;
            this.particles.Tick += new System.EventHandler(this.particles_Tick);
            // 
            // drag1
            // 
            this.drag1.DockIndicatorTransparencyValue = 0.6D;
            this.drag1.DragEndTransparencyValue = 0.9D;
            this.drag1.TargetControl = this.mainpanel;
            this.drag1.UseTransparentDrag = true;
            // 
            // drag2
            // 
            this.drag2.DockIndicatorTransparencyValue = 0.6D;
            this.drag2.DragEndTransparencyValue = 0.9D;
            this.drag2.TargetControl = this.label1;
            this.drag2.UseTransparentDrag = true;
            // 
            // drag3
            // 
            this.drag3.DockIndicatorTransparencyValue = 0.6D;
            this.drag3.DragEndTransparencyValue = 0.9D;
            this.drag3.TargetControl = this.label3;
            this.drag3.UseTransparentDrag = true;
            // 
            // basic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(372, 504);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.kill);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Red;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "basic";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "basic";
            this.Load += new System.EventHandler(this.basic_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.basic_KeyDown);
            this.mainpanel.ResumeLayout(false);
            this.mainpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ControlBox kill;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel mainpanel;
        private Guna.UI2.WinForms.Guna2CustomCheckBox chamsmenuv2;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2CustomCheckBox chamsmenuv1;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2CustomCheckBox ss;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2CustomCheckBox ssc;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2CustomCheckBox aimbotdrag;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2CustomCheckBox aimbothead;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2CustomCheckBox streammode;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2BorderlessForm basicborder;
        private System.Windows.Forms.Timer particles;
        private Guna.UI2.WinForms.Guna2DragControl drag1;
        private Guna.UI2.WinForms.Guna2DragControl drag2;
        private Guna.UI2.WinForms.Guna2DragControl drag3;
        private Guna.UI2.WinForms.Guna2CustomCheckBox dcrpc;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2CustomCheckBox guest;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2CustomRadioButton savestate;
    }
}