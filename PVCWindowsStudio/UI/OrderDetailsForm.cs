using PVCWindowsStudio.BLL;
using PVCWindowsStudio.BLL.FormModels;
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
    public partial class OrderDetailsForm : Telerik.WinControls.UI.RadForm
    {
        private readonly OderDetailsModel orderM = new OderDetailsModel();
        public OrderDetailsForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            InitOrderData();

            productMultiColumnComboBox1.DataSource = orderM.productBLL.GetExistProd();
            productMultiColumnComboBox1.AutoCompleteMode = AutoCompleteMode.Append;
            productMultiColumnComboBox1.EditorControl.TableElement.RowHeight = 110;
            productMultiColumnComboBox1.ValueMember = "ProductID";
            productMultiColumnComboBox1.SelectedIndex = -1;
            productMultiColumnComboBox1.Text = "Zgjidhni një produkt";

            ddlBlinds.DataSource = orderM.blindBll.GetAll();
            ddlBlinds.DisplayMember = "Name";
            ddlBlinds.ValueMember = "BlindID";
            ddlBlinds.SelectedIndex = -1;
            ddlBlinds.Text = "Zgjidhni roletat";

            ddlProfile.DataSource = orderM.profileBll.GetExistProfile();
            ddlProfile.DisplayMember = "NameProf";
            ddlProfile.ValueMember = "ProfileID";
            ddlProfile.SelectedIndex = -1;
            ddlProfile.Text = "Zgjidhni një profil";

            ddlWindowPane.DataSource = orderM.windowpaneBll.GetAll();
            ddlWindowPane.DisplayMember = "Name";
            ddlWindowPane.ValueMember = "WindowPaneID";
            ddlWindowPane.SelectedIndex = -1;
            ddlWindowPane.Text = "Zgjidhni llojin e xhamave";

            RadMessageBox.SetThemeName("MaterialBlueGrey");
            RadGridLocalizationProvider.CurrentProvider = new MyGridViewLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new MyMessageBoxLocalizationProvider();

        }

        private bool ValidationMethod()
        {
            bool valid = true;
            if (this.radValidationProvider1.ValidationMode == ValidationMode.Programmatically)
            {
                foreach (Control control in this.radPanel5.Controls)
                {
                    RadEditorControl editorControl = control as RadEditorControl;
                    if (editorControl != null)
                    {
                        this.radValidationProvider1.Validate(editorControl);
                        var mode = this.radValidationProvider1.AssociatedControls;
                        for (int i = 0; i < mode.Count; i++)
                        {
                            if (mode[i].Text == "Zgjidhni një produkt" || mode[i].Text == "0" || mode[i].Text == "Zgjidhni roletat"
                                || mode[i].Text == "Zgjidhni një profil" || mode[i].Text == "Zgjidhni llojin e xhamave")
                            {
                                valid = false;
                            }
                        }
                    }
                }
            }
            return valid;
        }


        private void InitOrderData()
        {
            orderMultiComboBox.DataSource = orderM.ordersBLL.GetAll();            
            orderMultiComboBox.AutoCompleteMode = AutoCompleteMode.Append;
            orderMultiComboBox.ValueMember = "OrderID";            
            orderMultiComboBox.DisplayMember = "OrderID";
            orderMultiComboBox.Text = "Zgjidhni një ofertë";         
        }

        private void radMultiColumnComboBox1_EditorControl_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                int id = int.Parse(orderMultiComboBox.EditorControl.Rows[rowindex].Cells["OrderID"].Value.ToString());
                lblOrderID.Text = id.ToString();
            }
        }

        private void productMultiColumnComboBox_EditorControl_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                orderM.details.Product = (Products)productMultiColumnComboBox1.EditorControl.Rows[rowindex].DataBoundItem;
                lblProductID.Text = orderM.details.Product.ProductID.ToString();
                if (orderM.details.Product.Picture?.Length > 0)
                    radPictureBox1.Image = ConvertToImage(orderM.details.Product.Picture);
                else
                    radPictureBox1.Image = null;
            }
        }

        private void lblOrderID_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblOrderID.Text))
                InitOrderDetailsData(int.Parse(lblOrderID.Text));
        }

        private void InitOrderDetailsData(int id)
        {
            orderDetailsradGridView.DataSource = orderM.detailsBLL.GetAll(id);
        }
        private void orderDetailsradGridView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                orderM.details = (OrderDetails)orderDetailsradGridView.Rows[rowindex].DataBoundItem;
                if (orderM.details != null)
                {
                    lblID.Text = orderM.details.OrderDetailsID.ToString();
                    txtWidth.Text = orderM.details.Width.ToString();
                    txtHeight.Text = orderM.details.Height.ToString();
                    txtQuantity.Text = orderM.details.Quantity.ToString();
                    ddlBlinds.Text = orderM.details.Blind.Name;
                    ddlBlinds.SelectedValue = orderM.details.BlindID;
                    ddlProfile.Text = orderM.details.Profile.NameProf;
                    ddlProfile.SelectedValue = orderM.details.ProfileID;
                    ddlWindowPane.Text = orderM.details.WindowPane.Name;
                    ddlWindowPane.SelectedValue = orderM.details.WindowPaneID;
                    productMultiColumnComboBox1.Text = orderM.details.Product.Name;
                    lblProductID.Text = orderM.details.ProductID.ToString();
                    if (orderM.details.Product.Picture?.Length > 0)
                        radPictureBox1.Image = ConvertToImage(orderM.details.Product.Picture);
                    else
                        radPictureBox1.Image = null;

                }
            }
        }
        private Image ConvertToImage(byte[] array)
        {
            Image x = (Bitmap)((new ImageConverter()).ConvertFrom(array));
            return x;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (radPictureBox1.Image != null)
                {
                    if (ValidationMethod())
                    {
                        total = TotalPrice();
                        var price = orderM.details.Total;
                        orderM.details.OrderDetailsID = int.Parse(lblID.Text);
                        orderM.details.Width = int.Parse(txtWidth.Text);
                        orderM.details.Height = int.Parse(txtHeight.Text);
                        orderM.details.Quantity = int.Parse(txtQuantity.Text);
                        orderM.details.BlindID = int.Parse(ddlBlinds.SelectedValue.ToString());
                        orderM.details.ProfileID = int.Parse(ddlProfile.SelectedValue.ToString());
                        orderM.details.ProductID = int.Parse(lblProductID.Text);
                        orderM.details.WindowPaneID = int.Parse(ddlWindowPane.SelectedValue.ToString());
                        orderM.details.HandWorkPrice = orderM.handiWorkBLL.GetPrice(orderM.details.Width, orderM.details.Height);
                        orderM.details.Price = Session.Methods.CalcPrice(orderM.details.ProductID, txtWidth.Value.ToString(), txtHeight.Value.ToString(), orderM.details.ProfileID, orderM.details.BlindID, orderM.blindBll.GetPrice(orderM.details.BlindID), orderM.windowpaneBll.GetPrice(orderM.details.WindowPaneID), orderM.details.WindowPaneID, orderM.detailsBLL.GetPrice(orderM.details.ProfileID, orderM.details.ProductID),orderM.details.HandWorkPrice);
                        orderM.details.Total = orderM.details.Price * orderM.details.Quantity;
                        orderM.details.LUB = 1;

                        orderM.order.OrderID = int.Parse(lblOrderID.Text);
                        if (price < orderM.details.Total)
                            orderM.order.TotalPrice = total + (orderM.details.Total - price);
                        else
                            orderM.order.TotalPrice = total - (price - orderM.details.Total);

                        orderM.order.LUB = 1;
                        if (orderM.detailsBLL.Update(orderM.details) && orderM.ordersBLL.UpdatePrice(orderM.order))
                        {
                            RadMessageBox.Show(MessageTexts.successUpdateOrderDetails);
                            InitOrderDetailsData(orderM.details.OrderID);
                            Clear();

                        }
                        else
                            RadMessageBox.Show(MessageTexts.somethingWrong);
                    }
                }
                else
                    RadMessageBox.Show(MessageTexts.productCantBeEmpty);
            }
            else
                RadMessageBox.Show(MessageTexts.successUpdateOrderDetails);
        }

        decimal total = 0;
        private decimal TotalPrice()
        {
            decimal total = 0;
            for (int i = 0; i < orderDetailsradGridView.RowCount; i++)
            {
                total += Convert.ToDecimal(orderDetailsradGridView.Rows[i].Cells["Total"].Value);
            }
            return total;
        }
        private void Clear()
        {
            lblProductID.Text = "";
            txtHeight.Text = "";
            txtWidth.Text = "";
            txtQuantity.Text = "";
            lblID.Text = "";
            ddlWindowPane.SelectedIndex = -1;
            ddlWindowPane.Text = "Zgjidhni llojin e xhamave";
            ddlProfile.SelectedIndex = -1;
            ddlProfile.Text = "Zgjidhni një profil";
            ddlBlinds.SelectedIndex = -1;
            ddlBlinds.Text = "Zgjidhni roletat";
            productMultiColumnComboBox1.SelectedIndex = -1;
            productMultiColumnComboBox1.Text = "Zgjidhni një produkt";
            radPictureBox1.Image = null;
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
                    orderM.detailsBLL.Delete(int.Parse(lblID.Text));
                    InitOrderDetailsData(orderM.details.OrderID);
                    if (orderDetailsradGridView.RowCount == 0)
                    {
                        if (orderM.ordersBLL.Delete(orderM.details.OrderID))
                        {
                            RadMessageBox.Show(MessageTexts.successDeleteOrderDetails);
                            InitOrderData();
                        }
                        else RadMessageBox.Show(MessageTexts.somethingWrong);
                    }
                    Clear();
                }
            }
            else RadMessageBox.Show(MessageTexts.selectMessageOrderDetails);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblOrderID.Text))
            {
                if (ValidationMethod())
                {
                    orderM.details.OrderID = int.Parse(lblOrderID.Text);
                    orderM.details.Width = int.Parse(txtWidth.Text);
                    orderM.details.Height = int.Parse(txtHeight.Text);
                    orderM.details.Quantity = int.Parse(txtQuantity.Text);
                    orderM.details.BlindID = int.Parse(ddlBlinds.SelectedValue.ToString());
                    orderM.details.ProfileID = int.Parse(ddlProfile.SelectedValue.ToString());
                    orderM.details.ProductID = int.Parse(productMultiColumnComboBox1.SelectedValue.ToString());
                    orderM.details.WindowPaneID = int.Parse(ddlWindowPane.SelectedValue.ToString());
                    orderM.details.HandWorkPrice = orderM.handiWorkBLL.GetPrice(orderM.details.Width,orderM.details.Height);
                    orderM.details.Price = Session.Methods.CalcPrice(orderM.details.ProductID, txtWidth.Text, txtHeight.Text, orderM.details.ProfileID, orderM.details.BlindID, orderM.blindBll.GetPrice(orderM.details.BlindID), orderM.windowpaneBll.GetPrice(orderM.details.WindowPaneID), orderM.details.WindowPaneID, orderM.detailsBLL.GetPrice(orderM.details.ProfileID, orderM.details.ProductID),orderM.details.HandWorkPrice);
                    orderM.details.Total = orderM.details.Price * orderM.details.Quantity;
                    orderM.details.InsertBy = 1;

                    orderM.order.OrderID = int.Parse(lblOrderID.Text);
                    orderM.order.TotalPrice = TotalPrice() + orderM.details.Total;
                    orderM.order.LUB = 1;
                    if (orderM.detailsBLL.Insert(orderM.details) && orderM.ordersBLL.UpdatePrice(orderM.order))
                    {
                        RadMessageBox.Show(MessageTexts.successInsertOrderDetails);
                        InitOrderDetailsData(orderM.details.OrderID);
                        Clear();
                    }
                    else
                        RadMessageBox.Show(MessageTexts.somethingWrong);
                }
            }
            else
                RadMessageBox.Show(MessageTexts.selectMessageOrder);

        }

        private void orderDetailsradGridView_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            TotalPrice();
        }

        private void orderDetailsradGridView_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            TotalPrice();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (orderDetailsradGridView.RowCount > 0)
            {
                OrderDetails order;
                for (int i = 0; i < orderDetailsradGridView.RowCount; i++)
                {
                    order = new OrderDetails();
                    order.ProductID = int.Parse(orderDetailsradGridView.Rows[i].Cells["ProductID"].Value.ToString());
                    order.Product = new Products()
                    {
                        Name = orderDetailsradGridView.Rows[i].Cells["Product"].Value.ToString()
                    };
                    if (ddlProfile.SelectedIndex > -1)
                    {
                        order.ProfileID = int.Parse(orderDetailsradGridView.Rows[i].Cells["ProfileID"].Value.ToString());
                    }
                    order.Profile = new Profiles()
                    {
                        Name = orderDetailsradGridView.Rows[i].Cells["Profile"].Value.ToString()
                    };
                    order.BlindID = int.Parse(orderDetailsradGridView.Rows[i].Cells["BlindID"].Value.ToString());
                    order.Blind = new Blinds()
                    {
                        Name = orderDetailsradGridView.Rows[i].Cells["Blind"].Value.ToString()
                    };
                    order.WindowPaneID = int.Parse(orderDetailsradGridView.Rows[i].Cells["WindowPaneID"].Value.ToString());
                    order.WindowPane = new WindowPanes()
                    {
                        Name = orderDetailsradGridView.Rows[i].Cells["WindowPane"].Value.ToString()
                    };
                    order.Quantity = int.Parse(orderDetailsradGridView.Rows[i].Cells["Quantity"].Value.ToString());
                    order.Width = decimal.Parse(orderDetailsradGridView.Rows[i].Cells["Width"].Value.ToString());
                    order.Height = decimal.Parse(orderDetailsradGridView.Rows[i].Cells["Height"].Value.ToString());
                    order.Price = decimal.Parse(orderDetailsradGridView.Rows[i].Cells["Price"].Value.ToString());
                    order.Total = decimal.Parse(orderDetailsradGridView.Rows[i].Cells["Total"].Value.ToString());
                    CopyList.orderList.Add(order);
                }
                
            }
        }
    }
}
