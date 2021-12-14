
namespace PVCWindowsStudio.Reports
{
    partial class OrderPhotoReportViewerForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.UriReportSource uriReportSource1 = new Telerik.Reporting.UriReportSource();
            this.reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.AccessibilityKeyMap = null;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(5);
            this.reportViewer1.Name = "reportViewer1";
            uriReportSource1.Uri = "C:\\Users\\Lenovo\\Desktop\\Customized_PvcWindowsStudio-main\\PVCWindowsStudio\\Reports" +
    "\\OrderPhotoReport.trdp";
            this.reportViewer1.ReportSource = uriReportSource1;
            this.reportViewer1.Size = new System.Drawing.Size(1200, 862);
            this.reportViewer1.TabIndex = 0;
            // 
            // OrderPhotoReportViewerForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 862);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OrderPhotoReportViewerForm1";
            this.Text = "Report Viewer Form";
            this.Load += new System.EventHandler(this.OrderPhotoReportViewerForm1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
    }
}

