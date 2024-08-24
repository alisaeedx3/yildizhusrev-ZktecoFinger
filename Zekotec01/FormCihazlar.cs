using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Zekotec01.DAL;
using Zekotec01.DALMssql;

namespace Zekotec01
{
    public partial class FormCihazlar : Form
    {
        public FormCihazlar()
        {
            InitializeComponent();

            // Set texts of controls to English
            this.groupBox1.Text = "Device Information"; // Changing "Cihaz Bilgileri" to "Device Information"
            this.label4.Text = "Device Type"; // Changing "Cihaz Tipi" to "Device Type"
            this.button_ChzSil.Text = "Delete Device"; // Changing "Cihaz Sil" to "Delete Device"
            this.button_ChzGuncelle.Text = "Update Device"; // Changing "Cihaz Güncelle" to "Update Device"
            this.label3.Text = "Port"; // "Port" remains "Port"
            this.label2.Text = "Device IP"; // Changing "Cihaz IP" to "Device IP"
            this.button_ChazEkle.Text = "Add Device"; // Changing "Cihaz Ekle" to "Add Device"
            this.label1.Text = "Device Name"; // Changing "Cihaz Adı" to "Device Name"
            this.groupBox2.Text = "Devices"; // Changing "Cihazlar" to "Devices"
            this.Text = "Devices Management"; // Changing form title from "FormCihazlar" to "Devices Management"

        }

        private void FormCihazlar_Load(object sender, EventArgs e)
        {

            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {

                // comboBox_cihazTipi.DataSource = System.Enum.GetValues(GetType(Cihaz.CihazTipi));
                comboBox_cihazTipi.DataSource = Enum.GetValues(typeof(CihazTipi));
                //comboBox_cihazTipi.ValueMember = "Key";
                //comboBox_cihazTipi.DisplayMember = "Value";
                dataGridView_Cihazlar.DataSource = db.Cihaz.ToList();
            }
            dataGridView_Cihazlar.Columns[0].Visible = false;
            dataGridView_Cihazlar.Columns[4].Visible = false;

            //dataGridView_Cihazlar.Columns[0].Width = 1;
        }

        private void button_ChazEkle_Click(object sender, EventArgs e)
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                //Boş alanların kontrolü
                if (VeriKontrol(textBox_chzport.Text, textBox_chzip.Text, textBox_chzAdi))
                {
                    MessageBox.Show("Lütfen Boş Alanları Doldurunuz", "Cihaz Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var cihaz = new DALMssql.Cihaz();
                    cihaz.Adi = textBox_chzAdi.Text;
                    cihaz.Ip = textBox_chzip.Text;
                    cihaz.Port = int.Parse(textBox_chzport.Text.Trim());
                    cihaz.CihazTipi = comboBox_cihazTipi.SelectedIndex;

                    //label1.Text = cihaz.CihazTipi.ToString();
                    db.Cihaz.Add(cihaz);
                    if (db.SaveChanges() > 0)
                    {
                        TemizleTextBox();
                        dataGridView_Cihazlar.DataSource = db.Cihaz.ToList();
                        MessageBox.Show("Cihaz Kaydedildi", "Cihaz Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TemizleTextBox();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt işleminde Hata Oluştu. Lütfen Tekrar Deneyiniz.", "Cihaz Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }


            }

        }

        private void dataGridView_Cihazlar_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            comboBox_cihazTipi.DataSource = Enum.GetValues(typeof(CihazTipi));
            label_Id.Text = dataGridView_Cihazlar[0, e.RowIndex].Value.ToString();
            textBox_chzip.Text = dataGridView_Cihazlar[1, e.RowIndex].Value.ToString();  //dataGridView_Cihazlar.Rows[e.RowIndex].Cells[1].ToString();
            textBox_chzport.Text = dataGridView_Cihazlar[2, e.RowIndex].Value.ToString();
            textBox_chzAdi.Text = dataGridView_Cihazlar[3, e.RowIndex].Value.ToString();

            comboBox_cihazTipi.SelectedItem = Enum.Parse(typeof(CihazTipi), dataGridView_Cihazlar[4, e.RowIndex].Value.ToString());



        }

        private void button_ChzGuncelle_Click(object sender, EventArgs e)
        {
            try
            {


                using (YoklamaDbEntities db = new YoklamaDbEntities())
                {


                    if (String.IsNullOrEmpty(label_Id.Text))
                    {
                        MessageBox.Show("Cihaz Seçmelisiniz", "Cihaz Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    if (VeriKontrol(textBox_chzport.Text, textBox_chzip.Text, textBox_chzAdi))
                    {
                        MessageBox.Show("Lütfen Boş Alanları Doldurunuz", "Cihaz Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        var cihaz = db.Cihaz.Find(int.Parse(label_Id.Text));
                        cihaz.Adi = textBox_chzAdi.Text;
                        cihaz.Ip = textBox_chzip.Text;
                        cihaz.CihazTipi = (int)(Enum.Parse(typeof(CihazTipi), comboBox_cihazTipi.SelectedValue.ToString()));
                        cihaz.Port = int.Parse(textBox_chzport.Text.Trim());
                        db.Entry(cihaz).State = EntityState.Modified;

                        #region Veri Tabanı Kayıt
                        if (db.SaveChanges() > 0)
                        {
                            TemizleTextBox();
                            dataGridView_Cihazlar.DataSource = db.Cihaz.ToList();
                            MessageBox.Show(cihaz.Adi + "Cihazı Güncellendi", "Cihaz Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Silme işleminde Hata Oluştu. Lütfen Tekrar Deneyiniz.", "Cihaz Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        #endregion
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata oluştu", ex.Message, MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
            }

        }

        private bool VeriKontrol(string text1, string text2, TextBox textBox_chzAdi)
        {
            //Boş alanların kontrolü
            if (string.IsNullOrEmpty(textBox_chzAdi.Text.Trim()) || string.IsNullOrEmpty(textBox_chzip.Text.Trim()) || string.IsNullOrEmpty(textBox_chzport.Text.Trim()))
            {
                return true; // Boş
            }
            return false;//Veriler Doğru
        }

        private void button_ChzSil_Click(object sender, EventArgs e)
        {
            using (YoklamaDbEntities db = new YoklamaDbEntities())
            {
                if (string.IsNullOrEmpty(label_Id.Text))
                {
                    MessageBox.Show("Cihaz Seçmelisiniz", "Cihaz Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var cihaz = db.Cihaz.Find(int.Parse(label_Id.Text));
                    db.Cihaz.Remove(cihaz);
                    #region Veri Tabanı Kayıt


                    if (db.SaveChanges() > 0)
                    {
                        TemizleTextBox();
                        dataGridView_Cihazlar.DataSource = db.Cihaz.ToList();
                        MessageBox.Show(cihaz.Adi + "Cihazı Silindi", "Cihaz Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Silme işleminde Hata Oluştu. Lütfen Tekrar Deneyiniz.", "Cihaz Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    #endregion

                }
            }
        }

        private void TemizleTextBox()
        {
            label_Id.Text = "";
            textBox_chzip.Text = "";
            textBox_chzport.Text = "";
            textBox_chzAdi.Text = "";

        }

        private void dataGridView_Cihazlar_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView_Cihazlar_RowHeaderMouseDoubleClick(sender, e);
        }
    }
}
