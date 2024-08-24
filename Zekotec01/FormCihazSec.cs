using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zekotec01.DALMssql;
using Zekotec01.Models;

namespace Zekotec01
{
    public partial class FormCihazSec : Form
    {
        public List<Cihaz> cihazlarRetun;
        private List<Cihaz> cihazlar;
        public FormCihazSec(List<Cihaz> _cihazlar)
        {
            cihazlar = _cihazlar;
            InitializeComponent();
            DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
            CheckboxColumn.TrueValue = true;
            CheckboxColumn.FalseValue = false;
            CheckboxColumn.Width = 100;
            dataGridView1.Columns.Add(CheckboxColumn);
            dataGridView1.Rows.Add(1);
            dataGridView1.DataSource = cihazlar.Select(h => new { Id = h.Id, CihazAdı = h.Adi }).ToList();
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Font = new FontDialogParse().GetFont();
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.RowHeadersVisible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (chk.Value == chk.FalseValue || chk.Value == null)
                {
                    int Id = int.Parse(row.Cells[1].Value.ToString());
                    cihazlar.Remove(cihazlar.Where(h => h.Id == Id).FirstOrDefault());
                }

            }

            this.cihazlarRetun = cihazlar;
            this.Close();
        }
    }
}
