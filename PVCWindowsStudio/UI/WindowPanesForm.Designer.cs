﻿namespace PVCWindowsStudio.UI
{
    partial class WindowPanesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowPanesForm));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.RadValidationRule radValidationRule1 = new Telerik.WinControls.UI.RadValidationRule();
            Telerik.WinControls.UI.RadValidationRule radValidationRule2 = new Telerik.WinControls.UI.RadValidationRule();
            this.txtName = new Telerik.WinControls.UI.RadTextBox();
            this.priceTxt = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.windowpaneGridView = new Telerik.WinControls.UI.RadGridView();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel5 = new Telerik.WinControls.UI.RadPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new Telerik.WinControls.UI.RadTextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.btnClear = new Telerik.WinControls.UI.RadButton();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.btnUpdate = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.radValidationProvider1 = new Telerik.WinControls.UI.RadValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowpaneGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowpaneGridView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).BeginInit();
            this.radPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            this.txtName.ThemeName = "MaterialBlueGrey";
            this.radValidationProvider1.SetValidationRule(this.txtName, radValidationRule1);
            // 
            // priceTxt
            // 
            resources.ApplyResources(this.priceTxt, "priceTxt");
            this.priceTxt.Name = "priceTxt";
            // 
            // 
            // 
            this.priceTxt.RootElement.CustomFontSize = 10.5F;
            this.priceTxt.TabStop = false;
            this.priceTxt.ThemeName = "MaterialBlueGrey";
            this.radValidationProvider1.SetValidationRule(this.priceTxt, radValidationRule2);
            // 
            // windowpaneGridView
            // 
            resources.ApplyResources(this.windowpaneGridView, "windowpaneGridView");
            this.windowpaneGridView.HideSelection = true;
            // 
            // 
            // 
            this.windowpaneGridView.MasterTemplate.AllowAddNewRow = false;
            this.windowpaneGridView.MasterTemplate.AllowDeleteRow = false;
            this.windowpaneGridView.MasterTemplate.AllowEditRow = false;
            this.windowpaneGridView.MasterTemplate.AllowSearchRow = true;
            this.windowpaneGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "WindowPaneID";
            resources.ApplyResources(gridViewTextBoxColumn1, "gridViewTextBoxColumn1");
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "WindowPaneID";
            gridViewTextBoxColumn1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Descending;
            gridViewTextBoxColumn1.Width = 46;
            gridViewTextBoxColumn2.FieldName = "Name";
            resources.ApplyResources(gridViewTextBoxColumn2, "gridViewTextBoxColumn2");
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn2.Width = 188;
            gridViewTextBoxColumn3.FieldName = "Other";
            resources.ApplyResources(gridViewTextBoxColumn3, "gridViewTextBoxColumn3");
            gridViewTextBoxColumn3.Name = "Other";
            gridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn3.Width = 328;
            gridViewTextBoxColumn4.FieldName = "Price";
            resources.ApplyResources(gridViewTextBoxColumn4, "gridViewTextBoxColumn4");
            gridViewTextBoxColumn4.Name = "Price";
            gridViewTextBoxColumn4.Width = 110;
            this.windowpaneGridView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.windowpaneGridView.MasterTemplate.EnablePaging = true;
            this.windowpaneGridView.MasterTemplate.PageSize = 15;
            sortDescriptor1.Direction = System.ComponentModel.ListSortDirection.Descending;
            sortDescriptor1.PropertyName = "WindowPaneID";
            this.windowpaneGridView.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.windowpaneGridView.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.windowpaneGridView.Name = "windowpaneGridView";
            this.windowpaneGridView.ThemeName = "MaterialBlueGrey";
            this.windowpaneGridView.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.windowpaneGridView_CellClick);
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.windowpaneGridView);
            resources.ApplyResources(this.radPanel2, "radPanel2");
            this.radPanel2.Name = "radPanel2";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radPanel5);
            this.radPanel1.Controls.Add(this.radPanel4);
            resources.ApplyResources(this.radPanel1, "radPanel1");
            this.radPanel1.Name = "radPanel1";
            // 
            // radPanel5
            // 
            this.radPanel5.Controls.Add(this.priceTxt);
            this.radPanel5.Controls.Add(this.label1);
            this.radPanel5.Controls.Add(this.label3);
            this.radPanel5.Controls.Add(this.lblID);
            this.radPanel5.Controls.Add(this.label2);
            this.radPanel5.Controls.Add(this.txtDescription);
            this.radPanel5.Controls.Add(this.lblUserName);
            this.radPanel5.Controls.Add(this.txtName);
            resources.ApplyResources(this.radPanel5, "radPanel5");
            this.radPanel5.Name = "radPanel5";
            this.radPanel5.ThemeName = "MaterialBlueGrey";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lblID
            // 
            resources.ApplyResources(this.lblID, "lblID");
            this.lblID.Name = "lblID";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            // 
            // 
            // 
            this.txtDescription.RootElement.StretchVertically = true;
            this.txtDescription.ThemeName = "MaterialBlueGrey";
            this.radValidationProvider1.SetValidationRule(this.txtDescription, null);
            // 
            // lblUserName
            // 
            resources.ApplyResources(this.lblUserName, "lblUserName");
            this.lblUserName.Name = "lblUserName";
            // 
            // radPanel4
            // 
            this.radPanel4.Controls.Add(this.btnClear);
            this.radPanel4.Controls.Add(this.btnDelete);
            this.radPanel4.Controls.Add(this.btnUpdate);
            this.radPanel4.Controls.Add(this.btnSave);
            resources.ApplyResources(this.radPanel4, "radPanel4");
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.ThemeName = "MaterialBlueGrey";
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::PVCWindowsStudio.Properties.Resources.plus__1_;
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnClear.Image = global::PVCWindowsStudio.Properties.Resources.eraser__1_;
            this.btnClear.Name = "btnClear";
            this.btnClear.ThemeName = "MaterialBlueGrey";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClear.GetChildAt(0))).Image = global::PVCWindowsStudio.Properties.Resources.eraser__1_;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClear.GetChildAt(0))).Text = resources.GetString("resource.Text");
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment")));
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::PVCWindowsStudio.Properties.Resources.plus__1_;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnDelete.Image = global::PVCWindowsStudio.Properties.Resources.trash;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ThemeName = "MaterialBlueGrey";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDelete.GetChildAt(0))).Image = global::PVCWindowsStudio.Properties.Resources.trash;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDelete.GetChildAt(0))).Text = resources.GetString("resource.Text1");
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnDelete.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDelete.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDelete.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDelete.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment1")));
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = global::PVCWindowsStudio.Properties.Resources.plus__1_;
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpdate.Image = global::PVCWindowsStudio.Properties.Resources.pencil;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ThemeName = "MaterialBlueGrey";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUpdate.GetChildAt(0))).Image = global::PVCWindowsStudio.Properties.Resources.pencil;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUpdate.GetChildAt(0))).Text = resources.GetString("resource.Text2");
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnUpdate.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdate.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdate.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdate.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment2")));
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackgroundImage = global::PVCWindowsStudio.Properties.Resources.plus__1_;
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnSave.Image = global::PVCWindowsStudio.Properties.Resources.plus__3_;
            this.btnSave.Name = "btnSave";
            this.btnSave.ThemeName = "MaterialBlueGrey";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Image = global::PVCWindowsStudio.Properties.Resources.plus__3_;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = resources.GetString("resource.Text3");
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment3")));
            // 
            // radValidationProvider1
            // 
            radValidationRule1.Controls.Add(this.txtName);
            radValidationRule1.Operator = Telerik.WinControls.Data.FilterOperator.IsNotLike;
            radValidationRule1.ToolTipText = "Name can\'t be empty!";
            radValidationRule1.Value = "";
            radValidationRule2.Controls.Add(this.priceTxt);
            radValidationRule2.Operator = Telerik.WinControls.Data.FilterOperator.IsNotEqualTo;
            radValidationRule2.ToolTipText = "Çmimi duhet të jetë më i lartë se zero!";
            radValidationRule2.ToolTipTitle = "Validimi dështoi";
            radValidationRule2.Value = "0.00";
            this.radValidationProvider1.ValidationRules.AddRange(new Telerik.WinControls.Data.FilterDescriptor[] {
            radValidationRule1,
            radValidationRule2});
            // 
            // WindowPanesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WindowPanesForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ThemeName = "MaterialBlueGrey";
            this.Load += new System.EventHandler(this.WindowPanesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowpaneGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.windowpaneGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).EndInit();
            this.radPanel5.ResumeLayout(false);
            this.radPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGridView windowpaneGridView;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel5;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadTextBox txtDescription;
        private System.Windows.Forms.Label lblUserName;
        private Telerik.WinControls.UI.RadTextBox txtName;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private Telerik.WinControls.UI.RadButton btnClear;
        private Telerik.WinControls.UI.RadButton btnDelete;
        private Telerik.WinControls.UI.RadButton btnUpdate;
        private Telerik.WinControls.UI.RadButton btnSave;
        private System.Windows.Forms.Label lblID;
        private Telerik.WinControls.UI.RadValidationProvider radValidationProvider1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private Telerik.WinControls.UI.RadMaskedEditBox priceTxt;
    }
}
