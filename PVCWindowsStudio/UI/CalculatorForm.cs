using PVCWindowsStudio.BLL;
using PVCWindowsStudio.BLL.FormModels;
using PVCWindowsStudio.BO;
using PVCWindowsStudio.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.Documents.SpreadsheetStreaming;
using Telerik.WinControls;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;

namespace PVCWindowsStudio.UI
{
    public partial class CalculatorForm : Telerik.WinControls.UI.RadForm
    {        
        public bool validating = false;

        private readonly CalculatorModel calcM = new CalculatorModel();
              

        public CalculatorForm()
        {                        
            InitializeComponent();
        }

        private decimal CalcPrice(int productId,int profileId,int blindId,int paneId,decimal width,decimal height)
        {
            if (productId > 0)
            {
                var formulaList = calcM.detailsBll.GetPrice(profileId, productId);

                for (int i = 0; i < formulaList.Count; i++)
                {
                    if (formulaList[i].Formula.Contains("Price"))
                    {
                        formulaList[i].Formula = formulaList[i].Formula.Replace("Price", formulaList[i].Price);
                    }
                    if (formulaList[i].Formula.Contains("Width"))
                    {
                        formulaList[i].Formula = formulaList[i].Formula.Replace("Width", width.ToString());
                    }
                    if (formulaList[i].Formula.Contains("Height"))
                    {
                        formulaList[i].Formula = formulaList[i].Formula.Replace("Height", height.ToString());
                    }
                }
                string total = "";

                for (int i = 0; i < formulaList.Count; i++)
                {
                    total = total + "+" + formulaList[i].Formula;
                }

                decimal price = Convert.ToDecimal(new DataTable().Compute(total, null));

                var paneprice = GetWindowPanePrice(paneId, width, height);
                var blindprice = GetBlindPrice(blindId, width, height);
                var handiworkprice = HandiWorkPrice(width, height);
                return Math.Round(price + paneprice + handiworkprice + blindprice);
            }
            else
                return 0;

        }

        private decimal GetWindowPanePrice(int id,decimal width,decimal height)
        {
            var pr = calcM.windowpaneBll.GetPrice(id);
            if (pr != -1)
                return (height / 100) * (width / 100) * pr;
            else return 0;
                    
        }
        private decimal GetBlindPrice(int id, decimal width, decimal height)
        {
            var pr = calcM.blindBll.GetPrice(id);
            if (pr != -1)
                return (height / 100) * (width / 100) * pr;
            else return 0;

        }

        private decimal HandiWorkPrice(decimal width,decimal height)
        {
            var pr = calcM.workBll.GetPrice(width,height);
            if (pr != -1)
                return pr;
            else return 0;
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {

            chooseProfile.Text = "Choose Profile";           
           
            clientradMultiColumnComboBox1.DataSource = calcM.clientBll.GetName();
            clientradMultiColumnComboBox1.SelectedIndex = -1;
            clientradMultiColumnComboBox1.AutoCompleteMode = AutoCompleteMode.Append;
            clientradMultiColumnComboBox1.Text = "Choose a client";


            GridViewComboBoxColumn col = this.calculatorGridView.Columns["Blind"] as GridViewComboBoxColumn;
            col.DataSource = calcM.blindBll.GetAll();
            col.DisplayMember = "Name";
            col.ValueMember = "BlindID";

            GridViewComboBoxColumn combo = this.calculatorGridView.Columns["Profile"] as GridViewComboBoxColumn;
            combo.DataSource = calcM.profileBll.GetExistProfile();
            combo.DisplayMember = "NameProf";
            combo.ValueMember = "ProfileID";          


            ddlProfile.DataSource = calcM.profileBll.GetExistProfile();
            ddlProfile.DisplayMember = "NameProf";
            ddlProfile.ValueMember = "ProfileID";
            ddlProfile.Text = "Choose a Profile";
            ddlProfile.SelectedIndex = -1;


            ddlWindowPane.DataSource = calcM.windowpaneBll.GetAll();
            ddlWindowPane.DisplayMember = "Name";
            ddlWindowPane.ValueMember = "WindowPaneID";
            ddlWindowPane.Text = "Choose Window Pane";

            discountCmb.SelectedIndex = 1;

            RadMessageBox.SetThemeName("MaterialBlueGrey");
            

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 60000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();

            LoadTemporaryData();
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            SaveTemporary();
        }

        private void LoadTemporaryData()
        {
            var list = calcM.detailsBll.GetAll_Temporary();
            if (list!=null)
            {
                calculatorGridView.DataSource = list;
            }
        }

        private void clientradMultiColumnComboBox1_EditorControl_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int rowindx = clientradMultiColumnComboBox1.EditorControl.CurrentCell.RowIndex;
            calcM.client = (Clients)clientradMultiColumnComboBox1.EditorControl.Rows[rowindx].DataBoundItem;
            lblClientID.Text = calcM.client.ClientID.ToString();
            txtName.Text = calcM.client.Name;
            txtLastName.Text = calcM.client.LastName;
            txtPhoneNr.Text = calcM.client.PhoneNumber;
            txtEmail.Text = calcM.client.Email;
            txtAddress.Text = calcM.client.Address;
        }



