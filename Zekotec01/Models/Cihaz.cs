using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Zekotec01.DAL;
using Zekotec01.DALMssql;

namespace Zekotec01.Models
{
    class CihazDurumu
    {
        public bool durum { get; set; } = false;
        public string mesaj { get; set; }
    }


    class CihazNesne
    {
      
      
        #region Cihaz Bağlantı ayarları

        private zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();
        private bool bIsConnected = false;//the boolean value identifies whether the device is connected
        private int iMachineNumber = 1;//the serial number of the device.After connecting the device ,this value will be changed.

        #endregion


        #region Cihaz Genel Değişkenleri
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
        #endregion

        bool baglantiDurum = false;

        public int Cihaz_ID;
        public string Name;

        public CihazDurumu CihazaBaglan(DALMssql.Cihaz chz)
        {
            
            CihazDurumu durum = new CihazDurumu();
            durum.durum = false;
            durum.mesaj = "Cihaza Bağlanılamadı";

            if (!baglantiDurum)
            {

                bIsConnected = axCZKEM1.Connect_Net(chz.Ip, chz.Port);
                if (bIsConnected)
                {
                    iMachineNumber = 1;//In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                    axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                    baglantiDurum = true;
                    durum.durum = baglantiDurum;
                    durum.mesaj = "Cihaz Bağlantısı Başarılı";
                }
                else
                {
                    axCZKEM1.GetLastError(ref idwErrorCode);
                    MessageBox.Show("Cihaza Bağlanılamadı, Hata kodu=" + idwErrorCode.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            return durum;
        }

        public bool KullanicilariGüncelle(List<Kullanici> Users)
        {

            bool sonuc = false;
            string mesaj = "Güncellenecek Kullanıcı Bulunamadı";

            axCZKEM1.EnableDevice(iMachineNumber, false);
           

            foreach (var item in Users)
            {
                if (axCZKEM1.SSR_SetUserInfo(iMachineNumber, item.CihazUserId.ToString(), item.Adres, null, 0, true))
                {

                    sonuc = true;
                    mesaj = "Güncelleme Başarıyla Gerçekleştirildi";
                }
                else
                {
                    mesaj = "Güncelleme Başarısız";
                }

            }

            axCZKEM1.EnableDevice(iMachineNumber, true);
            MessageBox.Show(mesaj);
         
            return sonuc;
        }

        public List<Kullanici> KayitlariGetir()
        {
            #region MyRegion Kullanıcı getir
            List<Kullanici> UserDownload = new List<Kullanici>();

            string sdwEnrollNumber = "";
            string sName = "";
            string sPassword = "";
            int iPrivilege = 0;
            bool bEnabled = false;
            int idwFingerIndex;
            string sTmpData = "";
            int iTmpLength = 0;
            int iFlag = 0;

            axCZKEM1.EnableDevice(iMachineNumber, false);
            axCZKEM1.ReadAllUserID(iMachineNumber);//read all the user information to the memory
            axCZKEM1.ReadAllTemplate(iMachineNumber);//read all the users' fingerprint templates to the memory

            while (axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))//get all the users' information from the memory
            {
                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    if (axCZKEM1.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))//get the corresponding templates string and length from the memory
                    {

                        Kullanici user = new Kullanici();
                        user.CihazUserId = int.Parse(sdwEnrollNumber);
                        user.AdSoyad = sName;

                        //birden fazla kayıt geldiği için ilk kaydı çek veritabanına kaydet 
                        if (UserDownload.Where(h => h.CihazUserId == user.CihazUserId).Count() == 0)
                        {
                            UserDownload.Add(user);
                        }
                    }
                }
            }

            //dataGridView_ogrliste.DataSource = UserDownload.ToList();
            axCZKEM1.EnableDevice(iMachineNumber, true);
            // axCZKEM1.Disconnect();
          
            return UserDownload.ToList();
            #endregion
        }

        public List<Yoklama> CihazKayitlariniOku()
        {
           
            List<Yoklama> yoklamalar = new List<Yoklama>();

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
                        Yoklama yoklama = new Yoklama();
                        yoklama.UserId = int.Parse(sdwEnrollNumber);
                        yoklama.Date = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
                       // yoklama.cihazTipi = cihaz.cihazTipi;

                        yoklamalar.Add(yoklama);


                    }

                }
                else
                {
                   
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
           
            return yoklamalar.ToList();
        }

        

    }
}
