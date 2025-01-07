using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BR_BASIC
{
    public partial class MessageBoxControl : UserControl
    {
        private Timer _slideTimer;
        private Timer _messageTimer;
        private int _remainingTime;
        private bool _isSlidingIn;
        private const int DefaultDuration = 5000;
        private const int SlideSpeed = 15;
        private double progress = 5;
        public MessageBoxControl()
        {
            InitializeComponent();

            _slideTimer = new Timer { Interval = 2 };
            _slideTimer.Tick += SlideTimer_Tick;

            _messageTimer = new Timer { Interval = 1000 };
            _messageTimer.Tick += MessageTimer_Tick;

            this.Visible = false;
        }
        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            _remainingTime -= 1000;
            if (_remainingTime <= 0)
            {
                _messageTimer.Stop();
                HideMessage();
            }
        }

        public void ShowMessage(string message, string status, string imageKey, Color baseColor, int duration = 5000)
        {
            msglbl.Text = message;
            msglbl.ForeColor = GetColorForStatus(status);

            //sep1.FillColor = baseColor;
            panel.BorderColor = baseColor;
            //label1.ForeColor = baseColor;

            _remainingTime = duration;
            this.Visible = true;

            this.Left = this.Parent.ClientSize.Width - this.Width;
            this.Top = this.Parent.ClientSize.Height;





            _isSlidingIn = true;
            _slideTimer.Start();
        }
        private Color GetColorForStatus(string status)
        {
            switch (status.ToLower())
            {
                case "cool": return Color.FromArgb(0, 192, 192);
                case "activating": return Color.Yellow;
                case "activated": return Color.Green;
                case "failed": return Color.Red;
                default: return Color.White;
            }
        }
        private void StartDecreasingProgressBar()
        {
            progress = 5;
            testbar.Value = 5;
            progresstimer.Start();
        }
        private void SlideTimer_Tick(object sender, EventArgs e)
        {
            if (_isSlidingIn)
            {
                if (this.Left > this.Parent.ClientSize.Width - this.Width - 10)
                {
                    this.Left -= SlideSpeed;
                }

                if (this.Top > this.Parent.ClientSize.Height - this.Height - 10)
                {
                    this.Top -= SlideSpeed;
                }
                else
                {
                    _slideTimer.Stop();
                    _messageTimer.Start();
                }
            }
            else
            {
                if (this.Top < this.Parent.ClientSize.Height)
                {
                    this.Top += SlideSpeed;
                }

                if (this.Left < this.Parent.ClientSize.Width - this.Width)
                {
                    this.Left += SlideSpeed;
                }
                else
                {
                    _slideTimer.Stop();
                    this.Visible = false;
                }
            }
        }
        //private Image GetImageForStatus(string imageKey)
        //{
        //    switch (imageKey.ToLower())
        //    {
        //        case "success": return Properties.Resources.check;
        //        case "error": return Properties.Resources.cross;
        //        case "loading": return Properties.Resources.loading;
        //        default: return Properties.Resources.brlogored;
        //    }
        //}

        public void HideMessage()
        {
            _isSlidingIn = false;
            _slideTimer.Start();
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progresstimer_Tick(object sender, EventArgs e)
        {
            progress -= 0.1;

            testbar.Value = (int)progress;

            if (progress <= 0)
            {
                progresstimer.Stop();
            }
        }
    }
}
