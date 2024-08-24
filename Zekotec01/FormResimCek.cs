using AForge.Video;
using AForge.Video.DirectShow;
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

namespace Zekotec01
{
    public partial class FormResimCek : Form
    {
        private FilterInfoCollection webcam;//webcam isminde tanımladığımız değişken bilgisayara kaç kamera bağlıysa onları tutan bir dizi. 
        private VideoCaptureDevice cam;//cam ise bizim kullanacağımız aygıt.
        public byte[] donenresim { get; private set; }
        public  FormResimCek()
        {
            InitializeComponent();
        }

        private void FormResimCek_Load(object sender, EventArgs e)
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);//webcam dizisine mevcut kameraları dolduruyoruz.
            foreach (FilterInfo videocapturedevice in webcam)
            {
                comboBox1.Items.Add(videocapturedevice.Name);//kameraları combobox a dolduruyoruz.
            }

            if (webcam.Count>0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {

                MessageBox.Show("Kamera Bulunamdı",
                                                    "Kamera Hatası",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error,
                                                    MessageBoxDefaultButton.Button1);
                this.Close();
            }

            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();//kamerayı başlatıyoruz.


        }

        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();//kısaca bu eventta kameradan alınan görüntüyü picturebox a atıyoruz.
            pictureBox1.Image = bit;
        }


        private void button_Cek_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;//foto çek denildiği zaman picturebox1 taki o an ki görüntüyü picturebox2 ye atıyoruz.
        }

        private void FormResimCek_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cam.IsRunning)
            {
                cam.Stop();
            }

            ImageConverter converter = new ImageConverter();
            byte[] bt = (byte[])converter.ConvertTo(pictureBox2.Image, typeof(byte[]));
            this.donenresim = bt;

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cam !=null && cam.IsRunning)
            {
                cam.Stop();
                cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
                cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
                cam.Start();//kamerayı başlatıyoruz.
            }
           
        }
    }
}
