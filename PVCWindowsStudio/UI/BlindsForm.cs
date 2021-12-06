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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            if (!String.IsNullOrEmpty(txtName.Text))
            {
                blind.Name = txtName.Text;
                blind.Other = txtDescription.Text;
                blind.Price = Convert.ToDecimal(txtPrice.Text);
                blind.Color = txtColor.Text;
                blind.InsertBy = 1;
                if (blindBll.Insert(blind))
                {
                    MessageBox.Show("Blind inserted successfully!");
                    this.radValidationProvider1.ClearErrorStatus();
                    Clear();
                    InitiateData();
                }
                else
                    MessageBox.Show("Something went wrong!");
            }
            else this.radValidationProvider1.Validate(txtName);

        }
        private void Clear()
        {
            this.radValidationProvider1.ClearErrorStatus();
            txtPrice.Text = "";
            txtName.Text = "";
            txtColor.Text = "";
            txtDescription.Text = "";
            lblID.Text = "";
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
                    blind.Price = Convert.ToDecimal(txtPrice.Text);
                    blind.Color = txtColor.Text;
                    blind.LUB = 1;
                    if (blindBll.Update(blind))
                    {
                        MessageBox.Show("Blind is updated successfully!");
                        Clear();
                        InitiateData();
                        this.radValidationProvider1.ClearErrorStatus();
                    }
                    else MessageBox.Show("Something went wrong!");
                }
                else this.radValidationProvider1.Validate(txtName);                
            }
            else MessageBox.Show("Please select a blind!");
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (MessageBox.Show("Are you sure you want to delete this?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (blindBll.Delete(int.Parse(lblID.Text)))
                    {
                        MessageBox.Show("Blind is deleted successfully!");
                        InitiateData();
                        Clear();
                    }
                    else MessageBox.Show("Something went wrong!");
                }
            }
            else MessageBox.Show("Please select a blind!");
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
                    txtPrice.Text = blind.Price.ToString();
                }
            }
        }
    }
}
