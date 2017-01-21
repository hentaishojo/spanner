using System;
using System.Windows.Forms;
using NAudio.Wave;

namespace WaveAnalyzer
{
    public partial class NAudioT05 : Form
    {
        public NAudioT05()
        {
            InitializeComponent();
        }

        private DirectSoundOut output = null;

        private BlockAlignReductionStream stream = null;

        private void NAudioT05_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "WAV|*.wav";
            if (open.ShowDialog() != DialogResult.OK) return;

            //WaveChannel32 wave = new
        }
    }
}
