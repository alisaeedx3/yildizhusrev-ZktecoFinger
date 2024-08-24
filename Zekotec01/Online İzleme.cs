using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Zekotec01.DAL;
using Zekotec01.DALMssql;
using Zekotec01.Models;
using zkemkeeper;

namespace Zekotec01
{
    public partial class Online_İzleme : Form
    {
        public Online_İzleme()
        {
            InitializeComponent();
            this.dataGridView2.Font = new FontDialogParse().GetFont();

        }

        private YoklamaDbEntities db = new YoklamaDbEntities();
        private CZKEMClass axCZKEM1 = new CZKEMClass();

        private CZKEMClass[] machines = new CZKEMClass[3];
         private int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value

        private void Online_İzleme_Load(object sender, EventArgs e)
        {
            comboBox_cihaz.DataSource = db.Cihaz.ToList();
            comboBox_cihaz.ValueMember = "Id";
            comboBox_cihaz.DisplayMember = "Adi";
        }

        private void button_izle_Click(object sender, EventArgs e)
        {
           
                CihazaBaglan(db.Cihaz.ToList());

            return;

            Cursor = Cursors.WaitCursor;
            var chz = db.Cihaz.Find(comboBox_cihaz.SelectedValue);
            label_chzTipi.Text = ((CihazTipi)chz.CihazTipi).ToString();
            if (chz!=null)
            {
                if (CihazaBaglan(chz.Ip, chz.Port.ToString()))
                {
                    //cihaz bağlandı;
                     
                    datagridguncelle();
                   
                }


            }
            else
            {
                MessageBox.Show("Cihaz Seçilmedi");

            }
            Cursor = Cursors.Default;

        }

        private bool CihazaBaglan(List<DALMssql.Cihaz> cihazlar)
        {
            int i = 0;
            CZKEMClass cihaz_;
            foreach (var item in cihazlar)
            {
                try
                {

               
                cihaz_ = new CZKEMClass();

                int idwErrorCode = 0;

                //cihaz.Disconnect();
                //return;

               var  IsConnected = cihaz_.Connect_Net(item.Ip, item.Port);
                if (IsConnected == true)
                {
                    //global değişken
                    // iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                    if (cihaz_.RegEvent(iMachineNumber, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                    {

                        cihaz_.OnConnected += new zkemkeeper._IZKEMEvents_OnConnectedEventHandler(axCZKEM1_OnConnected);  //(axCZKEM1_OnAttTransactionEx);//verilerin alındıgı event
                        cihaz_.OnDisConnected += new zkemkeeper._IZKEMEvents_OnDisConnectedEventHandler(OnDisConnected);

                        // this.axCZKEM1.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);//parmak okundu
                        //this.axCZKEM1.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);//doğrulama yapılıyr
                       cihaz_.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);//verilerin alındıgı event

                        //this.axCZKEM1.OnAttTransaction += new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(axCZKEM1_OnAttTransaction);//kullanıcı bilgileri cekiliyor
                    }
                    label_status.Text = "Cihaz Bağlı";
                    label_status.ForeColor = Color.DarkGreen;
                    machines[i] = cihaz_;
                    
                }
                else
                {
                    axCZKEM1.GetLastError(ref idwErrorCode);
                    MessageBox.Show("Cihaza Bağlantı Hatası, Hata Kodu =" + idwErrorCode.ToString(), " Cihaz Bağlantı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label_status.Text = "Bağlı Değil";
                    
                }
                }
                catch (Exception)
                {

                    
                }

            }


            return true;
            




        }


        private bool CihazaBaglan(string ip, string port)
        {

           


            bool bIsConnected = false;//the boolean value identifies whether the device is connected
            if (label_status.Text == "Cihaz Bağlı")
            {
                
                axCZKEM1.Disconnect();
                label_status.Text = "Bağlantı Koptu";
                return true;
            }

            if (ip.Trim() == "" || port.Trim() == "")
            {
                MessageBox.Show("Hatalı Ip veya Port Kaydı", "Cihaz Bağlantı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int idwErrorCode = 0;

            axCZKEM1.Disconnect();
            //return;

            bIsConnected = axCZKEM1.Connect_Net(ip, Convert.ToInt32(port));
            if (bIsConnected == true)
            {
                //global değişken
                // iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                if(axCZKEM1.RegEvent(iMachineNumber, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                {

                    this.axCZKEM1.OnConnected += new zkemkeeper._IZKEMEvents_OnConnectedEventHandler(axCZKEM1_OnConnected);  //(axCZKEM1_OnAttTransactionEx);//verilerin alındıgı event
                    this.axCZKEM1.OnDisConnected += new zkemkeeper._IZKEMEvents_OnDisConnectedEventHandler(OnDisConnected);

                    // this.axCZKEM1.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(axCZKEM1_OnFinger);//parmak okundu
                    //this.axCZKEM1.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(axCZKEM1_OnVerify);//doğrulama yapılıyr
                    this.axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);//verilerin alındıgı event

                    //this.axCZKEM1.OnAttTransaction += new zkemkeeper._IZKEMEvents_OnAttTransactionEventHandler(axCZKEM1_OnAttTransaction);//kullanıcı bilgileri cekiliyor
                }
                label_status.Text = "Cihaz Bağlı";
                label_status.ForeColor = Color.DarkGreen;
                return true;
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Cihaza Bağlantı Hatası, Hata Kodu =" + idwErrorCode.ToString(), " Cihaz Bağlantı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label_status.Text = "Bağlı Değil";
                return false;
            }




        }

