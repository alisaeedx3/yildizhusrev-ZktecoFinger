using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zekotec01.DAL;
using Zekotec01.DALMssql;
using Zekotec01.Models;
using Cihaz = Zekotec01.DAL.Cihaz;

namespace Zekotec01
{
    public partial class FormCihazKullaniciYonetimi : Form
    {
        public FormCihazKullaniciYonetimi()
        {
            InitializeComponent();
        }

        private void button_OgrGüncelle_Click(object sender, EventArgs e)
        {

            CihazNesne Cihaz = new CihazNesne();
            FormCihazSeç chz = new FormCihazSeç();
            chz.ShowDialog();

            //cihaz voş işe geri dön
            if (chz._cihaz == null)
            {
                return;
            }
            Cihaz.CihazaBaglan(chz._cihaz);

            var users = Cihaz.KayitlariGetir();
            //dataGridView_ogrliste.DataSource = users.ToList();
            // gridcihazagöredüzenle();

            //using (MyContext db = new MyContext(Helpers.GetConnection()))
            using (YoklamaDbEntities db = new YoklamaDbEntities())

            {
                int dbu = db.Kullanici.Count();
                int u = users.Count;
                //kullnı ve gelen karsılasıtırması 
                if ((u - dbu) > 0)
                {
                    //MessageBox.Show();
                    DialogResult cikis = new DialogResult();
                    cikis = MessageBox.Show((u - dbu) + "Adet Yeni Kayıt Var.\nYeni Kayıtlar Veritabanına Eklensin mi? ", "Uyarı", MessageBoxButtons.YesNo);
                    if (cikis == DialogResult.Yes)
                    {
                        yenikayitlariekle(users.ToList());
                    }

                }
                else if (dbu - u > 0)
                {

                    MessageBox.Show((dbu - u) + " Adet Silinmiş Kayıt Var");

                }
                else
                {
                    MessageBox.Show("Yeni Kayıt Yok");

                }
            }
            Cursor = Cursors.Default;
        }
        /*
        private void gridcihazagöredüzenle()
        {
            dataGridView_ogrliste.Columns[0].Visible = false;
            dataGridView_ogrliste.Columns[1].Visible = true;
            dataGridView_ogrliste.Columns[2].Visible = true;
            dataGridView_ogrliste.Columns[3].Visible = false;
            dataGridView_ogrliste.Columns[4].Visible = false;
            dataGridView_ogrliste.Columns[5].Visible = false;

            dataGridView_ogrliste.Columns[1].Width = 50;
            dataGridView_ogrliste.Columns[2].Width = 150;


        }*/

        private void yenikayitlariekle(List<Kullanici> usercihaz)
        {
            //ilk kayda avatara ekleme
            //byte[] resim = new Ogrenci() { ResimImage = Zekotec01.Properties.Resources.BayanAvatar }.ConvertImageToBase64();
            byte[] resim = new Ogrenci() { ResimImage = Zekotec01.Properties.Resources.BayanAvatar }.ConvertImageToByte();


            Cursor = Cursors.WaitCursor;
            // using (MyContext db = new MyContext(Helpers.GetConnection()))
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                var usersdb = db.Kullanici.ToList();
                foreach (var item in usercihaz)
                {
                    bool deger = false;
                    // if (usersdb.All(d => d.CihazUserId != item.CihazUserId))
                    if (usersdb.Where(d => d.CihazUserId == item.CihazUserId).Count() == 0)
                    {
                        item.AileTel = "";
                        item.CepTel = "";
                        item.Resim = resim;
                        db.Kullanici.Add(item);
                        deger = true;
                    }
                    if (deger)
                    {
                        db.SaveChanges();
                    }
                }

                if (usersdb.Count > usercihaz.Count)
                {
                    foreach (var item in usersdb)
                    {
                        bool deger = false;
                        if (usercihaz.Where(d => d.CihazUserId == item.CihazUserId).Count() == 0)
                        {
                            item.AileTel = "";
                            item.CepTel = "";
                            db.Kullanici.Remove(item);
                            deger = true;
                        }
                        if (deger)
                        {
                            db.SaveChanges();
                        }
                    }
                }
            }
            Cursor = Cursors.Default;

            //dataGridView_ogrliste.DataSource = db.Users.ToList();
            MessageBox.Show("Kayıtlar Başarıyla Eklendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormCihazKullaniciYonetimi_Load(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())

            {
                Cursor = Cursors.WaitCursor;
                OgrenciGüncelle(db.Kullanici.ToList());
                Cursor = Cursors.Default;
            }
        }

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

    }
}
