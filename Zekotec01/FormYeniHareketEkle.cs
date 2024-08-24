using System;
using System.Linq;
using System.Windows.Forms;
using Zekotec01.DAL;
using Zekotec01.DALMssql;

namespace Zekotec01
{
    public partial class FormYeniHareketEkle : Form
    {
        public DateTime donentarih { get; private set; }
        public DALMssql.Cihaz cihaz { get; private set; }

        public bool durum { get; private set; }
        public FormYeniHareketEkle()
        {
            InitializeComponent();
        }

        private void button_hareket_ekle_Click(object sender, EventArgs e)
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                this.donentarih = dateTimePicker_hareket.Value;
                this.cihaz = db.Cihaz.Find(comboBox_cihaz.SelectedValue);
                this.durum = true;
                this.Close();
            }
        }

        private void FormYeniHareketEkle_Load(object sender, EventArgs e)
        {
            //cbRace.DataSource = Enum.GetValues(typeof(Races));
            //comboBox_cihaz.DataSource = Enum.GetValues(typeof(DAL.CihazTipi));

            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                comboBox_cihaz.DataSource = db.Cihaz.ToList();

                comboBox_cihaz.ValueMember = "Id";
                comboBox_cihaz.DisplayMember = "Adi";

                dateTimePicker_hareket.Format = DateTimePickerFormat.Custom;
                dateTimePicker_hareket.CustomFormat = "dd:MM:yyyy HH:mm:ss";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.durum = false;
            this.Close();
        }
    }
}
