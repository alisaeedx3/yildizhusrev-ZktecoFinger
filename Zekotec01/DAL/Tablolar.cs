using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zekotec01.DAL
{
    public enum Durum { Aktif, İzinli, Ayrıldı,ErkenDönüş }
    public class User
    {
        
        public User()
        {
        }
        public int ID { get; set; }

        public int UserId { get; set; }

       // [Required(ErrorMessage ="Kullanıcı İsmi Girilmelidir")]
        [MaxLength(50)]
        [Index]
        public string Name { get; set; }

        [MaxLength(50)]
        [Index]
        public string CepTel { get; set; }

        [MaxLength(50)]
        [Index]
        public string AileTel { get; set; }


        public string Resim { get; set; }
        

        public Durum durum { get; set; }

        public string TcKimlik { get; set; }

        [MaxLength(50)]
        public string OdaNo { get; set; }

        public string Adres { get; set; }

        public string Notlar { get; set; }
    }

    



    public class Yoklama
    {
        public Yoklama()
        {
        }

        public int ID { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public  CihazTipi cihazTipi { get; set; }

        public int CihazId { get; set; }

    }

    public enum CihazTipi { Giris=1, Cikis=2,Yoklama=3 }

    public class Cihaz
    {
        public Cihaz()
        {
        }

        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        [Index]
        public string Ip { get; set; }


        [Required]
        [MaxLength(10)]
        [Index]
        public string Port { get; set; }


        [Required]
        [MaxLength(20)]
        [Index]
        public string CihazAdi { get; set; }

        //public enum CihazTipi{ Giris,Cikis}
        public CihazTipi cihazTipi { get; set; }

    }

    public class YoklamaDefault
    {
        public YoklamaDefault()
        { }
        public int ID { get; set; }
        public DateTime Hours_Start { get; set; }
        public DateTime Hours_Stop { get; set; }

    }

    public class YoklamaView
    {

        [Display(Name = "Öğrenci Id")]
        public int ID { get; set; }

        [Display(Name ="Öğrenci Adı")]
        public string Ad { get; set; }

        [Display(Name = "Okuma Tarihi")]
        public string OkumaTarihi { get; set; }

        [Display(Name = "Okuma Tarihi")]
        public string Tarih { get; set; }

        [Display(Name = "Yoklama Durumu")]
        public string yoklama { get; set; }

        [Display(Name = "Öğrenci Durumu")]
        public Durum? durum { get; set; } =  Durum.Aktif;
    }

    public class GenelRapor {

        public int UserId { get; set; }
        public int yoklamaId { get; set; }
        public string Adı { get; set; }
        public DateTime Tarih { get; set; }
        public CihazTipi cihaz { get; set; }
        public string cihazadi { get; set; }
    }

    public class Izin
    {
        public Izin() { }

        public int ID { get; set; }
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
        public int UserId { get; set; }
        public string Aciklama { get; set; }


    }

    public class UserView
    {
        public int ID { get; set; }
        public string AdiSoyadi { get; set; }
    }

}
