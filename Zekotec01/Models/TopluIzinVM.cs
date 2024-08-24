using System;
using System.Collections.Generic;
using Zekotec01.DAL;

namespace Zekotec01.Models
{
    class TopluIzinVM
    {
        public int KullaniciId { get; set; }
        public string AdSoyad { get; set; }

        public string TcNo { get; set; }
        public string OdaNo { get; set; }

        public List<DALMssql.Izin> Izinler { get; set; }

        public Durum Durum {
            get {
                if (KullaniciId == 2124) {
                    string a = "55";
                }
                return new IzinDurum(KullaniciId,DateTime.Parse(DateTime.Now.ToShortDateString()),DateTime.Now).getIzinDurumNow(Izinler) ;
            }

            private set { } 
        }

        
    }
}
