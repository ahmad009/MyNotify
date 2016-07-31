using Animation;
using MyNotify.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MyNotify
{
    public partial class frmNotify : Form
    {
        private Color successBg = Color.FromArgb(67, 172, 106);
        private Color infoBg = Color.FromArgb(91, 192, 222);
        private Color warningBg = Color.FromArgb(233, 144, 2);
        private Color errorBg = Color.FromArgb(240, 65, 36);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        //nope. fix later
        /*protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }*/

        public frmNotify(string Title, string Message, int Icon)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            NotifyShow(Icon, Title, Message);
        }

        public void NotifyShow(int type, string title, string message)
        {
            switch (type)
            {
                case 0:
                {
                    BackColor = successBg;
                    icon.Image = Resources.icon_success;
                    break;
                }
                case 1:
                {
                    BackColor = infoBg;
                    icon.Image = Resources.icon_info;
                    break;
                }
                case 2:
                {
                    BackColor = warningBg;
                    icon.Image = Resources.icon_warning;
                    break;
                }
                case 3:
                {
                    BackColor = errorBg;
                    icon.Image = Resources.icon_error;
                    break;
                }
                default:
                {
                    BackColor = successBg;
                    break;
                }
            }

            SoundPlayer audio = new SoundPlayer(Resources.Error);
            audio.Play();

            Title_lbl.Text = title;
            Message_lbl.Text = message;
            Opacity = 1;
            hideTimer.Stop();
            hideTimer.Start();
        }

        public void Fade(double opacity)
        {
            double toFade = this.Opacity - opacity;
            while (Math.Abs(this.Opacity - opacity) > 0.01)
            {
                this.Opacity -= toFade / 50;
                Application.DoEvents();
                System.Threading.Thread.Sleep(10);
            }

            Notify.NotifyForms.Remove(this);
        }

        private void hideTimer_Tick(object sender, EventArgs e)
        {
            Fade(0);
            hideTimer.Stop();
        }

        private void frmNotify_Load(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 10, Screen.PrimaryScreen.WorkingArea.Height - Height - 50);
            MaximumSize = Size;
            MinimumSize = Size;

            int height = 0;
            if (Notify.NotifyForms.Count != 0)
            {
                foreach (frmNotify notifyForm in Notify.NotifyForms)
                {
                    height = height + notifyForm.Height + 10;
                }
            }

            Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - 10, Screen.PrimaryScreen.WorkingArea.Height - Height - 10 - height);
            ControlAnimation.HorizontalMove(this, Screen.PrimaryScreen.WorkingArea.Width - base.Width - 10, 500, AnimationType.Resilience);

            hideTimer.Start();
        }
    }
}
