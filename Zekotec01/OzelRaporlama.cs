using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Zekotec01.DAL;
using Zekotec01.DALMssql;
using Zekotec01.Models;

namespace Zekotec01
{
    public partial class OzelRaporlama : Form
    {
        public OzelRaporlama()
        {
            InitializeComponent();
            AutoComplate();
        }

        private void buttonRaporla_Click(object sender, EventArgs e)
        {

            try
            {


                //MyContext db2 = new MyContext(Helpers.GetConnection());
                using (YoklamaDbEntities db2 = new YoklamaDbEntities())
                {
                    var ydf2 = db2.YoklamaZamani.FirstOrDefault();

                    if (ydf2 == null)
                    {
                        MessageBox.Show("Günlük Yoklama Aralığı bulunamad");
                        return;
                    }
                    Rapor rapor = new Rapor();
                    rapor.date_Start = ZamanAyarlari.Rapor_date_start_Get(dateTimePickerStart.Value,ydf2);  //Convert.ToDateTime(dateTimePickerStart.Value.ToShortDateString()).AddHours(0).AddMinutes(0);
                    rapor.date_Stop = ZamanAyarlari.Rapor_date_stop_Get(dateTimePickerStop.Value,ydf2);     //Convert.ToDateTime(dateTimePickerStop.Value.ToShortDateString()).AddHours(23).AddMinutes(59);
                    if (!String.IsNullOrEmpty(textBoxAdSoyad.Text))
                    {
                        rapor.user_Id = db2.Kullanici.Where(h => h.AdSoyad == textBoxAdSoyad.Text).FirstOrDefault().CihazUserId;
                        if (String.IsNullOrEmpty(rapor.user_Id.ToString()))
                        {
                            MessageBox.Show("Kullanıcı Bulunamadı",
                                            "Hata",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error,
                                            MessageBoxDefaultButton.Button1);
                            return;
                        }

                    }
                    List<YoklamaView> yoklama = rapor.raporGetirTarihlerArasi();
                    int fark = (dateTimePickerStop.Value.Day - dateTimePickerStart.Value.Day) + 1; //ZamanAyarlari.RaporGunSayisiGet(dateTimePickerStart.Value, dateTimePickerStop.Value) + 1;

                    label_izin.Text = (yoklama.Where(h => h.yoklama == "İZİNLİ").Count() / fark).ToString();
                    label_toplam.Text = (yoklama.Count() / fark).ToString();
                    label_mevcut.Text = (int.Parse(label_toplam.Text) - int.Parse(label_izin.Text)).ToString();
                    gridGuncelle(yoklama);


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        void gridGuncelle(List<YoklamaView> yoklama)
        {
            //reset
            reportViewer1.Reset();

            //datasourse
            ReportDataSource ds = new ReportDataSource("DataSet1", yoklama.OrderBy(h=>h.yoklama));
            reportViewer1.LocalReport.DataSources.Add(ds);
            //path
            reportViewer1.LocalReport.ReportPath = "Ryoklama.rdlc";
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.RefreshReport();

        }


        void AutoComplate()
        {
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


        private void OzelRaporlama_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }


    }
}
