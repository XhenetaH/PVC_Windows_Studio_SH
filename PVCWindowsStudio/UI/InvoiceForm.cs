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

                if (RadMessageBox.Show("Are you sure you want to save this order as a invoice?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (invoiceBll.Insert(invoice))
                    {
                        RadMessageBox.Show("Invoice inserted successfully!");
                        InvoiceInitData();
                        OrderInitData();
                    }
                    else
                        RadMessageBox.Show("Something went wrong!");
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

                txtPay.ReadOnly = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (ValidationMethod())
                {
                    invoice.InvoiceID = int.Parse(lblID.Text);
                    invoice.Paid = Convert.ToDecimal(txtPaid.Text);
                    invoice.Debt = Convert.ToDecimal(txtDebt.Text);
                    invoice.Date = radDateTimePicker1.Value;
                    invoice.LUB = 1;

                    if (invoiceBll.Update(invoice))
                    {
                        RadMessageBox.Show("Invoice updated successfully!");
                        InvoiceInitData();
                        Clear();
                    }
                    else
                        RadMessageBox.Show("Something went wrong!");
                }
            }
            else RadMessageBox.Show("Please select an invoice!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (RadMessageBox.Show("Are you sure you want to delete this?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (invoiceBll.Delete(int.Parse(lblID.Text)))
                    {
                        RadMessageBox.Show("Invoice deleted successfully!");
                        InvoiceInitData();
                        OrderInitData();
                        Clear();
                    }
                    else
                        RadMessageBox.Show("Something went wrong!");
                }
            }
            else
                RadMessageBox.Show("Please select an invoice!");
        }

        private void Clear()
        {
            lblID.Text = "";
            txtClient.Text = "";
            txtDebt.Text = "";
            txtPaid.Text = "";
            txtTotalPrice.Text = "";
            txtPay.Text = "";
            txtPay.ReadOnly = true;
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
                RadMessageBox.Show("Please select an invoice!");
        }
        private bool ValidationMethod()
        {
            bool valid = true;
            if (this.radValidationProvider1.ValidationMode == ValidationMode.Programmatically)
            {
                foreach (Control control in this.radPanel1.Controls)
                {
                    RadEditorControl editorControl = control as RadEditorControl;
                    if (editorControl != null)
                    {
                        this.radValidationProvider1.Validate(editorControl);
                        var mode = this.radValidationProvider1.AssociatedControls;
                        decimal nr;
                        foreach (var i in mode)
                        {
                            if (!decimal.TryParse(i.AccessibilityObject.Value, out nr))
                                valid = false;
                        }
                    }
                }
            }
            return valid;
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

        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            if (ValidationMethod())
            {
                if (String.IsNullOrEmpty(txtPay.Value.ToString()))
                {
                    txtDebt.Text = (invoice.Debt - 0).ToString();
                    txtPaid.Text = invoice.Paid.ToString();
                }
                else
                {
                    txtDebt.Text = (invoice.Debt - Convert.ToDecimal(txtPay.Value)).ToString();
                    txtPaid.Text = (invoice.Order.TotalPrice - Convert.ToDecimal(txtDebt.Text)).ToString();
                }
            }
        }

    }
}
