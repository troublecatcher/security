using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Text;
using System.IO;
using System.Security;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Steganography
{
    /// <summary>
    /// Summary description for SteganographyForm.
    /// </summary>
	public class SteganographyForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonHideMessage;
		private System.Windows.Forms.TextBox textBoxOriginalMessage;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button buttonExtractMessage;
		private System.Windows.Forms.TextBox textBoxExtractedlMessage;
		private System.Windows.Forms.GroupBox groupBox2;
        private GroupBox groupBox5;
        private TextBox textBox1;
        private GroupBox groupBox6;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Button button3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public SteganographyForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.buttonHideMessage = new System.Windows.Forms.Button();
            this.textBoxOriginalMessage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonExtractMessage = new System.Windows.Forms.Button();
            this.textBoxExtractedlMessage = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonHideMessage
            // 
            this.buttonHideMessage.Location = new System.Drawing.Point(261, 553);
            this.buttonHideMessage.Name = "buttonHideMessage";
            this.buttonHideMessage.Size = new System.Drawing.Size(102, 111);
            this.buttonHideMessage.TabIndex = 0;
            this.buttonHideMessage.Text = "Сокрыть";
            this.buttonHideMessage.Visible = false;
            this.buttonHideMessage.Click += new System.EventHandler(this.buttonHideMessage_Click);
            // 
            // textBoxOriginalMessage
            // 
            this.textBoxOriginalMessage.Location = new System.Drawing.Point(6, 24);
            this.textBoxOriginalMessage.Name = "textBoxOriginalMessage";
            this.textBoxOriginalMessage.Size = new System.Drawing.Size(200, 20);
            this.textBoxOriginalMessage.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxOriginalMessage);
            this.groupBox1.Location = new System.Drawing.Point(20, 542);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 58);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ввод";
            this.groupBox1.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 456);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Оригинальное изображение";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(348, 431);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Location = new System.Drawing.Point(380, 49);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(360, 456);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Измененное изображение";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(6, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(348, 431);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // buttonExtractMessage
            // 
            this.buttonExtractMessage.Location = new System.Drawing.Point(625, 553);
            this.buttonExtractMessage.Name = "buttonExtractMessage";
            this.buttonExtractMessage.Size = new System.Drawing.Size(106, 111);
            this.buttonExtractMessage.TabIndex = 2;
            this.buttonExtractMessage.Text = "Раскрыть";
            this.buttonExtractMessage.Visible = false;
            this.buttonExtractMessage.Click += new System.EventHandler(this.buttonExtractMessage_Click);
            // 
            // textBoxExtractedlMessage
            // 
            this.textBoxExtractedlMessage.Location = new System.Drawing.Point(8, 24);
            this.textBoxExtractedlMessage.Name = "textBoxExtractedlMessage";
            this.textBoxExtractedlMessage.ReadOnly = true;
            this.textBoxExtractedlMessage.Size = new System.Drawing.Size(200, 20);
            this.textBoxExtractedlMessage.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxExtractedlMessage);
            this.groupBox2.Location = new System.Drawing.Point(380, 606);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 58);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вывод";
            this.groupBox2.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Location = new System.Drawing.Point(20, 606);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(219, 58);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Пароль";
            this.groupBox5.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox2);
            this.groupBox6.Location = new System.Drawing.Point(380, 542);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(232, 58);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Пароль";
            this.groupBox6.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(360, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Загрузить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(378, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(360, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Загрузить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(378, 511);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(360, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Скачать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SteganographyForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(744, 673);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.buttonHideMessage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.buttonExtractMessage);
            this.Name = "SteganographyForm";
            this.Text = "Steganography";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SteganographyForm_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
	{
			Application.Run(new SteganographyForm());
		}

		private void SteganographyForm_Paint(
			object sender, 
			System.Windows.Forms.PaintEventArgs e)
		{
			
		}

		private void buttonHideMessage_Click(
			object sender, System.EventArgs e)
		{
			try
			{
                String encrypted = enc.EncryptData(textBoxOriginalMessage.Text, textBox1.Text);
                //show wait cursor
                this.Cursor = Cursors.WaitCursor;

				//start off with copy of original image
				bitmapModified = new Bitmap(
					bitmapOriginal, 
					bitmapOriginal.Width, 
					bitmapOriginal.Height);

				//get original message to be hidden
				int numberbytes = 
					(byte)encrypted.Length*2;
				byte[] bytesOriginal = new byte[numberbytes+1];
				bytesOriginal[0] = (byte)numberbytes;

				

                Encoding.UTF8.GetBytes(
					encrypted,
					0,
                    encrypted.Length,
					bytesOriginal,
					1);

				//set bits 1, 2, 3 of byte into LSB red
				//set bits 4, 5, 6 of byte into LSB green
				//set bits 7 and 8 of byte into LSB blue
				int byteCount = 0;
				for (int i=0; i<bitmapOriginal.Width; i++)
				{
					for (int j=0; j<bitmapOriginal.Height; j++)
					{
						if (bytesOriginal.Length==byteCount)
							return;

						Color clrPixelOriginal = 
							bitmapOriginal.GetPixel(i, j);
						byte r = 
							(byte)((clrPixelOriginal.R & ~0x7) |
							(bytesOriginal[byteCount]>>0)&0x7);
						byte g = 
							(byte)((clrPixelOriginal.G & ~0x7) |
							(bytesOriginal[byteCount]>>3)&0x7);
						byte b = 
							(byte)((clrPixelOriginal.B & ~0x3) |
							(bytesOriginal[byteCount]>>6)&0x3);
						byteCount++;

						//set pixel to modified color
						bitmapModified.SetPixel(
							i, j, Color.FromArgb(r, g, b));
					}

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error hiding message." +
					ex.Message);
			}
			finally
			{
				//show normal cursor
				this.Cursor = Cursors.Arrow;
                pictureBox2.Image = bitmapModified;
                groupBox6.Visible = true;
                groupBox2.Visible = true;
                button3.Visible = true;
                buttonExtractMessage.Visible = true;
                //repaint
                Invalidate();
			}
		}

		private void buttonExtractMessage_Click(
			object sender, System.EventArgs e)
		{
			//get bytes of message from modified image
			byte[] bytesExtracted = new byte [256+1];
			try
			{
				//show wait cursor, can be time-consuming
				this.Cursor = Cursors.WaitCursor;
				
				//get bits 1, 2, 3 of byte from LSB red
				//get bits 4, 5, 6 of byte from LSB green
				//get bits 7 and 8 of byte from LSB blue
				int byteCount = 0;
				for (int i=0; i<bitmapModified.Width; i++)
				{
					for (int j=0; j<bitmapModified.Height; j++)
					{
						if (bytesExtracted.Length==byteCount)
							return;

						Color clrPixelModified = 
							bitmapModified.GetPixel(i, j);
						byte bits123 = 
							(byte)((clrPixelModified.R&0x7)<<0);
						byte bits456 = (
							byte)((clrPixelModified.G&0x7)<<3);
						byte bits78  = (
							byte)((clrPixelModified.B&0x3)<<6);
					
						bytesExtracted[byteCount] = 
							(byte)(bits78 |bits456 | bits123);
						byteCount++;
					}

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					"Error extracting message." +
					ex.Message);
			}
			finally
			{
				//show normal cursor
				this.Cursor = Cursors.Arrow;

				//get number of bytes from start of array
				int numberbytes = bytesExtracted[0];

				//get remaining bytes in array into string
				var extracted = Encoding.UTF8.GetString(
					bytesExtracted,
					1,
					numberbytes);
				textBoxExtractedlMessage.Text = extracted;
				extracted = textBoxExtractedlMessage.Text;

                textBoxExtractedlMessage.Text =  
					enc.DecryptData(extracted, textBox2.Text);
			}		
		}

		//shared private fields
		private Bitmap bitmapOriginal;
		private Bitmap bitmapModified;
        RijndaelNs.AspRijndael enc = new RijndaelNs.AspRijndael();

        private void button1_Click(object sender, EventArgs e)
        {
			var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var bm = new Bitmap(ofd.FileName);
                bitmapOriginal = bm;
                pictureBox1.Image = bitmapOriginal;

                groupBox1.Visible = true;
                groupBox5.Visible = true;
                buttonHideMessage.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var bm = new Bitmap(ofd.FileName);
                bitmapModified = bm;
                pictureBox2.Image = bitmapModified;

                groupBox2.Visible = true;
                groupBox6.Visible = true;
                buttonExtractMessage.Visible = true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "bmp files (*.bmp)|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                bitmapModified.Save(sfd.FileName, ImageFormat.Bmp);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "bmp files (*.bmp)|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                bitmapOriginal.Save(sfd.FileName, ImageFormat.Jpeg);
            }
        }
    }
}
