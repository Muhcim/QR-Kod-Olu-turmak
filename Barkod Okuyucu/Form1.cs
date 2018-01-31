using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace Barkod_Okuyucu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Image KareKodOlustur(string giris, int kkDuzey)
        {
            var deger = giris;
            MessagingToolkit.QRCode.Codec.QRCodeEncoder qe = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
            qe.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qe.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            qe.QRCodeVersion = kkDuzey;
            System.Drawing.Bitmap bm = qe.Encode(deger);
            return bm;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = KareKodOlustur(textBox1.Text, 4);
            }
            catch 
            {

                MessageBox.Show("1Kodunuz Olusturuldu");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            QRCodeDecoder decoder = new QRCodeDecoder();
            textBox1.Text=decoder.decode(new QRCodeBitmapImage(pictureBox1.Image as Bitmap));
            MessageBox.Show("Kodunuz oluşturuldu");
        }
    } 
}