        private void TotalPriceCalc()
        {

            if (String.IsNullOrEmpty(txtDiscount.Text))
                txtTotal.Text = Convert.ToString(Math.Round(Total() - 0));
            else
            {
                if (discountCmb.SelectedIndex == 0)
                    txtTotal.Text = Convert.ToString(Math.Round(Total() - Discount()));
                if (discountCmb.SelectedIndex == 1)
                    txtTotal.Text = Convert.ToString(Math.Round(Total() - Convert.ToDecimal(txtDiscount.Text)));
            }

        }

        private decimal Total()
        {
            decimal total = 0;
            for (int i = 0; i < calculatorGridView.Rows.Count; i++)
            {
                total += Convert.ToDecimal(calculatorGridView.Rows[i].Cells["Total"].Value);
            }
            return Math.Round(total);

        }

        private decimal Discount()
        {
            decimal discount = Convert.ToDecimal(txtDiscount.Text);

            discount = (discount / 100) * Total();
            return discount;
        }

        private void calculatorGridView_RowsChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {            
            if (e.Action == Telerik.WinControls.Data.NotifyCollectionChangedAction.Add)
            {                
                var newRow = e.NewItems[0] as GridViewDataRowInfo;
                int profileId=-2;
                if (chooseProfile.SelectedIndex == 0)
                    profileId = int.Parse(ddlProfile.SelectedValue.ToString());
                else if(chooseProfile.SelectedIndex == 1)
                    profileId = int.Parse(calculatorGridView.CurrentRow.Cells["Profile"].Value.ToString());
                if (profileId > -1)
                {
                    newRow.Cells["Price"].Value = CalcPrice(int.Parse(newRow.Cells["Product"].Value.ToString()), profileId, int.Parse(newRow.Cells["Blind"].Value.ToString()), int.Parse(ddlWindowPane.SelectedValue.ToString()), Convert.ToDecimal(newRow.Cells["Width"].Value.ToString()), Convert.ToDecimal(newRow.Cells["Height"].Value.ToString()));
                    newRow.Cells["Total"].Value = Convert.ToDecimal(newRow.Cells["Price"].Value) * int.Parse(newRow.Cells["Quantity"].Value.ToString());
                    newRow.Cells["HandWorkPrice"].Value = Convert.ToDecimal(calcM.workBll.GetPrice(Convert.ToDecimal(newRow.Cells["Width"].Value.ToString()), Convert.ToDecimal(newRow.Cells["Height"].Value.ToString())));
                }
            }
            
            TotalPriceCalc();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            TotalPriceCalc();
        }

        private void discountCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalPriceCalc();
        }

