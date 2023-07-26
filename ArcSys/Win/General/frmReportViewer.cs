using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace CS2010.ArcSys.Win
{
    public partial class frmReportViewer : Form
    {
        public frmReportViewer()
        {
            InitializeComponent();
        }

        public void ShowReport(DataTable dt, string ReportName, string FilterText)
        {
            try 
	        {	        
                ReportDocument doc = new ReportDocument();

                doc.Load(ReportName);
                doc.SetDataSource(dt);

                doc.SetParameterValue("FilterText", FilterText);

                CRV.ReportSource = doc;



                this.Show();
	        }
	        catch (Exception ex)
	        {
                Program.ShowError(ex);
            }

        }
    }
}
