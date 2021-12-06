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

namespace PVCWindowsStudio.UI
{
    public partial class WindowPanesForm : Telerik.WinControls.UI.RadForm
    {
        private WindowPanes windowpane;
        private readonly WindowPaneBLL windowpaneBll;

        public WindowPanesForm()
        {
            windowpane = new WindowPanes();
            windowpaneBll = new WindowPaneBLL();
            InitializeComponent();
        }

        private void WindowPanesForm_Load(object sender, EventArgs e)
        {
            InitiateData();
            RadMessageBox.SetThemeName("MaterialBlueGrey");
        }

        private void InitiateData()
        {
            windowpaneGridView.DataSource = windowpaneBll.GetAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text) && !String.IsNullOrEmpty(txtPrice.Text))
            {
                windowpane.Name = txtName.Text;
                windowpane.Price = Convert.ToDecimal(txtPrice.Text);
                windowpane.Other = txtDescription.Text;
                windowpane.InsertBy = 1;
                if (windowpaneBll.Insert(windowpane))
                {
                    RadMessageBox.Show("Window Pane inserted successfully!");
                    Clear();
                    InitiateData();
                    this.radValidationProvider1.ClearErrorStatus();
                }
                else RadMessageBox.Show("Something went worng!");
            }
            else
            {
                this.radValidationProvider1.Validate(txtName);
                this.radValidationProvider1.Validate(txtPrice);
            }
            
        }
        private void Clear()
        {
            this.radValidationProvider1.ClearErrorStatus();
            txtName.Text = "";
            txtDescription.Text = "";
            lblID.Text = "";
            txtPrice.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                windowpane.Name = txtName.Text;
                windowpane.Price = Convert.ToDecimal(txtPrice.Text);
                windowpane.Other = txtDescription.Text;
                windowpane.LUB = 1;
                if (!String.IsNullOrEmpty(txtName.Text))
                {                    
                    if (windowpaneBll.Update(windowpane))
                    {
                        RadMessageBox.Show("Window Pane updated successfully!");
                        Clear();
                        InitiateData();
                        this.radValidationProvider1.ClearErrorStatus();
                    }
                    else RadMessageBox.Show("Something went wrong!");
                }
                else this.radValidationProvider1.Validate(txtName);

            }
            else RadMessageBox.Show("Please select a Window Pane!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (RadMessageBox.Show("Are you sure you want to delete this?", "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (windowpaneBll.Delete(int.Parse(lblID.Text)))
                    {
                        RadMessageBox.Show("Window Pane deleted successfully!");
                        InitiateData();
                        Clear();
                    }
                    else RadMessageBox.Show("Something went wrong!");
                }                
            }
            else RadMessageBox.Show("Please select a window pane!");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void windowpaneGridView_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            this.radValidationProvider1.ClearErrorStatus();
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                windowpane = (WindowPanes)windowpaneGridView.Rows[rowindex].DataBoundItem;
                if (windowpane != null)
                {
                    lblID.Text = windowpane.WindowPaneID.ToString();
                    txtName.Text = windowpane.Name;
                    txtPrice.Text = windowpane.Price.ToString();
                    txtDescription.Text = windowpane.Other;
                }
            }
        }
    }
}
