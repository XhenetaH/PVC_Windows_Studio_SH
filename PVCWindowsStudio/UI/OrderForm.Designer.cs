namespace PVCWindowsStudio.UI
{
    partial class OrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.RadValidationRule radValidationRule1 = new Telerik.WinControls.UI.RadValidationRule();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.clientMultiComboBox = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.radValidationProvider1 = new Telerik.WinControls.UI.RadValidationProvider(this.components);
            this.txtComment = new Telerik.WinControls.UI.RadTextBox();
            this.radDateTimePicker1 = new Telerik.WinControls.UI.RadDateTimePicker();
            this.txtDiscount = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.btnUpdate = new Telerik.WinControls.UI.RadButton();
            this.lblID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new Telerik.WinControls.UI.RadButton();
            this.btnDelete = new Telerik.WinControls.UI.RadButton();
            this.lblUserName = new System.Windows.Forms.Label();
            this.radPanel2 = new Telerik.WinControls.UI.RadPanel();
            this.orderGridView = new Telerik.WinControls.UI.RadGridView();
            this.radPanel5 = new Telerik.WinControls.UI.RadPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblClientID = new System.Windows.Forms.Label();
            this.discountCmb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.radPanel4 = new Telerik.WinControls.UI.RadPanel();
            this.btnPrint = new Telerik.WinControls.UI.RadDropDownButton();
            this.orderWithPhoto = new Telerik.WinControls.UI.RadMenuItem();
            this.classicOrder = new Telerik.WinControls.UI.RadMenuItem();
            this.materialBlueGreyTheme1 = new Telerik.WinControls.Themes.MaterialBlueGreyTheme();
            ((System.ComponentModel.ISupportInitialize)(this.clientMultiComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientMultiComboBox.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientMultiComboBox.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).BeginInit();
            this.radPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).BeginInit();
            this.radPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).BeginInit();
            this.radPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // clientMultiComboBox
            // 
            this.clientMultiComboBox.AutoFilter = true;
            this.clientMultiComboBox.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            // 
            // clientMultiComboBox.NestedRadGridView
            // 
            this.clientMultiComboBox.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.clientMultiComboBox.EditorControl, "clientMultiComboBox.NestedRadGridView");
            this.clientMultiComboBox.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // 
            // 
            this.clientMultiComboBox.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.clientMultiComboBox.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.clientMultiComboBox.EditorControl.MasterTemplate.AllowColumnChooser = false;
            this.clientMultiComboBox.EditorControl.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.clientMultiComboBox.EditorControl.MasterTemplate.AllowSearchRow = true;
            this.clientMultiComboBox.EditorControl.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "ClientID";
            resources.ApplyResources(gridViewTextBoxColumn1, "gridViewTextBoxColumn1");
            gridViewTextBoxColumn1.Name = "ClientID";
            gridViewTextBoxColumn1.Width = 41;
            gridViewTextBoxColumn2.FieldName = "FullName";
            resources.ApplyResources(gridViewTextBoxColumn2, "gridViewTextBoxColumn2");
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.Width = 229;
            this.clientMultiComboBox.EditorControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2});
            this.clientMultiComboBox.EditorControl.MasterTemplate.EnableFiltering = true;
            this.clientMultiComboBox.EditorControl.MasterTemplate.EnableGrouping = false;
            this.clientMultiComboBox.EditorControl.MasterTemplate.SelectionMode = Telerik.WinControls.UI.GridViewSelectionMode.None;
            this.clientMultiComboBox.EditorControl.MasterTemplate.ShowColumnHeaders = false;
            this.clientMultiComboBox.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.clientMultiComboBox.EditorControl.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.clientMultiComboBox.EditorControl.Name = "NestedRadGridView";
            this.clientMultiComboBox.EditorControl.ReadOnly = true;
            this.clientMultiComboBox.EditorControl.ShowGroupPanel = false;
            this.clientMultiComboBox.EditorControl.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radMultiColumnComboBox1_EditorControl_CellClick);
            resources.ApplyResources(this.clientMultiComboBox, "clientMultiComboBox");
            this.clientMultiComboBox.Name = "clientMultiComboBox";
            this.clientMultiComboBox.TabStop = false;
            this.clientMultiComboBox.ThemeName = "MaterialBlueGrey";
            this.radValidationProvider1.SetValidationRule(this.clientMultiComboBox, null);
            // 
            // radValidationProvider1
            // 
            this.radValidationProvider1.ValidationMode = Telerik.WinControls.UI.ValidationMode.Programmatically;
            radValidationRule1.Operator = Telerik.WinControls.Data.FilterOperator.IsNotLike;
            radValidationRule1.ToolTipText = "Name can\'t be empty!";
            radValidationRule1.Value = "";
            this.radValidationProvider1.ValidationRules.AddRange(new Telerik.WinControls.Data.FilterDescriptor[] {
            radValidationRule1});
            // 
            // txtComment
            // 
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            // 
            // 
            // 
            this.txtComment.RootElement.StretchVertically = true;
            this.txtComment.ThemeName = "MaterialBlueGrey";
            this.radValidationProvider1.SetValidationRule(this.txtComment, null);
            // 
            // radDateTimePicker1
            // 
            this.radDateTimePicker1.CalendarSize = new System.Drawing.Size(290, 320);
            resources.ApplyResources(this.radDateTimePicker1, "radDateTimePicker1");
            this.radDateTimePicker1.Name = "radDateTimePicker1";
            this.radDateTimePicker1.TabStop = false;
            this.radDateTimePicker1.ThemeName = "MaterialBlueGrey";
            this.radValidationProvider1.SetValidationRule(this.radDateTimePicker1, null);
            this.radDateTimePicker1.Value = new System.DateTime(2021, 6, 18, 15, 14, 13, 181);
            // 
            // txtDiscount
            // 
            resources.ApplyResources(this.txtDiscount, "txtDiscount");
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.TabStop = false;
            this.txtDiscount.ThemeName = "MaterialBlueGrey";
            this.radValidationProvider1.SetValidationRule(this.txtDiscount, null);
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
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnUpdate.GetChildAt(0))).Text = resources.GetString("resource.Text");
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnUpdate.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdate.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdate.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnUpdate.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment")));
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
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnClear.GetChildAt(0))).Text = resources.GetString("resource.Text1");
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnClear.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment1")));
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
            ((Telerik.WinControls.UI.RadButtonElement)(this.btnDelete.GetChildAt(0))).Text = resources.GetString("resource.Text2");
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.btnDelete.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDelete.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDelete.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnDelete.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment2")));
            // 
            // lblUserName
            // 
            resources.ApplyResources(this.lblUserName, "lblUserName");
            this.lblUserName.Name = "lblUserName";
            // 
            // radPanel2
            // 
            this.radPanel2.Controls.Add(this.orderGridView);
            resources.ApplyResources(this.radPanel2, "radPanel2");
            this.radPanel2.Name = "radPanel2";
            // 
            // orderGridView
            // 
            this.orderGridView.BackColor = System.Drawing.Color.White;
            this.orderGridView.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.orderGridView, "orderGridView");
            this.orderGridView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.orderGridView.HideSelection = true;
            // 
            // 
            // 
            this.orderGridView.MasterTemplate.AllowAddNewRow = false;
            this.orderGridView.MasterTemplate.AllowDeleteRow = false;
            this.orderGridView.MasterTemplate.AllowEditRow = false;
            this.orderGridView.MasterTemplate.AllowSearchRow = true;
            this.orderGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "OrderID";
            resources.ApplyResources(gridViewTextBoxColumn3, "gridViewTextBoxColumn3");
            gridViewTextBoxColumn3.MinWidth = 6;
            gridViewTextBoxColumn3.Name = "OrderID";
            gridViewTextBoxColumn3.SortOrder = Telerik.WinControls.UI.RadSortOrder.Descending;
            gridViewTextBoxColumn3.Width = 88;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Clients.FullName";
            resources.ApplyResources(gridViewTextBoxColumn4, "gridViewTextBoxColumn4");
            gridViewTextBoxColumn4.MinWidth = 6;
            gridViewTextBoxColumn4.Name = "Client";
            gridViewTextBoxColumn4.Width = 102;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "FullDiscount";
            resources.ApplyResources(gridViewTextBoxColumn5, "gridViewTextBoxColumn5");
            gridViewTextBoxColumn5.MinWidth = 6;
            gridViewTextBoxColumn5.Name = "Discount";
            gridViewTextBoxColumn5.Width = 74;
            gridViewTextBoxColumn6.DataType = typeof(decimal);
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "TotalPrice";
            resources.ApplyResources(gridViewTextBoxColumn6, "gridViewTextBoxColumn6");
            gridViewTextBoxColumn6.MinWidth = 6;
            gridViewTextBoxColumn6.Name = "TotalPrice";
            gridViewTextBoxColumn6.Width = 74;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Date";
            resources.ApplyResources(gridViewTextBoxColumn7, "gridViewTextBoxColumn7");
            gridViewTextBoxColumn7.MinWidth = 6;
            gridViewTextBoxColumn7.Name = "Date";
            gridViewTextBoxColumn7.Width = 88;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Comment";
            resources.ApplyResources(gridViewTextBoxColumn8, "gridViewTextBoxColumn8");
            gridViewTextBoxColumn8.MinWidth = 6;
            gridViewTextBoxColumn8.Name = "Comment";
            gridViewTextBoxColumn8.Width = 122;
            this.orderGridView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.orderGridView.MasterTemplate.EnablePaging = true;
            sortDescriptor1.Direction = System.ComponentModel.ListSortDirection.Descending;
            sortDescriptor1.PropertyName = "OrderID";
            this.orderGridView.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.orderGridView.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.orderGridView.Name = "orderGridView";
            this.orderGridView.ThemeName = "MaterialBlueGrey";
            this.orderGridView.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.MasterTemplate_CellClick);
            // 
            // radPanel5
            // 
            this.radPanel5.Controls.Add(this.label1);
            this.radPanel5.Controls.Add(this.label5);
            this.radPanel5.Controls.Add(this.lblClientID);
            this.radPanel5.Controls.Add(this.discountCmb);
            this.radPanel5.Controls.Add(this.txtDiscount);
            this.radPanel5.Controls.Add(this.label4);
            this.radPanel5.Controls.Add(this.radDateTimePicker1);
            this.radPanel5.Controls.Add(this.label3);
            this.radPanel5.Controls.Add(this.clientMultiComboBox);
            this.radPanel5.Controls.Add(this.lblID);
            this.radPanel5.Controls.Add(this.label2);
            this.radPanel5.Controls.Add(this.txtComment);
            this.radPanel5.Controls.Add(this.lblUserName);
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
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lblClientID
            // 
            resources.ApplyResources(this.lblClientID, "lblClientID");
            this.lblClientID.Name = "lblClientID";
            // 
            // discountCmb
            // 
            resources.ApplyResources(this.discountCmb, "discountCmb");
            this.discountCmb.FormattingEnabled = true;
            this.discountCmb.Items.AddRange(new object[] {
            resources.GetString("discountCmb.Items"),
            resources.GetString("discountCmb.Items1")});
            this.discountCmb.Name = "discountCmb";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radPanel5);
            this.radPanel1.Controls.Add(this.radPanel4);
            resources.ApplyResources(this.radPanel1, "radPanel1");
            this.radPanel1.Name = "radPanel1";
            // 
            // radPanel4
            // 
            this.radPanel4.Controls.Add(this.btnPrint);
            this.radPanel4.Controls.Add(this.btnClear);
            this.radPanel4.Controls.Add(this.btnDelete);
            this.radPanel4.Controls.Add(this.btnUpdate);
            resources.ApplyResources(this.radPanel4, "radPanel4");
            this.radPanel4.Name = "radPanel4";
            this.radPanel4.ThemeName = "MaterialBlueGrey";
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.btnPrint.Image = global::PVCWindowsStudio.Properties.Resources.print;
            this.btnPrint.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.orderWithPhoto,
            this.classicOrder});
            this.btnPrint.Name = "btnPrint";
            // 
            // 
            // 
            this.btnPrint.RootElement.CustomFontSize = 14.5F;
            this.btnPrint.SvgImageXml = null;
            this.btnPrint.ThemeName = "MaterialBlueGrey";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.btnPrint.GetChildAt(0))).Image = global::PVCWindowsStudio.Properties.Resources.print;
            ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.btnPrint.GetChildAt(0))).TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.btnPrint.GetChildAt(0))).Text = resources.GetString("resource.Text3");
            ((Telerik.WinControls.UI.RadDropDownButtonElement)(this.btnPrint.GetChildAt(0))).CanFocus = true;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(5))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(5))).Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            ((Telerik.WinControls.Primitives.TextPrimitive)(this.btnPrint.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(1).GetChildAt(1))).Alignment = ((System.Drawing.ContentAlignment)(resources.GetObject("resource.Alignment3")));
            // 
            // orderWithPhoto
            // 
            this.orderWithPhoto.Font = new System.Drawing.Font("Segoe UI", 11.8F, System.Drawing.FontStyle.Bold);
            this.orderWithPhoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.orderWithPhoto.Name = "orderWithPhoto";
            resources.ApplyResources(this.orderWithPhoto, "orderWithPhoto");
            this.orderWithPhoto.UseCompatibleTextRendering = false;
            this.orderWithPhoto.Click += new System.EventHandler(this.printWithPhoto_Click);
            // 
            // classicOrder
            // 
            this.classicOrder.DescriptionFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classicOrder.Font = new System.Drawing.Font("Segoe UI", 11.8F, System.Drawing.FontStyle.Bold);
            this.classicOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(125)))), ((int)(((byte)(139)))));
            this.classicOrder.Name = "classicOrder";
            resources.ApplyResources(this.classicOrder, "classicOrder");
            this.classicOrder.Click += new System.EventHandler(this.classicOrder_Click);
            // 
            // OrderForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radPanel2);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ThemeName = "MaterialBlueGrey";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientMultiComboBox.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientMultiComboBox.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientMultiComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDateTimePicker1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel2)).EndInit();
            this.radPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel5)).EndInit();
            this.radPanel5.ResumeLayout(false);
            this.radPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radPanel4)).EndInit();
            this.radPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadValidationProvider radValidationProvider1;
        private Telerik.WinControls.UI.RadTextBox txtComment;
        private Telerik.WinControls.UI.RadButton btnUpdate;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadButton btnClear;
        private Telerik.WinControls.UI.RadButton btnDelete;
        private System.Windows.Forms.Label lblUserName;
        private Telerik.WinControls.UI.RadPanel radPanel2;
        private Telerik.WinControls.UI.RadGridView orderGridView;
        private Telerik.WinControls.UI.RadPanel radPanel5;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadPanel radPanel4;
        private Telerik.WinControls.Themes.MaterialBlueGreyTheme materialBlueGreyTheme1;
        private Telerik.WinControls.UI.RadMultiColumnComboBox clientMultiComboBox;
        private Telerik.WinControls.UI.RadMaskedEditBox txtDiscount;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadDateTimePicker radDateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox discountCmb;
        private System.Windows.Forms.Label lblClientID;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadDropDownButton btnPrint;
        private Telerik.WinControls.UI.RadMenuItem orderWithPhoto;
        private Telerik.WinControls.UI.RadMenuItem classicOrder;
        private System.Windows.Forms.Label label1;
    }
}
