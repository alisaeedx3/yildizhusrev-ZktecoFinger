using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Zekotec01.DAL;
using Zekotec01.DALMssql;
using Zekotec01.Models;

namespace Zekotec01
{
    public partial class FormTopluIzin : Form
    {
        
        public FormTopluIzin()
        {
           
            InitializeComponent();
            DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
            CheckboxColumn.TrueValue = true;
            CheckboxColumn.FalseValue = false;
            CheckboxColumn.Width = 100;
            dataGridView1.Columns.Add(CheckboxColumn);
            dataGridView1.Rows.Add(1);

            dataGridView1.Font = new FontDialogParse().GetFont();

            


        }

        private void FormTopluIzin_Load(object sender, EventArgs e)
        {
            gridGuncelle();
        }

        private void gridGuncelle()
        {
            IzinDurum d = new IzinDurum();

            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {


                dataGridView1.DataSource = db.Kullanici.Select(h => new TopluIzinVM
                {
                    KullaniciId = h.Id,
                    AdSoyad = h.AdSoyad,
                    OdaNo = h.OdaNo,
                    Izinler = h.Izin.ToList()
                }

                ).ToList();

                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[0].Width = 75;
                dataGridView1.Columns[2].Width = 300;
                dataGridView1.Columns[3].Width = 75;



            }
        }

        private void btnTopluIzın_Click(object sender, EventArgs e)
        {
            try
            {
                var IzinListesi = new List<DALMssql.Izin>();
                DALMssql.Izin izinAlacakKisi;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                   
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chk.Value == chk.TrueValue)
                    {
                        var dd = row.Cells[5].Value;
                        if (dd.ToString() == Durum.İzinli.ToString())
                            throw new Exception($"{row.Cells[2].Value} izinli öğrenci");

                        izinAlacakKisi = new DALMssql.Izin()
                        {
                            KullaniciId = int.Parse(row.Cells[1].Value.ToString()),
                            BaslamaTarihi = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString()),
                            BitisTarihi = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString()).AddHours(23).AddMinutes(59),
                            Aciklama = "Toplu izin"
                        };
                        IzinListesi.Add(izinAlacakKisi);
                    }

                }

                using (var db = new YoklamaDbEntities())
                {
                    db.Izin.AddRange(IzinListesi);
                    db.SaveChanges();
                }
                gridGuncelle();
                MessageBox.Show($"{IzinListesi.Count.ToString()} öğrencye {dateTimePicker1.Value} - {dateTimePicker2.Value} tarihleri arasında izin verildi");
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hata :{ex.Message} \n {ex.InnerException}");
            }
            
            
        }
    }
}
