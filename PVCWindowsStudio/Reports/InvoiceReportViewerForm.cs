using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PVCWindowsStudio.Reports
{
    public partial class InvoiceReportViewerForm : Form
    {
        private int Id { get; set; }
        public InvoiceReportViewerForm(int id)
        {
            this.Id = id;
            InitializeComponent();
        }

        private void InvoiceReportViewerForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.ReportSource.Parameters.Add("InvoiceID", Id);
            this.reportViewer1.RefreshReport();
        }
    }
}
