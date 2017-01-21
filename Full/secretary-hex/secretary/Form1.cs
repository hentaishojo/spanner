using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;
using System.Media;
using System.Drawing.Imaging;
using System.Net;

namespace secretary
{
    public partial class Form1 : Form
    {
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;
        //private bool eng_flag=false;
        private int ques_num = 0;
        private int ques_type = 0;
        private string note_clone;
        private string[,] default_param = new string[4,2] {{"Window_Pos_X","0"},
                                                           {"Window_Pos_Y","0"},
                                                           {"WiFi_btn_enable","0"},
                                                           {"English_Module","0"}};
        private string[] eng_pool;
        private Dictionary<string, int> eng_wrong = new Dictionary<string, int>();
        private int[] winrate = {0,0};
        //DriveService service;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        public Form1()
        {
            InitializeComponent();
            this.notifyIcon = notifyIcon1;
            this.notifyIcon.Icon = this.Icon;
            this.notifyIcon.Text = "secretary";
            this.ShowInTaskbar = false;
            this.notifyIcon.Visible = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            check_data_param();
            
            HotKey.RegisterHotKey(Handle, 103, HotKey.KeyModifiers.None, Keys.PrintScreen);
            HotKey.RegisterHotKey(Handle, 104, HotKey.KeyModifiers.Ctrl, Keys.F9);
            //HotKey.RegisterHotKey(Handle, 103, HotKey.KeyModifiers.Ctrl, Keys.F10);
            HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.Ctrl, Keys.F11);
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.Ctrl, Keys.F12);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 105://F8
                            
                            break;

                        case 104:
                            show_hide();
                            break;

                        case 103:
                            print_screen();
                            break;

                        case 102:
                            sys_vol_up();
                            break;