        private void btnClearClient_Click(object sender, EventArgs e)
        {
            clientradMultiColumnComboBox1.SelectedIndex = -1;
            clientradMultiColumnComboBox1.Text = "Choose a client";

            lblClientID.Text = "";
            txtName.Text = "";
            txtLastName.Text = "";
            txtPhoneNr.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void btnClearInfo_Click(object sender, EventArgs e)
        {
            ddlProfile.SelectedIndex = -1;
            ddlProfile.Text = "Choose a profile";
            ddlWindowPane.SelectedIndex = -1;
            ddlWindowPane.Text = "Choose a window pane";
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            while (calculatorGridView.RowCount != 0)
            {
                for (int i = 0; i < calculatorGridView.RowCount; i++)
                {
                    calculatorGridView.Rows.RemoveAt(i);
                }
            }
            calcM.detailsBll.Delete_Temporary();
        }

        bool isColmnAdded;
        private void calculatorGridView_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (this.calculatorGridView.CurrentColumn is GridViewMultiComboBoxColumn)
            {
                if (!isColmnAdded)
                {
                    isColmnAdded = true;
                    RadMultiColumnComboBoxElement editor = (RadMultiColumnComboBoxElement)this.calculatorGridView.ActiveEditor;
                    editor.EditorControl.MasterTemplate.AutoGenerateColumns = false;
                    editor.EditorControl.AllowSearchRow = true;
                    editor.EditorControl.Columns.Add(new GridViewTextBoxColumn("ProductID"));
                    editor.EditorControl.Columns.Add(new GridViewImageColumn("Picture"));
                    editor.EditorControl.Columns.Add(new GridViewTextBoxColumn("Name"));
                    editor.EditorControl.Columns[0].IsVisible = false;
                    editor.EditorControl.Columns[1].ImageLayout = ImageLayout.Zoom;
                    editor.EditorControl.Columns[1].Width = 130;
                    editor.EditorControl.Columns[2].Width = 100;
                    editor.EditorControl.TableElement.RowHeight = 110;
                    editor.EditorControl.Width = 200;


                }
            }            

        }

        private void calculatorGridView_CellValidating(object sender, CellValidatingEventArgs e)
        {
            var currentRow = calculatorGridView.CurrentRow;
            
            if (!e.ColumnIndex.Equals(-1) && !e.RowIndex.Equals(-1))
            {
                int profileId = -1;
                if (chooseProfile.SelectedIndex == 0)
                {
                    if (ddlProfile.SelectedValue != null)
                        profileId = int.Parse(ddlProfile.SelectedValue.ToString());
                }
                else
                {
                    if (calculatorGridView.CurrentRow.Cells["Profile"].Value != null)
                        profileId = int.Parse(calculatorGridView.CurrentRow.Cells["Profile"].Value.ToString());
                }
                if (ddlWindowPane.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a window pane!");
                }
                else if (chooseProfile.SelectedIndex == 0 && ddlProfile.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a profile!");
                }
                else if (chooseProfile.SelectedIndex == 1 && calculatorGridView.CurrentRow.Cells["Profile"].Value == null)
                {
                    RadMessageBox.Show("Please select a profile!");
                }                              
                else
                {
                    if (e.Column.Name == "Product")
                    {
                        if (e.Value == null)
                        {
                            e.Cancel = true;
                            RadMessageBox.Show($"{e.Column.Name} can't be empty!");
                        }
                        else
                        {

                            currentRow.Cells["Price"].Value = CalcPrice(int.Parse(e.Value.ToString()), profileId, int.Parse(currentRow.Cells["Blind"].Value.ToString()), int.Parse(ddlWindowPane.SelectedValue.ToString()), Convert.ToDecimal(currentRow.Cells["Width"].Value.ToString()), Convert.ToDecimal(currentRow.Cells["Height"].Value.ToString()));
                            currentRow.Cells["Total"].Value = Convert.ToDecimal(currentRow.Cells["Price"].Value) * int.Parse(currentRow.Cells["Quantity"].Value.ToString());

                        }
                    }
                    if (e.Column.Name == "Blind")
                    {
                        if (e.Value == null)
                        {
                            e.Cancel = true;
                            RadMessageBox.Show($"{e.Column.Name} can't be empty!");
                        }
                        else
                        {
                            currentRow.Cells["Price"].Value = CalcPrice(int.Parse(currentRow.Cells["Product"].Value.ToString()), profileId, int.Parse(e.Value.ToString()), int.Parse(ddlWindowPane.SelectedValue.ToString()), Convert.ToDecimal(currentRow.Cells["Width"].Value.ToString()), Convert.ToDecimal(currentRow.Cells["Height"].Value.ToString()));
                            currentRow.Cells["Total"].Value = Convert.ToDecimal(currentRow.Cells["Price"].Value) * int.Parse(currentRow.Cells["Quantity"].Value.ToString());

                        }
                    }
                    if (e.Column.Name == "Width")
                    {
                        if (e.Value != null)
                        {
                            currentRow.Cells["Price"].Value = CalcPrice(int.Parse(currentRow.Cells["Product"].Value.ToString()), profileId, int.Parse(currentRow.Cells["Blind"].Value.ToString()), int.Parse(ddlWindowPane.SelectedValue.ToString()), Convert.ToDecimal(e.Value.ToString()), Convert.ToDecimal(currentRow.Cells["Height"].Value.ToString()));
                            currentRow.Cells["Total"].Value = Convert.ToDecimal(currentRow.Cells["Price"].Value) * int.Parse(currentRow.Cells["Quantity"].Value.ToString());
                            currentRow.Cells["HandWorkPrice"].Value = Convert.ToDecimal(calcM.workBll.GetPrice(Convert.ToDecimal(e.Value.ToString()), Convert.ToDecimal(currentRow.Cells["Height"].Value.ToString())));
                        }
                        else
                        {
                            e.Cancel = true;
                            RadMessageBox.Show($"{e.Column.Name} can't be empty!");
                        }

                    }
                    if (e.Column.Name == "Height")
                    {
                        if (e.Value != null)
                        {
                            currentRow.Cells["Price"].Value = CalcPrice(int.Parse(currentRow.Cells["Product"].Value.ToString()), profileId, int.Parse(currentRow.Cells["Blind"].Value.ToString()), int.Parse(ddlWindowPane.SelectedValue.ToString()), Convert.ToDecimal(currentRow.Cells["Width"].Value.ToString()), Convert.ToDecimal(e.Value.ToString()));
                            currentRow.Cells["Total"].Value = Convert.ToDecimal(currentRow.Cells["Price"].Value) * int.Parse(currentRow.Cells["Quantity"].Value.ToString());
                            currentRow.Cells["HandWorkPrice"].Value = Convert.ToDecimal(calcM.workBll.GetPrice(Convert.ToDecimal(currentRow.Cells["Height"].Value.ToString()), Convert.ToDecimal(e.Value.ToString())));
                        }
                        else
                        {
                            e.Cancel = true;                           
                            RadMessageBox.Show($"{e.Column.Name} can't be empty!");
                        }
                    }
                    if (e.Column.Name == "Quantity")
                    {
                        if (e.Value != null)
                        {                            
                            currentRow.Cells["Total"].Value = Convert.ToDecimal(currentRow.Cells["Price"].Value) * int.Parse(e.Value.ToString());
                        }
                        else
                        {
                            e.Cancel = true;
                            RadMessageBox.Show($"{e.Column.Name} can't be empty!");
                        }

                    }
                }
            }
        }

