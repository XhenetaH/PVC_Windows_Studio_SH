﻿namespace PVCWindowsStudio.UI
{
    partial class ClientsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientsForm));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.RadValidationRule radValidationRule1 = new Telerik.WinControls.UI.RadValidationRule();
            Telerik.WinControls.UI.RadValidationRule radValidationRule2 = new Telerik.WinControls.UI.RadValidationRule();
            this.txtName = new Telerik.WinControls.UI.RadTextBox();
            this.txtLastName = new Telerik.WinControls.UI.RadTextBox();
            this.radPanel6 = new Telerik.WinControls.UI.RadPanel();
            this.clientGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.btnUpdate = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.radPanel5 = new Telerik.WinControls.UI.RadPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new Telerik.WinControls.UI.RadTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new Telerik.WinControls.UI.RadTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPhoneNr = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnClear = new Telerik.WinControls.UI.RadButton();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            this.radValidationProvider1 = new Telerik.WinControls.UI.RadValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel6)).BeginInit();
            this.radPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).BeginInit();
            this.radPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
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
            // txtLastName
            // 
            resources.ApplyResources(this.txtLastName, "txtLastName");
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ThemeName = "MaterialBlueGrey";
            this.radValidationProvider1.SetValidationRule(this.txtLastName, radValidationRule2);
            // 
            // radPanel6
            // 
            this.radPanel6.Controls.Add(this.clientGridView1);
            resources.ApplyResources(this.radPanel6, "radPanel6");
            this.radPanel6.Name = "radPanel6";
            // 
            // clientGridView1
            // 
            this.clientGridView1.BackColor = System.Drawing.Color.White;
            this.clientGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.clientGridView1, "clientGridView1");
            this.clientGridView1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.clientGridView1.HideSelection = true;
            // 
            // 
            // 
            this.clientGridView1.MasterTemplate.AllowAddNewRow = false;
            this.clientGridView1.MasterTemplate.AllowDeleteRow = false;
            this.clientGridView1.MasterTemplate.AllowEditRow = false;
            this.clientGridView1.MasterTemplate.AllowSearchRow = true;
            this.clientGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Name";
            resources.ApplyResources(gridViewTextBoxColumn1, "gridViewTextBoxColumn1");
            gridViewTextBoxColumn1.MinWidth = 6;
            gridViewTextBoxColumn1.Name = "Name";
            gridViewTextBoxColumn1.Width = 172;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "LastName";
            resources.ApplyResources(gridViewTextBoxColumn2, "gridViewTextBoxColumn2");
            gridViewTextBoxColumn2.MinWidth = 6;
            gridViewTextBoxColumn2.Name = "LastName";
            gridViewTextBoxColumn2.Width = 173;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "PhoneNumber";
            resources.ApplyResources(gridViewTextBoxColumn3, "gridViewTextBoxColumn3");
            gridViewTextBoxColumn3.MinWidth = 6;
            gridViewTextBoxColumn3.Name = "PhoneNumber";
            gridViewTextBoxColumn3.Width = 132;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Email";
            resources.ApplyResources(gridViewTextBoxColumn4, "gridViewTextBoxColumn4");
            gridViewTextBoxColumn4.MinWidth = 6;
            gridViewTextBoxColumn4.Name = "Email";
            gridViewTextBoxColumn4.Width = 182;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Address";
            resources.ApplyResources(gridViewTextBoxColumn5, "gridViewTextBoxColumn5");
            gridViewTextBoxColumn5.MinWidth = 6;
            gridViewTextBoxColumn5.Name = "Address";
            gridViewTextBoxColumn5.Width = 224;
            gridViewTextBoxColumn6.FieldName = "ClientID";
            resources.ApplyResources(gridViewTextBoxColumn6, "gridViewTextBoxColumn6");
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "ClientID";
            gridViewTextBoxColumn6.SortOrder = Telerik.WinControls.UI.RadSortOrder.Descending;
            gridViewTextBoxColumn6.Width = 47;
            this.clientGridView1.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.clientGridView1.MasterTemplate.EnablePaging = true;
            sortDescriptor1.Direction = System.ComponentModel.ListSortDirection.Descending;
            sortDescriptor1.PropertyName = "ClientID";
            this.clientGridView1.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.clientGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.clientGridView1.Name = "clientGridView1";
            this.clientGridView1.ThemeName = "MaterialBlueGrey";
            this.clientGridView1.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.clientGridView1_CellClick);
            // 
            // radPanel2
            // 
            resources.ApplyResources(this.radPanel2, "radPanel2");
            this.radPanel2.Name = "radPanel2";
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.BackgroundImage = global::PVCWindowsStudio.Properties.Resources.plus__1_;
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnUpdate.Image = global::PVCWindowsStudio.Properties.Resources.pencil;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ThemeName = "MaterialBlueGrey";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUpdate.GetChildAt(0))).Image = global::PVCWindowsStudio.Properties.Resources.pencil;
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUpdate.GetChildAt(0))).Text = resources.GetString("resource.Text");
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnUpdate.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdate.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdate.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdate.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment")));
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
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnSave.GetChildAt(0))).Text = resources.GetString("resource.Text1");
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnSave.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment1")));
            // 
            // radPanel5
            // 
            this.radPanel5.Controls.Add(this.label6);
            this.radPanel5.Controls.Add(this.label5);
            this.radPanel5.Controls.Add(this.txtAddress);
            this.radPanel5.Controls.Add(this.label4);
            this.radPanel5.Controls.Add(this.txtEmail);
            this.radPanel5.Controls.Add(this.label3);
            this.radPanel5.Controls.Add(this.txtPhoneNr);
            this.radPanel5.Controls.Add(this.label2);
            this.radPanel5.Controls.Add(this.txtLastName);
            this.radPanel5.Controls.Add(this.lblID);
            this.radPanel5.Controls.Add(this.lblUserName);
            this.radPanel5.Controls.Add(this.txtName);
            resources.ApplyResources(this.radPanel5, "radPanel5");
            this.radPanel5.Name = "radPanel5";
            this.radPanel5.ThemeName = "MaterialBlueGrey";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtAddress
            // 
            resources.ApplyResources(this.txtAddress, "txtAddress");
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ThemeName = "MaterialBlueGrey";
            this.radValidationProvider1.SetValidationRule(this.txtAddress, null);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtEmail
            // 
            resources.ApplyResources(this.txtEmail, "txtEmail");
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ThemeName = "MaterialBlueGrey";
            this.radValidationProvider1.SetValidationRule(this.txtEmail, null);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtPhoneNr
            // 
            resources.ApplyResources(this.txtPhoneNr, "txtPhoneNr");
            this.txtPhoneNr.Name = "txtPhoneNr";
            this.txtPhoneNr.ThemeName = "MaterialBlueGrey";
            this.radValidationProvider1.SetValidationRule(this.txtPhoneNr, null);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblID
            // 
            resources.ApplyResources(this.lblID, "lblID");
            this.lblID.Name = "lblID";
            // 
            // lblUserName
            // 
            resources.ApplyResources(this.lblUserName, "lblUserName");
            this.lblUserName.Name = "lblUserName";
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
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClear.GetChildAt(0))).Text = resources.GetString("resource.Text2");
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment2")));
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
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDelete.GetChildAt(0))).Text = resources.GetString("resource.Text3");
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnDelete.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDelete.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDelete.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDelete.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment3")));
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
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radPanel5);
            this.radPanel1.Controls.Add(this.radPanel4);
            resources.ApplyResources(this.radPanel1, "radPanel1");
            this.radPanel1.Name = "radPanel1";
            // 
            // radValidationProvider1
            // 
            this.radValidationProvider1.ValidationMode = Telerik.WinControls.UI.ValidationMode.Programmatically;
            radValidationRule1.Controls.Add(this.txtName);
            radValidationRule1.Operator = Telerik.WinControls.Data.FilterOperator.IsNotLike;
            radValidationRule1.ToolTipText = "Emri nuk mund të jetë i zbrazët!";
            radValidationRule1.ToolTipTitle = "Validimi Dështoi!";
            radValidationRule1.Value = "";
            radValidationRule2.Controls.Add(this.txtLastName);
            radValidationRule2.Operator = Telerik.WinControls.Data.FilterOperator.IsNotLike;
            radValidationRule2.ToolTipText = "Mbiemri nuk mund të jetë i zbrazët!";
            radValidationRule2.ToolTipTitle = "Validimi Dështoi!";
            radValidationRule2.Value = "";
            this.radValidationProvider1.ValidationRules.AddRange(new Telerik.WinControls.Data.FilterDescriptor[] {
            radValidationRule1,
            radValidationRule2});
            // 
            // ClientsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radPanel6);
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClientsForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ThemeName = "MaterialBlueGrey";
            this.Load += new System.EventHandler(this.ClientsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLastName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel6)).EndInit();
            this.radPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).EndInit();
            this.radPanel5.ResumeLayout(false);
            this.radPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhoneNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel6;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadButton btnUpdate;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadPanel radPanel5;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblUserName;
        private Telerik.WinControls.UI.RadTextBox txtName;
        private Telerik.WinControls.UI.RadValidationProvider radValidationProvider1;
        private Telerik.WinControls.UI.RadButton btnClear;
        private Telerik.WinControls.UI.RadButton btnDelete;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadTextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadTextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadTextBox txtPhoneNr;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadTextBox txtLastName;
        private Telerik.WinControls.UI.RadGridView clientGridView1;
        private System.Windows.Forms.Label label6;
    }
}
