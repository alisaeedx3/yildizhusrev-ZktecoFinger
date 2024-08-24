using System;
using Zekotec01.DALMssql;

namespace Zekotec01.Models
{

    public class ZamanAyarlari
    {
       
        public static DateTime Rapor_date_start_Get(YoklamaZamani _ydf)
        {


            if (0 <= DateTime.Now.Hour && DateTime.Now.Hour < 3)
                return Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddDays(-1).AddHours(_ydf.Sure).AddMinutes(_ydf.Dakika);
            return Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddHours(_ydf.BaslamaSaati.Hour).AddMinutes(_ydf.BaslamaSaati.Minute);

        }



        public static DateTime Rapor_date_start_Get(DateTime zaman, YoklamaZamani _ydf)
        { 
            return Convert.ToDateTime(zaman.ToShortDateString()).AddHours(_ydf.BaslamaSaati.Hour).AddMinutes(_ydf.BaslamaSaati.Minute);
        }



        /// <summary>
        /// Uc saat elle belirlendi simdilik
        /// </summary>
        /// <returns></returns>
        public static DateTime Rapor_date_stop_Get(YoklamaZamani _ydf)
        {
          
            if (0 <= DateTime.Now.Hour && DateTime.Now.Hour < 3)
                return Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddDays(-1).AddHours( _ydf.BaslamaSaati.Hour+ _ydf.Sure).AddMinutes(_ydf.BaslamaSaati.Minute+_ydf.Dakika);
            return Convert.ToDateTime(DateTime.Now.ToShortDateString()).AddHours(_ydf.BaslamaSaati.Hour + _ydf.Sure).AddMinutes(_ydf.BaslamaSaati.Minute + _ydf.Dakika);

        }

        /// <summary>
        /// DAtetimepicture gibi yerden zaman aralıgı secildigi zaman
        /// </summary>
        /// <returns></returns>
        public static DateTime Rapor_date_stop_Get(DateTime zaman,YoklamaZamani _ydf)
        {

            return zaman.AddHours(_ydf.Sure).AddMinutes(_ydf.Dakika);
        }



        public static DateTime YoklamaDate_Start_Get(DateTime zaman, YoklamaZamani ydf2)
        {
            return new DateTime(zaman.Year, zaman.Month, zaman.Day, ydf2.BaslamaSaati.Hour, ydf2.BaslamaSaati.Minute, 0);
        }


        public static DateTime YoklamaDate_Stop_Get(DateTime zaman, YoklamaZamani ydf2)
        {
            var stopDate = new DateTime(zaman.Year, zaman.Month, zaman.Day, ydf2.BaslamaSaati.Hour, ydf2.BaslamaSaati.Minute, 0);
            stopDate = stopDate.AddHours(ydf2.Sure).AddMinutes(ydf2.Dakika);
            return stopDate;
        }

        public static int RaporGunSayisiGet(DateTime baslama, DateTime bitis)
        {
            var z = bitis.AddHours(-3).Day - baslama.Day;
            return z;
        }

    }
}
