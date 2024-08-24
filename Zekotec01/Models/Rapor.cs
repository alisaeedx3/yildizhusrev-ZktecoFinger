using System;
using System.Collections.Generic;
using System.Linq;
using Zekotec01.DAL;
using Zekotec01.DALMssql;

namespace Zekotec01.Models
{
    public class Rapor
    {
        //public string Ogradi;
        public DateTime date_Start;
        public DateTime date_Stop;
        public int? user_Id;
        private DateTime zaman;
        private DateTime YoklamaDate_Start;
        private DateTime YoklamaDate_Stop;



        public List<YoklamaView> raporGetirTarihlerArasi()
        {

            //MyContext _db = new MyContext(Helpers.GetConnection());

            using (YoklamaDbEntities _db = new YoklamaDbEntities())
            {
                YoklamaZamani ydf2 = _db.YoklamaZamani.FirstOrDefault();
                if (ydf2 == null)
                {
                    throw new Exception("Yoklama Zamanı Tanımlı degil");
                }


                int gün = ZamanAyarlari.RaporGunSayisiGet(date_Start, date_Stop);
                var ogrenciler = _db.Kullanici.ToList();

                //tek ögrenci raporlaması yapılacaksa User Id gelir
                if (user_Id > 0)
                {
                    ogrenciler = ogrenciler.Where(h => h.CihazUserId == user_Id).ToList();
                }



                List<YoklamaView> yoklamaListesi = new List<YoklamaView>();


                for (int i = 0; i <= gün; i++)
                {
                    zaman = date_Start.AddDays(i);

                    YoklamaDate_Start = ZamanAyarlari.YoklamaDate_Start_Get(zaman, ydf2); // new DateTime(zaman.Year, zaman.Month, zaman.Day, ydf2.BaslamaSaati.Hour,ydf2.BaslamaSaati.Minute, 0);
                    YoklamaDate_Stop = ZamanAyarlari.YoklamaDate_Stop_Get(zaman, ydf2);// DateTime(zaman.Year, zaman.Month, zaman.Day, ydf2.BitisSaati.Hour, ydf2.BitisSaati.Minute, 0);

                    var yoklamalar = _db.OkumaKayit.Where(h => h.OkumaZamani >= YoklamaDate_Start & YoklamaDate_Stop >= h.OkumaZamani).ToList();

                    foreach (var item in yoklamalistesigetir(ogrenciler, yoklamalar))
                    {
                        item.OkumaTarihi = date_Start.AddDays(i).ToLongDateString();
                        yoklamaListesi.Add(item);
                    }

                }
                return yoklamaListesi;
            }
        }

        public List<YoklamaView> raporGetirKisiyiTarihlerArasi()
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                var yoklamalar = db.OkumaKayit.Where(h => h.OkumaZamani > date_Start & h.OkumaZamani < date_Stop).ToList();
                var ogrenciler = db.Kullanici.Where(h => h.Id == user_Id).ToList();
                return new List<YoklamaView>(); //yoklamalistesigetir(ogrenciler, yoklamalar);
            }
        }

        private List<YoklamaView> yoklamalistesigetir(List<Kullanici> ogrenciler, List<OkumaKayit> yoklamalar)
        {
            YoklamaView yok;
            IzinDurum durum;
            List<YoklamaView> yoks = new List<YoklamaView>();
            foreach (var item in ogrenciler)
            {
                //Yoklama yoklama = yoklamalar.Where(h => h.cihazTipi==CihazTipi.Giris & h.UserId == item.UserId & YoklamaDate_Start <= h.Date & YoklamaDate_Stop >= h.Date).OrderByDescending(k => k.Date).FirstOrDefault();
                if (item.AdSoyad.ToLower().Equals("evrim gümüş") == true)
                {
                    var h = "deben";
                }
                    
                var yoklama = yoklamalar.Where(h => h.CihazUserID == item.CihazUserId & YoklamaDate_Start <= h.OkumaZamani & YoklamaDate_Stop >= h.OkumaZamani).OrderByDescending(k => k.OkumaZamani).FirstOrDefault();

                yok = new YoklamaView();
                durum = new IzinDurum();

                yok.Ad = item.AdSoyad;
                yok.durum = (Durum?)item.Durum;
                yok.ID = item.Id;

                durum.user_Id = item.Id;
                durum.zaman = zaman;


                if (yoklama == null || (CihazTipi)yoklama.CihazTipi == CihazTipi.Cikis)
                {
                    yok.Tarih = "---";
                    yok.yoklama = "YOK";

                }
                else //if (yoklama.cihazTipi == CihazTipi.Yoklama)
                {

                    yok.yoklama = "VAR";
                    yok.Tarih = yoklama.OkumaZamani.ToString();
                    durum.YoklamaZamani = yoklama.OkumaZamani;
                }


                yok.durum = durum.getDurum(item.Izin.ToList());
                switch (yok.durum)
                {
                    case Durum.Aktif:
                        break;
                    case Durum.İzinli:
                        yok.yoklama = "İZİNLİ";
                        break;
                    case Durum.Ayrıldı:
                        yok.yoklama = "AYRILDI";
                        break;
                    default:
                        break;
                }

                yoks.Add(yok);

            }
            return yoks;
        }

        public bool yoklamakaydet(List<YoklamaView> yoklamalar)
        {

            return true;
        }

    }
}
