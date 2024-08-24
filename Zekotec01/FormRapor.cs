using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Windows.Forms;
using Zekotec01.DAL;

namespace Zekotec01
{
    public partial class FormRapor : Form
    {
        public FormRapor(List<YoklamaView> yoklama)
        {


            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            //reset
            reportViewer1.Reset();
            
            //datasourse
            ReportDataSource ds = new ReportDataSource("DataSet1",yoklama);
            reportViewer1.LocalReport.DataSources.Add(ds);
            //path
            reportViewer1.LocalReport.ReportPath = "    ";

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.RefreshReport();

            reportViewer1.RefreshReport();



        }

        
    }
}
