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
    public partial class BlindsForm : Telerik.WinControls.UI.RadForm
    {
        private Blinds blind;
        private readonly BlindBLL blindBll;
        public BlindsForm()
        {
            blind = new Blinds();
            blindBll = new BlindBLL();
            InitializeComponent();
        }

        private void BlindsForm_Load(object sender, EventArgs e)
        {
            InitiateData();
            RadMessageBox.SetThemeName("MaterialBlueGrey");
            RadGridLocalizationProvider.CurrentProvider = new MyGridViewLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new MyMessageBoxLocalizationProvider();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                blind.Name = txtName.Text;
                blind.Other = txtDescription.Text;
                blind.Price = Convert.ToDecimal(priceTxt.Value);
                blind.Color = txtColor.Text;
                blind.InsertBy = 1;
                if (blindBll.Insert(blind))
                {
                    RadMessageBox.Show(MessageTexts.successInsertBlind);
                    this.radValidationProvider1.ClearErrorStatus();
                    Clear();
                    InitiateData();
                }
                else
                    RadMessageBox.Show(MessageTexts.somethingWrong);
            }
            else
            {
                this.radValidationProvider1.Validate(txtName);
                this.radValidationProvider1.Validate(priceTxt);
            }

        }
        private void Clear()
        {
            this.radValidationProvider1.ClearErrorStatus();      
            txtName.Text = "";
            txtColor.Text = "";
            txtDescription.Text = "";
            lblID.Text = "";
            priceTxt.Text = "0.00";
        }
        private void InitiateData()
        {
            blindsGrindView.DataSource = blindBll.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {

                if (!String.IsNullOrEmpty(txtName.Text))
                {
                    blind.BlindID = int.Parse(lblID.Text);
                    blind.Name = txtName.Text;
                    blind.Other = txtDescription.Text;
                    blind.Price = Convert.ToDecimal(priceTxt.Value);
                    blind.Color = txtColor.Text;
                    blind.LUB = 1;
                    if (blindBll.Update(blind))
                    {
                        RadMessageBox.Show(MessageTexts.successUpdateBlind);
                        Clear();
                        InitiateData();
                        this.radValidationProvider1.ClearErrorStatus();
                    }
                    else RadMessageBox.Show(MessageTexts.somethingWrong);
                }
                else {                    
                    this.radValidationProvider1.Validate(txtName);
                    this.radValidationProvider1.Validate(priceTxt);
                }
            }
            else RadMessageBox.Show(MessageTexts.selectMessageBlind);
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (RadMessageBox.Show(MessageTexts.deleteMessage, "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (blindBll.Delete(int.Parse(lblID.Text)))
                    {
                        RadMessageBox.Show(MessageTexts.successDeleteBlind);
                        InitiateData();
                        Clear();
                    }
                    else RadMessageBox.Show(MessageTexts.somethingWrong);
                }
            }
            else RadMessageBox.Show(MessageTexts.selectMessageBlind);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void blindsGrindView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            this.radValidationProvider1.ClearErrorStatus();
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                blind = (Blinds)blindsGrindView.Rows[rowindex].DataBoundItem;
                if (blind != null)
                {
                    lblID.Text = blind.BlindID.ToString();
                    txtName.Text = blind.Name;
                    txtDescription.Text = blind.Other;
                    txtColor.Text = blind.Color;
                    priceTxt.Value = blind.Price;
                }
            }
        }
    }
}
