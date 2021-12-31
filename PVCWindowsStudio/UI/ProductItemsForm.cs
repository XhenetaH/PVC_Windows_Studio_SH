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
using Telerik.WinControls.UI.Localization;

namespace PVCWindowsStudio.UI
{
    public partial class ProductItemsForm : Telerik.WinControls.UI.RadForm
    {
        private readonly ProductItemsModel productModel = new ProductItemsModel();
        public ProductItemsForm()
        {
            InitializeComponent();
        }

        private void InitiateProduct()
        {
            var productList = productModel.ProductBLL.GetAll();
            productsradGridView.DataSource = productList;
            this.productsradGridView.TableElement.RowHeight = 150;

            ddlMaterial.DataSource = productModel.MaterialBll.GetExist();
            ddlMaterial.DisplayMember = "Name";
            ddlMaterial.ValueMember = "MaterialID";

            ddlFormula.DataSource = productModel.FormulaBll.GetAll();
            ddlFormula.DisplayMember = "FormulaType";
            ddlFormula.ValueMember = "FormulaID";

        }
        private void ProductItemsForm_Load(object sender, EventArgs e)
        {
            InitiateProduct();
            RadMessageBox.SetThemeName("MaterialBlueGrey");
            RadGridLocalizationProvider.CurrentProvider = new MyGridViewLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new MyMessageBoxLocalizationProvider();
        }

        private Image ConvertToImage(byte[] array)
        {
            Image x = (Bitmap)new ImageConverter().ConvertFrom(array);
            return x;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (productPictureBox.Image == null)
                RadMessageBox.Show(MessageTexts.pictureBoxMessage);            
            else
            {
                productModel.ProductItems.ProductID = int.Parse(lblproductID.Text);
                productModel.ProductItems.MaterialID = int.Parse(ddlMaterial.SelectedValue.ToString());
                productModel.ProductItems.FormulaID = int.Parse(ddlFormula.SelectedValue.ToString());
                productModel.ProductItems.InsertBy = 1;

                if (productModel.ProductItemsBll.Insert(productModel.ProductItems))
                {
                    RadMessageBox.Show(MessageTexts.successInsertProductItem);
                    InitiateProductItems(int.Parse(lblproductID.Text));
                    
                }
                else RadMessageBox.Show(MessageTexts.somethingWrong);
            }
        }

        private void Clear()
        {
            lblProductItemID.Text = "";
            productPictureBox.Image = null;
            productitemsGridView.Rows.Clear();
        }

        private void InitiateProductItems(int id)
        {
            productitemsGridView.DataSource = productModel.ProductItemsBll.GetAll(id);
                
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblProductItemID.Text))
            {
                if (productPictureBox.Image == null)
                    MessageBox.Show(MessageTexts.pictureBoxMessage);
                else
                {
                    productModel.ProductItems.ProductItemsID = int.Parse(lblProductItemID.Text);
                    productModel.ProductItems.MaterialID = int.Parse(ddlMaterial.SelectedValue.ToString());
                    productModel.ProductItems.ProductID = int.Parse(lblproductID.Text);
                    productModel.ProductItems.FormulaID = int.Parse(ddlFormula.SelectedValue.ToString());
                    productModel.ProductItems.LUB = 1;

                    if (productModel.ProductItemsBll.Update(productModel.ProductItems))
                    {
                        RadMessageBox.Show(MessageTexts.successUpdateProductItem);
                        InitiateProductItems(int.Parse(lblproductID.Text));
                        lblProductItemID.Text = "";

                    }
                    else
                        RadMessageBox.Show(MessageTexts.somethingWrong);

                }
            }
            else RadMessageBox.Show(MessageTexts.selectMessageProductItem);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblProductItemID.Text))
            {
                if (RadMessageBox.Show(MessageTexts.deleteMessage, "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (productModel.ProductItemsBll.Delete(int.Parse(lblProductItemID.Text)))
                    {
                        RadMessageBox.Show(MessageTexts.successDeleteProductItem);
                        InitiateProductItems(int.Parse(lblproductID.Text));
                        lblProductItemID.Text = "";
                    }
                    else
                        RadMessageBox.Show(MessageTexts.somethingWrong);
                }

            }
            else RadMessageBox.Show(MessageTexts.selectMessageProductItem);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void productsradGridView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                productModel.Product = (Products)productsradGridView.Rows[rowindex].DataBoundItem;
                if (productModel.Product != null)
                {
                    lblproductID.Text = productModel.Product.ProductID.ToString();
                    if (productModel.Product.Picture?.Length > 0)
                        productPictureBox.Image = ConvertToImage(productModel.Product.Picture);
                    else
                        productPictureBox.Image = null;
                    InitiateProductItems(int.Parse(lblproductID.Text));                   

                }
            }
        }

        private void productitemsGridView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                productModel.ProductItems = (ProductItems)productitemsGridView.Rows[rowindex].DataBoundItem;
                if (productModel.ProductItems != null)
                {
                    lblProductItemID.Text = productModel.ProductItems.ProductItemsID.ToString();
                    lblproductID.Text = productModel.ProductItems.Products.ProductID.ToString();
                    ddlFormula.SelectedValue = productModel.ProductItems.Formula.FormulaID;
                    ddlFormula.Text = productModel.ProductItems.Formula.FormulaType;
                    ddlMaterial.SelectedValue = productModel.ProductItems.Materials.MaterialID;
                    ddlMaterial.Text = productModel.ProductItems.Materials.Name;
                    if (productModel.ProductItems.Products.Picture?.Length > 0)
                        productPictureBox.Image = ConvertToImage(productModel.ProductItems.Products.Picture);
                    else
                        productPictureBox.Image = null;

                }
            }
        }

        private void btnAddFormula_Click(object sender, EventArgs e)
        {
            FormulaForm frm = new FormulaForm();
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            frm.Show();
        }
    }
}
