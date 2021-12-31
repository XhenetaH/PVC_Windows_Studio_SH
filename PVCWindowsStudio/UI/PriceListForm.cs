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
    public partial class PriceListForm : Telerik.WinControls.UI.RadForm
    {
        private readonly PriceListModel priceListModel = new PriceListModel();
        public PriceListForm()
        {
            InitializeComponent();
        }


        private void InitiateData()
        {
            pricelistGridView.DataSource = priceListModel.pricelistbll.GetAll();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ddlMaterial.SelectedIndex.Equals(-1))
            {
                if (!txtPrice.Text.Equals("0.00"))
                {
                    if (ddlProfile.SelectedIndex < 0)
                        ddlProfile.SelectedValue = 0;
                    else
                    {
                        if (ddlProfile.SelectedValue != null)
                            priceListModel.pricelist.ProfileID = (int)ddlProfile.SelectedValue;
                    }
                    priceListModel.pricelist.MaterialID = int.Parse(ddlMaterial.SelectedValue.ToString());
                    priceListModel.pricelist.Price = Convert.ToDecimal(txtPrice.Value.ToString());
                    priceListModel.pricelist.InsertBy = 1;
                    if (priceListModel.pricelistbll.Insert(priceListModel.pricelist))
                    {
                        RadMessageBox.Show(MessageTexts.successInsertPriceList);
                        InitiateData();
                        Clear();
                        this.radValidationProvider1.ClearErrorStatus();

                    }
                    else
                        RadMessageBox.Show(MessageTexts.somethingWrong);
                }
                else
                {
                    this.radValidationProvider1.Validate(txtPrice);
                }

            }
            else RadMessageBox.Show(MessageTexts.selectMessageMaterial);
        }

        private void Clear()
        {
            txtPrice.Text = "";
            ddlMaterial.SelectedIndex = -1;
            ddlMaterial.Text = "Zgjidhni një material";
            ddlProfile.SelectedIndex = -1;
            ddlProfile.Text = "Zgjidhni një profil";
        }

        private void PriceListForm_Load(object sender, EventArgs e)
        {
            ddlMaterial.DataSource = priceListModel.materialbll.GetAll();
            ddlMaterial.DisplayMember = "Name";
            ddlMaterial.ValueMember = "MaterialID";
            ddlMaterial.Text = "Zgjidhni një material";
            ddlMaterial.SelectedIndex = -1;

            ddlProfile.DataSource = priceListModel.profilebll.GetAll();
            ddlProfile.DisplayMember = "NameProf";
            ddlProfile.ValueMember = "ProfileID";
            ddlProfile.Text = "Zgjidhni një profil";
            ddlProfile.SelectedIndex = -1;

            InitiateData();

            RadMessageBox.SetThemeName("MaterialBlueGrey");
            RadGridLocalizationProvider.CurrentProvider = new MyGridViewLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new MyMessageBoxLocalizationProvider();

        }
  

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (!ddlMaterial.SelectedIndex.Equals(-1))
                {
                    if (!txtPrice.Text.Equals("0.00"))
                    {
                        priceListModel.pricelist.PriceListID = int.Parse(lblID.Text);
                        if (ddlProfile.SelectedIndex.Equals(-1))
                            priceListModel.pricelist.ProfileID = 0;
                        else
                            priceListModel.pricelist.ProfileID = int.Parse(ddlProfile.SelectedValue.ToString());
                        priceListModel.pricelist.MaterialID = int.Parse(ddlMaterial.SelectedValue.ToString());
                        priceListModel.pricelist.Price = Convert.ToDecimal(txtPrice.Value.ToString());
                        priceListModel.pricelist.LUB = 1;
                        if (priceListModel.pricelistbll.Update(priceListModel.pricelist))
                        {
                            RadMessageBox.Show(MessageTexts.successUpdatePriceList);
                            InitiateData();
                            Clear();
                            this.radValidationProvider1.ClearErrorStatus();
                        }
                        else
                            RadMessageBox.Show(MessageTexts.somethingWrong);
                    }
                    else
                    {
                        this.radValidationProvider1.Validate(txtPrice);
                    }
                }
                else RadMessageBox.Show(MessageTexts.MaterialCantBeEmpty);
            }
            else RadMessageBox.Show(MessageTexts.selectMessagePriceList);
        }

        private void pricelistGridView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                priceListModel.pricelist = (PriceList)pricelistGridView.Rows[rowindex].DataBoundItem;
                if (priceListModel.pricelist != null)
                {
                    lblID.Text = priceListModel.pricelist.PriceListID.ToString();
                    ddlMaterial.Text = priceListModel.pricelist.Materials.Name;
                    ddlMaterial.SelectedValue = priceListModel.pricelist.MaterialID;
                    ddlProfile.Text = priceListModel.pricelist.Profiles.NameProf;
                    ddlProfile.SelectedValue = priceListModel.pricelist.ProfileID;
                    txtPrice.Value = priceListModel.pricelist.Price;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (RadMessageBox.Show(MessageTexts.deleteMessage, "", MessageBoxButtons.YesNo,RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (priceListModel.pricelistbll.Delete(int.Parse(lblID.Text)))
                    {
                        RadMessageBox.Show(MessageTexts.successDeletePriceList);
                        InitiateData();
                        Clear();
                    }
                    else RadMessageBox.Show(MessageTexts.somethingWrong);
                }
            }
            else RadMessageBox.Show(MessageTexts.selectMessagePriceList);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
