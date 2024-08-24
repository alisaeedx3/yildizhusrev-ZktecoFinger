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


namespace Zekotec01
{
    public partial class HareketGuncelle : Form
    {
        public HareketGuncelle(int? id)
        {
            InitializeComponent();
            if (id==null)
            {
                MessageBox.Show("Yoklama Kaydı Seçilmedi");
                this.Close();
            }
            label_ID.Text = id.ToString();
           

        }

        private void HareketGuncelle_Load(object sender, EventArgs e)
        {

            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                comboBox_cihaz.DataSource = db.Cihaz.ToList();
                comboBox_cihaz.ValueMember = "Id";
                comboBox_cihaz.DisplayMember = "Adi";

                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "dd:MM:yyyy HH:mm:ss";

                var yk = db.OkumaKayit.Find(int.Parse(label_ID.Text));
                dateTimePicker1.Value = yk.OkumaZamani;
                comboBox_cihaz.SelectedValue = yk.OkunanCihazId;

            }

        }

        private void button_guncelle_Click(object sender, EventArgs e)
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                var yk = db.OkumaKayit.Find(int.Parse(label_ID.Text));
                var cihaz = db.Cihaz.Find(comboBox_cihaz.SelectedValue);
                yk.OkumaZamani = dateTimePicker1.Value;
                yk.CihazTipi = cihaz.CihazTipi;
                yk.OkunanCihazId = cihaz.Id;
                db.Entry(yk).State = System.Data.Entity.EntityState.Modified;
                if (db.SaveChanges()>0)
                {
                    MessageBox.Show("Kayıt Güncellendi");
                    this.Close();
                    return;
                }
                MessageBox.Show("Hareket Kayıt Güncellemede Hata Oluştu.",
                                    "Hatas",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1);
          
               
            }
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                var yk = db.OkumaKayit.Find(int.Parse(label_ID.Text));
                db.OkumaKayit.Remove(yk);
                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("Kayıt Silindi");
                    this.Close();
                    return;
                }
                
                MessageBox.Show("Hareket Kayıt Silmede Hata Oluştu.",
                                   "Hatas",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error,
                                   MessageBoxDefaultButton.Button1);

            }
        }
    }
}
