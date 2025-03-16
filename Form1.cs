using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Windows.Forms;

namespace WeekNumberTray
{
    public class WeekNumberTrayApp : Form
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private Timer updateTimer;

        public WeekNumberTrayApp()
        {
            this.WindowState = FormWindowState.Minimized; 
            this.ShowInTaskbar = false; 
            this.FormBorderStyle = FormBorderStyle.None; 
            this.Visible = false;

            trayIcon = new NotifyIcon
            {
                Visible = true
            };

            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Exit", null, OnExit);
            trayIcon.ContextMenuStrip = trayMenu;

            updateTimer = new Timer { Interval = 60000 };
            updateTimer.Tick += UpdateWeekNumber;
            updateTimer.Start();

            UpdateWeekNumber(null, null);
        }

        private void UpdateWeekNumber(object sender, EventArgs e)
        {
            int weekNumber = GetWeekNumber(DateTime.Now);

            trayIcon.Icon = GenerateIcon(weekNumber);
        }

        private int GetWeekNumber(DateTime date)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private Icon GenerateIcon(int number)
        {
            int size = 32;
            using (Bitmap bitmap = new Bitmap(size, size))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.FillRectangle(Brushes.White, 0, 0, size, size);
                g.DrawRectangle(Pens.Black, 0, 0, size - 1, size - 1);

                using (Font font = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel))
                using (StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    g.DrawString(number.ToString(), font, Brushes.Black, new RectangleF(0, 0, size, size), format);
                }

                return Icon.FromHandle(bitmap.GetHicon());
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            updateTimer?.Stop();
            updateTimer?.Dispose();
            trayIcon.Visible = false;
            trayIcon.Dispose();
            trayMenu.Dispose();
            Application.Exit();
        }


    }
}