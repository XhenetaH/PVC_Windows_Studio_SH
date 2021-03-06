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
    public partial class MaterialsForm : Telerik.WinControls.UI.RadForm
    {
        private Materials material;
        private readonly MaterialBLL materialBll;
        public MaterialsForm()
        {
            material = new Materials();
            materialBll = new MaterialBLL();            
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (ValidationMethod())
            {
                material.Name = txtName.Text;
                material.Other = txtDescription.Text;
                material.InsertBy = 1;
                if (materialBll.Insert(material))
                {
                    Clear();
                    InitiateData();
                    this.radValidationProvider1.ClearErrorStatus();
                    RadMessageBox.Show(MessageTexts.successInsertMaterial);
                }
                else RadMessageBox.Show(MessageTexts.somethingWrong);
            }
            
        }
        private void Clear()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            lblID.Text = "";
        }

        private void InitiateData()
        {
            materialGridView.DataSource = materialBll.GetAll();
        }

     
        private void MaterialsForm_Load(object sender, EventArgs e)
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                
                if (ValidationMethod())
                {
                    material.MaterialID = int.Parse(lblID.Text);
                    material.Name = txtName.Text;
                    material.Other = txtDescription.Text;
                    material.LUB = 1;
                    if (materialBll.Update(material))
                    {
                        RadMessageBox.Show(MessageTexts.successUpdateMaterial);
                        Clear();
                        InitiateData();
                        this.radValidationProvider1.ClearErrorStatus();
                    }
                    else RadMessageBox.Show(MessageTexts.somethingWrong);
                }
                else this.radValidationProvider1.Validate(txtName);
            }
            else
                RadMessageBox.Show(MessageTexts.selectMessageMaterial);
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
                    if (materialBll.Delete(int.Parse(lblID.Text)))
                    {
                        RadMessageBox.Show(MessageTexts.successDeleteMaterial);
                        InitiateData();
                        Clear();
                    }
                    else RadMessageBox.Show(MessageTexts.somethingWrong);
                }

            }
            else
                RadMessageBox.Show(MessageTexts.selectMessageMaterial);

        }

        private void materialGridView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                material = (Materials)materialGridView.Rows[rowindex].DataBoundItem;
                if (material != null)
                {
                    lblID.Text = material.MaterialID.ToString();
                    txtName.Text = material.Name;
                    txtDescription.Text = material.Other;
                }
            }
        }
    }
}