        private void OnDisConnected()
        {
            throw new NotImplementedException();
        }

        private void axCZKEM1_OnConnected()
        {
            throw new NotImplementedException();
        }

        private void axCZKEM1_OnAttTransactionEx(string sEnrollNumber, int iIsInValid, int iAttState, int iVerifyMethod, int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond, int iWorkCode)
        {
            int iUserID = int.Parse(sEnrollNumber);
            //label_status.Text = "RTEvent OnVerify Has been Triggered,Verifying...";
            if (iUserID != -1)
            {
                //label_status.Text= "Verified OK, the UserID is " + iUserID.ToString();

                var user = db.Kullanici.Where(h => h.CihazUserId == iUserID).SingleOrDefault();
                if (user == null)
                {
                    pictureBox_Ok.Visible = false;
                    pictureBox_Hata.Visible = true;

                    MessageBox.Show("Öğrenci Kaydı Bulunamadı. Öğrencileri Güncellemesiniz",
                                    "Veri Tabanı Güncelleme",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1);




                }
                else
                {

                    OkumaKayit yk = new OkumaKayit();
                    yk.CihazTipi = (int)(CihazTipi)Enum.Parse(typeof(CihazTipi), label_chzTipi.Text);
                    yk.OkumaZamani = DateTime.Now;
                    yk.CihazUserID = iUserID;
                    yk.OkunanCihazId = int.Parse(comboBox_cihaz.SelectedValue.ToString());

                    db.OkumaKayit.Add(yk);
                    if (db.SaveChanges() > 0)
                    {
                        label_Name.Text = user.AdSoyad;
                        label_islemtarihi.Text = yk.OkumaZamani.ToString();
                        pictureBox_Ok.Visible = true;
                        pictureBox_Hata.Visible = false;
                        pictureBox1.Image = new Ogrenci { ResimByte = user.Resim }.ConvertByteToImage();
                        datagridguncelle();



                    }
                    else
                    {

                        MessageBox.Show("Yoklama Kaydında \n Hata Oluştu.");
                    }

                }



            }
            else
            {
                pictureBox_Ok.Visible = false;
                pictureBox_Hata.Visible = true;
                label_Name.Text = "Hatalı Okuma \n\nLütfen Tekrar Deneyiniz";
            }
        }

        private void datagridguncelle()
        {
            //MyContext db2 = new MyContext(Helpers.GetConnection());
            var ydf2 = db.YoklamaZamani.FirstOrDefault();

            if (ydf2 == null)
            {
                MessageBox.Show("Günlük Yoklama Aralığı bulunamadı");
                return;
            }

            Rapor rapor = new Rapor();
            rapor.date_Start = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddHours(0).AddMinutes(0);
            rapor.date_Stop = Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddHours(23).AddMinutes(59);

            List<YoklamaView> yoks = rapor.raporGetirTarihlerArasi();   

            label_Toplam.Text = yoks.Count().ToString();
            label_Var.Text = yoks.Where(h => h.yoklama == "VAR").Count().ToString();
            label_Yok.Text = yoks.Where(h => h.yoklama == "YOK").Count().ToString();

            yoklamagdirdguncelle(yoks.ToList());
        }

        void yoklamagdirdguncelle(List<YoklamaView> yoklama)
        {
            dataGridView2 .DataSource = yoklama.ToList();

            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[1].Width = 200;
            dataGridView2.Columns[2].Width = 170;
            dataGridView2.Columns[3].Width = 170;
            dataGridView2.Columns[4].Width = 150;
            dataGridView2.Columns[5].Visible = false;
                        
            dataGridView2.Columns[1].HeaderText = "ÖĞRENCİ ADI";
            dataGridView2.Columns[2].HeaderText = "YOKLAMA TARİHİ";
            dataGridView2.Columns[3].HeaderText = "OKUMA TARİHİ";
            dataGridView2.Columns[4].HeaderText = "YOKLAMA DURUMU";




        }

        private void Online_İzleme_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (label_status.Text == "Cihaz Bağlı")
            {
                axCZKEM1.Disconnect();
            }

        }
    }
}
