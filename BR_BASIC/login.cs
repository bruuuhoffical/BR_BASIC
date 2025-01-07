using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyAuth;
using Microsoft.Win32;

namespace BR_BASIC
{
    public partial class login : Form
    {
        private ParticleSystem particleSystem;
        private const string registryKey = @"Software\BRUUUH_BASIC";
        private const string usernameValue = "Username";
        private const string passwordValue = "Password";
        private const string autofillValue = "Autofill";
        private List<MessageBoxControl> _messageBoxes;
        private static int activeMessageBoxes = 0;
        private static int lastMessageBoxY = 0;
        private MessageBoxControl _messageBox;
        public login()
        {
            InitializeComponent();
            KeyAuthApp.init();
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
        }
        public static api KeyAuthApp = new api(
        name: "BRUUUH BASIC",
        ownerid: "3jC6RTlK0L",
        version: "1.1"
);
        private void kill_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #region AutoFill
        private void SaveToRegistry(string username, string password)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(registryKey))
                {
                    key.SetValue(usernameValue, username);
                    key.SetValue(passwordValue, password);
                    key.SetValue(autofillValue, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to registry: " + ex.Message);
            }
        }

        private string GetFromRegistry(string valueName)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKey))
                {
                    if (key != null && key.GetValue(valueName) != null)
                    {
                        return key.GetValue(valueName).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading from registry: " + ex.Message);
            }

            return string.Empty;
        }

        private bool IsAutofillEnabled()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKey))
                {
                    if (key != null && key.GetValue(autofillValue) != null)
                    {
                        return Convert.ToBoolean(key.GetValue(autofillValue));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking registry value: " + ex.Message);
            }

            return false;
        }
        #endregion
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

            // Pass the correct status color (message status determines the color)
            messageBox.ShowMessage(message, status, imageKey, baseColor);

            activeMessageBoxes++;

            Timer timer = new Timer { Interval = 5000 }; // Duration for how long the message is visible
            timer.Tick += (sender, e) =>
            {
                messageBox.HideMessage(); // Hide the message after the timer ends
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
        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void particles_Tick(object sender, EventArgs e)
        {
            particleSystem.UpdateParticles();
            Invalidate();
        }

        private void login_Load(object sender, EventArgs e)
        {
            ShowMessageBox("Welcome", "", "");
            autofill.Focus();
            if (IsAutofillEnabled())
            {
                username.Text = GetFromRegistry(usernameValue);
                password.Text = GetFromRegistry(passwordValue);
            }
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(username.Text, password.Text);
            if (KeyAuthApp.response.success)
            {
                if (autofill.Checked)
                {
                    SaveToRegistry(username.Text, password.Text);
                }
                basic BRUUUH = new basic();
                BRUUUH.Show();
                this.Hide();
            }
            else
            {
                ShowMessageBox("Error", "failed", "failed");
            }
            loginbtn.Focus();
        }
    }
}
