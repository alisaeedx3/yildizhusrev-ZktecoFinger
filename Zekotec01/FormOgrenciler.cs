using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Zekotec01.DAL;
using Zekotec01.DALMssql;
using Zekotec01.Models;

namespace Zekotec01
{
    public partial class FormOgrenciler : Form
    {
        public FormOgrenciler()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form Yüklenmesi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOgrenciler_Load(object sender, EventArgs e)
        {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                //gridgüncelle();

                //adsoyad textboxverileri
                AutoComplate();

                //izin bilgileri
                dateTimePickerStop.Value = DateTime.Now.AddDays(1);

                tabControl1.Enabled = false;
        }


        private void gridgüncelle()
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {

                if (String.IsNullOrEmpty(textBoxSearch.Text.Trim()))
                {
                    dataGridView_ogrliste.DataSource = db.Kullanici.Select(h => new UserView { ID = h.Id, AdiSoyadi = h.AdSoyad }).OrderBy(k => k.AdiSoyadi).ToList();
                }
                else
                {
                    dataGridView_ogrliste.DataSource = db.Kullanici.Where(h => h.AdSoyad.Contains(textBoxSearch.Text.Trim())).Select(h => new UserView { ID = h.Id, AdiSoyadi = h.AdSoyad }).OrderBy(k => k.AdiSoyadi).ToList();

                }
            }
           
 
            dataGridView_ogrliste.Columns[0].Visible = false;
            dataGridView_ogrliste.Columns[1].Visible = true;

            dataGridView_ogrliste.Columns[1].HeaderText = "ADI SOYADI";
            dataGridView_ogrliste.Columns[1].Width = 154;
        }

        #region Öğrenci İşlemleri

