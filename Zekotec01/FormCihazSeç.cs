using System;
using System.Linq;
using System.Windows.Forms;
using Zekotec01.DALMssql;

namespace Zekotec01
{
    public partial class FormCihazSeç : Form
    {
        public DALMssql.Cihaz _cihaz { get; private set; }
        public FormCihazSeç()
        {
            InitializeComponent();
        }

        private void FormCihazSeç_Load(object sender, EventArgs e)
        {
            using (DALMssql.YoklamaDbEntities db = new YoklamaDbEntities())
            {
                var cihazlar = db.Cihaz.ToList();
                if (cihazlar.Count==0)
                {
                    MessageBox.Show("Tanımlı Cihaz Bulunamadı. Cihaz Tanımlamalısınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    this.Close();

                }
                comboBox1.DataSource = cihazlar;
                comboBox1.ValueMember = "Id";
                comboBox1.DisplayMember = "Adi";
            }
        }

        private void button_Tamam_Click(object sender, EventArgs e)
        {
            using (DALMssql.YoklamaDbEntities db = new YoklamaDbEntities())
            {
                this._cihaz = db.Cihaz.Find(comboBox1.SelectedValue);
            }
            this.Close(); 
        }
    }
}
