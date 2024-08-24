using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Zekotec01.DALMssql;

namespace Zekotec01
{
    public partial class FormYoklamaDefault : Form
    {

        public FormYoklamaDefault()
        {
            InitializeComponent();

            // Set texts of controls to English
            this.groupBox1.Text = "Daily Attendance Scheduling"; // Changing "Günlük Yoklama Zamanlama" to "Daily Attendance Scheduling"
            this.label1.Text = "Attendance Start Time"; // Changing "Yoklama Başlangıç Saati" to "Attendance Start Time"
            this.label2.Text = "Attendance Duration Time"; // Changing "Yoklama Süresi Zamanı" to "Attendance Duration Time"
            this.label3.Text = "hr."; // Changing "s." to "hr."
            this.label4.Text = "min."; // Changing "dk." to "min."
            this.button_kaydet.Text = "Save"; // Changing "Kaydet" to "Save"
            this.Text = "Default Attendance Form"; // Changing form title to "Default Attendance Form"


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "HH:mm";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "HH:mm";
        }



        private void FormYoklamaDefault_Load(object sender, EventArgs e)
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {

                var ydf = db.YoklamaZamani.SingleOrDefault();
                if (ydf == null)
                {
                    YoklamaZamani ydf1 = new YoklamaZamani
                    {
                        BaslamaSaati = dateTimePicker1.Value,
                        BitisSaati = dateTimePicker2.Value,
                    };

                    db.YoklamaZamani.Add(ydf1);
                    if (db.SaveChanges() < 1)
                    {
                        MessageBox.Show("Varsayılan yoklama oluşturmada hata");
                        return;
                    }
                    ydf = ydf1;
                }
                else
                {
                    dateTimePicker1.Value = ydf.BaslamaSaati;
                    dateTimePicker2.Value = ydf.BitisSaati;
                    textBox_Sure.Text = ydf.Sure.ToString();
                    textBox_Dakika.Text = ydf.Dakika.ToString();
                }

            }

        }

        private void button_kaydet_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox_Sure.Text))
                textBox_Sure.Text = "1";

            if (string.IsNullOrEmpty(textBox_Dakika.Text))
                textBox_Sure.Text = "1";

            try
            {
                using (YoklamaDbEntities db = new YoklamaDbEntities())
                {


                    var ydf = db.YoklamaZamani.FirstOrDefault();
                    ydf.BaslamaSaati = dateTimePicker1.Value;
                    ydf.BitisSaati = dateTimePicker2.Value;
                    ydf.Sure = int.Parse(textBox_Sure.Text);
                    ydf.Dakika = int.Parse(textBox_Dakika.Text);

                    db.Entry(ydf).State = EntityState.Modified;
                   
                    MessageBox.Show(db.SaveChanges() > 0
                        ? "Varsayılan yoklama oluşturuldu"
                        : "Varsayılan yoklama oluşturmada hata !!!! ");
                    this.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Varsayılan yoklama oluşturmada hata" + ex.Message);
            }

        }
    }
}
