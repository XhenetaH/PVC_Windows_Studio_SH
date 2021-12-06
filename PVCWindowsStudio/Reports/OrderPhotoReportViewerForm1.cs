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
    public partial class OrderPhotoReportViewerForm1 : Form
    {
        private int Id { get; set; }
        
        public OrderPhotoReportViewerForm1(int id)
        {
            this.Id = id;
            InitializeComponent();
        }

        private void OrderPhotoReportViewerForm1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.ReportSource.Parameters.Add("OrderID", Id);
            this.reportViewer1.RefreshReport();
        }
    }
}