        private void calculatorGridView_UserAddingRow(object sender, GridViewRowCancelEventArgs e)
        {
            if (e.Rows[0].Cells["Width"].Value == null 
                || e.Rows[0].Cells["Height"].Value == null 
                ||e.Rows[0].Cells["Product"].Value == null
                || e.Rows[0].Cells["Blind"].Value == null
                || e.Rows[0].Cells["Quantity"].Value == null)
            {
                e.Cancel = true;

                var confirmClear = RadMessageBox.Show("Please fill all the fields!","", MessageBoxButtons.OKCancel,RadMessageIcon.Info);
                if (DialogResult.Cancel == confirmClear)
                {
                    calculatorGridView.MasterView.TableAddNewRow.CancelAddNewRow();
                    
                }
            }
        }



        private void ddlProfile_SelectedValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < calculatorGridView.RowCount; i++)
            {
                calculatorGridView.Rows[i].Cells["Price"].Value = CalcPrice(int.Parse(calculatorGridView.Rows[i].Cells["Product"].Value.ToString()), int.Parse(ddlProfile.SelectedValue.ToString()), int.Parse(calculatorGridView.Rows[i].Cells["Blind"].Value.ToString()), int.Parse(ddlWindowPane.SelectedValue.ToString()), Convert.ToDecimal(calculatorGridView.Rows[i].Cells["Width"].Value.ToString()), Convert.ToDecimal(calculatorGridView.Rows[i].Cells["Height"].Value.ToString()));
                calculatorGridView.Rows[i].Cells["Total"].Value = Convert.ToDecimal(calculatorGridView.Rows[i].Cells["Price"].Value) * int.Parse(calculatorGridView.Rows[i].Cells["Quantity"].Value.ToString());
            }            
        }

        private void ddlWindowPane_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (calculatorGridView.RowCount > 0)
            {
                int profileID = -2;
                if (chooseProfile.SelectedIndex == 0)
                {
                    if (ddlProfile.SelectedIndex > -1)
                        profileID = int.Parse(ddlProfile.SelectedValue.ToString());
                }
                else if (chooseProfile.SelectedIndex == 1)
                    if (calculatorGridView.CurrentRow.Cells["Profile"].Value != null)
                        profileID = int.Parse(calculatorGridView.CurrentRow.Cells["Profile"].Value.ToString());
                if (profileID > -1)
                {
                    for (int i = 0; i < calculatorGridView.RowCount; i++)
                    {
                        calculatorGridView.Rows[i].Cells["Price"].Value = CalcPrice(int.Parse(calculatorGridView.Rows[i].Cells["Product"].Value.ToString()), profileID, int.Parse(calculatorGridView.Rows[i].Cells["Blind"].Value.ToString()), int.Parse(ddlWindowPane.SelectedValue.ToString()), Convert.ToDecimal(calculatorGridView.Rows[i].Cells["Width"].Value.ToString()), Convert.ToDecimal(calculatorGridView.Rows[i].Cells["Height"].Value.ToString()));
                        calculatorGridView.Rows[i].Cells["Total"].Value = Convert.ToDecimal(calculatorGridView.Rows[i].Cells["Price"].Value) * int.Parse(calculatorGridView.Rows[i].Cells["Quantity"].Value.ToString());

                    }
                }
            }

        }
        private bool ValidationMethod()
        {
            bool valid = true;
            if (this.radValidationProvider1.ValidationMode == ValidationMode.Programmatically)
            {
                foreach (Control control in this.radPanel1.Controls)
                {
                    RadEditorControl editorControl = control as RadEditorControl;
                    if (editorControl != null)
                    {
                        this.radValidationProvider1.Validate(editorControl);
                        var mode = this.radValidationProvider1.AssociatedControls;
                        foreach (var i in mode)
                        {
                            if (string.IsNullOrEmpty(i.AccessibilityObject.Value))
                                valid = false;
                        }
                    }
                }
            }
            return valid;
        }

        private void radPanel1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (calculatorGridView.RowCount>0)
            {

                string exportFile = string.Empty;
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    if (sfd.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    exportFile = sfd.FileName + ".xlsx";
                }
                if (!string.IsNullOrEmpty(exportFile))
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        Telerik.WinControls.Export.GridViewSpreadExport exporter = new Telerik.WinControls.Export.GridViewSpreadExport(this.calculatorGridView);
                        Telerik.WinControls.Export.SpreadExportRenderer renderer = new Telerik.WinControls.Export.SpreadExportRenderer();
                        exporter.RunExport(ms, renderer);

                        using (System.IO.FileStream fileStream = new System.IO.FileStream(exportFile, FileMode.Create, FileAccess.Write))
                        {
                            ms.WriteTo(fileStream);
                            if (File.Exists(fileStream.Name)) RadMessageBox.Show("Order details exported to excel!");
                        }
                    }
                }
                else RadMessageBox.Show("Something went wrong!");
            }
        }

        private void ddlProfile_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ddlProfile.SelectedIndex != -1)
            {
                GridViewMultiComboBoxColumn multi = this.calculatorGridView.Columns["Product"] as GridViewMultiComboBoxColumn;

                Profiles profile = new Profiles();
                profile = (Profiles)ddlProfile.SelectedItems[0].DataBoundItem;
                multi.DataSource = calcM.productBll.GetExistProdByColor(profile.Color);
                multi.DisplayMember = "Name";
                multi.ValueMember = "ProductID";

            }
        }

        private void chooseProfile_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            GridViewMultiComboBoxColumn multi = this.calculatorGridView.Columns["Product"] as GridViewMultiComboBoxColumn;

            if (chooseProfile.SelectedIndex==1)
            {
                calculatorGridView.Columns["Profile"].IsVisible = true;
                ddlProfile.Visible = false;
                multi.DataSource = calcM.productBll.GetExistProd();
                multi.DisplayMember = "Name";
                multi.ValueMember = "ProductID";

            }
            else if(chooseProfile.SelectedIndex ==0)
            {
                ddlProfile.Visible = true;
                calculatorGridView.Columns["Profile"].IsVisible = false;
                multi.DataSource = null;
            }
            else
            {
                calculatorGridView.Columns["Profile"].IsVisible = false;
                ddlProfile.Visible = false;
            }
            
        }

        private void calculatorGridView_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.HeaderText == "Profile")
            {
                if (calculatorGridView.CurrentRow.Cells["Product"].Value != null)
                {
                    if (calculatorGridView.CurrentRow.Cells["Profile"].Value != null)
                    {
                        if (calculatorGridView.CurrentRow.Cells["Blind"].Value != null)
                        {
                            if (ddlWindowPane.SelectedIndex > -1)
                            {
                                if (calculatorGridView.CurrentRow.Cells["Width"].Value != null)
                                {
                                    if (calculatorGridView.CurrentRow.Cells["Height"].Value != null)
                                    {
                                        if (calculatorGridView.CurrentRow.Cells["Quantity"].Value != null)
                                        {
                                            calculatorGridView.CurrentRow.Cells["Price"].Value = CalcPrice(int.Parse(calculatorGridView.CurrentRow.Cells["Product"].Value.ToString()), int.Parse(calculatorGridView.CurrentRow.Cells["Profile"].Value.ToString()), int.Parse(calculatorGridView.CurrentRow.Cells["Blind"].Value.ToString()), int.Parse(ddlWindowPane.SelectedValue.ToString()), Convert.ToDecimal(calculatorGridView.CurrentRow.Cells["Width"].Value.ToString()), Convert.ToDecimal(calculatorGridView.CurrentRow.Cells["Height"].Value.ToString()));
                                            calculatorGridView.CurrentRow.Cells["Total"].Value = Convert.ToDecimal(calculatorGridView.CurrentRow.Cells["Price"].Value) * int.Parse(calculatorGridView.CurrentRow.Cells["Quantity"].Value.ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        } 

        private void save_Click(object sender, EventArgs e)
        {           
            SaveTemporary();            
        }

        private void SaveTemporary()
        {
            if (ddlWindowPane.SelectedIndex > -1)
            {
                calcM.detailsBll.Delete_Temporary();
                if (calculatorGridView.RowCount > 0)
                {
                    for (int i = 0; i < calculatorGridView.RowCount; i++)
                    {
                        calcM.details.ProductID = int.Parse(calculatorGridView.Rows[i].Cells["Product"].Value.ToString());
                        calcM.details.Product = new Products()
                        {
                            Name = calcM.productBll.Get(calcM.details.ProductID).Name
                        };
                        if (chooseProfile.SelectedIndex == 0)
                        {
                            if (ddlProfile.SelectedIndex > -1)
                                calcM.details.ProfileID = int.Parse(ddlProfile.SelectedValue.ToString());
                        }
                        else if (chooseProfile.SelectedIndex == 1)
                        {
                            if (calculatorGridView.Rows[i].Cells["Profile"].Value != null)
                                calcM.details.ProfileID = int.Parse(calculatorGridView.Rows[i].Cells["Profile"].Value.ToString());
                        }
                        calcM.details.Profile = new Profiles()
                        {
                            Name = calcM.profileBll.Get(calcM.details.ProfileID).NameProf
                        };
                        calcM.details.BlindID = int.Parse(calculatorGridView.Rows[i].Cells["Blind"].Value.ToString());
                        calcM.details.Blind = new Blinds()
                        {
                            Name = calcM.blindBll.Get(calcM.details.BlindID).Name
                        };
                        calcM.details.WindowPaneID = int.Parse(ddlWindowPane.SelectedValue.ToString());
                        calcM.details.WindowPane = new WindowPanes()
                        {
                            Name = calcM.windowpaneBll.Get(calcM.details.WindowPaneID).Name
                        };
                        calcM.details.Quantity = int.Parse(calculatorGridView.Rows[i].Cells["Quantity"].Value.ToString());
                        calcM.details.Width = decimal.Parse(calculatorGridView.Rows[i].Cells["Width"].Value.ToString());
                        calcM.details.Height = decimal.Parse(calculatorGridView.Rows[i].Cells["Height"].Value.ToString());
                        calcM.details.Price = decimal.Parse(calculatorGridView.Rows[i].Cells["Price"].Value.ToString());
                        calcM.details.Total = decimal.Parse(calculatorGridView.Rows[i].Cells["Total"].Value.ToString());
                        calcM.details.HandWorkPrice = decimal.Parse(calculatorGridView.Rows[i].Cells["HandWorkPrice"].Value.ToString());
                        calcM.detailsBll.Insert_Temporary(calcM.details);

                    }
                }
            }
        }

        private void saveAs_Click(object sender, EventArgs e)
        {
            int clientID = 0;
            if (calculatorGridView.RowCount != 0)
            {
                if (ddlWindowPane.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a window pane!");
                }
                else
                {
                    if (String.IsNullOrEmpty(lblClientID.Text))
                    {
                        if (ValidationMethod())
                        {
                            radValidationProvider1.ClearErrorStatus();

                            calcM.client.Name = txtName.Text;
                            calcM.client.LastName = txtLastName.Text;
                            calcM.client.PhoneNumber = txtPhoneNr.Text;
                            calcM.client.Address = txtAddress.Text;
                            calcM.client.Email = txtEmail.Text;
                            calcM.client.InsertBy = 1;

                            calcM.clientBll.Insert(calcM.client);
                            clientID = calcM.clientBll.GetID();
                        }

                    }
                    else
                    {
                        clientID = int.Parse(lblClientID.Text);
                    }
                    if (clientID != 0)
                    {
                        calcM.order.ClientID = clientID;
                        calcM.order.Date = DateTime.Now;
                        calcM.order.Comment = "";
                        if (String.IsNullOrEmpty(txtDiscount.Text))
                            calcM.order.Discount = 0;
                        else
                            calcM.order.Discount = Convert.ToDecimal(txtDiscount.Text);
                        calcM.order.DiscountType = discountCmb.Text;
                        calcM.order.TotalPrice = Convert.ToDecimal(txtTotal.Text);
                        calcM.order.InsertBy = 1;
                        if (calcM.orderBll.Insert(calcM.order))
                        {

                            RadMessageBox.Show("Order inserted successfully!");

                        }
                        for (int i = 0; i < calculatorGridView.RowCount; i++)
                        {
                            calcM.details.OrderID = calcM.orderBll.GetID();
                            calcM.details.ProductID = int.Parse(calculatorGridView.Rows[i].Cells["Product"].Value.ToString());
                            calcM.details.BlindID = int.Parse(calculatorGridView.Rows[i].Cells["Blind"].Value.ToString());
                            calcM.details.WindowPaneID = int.Parse(ddlWindowPane.SelectedValue.ToString());
                            calcM.details.Quantity = int.Parse(calculatorGridView.Rows[i].Cells["Quantity"].Value.ToString());
                            calcM.details.Width = int.Parse(calculatorGridView.Rows[i].Cells["Width"].Value.ToString());
                            calcM.details.Height = int.Parse(calculatorGridView.Rows[i].Cells["Height"].Value.ToString());
                            calcM.details.Price = Convert.ToDecimal(calculatorGridView.Rows[i].Cells["Price"].Value);
                            calcM.details.Total = Convert.ToDecimal(calculatorGridView.Rows[i].Cells["Total"].Value);
                            calcM.details.HandWorkPrice = Convert.ToDecimal(calculatorGridView.Rows[i].Cells["HandWorkPrice"].Value);
                            calcM.details.InsertBy = 1;
                            if (chooseProfile.SelectedIndex == 0)
                                calcM.details.ProfileID = int.Parse(ddlProfile.SelectedValue.ToString());
                            else if (chooseProfile.SelectedIndex == 1)
                                calcM.details.ProfileID = int.Parse(calculatorGridView.Rows[i].Cells["Profile"].Value.ToString());
                            else if(chooseProfile.SelectedIndex ==-1 && calculatorGridView.Rows[i].Cells["Profile"].Value !=null)
                                calcM.details.ProfileID = int.Parse(calculatorGridView.Rows[i].Cells["Profile"].Value.ToString());
                            calcM.detailsBll.Insert(calcM.details);
                        }
                    }
                }
            }
            else
            {

                RadMessageBox.Show("Your order is empty!");

            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if(CopyList.orderList !=null)
            {
                var source = new BindingSource();
                source.DataSource = CopyList.orderList;
                calculatorGridView.DataSource = source;
                
            }
        }

        private void calculatorGridView_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (chooseProfile.SelectedIndex < 0)
            {             
                
                RadMessageBox.Show("Please select a profile method!");
                calculatorGridView.MasterView.TableAddNewRow.CancelAddNewRow();
            }
            else
            {
                if (chooseProfile.SelectedIndex == 0 && ddlProfile.SelectedIndex < 0)
                {
                    RadMessageBox.Show("Please select a profile!");
                    calculatorGridView.MasterView.TableAddNewRow.CancelAddNewRow();
                }
            }
            if(ddlWindowPane.SelectedIndex<0)
            {
                RadMessageBox.Show("Please select a window pane!");
                calculatorGridView.MasterView.TableAddNewRow.CancelAddNewRow();
            }
        }

    }
}
