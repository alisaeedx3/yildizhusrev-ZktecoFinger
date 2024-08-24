using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zekotec01.Models;

namespace Zekotec01
{
    public partial class FormAyarlar : Form
    {

        public FormAyarlar()
        {
            InitializeComponent();
            testlabelUpdate();

            // Set texts of controls to English
            this.button1.Text = "Grid Views"; // Changing "Grid Görünümleri" to "Grid Views"
            this.labeltest.Text = "Test Size - Font Family"; // Assuming this is already in English, no change needed
            this.Text = "Settings"; // Changing form title from "FormAyarlar" to "Settings"

        }

        private void testlabelUpdate()
        {
            FontDialogParse ff = new FontDialogParse();
            var f = ff.GetFont();
            labeltest.Font = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FontDialog fontdlg = new FontDialog();
            fontdlg.ShowColor = true;
            fontdlg.MaxSize = 20;
            fontdlg.MinSize = 12;
            fontdlg.ShowDialog();

            
            FontDialogParse ff = new FontDialogParse();
            var f = ff.SaveFont(fontdlg.Font);

            testlabelUpdate();
        }
    }
}
