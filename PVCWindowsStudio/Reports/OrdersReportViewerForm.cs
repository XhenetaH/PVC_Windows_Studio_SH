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
    public partial class OrdersReportViewerForm : Form
    {
        private int Id { get; set; }
        public OrdersReportViewerForm(int _id)
        {
            this.Id = _id;
            InitializeComponent();
        }
        public OrdersReportViewerForm()
        {

        }
        private void OrdersReportViewerForm_Load(object sender, EventArgs e)
        {
            this.reportViewer1.ReportSource.Parameters.Add("OrderID", Id);
            this.reportViewer1.RefreshReport();
        }
    }
}
