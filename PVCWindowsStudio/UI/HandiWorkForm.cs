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
    public partial class HandiWorkForm : Telerik.WinControls.UI.RadForm
    {
        private readonly HandiWorkBLL handiBll;
        private HandiWork handi;
        public HandiWorkForm()
        {
            handiBll = new HandiWorkBLL();
            handi = new HandiWork();
            InitializeComponent();
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
                            if (i.AccessibilityObject.Value.ToString() == "0" || !decimal.TryParse(i.AccessibilityObject.Value,out nr))
                                valid = false;
                        }
                    }
                }
            }
            return valid;
        }

        private void InitiateData()
        {
            handworkGridView1.DataSource = handiBll.GetAll();
        }

        private void HandiWorkForm_Load(object sender, EventArgs e)
        {
            InitiateData();
            RadMessageBox.SetThemeName("MaterialBlueGrey");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {

                if(ValidationMethod())
                {
                    handi.HandiWorkID = int.Parse(lblID.Text);
                    handi.MaxHeight = int.Parse(txtMaxHeight.Value.ToString());
                    handi.MinHeight = int.Parse(txtMinHeight.Value.ToString());
                    handi.MaxWidth = int.Parse(txtMaxWidth.Value.ToString());
                    handi.MinWidth = int.Parse(txtMinWidth.Value.ToString());
                    handi.Price = Convert.ToDecimal(txtPricee.Value.ToString());
                    handi.LUB =1;

                    if (handiBll.Update(handi))
                    {
                        RadMessageBox.Show("HandiWork updated successfully!");
                        InitiateData();
                        Clear();

                    }
                    else RadMessageBox.Show("Something went wrong!");

                }
            }
            else RadMessageBox.Show("Please select a HandiWork item!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (RadMessageBox.Show("Are you sure you want to delete this?", "", MessageBoxButtons.YesNo,RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (handiBll.Delete(int.Parse(lblID.Text)))
                    {
                        RadMessageBox.Show("HandiWork item is deleted successfully!");
                        InitiateData();
                        Clear();
                    }
                    else RadMessageBox.Show("Something went wrong!");
                }
            }
            else RadMessageBox.Show("Please select a HandiWork item!");
        }
        private void Clear()
        {
            txtPricee.Text = "";
            txtMaxHeight.Text = "";
            txtMinHeight.Text = "";
            txtMaxWidth.Text = "";
            txtMinWidth.Text = "";
            lblID.Text = "";
        }
        private void handworkGridView1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            this.radValidationProvider1.ClearErrorStatus();
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                handi = (HandiWork)handworkGridView1.Rows[rowindex].DataBoundItem;
                if (handi != null)
                {
                    lblID.Text = handi.HandiWorkID.ToString();
                    txtMaxWidth.Value = handi.MaxWidth.ToString();
                    txtMinWidth.Value = handi.MinWidth.ToString();
                    txtMaxHeight.Value = handi.MaxHeight.ToString();
                    txtMinHeight.Value = handi.MinHeight.ToString();
                    txtPricee.Value = handi.Price;
                }
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            
            if (ValidationMethod())
            {
                handi.MaxHeight = int.Parse(txtMaxHeight.Value.ToString());
                handi.MinHeight = int.Parse(txtMinHeight.Value.ToString());
                handi.MaxWidth = int.Parse(txtMaxWidth.Value.ToString());
                handi.MinWidth = int.Parse(txtMinWidth.Value.ToString());
                handi.Price = Convert.ToDecimal(txtPricee.Value.ToString());
                handi.InsertBy = 1;
                if (handiBll.Insert(handi))
                {
                    RadMessageBox.Show("HandiWork inserted successfully!");
                    InitiateData();
                    Clear();
                }
                else RadMessageBox.Show("Something went wrong!");

            }
        }
    }
}
