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
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace TradeAdvisor
{
    class Tabs_d
    {
        private TabPage tb = new TabPage();
        private Chart chart = new Chart();
        private ChartArea chartArea_K = new ChartArea("CA_Price");
        private ChartArea chartArea_Vol = new ChartArea("CA_Vol");
        private ChartArea chartArea_KD = new ChartArea("CA_KD");
        private ChartArea chartArea_MACD = new ChartArea("CA_MACD");
        private Series series0 = new Series();
        private Series series1 = new Series();
        private Series series2 = new Series();
        private Series series3 = new Series();
        private Series series4 = new Series();
        private Series series5 = new Series();
        private Series series6 = new Series();
        private Series series7 = new Series();
        private Series series8 = new Series();
        private Series series9 = new Series();
        private NumericUpDown nud1 = new NumericUpDown();
        private NumericUpDown nud2 = new NumericUpDown();
        private NumericUpDown nud3 = new NumericUpDown();
        private NumericUpDown nud4 = new NumericUpDown();
        private ToolTip Tt = new ToolTip();
        private int scroll_blockSize = 0;
        private double dou_temp;
        private double dou_temp_2;
        string[] str_set;
        double[,] val_set;
        double[] RSV;
        double[] KD_K;
        double[] KD_D;
        double[] EMA_12;
        double[] EMA_26;
        double[] MACD;
        double pX=0;


        public Tabs_d(TabControl tc, string[] str_set, double[,] data_set, int s_MA, int m_MA, int l_MA)
	    {
            this.str_set = str_set;
            this.val_set = data_set;
            RSV = new double[str_set.Length];
            KD_K = new double[str_set.Length];
            KD_D = new double[str_set.Length];
            EMA_12 = new double[str_set.Length];
            EMA_26 = new double[str_set.Length];
            MACD = new double[str_set.Length];
		    chart_initial(tc, s_MA, m_MA, l_MA);
		    charting(Convert.ToInt32(nud1.Value), Convert.ToInt32(nud2.Value), Convert.ToInt32(nud3.Value));
	    }

        private void chart_initial(TabControl tc, int s_MA, int m_MA, int l_MA)
        {
            int j;

            tb.Name = "Day";
            tb.Text = "Day";
            tb.Dock = DockStyle.Fill;
            tc.TabPages.Add(tb);

            chart.Size = new Size(1500, 1000);

            chartArea_K.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea_K.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea_K.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_K.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_K.BackColor = System.Drawing.Color.Black;
            chartArea_K.AxisX.Minimum = 0;
            chartArea_K.AxisX.Maximum = str_set.Length;
            chartArea_K.CursorX.AutoScroll = true;
            chartArea_K.AxisX.ScaleView.Zoomable = true;
            chartArea_K.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            chartArea_K.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartArea_K.AxisX.ScrollBar.BackColor = Color.DarkGray;
            chartArea_K.AxisX.ScrollBar.ButtonColor = Color.LightGray;
            chartArea_K.Position.X = 0;
            chartArea_K.Position.Y = 0;
            chartArea_K.Position.Width = 100;
            chartArea_K.Position.Height = 55;
            chart.ChartAreas.Add(chartArea_K);

            chartArea_Vol.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea_Vol.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea_Vol.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_Vol.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_Vol.BackColor = System.Drawing.Color.Black;
            chartArea_Vol.AxisX.Minimum = 0;
            chartArea_Vol.AxisX.Maximum = str_set.Length;
            chartArea_Vol.AxisY.Minimum = 0;
            chartArea_Vol.AxisY.Maximum = 100;
            chartArea_Vol.CursorX.AutoScroll = true;
            chartArea_Vol.AxisX.ScaleView.Zoomable = true;
            chartArea_Vol.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            chartArea_Vol.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartArea_Vol.AxisX.ScrollBar.BackColor = Color.DarkGray;
            chartArea_Vol.AxisX.ScrollBar.ButtonColor = Color.LightGray;
            chartArea_Vol.Position.X = 0;
            chartArea_Vol.Position.Y = 55;
            chartArea_Vol.Position.Width = 100;
            chartArea_Vol.Position.Height = 15;
            chart.ChartAreas.Add(chartArea_Vol);

            chartArea_KD.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea_KD.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea_KD.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_KD.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_KD.BackColor = System.Drawing.Color.Black;
            chartArea_KD.AxisX.Minimum = 0;
            chartArea_KD.AxisX.Maximum = str_set.Length;
            //chartArea_KD.AxisY.Minimum = 0;
            //chartArea_KD.AxisY.Maximum = 100;
            chartArea_KD.CursorX.AutoScroll = true;
            chartArea_KD.AxisX.ScaleView.Zoomable = true;
            chartArea_KD.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            chartArea_KD.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartArea_KD.AxisX.ScrollBar.BackColor = Color.DarkGray;
            chartArea_KD.AxisX.ScrollBar.ButtonColor = Color.LightGray;
            chartArea_KD.Position.X = 0;
            chartArea_KD.Position.Y = 70;
            chartArea_KD.Position.Width = 100;
            chartArea_KD.Position.Height = 15;
            chart.ChartAreas.Add(chartArea_KD);

            chartArea_MACD.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea_MACD.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea_MACD.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_MACD.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_MACD.BackColor = System.Drawing.Color.Black;
            chartArea_MACD.AxisX.Minimum = 0;
            chartArea_MACD.AxisX.Maximum = str_set.Length;
            //chartArea_MACD.AxisY.Minimum = 0;
            //chartArea_MACD.AxisY.Maximum = 100;
            chartArea_MACD.CursorX.AutoScroll = true;
            chartArea_MACD.AxisX.ScaleView.Zoomable = true;
            chartArea_MACD.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            chartArea_MACD.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartArea_MACD.AxisX.ScrollBar.BackColor = Color.DarkGray;
            chartArea_MACD.AxisX.ScrollBar.ButtonColor = Color.LightGray;
            chartArea_MACD.Position.X = 0;
            chartArea_MACD.Position.Y = 85;
            chartArea_MACD.Position.Width = 100;
            chartArea_MACD.Position.Height = 15;
            chart.ChartAreas.Add(chartArea_MACD);


            series0.Name = "K";
            series1.Name = "MA_short";
            series2.Name = "MA_middle";
            series3.Name = "MA_long";
            series4.Name = "Vol";
            series5.Name = "KD_K";
            series6.Name = "KD_D";
            series7.Name = "DIF";
            series8.Name = "MACD";
            series9.Name = "OSC";

            chart.Series.Add(series0);
            chart.Series.Add(series1);
            chart.Series.Add(series2);
            chart.Series.Add(series3);
            chart.Series.Add(series4);
            chart.Series.Add(series5);
            chart.Series.Add(series6);
            chart.Series.Add(series7);
            chart.Series.Add(series8);
            chart.Series.Add(series9);

            chart.Series["K"].ChartType = SeriesChartType.Candlestick;
            chart.Series["K"]["OpenCloseStyle"] = "Triangle";
            chart.Series["K"]["ShowOpenClose"] = "Both";
            chart.Series["K"]["PointWidth"] = "0.5";
            chart.Series["K"]["PriceUpColor"] = "Red";
            chart.Series["K"]["PriceDownColor"] = "Green";
            chart.Series["MA_short"].ChartType = SeriesChartType.Line;
            chart.Series["MA_middle"].ChartType = SeriesChartType.Line;
            chart.Series["MA_long"].ChartType = SeriesChartType.Line;
            chart.Series["Vol"].ChartType = SeriesChartType.Column;
            chart.Series["KD_K"].ChartType = SeriesChartType.Line;
            chart.Series["KD_D"].ChartType = SeriesChartType.Line;
            chart.Series["DIF"].ChartType = SeriesChartType.Line;
            chart.Series["MACD"].ChartType = SeriesChartType.Line;
            chart.Series["OSC"].ChartType = SeriesChartType.Column;

            //chart.Series["Vol"].YAxisType = AxisType.Secondary;
            chart.Series["K"].ChartArea = "CA_Price";
            chart.Series["MA_short"].ChartArea = "CA_Price";
            chart.Series["MA_middle"].ChartArea = "CA_Price";
            chart.Series["MA_long"].ChartArea = "CA_Price";
            chart.Series["Vol"].ChartArea = "CA_Vol";
            chart.Series["KD_K"].ChartArea = "CA_KD";
            chart.Series["KD_K"].Color = Color.Green;
            chart.Series["KD_D"].ChartArea = "CA_KD";
            chart.Series["KD_D"].Color = Color.Red;
            chart.Series["DIF"].ChartArea = "CA_MACD";
            chart.Series["DIF"].Color = Color.Yellow;
            chart.Series["MACD"].ChartArea = "CA_MACD";
            chart.Series["MACD"].Color = Color.LightBlue;
            chart.Series["OSC"].ChartArea = "CA_MACD";
            chart.Series["OSC"].Color = Color.LightGray;

            nud1.Minimum = 0;
            nud2.Minimum = 0;
            nud3.Minimum = 0;
            nud4.Minimum = 0;
            nud1.Maximum = str_set.Length;
            nud2.Maximum = str_set.Length;
            nud3.Maximum = str_set.Length;
            nud4.Maximum = str_set.Length;
            nud1.Value = s_MA;
            nud2.Value = m_MA;
            nud3.Value = l_MA;
            nud4.Value = str_set.Length;
            nud1.Location = new Point(1550, 15);
            nud2.Location = new Point(1550, 45);
            nud3.Location = new Point(1550, 75);
            nud4.Location = new Point(1550, 150);

            tb.Controls.Add(nud1);
            tb.Controls.Add(nud2);
            tb.Controls.Add(nud3);
            tb.Controls.Add(nud4);

            nud1.TextChanged += new EventHandler(nud_change);
            nud2.TextChanged += new EventHandler(nud_change);
            nud3.TextChanged += new EventHandler(nud_change);
            nud4.TextChanged += new EventHandler(nud_change);
            chart.MouseMove += new MouseEventHandler(chData_MouseMove);
            chart.Click += new EventHandler(chart_onclick);

            //0=high,1=low,2=open,3=close,4=adj_high,5=adj_low,6=adj_open,7=adj_close,8=volume
            for (int i = 0; i < val_set.Length / 9 - 1; i++)
            {
                chart.Series["K"].Points.AddXY(str_set[i], val_set[i, 4]);
                chart.Series["K"].Points[i].YValues[1] = val_set[i, 5];
                chart.Series["K"].Points[i].YValues[2] = val_set[i, 6];
                chart.Series["K"].Points[i].YValues[3] = val_set[i, 7];
                chart.Series["Vol"].Points.AddXY(str_set[i], val_set[i, 8]);
                if (val_set[i, 7] - val_set[i, 6]>0)
                {
                    chart.Series["Vol"].Points[i].Color = System.Drawing.Color.Red;
                }
                else if(val_set[i, 7] - val_set[i, 6]<0)
                {
                    chart.Series["Vol"].Points[i].Color = System.Drawing.Color.Green;
                }
                else
                {
                    chart.Series["Vol"].Points[i].Color = System.Drawing.Color.Gray;
                }

                {   //RSV
                    try
                    {
                        dou_temp = val_set[i, 4]; //high of 9
                        dou_temp_2 = val_set[i, 5]; //low of 9
                        for (j = 1; j < 9; j++)
                        {
                            if (dou_temp < val_set[i - j, 4])
                            {
                                dou_temp = val_set[i - j, 4];
                            }
                            if (dou_temp_2 > val_set[i - j, 5])
                            {
                                dou_temp_2 = val_set[i - j, 5];
                            }

                        }

                        RSV[i] = (val_set[i, 7] - dou_temp_2) / (dou_temp - dou_temp_2);
                    }
                    catch
                    {
                        RSV[i] = 0.5;
                    }
                    
                    //KD
                    try
                    {
                        KD_K[i] = (2.0 / 3) * KD_K[i - 1] + (1.0 / 3) * RSV[i];
                        KD_D[i] = (2.0 / 3) * KD_D[i - 1] + (1.0 / 3) * KD_K[i];
                    }
                    catch
                    {
                        KD_K[i] = 0.5;
                        KD_D[i] = 0.5;
                    }
                    chart.Series["KD_K"].Points.AddXY(str_set[i], KD_K[i]);
                    chart.Series["KD_D"].Points.AddXY(str_set[i], KD_D[i]);
                }

                {   //MACD
                    dou_temp = (val_set[i, 4] + val_set[i, 5] + 2*val_set[i, 7]) / 4; //P
                    try
                    {
                        EMA_12[i] = EMA_12[i - 1] + (2.0 / 13) * (dou_temp - EMA_12[i - 1]);
                        EMA_26[i] = EMA_26[i - 1] + (2.0 / 27) * (dou_temp - EMA_26[i - 1]);
                    }
                    catch
                    {
                        EMA_12[i] = val_set[i, 7] + (2.0 / 13) * (dou_temp - val_set[i, 7]);
                        EMA_26[i] = val_set[i, 7] + (2.0 / 27) * (dou_temp - val_set[i, 7]);
                    }

                    dou_temp_2 = EMA_26[i] - EMA_12[i];//DIF
                    try
                    {
                        MACD[i] = MACD[i - 1] + (2.0 / 10) * (dou_temp_2 - MACD[i - 1]);
                    }
                    catch
                    {
                        MACD[i] = dou_temp_2;
                    }

                    chart.Series["DIF"].Points.AddXY(str_set[i], dou_temp_2);
                    chart.Series["MACD"].Points.AddXY(str_set[i], MACD[i]);
                    chart.Series["OSC"].Points.AddXY(str_set[i], dou_temp_2 - MACD[i]);

                    if (dou_temp_2 - MACD[i] > 0)
                    {
                        chart.Series["OSC"].Points[i].Color = System.Drawing.Color.Red;
                    }
                    else if (dou_temp_2 - MACD[i] < 0)
                    {
                        chart.Series["OSC"].Points[i].Color = System.Drawing.Color.Green;
                    }
                    else
                    {
                        chart.Series["OSC"].Points[i].Color = System.Drawing.Color.Gray;
                    }
                    
                }
                //0=high,1=low,2=open,3=close,4=adj_high,5=adj_low,6=adj_open,7=adj_close,8=volume
            }

            scroll_blockSize = Convert.ToInt32(nud4.Value);
            //chartArea_K.AxisY.Minimum = Math.Round(chart.Series["K"].Points.FindMinByValue().YValues[1]);
            //chartArea_K.AxisY.Maximum = Math.Round(chart.Series["K"].Points.FindMaxByValue().YValues[0]);
            chartArea_Vol.AxisY.Minimum = 0;
            //chartArea_Vol.AxisY.Maximum = 100;
            chartArea_K.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_K.AxisX.ScaleView.SmallScrollSize = scroll_blockSize;
            chartArea_Vol.AxisX.ScrollBar.Enabled = false;
            chartArea_Vol.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_Vol.AxisX.ScaleView.SmallScrollSize = scroll_blockSize;
            chartArea_KD.AxisX.ScrollBar.Enabled = false;
            chartArea_KD.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_KD.AxisX.ScaleView.SmallScrollSize = scroll_blockSize;
            chartArea_MACD.AxisX.ScrollBar.Enabled = false;
            chartArea_MACD.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_MACD.AxisX.ScaleView.SmallScrollSize = scroll_blockSize;

            tb.Controls.Add(chart);

            //Tt.ReshowDelay = 500;
        }

        private void nud_change(object sender, EventArgs e)
        {
            charting(Convert.ToInt32(nud1.Value), Convert.ToInt32(nud2.Value), Convert.ToInt32(nud3.Value));
            scroll_blockSize = Convert.ToInt32(nud4.Value);
            chartArea_K.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_Vol.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_KD.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_MACD.AxisX.ScaleView.Zoom(0, scroll_blockSize);
        }

        private void chData_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
                        
            chartArea_K.CursorX.SetCursorPixelPosition(mousePoint, true);
            chartArea_K.CursorY.SetCursorPixelPosition(mousePoint, true);
            chartArea_Vol.CursorX.SetCursorPixelPosition(mousePoint, true);
            chartArea_KD.CursorX.SetCursorPixelPosition(mousePoint, true);
            chartArea_MACD.CursorX.SetCursorPixelPosition(mousePoint, true);

            chartArea_K.CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);

            if (pX != chartArea_K.CursorX.Position)
            {
                pX = chartArea_K.CursorX.Position;
                try
                {
                    if (val_set[Convert.ToInt32(pX) - 1, 2] > val_set[Convert.ToInt32(pX) - 1, 3])
                    {
                        Tt.Show(str_set[Convert.ToInt32(pX) - 1] + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 4].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 6].ToString() + "   " + val_set[Convert.ToInt32(pX) - 1, 7].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 5].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 8].ToString() + "  ↓", this.chart, 60, 10);
                    }
                    else if (val_set[Convert.ToInt32(pX) - 1, 2] < val_set[Convert.ToInt32(pX) - 1, 3])
                    {
                        Tt.Show(str_set[Convert.ToInt32(pX) - 1] + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 4].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 6].ToString() + "   " + val_set[Convert.ToInt32(pX) - 1, 7].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 5].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 8].ToString() + "  ↑", this.chart, 60, 10);
                    }
                    else
                    {
                        Tt.Show(str_set[Convert.ToInt32(pX) - 1] + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 4].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 6].ToString() + "   " + val_set[Convert.ToInt32(pX) - 1, 7].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 5].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 8].ToString() + "  -", this.chart, 60, 10);
                    }
                }
                catch { }
            }
            
        }

        private void chart_onclick(object sender, EventArgs e)
        {
            chartArea_Vol.AxisX.ScaleView.Position = chartArea_K.AxisX.ScaleView.Position;
            chartArea_KD.AxisX.ScaleView.Position = chartArea_K.AxisX.ScaleView.Position;
            chartArea_MACD.AxisX.ScaleView.Position = chartArea_K.AxisX.ScaleView.Position;
        }


        //private void chData_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Delta < 0)
        //        {
        //            chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
        //            chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
        //        }

        //        if (e.Delta > 0)
        //        {
        //            double xMin = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
        //            double xMax = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
        //            double yMin = chart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
        //            double yMax = chart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

        //            double posXStart = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
        //            double posXFinish = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
        //            double posYStart = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
        //            double posYFinish = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

        //            chart.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
        //            chart.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
        //        }
        //    }
        //    catch { }
        //}


        //0=high,1=low,2=open,3=close,4=adj_high,5=adj_low,6=adj_open,7=adj_close,8=volume
	    private void charting(int MA_s, int MA_m, int MA_l)
        {
            int i, j;

            chart.Series["MA_short"].Points.Clear();
            chart.Series["MA_middle"].Points.Clear();
            chart.Series["MA_long"].Points.Clear();


            for (i = 0; i < val_set.Length / 9 - 1; i++)
            {


                if (i > MA_s && i< val_set.Length / 9)
                {
                    dou_temp = 0;
                    for (j = 0; j < MA_s; j++)
                    {
                        dou_temp = dou_temp + val_set[i - j, 7];
                    }
                    dou_temp = dou_temp / MA_s;
                    chart.Series["MA_short"].Points.AddXY(str_set[i], dou_temp);
                }
                else
                {
                    chart.Series["MA_short"].Points.AddXY(str_set[i], 0);
                }

                if (i > MA_m && i< val_set.Length / 9)
                {
                    dou_temp = 0;
                    for (j = 0; j < MA_m; j++)
                    {
                        dou_temp = dou_temp + val_set[i - j, 7];
                    }
                    dou_temp = dou_temp / MA_m;
                    chart.Series["MA_middle"].Points.AddXY(str_set[i], dou_temp);
                }
                else
                {
                    chart.Series["MA_middle"].Points.AddXY(str_set[i], 0);
                }

                if (i > MA_l && i< val_set.Length / 9)
                {
                    dou_temp = 0;
                    for (j = 0; j < MA_l; j++)
                    {
                        dou_temp = dou_temp + val_set[i - j, 7];
                    }
                    dou_temp = dou_temp / MA_l;
                    chart.Series["MA_long"].Points.AddXY(str_set[i], dou_temp);
                }
                else
                {
                    chart.Series["MA_long"].Points.AddXY(str_set[i], 0);
                }

                //{
                //    dou_temp = val_set[i,4]; //high of 9
                //    dou_temp_2 = val_set[i,5]; //low of 9
                //    for (j = 1; j < 9; j++)
                //    {
                //        if (dou_temp < val_set[i - j, 4])
                //        {
                //            dou_temp = val_set[i - j, 4];
                //        }
                //        if (dou_temp_2 > val_set[i - j, 5])
                //        {
                //            dou_temp_2 = val_set[i - j, 5];
                //        }
                        
                //    }

                //    RSV[i] = (val_set[i,7] - dou_temp_2) / (dou_temp - dou_temp_2);
                //    chart.Series["MA_KD"].Points.AddXY(str_set[i], RSV[i]);
                //}

                {

                }

            }
            //0=high,1=low,2=open,3=close,4=adj_high,5=adj_low,6=adj_open,7=adj_close,8=volume
            
        }
    }

    class Tabs_w
    {
        private TabPage tb = new TabPage();
        private Chart chart = new Chart();
        private ChartArea chartArea_K = new ChartArea("CA_Price");
        private ChartArea chartArea_Vol = new ChartArea("CA_Vol");
        private ChartArea chartArea_KD = new ChartArea("CA_KD");
        private ChartArea chartArea_MACD = new ChartArea("CA_MACD");
        private Series series0 = new Series();
        private Series series1 = new Series();
        private Series series2 = new Series();
        private Series series3 = new Series();
        private Series series4 = new Series();
        private Series series5 = new Series();
        private Series series6 = new Series();
        private Series series7 = new Series();
        private Series series8 = new Series();
        private Series series9 = new Series();
        private Series series10 = new Series();
        private Series series11 = new Series();
        private Series series12 = new Series();
        private NumericUpDown nud1 = new NumericUpDown();
        private NumericUpDown nud2 = new NumericUpDown();
        private NumericUpDown nud3 = new NumericUpDown();
        private NumericUpDown nud4 = new NumericUpDown();
        private ToolTip Tt = new ToolTip();
        private int scroll_blockSize = 0;
        private double dou_temp;
        private double MA_temp;
        private double MB_temp;
        private double dou_temp_2;
        string[] str_set;
        double[,] val_set;
        double[] RSV;
        double[] KD_K;
        double[] KD_D;
        double[] EMA_12;
        double[] EMA_26;
        double[] MACD;
        double pX = 0;


        public Tabs_w(TabControl tc, string[] str_set, double[,] data_set, int s_MA)
        {
            this.str_set = str_set;
            this.val_set = data_set;
            RSV = new double[str_set.Length];
            KD_K = new double[str_set.Length];
            KD_D = new double[str_set.Length];
            EMA_12 = new double[str_set.Length];
            EMA_26 = new double[str_set.Length];
            MACD = new double[str_set.Length];
            chart_initial(tc, s_MA);
            charting(Convert.ToInt32(nud1.Value));
        }

        private void chart_initial(TabControl tc, int s_MA)
        {
            int j;

            tb.Name = "Week";
            tb.Text = "Week";
            tb.Dock = DockStyle.Fill;
            tc.TabPages.Add(tb);

            chart.Size = new Size(1500, 1000);

            chartArea_K.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea_K.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea_K.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_K.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_K.BackColor = System.Drawing.Color.Black;
            chartArea_K.AxisX.Minimum = 0;
            chartArea_K.AxisX.Maximum = str_set.Length;
            chartArea_K.CursorX.AutoScroll = true;
            chartArea_K.AxisX.ScaleView.Zoomable = true;
            chartArea_K.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            chartArea_K.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartArea_K.AxisX.ScrollBar.BackColor = Color.DarkGray;
            chartArea_K.AxisX.ScrollBar.ButtonColor = Color.LightGray;
            chartArea_K.Position.X = 0;
            chartArea_K.Position.Y = 0;
            chartArea_K.Position.Width = 100;
            chartArea_K.Position.Height = 55;
            chart.ChartAreas.Add(chartArea_K);

            chartArea_Vol.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea_Vol.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea_Vol.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_Vol.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_Vol.BackColor = System.Drawing.Color.Black;
            chartArea_Vol.AxisX.Minimum = 0;
            chartArea_Vol.AxisX.Maximum = str_set.Length;
            chartArea_Vol.AxisY.Minimum = 0;
            chartArea_Vol.AxisY.Maximum = 100;
            chartArea_Vol.CursorX.AutoScroll = true;
            chartArea_Vol.AxisX.ScaleView.Zoomable = true;
            chartArea_Vol.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            chartArea_Vol.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartArea_Vol.AxisX.ScrollBar.BackColor = Color.DarkGray;
            chartArea_Vol.AxisX.ScrollBar.ButtonColor = Color.LightGray;
            chartArea_Vol.Position.X = 0;
            chartArea_Vol.Position.Y = 55;
            chartArea_Vol.Position.Width = 100;
            chartArea_Vol.Position.Height = 15;
            chart.ChartAreas.Add(chartArea_Vol);

            chartArea_KD.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea_KD.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea_KD.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_KD.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_KD.BackColor = System.Drawing.Color.Black;
            chartArea_KD.AxisX.Minimum = 0;
            chartArea_KD.AxisX.Maximum = str_set.Length;
            //chartArea_KD.AxisY.Minimum = 0;
            //chartArea_KD.AxisY.Maximum = 100;
            chartArea_KD.CursorX.AutoScroll = true;
            chartArea_KD.AxisX.ScaleView.Zoomable = true;
            chartArea_KD.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            chartArea_KD.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartArea_KD.AxisX.ScrollBar.BackColor = Color.DarkGray;
            chartArea_KD.AxisX.ScrollBar.ButtonColor = Color.LightGray;
            chartArea_KD.Position.X = 0;
            chartArea_KD.Position.Y = 70;
            chartArea_KD.Position.Width = 100;
            chartArea_KD.Position.Height = 15;
            chart.ChartAreas.Add(chartArea_KD);

            chartArea_MACD.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea_MACD.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea_MACD.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_MACD.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_MACD.BackColor = System.Drawing.Color.Black;
            chartArea_MACD.AxisX.Minimum = 0;
            chartArea_MACD.AxisX.Maximum = str_set.Length;
            //chartArea_MACD.AxisY.Minimum = 0;
            //chartArea_MACD.AxisY.Maximum = 100;
            chartArea_MACD.CursorX.AutoScroll = true;
            chartArea_MACD.AxisX.ScaleView.Zoomable = true;
            chartArea_MACD.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            chartArea_MACD.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartArea_MACD.AxisX.ScrollBar.BackColor = Color.DarkGray;
            chartArea_MACD.AxisX.ScrollBar.ButtonColor = Color.LightGray;
            chartArea_MACD.Position.X = 0;
            chartArea_MACD.Position.Y = 85;
            chartArea_MACD.Position.Width = 100;
            chartArea_MACD.Position.Height = 15;
            chart.ChartAreas.Add(chartArea_MACD);

            series0.Name = "K";
            //series1.Name = "MA";
            series2.Name = "MB";
            series3.Name = "Bool+1";
            series4.Name = "Bool+2";
            series5.Name = "Bool-1";
            series6.Name = "Bool-2";
            series7.Name = "Vol";
            series8.Name = "KD_K";
            series9.Name = "KD_D";
            series10.Name = "DIF";
            series11.Name = "MACD";
            series12.Name = "OSC";

            chart.Series.Add(series0);
            //chart.Series.Add(series1);
            chart.Series.Add(series2);
            chart.Series.Add(series3);
            chart.Series.Add(series4);
            chart.Series.Add(series5);
            chart.Series.Add(series6);
            chart.Series.Add(series7);
            chart.Series.Add(series8);
            chart.Series.Add(series9);
            chart.Series.Add(series10);
            chart.Series.Add(series11);
            chart.Series.Add(series12);
            
            chart.Series["K"].ChartType = SeriesChartType.Candlestick;
            chart.Series["K"]["OpenCloseStyle"] = "Triangle";
            chart.Series["K"]["ShowOpenClose"] = "Both";
            chart.Series["K"]["PointWidth"] = "0.5";
            chart.Series["K"]["PriceUpColor"] = "Red";
            chart.Series["K"]["PriceDownColor"] = "Green";
            //chart.Series["MA"].ChartType = SeriesChartType.Line;
            chart.Series["MB"].ChartType = SeriesChartType.Line;
            chart.Series["Bool+1"].ChartType = SeriesChartType.Line;
            chart.Series["Bool+2"].ChartType = SeriesChartType.Line;
            chart.Series["Bool-1"].ChartType = SeriesChartType.Line;
            chart.Series["Bool-2"].ChartType = SeriesChartType.Line;
            chart.Series["MB"].Color = Color.SkyBlue;
            chart.Series["Bool+1"].Color = Color.White;
            chart.Series["Bool+2"].Color = Color.White;
            chart.Series["Bool-1"].Color = Color.White;
            chart.Series["Bool-2"].Color = Color.White;
            chart.Series["Vol"].ChartType = SeriesChartType.Column;
            chart.Series["KD_K"].ChartType = SeriesChartType.Line;
            chart.Series["KD_D"].ChartType = SeriesChartType.Line;
            chart.Series["DIF"].ChartType = SeriesChartType.Line;
            chart.Series["MACD"].ChartType = SeriesChartType.Line;
            chart.Series["OSC"].ChartType = SeriesChartType.Column;

            //chart.Series["Vol"].YAxisType = AxisType.Secondary;
            chart.Series["K"].ChartArea = "CA_Price";
            //chart.Series["MA"].ChartArea = "CA_Price";
            chart.Series["MB"].ChartArea = "CA_Price";
            chart.Series["Bool+1"].ChartArea = "CA_Price";
            chart.Series["Bool+2"].ChartArea = "CA_Price";
            chart.Series["Bool-1"].ChartArea = "CA_Price";
            chart.Series["Bool-2"].ChartArea = "CA_Price";
            chart.Series["Vol"].ChartArea = "CA_Vol";
            chart.Series["KD_K"].ChartArea = "CA_KD";
            chart.Series["KD_K"].Color = Color.Green;
            chart.Series["KD_D"].ChartArea = "CA_KD";
            chart.Series["KD_D"].Color = Color.Red;
            chart.Series["DIF"].ChartArea = "CA_MACD";
            chart.Series["DIF"].Color = Color.Yellow;
            chart.Series["MACD"].ChartArea = "CA_MACD";
            chart.Series["MACD"].Color = Color.LightBlue;
            chart.Series["OSC"].ChartArea = "CA_MACD";
            chart.Series["OSC"].Color = Color.LightGray;

            nud1.Minimum = 0;
            nud2.Minimum = 0;
            nud3.Minimum = 0;
            nud4.Minimum = 0;
            nud1.Maximum = str_set.Length;
            nud2.Maximum = str_set.Length;
            nud3.Maximum = str_set.Length;
            nud4.Maximum = str_set.Length;
            nud1.Value = s_MA;
            nud2.Value = 0;
            nud3.Value = 0;
            nud4.Value = str_set.Length;
            nud1.Location = new Point(1550, 15);
            nud2.Location = new Point(1550, 45);
            nud3.Location = new Point(1550, 75);
            nud4.Location = new Point(1550, 150);

            tb.Controls.Add(nud1);
            //tb.Controls.Add(nud2);
            //tb.Controls.Add(nud3);
            tb.Controls.Add(nud4);

            nud1.TextChanged += new EventHandler(nud_change);
            nud2.TextChanged += new EventHandler(nud_change);
            nud3.TextChanged += new EventHandler(nud_change);
            nud4.TextChanged += new EventHandler(nud_change);
            chart.MouseMove += new MouseEventHandler(chData_MouseMove);
            chart.Click += new EventHandler(chart_onclick);

            //0=high,1=low,2=open,3=close,4=adj_high,5=adj_low,6=adj_open,7=adj_close,8=volume
            for (int i = 0; i < val_set.Length / 5 - 1; i++)
            {
                chart.Series["K"].Points.AddXY(str_set[i], val_set[i, 0]);
                chart.Series["K"].Points[i].YValues[1] = val_set[i, 1];
                chart.Series["K"].Points[i].YValues[2] = val_set[i, 2];
                chart.Series["K"].Points[i].YValues[3] = val_set[i, 3];
                chart.Series["Vol"].Points.AddXY(str_set[i], val_set[i, 4]);
                if (val_set[i, 3] - val_set[i, 2] > 0)
                {
                    chart.Series["Vol"].Points[i].Color = System.Drawing.Color.Red;
                }
                else if (val_set[i, 3] - val_set[i, 2] < 0)
                {
                    chart.Series["Vol"].Points[i].Color = System.Drawing.Color.Green;
                }
                else
                {
                    chart.Series["Vol"].Points[i].Color = System.Drawing.Color.Gray;
                }

                {   //RSV
                    try
                    {
                        dou_temp = val_set[i, 0]; //high of 9
                        dou_temp_2 = val_set[i, 1]; //low of 9
                        for (j = 1; j < 9; j++)
                        {
                            if (dou_temp < val_set[i - j, 0])
                            {
                                dou_temp = val_set[i - j, 0];
                            }
                            if (dou_temp_2 > val_set[i - j, 1])
                            {
                                dou_temp_2 = val_set[i - j, 1];
                            }

                        }

                        RSV[i] = (val_set[i, 3] - dou_temp_2) / (dou_temp - dou_temp_2);
                    }
                    catch
                    {
                        RSV[i] = 0.5;
                    }

                    //KD
                    try
                    {
                        KD_K[i] = (2.0 / 3) * KD_K[i - 1] + (1.0 / 3) * RSV[i];
                        KD_D[i] = (2.0 / 3) * KD_D[i - 1] + (1.0 / 3) * KD_K[i];
                    }
                    catch
                    {
                        KD_K[i] = 0.5;
                        KD_D[i] = 0.5;
                    }
                    chart.Series["KD_K"].Points.AddXY(str_set[i], KD_K[i]);
                    chart.Series["KD_D"].Points.AddXY(str_set[i], KD_D[i]);
                }

                {   //MACD
                    dou_temp = (val_set[i, 0] + val_set[i, 1] + 2 * val_set[i, 3]) / 4; //P
                    try
                    {
                        EMA_12[i] = EMA_12[i - 1] + (2.0 / 13) * (dou_temp - EMA_12[i - 1]);
                        EMA_26[i] = EMA_26[i - 1] + (2.0 / 27) * (dou_temp - EMA_26[i - 1]);
                    }
                    catch
                    {
                        EMA_12[i] = val_set[i, 3] + (2.0 / 13) * (dou_temp - val_set[i, 3]);
                        EMA_26[i] = val_set[i, 3] + (2.0 / 27) * (dou_temp - val_set[i, 3]);
                    }

                    dou_temp_2 = EMA_26[i] - EMA_12[i];//DIF
                    try
                    {
                        MACD[i] = MACD[i - 1] + (2.0 / 10) * (dou_temp_2 - MACD[i - 1]);
                    }
                    catch
                    {
                        MACD[i] = dou_temp_2;
                    }

                    chart.Series["DIF"].Points.AddXY(str_set[i], dou_temp_2);
                    chart.Series["MACD"].Points.AddXY(str_set[i], MACD[i]);
                    chart.Series["OSC"].Points.AddXY(str_set[i], dou_temp_2 - MACD[i]);

                    if (dou_temp_2 - MACD[i] > 0)
                    {
                        chart.Series["OSC"].Points[i].Color = System.Drawing.Color.Red;
                    }
                    else if (dou_temp_2 - MACD[i] < 0)
                    {
                        chart.Series["OSC"].Points[i].Color = System.Drawing.Color.Green;
                    }
                    else
                    {
                        chart.Series["OSC"].Points[i].Color = System.Drawing.Color.Gray;
                    }

                }
            }

            scroll_blockSize = Convert.ToInt32(nud4.Value);
            //chartArea_K.AxisY.Minimum = Math.Round(chart.Series["K"].Points.FindMinByValue().YValues[1]);
            //chartArea_K.AxisY.Maximum = Math.Round(chart.Series["K"].Points.FindMaxByValue().YValues[0]);
            chartArea_Vol.AxisY.Minimum = 0;
            //chartArea_Vol.AxisY.Maximum = 100;
            chartArea_K.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_K.AxisX.ScaleView.SmallScrollSize = scroll_blockSize;
            chartArea_Vol.AxisX.ScrollBar.Enabled = false;
            chartArea_Vol.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_Vol.AxisX.ScaleView.SmallScrollSize = scroll_blockSize;
            chartArea_KD.AxisX.ScrollBar.Enabled = false;
            chartArea_KD.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_KD.AxisX.ScaleView.SmallScrollSize = scroll_blockSize;
            chartArea_MACD.AxisX.ScrollBar.Enabled = false;
            chartArea_MACD.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_MACD.AxisX.ScaleView.SmallScrollSize = scroll_blockSize;

            tb.Controls.Add(chart);

            //Tt.ReshowDelay = 500;
        }

        private void nud_change(object sender, EventArgs e)
        {
            charting(Convert.ToInt32(nud1.Value));
            scroll_blockSize = Convert.ToInt32(nud4.Value);
            chartArea_K.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_Vol.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_KD.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_MACD.AxisX.ScaleView.Zoom(0, scroll_blockSize);
        }

        private void chData_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            chartArea_K.CursorX.SetCursorPixelPosition(mousePoint, true);
            chartArea_K.CursorY.SetCursorPixelPosition(mousePoint, true);
            chartArea_Vol.CursorX.SetCursorPixelPosition(mousePoint, true);
            chartArea_KD.CursorX.SetCursorPixelPosition(mousePoint, true);
            chartArea_MACD.CursorX.SetCursorPixelPosition(mousePoint, true);

            chartArea_K.CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);

            if (pX != chartArea_K.CursorX.Position)
            {
                pX = chartArea_K.CursorX.Position;
                try
                {
                    if (val_set[Convert.ToInt32(pX) - 1, 2] > val_set[Convert.ToInt32(pX) - 1, 3])
                    {
                        Tt.Show(str_set[Convert.ToInt32(pX) - 1] + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 4].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 6].ToString() + "   " + val_set[Convert.ToInt32(pX) - 1, 7].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 5].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 8].ToString() + "  ↓", this.chart, 60, 10);
                    }
                    else if (val_set[Convert.ToInt32(pX) - 1, 2] < val_set[Convert.ToInt32(pX) - 1, 3])
                    {
                        Tt.Show(str_set[Convert.ToInt32(pX) - 1] + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 4].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 6].ToString() + "   " + val_set[Convert.ToInt32(pX) - 1, 7].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 5].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 8].ToString() + "  ↑", this.chart, 60, 10);
                    }
                    else
                    {
                        Tt.Show(str_set[Convert.ToInt32(pX) - 1] + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 4].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 6].ToString() + "   " + val_set[Convert.ToInt32(pX) - 1, 7].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 5].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 8].ToString() + "  -", this.chart, 60, 10);
                    }
                }
                catch { }
            }

        }

        private void chart_onclick(object sender, EventArgs e)
        {
            chartArea_Vol.AxisX.ScaleView.Position = chartArea_K.AxisX.ScaleView.Position;
            chartArea_KD.AxisX.ScaleView.Position = chartArea_K.AxisX.ScaleView.Position;
            chartArea_MACD.AxisX.ScaleView.Position = chartArea_K.AxisX.ScaleView.Position;
        }


        //private void chData_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Delta < 0)
        //        {
        //            chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
        //            chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
        //        }

        //        if (e.Delta > 0)
        //        {
        //            double xMin = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
        //            double xMax = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
        //            double yMin = chart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
        //            double yMax = chart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

        //            double posXStart = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
        //            double posXFinish = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
        //            double posYStart = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
        //            double posYFinish = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

        //            chart.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
        //            chart.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
        //        }
        //    }
        //    catch { }
        //}

        private void charting(int MA_s)
        {
            int i, j;

            //chart.Series["MA"].Points.Clear();
            chart.Series["MB"].Points.Clear();
            chart.Series["Bool+1"].Points.Clear();
            chart.Series["Bool+2"].Points.Clear();
            chart.Series["Bool-1"].Points.Clear();
            chart.Series["Bool-2"].Points.Clear();

            for (i = 0; i < val_set.Length / 5 - 1; i++)
            {


                if (i > MA_s && i < val_set.Length / 5)
                {
                    dou_temp = 0;
                    for (j = 0; j < MA_s; j++)
                    {
                        dou_temp = dou_temp + val_set[i - j, 3];
                    }
                    MA_temp = dou_temp / MA_s;
                    //chart.Series["MA"].Points.AddXY(str_set[i], MA_temp);

                    dou_temp = 0;
                    for (j = 1; j < MA_s; j++)
                    {
                        dou_temp = dou_temp + val_set[i - j, 3];
                    }
                    MB_temp = dou_temp / MA_s;
                    chart.Series["MB"].Points.AddXY(str_set[i], MB_temp);

                    dou_temp = 0;
                    for (j = 0; j < MA_s; j++)
                    {
                        dou_temp = dou_temp + Math.Pow(val_set[i - j, 3] - MA_temp,2);
                    }
                    //dou_temp = dou_temp / MA_s;
                    dou_temp = Math.Sqrt(dou_temp / MA_s);
                    chart.Series["Bool+1"].Points.AddXY(str_set[i], dou_temp + MB_temp);
                    chart.Series["Bool+2"].Points.AddXY(str_set[i], 2*dou_temp + MB_temp);
                    chart.Series["Bool-1"].Points.AddXY(str_set[i], -1*dou_temp + MB_temp);
                    chart.Series["Bool-2"].Points.AddXY(str_set[i], -2*dou_temp + MB_temp);
                }
                else
                {
                    chart.Series["MB"].Points.AddXY(str_set[i], 0);
                    chart.Series["Bool+1"].Points.AddXY(str_set[i], 0);
                    chart.Series["Bool+2"].Points.AddXY(str_set[i], 0);
                    chart.Series["Bool-1"].Points.AddXY(str_set[i], 0);
                    chart.Series["Bool-2"].Points.AddXY(str_set[i], 0);
                }
                
            }

        }
    }

    class Tabs_m
    {
        private TabPage tb = new TabPage();
        private Chart chart = new Chart();
        private ChartArea chartArea_K = new ChartArea("CA_Price");
        private ChartArea chartArea_Vol = new ChartArea("CA_Vol");
        private ChartArea chartArea_KD = new ChartArea("CA_KD");
        private ChartArea chartArea_MACD = new ChartArea("CA_MACD");
        private Series series0 = new Series();
        private Series series1 = new Series();
        private Series series2 = new Series();
        private Series series3 = new Series();
        private Series series4 = new Series();
        private Series series5 = new Series();
        private Series series6 = new Series();
        private Series series7 = new Series();
        private Series series8 = new Series();
        private Series series9 = new Series();
        private NumericUpDown nud1 = new NumericUpDown();
        private NumericUpDown nud2 = new NumericUpDown();
        private NumericUpDown nud3 = new NumericUpDown();
        private NumericUpDown nud4 = new NumericUpDown();
        private ToolTip Tt = new ToolTip();
        private int scroll_blockSize = 0;
        private double dou_temp;
        private double dou_temp_2;
        string[] str_set;
        double[,] val_set;
        double[] RSV;
        double[] KD_K;
        double[] KD_D;
        double[] EMA_12;
        double[] EMA_26;
        double[] MACD;
        double pX = 0;


        public Tabs_m(TabControl tc, string[] str_set, double[,] data_set, int s_MA, int m_MA, int l_MA)
        {
            this.str_set = str_set;
            this.val_set = data_set;
            RSV = new double[str_set.Length];
            KD_K = new double[str_set.Length];
            KD_D = new double[str_set.Length];
            EMA_12 = new double[str_set.Length];
            EMA_26 = new double[str_set.Length];
            MACD = new double[str_set.Length];
            chart_initial(tc, s_MA, m_MA, l_MA);
            charting(Convert.ToInt32(nud1.Value), Convert.ToInt32(nud2.Value), Convert.ToInt32(nud3.Value));
        }

        private void chart_initial(TabControl tc, int s_MA, int m_MA, int l_MA)
        {
            int j;

            tb.Name = "Month";
            tb.Text = "Month";
            tb.Dock = DockStyle.Fill;
            tc.TabPages.Add(tb);

            chart.Size = new Size(1500, 1000);

            chartArea_K.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea_K.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea_K.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_K.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_K.BackColor = System.Drawing.Color.Black;
            chartArea_K.AxisX.Minimum = 0;
            chartArea_K.AxisX.Maximum = str_set.Length;
            chartArea_K.CursorX.AutoScroll = true;
            chartArea_K.AxisX.ScaleView.Zoomable = true;
            chartArea_K.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            chartArea_K.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartArea_K.AxisX.ScrollBar.BackColor = Color.DarkGray;
            chartArea_K.AxisX.ScrollBar.ButtonColor = Color.LightGray;
            chartArea_K.Position.X = 0;
            chartArea_K.Position.Y = 0;
            chartArea_K.Position.Width = 100;
            chartArea_K.Position.Height = 55;
            chart.ChartAreas.Add(chartArea_K);

            chartArea_Vol.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea_Vol.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea_Vol.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_Vol.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_Vol.BackColor = System.Drawing.Color.Black;
            chartArea_Vol.AxisX.Minimum = 0;
            chartArea_Vol.AxisX.Maximum = str_set.Length;
            chartArea_Vol.AxisY.Minimum = 0;
            chartArea_Vol.AxisY.Maximum = 100;
            chartArea_Vol.CursorX.AutoScroll = true;
            chartArea_Vol.AxisX.ScaleView.Zoomable = true;
            chartArea_Vol.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            chartArea_Vol.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartArea_Vol.AxisX.ScrollBar.BackColor = Color.DarkGray;
            chartArea_Vol.AxisX.ScrollBar.ButtonColor = Color.LightGray;
            chartArea_Vol.Position.X = 0;
            chartArea_Vol.Position.Y = 55;
            chartArea_Vol.Position.Width = 100;
            chartArea_Vol.Position.Height = 15;
            chart.ChartAreas.Add(chartArea_Vol);

            chartArea_KD.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea_KD.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea_KD.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_KD.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_KD.BackColor = System.Drawing.Color.Black;
            chartArea_KD.AxisX.Minimum = 0;
            chartArea_KD.AxisX.Maximum = str_set.Length;
            //chartArea_KD.AxisY.Minimum = 0;
            //chartArea_KD.AxisY.Maximum = 100;
            chartArea_KD.CursorX.AutoScroll = true;
            chartArea_KD.AxisX.ScaleView.Zoomable = true;
            chartArea_KD.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            chartArea_KD.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartArea_KD.AxisX.ScrollBar.BackColor = Color.DarkGray;
            chartArea_KD.AxisX.ScrollBar.ButtonColor = Color.LightGray;
            chartArea_KD.Position.X = 0;
            chartArea_KD.Position.Y = 70;
            chartArea_KD.Position.Width = 100;
            chartArea_KD.Position.Height = 15;
            chart.ChartAreas.Add(chartArea_KD);

            chartArea_MACD.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea_MACD.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea_MACD.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_MACD.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            chartArea_MACD.BackColor = System.Drawing.Color.Black;
            chartArea_MACD.AxisX.Minimum = 0;
            chartArea_MACD.AxisX.Maximum = str_set.Length;
            //chartArea_MACD.AxisY.Minimum = 0;
            //chartArea_MACD.AxisY.Maximum = 100;
            chartArea_MACD.CursorX.AutoScroll = true;
            chartArea_MACD.AxisX.ScaleView.Zoomable = true;
            chartArea_MACD.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            chartArea_MACD.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartArea_MACD.AxisX.ScrollBar.BackColor = Color.DarkGray;
            chartArea_MACD.AxisX.ScrollBar.ButtonColor = Color.LightGray;
            chartArea_MACD.Position.X = 0;
            chartArea_MACD.Position.Y = 85;
            chartArea_MACD.Position.Width = 100;
            chartArea_MACD.Position.Height = 15;
            chart.ChartAreas.Add(chartArea_MACD);

            series0.Name = "K";
            series1.Name = "MA_short";
            series2.Name = "MA_middle";
            series3.Name = "MA_long";
            series4.Name = "Vol";
            series5.Name = "KD_K";
            series6.Name = "KD_D";
            series7.Name = "DIF";
            series8.Name = "MACD";
            series9.Name = "OSC";

            chart.Series.Add(series0);
            chart.Series.Add(series1);
            chart.Series.Add(series2);
            chart.Series.Add(series3);
            chart.Series.Add(series4);
            chart.Series.Add(series5);
            chart.Series.Add(series6);
            chart.Series.Add(series7);
            chart.Series.Add(series8);
            chart.Series.Add(series9);

            chart.Series["K"].ChartType = SeriesChartType.Candlestick;
            chart.Series["K"]["OpenCloseStyle"] = "Triangle";
            chart.Series["K"]["ShowOpenClose"] = "Both";
            chart.Series["K"]["PointWidth"] = "0.5";
            chart.Series["K"]["PriceUpColor"] = "Red";
            chart.Series["K"]["PriceDownColor"] = "Green";
            chart.Series["MA_short"].ChartType = SeriesChartType.Line;
            chart.Series["MA_middle"].ChartType = SeriesChartType.Line;
            chart.Series["MA_long"].ChartType = SeriesChartType.Line;
            chart.Series["Vol"].ChartType = SeriesChartType.Column;
            chart.Series["KD_K"].ChartType = SeriesChartType.Line;
            chart.Series["KD_D"].ChartType = SeriesChartType.Line;
            chart.Series["DIF"].ChartType = SeriesChartType.Line;
            chart.Series["MACD"].ChartType = SeriesChartType.Line;
            chart.Series["OSC"].ChartType = SeriesChartType.Column;

            //chart.Series["Vol"].YAxisType = AxisType.Secondary;
            chart.Series["K"].ChartArea = "CA_Price";
            chart.Series["MA_short"].ChartArea = "CA_Price";
            chart.Series["MA_middle"].ChartArea = "CA_Price";
            chart.Series["MA_long"].ChartArea = "CA_Price";
            chart.Series["Vol"].ChartArea = "CA_Vol";
            chart.Series["KD_K"].ChartArea = "CA_KD";
            chart.Series["KD_K"].Color = Color.Green;
            chart.Series["KD_D"].ChartArea = "CA_KD";
            chart.Series["KD_D"].Color = Color.Red;
            chart.Series["DIF"].ChartArea = "CA_MACD";
            chart.Series["DIF"].Color = Color.Yellow;
            chart.Series["MACD"].ChartArea = "CA_MACD";
            chart.Series["MACD"].Color = Color.LightBlue;
            chart.Series["OSC"].ChartArea = "CA_MACD";
            chart.Series["OSC"].Color = Color.LightGray;

            nud1.Minimum = 0;
            nud2.Minimum = 0;
            nud3.Minimum = 0;
            nud4.Minimum = 0;
            nud1.Maximum = str_set.Length;
            nud2.Maximum = str_set.Length;
            nud3.Maximum = str_set.Length;
            nud4.Maximum = str_set.Length;
            nud1.Value = s_MA;
            nud2.Value = m_MA;
            nud3.Value = l_MA;
            nud4.Value = str_set.Length;
            nud1.Location = new Point(1550, 15);
            nud2.Location = new Point(1550, 45);
            nud3.Location = new Point(1550, 75);
            nud4.Location = new Point(1550, 150);

            tb.Controls.Add(nud1);
            tb.Controls.Add(nud2);
            tb.Controls.Add(nud3);
            tb.Controls.Add(nud4);

            nud1.TextChanged += new EventHandler(nud_change);
            nud2.TextChanged += new EventHandler(nud_change);
            nud3.TextChanged += new EventHandler(nud_change);
            nud4.TextChanged += new EventHandler(nud_change);
            chart.MouseMove += new MouseEventHandler(chData_MouseMove);
            chart.Click += new EventHandler(chart_onclick);

            //0=high,1=low,2=open,3=close,4=adj_high,5=adj_low,6=adj_open,7=adj_close,8=volume
            for (int i = 0; i < val_set.Length / 5 - 1; i++)
            {
                chart.Series["K"].Points.AddXY(str_set[i], val_set[i, 0]);
                chart.Series["K"].Points[i].YValues[1] = val_set[i, 1];
                chart.Series["K"].Points[i].YValues[2] = val_set[i, 2];
                chart.Series["K"].Points[i].YValues[3] = val_set[i, 3];
                chart.Series["Vol"].Points.AddXY(str_set[i], val_set[i, 4]);
                if (val_set[i, 3] - val_set[i, 2] > 0)
                {
                    chart.Series["Vol"].Points[i].Color = System.Drawing.Color.Red;
                }
                else if (val_set[i, 3] - val_set[i, 2] < 0)
                {
                    chart.Series["Vol"].Points[i].Color = System.Drawing.Color.Green;
                }
                else
                {
                    chart.Series["Vol"].Points[i].Color = System.Drawing.Color.Gray;
                }

                {   //RSV
                    try
                    {
                        dou_temp = val_set[i, 0]; //high of 9
                        dou_temp_2 = val_set[i, 1]; //low of 9
                        for (j = 1; j < 9; j++)
                        {
                            if (dou_temp < val_set[i - j, 0])
                            {
                                dou_temp = val_set[i - j, 0];
                            }
                            if (dou_temp_2 > val_set[i - j, 1])
                            {
                                dou_temp_2 = val_set[i - j, 1];
                            }

                        }

                        RSV[i] = (val_set[i, 3] - dou_temp_2) / (dou_temp - dou_temp_2);
                    }
                    catch
                    {
                        RSV[i] = 0.5;
                    }

                    //KD
                    try
                    {
                        KD_K[i] = (2.0 / 3) * KD_K[i - 1] + (1.0 / 3) * RSV[i];
                        KD_D[i] = (2.0 / 3) * KD_D[i - 1] + (1.0 / 3) * KD_K[i];
                    }
                    catch
                    {
                        KD_K[i] = 0.5;
                        KD_D[i] = 0.5;
                    }
                    chart.Series["KD_K"].Points.AddXY(str_set[i], KD_K[i]);
                    chart.Series["KD_D"].Points.AddXY(str_set[i], KD_D[i]);
                }

                {   //MACD
                    dou_temp = (val_set[i, 0] + val_set[i, 1] + 2 * val_set[i, 3]) / 4; //P
                    try
                    {
                        EMA_12[i] = EMA_12[i - 1] + (2.0 / 13) * (dou_temp - EMA_12[i - 1]);
                        EMA_26[i] = EMA_26[i - 1] + (2.0 / 27) * (dou_temp - EMA_26[i - 1]);
                    }
                    catch
                    {
                        EMA_12[i] = val_set[i, 3] + (2.0 / 13) * (dou_temp - val_set[i, 3]);
                        EMA_26[i] = val_set[i, 3] + (2.0 / 27) * (dou_temp - val_set[i, 3]);
                    }

                    dou_temp_2 = EMA_26[i] - EMA_12[i];//DIF
                    try
                    {
                        MACD[i] = MACD[i - 1] + (2.0 / 10) * (dou_temp_2 - MACD[i - 1]);
                    }
                    catch
                    {
                        MACD[i] = dou_temp_2;
                    }

                    chart.Series["DIF"].Points.AddXY(str_set[i], dou_temp_2);
                    chart.Series["MACD"].Points.AddXY(str_set[i], MACD[i]);
                    chart.Series["OSC"].Points.AddXY(str_set[i], dou_temp_2 - MACD[i]);

                    if (dou_temp_2 - MACD[i] > 0)
                    {
                        chart.Series["OSC"].Points[i].Color = System.Drawing.Color.Red;
                    }
                    else if (dou_temp_2 - MACD[i] < 0)
                    {
                        chart.Series["OSC"].Points[i].Color = System.Drawing.Color.Green;
                    }
                    else
                    {
                        chart.Series["OSC"].Points[i].Color = System.Drawing.Color.Gray;
                    }

                }

            }

            scroll_blockSize = Convert.ToInt32(nud4.Value);
            //chartArea_K.AxisY.Minimum = Math.Round(chart.Series["K"].Points.FindMinByValue().YValues[1]);
            //chartArea_K.AxisY.Maximum = Math.Round(chart.Series["K"].Points.FindMaxByValue().YValues[0]);
            chartArea_Vol.AxisY.Minimum = 0;
            //chartArea_Vol.AxisY.Maximum = 100;
            chartArea_K.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_K.AxisX.ScaleView.SmallScrollSize = scroll_blockSize;
            chartArea_Vol.AxisX.ScrollBar.Enabled = false;
            chartArea_Vol.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_Vol.AxisX.ScaleView.SmallScrollSize = scroll_blockSize;
            chartArea_KD.AxisX.ScrollBar.Enabled = false;
            chartArea_KD.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_KD.AxisX.ScaleView.SmallScrollSize = scroll_blockSize;
            chartArea_MACD.AxisX.ScrollBar.Enabled = false;
            chartArea_MACD.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_MACD.AxisX.ScaleView.SmallScrollSize = scroll_blockSize;

            tb.Controls.Add(chart);

            //Tt.ReshowDelay = 500;
        }

        private void nud_change(object sender, EventArgs e)
        {
            charting(Convert.ToInt32(nud1.Value), Convert.ToInt32(nud2.Value), Convert.ToInt32(nud3.Value));
            scroll_blockSize = Convert.ToInt32(nud4.Value);
            chartArea_K.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_Vol.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_KD.AxisX.ScaleView.Zoom(0, scroll_blockSize);
            chartArea_MACD.AxisX.ScaleView.Zoom(0, scroll_blockSize);
        }

        private void chData_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            chartArea_K.CursorX.SetCursorPixelPosition(mousePoint, true);
            chartArea_K.CursorY.SetCursorPixelPosition(mousePoint, true);
            chartArea_Vol.CursorX.SetCursorPixelPosition(mousePoint, true);
            chartArea_KD.CursorX.SetCursorPixelPosition(mousePoint, true);
            chartArea_MACD.CursorX.SetCursorPixelPosition(mousePoint, true);

            chartArea_K.CursorX.SetCursorPixelPosition(new Point(e.X, e.Y), true);

            if (pX != chartArea_K.CursorX.Position)
            {
                pX = chartArea_K.CursorX.Position;
                try
                {
                    if (val_set[Convert.ToInt32(pX) - 1, 2] > val_set[Convert.ToInt32(pX) - 1, 3])
                    {
                        Tt.Show(str_set[Convert.ToInt32(pX) - 1] + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 4].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 6].ToString() + "   " + val_set[Convert.ToInt32(pX) - 1, 7].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 5].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 8].ToString() + "  ↓", this.chart, 60, 10);
                    }
                    else if (val_set[Convert.ToInt32(pX) - 1, 2] < val_set[Convert.ToInt32(pX) - 1, 3])
                    {
                        Tt.Show(str_set[Convert.ToInt32(pX) - 1] + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 4].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 6].ToString() + "   " + val_set[Convert.ToInt32(pX) - 1, 7].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 5].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 8].ToString() + "  ↑", this.chart, 60, 10);
                    }
                    else
                    {
                        Tt.Show(str_set[Convert.ToInt32(pX) - 1] + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 4].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 6].ToString() + "   " + val_set[Convert.ToInt32(pX) - 1, 7].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 5].ToString()
                                                            + "\r\n" + val_set[Convert.ToInt32(pX) - 1, 8].ToString() + "  -", this.chart, 60, 10);
                    }
                }
                catch { }
            }

        }

        private void chart_onclick(object sender, EventArgs e)
        {
            chartArea_Vol.AxisX.ScaleView.Position = chartArea_K.AxisX.ScaleView.Position;
            chartArea_KD.AxisX.ScaleView.Position = chartArea_K.AxisX.ScaleView.Position;
            chartArea_MACD.AxisX.ScaleView.Position = chartArea_K.AxisX.ScaleView.Position;
        }


        //private void chData_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Delta < 0)
        //        {
        //            chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
        //            chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
        //        }

        //        if (e.Delta > 0)
        //        {
        //            double xMin = chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
        //            double xMax = chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
        //            double yMin = chart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
        //            double yMax = chart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

        //            double posXStart = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / 4;
        //            double posXFinish = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / 4;
        //            double posYStart = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / 4;
        //            double posYFinish = chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / 4;

        //            chart.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
        //            chart.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
        //        }
        //    }
        //    catch { }
        //}

        private void charting(int MA_s, int MA_m, int MA_l)
        {
            int i, j;

            chart.Series["MA_short"].Points.Clear();
            chart.Series["MA_middle"].Points.Clear();
            chart.Series["MA_long"].Points.Clear();


            for (i = 0; i < val_set.Length / 5 - 1; i++)
            {


                if (i > MA_s && i< val_set.Length / 5)
                {
                    dou_temp = 0;
                    for (j = 0; j < MA_s; j++)
                    {
                        dou_temp = dou_temp + val_set[i - j, 3];
                    }
                    dou_temp = dou_temp / MA_s;
                    chart.Series["MA_short"].Points.AddXY(str_set[i], dou_temp);
                }
                else
                {
                    chart.Series["MA_short"].Points.AddXY(str_set[i], 0);
                }

                if (i > MA_m && i< val_set.Length / 5)
                {
                    dou_temp = 0;
                    for (j = 0; j < MA_m; j++)
                    {
                        dou_temp = dou_temp + val_set[i - j, 3];
                    }
                    dou_temp = dou_temp / MA_m;
                    chart.Series["MA_middle"].Points.AddXY(str_set[i], dou_temp);
                }
                else
                {
                    chart.Series["MA_middle"].Points.AddXY(str_set[i], 0);
                }

                if (i > MA_l && i< val_set.Length / 5)
                {
                    dou_temp = 0;
                    for (j = 0; j < MA_l; j++)
                    {
                        dou_temp = dou_temp + val_set[i - j, 3];
                    }
                    dou_temp = dou_temp / MA_l;
                    chart.Series["MA_long"].Points.AddXY(str_set[i], dou_temp);
                }
                else
                {
                    chart.Series["MA_long"].Points.AddXY(str_set[i], 0);
                }
            }

        }
    }

    class Stocks
    {
        private TabPage tb = new TabPage();
        private WebClient wc = new WebClient();
        private char[] comma = { ',' };
        private string[] str_set_d;
        private double[,] val_set_d;
        private string[] str_set_w;
        private double[,] val_set_w;
        private string[] str_set_m;
        private double[,] val_set_m;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private bool write_flag = false;
        
        public Stocks(TabControl Main_tc, int stock_num,
									    int s_d_MA, int m_d_MA, int l_d_MA, 
									    int w_MA,
									    int s_m_MA, int m_m_MA, int l_m_MA)
	    {
            
            tb.Name = Convert.ToString(stock_num);
            tb.Text = Convert.ToString(stock_num);
            tb.Dock = DockStyle.Fill;
            Main_tc.TabPages.Add(tb);

            TabControl tc = new TabControl();
            tc.Dock = DockStyle.Fill;
            tb.Controls.Add(tc);

            get_data_from_yahoo(stock_num);

            Tabs_d tb_d = new Tabs_d(tc, str_set_d, val_set_d, s_d_MA, m_d_MA, l_d_MA);
            Tabs_w tb_w = new Tabs_w(tc, str_set_w, val_set_w, w_MA);
            Tabs_m tb_m = new Tabs_m(tc, str_set_m, val_set_m, s_m_MA, m_m_MA, l_m_MA);
	    }


        private void get_data_from_yahoo(int stock_num)
        { 
            WebClient wc = new WebClient();
            int j=0;
            int d_count=0;
            int w_count = 1;
            int m_count = 1;
            int temp_shift=0;

            

            DS.Tables.Add(DT);
            DT.TableName = "Days";
            DT.Columns.Add("Date");
            DT.Columns.Add("Open");
            DT.Columns.Add("High");
            DT.Columns.Add("Low");
            DT.Columns.Add("Close");
            DT.Columns.Add("Volume");
            DT.Columns.Add("Adj Close");

            try
            {
                wc.DownloadFile("http://ichart.finance.yahoo.com/table.csv?s=" + Convert.ToString(stock_num) + ".TW&t=00&c=2013&g=d&ignore=.csv", "temp.csv");
                write_flag = true;
            }
            catch 
            {
                try
                {
                    wc.DownloadFile("http://ichart.finance.yahoo.com/table.csv?s=" + Convert.ToString(stock_num) + ".TWO&t=00&c=2013&g=d&ignore=.csv", "temp.csv");
                    write_flag = true;
                }

                catch { }
            }

            if(write_flag==true)
            {
                File.Copy("temp.csv", Convert.ToString(stock_num) + ".csv", true);
            }


            using (StreamReader sr = new StreamReader(Convert.ToString(stock_num) + ".csv"))
            {
                string item;
                string[] arr;
                int count = 0;
                while ((item = sr.ReadLine()) != null)
                {
                    if (count == 0)
                    {
                        count = 1;
                    }
                    else
                    {
                        arr = item.Split(',');
                        DS.Tables["Days"].Rows.Add(arr);
                    }

                }
            }

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                if (Convert.ToDouble(DT.Rows[i]["Volume"]) != 0) 
                {
                    d_count++;
                }
            }

            //day
            str_set_d = new string[d_count];
            val_set_d = new double[d_count, 9];

            for (int i = 0; i < DT.Rows.Count; i++)
            {

                if (Convert.ToDouble(DT.Rows[DT.Rows.Count - i - 1]["Volume"]) != 0)
                {
                    str_set_d[i - temp_shift] = Convert.ToString(DT.Rows[DT.Rows.Count - i - 1]["Date"]);
                    val_set_d[i - temp_shift, 0] = Convert.ToDouble(DT.Rows[DT.Rows.Count - i - 1]["High"]);
                    val_set_d[i - temp_shift, 1] = Convert.ToDouble(DT.Rows[DT.Rows.Count - i - 1]["Low"]);
                    val_set_d[i - temp_shift, 2] = Convert.ToDouble(DT.Rows[DT.Rows.Count - i - 1]["Open"]);
                    val_set_d[i - temp_shift, 3] = Convert.ToDouble(DT.Rows[DT.Rows.Count - i - 1]["Close"]);
                    val_set_d[i - temp_shift, 7] = Convert.ToDouble(DT.Rows[DT.Rows.Count - i - 1]["Adj Close"]);
                    val_set_d[i - temp_shift, 8] = Convert.ToDouble(DT.Rows[DT.Rows.Count - i - 1]["Volume"]);
                    val_set_d[i - temp_shift, 4] = val_set_d[i - temp_shift, 0] - val_set_d[i - temp_shift, 3] + val_set_d[i - temp_shift, 7];
                    val_set_d[i - temp_shift, 5] = val_set_d[i - temp_shift, 1] - val_set_d[i - temp_shift, 3] + val_set_d[i - temp_shift, 7];
                    val_set_d[i - temp_shift, 6] = val_set_d[i - temp_shift, 2] - val_set_d[i - temp_shift, 3] + val_set_d[i - temp_shift, 7];

                    //if (Convert.ToDouble(DT.Rows[DT.Rows.Count - i - 1]["Volume"]) / 10000000 > 100)
                    //{
                    //    val_set_d[i - temp_shift, 8] = 100;
                    //}
                    //else
                    //{
                    //    val_set_d[i - temp_shift, 8] = Convert.ToDouble(DT.Rows[DT.Rows.Count - i - 1]["Volume"]) / 10000000;
                    //}
                    
                }
                else
                {
                    temp_shift++;
                }
                
                
                //0=high,1=low,2=open,3=close,4=adj_high,5=adj_low,6=adj_open,7=adj_close,8=volume
            }
            //week
            int[] weekday_arr = new int[d_count];
            for (int i = 0; i < d_count; i++)
            {
                
                if ((Convert.ToDateTime(str_set_d[i])).ToString("ddd") == "週日")
                {
                    weekday_arr[i] = 0;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("ddd") == "週一")
                {
                    weekday_arr[i] = 1;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("ddd") == "週二")
                {
                    weekday_arr[i] = 2;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("ddd") == "週三")
                {
                    weekday_arr[i] = 3;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("ddd") == "週四")
                {
                    weekday_arr[i] = 4;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("ddd") == "週五")
                {
                    weekday_arr[i] = 5;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("ddd") == "週六")
                {
                    weekday_arr[i] = 6;
                }
            }
            for (int i = 1; i < d_count; i++)
            { 
                
                if (weekday_arr[i] <= weekday_arr[i - 1])
                {
                    w_count = w_count + 1;
                }
            }
            //doggy
            str_set_w = new string[w_count];
            val_set_w = new double[w_count, 5];
            j = 0;
            double temp_high=0;
            double temp_low=0;
            double temp_vol = 0;
            //0=adj_high,1=adj_low,2=adj_open,3=adj_close,4=volume
            for (int i = 0; i < d_count; i++)
            {
                if(temp_high==0)
                {
                    temp_high = val_set_d[i, 4];
                    temp_low = val_set_d[i, 5];
                    str_set_w[j] = str_set_d[i];
                    val_set_w[j, 2] = val_set_d[i,6];
                    temp_vol = val_set_d[i, 8];

                    if (i == d_count - 1)
                    {
                        val_set_w[j, 0] = temp_high;
                        val_set_w[j, 1] = temp_low;
                        val_set_w[j, 3] = val_set_d[i, 7];
                        val_set_w[j, 4] = temp_vol;
                        j++;
                        temp_high = 0;
                        temp_low = 0;
                        temp_vol = 0;
                        break;
                    }
                }
                else
                {
                    if(temp_high<val_set_d[i, 4])
                    {
                        temp_high = val_set_d[i, 4];
                    }
                    if(temp_low>val_set_d[i, 5])
                    {
                        temp_low = val_set_d[i, 5];
                    }
                    temp_vol = temp_vol + val_set_d[i, 8];

                    if (i == d_count - 1)
                    {
                        val_set_w[j, 0] = temp_high;
                        val_set_w[j, 1] = temp_low;
                        val_set_w[j, 3] = val_set_d[i, 7];
                        val_set_w[j, 4] = temp_vol;
                        j++;
                        temp_high = 0;
                        temp_low = 0;
                        temp_vol = 0;
                        break;
                    }


                    if (weekday_arr[i] >= weekday_arr[i + 1])
                    {
                        val_set_w[j, 0] = temp_high;
                        val_set_w[j, 1] = temp_low;
                        val_set_w[j, 3] = val_set_d[i, 7];
                        val_set_w[j, 4] = temp_vol;
                        j++;
                        temp_high = 0;
                        temp_low = 0;
                        temp_vol = 0;
                    }
                }

            }

            //month
            int[] month_arr = new int[d_count];
            for (int i = 0; i < d_count; i++)
            {

                if ((Convert.ToDateTime(str_set_d[i])).ToString("MMM") == "一月")
                {
                    month_arr[i] = 1;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("MMM") == "二月")
                {
                    month_arr[i] = 2;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("MMM") == "三月")
                {
                    month_arr[i] = 3;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("MMM") == "四月")
                {
                    month_arr[i] = 4;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("MMM") == "五月")
                {
                    month_arr[i] = 5;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("MMM") == "六月")
                {
                    month_arr[i] = 6;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("MMM") == "七月")
                {
                    month_arr[i] = 7;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("MMM") == "八月")
                {
                    month_arr[i] = 8;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("MMM") == "九月")
                {
                    month_arr[i] = 9;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("MMM") == "十月")
                {
                    month_arr[i] = 10;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("MMM") == "十一月")
                {
                    month_arr[i] = 11;
                }
                else if ((Convert.ToDateTime(str_set_d[i])).ToString("MMM") == "十二月")
                {
                    month_arr[i] = 12;
                }

            }
            for (int i = 1; i < d_count; i++)
            {

                if (month_arr[i] != month_arr[i - 1])
                {
                    m_count = m_count + 1;
                }
            }

            str_set_m = new string[m_count];
            val_set_m = new double[m_count, 5];
            j = 0;
            temp_high = 0;
            temp_low = 0;
            temp_vol = 0;
            //0=adj_high,1=adj_low,2=adj_open,3=adj_close,4=volume
            for (int i = 0; i < d_count; i++)
            {
                if (temp_high == 0)
                {
                    temp_high = val_set_d[i, 4];
                    temp_low = val_set_d[i, 5];
                    str_set_m[j] = str_set_d[i];
                    val_set_m[j, 2] = val_set_d[i, 6];
                    temp_vol = val_set_d[i, 8];

                    if (i == d_count - 1)
                    {
                        val_set_m[j, 0] = temp_high;
                        val_set_m[j, 1] = temp_low;
                        val_set_m[j, 3] = val_set_d[i, 7];
                        val_set_m[j, 4] = temp_vol;
                        j++;
                        temp_high = 0;
                        temp_low = 0;
                        temp_vol = 0;
                        break;
                    }
                }
                else
                {
                    if (temp_high < val_set_d[i, 4])
                    {
                        temp_high = val_set_d[i, 4];
                    }
                    if (temp_low > val_set_d[i, 5])
                    {
                        temp_low = val_set_d[i, 5];
                    }
                    temp_vol = temp_vol + val_set_d[i, 8];

                    if (i == d_count - 1)
                    {
                        val_set_m[j, 0] = temp_high;
                        val_set_m[j, 1] = temp_low;
                        val_set_m[j, 3] = val_set_d[i, 7];
                        val_set_m[j, 4] = temp_vol/10;
                        j++;
                        temp_high = 0;
                        temp_low = 0;
                        temp_vol = 0;
                        break;
                    }


                    if (month_arr[i] != month_arr[i + 1])
                    {
                        val_set_m[j, 0] = temp_high;
                        val_set_m[j, 1] = temp_low;
                        val_set_m[j, 3] = val_set_d[i, 7];
                        val_set_m[j, 4] = temp_vol/10;
                        j++;
                        temp_high = 0;
                        temp_low = 0;
                        temp_vol = 0;
                    }
                }

            }


            //vol adjust
            temp_high = 5; //multi of avg
            temp_vol = 0;
            for(int i=0;i<d_count;i++)
            {
                temp_vol = temp_vol + val_set_d[i, 8];
            }
            temp_vol = temp_vol / d_count;
            for (int i = 0; i < d_count; i++)
            {
                if (val_set_d[i, 8] > temp_high * temp_vol)
                {
                    val_set_d[i, 8] = temp_high * temp_vol;
                }
                val_set_d[i, 8] = val_set_d[i, 8] / temp_vol * (100 / temp_high);
            }

            for (int i = 0; i < w_count; i++)
            {
                temp_vol = temp_vol + val_set_w[i, 4];
            }
            temp_vol = temp_vol / w_count;
            for (int i = 0; i < w_count; i++)
            {
                if (val_set_w[i, 4] > temp_high * temp_vol)
                {
                    val_set_w[i, 4] = temp_high * temp_vol;
                }
                val_set_w[i, 4] = val_set_w[i, 4] / temp_vol * (100 / temp_high);
            }

            for (int i = 0; i < m_count; i++)
            {
                temp_vol = temp_vol + val_set_m[i, 4];
            }
            temp_vol = temp_vol / m_count;
            for (int i = 0; i < m_count; i++)
            {
                if (val_set_m[i, 4] > temp_high * temp_vol)
                {
                    val_set_m[i, 4] = temp_high * temp_vol;
                }
                val_set_m[i, 4] = val_set_m[i, 4] / temp_vol * (100 / temp_high);
            }
        }


        //private void get_data_from_google(int stock_num)
        //{
        //    int i;
        //    wc1.DownloadFile("http://www.google.com/finance/getprices?q=" + Convert.ToString(stock_num) + "&x=TPE&i=86400&p=1Y&f=d,c,h,l,o,v", Convert.ToString(stock_num) + ".txt");
        //    using (StreamReader sr = new StreamReader(Convert.ToString(stock_num) + ".txt", System.Text.Encoding.Default))
        //    {
        //        data_all = sr.ReadToEnd();
        //    }
        //    str_temp = data_all.Substring(143);
        //    data_row = str_temp.Split(Environment.NewLine.ToCharArray());
        //    data_set_d = new double[data_row.Length, 4];
        //    for (i = 0; i < data_row.Length - 1; i++)
        //    {
        //        str_temp = data_row[i];
        //        data_word = str_temp.Split(comma);

        //        data_set_d[i, 0] = Convert.ToDouble(data_word[2]);
        //        data_set_d[i, 1] = Convert.ToDouble(data_word[3]);
        //        data_set_d[i, 2] = Convert.ToDouble(data_word[4]);
        //        data_set_d[i, 3] = Convert.ToDouble(data_word[1]);
        //    }
        //}

    }


}
