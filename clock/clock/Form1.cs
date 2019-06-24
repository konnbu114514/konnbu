using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            this.FormBorderStyle = FormBorderStyle.None;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;


            InitializeComponent();



            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.stretchToFit = true;


            this.StartPosition = FormStartPosition.Manual;
            this.DesktopLocation = new Point(1100, 400);







            //ファイルオープン
            string appPath = System.Windows.Forms.Application.StartupPath;


            string fileName = appPath + @"\clock.mp4";
            if (System.IO.File.Exists(fileName))
            {
                axWindowsMediaPlayer1.URL = appPath + @"\clock.mp4";
            }
            else
            {
                MessageBox.Show(fileName + "clock.mp4 がありません確認してください");
                Application.Exit();
            }

            axWindowsMediaPlayer1.settings.setMode("loop", true);

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            label1.Text = d.Hour + ":" + d.Minute + ":" + d.Second;



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

            this.TopMost = !this.TopMost;


        }

        [SecurityPermission(SecurityAction.Demand,
    Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const long SC_MOVE = 0xF010L;

            if (m.Msg == WM_SYSCOMMAND &&
                (m.WParam.ToInt64() & 0xFFF0L) == SC_MOVE)
            {
                m.Result = IntPtr.Zero;
                return;
            }

            base.WndProc(ref m);
        }

    }

  
}


