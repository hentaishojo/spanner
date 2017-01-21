using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Text.RegularExpressions;

namespace TradeAdvisor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Initialize_Form();
        }

        private void Initialize_Form()
        {
            this.Text = "TradeAdvisor";
            this.WindowState = FormWindowState.Maximized;

            StatusStrip ss = new StatusStrip();
            ToolStripStatusLabel tsl = new ToolStripStatusLabel();
            ToolStripItem[] tsi = new ToolStripItem[1];
            tsi[0] = tsl;
            tsl.Text = "Ready!";
            ss.Items.AddRange(tsi);
            this.Controls.Add(ss);

            TabControl Main_tc = new TabControl();
            Main_tc.Dock = DockStyle.Fill;
            this.Controls.Add(Main_tc);

            TabPage tb_g = new TabPage("General");
            tb_g.Dock = DockStyle.Fill;
            Main_tc.TabPages.Add(tb_g);


            Label lb1 = new Label();
            lb1.Location = new Point(15, 20);
            lb1.Text = "Version: 0.1";
            lb1.Size = new Size(500, 15);
            Label lb2 = new Label();
            lb2.Location = new Point(15, 60);
            lb2.Text = "DateTime: 2016/04/30 15:00";
            lb2.Size = new Size(500, 15);
            Label lb3 = new Label();
            lb3.Location = new Point(15, 100);
            lb3.Text = "Craft by Liao";
            lb3.Size = new Size(500, 15);
            tb_g.Controls.Add(lb1);
            tb_g.Controls.Add(lb2);
            tb_g.Controls.Add(lb3);

            if (File.Exists("./TA_param.txt") == true)
            {
                string[] lines_param = File.ReadAllLines("./TA_param.txt");
                for (int i = 0; i < lines_param.Length; i++)
                {
                    string[] temp_str = Regex.Split(lines_param[i], ",");
                    Stocks tb_s = new Stocks(Main_tc, Convert.ToInt32(temp_str[0]),
                                    Convert.ToInt32(temp_str[1]), Convert.ToInt32(temp_str[2]), Convert.ToInt32(temp_str[3]),
                                    Convert.ToInt32(temp_str[4]),
                                    Convert.ToInt32(temp_str[5]), Convert.ToInt32(temp_str[6]), Convert.ToInt32(temp_str[7]));
                    try
                    {
                        
                    }
                    catch
                    {
                        tsl.Text = "Param error";
                    }
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText("./TA_param.txt"))
                {
                    tsl.Text = "Can't found TA_param.txt, make a example file automatically. Please restart this program!";
                    sw.WriteLine("5289,10,20,60,20,6,12,24");
                }
            }
        }
       
    }
}
