using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Zekotec01.DAL;
using Zekotec01.DALMssql;
using Zekotec01.Models;

namespace Zekotec01
{
    public partial class OkunanTumVeriler : Form
    {
        public OkunanTumVeriler()
        {
            InitializeComponent();
            AutoComplate();
            this.dataGridView1.Font = new FontDialogParse().GetFont();
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; //DataGridViewAutoSizeColumnMode.AllCells;


            ////dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ////dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }



        private void buttonRaporla_Click(object sender, EventArgs e)
        {
            gridGuncelle();
        }

        void gridGuncelle()
        {
            Cursor = Cursors.WaitCursor;
            //using (MyContext db = new MyContext(Helpers.GetConnection()))
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {


                DateTime date_Start = Convert.ToDateTime(dateTimePickerStart.Value.ToShortDateString()).AddHours(0).AddMinutes(0);
                DateTime date_Stop = Convert.ToDateTime(dateTimePickerStop.Value.ToShortDateString()).AddHours(23).AddMinutes(59);

                var yoklamalar = db.OkumaKayit.Where(h => (date_Start <= h.OkumaZamani) & (h.OkumaZamani <= date_Stop)).ToList();
                var ogrenciler = db.Kullanici.ToList();
                if (!String.IsNullOrEmpty(textBoxAdSoyad.Text))
                {
                    ogrenciler = db.Kullanici.Where(h => h.AdSoyad == textBoxAdSoyad.Text).ToList();
                }


                var cihazlar = db.Cihaz.ToList();

                var genelrapor =
                    from yoklama in yoklamalar
                    join ogrenci in ogrenciler on yoklama.CihazUserID equals ogrenci.CihazUserId
                    join cihaz in cihazlar on yoklama.OkunanCihazId equals cihaz.Id
                    select new GenelRapor { cihazadi = cihaz.Adi, yoklamaId = yoklama.Id, UserId = yoklama.CihazUserID, Adı = ogrenci.AdSoyad, Tarih = yoklama.OkumaZamani, cihaz = (CihazTipi)yoklama.CihazTipi };

                dataGridView1.DataSource = genelrapor.ToList();

            }
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Width = 300;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 75;
            dataGridView1.Columns[5].Width = 75;
       




            Cursor = Cursors.Default;
        }


        void AutoComplate()
        {
            //MyContext db2 = new MyContext(Helpers.GetConnection());
            using (YoklamaDbEntities db2 = new YoklamaDbEntities())
            {


                textBoxAdSoyad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBoxAdSoyad.AutoCompleteSource = AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
                foreach (var item in db2.Kullanici.Select(k => k.AdSoyad).ToList())
                {
                    coll.Add(item);
                }
                textBoxAdSoyad.AutoCompleteCustomSource = coll;
            }
        }


        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            HareketGuncelle frm = new HareketGuncelle(int.Parse(dataGridView1[1, e.RowIndex].Value.ToString()));
            frm.ShowDialog();
            gridGuncelle();


        }

      
    }
}
