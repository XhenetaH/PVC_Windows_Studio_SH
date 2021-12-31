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
    public partial class ProductsForm : Telerik.WinControls.UI.RadForm
    {
        private Products product;
        private readonly ProductBLL productBll;
        private readonly ProfileBLL profileBLL;
        public ProductsForm()
        {
            product = new Products();
            productBll = new ProductBLL();
            profileBLL = new ProfileBLL();
            InitializeComponent();
        }

        private void InitiateData()
        {
            productGridView.DataSource = productBll.GetAll();
            this.productGridView.TableElement.RowHeight = 130;

            ddlColor.DataSource = profileBLL.GetColor();
            ddlColor.DisplayMember = "Color";            
            ddlColor.Text = "Zgjidhni një ngjyrë";            
        }
        private void ProductsForm_Load(object sender, EventArgs e)
        {
            InitiateData();
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
                        for(int i=0; i<mode.Count;i++)
                        {
                            if(mode[i].Text == "Zgjidhni një ngjyrë" || mode[i].Text == "")
                            {
                                valid = false;
                            }
                        }
                    }
                }
            }
            return valid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (productPictureBox.Image == null)
                RadMessageBox.Show(MessageTexts.pictureBoxMessage);
            else {
                if (ValidationMethod())
                {
                    product.Name = txtName.Text;
                    product.Other = txtDescription.Text;
                    product.Picture = ConvertFormImage(productPictureBox.Image);
                    product.Color = ddlColor.SelectedValue.ToString();
                    product.InsertBy = 1;

                    if (productBll.Insert(product))
                    {
                        RadMessageBox.Show(MessageTexts.successInsertProduct);
                        InitiateData();
                        Clear();
                        this.radValidationProvider1.ClearErrorStatus();
                    }
                    else RadMessageBox.Show(MessageTexts.somethingWrong);
                }
            }
        }

        private byte[] ConvertFormImage(Image img)
        {
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
            return arr;
        }
        private void Clear()
        {
            this.radValidationProvider1.ClearErrorStatus();
            lblID.Text = "";
            txtName.Text = "";
            txtDescription.Text = "";
            ddlColor.Text = "Zgjidhni një ngjyrë";
            productPictureBox.Image = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string filename;
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg|PNG|*.png", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;
                    productPictureBox.Image = Image.FromFile(filename);
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
                if (productPictureBox.Image == null)
                    RadMessageBox.Show(MessageTexts.pictureBoxMessage);
                else
                {
                    if (ValidationMethod())
                    {
                        product.Name = txtName.Text;
                        product.Other = txtDescription.Text;
                        product.Picture = ConvertFormImage(productPictureBox.Image);
                        product.Color = ddlColor.SelectedValue.ToString();
                        product.LUB = 1;

                        if (productBll.Update(product))
                        {
                            RadMessageBox.Show(MessageTexts.successUpdateProduct);
                            InitiateData();
                            Clear();
                            this.radValidationProvider1.ClearErrorStatus();
                        }
                        else RadMessageBox.Show(MessageTexts.somethingWrong);
                    }
                }
            }
            else RadMessageBox.Show(MessageTexts.selectMessageProduct);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (RadMessageBox.Show(MessageTexts.deleteMessage, "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (productBll.Delete(int.Parse(lblID.Text)))
                    {
                        RadMessageBox.Show(MessageTexts.successDeleteProduct);
                        InitiateData();
                        Clear();
                    }
                    else RadMessageBox.Show(MessageTexts.somethingWrong);
                }
            }
            else RadMessageBox.Show(MessageTexts.selectMessageProduct);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            productPictureBox.Image = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void productGridView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                product = (Products)productGridView.Rows[rowindex].DataBoundItem;

                if (product != null)
                {
                    lblID.Text = product.ProductID.ToString();
                    txtName.Text = product.Name;
                    txtDescription.Text = product.Other;
                    ddlColor.SelectedValue = product.Color;
                    if (product.Picture?.Length > 0)
                        productPictureBox.Image = ConvertToImage(product.Picture);
                    else
                        productPictureBox.Image = null;

                }
            }
        }
    }
}
