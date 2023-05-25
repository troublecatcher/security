using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AudioSteganographyClass1
{
    public partial class Form1 : Form
    {
        string initPath;
        string stegPath;
        string message;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            message = textBox1.Text.ToString();

            WaveAudio file = new WaveAudio(new FileStream(initPath, FileMode.Open, FileAccess.Read));
            var leftStream = file.GetLeftStream();
            var rightStream = file.GetRightStream();
            byte[] bufferMessage = System.Text.Encoding.UTF8.GetBytes(message);
            short tempBit;
            int bufferIndex = 0;
            int bufferLength = bufferMessage.Length;
            int channelLength = leftStream.Count;
            int storageBlock = (int)Math.Ceiling((double)bufferLength / (channelLength * 2));
            leftStream[0] = (short)(bufferLength / 32767);
            rightStream[0] = (short)(bufferLength % 32767);
            for (int i = 1; i < leftStream.Count; i++)
            {
                if (i < leftStream.Count)
                {
                    if (bufferIndex < bufferLength && i % 8 > 7 - storageBlock && i % 8 <= 7)
                    {
                        tempBit = (short)bufferMessage[bufferIndex++];
                        leftStream.Insert(i, tempBit);
                    }
                }
                if (i < rightStream.Count)
                {
                    if (bufferIndex < bufferLength && i % 8 > 7 - storageBlock && i % 8 <= 7)
                    {
                        tempBit = (short)bufferMessage[bufferIndex++];
                        rightStream.Insert(i, tempBit);
                    }
                }
            }

            file.UpdateStreams(leftStream, rightStream);
            var sfd = new SaveFileDialog();
            sfd.Filter = "wav files (*.wav)|*.wav";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Success!");
                file.WriteFile(sfd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WaveAudio file = new WaveAudio(new FileStream(stegPath, FileMode.Open, FileAccess.Read));
            List<short> leftStream = file.GetLeftStream();
            List<short> rightStream = file.GetRightStream();
            int bufferIndex = 0;
            int messageLengthQuotient = leftStream[0];
            int messageLengthRemainder = rightStream[0];
            int channelLength = leftStream.Count;

            int bufferLength = 32767 * messageLengthQuotient + messageLengthRemainder;
            int storageBlock = (int)Math.Ceiling((double)bufferLength / (channelLength * 2));

            byte[] bufferMessage = new byte[bufferLength];
            for (int i = 1; i < leftStream.Count; i++)
            {
                if (bufferIndex < bufferLength && i % 8 > 7 - storageBlock && i % 8 <= 7)
                {
                    bufferMessage[bufferIndex++] = (byte)leftStream[i];
                    if (bufferIndex < bufferLength)
                        bufferMessage[bufferIndex++] = (byte)rightStream[i];
                }
            }

            textBox2.Text = Encoding.UTF8.GetString(bufferMessage);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                initPath = ofd.FileName;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                stegPath = ofd.FileName;
            }
        }
    }
}