        private void dataGridView_ogrliste_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView_ogrliste_RowHeaderMouseDoubleClick(sender, e);
        }
        private void dataGridView_ogrliste_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {

                tabControl1.Enabled = true;
                comboBox_Durum.DataSource = Enum.GetValues(typeof(Durum));
                label_İzinID.Text = dataGridView_ogrliste[0, e.RowIndex].Value.ToString();
                var _user = db.Kullanici.Find(int.Parse(label_İzinID.Text));
                if (_user == null)
                {
                    MessageBox.Show("Kullanıcı Bulunamadı",
                                        "Hatas",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1);
                    return;

                }

            
                textBoxCihazID.Text = _user.CihazUserId.ToString();
                textBox_Ad.Text = _user.AdSoyad;
                textBox_CepTel.Text = _user.CepTel;
                textBox_AileTel.Text = _user.AileTel;

                textBox_OdaNo.Text = _user.OdaNo;
                textBox_Tc.Text = _user.TcKimlik;
                textBox_Adres.Text = _user.Adres;
                textBoxnotlar.Text = _user.Not;

                label_UserID.Text = _user.Id.ToString();

                if (_user.Resim==null)
                {
                    pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\resimler\\BAvatar.png");
                }
                else
                {
                    pictureBox1.Image = new Ogrenci() { ResimByte = _user.Resim }.ConvertByteToImage();

                }

                //hareketbilgilerini ogunku tarihe göre gösterir
                gridGuncelle_tumhareketler();
            }

            //Tabpanel ilkini açma
            tabControl1.SelectedIndex = 0;

            //cihaz kullanıc guncelleme butonu
            button_CihazGuncelle.Enabled = true;

            //izin bilgilerini Günceller
            izinbilgileriguncelle();
            buttonYeniizinEkle.Visible = true;
            button_güncelle.Visible = false;
            button_sil.Visible = false;

            //Ogr buton ayarları
            button_CihazGuncelle.Enabled = buttonOgrSil.Enabled = true;
            

        }

        /// <summary>
        /// Öğrenci Güncelleme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Kaydet_Click(object sender, EventArgs e)
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {

                if (label_KayitDurum.Text=="Güncelleme")
                {
                    #region Öğrenci Güncelleme
                    if (String.IsNullOrEmpty(label_İzinID.Text))
                    {
                        MessageBox.Show("Öğrenci Seçimi Yapmalısınız.",
                                            "Seçim Hatası",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error,
                                            MessageBoxDefaultButton.Button1);
                        return;
                    }

                    var user = db.Kullanici.Find(int.Parse(label_İzinID.Text));
                    user.AileTel = textBox_AileTel.Text;
                    user.CepTel = textBox_CepTel.Text;
                    user.Durum = (int)comboBox_Durum.SelectedIndex;
                    user.AdSoyad = textBox_Ad.Text;
                    user.Id = int.Parse(label_İzinID.Text);
                    user.CihazUserId = int.Parse(textBoxCihazID.Text);
                    user.Adres = textBox_Adres.Text;
                    user.Not = textBoxnotlar.Text;
                    user.TcKimlik = textBox_Tc.Text;
                    user.OdaNo = textBox_OdaNo.Text;



                    //dosyadan resimm kayıt etme cekme yöntemi
                    //string dosyaadi = user.Name + user.UserId;
                    //file kayıt yöntemi
                    //pictureBox1.Image.Save(Application.StartupPath + "\\resimler\\" + dosyaadi,System.Drawing.Imaging.ImageFormat.Bmp);
                    //user.Resim = dosyaadi;


                    //string kayıt yöntemi
                    user.Resim = new Models.Ogrenci() { ResimImage = pictureBox1.Image }.ConvertImageToByte();

                    db.Entry(user).State = EntityState.Modified;

                    #region Veri Tabanı Kayıt
                    if (db.SaveChanges() > 0)
                    {
                        TemizleTextBox();
                        gridgüncelle();
                        MessageBox.Show("Kayıt Güncellendi", "Öğrenciler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabControl1.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme işleminde Hata Oluştu. Lütfen Tekrar Deneyiniz.", "Öğrenciler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion
                    #endregion
                    buttonOgrYeniEkle.Enabled = true;


                }
                else if (label_KayitDurum.Text == "Yeni Kayıt")
                {
                    #region Yeni Kayıt


                    try
                    {
                        var user = new Kullanici();

                        if (!String.IsNullOrEmpty(textBoxCihazID.Text))
                        {
                            user.CihazUserId = Convert.ToInt16(textBoxCihazID.Text);
                        }


                        user.AdSoyad = textBox_Ad.Text;
                        user.AileTel = textBox_AileTel.Text;
                        user.CepTel = textBox_CepTel.Text;
                        user.Durum = comboBox_Durum.SelectedIndex;
                        user.Adres = textBox_Adres.Text;
                        user.Not = textBoxnotlar.Text;
                        user.TcKimlik = textBox_Tc.Text;
                        user.OdaNo = textBox_OdaNo.Text;
                        string dosyaadi = user.AdSoyad + user.CihazUserId;

                        //dosya kayıt yöntemi
                        //pictureBox1.Image.Save(Application.StartupPath + "\\resimler\\" + dosyaadi , System.Drawing.Imaging.ImageFormat.Jpeg);
                        //user.Resim = dosyaadi;

                        //vt kayıt yöntemi 
                        Models.Ogrenci ogrenci = new Models.Ogrenci() { ResimImage = pictureBox1.Image };
                        user.Resim = ogrenci.ConvertImageToByte();

                        db.Kullanici.Add(user);

                        if (db.SaveChanges() > 0)
                        {
                            MessageBox.Show("Kullanıcı Başarıyla Eklendi",
                                    "Kullanıcı Silme",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1);
                            gridgüncelle();
                            TemizleTextBox();
                            this.buttonOgrYeniEkle.Text = "Yeni Kayıt";
                        }

                    }
                    catch (Exception hata)
                    {

                        MessageBox.Show(hata.ToString(),
                                         "Kullanıcı Girişi Hatası",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error,
                                         MessageBoxDefaultButton.Button1);
                    }

                    #endregion

                    label_KayitDurum.Text = "Güncelleme";
                }

            }

        }

        private void TemizleTextBox()
        {
             
            foreach (var item in groupBox_islem.Controls.OfType<TextBox>().ToList())
            {
                item.Text = "";
            }
            label_İzinID.Text = "";
            pictureBox1.Image = null;
            
        }


        /// <summary>
        /// Tek kullanıcı Güncellemek için
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var users = new List<Kullanici>
                    {
                        new Kullanici {CihazUserId = int.Parse(textBoxCihazID.Text), AdSoyad=textBox_Ad.Text }
                    };
            OgrenciGüncelle(users);
            Cursor = Cursors.Default;

        }

        /// <summary>
        /// Kullanıcıları Günceller
        /// </summary>
        /// <param name="users"> Kullanıcı Listesi Alır</param>
        void OgrenciGüncelle(List<Kullanici> users)
        {
            CihazNesne Cihaz = new CihazNesne();
            FormCihazSeç frm = new FormCihazSeç();
            frm.ShowDialog();
            DALMssql.Cihaz chz = frm._cihaz;
            if (chz != null)
            {
                CihazDurumu _chzdurum = Cihaz.CihazaBaglan(chz);

                if (_chzdurum.durum)
                {
                    if (!Cihaz.KullanicilariGüncelle(users))
                    {
                        MessageBox.Show("Kullanici Güncellenemedi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void izinbilgileriguncelle()
        {
            if (String.IsNullOrEmpty(textBoxCihazID.Text.Trim()))
            {
                return;
            }
            int id = int.Parse(label_UserID.Text.Trim());
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                dataGridViewIzinbilgileri.DataSource = db.Izin.Where(h => h.KullaniciId == id).Select(h=>new {h.Id,h.BaslamaTarihi,h.BitisTarihi,h.Aciklama }).ToList();
            }
           dataGridViewIzinbilgileri.Columns[0].Visible = false;
           dataGridViewIzinbilgileri.Columns[1].Visible = true;
           dataGridViewIzinbilgileri.Columns[2].Visible = true;
           dataGridViewIzinbilgileri.Columns[3].Visible = true;

           dataGridViewIzinbilgileri.Columns[1].HeaderText = "İZİN BAŞLANGIÇ";
           dataGridViewIzinbilgileri.Columns[2].HeaderText = "İZİN BİTİŞ";

           dataGridViewIzinbilgileri.Columns[1].Width = 200;
           dataGridViewIzinbilgileri.Columns[2].Width = 200;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label_KayitDurum.Text = "Yeni Kayıt";
            tabControl1.Enabled = true;
            comboBox_Durum.DataSource = Enum.GetValues(typeof(Durum));
            TemizleTextBox();
            buttonOgrSil.Enabled = button_CihazGuncelle.Enabled = false;
            pictureBox1.Image = Zekotec01.Properties.Resources.BayanAvatar;

        }

        /// <summary>
        /// Silme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {

          

                if (String.IsNullOrEmpty(label_İzinID.Text))
                {
                    MessageBox.Show("Öğrenci Seçimi Yapmalısınız.",
                                        "Seçim Hatası",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error,
                                        MessageBoxDefaultButton.Button1);
                    return;
                }

                int? userid = Convert.ToInt16(label_İzinID.Text);
                if (userid==null)
                {
                    MessageBox.Show("Herhangi Bir Kayıt Seçilmedi",
                   "Kayıt Silme",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1);
                    return;
                }

                var user = db.Kullanici.Find(userid);
                if (user==null)
                {
                    MessageBox.Show("Silinecek Kayıt Bulunamadı",
                    "Kayıt Silme",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);

                    return;
                }
                db.Kullanici.Remove(user);

                if (db.SaveChanges()>0)
                {
                    gridgüncelle();
                    TemizleTextBox();
                    MessageBox.Show("Kullanıcı Başarıyla Silindi",
                                    "Kullanıcı Silme",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
           
            
                DialogResult result = MessageBox.Show("Tüm Öğrenci Bilgilerini, Yoklama Kayıtlarını ve İzin Bilgilerini Silmek İstediğinize Eminmisiniz?", "Doğrulama", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    kullanicisil();                   
                    Cursor = Cursors.Default;
                }
                else if (result == DialogResult.No)
                {
                    //...
                }
                else
                {
                    //...
                }
            
           
        }

       // void kullanicisil(List<User> users)
        void kullanicisil()
        {

            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                foreach (var user in db.Kullanici.ToList())
                {
                    

                    foreach (var yoklama in db.OkumaKayit.Where(h => h.CihazUserID == user.CihazUserId).ToList())
                    {
                        db.OkumaKayit.Remove(yoklama);
                    }

                    foreach (var izin in db.Izin.Where(h => h.KullaniciId == user.Id).ToList())
                    {
                        db.Izin.Remove(izin);

                    }

                    db.Kullanici.Remove(user);
                }

                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("Tüm Kullanıcılar Silindi",
                                         "Toplu Kullanıcı Silme",
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information,
                                         MessageBoxDefaultButton.Button1);
                    gridgüncelle();
                    return;
                }
            }
            MessageBox.Show("Kullanıc Silmede Veri Tabanı Hatası",
                                    "Toplu Kullanıcı Silme",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
            return;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dosyadanresimyükle();
        }

        private void dosyadanresimyükle()
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.InitialDirectory = "C:\\";
            dosya.Title = "Resim Seç";
            dosya.FilterIndex = 1;
            //dosya.Filter = ("Png Resim Dosyası (*.png)|Jpeg Resim Dosyası (*.jpg)|*.jpg|Gif Resim Dosyası (*.gif)|*.gif|Bmp Resim Dosyası(*.bmp)|*.bmp|Tüm Dosyalar(*.*)|*.*");
            if (dosya.ShowDialog() == DialogResult.OK)
            {
                string dosyaadi = "";
                dosyaadi = dosya.FileName;
                pictureBox1.Image = Image.FromFile(dosyaadi);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


            }
        }

        private void button_resim_cek_Click(object sender, EventArgs e)
        {
            //FormResimCek frm = new FormResimCek();
            //frm.ShowDialog();

            FormResimCek gen = new FormResimCek();
            gen.ShowDialog();
            byte[] resim = gen.donenresim;
            if (resim.Count() != 0)
            {
                pictureBox1.Image = (Bitmap)((new ImageConverter()).ConvertFrom(resim));
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dosyadanresimyükle();
        }

        void AutoComplate()
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {

                textBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
                foreach (var item in db.Kullanici.Select(k => k.AdSoyad).ToList())
                {
                    coll.Add(item);
                }
                textBoxSearch.AutoCompleteCustomSource = coll;
            }

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            gridgüncelle();
        }

        #endregion


        #region İzin İşlemleri
        private void izingüncelle(int id)
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                dataGridViewIzinbilgileri.DataSource = db.Izin.Where(h => h.KullaniciId == id).Select(h=>new {h.Id,h.BaslamaTarihi,h.BitisTarihi,h.Aciklama }).ToList();
            }

            dataGridViewIzinbilgileri.Columns[0].Visible = true;
            dataGridViewIzinbilgileri.Columns[1].Visible = true;
            dataGridViewIzinbilgileri.Columns[2].Visible = true;
            dataGridViewIzinbilgileri.Columns[3].Visible = true;

            dataGridViewIzinbilgileri.Columns[1].HeaderText = "İZİN BAŞLANGIÇ";
            dataGridViewIzinbilgileri.Columns[2].HeaderText = "İZİN BİTİŞ";

            dataGridViewIzinbilgileri.Columns[1].Width = 200;
            dataGridViewIzinbilgileri.Columns[2].Width = 200;


        }


   
        private void izinbuttonYeniizinEkle_Click(object sender, EventArgs e)
        {
            

            if (String.IsNullOrEmpty(label_UserID.Text))
            {
                MessageBox.Show("İzin Eklenecek Kullanıcı Bulunamadı.",
                                  "Hata",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error,
                                  MessageBoxDefaultButton.Button1);
                return;
            }

            try
            {
                using (YoklamaDbEntities db = new YoklamaDbEntities())
                {
                    var izin = new DALMssql.Izin();
                    izin.KullaniciId = int.Parse(label_UserID.Text);
                    izin.BaslamaTarihi = Convert.ToDateTime(dateTimePickerStart.Value.ToShortDateString()).AddHours(0).AddMinutes(0);
                    izin.BitisTarihi = Convert.ToDateTime(dateTimePickerStop.Value.ToShortDateString()).AddDays(-1).AddHours(23).AddMinutes(59);
                    db.Izin.Add(izin);
                    if (db.SaveChanges() > 0)
                    {
                        izingüncelle(izin.KullaniciId);
                        MessageBox.Show("İzin eklendi");

                    }
                    else
                    {
                        MessageBox.Show("Izin Eklemede Hata oldu");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
               
            }
            
        }

        private void izindataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dateTimePickerStart.Value = (DateTime)dataGridViewIzinbilgileri[1, e.RowIndex].Value;
            dateTimePickerStop.Value = (DateTime)dataGridViewIzinbilgileri[2, e.RowIndex].Value;
            label_İzinID.Text = dataGridViewIzinbilgileri[0, e.RowIndex].Value.ToString();

            buttonYeniizinEkle.Visible = false;
            button_güncelle.Visible = true;
            button_sil.Visible = true;

        }

        private void izinbutton_güncelle_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(label_İzinID.Text))
            {
                MessageBox.Show("İzin Seçimi yapılmadı",
                                    "Hata",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);

                return;
            }

            using (YoklamaDbEntities db = new YoklamaDbEntities())

            {
                var izin = db.Izin.Find(int.Parse(label_İzinID.Text));
                izin.BaslamaTarihi = dateTimePickerStart.Value;
                izin.BitisTarihi = dateTimePickerStop.Value;
                db.Entry(izin).State = EntityState.Modified;
                if (db.SaveChanges() > 0)
                {
                    izingüncelle(int.Parse(label_UserID.Text));
                    MessageBox.Show("İzin Başarıyla Güncellendi");
                    
                }
                else
                {
                    MessageBox.Show("İzin Güncellemede Veritabanı Hatası",
                                   "Hata",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error,
                                   MessageBoxDefaultButton.Button1);

                }
            }



            buttonYeniizinEkle.Visible = true;
            button_güncelle.Visible = false;
            button_sil.Visible = false;
            izinbilgileriguncelle();

        }

        private void izinbutton_sil_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(label_İzinID.Text))
            {
                MessageBox.Show("İzin Seçimi yapılmadı",
                                    "Hata",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);

                return;
            }

            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                var izin = db.Izin.Find(int.Parse(label_İzinID.Text));

                db.Izin.Remove(izin);
                if (db.SaveChanges() > 0)
                {
                    izingüncelle(int.Parse(label_UserID.Text));
                    MessageBox.Show("İzin Başarıyla Silindi");
                    

                }
                else
                {
                    MessageBox.Show("İzin Silmede Veritabanı Hatası",
                                   "Hata",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error,
                                   MessageBoxDefaultButton.Button1);

                }
            }


            buttonYeniizinEkle.Visible = true;
            button_güncelle.Visible = false;
            button_sil.Visible = false;
        }



        #endregion

        #region Tüm veri işlemleri
        private void button_CihazOkuma_Click(object sender, EventArgs e)
        {
            gridGuncelle_tumhareketler();
        }

        void gridGuncelle_tumhareketler()
        {
            Cursor = Cursors.WaitCursor;

            DateTime date_Start = Convert.ToDateTime(dateTimePicker_start_tum.Value.ToShortDateString()).AddHours(0).AddMinutes(0);
            DateTime date_Stop = Convert.ToDateTime(dateTimePicker_stop_tum.Value.ToShortDateString()).AddHours(23).AddMinutes(59);
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {


                var yoklamalar = db.OkumaKayit.Where(h => date_Start <= h.OkumaZamani & h.OkumaZamani <= date_Stop).ToList();
                int id = int.Parse(label_UserID.Text);
                var ogrenciler = db.Kullanici.Where(h => h.Id == id).ToList();
                var cihazlar = db.Cihaz.ToList();

                var genelrapor =
                    from yoklama in yoklamalar
                    join ogrenci in ogrenciler on yoklama.CihazUserID equals ogrenci.CihazUserId
                    join cihaz in cihazlar on yoklama.OkunanCihazId equals cihaz.Id
                    select new GenelRapor { cihazadi = cihaz.Adi, yoklamaId = yoklama.Id, UserId = yoklama.CihazUserID, Adı = ogrenci.AdSoyad, Tarih = yoklama.OkumaZamani, cihaz = (CihazTipi)yoklama.CihazTipi };

                dataGridView_tum_veriler.DataSource = genelrapor.ToList();
            }

            dataGridView_tum_veriler.Columns[0].Visible = false;

            dataGridView_tum_veriler.Columns[1].Visible = false;
           // dataGridView_tum_veriler.Columns[1].Width = 0;

            dataGridView_tum_veriler.Columns[2].HeaderText = "ADI SOYADI";
            dataGridView_tum_veriler.Columns[3].Width = 154;

            dataGridView_tum_veriler.Columns[3].HeaderText = "İŞLEM TARİHİ";
            dataGridView_tum_veriler.Columns[3].Width = 125;

            dataGridView_tum_veriler.Columns[4].HeaderText = "CİHAZ TİPİ";
            dataGridView_tum_veriler.Columns[4].Width = 105;

            dataGridView_tum_veriler.Columns[5].HeaderText = "CİHAZ ADI";
            dataGridView_tum_veriler.Columns[5].Width = 105;
          
            Cursor = Cursors.Default;
        }

        private void button_yenihareketekle_Click(object sender, EventArgs e)
        {

            FormYeniHareketEkle frm = new FormYeniHareketEkle();
            frm.ShowDialog();

            //herhangi değişiklik istenmiyor ise
            if (!frm.durum)
            {
                return;
            }

            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                var yoklama = new OkumaKayit();
                yoklama.OkumaZamani = frm.donentarih;
                yoklama.CihazTipi = (int)frm.cihaz.CihazTipi;
                yoklama.CihazUserID = int.Parse(textBoxCihazID.Text);
                yoklama.OkunanCihazId = frm.cihaz.Id;

                db.OkumaKayit.Add(yoklama);
                if (db.SaveChanges() > 0)
                {
                    gridGuncelle_tumhareketler();
                    MessageBox.Show("Yeni Hareket Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            MessageBox.Show("Kaydetmede Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void dataGridView_tum_veriler_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        { 
          
            HareketGuncelle frm = new HareketGuncelle(int.Parse(dataGridView_tum_veriler[1, e.RowIndex].Value.ToString()));
            frm.ShowDialog();
            gridGuncelle_tumhareketler();
        }
        #endregion

       
    }
}

