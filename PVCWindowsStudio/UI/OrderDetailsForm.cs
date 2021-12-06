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
    public partial class OrderDetailsForm : Telerik.WinControls.UI.RadForm
    {
        private readonly OrderBLL ordersBLL;
        private Orders order;
        private readonly BlindBLL blindBll;
        private readonly OrderDetailsBLL detailsBLL;
        private OrderDetails details;
        private readonly ProductBLL productBll;
        private readonly ProfileBLL profileBll;
        private readonly WindowPaneBLL windowpaneBll;
        public OrderDetailsForm()
        {
            productBll = new ProductBLL();
            profileBll = new ProfileBLL();
            windowpaneBll = new WindowPaneBLL();
            blindBll = new BlindBLL();
            detailsBLL = new OrderDetailsBLL();
            ordersBLL = new OrderBLL();
            order = new Orders();
            details = new OrderDetails();
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            InitOrderData();

            // productMultiColumnComboBox1.DataSource = productBll.GetExistProd("Bardhe");
            productMultiColumnComboBox1.AutoCompleteMode = AutoCompleteMode.Append;
            productMultiColumnComboBox1.EditorControl.TableElement.RowHeight = 110;
            productMultiColumnComboBox1.ValueMember = "ProductID";

            ddlBlinds.DataSource = blindBll.GetAll();
            ddlBlinds.DisplayMember = "Name";
            ddlBlinds.ValueMember = "BlindID";

            ddlProfile.DataSource = profileBll.GetExistProfile();
            ddlProfile.DisplayMember = "NameProf";
            ddlProfile.ValueMember = "ProfileID";

            ddlWindowPane.DataSource = windowpaneBll.GetAll();
            ddlWindowPane.DisplayMember = "Name";
            ddlWindowPane.ValueMember = "WindowPaneID";

            RadMessageBox.SetThemeName("MaterialBlueGrey");
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
                        foreach (var i in mode)
                        {
                            if (i.AccessibilityObject.Value.ToString() == "0" )
                                valid = false;
                        }
                    }
                }
            }
            return valid;
        }


        private void InitOrderData()
        {
            orderMultiComboBox.DataSource = ordersBLL.GetAll();
            //orderMultiComboBox.SelectedIndex = -1;
            orderMultiComboBox.AutoCompleteMode = AutoCompleteMode.Append;
            orderMultiComboBox.ValueMember = "OrderID";
            orderMultiComboBox.Text = "Choose a order";
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
                int id = int.Parse(productMultiColumnComboBox1.EditorControl.Rows[rowindex].Cells["ProductID"].Value.ToString());
                lblProductID.Text = id.ToString();
            }
        }

        private void lblOrderID_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblOrderID.Text))
                InitOrderDetailsData(int.Parse(lblOrderID.Text));
        }

        private void InitOrderDetailsData(int id)
        {
            orderDetailsradGridView.DataSource = detailsBLL.GetAll(id);
        }
        private void orderDetailsradGridView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                details = (OrderDetails)orderDetailsradGridView.Rows[rowindex].DataBoundItem;
                if (details != null)
                {
                    lblID.Text = details.OrderDetailsID.ToString();
                    txtWidth.Text = details.Width.ToString();
                    txtHeight.Text = details.Height.ToString();
                    txtQuantity.Text = details.Quantity.ToString();
                    ddlBlinds.Text = details.Blind.Name;
                    ddlBlinds.SelectedValue = details.BlindID;
                    ddlProfile.Text = details.Profile.NameProf;
                    ddlProfile.SelectedValue = details.ProfileID;
                    ddlWindowPane.Text = details.WindowPane.Name;
                    ddlWindowPane.SelectedValue = details.WindowPaneID;
                    productMultiColumnComboBox1.Text = details.Product.Name;
                    lblProductID.Text = details.ProductID.ToString();
                    if (details.Product.Picture?.Length > 0)
                        radPictureBox1.Image = ConvertToImage(details.Product.Picture);
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
                        var price = details.Total;
                        details.OrderDetailsID = int.Parse(lblID.Text);
                        details.Width = int.Parse(txtWidth.Text);
                        details.Height = int.Parse(txtHeight.Text);
                        details.Quantity = int.Parse(txtQuantity.Text);
                        details.BlindID = int.Parse(ddlBlinds.SelectedValue.ToString());
                        details.ProfileID = int.Parse(ddlProfile.SelectedValue.ToString());
                        details.ProductID = int.Parse(lblProductID.Text);
                        details.WindowPaneID = int.Parse(ddlWindowPane.SelectedValue.ToString());
                        details.Price = Session.Methods.CalcPrice(details.ProductID, txtWidth.Value.ToString(), txtHeight.Value.ToString(), details.ProfileID, details.BlindID, blindBll.GetPrice(details.BlindID), windowpaneBll.GetPrice(details.WindowPaneID), details.WindowPaneID, detailsBLL.GetPrice(details.ProfileID, details.ProductID));
                        details.Total = details.Price * details.Quantity;
                        details.LUB = 1;

                        order.OrderID = int.Parse(lblOrderID.Text);
                        if (price < details.Total)
                            order.TotalPrice = total + (details.Total - price);
                        else
                            order.TotalPrice = total - (price-details.Total);
                       
                        order.LUB = 1;
                        if (detailsBLL.Update(details) && ordersBLL.UpdatePrice(order))
                        {
                            RadMessageBox.Show("Order details updated successfully!");
                            InitOrderDetailsData(details.OrderID);
                            Clear();
                            
                        }
                        else
                            RadMessageBox.Show("Something went wrong!");
                    }
                }
                else
                    RadMessageBox.Show("Product canot be empty");
            }
            else
                RadMessageBox.Show("Please select an item from your order!");
        }

        decimal total = 0;
        private decimal TotalPrice()
        {
            decimal total = 0;
            for(int i=0; i<orderDetailsradGridView.RowCount; i++)
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
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (RadMessageBox.Show("Are you sure you want to delete this?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    detailsBLL.Delete(int.Parse(lblID.Text));
                    InitOrderDetailsData(details.OrderID);
                    if (orderDetailsradGridView.RowCount == 0)
                    {
                        if (ordersBLL.Delete(details.OrderID))
                        {
                            RadMessageBox.Show("Order item deleted successfully!");
                            InitOrderData();
                        }
                        else RadMessageBox.Show("Something went wrong!");
                    }
                    Clear();
                }
            }
            else RadMessageBox.Show("Please select an order item!");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblOrderID.Text))
            {
                if (ValidationMethod())
                {
                    details.OrderID = int.Parse(lblOrderID.Text);
                    details.Width = int.Parse(txtWidth.Text);
                    details.Height = int.Parse(txtHeight.Text);
                    details.Quantity = int.Parse(txtQuantity.Text);
                    details.BlindID = int.Parse(ddlBlinds.SelectedValue.ToString());
                    details.ProfileID = int.Parse(ddlProfile.SelectedValue.ToString());
                    details.ProductID = int.Parse(productMultiColumnComboBox1.SelectedValue.ToString());
                    details.WindowPaneID = int.Parse(ddlWindowPane.SelectedValue.ToString());
                    details.Price = Session.Methods.CalcPrice(details.ProductID, txtWidth.Text, txtHeight.Text, details.ProfileID, details.BlindID, blindBll.GetPrice(details.BlindID), windowpaneBll.GetPrice(details.WindowPaneID), details.WindowPaneID, detailsBLL.GetPrice(details.ProfileID, details.ProductID));
                    details.Total = details.Price * details.Quantity;
                    details.InsertBy = 1;

                    order.OrderID = int.Parse(lblOrderID.Text);
                    order.TotalPrice = TotalPrice() + details.Total;
                    order.LUB = 1;
                    if (detailsBLL.Insert(details) && ordersBLL.UpdatePrice(order))
                    {
                        RadMessageBox.Show("Order item inserted successfully!");
                        InitOrderDetailsData(details.OrderID);
                        Clear();
                    }
                    else
                        RadMessageBox.Show("Something went wrong!");
                }
            }
            else
                RadMessageBox.Show("Please select an order!");

        }

        private void orderDetailsradGridView_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            TotalPrice();
        }

        private void orderDetailsradGridView_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            TotalPrice();
        }
    }
}
