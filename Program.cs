using System;
using System.Windows.Forms;

namespace WeekNumberTray
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new WeekNumberTrayApp());
        }
    }
}
