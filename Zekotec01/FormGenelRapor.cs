using Microsoft.Reporting.WinForms;
using System.Collections.Generic;
using System.Windows.Forms;
using Zekotec01.DAL;

namespace Zekotec01
{
    public partial class FormGenelRapor : Form
    {
        public FormGenelRapor(List<GenelRapor> rapor)
        {

            InitializeComponent();
            //reset
            reportViewer1.Reset();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            //datasourse
            ReportDataSource ds = new ReportDataSource("DataSetGenel", rapor);
            reportViewer1.LocalReport.DataSources.Add(ds);
            //path
            reportViewer1.LocalReport.ReportPath = "ReportGenel.rdlc";

           
           
            reportViewer1.RefreshReport();


        }

       
    }
}
