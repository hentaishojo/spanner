using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WaveAnalyzer
{
    public partial class BaseAudio : Form
    {
        long length;
        long dataLength;
        byte[] headIn;
        byte[] dataIn;
        byte[] bufferOut;
        byte[] headOut;
        byte[] dataOut;


        public BaseAudio()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
        }

        private void WavIN(string spath)
        {
            FileStream fs = new FileStream(spath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            length = fs.Length;
            dataLength = length - 44;

            headIn = new byte[44];
            dataIn = new byte[dataLength];
            
            for (int i = 0; i < 44; i++)
            {
                headIn[i] = br.ReadByte();
            }

            for (int i = 0; i < dataLength; i++)
            {
                dataIn[i] = br.ReadByte();
            }
        }

        private void WavOUT(string spath)
        {
            FileStream fs = new FileStream(spath, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(headOut);
            bw.Write(dataOut);
            bw.Close();
            fs.Close();
        }

        private void HeadTransfer()
        {
            headOut = new byte[44];
            for (int i = 0; i < 44; i++)
            {
                headOut[i] = headIn[i];
            }
        }

        private void DataTransfer()
        {
            dataOut = new byte[dataLength];
            for (int i = 0; i < dataLength; i++)
            {
                dataOut[i] = dataIn[i];
            }
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            WavIN("test.wav");
            
        }

        private void OutBtn_Click(object sender, EventArgs e)
        {
            WavOUT("out.wav");
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            HeadTransfer();
            DataTransfer();

            bufferOut = new byte[length];

            for (int i = 0; i < 44; i++)
            {
                bufferOut[i] = headIn[i];
            }

            for (int i = 0; i < 10000; i++)
            {
                bufferOut[i+44] = dataIn[i];
            }

            using (MemoryStream ms = new MemoryStream(bufferOut))
            {
                
                SoundPlayer player = new SoundPlayer(ms);
                player.Play();
            }
        }
    }
}
