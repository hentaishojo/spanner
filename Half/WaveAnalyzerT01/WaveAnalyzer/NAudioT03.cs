using NAudio.Wave;
using System;
using System.Windows.Forms;

namespace WaveAnalyzer
{
    public partial class NAudioT03 : Form
    {
        public NAudioT03()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "MP3|*.mp3;";
            if (open.ShowDialog() != DialogResult.OK) return;

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "WAV|*.wav";
            if (save.ShowDialog() != DialogResult.OK) return;

            using(Mp3FileReader mp3 = new Mp3FileReader(open.FileName))
            {
                using(WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(save.FileName, pcm);
                }
            }
        }
    }
}
