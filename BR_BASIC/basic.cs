using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Bruuuh;
using DiscordRPC;
using Microsoft.Win32;
using RedMem;
using TheArtOfDevHtmlRenderer.Adapters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace BR_BASIC
{
    public partial class basic : Form
    {
        private const string registryKey = @"Software\BRUUUH_BASIC";
        private const string strmstate = "Streamer Mode";
        private List<MessageBoxControl> _messageBoxes;
        private static int activeMessageBoxes = 0;
        private static int lastMessageBoxY = 0;
        private MessageBoxControl _messageBox;
        private ParticleSystem particleSystem;
        private string RED;

        public static MemRed RedLib = new MemRed();
        public static String PID;
        Evelyn bruuuh = new Evelyn();

        private const int HOTKEY_F4 = 1;
        private const int HOTKEY_F5 = 2;

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const uint MOD_NONE = 0x0000;


        string sscSearch = "8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01";
        string sscReplace = "8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 FF FF 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01";
        string ssSearch = "00 00 00 81 95 E3 3F 00 00 80 3F 00 00 80 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 90 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 3F 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00";
        string ssReplace = "00 00 00 81 95 E3 3F 00 00 80 3F 00 00 80 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 90 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 2B 00 00 80 2B 00 00 00 00 04 00 00 00 00 00 80 3F 00";
        List<long> addressesSsc = new List<long>();
        List<long> addressesSs = new List<long>();
        public basic()
        {
            InitializeComponent();
            #region Message
            _messageBoxes = new List<MessageBoxControl>();
            _messageBox = new MessageBoxControl
            {
                Visible = false,
                Dock = DockStyle.Bottom
            };
            this.Controls.Add(_messageBox);
            #endregion
            #region Show Particles
            particleSystem = new ParticleSystem();
            #endregion
            RegisterHotKey(this.Handle, HOTKEY_F4, MOD_NONE, (uint)Keys.F4);
            RegisterHotKey(this.Handle, HOTKEY_F5, MOD_NONE, (uint)Keys.F5);
        }

        private void kill_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        public static bool Streaming;

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);
        
        private void streammode_Click(object sender, EventArgs e)
        {
            if (streammode.Checked)
            {
                EnableStreamerMode();
            }
            else
            {
                DisabeStreamerMode();
            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                int hotkeyId = m.WParam.ToInt32();
                switch (hotkeyId)
                {
                    case HOTKEY_F4:
                        EnableAimbothead();
                        break;
                    case HOTKEY_F5:
                        EnableAimbotDrag();
                        break;
                }
            }
        }
        #region .
        private void EnableStreamerMode()
        {
            base.ShowInTaskbar = false;
            Streaming = true;
            SetWindowDisplayAffinity(base.Handle, 17U);
            basicborder.HasFormShadow = false;
            basicborder.ShadowColor = Color.Black;
            ShowMessageBox("Streamer Mode Enabled", "sucess", "");
        }
        private void DisabeStreamerMode()
        {
            base.ShowInTaskbar = true;
            Streaming = false;
            SetWindowDisplayAffinity(base.Handle, 0U);
            basicborder.HasFormShadow = false;
            basicborder.ShadowColor = Color.Red;
            ShowMessageBox("Streamer Mode Disabled", "sucess", "");
        }
        #region Particles
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            particleSystem.DrawParticles(e.Graphics);
        }
        #endregion
        private void ShowMessageBox(string message, string status, string imageKey)
        {
            MessageBoxControl messageBox = new MessageBoxControl();
            this.Controls.Add(messageBox);

            Color baseColor = label1.ForeColor;

            if (activeMessageBoxes > 0)
            {
                messageBox.Location = new Point(this.ClientSize.Width - messageBox.Width - 10, lastMessageBoxY - messageBox.Height - 10);
            }
            else
            {
                messageBox.Location = new Point(this.ClientSize.Width - messageBox.Width - 10, this.ClientSize.Height - messageBox.Height - 10);
            }

            lastMessageBoxY = messageBox.Location.Y;
            messageBox.BringToFront();

            messageBox.ShowMessage(message, status, imageKey, baseColor);

            activeMessageBoxes++;

            Timer timer = new Timer { Interval = 5000 }; 
            timer.Tick += (sender, e) =>
            {
                messageBox.HideMessage();
                activeMessageBoxes--;

                if (activeMessageBoxes > 0)
                {
                    foreach (Control control in this.Controls)
                    {
                        if (control is MessageBoxControl && control.Location.Y < lastMessageBoxY)
                        {
                            control.Location = new Point(control.Location.X, control.Location.Y + messageBox.Height + 10);
                        }
                    }
                }

                if (activeMessageBoxes == 0)
                {
                    lastMessageBoxY = this.ClientSize.Height - messageBox.Height - 10;
                }

                timer.Stop();
            };
            timer.Start();
        }
        #endregion
        private void particles_Tick(object sender, EventArgs e)
        {
            particleSystem.UpdateParticles();
            Invalidate();
        }



        #region Checkbox Commands
        private void aimbothead_Click(object sender, EventArgs e)
        {
            if (aimbothead.Checked)
            {
                EnableAimbothead();
            }
            else
            {
                DisableAimbothead();
            }
        }

        private void aimbotdrag_Click(object sender, EventArgs e)
        {
            if (aimbotdrag.Checked)
            {
                EnableAimbotDrag();
            }
            else
            {
                DisableAimbotDrag();
            }
        }

        private void ssc_Click(object sender, EventArgs e)
        {
            if (ssc.Checked)
            {
                EnableSniperScope();
            }
            else
            {
                DisableSniperScope();
            }
        }

        private void ss_Click(object sender, EventArgs e)
        {
            if (ss.Checked)
            {
                EnableSniperSwitch();
            }
            else
            {
                DisableSniperSwitch();
            }
        }

        private void chamsmenuv1_Click(object sender, EventArgs e)
        {
            if (chamsmenuv1.Checked)
            {
                InjectnormalChams();
            }
            else
            {

            }
        }

        private void chamsmenuv2_Click(object sender, EventArgs e)
        {
            if (chamsmenuv2.Checked)
            {
                startadvancedchams();
                ChamsMenuv1();
            }
            else
            {

            }
        }
        #endregion



        #region Main Commands

        #region AimbotHead
        private async void EnableAimbotDrag()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
                RedLib.OpenProcess(proc);
                //Applying
                ShowMessageBox("Enabling Aimbot", "activating", "");

                RedLib.OpenProcess(Convert.ToInt32(PID));
                IEnumerable<long> longs = await RedLib.AoBScan(0x0000000000010000, 0x00007ffffffeffff, "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF", true, true);

                if (longs == null)
                    Console.WriteLine("Only Work Ingame. No Entities Found");
                foreach (long num in longs)
                {
                    string str = num.ToString("X");

                    Console.WriteLine("Address Detection Complete Wait a While");
                    byte[] numArray = RedLib.AhReadMeFucker((num + 156L).ToString("X"), 4);
                    RedLib.WriteMemory((num + 108L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                //Sucess
                ShowMessageBox("Aimbot Enabled", "", "");
            }
        }
        private async void DisableAimbotDrag()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
                RedLib.OpenProcess(proc);
                //Applying
                ShowMessageBox("Enabling Aimbot", "activating", "");

                RedLib.OpenProcess(Convert.ToInt32(PID));
                IEnumerable<long> longs = await RedLib.AoBScan(0x0000000000010000, 0x00007ffffffeffff, "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF", true, true);

                if (longs == null)
                    Console.WriteLine("Only Work Ingame. No Entities Found");
                ShowMessageBox("Aimbot Error", "", "");
                foreach (long num in longs)
                {
                    string str = num.ToString("X");

                    Console.WriteLine("Address Detection Complete Wait a While");
                    byte[] numArray = RedLib.AhReadMeFucker((num + 108L).ToString("X"), 4);
                    RedLib.WriteMemory((num + 156L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                //Sucess
                ShowMessageBox("Aimbot Enabled", "", "");
            }
        }
        #endregion
        #region AimbotDrag
        private async void EnableAimbothead()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
                RedLib.OpenProcess(proc);
                //Applying
                ShowMessageBox("Enabling Aimbot", "activating", "");

                RedLib.OpenProcess(Convert.ToInt32(PID));
                //IEnumerable<long> longs = await RedLib.AoBScan(0x0000000000010000, 0x00007ffffffeffff, "00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF ?? ?? ?? ?? 00 00 00 00 00 00 ?? ?? 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00", true, true);
                IEnumerable<long> longs = await RedLib.AoBScan(65536L, 140737488289791L, "00 00 00 00 00 00 A5 43 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF", true, true);

                if (longs == null)
                    Console.WriteLine("Only Work Ingame. No Entities Found");
                foreach (long num in longs)
                {
                    string str = num.ToString("X");

                    Console.WriteLine("Address Detection Complete Wait a While");
                    byte[] numArray = RedLib.AhReadMeFucker((num + 92L).ToString("X"), 4);
                    RedLib.WriteMemory((num + 40L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                //Sucess
                ShowMessageBox("Aimbot Enabled", "", "");
            }
        }
        private async void DisableAimbothead()
        {
            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
                RedLib.OpenProcess(proc);
                //Applying
                ShowMessageBox("Enabling Aimbot", "activating", "");

                RedLib.OpenProcess(Convert.ToInt32(PID));
                //IEnumerable<long> longs = await RedLib.AoBScan(0x0000000000010000, 0x00007ffffffeffff, "00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF ?? ?? ?? ?? 00 00 00 00 00 00 ?? ?? 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00", true, true);
                IEnumerable<long> longs = await RedLib.AoBScan(65536L, 140737488289791L, "00 00 00 00 00 00 A5 43 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 BF", true, true);

                if (longs == null)
                    Console.WriteLine("Only Work Ingame. No Entities Found");
                foreach (long num in longs)
                {
                    string str = num.ToString("X");

                    Console.WriteLine("Address Detection Complete Wait a While");
                    byte[] numArray = RedLib.AhReadMeFucker((num + 40L).ToString("X"), 4);
                    RedLib.WriteMemory((num + 92L).ToString("X"), "int", BitConverter.ToInt32(numArray, 0).ToString());
                }
                //Sucess
                ShowMessageBox("Aimbot Disabled", "", "");
            }
        }
        #endregion
        private async void EnableSniperScope()
        {
            string search = "8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01";
            string replace = "8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 FF FF 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Enabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        private async void DisableSniperScope()
        {
            string search = "8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 FF FF 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01";
            string replace = "8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Disabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Disabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }




        private async void EnableSniperSwitch()
        {
            string search = "00 00 00 81 95 E3 3F 00 00 80 3F 00 00 80 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 90 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 3F 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00";
            string replace = "00 00 00 81 95 E3 3F 00 00 80 3F 00 00 80 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 90 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 2B 00 00 80 2B 00 00 00 00 04 00 00 00 00 00 80 3F 00";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Enabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        private async void DisableSniperSwitch()
        {
            string search = "00 00 00 81 95 E3 3F 00 00 80 3F 00 00 80 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 90 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 2B 00 00 80 2B 00 00 00 00 04 00 00 00 00 00 80 3F 00";
            string replace = "00 00 00 81 95 E3 3F 00 00 80 3F 00 00 80 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 90 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 3F 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Enabling", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Enabled", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        #region DLL INJECTION SYSTEM
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadLibraryA(string lpLibFileName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeLibrary(IntPtr hModule);

        const uint PROCESS_CREATE_THREAD = 0x2;
        const uint PROCESS_QUERY_INFORMATION = 0x400;
        const uint PROCESS_VM_OPERATION = 0x8;
        const uint PROCESS_VM_WRITE = 0x20;
        const uint PROCESS_VM_READ = 0x10;
        const uint MEM_COMMIT = 0x1000;
        const uint PAGE_READWRITE = 4;

        private static void inject(string resourceName, string outputPath)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            using (Stream resourceStream = executingAssembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                {
                    throw new ArgumentException($"Resource '{resourceName}' not found.");
                }
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
                {
                    byte[] buffer = new byte[resourceStream.Length];
                    resourceStream.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                }
            }
        }

        #endregion
        private void startadvancedchams()
        {
            string processName = "HD-Player";
            string glew = "BR_BASIC.Properties.glew32.dll";
            string glewpath = Path.Combine(Path.GetTempPath(), "glew32.dll");


            inject(glew, glewpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            if (chamsmenuv2.Checked)
            {
                IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)glewpath.Length, MEM_COMMIT, PAGE_READWRITE);
                IntPtr bytesWritten;
                WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(glewpath), (uint)glewpath.Length, out bytesWritten);
                IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

                if (hThread == IntPtr.Zero)
                {
                    //ShowMessageBox("Inject Failed", "failed", "");
                }
                else
                {
                    //ShowMessageBox("Injected", "", "");
                }
            }
        }
        private void ChamsMenuv1()
        {
            string processName = "HD-Player";
            string main = "BR_BASIC.Properties.menuoverlay.dll";
            string mainpath = Path.Combine(Path.GetTempPath(), "menuoverlay.dll");


            inject(main, mainpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            if (chamsmenuv2.Checked)
            {
                IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)mainpath.Length, MEM_COMMIT, PAGE_READWRITE);
                IntPtr bytesWritten;
                WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(mainpath), (uint)mainpath.Length, out bytesWritten);
                IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

                if (hThread == IntPtr.Zero)
                {
                    ShowMessageBox("Inject Failed", "failed", "");
                }
                else
                {
                    ShowMessageBox("Injected", "", "");
                }
            }
        }
        private void InjectnormalChams()
        {
            string processName = "HD-Player";
            string main = "BR_BASIC.Properties.menunormal.dll";
            string mainpath = Path.Combine(Path.GetTempPath(), "menunormal.dll");


            inject(main, mainpath);

            Process[] targetProcesses = Process.GetProcessesByName(processName);
            if (targetProcesses.Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
                return;
            }

            Process targetProcess = targetProcesses[0];
            IntPtr hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            if (hProcess == IntPtr.Zero)
            {
                ShowMessageBox("Process Failure", "failed", "");
                return;
            }
            if (chamsmenuv1.Checked)
            {
                IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)mainpath.Length, MEM_COMMIT, PAGE_READWRITE);
                IntPtr bytesWritten;
                WriteProcessMemory(hProcess, allocMemAddress, System.Text.Encoding.ASCII.GetBytes(mainpath), (uint)mainpath.Length, out bytesWritten);
                IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, IntPtr.Zero, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);

                if (hThread == IntPtr.Zero)
                {
                    ShowMessageBox("Inject Failed", "failed", "");
                }
                else
                {
                    ShowMessageBox("Injected", "", "");
                }
            }
        }
        private async void ResetGuest()
        {
            string search = "10 4C 2D E9 08 B0 8D E2 0C 01 9F E5 00 00 8F E0";
            string replace = "01 00 A0 E3 1E FF 2F E1";
            bool k = false;

            if (Process.GetProcessesByName("HD-Player").Length == 0)
            {
                ShowMessageBox("Open Emulator", "failed", "");
            }
            else
            {
                bruuuh.OpenProcess("HD-Player");
                ShowMessageBox("Resetting", "activating", "");
                int i2 = 22000000;
                IEnumerable<long> wl = await bruuuh.AoBScan(search, writable: true);
                string u = "0x" + wl.FirstOrDefault().ToString("X");
                if (wl.Count() != 0)
                {
                    for (int i = 0; i < wl.Count(); i++)
                    {
                        i2++;
                        bruuuh.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                    }
                    k = true;
                }

                if (k == true)
                {
                    ShowMessageBox("Resetted", "sucess", "");
                }
                else
                {
                    ShowMessageBox("Error Occured", "failed", "");
                }
            }
        }
        private void DiscordRPCMode()
        {
            if (dcrpc.Checked)
            {
                RichStatus.DisconnectRPC();
                ShowMessageBox("Discord RPC Disabled", "sucess", "");
            }
            else
            {
                RichStatus.rpctimestamp = Timestamps.Now;
                RichStatus.InitializeRPC();
                ShowMessageBox("Discord RPC Enabled", "sucess", "");
            }
        }
        #endregion

        private void loadall_Click(object sender, EventArgs e)
        {
            
        }

        private void basic_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private static DateTime UnixTimeToDateTime(long unixTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return unixStart.AddSeconds(unixTime).ToLocalTime();
        }
        private void basic_Load(object sender, EventArgs e)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKey))
            {
                if (key != null)
                {
                    object storedState = key.GetValue(strmstate, 0);

                    streammode.Checked = (storedState.ToString() == "1");
                }
            }
            RichStatus.rpctimestamp = Timestamps.Now;
            RichStatus.InitializeRPC();
            if (login.KeyAuthApp.user_data != null)
            {
                string username = login.KeyAuthApp.user_data.username;
                DateTime expiryDateTime = UnixTimeToDateTime(long.Parse(login.KeyAuthApp.user_data.subscriptions[0].expiry));
            }
        }

        private void guna2CustomCheckBox1_Click(object sender, EventArgs e)
        {
            if (guest.Checked)
            {
                ResetGuest();
            }
        }

        private void dcrpc_Click(object sender, EventArgs e)
        {
            DiscordRPCMode();
        }

        private void savestate_CheckedChanged(object sender, EventArgs e)
        {
            if (savestate.Checked)
            {
                int checkboxState = streammode.Checked ? 1 : 0;

                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(registryKey))
                {
                    if (key != null)
                    {
                        key.SetValue(strmstate, checkboxState);
                    }
                }
            }
        }
    }
}