                        case 101://F12
                            sys_vol_down();
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }
        
        private void show_hide()
        {
            if (this.Visible == false)
            {
                this.Visible = true;
            }
            else
            {
                this.Visible = false;
            }
            tabControl1.Enabled = false;
            tabControl1.SelectTab("tabPage1");
            tabControl1.Enabled = true;
        }
        private void print_screen()
        {
            string filder = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            for(int i =0;i<Screen.AllScreens.Length;i++)
            {
                var bmpScreenshot = new Bitmap(Screen.AllScreens[i].Bounds.Width,
                               Screen.AllScreens[i].Bounds.Height,
                               PixelFormat.Format32bppArgb);

                var gfxScreenshot = Graphics.FromImage(bmpScreenshot);

                gfxScreenshot.CopyFromScreen(Screen.AllScreens[i].Bounds.X,
                                            Screen.AllScreens[i].Bounds.Y,
                                            0,
                                            0,
                                            Screen.AllScreens[i].Bounds.Size,
                                            CopyPixelOperation.SourceCopy);

                if(Screen.AllScreens.Length==1)
                {
                    bmpScreenshot.Save(filder + "\\" + DateTime.Now.ToString("yyyyMMdd-hmmss") + ".png", ImageFormat.Png);
                }
                else
                {
                    bmpScreenshot.Save(filder + "\\" + DateTime.Now.ToString("yyyyMMdd-hmmss-") + i.ToString() + ".png", ImageFormat.Png);
                }
                
            }
            
        }
        private void sys_vol_up()
        {
            for (int i = 1; i <= 5; i++)
            {
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
            }
            tabControl1.Enabled = false;
            tabControl1.SelectTab("tabPage1");
            tabControl1.Enabled = true;
        }
        private void sys_vol_down()
        {
            for (int i = 1; i <= 5; i++)
            {
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_DOWN);
            }
            tabControl1.Enabled = false;
            tabControl1.SelectTab("tabPage1");
            tabControl1.Enabled = true;
        }
        private void check_data_param()
        {
            if (File.Exists("./secretary_param.txt") == true)
            {
                string[] lines_param = File.ReadAllLines("./secretary_param.txt");
                for (int i = 0; i < lines_param.Length; i++)
                {
                    string[] temp_str = Regex.Split(lines_param[i], "=");
                    try
                    {
                        input_param(temp_str[0], temp_str[1], i + 1);
                    }
                    catch
                    {
                        toolStripStatusLabel1.Text = "param error in line " + (i + 1).ToString() + ": " + lines_param[i];
                    }
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText("./secretary_param.txt"))
                {
                    for (int i = 0; i < default_param.GetLength(0); i++)
                    {
                        sw.WriteLine(default_param[i, 0] + "=" + default_param[i, 1]);
                    }
                    toolStripStatusLabel1.Text = "secretary_param.txt can not be found, create one";
                }
            }

            if (File.Exists("./secretary_data.txt") == true)
            {
                using (StreamReader sr = new StreamReader("./secretary_data.txt", System.Text.Encoding.UTF8))
                {
                    textBox1.Text = sr.ReadToEnd();
                    note_clone = textBox1.Text;
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText("./secretary_data.txt"))
                {
                    sw.WriteLine(" ");
                    toolStripStatusLabel1.Text = "secretary_param.txt can not be found, create new one.";
                }
            }
        }
        private void input_param(string param_id, string param_value, int order)
        {
            
            if (param_id == default_param[0, 0])
            {
                try
                {
                    this.Location = new Point(Convert.ToInt32(param_value), 0);
                }
                catch
                {
                    this.Location = new Point(Convert.ToInt32(default_param[0, 1]), 0); 
                    toolStripStatusLabel1.Text = default_param[0, 0]+" can not be phrased";
                }
            }
            else if (param_id == default_param[1, 0])
            {
                try
                {
                    this.Location = new Point(this.Location.X, Convert.ToInt32(param_value));
                }
                catch
                {
                    this.Location = new Point(this.Location.X, Convert.ToInt32(default_param[1, 1])); 
                    toolStripStatusLabel1.Text = default_param[1, 0] + " can not be phrased";
                }
            }
            else if (param_id == default_param[2, 0])
            {
                try
                {
                    if(Convert.ToInt32(param_value)==1)
                    {
                        this.button_wifi.Enabled = true;
                    }
                }
                catch
                {
                    this.button_wifi.Enabled = Convert.ToBoolean(default_param[2, 1]);
                    toolStripStatusLabel1.Text = default_param[2, 0] + " can not be phrased";
                }
            }
            else if (param_id == default_param[3, 0])
            {
                try
                {
                    if (Convert.ToInt32(param_value) == 1)
                    {
                        if (File.Exists("./eng_pool.txt"))
                        {
                            eng_initial();
                        }
                    }
                }
                catch
                {
                    this.button_wifi.Enabled = Convert.ToBoolean(default_param[3, 1]);
                    toolStripStatusLabel1.Text = default_param[3, 0] + " can not be phrased";
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "param error in line " + order.ToString() + ": " + param_id;
            }
        }
        private void eng_initial()
        {
            eng_pool = File.ReadAllLines("./eng_pool.txt", Encoding.UTF8);
            Random rnd = new Random();

            //using (StreamWriter sw = File.CreateText("./eng_tr.txt"))
            //{
            //    for (int i = 0; i < eng_pool.Length; i++)
            //    {
            //        //if (eng_pool[i].Contains("@"))
            //        //{
            //        //    if (eng_pool[i][0] != '@')
            //        //    {
            //        //        if (eng_pool[i][5] == ' ')
            //        //        {
            //        //            string temp = eng_pool[i].Substring(6);
            //        //            sw.WriteLine(temp, Encoding.UTF8);
            //        //        }
            //        //        if (eng_pool[i][7] == ' ')
            //        //        {
            //        //            string temp = eng_pool[i].Substring(8);
            //        //            sw.WriteLine(temp, Encoding.UTF8);
            //        //        }
            //        //    }
            //        //} // pick up contains "@" && remove number

            //        //if (eng_pool[i][0] == ' ')
            //        //{
            //        //    string temp = eng_pool[i].Substring(1);
            //        //    sw.WriteLine(temp, Encoding.UTF8);
            //        //}
            //        //else
            //        //{
            //        //    sw.WriteLine(eng_pool[i], Encoding.UTF8);
            //        //} //start with " "

            //        //if (eng_pool[i][eng_pool[i].Length - 1] != '@')
            //        //{
            //        //    sw.WriteLine(eng_pool[i], Encoding.UTF8);
            //        //} //end with "@"

            //        //if (!eng_pool[i].Contains("縮寫"))
            //        //{
            //        //    sw.WriteLine(eng_pool[i], Encoding.UTF8);
            //        //} //contain "縮寫"

            //        if (eng_pool[i][eng_pool[i].Length - 1] == ')')
            //        {
            //            int count = 0;
            //            foreach (char c in eng_pool[i])
            //            {
            //                if(c==')')
            //                    count++;
            //            }
            //            if(count>1)
            //                sw.WriteLine(eng_pool[i], Encoding.UTF8);
            //        }
            //        else
            //        {
            //            sw.WriteLine(eng_pool[i], Encoding.UTF8);
            //        } //end with ")" && only one ")"
            //    }
            //} // filter

            //using (StreamWriter sw = File.CreateText("./eng_tr.txt"))
            //{
            //    for (int i = 0; i < eng_pool.Length; i++)
            //    {
            //        sw.WriteLine(eng_pool[i].Split('@')[0] + "@[" + eng_pool[i].Split('@')[0].Length.ToString() + "]" + eng_pool[i].Split('@')[1], Encoding.UTF8);
            //    }
            //} // calculate string length

            //using (StreamWriter sw = File.CreateText("./eng_tr.txt"))
            //{
            //    for (int i = 0; i < eng_pool.Length; i++)
            //    {
            //        sw.WriteLine("\""+eng_pool[i]+"\",", Encoding.UTF8);
            //    }
            //} // for android

            if (File.Exists("./eng_wrong.txt"))
            {
                string[] wrong = File.ReadAllLines("./eng_wrong.txt", Encoding.UTF8);
                for(int i =0; i<wrong.Length;i++)
                {
                    eng_wrong.Add(wrong[i],2);
                }
                
            }

            btn_eng_ent.Enabled = true;
            next_question();
        }
        private void next_question()
        {
            Random rnd = new Random();

            if(rnd.Next(1,5)>3 && eng_wrong.Count>1)
            {
                ques_type = 1;
                ques_num = rnd.Next(0, eng_wrong.Count);
                label_Q.Text = eng_wrong.ElementAt(ques_num).Key.Split('@')[1]+" (曾經錯過)";
            }
            else
            {
                ques_type = 0;
                ques_num = rnd.Next(0, eng_pool.Length);
                label_Q.Text = eng_pool[ques_num].Split('@')[1];
            }

            

            //question = eng_chosen[Ques_flag].Split('@', ')')[0] + eng_chosen[Ques_flag].Split('@', ')')[1];
            
            /* ques_type
             * 1. CH_t -> EN_t
             * 2. EN_t -> CH_t
             * 3. EN_s -> EN_t
             */

            
        }
        private void btn_eng_ent_Click(object sender, EventArgs e)
        {
            check_answer();
        }
        private void key_eng_ent_down(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                check_answer();
            }
        }
        private void check_answer()
        {
            if (ques_type == 1)
            {
                string answer = eng_wrong.ElementAt(ques_num).Key.Split('@')[0];

                if (textBox_eng_ans.Text.Contains(answer))
                {
                    label_A.Text = eng_wrong.ElementAt(ques_num).Key + ",    Correct!";
                    textBox_eng_ans.Text = "";
                    if (eng_wrong.ElementAt(ques_num).Value > 1)
                    {
                        eng_wrong[eng_wrong.ElementAt(ques_num).Key]--;
                    }
                    else
                    {
                        eng_wrong.Remove(eng_wrong.ElementAt(ques_num).Key);
                    }
                    next_question();
                    winrate[0]++;
                }
                else
                {
                    label_A.Text = "You: " + textBox_eng_ans.Text + "!,    Ans: " + answer;
                    textBox_eng_ans.Text = "";
                    winrate[1]++;
                }

                if(winrate[0]+winrate[1]<5)
                {
                    label_R.Text = "?% - (" + winrate[0].ToString() + "/" + winrate[1].ToString() + ")";
                }
                else
                {
                    label_R.Text = (100*winrate[0] / (winrate[0] + winrate[1])).ToString() + "% - (" + winrate[0].ToString() + "/" + winrate[1].ToString() + ")";
                }
                
            }
            else
            {
                string answer = eng_pool[ques_num].Split('@')[0];

                if (textBox_eng_ans.Text.Contains(answer))
                {
                    label_A.Text = eng_pool[ques_num] + ",    Correct!";
                    textBox_eng_ans.Text = "";
                    next_question();
                    winrate[0]++;
                }
                else
                {
                    label_A.Text = "You: " + textBox_eng_ans.Text + ",    Ans: " + answer;
                    textBox_eng_ans.Text = "";
                    winrate[1]++;
                    try
                    {
                        eng_wrong.First(x => x.Key == eng_pool[ques_num]);
                        eng_wrong[eng_pool[ques_num]]++;
                    }
                    catch
                    {
                        eng_wrong.Add(eng_pool[ques_num], 2);
                    }
                    
                }

                if (winrate[0] + winrate[1] < 5)
                {
                    label_R.Text = "?% - (" + winrate[0].ToString() + "/" + winrate[1].ToString() + ")";
                }
                else
                {
                    label_R.Text = (100 * winrate[0] / (winrate[0] + winrate[1])).ToString() + "% - (" + winrate[0].ToString() + "/" + winrate[1].ToString() + ")";
                }
            }

        }
        private void button_pw_Click(object sender, EventArgs e)
        {
            try
            {
                Process PW_txt = new Process();
                PW_txt.StartInfo.FileName = "PW.txt";
                PW_txt.Start();
                tabControl1.Enabled = false;
                tabControl1.SelectTab("tabPage1");
                tabControl1.Enabled = true;
            }
            catch
            {
                using (StreamWriter sw = File.CreateText("PW.txt"))
                {
                    sw.WriteLine(" ");
                    toolStripStatusLabel1.Text = "PW.txt can not be found, create new one.";
                }
            }
        }
        private void button_wifi_Click(object sender, EventArgs e)
        {
            try
            {
                Process Wifi_on = new Process();
                Wifi_on.StartInfo.FileName = "netsh wlan start hostednetwork";
                Wifi_on.Start();
                toolStripStatusLabel1.Text = "Wifi Started!";
                tabControl1.Enabled = false;
                tabControl1.SelectTab("tabPage1");
                tabControl1.Enabled = true;
            }
            catch
            {
                toolStripStatusLabel1.Text = "Wifi failed!";
            }
        }
        private void write_data()
        {
            
            toolStripStatusLabel1.Text = "Note saving...";
            using (FileStream fs = new FileStream("./secretary_data.txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(textBox1.Text);
                }
            }
            
            Task.Factory.StartNew(() =>
            {
                SpinWait.SpinUntil(() => false, 1000);
                toolStripStatusLabel1.Text = "Note saved!";
            });
            
        }
        private void write_eng()
        {
            using (StreamWriter sw = File.CreateText("./eng_wrong.txt"))
            {
                foreach(KeyValuePair<string, int> ques in eng_wrong)
                {
                    if (ques.Key != null && ques.Key != "")
                        sw.WriteLine(ques.Key, Encoding.UTF8);
                }
            }
            //using (StreamWriter sw = File.CreateText("./eng_pool.txt"))
            //{
            //    for (int i = 0; i < eng_pool.Length;i++ )
            //    {
            //        if (eng_pool[i] != null && eng_pool[i]!= "")
            //            sw.WriteLine(eng_pool[i], Encoding.UTF8);
            //    }
            //}
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text != note_clone)
            {
                write_data();
                
                note_clone = textBox1.Text;
            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (textBox1.Text != note_clone)
            {
                write_data();
                
                note_clone = textBox1.Text;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {   
            if (textBox1.Text != note_clone)
            {
                write_data();
                
                note_clone = textBox1.Text;
            }
            write_eng();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }


        //////////////////////////////////////////////////////////// useless zone////////////////////////////////////////////////////////////
        private void rasdial()
        {
            Task.Factory.StartNew(() =>
            {
                SpinWait.SpinUntil(() => false, 30000);
                toolStripStatusLabel1.Text = "rasdial completed!";
                Process myProcess = new Process();
                ProcessStartInfo Adsl = new ProcessStartInfo();
                Adsl.FileName = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"/rasdial.exe ";
                myProcess.StartInfo = Adsl;
                Adsl.Arguments = "寬頻連線 75809388@hinet.net pqirqauh";
                myProcess.Start();
                myProcess.WaitForExit();

                ProcessStartInfo Line = new ProcessStartInfo();
                Line.FileName = @"C:\Users\liao8\AppData\Local\LINE\bin\LineLauncher.exe";
                myProcess.StartInfo = Line;
                myProcess.Start();

                SyncNoteDown();
            });
        }
        private void SyncNoteDown()
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    string downFtpData = DownFtpData();
                    ClearFtpData();
                    this.Invoke((MethodInvoker)delegate()
                    {
                        textBox1.Text = textBox1.Text + "\n" + downFtpData;
                        note_clone = textBox1.Text;
                        write_data();
                    });
                });
            }
            catch { }
        }


        private string DownFtpData()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://a4225599@server27.000webhost.com/%2F/SyncNote/secretary_data.txt");
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            request.Credentials = new NetworkCredential("a4225599", "s9951111");

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string re = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return re;
        }

        private void ClearFtpData()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://a4225599@server27.000webhost.com/%2F/SyncNote/secretary_data.txt");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential("a4225599", "s9951111");

            byte[] fileContents = Encoding.UTF8.GetBytes("");
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
        }
    }
}
