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
    public partial class PriceListForm : Telerik.WinControls.UI.RadForm
    {
        private readonly ProfileBLL profilebll;
        private readonly MaterialBLL materialbll;
        private PriceList pricelist;
        private readonly PriceListBLL pricelistbll;
        public PriceListForm()
        {
            profilebll = new ProfileBLL();
            materialbll = new MaterialBLL();
            pricelist = new PriceList();
            pricelistbll = new PriceListBLL();
            InitializeComponent();
        }


        private void InitiateData()
        {
            pricelistGridView.DataSource = pricelistbll.GetAll();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ddlMaterial.SelectedIndex.Equals(-1))
            {
                if (ValidationMethod())
                {
                    if (ddlProfile.SelectedIndex < 0)
                        ddlProfile.SelectedValue = 0;
                    else
                    {
                        if (ddlProfile.SelectedValue != null)
                            pricelist.ProfileID = (int)ddlProfile.SelectedValue;
                    }
                    pricelist.MaterialID = int.Parse(ddlMaterial.SelectedValue.ToString());
                    pricelist.Price = Convert.ToDecimal(txtPrice.Value.ToString());
                    pricelist.InsertBy = 1;
                    if (pricelistbll.Insert(pricelist))
                    {
                        RadMessageBox.Show("Item inserted successfully!");
                        InitiateData();
                        Clear();
                        this.radValidationProvider1.ClearErrorStatus();

                    }
                    else
                        RadMessageBox.Show("Something went wrong!");
                }

            }
            else RadMessageBox.Show("Please select a Material!");
        }

        private void Clear()
        {
            txtPrice.Text = "";
            ddlMaterial.SelectedIndex = -1;
            ddlMaterial.Text = "Choose a Material";
            ddlProfile.SelectedIndex = -1;
            ddlProfile.Text = "Choose a Profile";
        }

        private void PriceListForm_Load(object sender, EventArgs e)
        {
            ddlMaterial.DataSource = materialbll.GetAll();
            ddlMaterial.DisplayMember = "Name";
            ddlMaterial.ValueMember = "MaterialID";
            ddlMaterial.Text = "Choose a Material";
            ddlMaterial.SelectedIndex = -1;

            ddlProfile.DataSource = profilebll.GetAll();
            ddlProfile.DisplayMember = "NameProf";
            ddlProfile.ValueMember = "ProfileID";
            ddlProfile.Text = "Choose a Profile";
            ddlProfile.SelectedIndex = -1;

            InitiateData();

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (!ddlMaterial.SelectedIndex.Equals(-1))
                {
                    if (ValidationMethod())
                    {
                        pricelist.PriceListID = int.Parse(lblID.Text);
                        if (ddlProfile.SelectedIndex.Equals(-1))
                            pricelist.ProfileID = 0;
                        else
                            pricelist.ProfileID = int.Parse(ddlProfile.SelectedValue.ToString());
                        pricelist.MaterialID = int.Parse(ddlMaterial.SelectedValue.ToString());
                        pricelist.Price = Convert.ToDecimal(txtPrice.Value.ToString());
                        pricelist.LUB = 1;
                        if (pricelistbll.Update(pricelist))
                        {
                            RadMessageBox.Show("Item updated successfully!");
                            InitiateData();
                            Clear();
                            this.radValidationProvider1.ClearErrorStatus();
                        }
                        else
                            RadMessageBox.Show("Something went wrong!");
                    }
                }
                else RadMessageBox.Show("Material can't be empty!");
            }
            else RadMessageBox.Show("Please select an item!");
        }

        private void pricelistGridView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                pricelist = (PriceList)pricelistGridView.Rows[rowindex].DataBoundItem;
                if (pricelist != null)
                {
                    lblID.Text = pricelist.PriceListID.ToString();
                    ddlMaterial.Text = pricelist.Materials.Name;
                    ddlMaterial.SelectedValue = pricelist.MaterialID;
                    ddlProfile.Text = pricelist.Profiles.NameProf;
                    ddlProfile.SelectedValue = pricelist.ProfileID;
                    txtPrice.Value = pricelist.Price;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (RadMessageBox.Show("Are you sure you want to delete this?", "", MessageBoxButtons.YesNo,RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (pricelistbll.Delete(int.Parse(lblID.Text)))
                    {
                        RadMessageBox.Show("Price List item is deleted successfully!");
                        InitiateData();
                        Clear();
                    }
                    else RadMessageBox.Show("Something went wrong!");
                }
            }
            else RadMessageBox.Show("Please select a Price List item!");
        }
       
    }
}
