using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;

namespace start
{
    public partial class Form1 : Form
    {
        bool ConnectGoogleTW()
        {
            //Google網址
            string googleTW = "www.google.tw";
            //Ping網站
            Ping p = new Ping();
            //網站的回覆
            PingReply reply;

            try
            {
                //取得網站的回覆
                reply = p.Send(googleTW);
                //如果回覆的狀態為Success則return true
                if (reply.Status == IPStatus.Success) { return true; }

            }

            //catch這裡的Exception, 是有可能網站當下的某某狀況造成, 可以直接讓它傳回false.
            //或在重覆try{}裡的動作一次
            catch { return false; }

            //如果reply.Status !=IPStatus.Success, 直接回傳false
            return false;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*label1.Text = "確認連線...";
            while (ConnectGoogleTW() != true)
            {
                
                
            }*/

            label1.Text = "等60秒...";
            Thread.Sleep(60000);

            label1.Text = "開啟Battle.net...";
            ProcessStartInfo open_2 = new ProcessStartInfo();
            open_2.FileName = "Battle.net Launcher.exe"; // 檔案名稱
            open_2.WorkingDirectory = @"D:\BZ\Battle.net"; // 資料夾路徑
            Process.Start(open_2);

            label1.Text = "開啟LINE...";
            ProcessStartInfo open_1 = new ProcessStartInfo();
            open_1.FileName = "LINE.exe"; // 檔案名稱
            open_1.WorkingDirectory = @"C:\Program Files (x86)\LINE"; // 資料夾路徑
            Process.Start(open_1);

            label1.Text = "就緒";

            this.Close();
            Environment.Exit(Environment.ExitCode);

            InitializeComponent();
        }

    }
}
