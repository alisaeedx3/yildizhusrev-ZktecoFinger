using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Zekotec01.DAL;
using Zekotec01.DALMssql;
using Zekotec01.Models;

namespace Zekotec01
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
            this.dataGridView1.Font = new FontDialogParse().GetFont();
        }


        public zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
        private bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.

        private void Giris_Load(object sender, EventArgs e)
        {
            dateTimePicker_FromDate.Format = DateTimePickerFormat.Custom;
            dateTimePicker_FromDate.CustomFormat = "dd:MM:yyyy HH:mm:ss";

            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                var yoklamaZamaniAraligi = db.YoklamaZamani.FirstOrDefault();
               // var bitis = yoklamaZamaniAraligi.BitisSaati.AddHours(3);
                label_yoklamaAralikZamani.Text = $"{yoklamaZamaniAraligi.BaslamaSaati.ToShortTimeString()} - {yoklamaZamaniAraligi.BaslamaSaati.AddHours(yoklamaZamaniAraligi.Sure).AddMinutes(yoklamaZamaniAraligi.Dakika).ToShortTimeString()}";
            }

        }




        #region Tool Menu



        private void yeniCihazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCihazlar fr = new FormCihazlar();
            fr.ShowDialog();

        }
        #endregion


        private List<OkumaKayit> Cihazoku(DALMssql.Cihaz cihaz)
        {

            #region Değişkenler
            string sdwEnrollNumber = "";
            int idwTMachineNumber = 0;
            int idwEMachineNumber = 0;
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;

            int idwErrorCode = 0;
            int iGLCount = 0;
            int iIndex = 0;

            Cursor = Cursors.WaitCursor;
            List<OkumaKayit> yoklamalar = new List<OkumaKayit>();
            #endregion

            #region Cihaz Bağlantı

            Cursor = Cursors.WaitCursor;
            //axCZKEM1.Disconnect();              
            bIsConnected = axCZKEM1.Connect_Net(cihaz.Ip, Convert.ToInt32(cihaz.Port));
            if (bIsConnected)
            {
                iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Cihaza Bağlanılamadı, Hata kodu=" + idwErrorCode.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Cursor = Cursors.Default;
            #endregion

            axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device

            #region Log sayısı okuyeni kayıt varsa kayıtları getir

            int iValue = 0;
            if (axCZKEM1.GetDeviceStatus(iMachineNumber, 6, ref iValue) & iValue > 0) //Here we use the function "GetDeviceStatus" to get the record's count.The parameter "Status" is 6.
            {
                #region Yoklama verilerini al ve log sil

                #region yoklama verilerini çek


                if (axCZKEM1.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
                {
                    while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                               out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                    {


                        iGLCount++;
                        iIndex++;
                        OkumaKayit yoklama = new OkumaKayit();
                        yoklama.CihazUserID = int.Parse(sdwEnrollNumber);
                        yoklama.OkumaZamani = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
                        yoklama.CihazTipi = cihaz.CihazTipi;
                        yoklama.OkunanCihazId = cihaz.Id;

                        yoklamalar.Add(yoklama);


                    }

                }
                else
                {
                    Cursor = Cursors.Default;
                    axCZKEM1.GetLastError(ref idwErrorCode);

                    if (idwErrorCode != 0)
                    {
                        MessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString(), "Error");
                    }
                    else
                    {
                        MessageBox.Show("No data from terminal returns!", "Error");
                    }
                }
                #endregion


                #region logları sil
                //okuma yapılmıs ve  
                if (bIsConnected)
                {
                    //gelen kayıt var ise o makinayı sıfırla
                    if (yoklamalar.Count() > 0)
                    {
                        if (axCZKEM1.ClearGLog(iMachineNumber))
                        {
                            axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                                                                 // MessageBox.Show("All att Logs have been cleared from teiminal!", "Success");
                        }
                        else
                        {
                            axCZKEM1.GetLastError(ref idwErrorCode);
                            MessageBox.Show("Log Kayıtları Silinirken Hata Oluştu, Hata Kodu=" + idwErrorCode.ToString(), "Hata");
                        }
                    }


                }
                #endregion




                #endregion
            }
            else
            {
                //axCZKEM1.GetLastError(ref idwErrorCode);
                //MessageBox.Show("Yeni Kayıt Bulunamadı, HataKodu=" + idwErrorCode.ToString(), "Error");
            }
            #endregion

            axCZKEM1.EnableDevice(iMachineNumber, true);//enable the device
            axCZKEM1.Disconnect();
            Cursor = Cursors.Default;
            return yoklamalar;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoklamaZamani ydf;
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                ydf = db.YoklamaZamani.FirstOrDefault();
            }
            
            Cursor = Cursors.WaitCursor;
            
            Rapor rapor = new Rapor();
            rapor.date_Start = ZamanAyarlari.Rapor_date_start_Get(ydf);
            rapor.date_Stop = ZamanAyarlari.Rapor_date_stop_Get(ydf);

            List<YoklamaView> yoks = rapor.raporGetirTarihlerArasi();

            label_toplam.Text = yoks.Count().ToString();
            label_var.Text = yoks.Where(h => h.yoklama == "VAR").Count().ToString();
            label_yok.Text = yoks.Where(h => h.yoklama == "YOK").Count().ToString();
            labelizin.Text = yoks.Where(h => h.yoklama == "İZİNLİ").Count().ToString();

            yoklamagdirdguncelle(yoks.ToList());

            // dataGridView1.DataSource = yoks.ToList();
            Cursor = Cursors.Default;
        }

        private void yoklamagdirdguncelle(List<YoklamaView> yoklama)
        {
            dataGridView1.DataSource = yoklama.ToList();

            dataGridView1.Columns[0].Visible = false;
            //set autosize mode
            //grd.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //grd.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //grd.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].Width = 125;
            dataGridView1.Columns[5].Visible = false;

            dataGridView1.Columns[1].HeaderText = "ÖĞRENCİ ADI";
            dataGridView1.Columns[2].HeaderText = "YOKLAMA TARİHİ";
            dataGridView1.Columns[3].HeaderText = "OKUMA TARİHİ";
            dataGridView1.Columns[4].HeaderText = "YOKLAMA DURUMU";

       




        }

        private void günlükYoklamaAralığıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormYoklamaDefault frm = new FormYoklamaDefault();
            frm.ShowDialog();
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                var yoklamaZamaniAraligi = db.YoklamaZamani.FirstOrDefault();
                // var bitis = yoklamaZamaniAraligi.BitisSaati.AddHours(3);
                label_yoklamaAralikZamani.Text = $"{yoklamaZamaniAraligi.BaslamaSaati.ToShortTimeString()} - {yoklamaZamaniAraligi.BaslamaSaati.AddHours(yoklamaZamaniAraligi.Sure).AddMinutes(yoklamaZamaniAraligi.Dakika).ToShortTimeString()}";

            }
        }



        /// <summary>
        /// Günlük Yoklama / Bu gunun tarihlerini raporlattırır
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void günlükYoklamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (YoklamaDbEntities db2 = new YoklamaDbEntities())
            {
                var ydf2 = db2.YoklamaZamani.FirstOrDefault();

                if (ydf2 == null)
                {
                    MessageBox.Show("Günlük Yoklama Aralığı bulunamad");
                    return;
                }

                Rapor rapor = new Rapor();
                rapor.date_Start = ZamanAyarlari.Rapor_date_start_Get(ydf2);//Date_Start;
                rapor.date_Stop = ZamanAyarlari.Rapor_date_stop_Get(ydf2);// Date_Stop;
                var yoks = rapor.raporGetirTarihlerArasi();
                FormRapor frm = new FormRapor(yoks.OrderBy(h => h.yoklama).ToList());
                frm.ShowDialog();

            }
            

        }

        private void onlineYoklamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Online_İzleme frm = new Online_İzleme();
            frm.ShowDialog();
        }

        private void yoklamaVerileriniAlToolStripMenuItem_Click(object sender, EventArgs e)
        {

            

            //MyContext db = new MyContext(Helpers.GetConnection());
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                var cihazlar = db.Cihaz.ToList();

                FormCihazSec fm = new FormCihazSec(cihazlar);
                fm.ShowDialog();

                var ch = fm.cihazlarRetun;
                var TümYoklamalar = new List<OkumaKayit>();

              
                foreach (var cihaz in fm.cihazlarRetun)
                {
                    
                    TümYoklamalar.AddRange(Cihazoku(cihaz));
                }

                if (TümYoklamalar.Count() > 0)
                {
                    db.OkumaKayit.AddRange(TümYoklamalar);

                    if (db.SaveChanges() > 0)
                    {

                        MessageBox.Show("Toplam" + TümYoklamalar.Count() + " Adet Kayıt Alındı", "Yoklama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kayıt Kaydetmede Sıkıntı oluştu.", "Cihaz Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Toplam" + TümYoklamalar.Count() + " Adet Kayıt Alındı", "Yoklama", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        /// <summary>
        /// Özel Yoklama listeleme / belirtilen tarihte kişinin günlük yoklamasını getirir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                var ydf2 = db.YoklamaZamani.FirstOrDefault();

                if (ydf2 == null)
                {
                    MessageBox.Show("Günlük Yoklama Aralığı bulunamadı");
                    return;
                }

                Rapor rapor = new Rapor();
                rapor.date_Start = ZamanAyarlari.Rapor_date_start_Get(dateTimePicker_FromDate.Value,ydf2);// Date_Start;
                rapor.date_Stop = ZamanAyarlari.Rapor_date_stop_Get(rapor.date_Start,ydf2);// Date_Stop;

                List<YoklamaView> yoks = rapor.raporGetirTarihlerArasi();
                if (!String.IsNullOrEmpty(textBox_Adsoyad.Text.Trim()))
                {
                    string ad = textBox_Adsoyad.Text.Trim();
                    yoks = yoks.Where(h => h.Ad.ToLower().Contains(ad.ToLower())).ToList();
                }

                dataGridView1.DataSource = yoks.OrderByDescending(h => h.Tarih).ToList();
            }
            Cursor = Cursors.Default;
        }

        private void genelRaporlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OzelRaporlama frm = new OzelRaporlama();
            frm.ShowDialog();

        }


        private void öğrenciİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOgrenciler fr = new FormOgrenciler();
            fr.DesktopLocation = new Point((this.Left + 10), (this.Top + 10));
            fr.ShowDialog();
        }



        private void cihazKullanıcıİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCihazKullaniciYonetimi frm = new FormCihazKullaniciYonetimi();
            frm.ShowDialog();
        }

        private void okumaKayıtlarıRapolamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OkunanTumVeriler fr = new OkunanTumVeriler();
            fr.DesktopLocation = new Point((this.Left + 100), (this.Top + 100));
            fr.ShowDialog();

        }

        private void topluİzinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTopluIzin fr = new FormTopluIzin();
            fr.DesktopLocation = new Point((this.Left + 100), (this.Top + 100));
            fr.ShowDialog();
        }

        private void ayarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fr = new FormAyarlar();
            fr.DesktopLocation = new Point((this.Left + 100), (this.Top + 100));
            fr.ShowDialog();
        }
    }
}
