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
using Telerik.WinControls.UI.Localization;

namespace PVCWindowsStudio.UI
{
    public partial class OrderForm : Telerik.WinControls.UI.RadForm
    {
        private readonly OrderBLL orderBll;
        private Orders order;
        private readonly ClientBLL clientBll;
        public OrderForm()
        {
            clientBll = new ClientBLL();
            orderBll = new OrderBLL();
            order = new Orders();
            InitializeComponent();
        }

     

        private void OrderForm_Load(object sender, EventArgs e)
        {
            InitiateData();
            clientMultiComboBox.DataSource = clientBll.GetName();
            clientMultiComboBox.SelectedIndex = -1;
            clientMultiComboBox.AutoCompleteMode = AutoCompleteMode.Append;           
            clientMultiComboBox.Text = "Zgjidhni një klient";
            discountCmb.SelectedIndex = 1;

            RadMessageBox.SetThemeName("MaterialBlueGrey");
            RadGridLocalizationProvider.CurrentProvider = new MyGridViewLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new MyMessageBoxLocalizationProvider();
        }

        
        private void InitiateData()
        {
            orderGridView.DataSource = orderBll.GetAll();
        }

        private void radMultiColumnComboBox1_EditorControl_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            lblClientID.Text = clientMultiComboBox.EditorControl.Rows[rowindex].Cells["ClientID"].Value.ToString();
        }

        private void MasterTemplate_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex > -1)
            {
                order = (Orders)orderGridView.Rows[rowindex].DataBoundItem;
                if (order != null)
                {
                    lblID.Text = order.OrderID.ToString();
                    clientMultiComboBox.SelectedValue = order.ClientID;
                    clientMultiComboBox.Text = order.Clients.FullName;
                    radDateTimePicker1.Value = order.Date;
                    txtDiscount.Text = order.Discount.ToString();
                    discountCmb.Text = order.DiscountType;
                    if (order.DiscountType == "%")
                        discountCmb.SelectedValue = 0;
                    else
                        discountCmb.SelectedValue = 1;
                    txtComment.Text = order.Comment;
                    lblClientID.Text = order.ClientID.ToString();
                }
            }
        }
        private void Clear()
        {
            clientMultiComboBox.Text = "Zgjidhni një klient";
            discountCmb.SelectedIndex = 1;

            lblID.Text = "";
            lblClientID.Text = "";
            radDateTimePicker1.Value = DateTime.Now;
            txtDiscount.Text = "";
            txtComment.Text = "";
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                decimal discount = order.Discount;
                decimal actualDiscount = Convert.ToDecimal(txtDiscount.Text);
                order.OrderID = int.Parse(lblID.Text);
                order.ClientID = int.Parse(lblClientID.Text);
                order.Date = radDateTimePicker1.Value;
                order.Discount = Convert.ToDecimal(txtDiscount.Text);
                order.DiscountType = discountCmb.Text;
                order.Comment = txtComment.Text;
                if (discount < actualDiscount)
                {
                    if (discountCmb.SelectedIndex == 1)
                        order.TotalPrice =Math.Round(order.TotalPrice - actualDiscount);
                    else
                        order.TotalPrice =Math.Round(order.TotalPrice - ((actualDiscount / 100) * order.TotalPrice));
                }
                else
                {
                    if (discountCmb.SelectedIndex == 1)                    
                        order.TotalPrice = Math.Round(order.TotalPrice + discount);                    
                    else
                        order.TotalPrice = Math.Round(order.TotalPrice + (order.Total - (order.Total-((discount / 100) * order.Total))));
                }
                order.LUB = 1;

                if (orderBll.Update(order))
                {
                    RadMessageBox.Show(MessageTexts.successUpdateOrder);
                    InitiateData();
                    Clear();
                }
                else
                    RadMessageBox.Show(MessageTexts.somethingWrong);
            }
            else
                RadMessageBox.Show(MessageTexts.selectMessageOrder);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (RadMessageBox.Show(MessageTexts.deleteMessage, "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (orderBll.DeleteAll(int.Parse(lblID.Text)))
                    {
                        RadMessageBox.Show(MessageTexts.successDeleteOrder);
                        InitiateData();
                        Clear();
                    }
                    else
                        RadMessageBox.Show(MessageTexts.somethingWrong);
                }
            }
            else
                RadMessageBox.Show(MessageTexts.selectMessageOrder);
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void printWithPhoto_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                Reports.OrderPhotoReportViewerForm1 orderReport = new Reports.OrderPhotoReportViewerForm1(int.Parse(lblID.Text));
                orderReport.Show();
            }
            else
                RadMessageBox.Show(MessageTexts.selectMessageOrder);
        }

        private void classicOrder_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                Reports.OrdersReportViewerForm orderReport = new Reports.OrdersReportViewerForm(int.Parse(lblID.Text));
                orderReport.Show();
            }
            else
                RadMessageBox.Show(MessageTexts.selectMessageOrder);
        }
        
    }
}
