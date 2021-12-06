using PVCWindowsStudio.BLL;
using PVCWindowsStudio.BO;
using PVCWindowsStudio.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PVCWindowsStudio.UI
{
    public partial class ProfilesForm : Telerik.WinControls.UI.RadForm
    {
        private Profiles profile;
        private readonly ProfileBLL profileBll;
        public ProfilesForm()
        {
            profile = new Profiles();
            profileBll = new ProfileBLL();
            InitializeComponent();
        }

        private void ProfilesForm_Load(object sender, EventArgs e)
        {
            InitiateData();
            RadMessageBox.SetThemeName("MaterialBlueGrey");

        }

        private void InitiateData()
        {
            profileGridView.DataSource = profileBll.GetAll();
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
                            if (string.IsNullOrEmpty(i.AccessibilityObject.Value.ToString()))
                                valid = false;
                        }
                    }
                }
            }
            return valid;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            if (ValidationMethod())
            {
                profile.Name = txtName.Text;
                profile.Other = txtDescription.Text;
                profile.Color = txtColor.Text;
                profile.InsertBy = 1;
                if (profileBll.Insert(profile))
                {
                    RadMessageBox.Show("Profile inserted successfully!");
                    Clear();
                    InitiateData();
                    this.radValidationProvider1.ClearErrorStatus();
                }
                else RadMessageBox.Show("Something went wrong!");
            }           
           
        }
        private void Clear()
        {
            this.radValidationProvider1.ClearErrorStatus();
            txtName.Text = "";
            txtDescription.Text = "";
            txtColor.Text = "";
            lblID.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (ValidationMethod())
                {
                    profile.Name = txtName.Text;
                    profile.Other = txtDescription.Text;
                    profile.Color = txtColor.Text;
                    profile.LUB = 1;
                    if (profileBll.Update(profile))
                    {
                        RadMessageBox.Show("Profile updated successfully!");
                        Clear();
                        InitiateData();
                        this.radValidationProvider1.ClearErrorStatus();
                    }
                    else RadMessageBox.Show("Something went wrong!");
                }
                
            }
            else RadMessageBox.Show("Please select a profile!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (RadMessageBox.Show("Are you sure you want to delete this?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (profileBll.Delete(int.Parse(lblID.Text)))
                    {
                        RadMessageBox.Show("Profile deleted successfully!");
                        InitiateData();
                        Clear();
                    }
                    else RadMessageBox.Show("Something went wrong!");
                }
            }
            else RadMessageBox.Show("Please select a Profile!");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void profileGridView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            this.radValidationProvider1.ClearErrorStatus();
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                profile = (Profiles)profileGridView.Rows[rowindex].DataBoundItem;
                if (profile != null)
                {
                    lblID.Text = profile.ProfileID.ToString();
                    txtName.Text = profile.Name;
                    txtDescription.Text = profile.Other;
                    txtColor.Text = profile.Color;
                }
            }
        }
    }
}
