using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Zekotec01.DAL;
using Zekotec01.DALMssql;


namespace Zekotec01.Models
{
    // 3   6   10
    public class IzinDurum
    {
        public int user_Id;
        /// <summary>
        /// İşlemin yapıldıgı O anki tarih (Now)
        /// </summary>
        public DateTime zaman;
        public DateTime YoklamaZamani;

        public IzinDurum()
        {

        }

        public IzinDurum(int _user_Id, DateTime _zaman, DateTime _YoklamaZamani)
        {
            user_Id = _user_Id;
            zaman = _zaman;
            YoklamaZamani = _YoklamaZamani;

        }

        public Durum getDurum(List<DALMssql.Izin> IzinListesi)
        {
            using (var db2 = new YoklamaDbEntities())
            {


                DALMssql.Izin izin = IzinListesi.OrderByDescending(h => h.Id).FirstOrDefault();

                if (izin == null)
                {
                    return Durum.Aktif;
                }

                if (zaman >= izin.BaslamaTarihi & zaman <= izin.BitisTarihi)
                {
                    if (izin.BaslamaTarihi.Value.AddDays(1) <= YoklamaZamani && YoklamaZamani <= izin.BitisTarihi)
                    {
                        izin.Aciklama = izin.BitisTarihi.Value.ToShortDateString() + " tarihindeki izin" + YoklamaZamani.ToShortDateString() + " tarihinde yurda giriş yaparak bitmiştir.";
                        izin.BitisTarihi = DateTime.Now;
                        //db2.Entry(izin).State = EntityState.Modified;
                        //db2.SaveChanges();
                        return Durum.Aktif;
                    }
                    return Durum.İzinli;
                }
                return Durum.Aktif;
            }
        }

        public Durum getDurum()
        {
            //user_ID cihazdaki Id
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                var izin = db.Izin.OrderByDescending(h => h.Id).Where(h => h.KullaniciId == user_Id).FirstOrDefault();

                if (izin == null)
                {
                    return Durum.Aktif;
                }

                if (zaman >= izin.BaslamaTarihi & zaman <= izin.BitisTarihi)
                {
                    if (izin.BaslamaTarihi.Value.AddDays(1) <= YoklamaZamani && YoklamaZamani <= izin.BitisTarihi)
                    {
                        izin.Aciklama = izin.BitisTarihi.Value.ToShortDateString() + " tarihindeki izin" + YoklamaZamani.ToShortDateString() + " tarihinde yurda giriş yaparak bitmiştir.";
                        izin.BitisTarihi = DateTime.Now;
                        db.Entry(izin).State = EntityState.Modified;
                        db.SaveChanges();
                        return Durum.Aktif;
                    }
                    return Durum.İzinli;
                }
                return Durum.Aktif;

            }


        }

        public Durum getIzinDurumNow(List<DALMssql.Izin> IzinListesi)
        {
            //user_ID cihazdaki Id
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                var izin = db.Izin.OrderByDescending(h => h.Id).Where(h => h.KullaniciId == user_Id).FirstOrDefault();

                if (izin == null)
                {
                    return Durum.Aktif;
                }

                if (zaman >= izin.BaslamaTarihi & zaman <= izin.BitisTarihi)
                {
                    return Durum.İzinli;
                }
                return Durum.Aktif;

            }


        }


    }
}