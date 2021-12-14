using PVCWindowsStudio.BLL;
using PVCWindowsStudio.BO;
using PVCWindowsStudio.Session;
using System;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI.Localization;

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
            RadGridLocalizationProvider.CurrentProvider = new MyGridViewLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new MyMessageBoxLocalizationProvider();

        }

        private void InitiateData()
        {
            windowpaneGridView.DataSource = windowpaneBll.GetAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtName.Text))
            {                
                windowpane.Name = txtName.Text;
                windowpane.Price = Convert.ToDecimal(priceTxt.Value.ToString());                
                windowpane.Other = txtDescription.Text;
                windowpane.InsertBy = 1;
                if (windowpaneBll.Insert(windowpane))
                {
                    RadMessageBox.Show(MessageTexts.successInsertPane);
                    Clear();
                    InitiateData();
                    this.radValidationProvider1.ClearErrorStatus();
                }
                else RadMessageBox.Show(MessageTexts.somethingWrong);
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
            txtDescription.Text = "";
            lblID.Text = "";            
            priceTxt.Text = "0.00";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                windowpane.Name = txtName.Text;
                windowpane.Price = Convert.ToDecimal(priceTxt.Value);
                windowpane.Other = txtDescription.Text;
                windowpane.LUB = 1;
                if (!String.IsNullOrEmpty(txtName.Text))
                {
                    if (windowpaneBll.Update(windowpane))
                    {
                        RadMessageBox.Show(MessageTexts.successUpdatePane);
                        Clear();
                        InitiateData();
                        this.radValidationProvider1.ClearErrorStatus();
                    }
                    else RadMessageBox.Show(MessageTexts.somethingWrong);
                }
                else
                {
                    this.radValidationProvider1.Validate(priceTxt);
                    this.radValidationProvider1.Validate(txtName);
                }

            }
            else RadMessageBox.Show(MessageTexts.selectMessagePane);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (RadMessageBox.Show(MessageTexts.deleteMessage, "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (windowpaneBll.Delete(int.Parse(lblID.Text)))
                    {
                        RadMessageBox.Show(MessageTexts.successDeletePane);
                        InitiateData();
                        Clear();
                    }
                    else RadMessageBox.Show(MessageTexts.somethingWrong);
                }                
            }
            else RadMessageBox.Show(MessageTexts.selectMessagePane);
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
                    priceTxt.Value = windowpane.Price;
                    txtDescription.Text = windowpane.Other;
                }
            }
        }
    }
}
