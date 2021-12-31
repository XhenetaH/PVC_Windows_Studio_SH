using PVCWindowsStudio.BLL;
using PVCWindowsStudio.BO;
using PVCWindowsStudio.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace PVCWindowsStudio.UI
{
    public partial class InvoiceForm : Telerik.WinControls.UI.RadForm
    {
        private OrderBLL orderBll;
        private InvoiceBLL invoiceBll;
        private Invoices invoice;
        
        public InvoiceForm()
        {
            invoice = new Invoices();
            orderBll = new OrderBLL();
            invoiceBll = new InvoiceBLL();
            InitializeComponent();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            OrderInitData();
            InvoiceInitData();
            RadMessageBox.SetThemeName("MaterialBlueGrey");
            RadGridLocalizationProvider.CurrentProvider = new MyGridViewLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new MyMessageBoxLocalizationProvider();           
        }
        private void OrderInitData()
        {            
            OrderradGridView.DataSource = orderBll.GetAllExist();
        }
        private void InvoiceInitData()
        {
            InvoiceradGridView.DataSource = invoiceBll.GetAll();
        }
        private void OrderradGridView_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                var order = (Orders)OrderradGridView.Rows[rowindex].DataBoundItem;
                invoice.OrderID = order.OrderID;
                invoice.Paid = 0;
                invoice.Debt = order.TotalPrice;
                invoice.Date = DateTime.Now;
                invoice.InsertBy = 1;

                if (RadMessageBox.Show(MessageTexts.saveInvoice, "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (invoiceBll.Insert(invoice))
                    {
                        RadMessageBox.Show(MessageTexts.successInsertInvoice);
                        InvoiceInitData();
                        OrderInitData();
                    }
                    else
                        RadMessageBox.Show(MessageTexts.somethingWrong);
                }
            }
            
        }

        private void InvoiceradGridView_CellClick(object sender, GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                invoice = (Invoices)InvoiceradGridView.Rows[rowindex].DataBoundItem;
                lblID.Text = invoice.InvoiceID.ToString();
                txtClient.Text = invoice.Order.Clients.FullName.ToString();
                txtTotalPrice.Text = invoice.Order.TotalPrice.ToString();
                txtPaid.Text = invoice.Paid.ToString();
                txtDebt.Text = invoice.Debt.ToString();
                radDateTimePicker1.Value = invoice.Date;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                invoice.InvoiceID = int.Parse(lblID.Text);
                invoice.Paid = Convert.ToDecimal(txtPaid.Text);
                invoice.Debt = Convert.ToDecimal(txtDebt.Text);
                invoice.Date = radDateTimePicker1.Value;
                invoice.LUB = 1;

                if (invoiceBll.Update(invoice))
                {
                    RadMessageBox.Show(MessageTexts.successUpdateInvoice);
                    InvoiceInitData();                    
                    Clear();
                }
                else
                    RadMessageBox.Show(MessageTexts.somethingWrong);
            }
            else RadMessageBox.Show(MessageTexts.selectMessageInvoice);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (RadMessageBox.Show(MessageTexts.deleteMessage, "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (invoiceBll.Delete(int.Parse(lblID.Text),invoice.OrderID))
                    {
                        RadMessageBox.Show(MessageTexts.successDeleteInvoice);
                        InvoiceInitData();
                        OrderInitData();
                        Clear();
                    }
                    else
                        RadMessageBox.Show(MessageTexts.somethingWrong);
                }
            }
            else
                RadMessageBox.Show(MessageTexts.selectMessageInvoice);
        }

        private void Clear()
        {
            lblID.Text = "";
            txtClient.Text = "";            
            txtPaid.Text = "";
            txtTotalPrice.Text = "";
            txtDebt.Text = "";
            radDateTimePicker1.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                Reports.InvoiceReportViewerForm invoiceReport = new Reports.InvoiceReportViewerForm(int.Parse(lblID.Text));
                invoiceReport.Show();
            }
            else
                RadMessageBox.Show(MessageTexts.selectMessageInvoice);
        }       
        private void InvoiceradGridView_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.Name == "Paid" && e.Row.Cells["Paid"].Value.ToString() == e.Row.Cells["Total"].Value.ToString())
            {
                e.CellElement.DrawFill = true;
                e.CellElement.BackColor = Color.FromArgb(192, 255, 192);
                e.CellElement.NumberOfColors = 1;

            }
            else if(e.Column.Name == "Debt" && Convert.ToDecimal(e.Row.Cells["Debt"].Value) > 0)
            {
                e.CellElement.DrawFill = true;
                e.CellElement.BackColor = Color.FromArgb(255, 192, 192);
                e.CellElement.NumberOfColors = 1;
            }
            else
            {
                e.CellElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                e.CellElement.ResetValue(LightVisualElement.NumberOfColorsProperty, ValueResetFlags.Local);
            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            txtDebt.Text = (Convert.ToDecimal(txtTotalPrice.Text) - Convert.ToDecimal(txtPaid.Value)).ToString();
        }
    }
}
