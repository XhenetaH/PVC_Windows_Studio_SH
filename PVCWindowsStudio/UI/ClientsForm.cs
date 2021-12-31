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
    public partial class ClientsForm : Telerik.WinControls.UI.RadForm
    {
        private readonly ClientBLL clientBll;
        private Clients client;
        public ClientsForm()
        {
            clientBll = new ClientBLL();
            client = new Clients();
            InitializeComponent();
        }
        private void InitiateData()
        {
            clientGridView1.DataSource = clientBll.GetAll();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidationMethod())
            {
                client.Name = txtName.Text;
                client.LastName = txtLastName.Text;
                client.PhoneNumber = txtPhoneNr.Text;
                client.Email = txtEmail.Text;
                client.Address = txtAddress.Text;
                client.InsertBy = 1;
                if (clientBll.Insert(client))
                {
                    RadMessageBox.Show(MessageTexts.successInsertClient);
                    Clear();
                    InitiateData();
                    this.radValidationProvider1.ClearErrorStatus();
                }
                else RadMessageBox.Show(MessageTexts.somethingWrong);
            }
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            InitiateData();

            RadMessageBox.SetThemeName("MaterialBlueGrey");
            RadGridLocalizationProvider.CurrentProvider = new MyGridViewLocalizationProvider();
            RadMessageLocalizationProvider.CurrentProvider = new MyMessageBoxLocalizationProvider();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {                
                if (ValidationMethod())
                {
                    client.Name = txtName.Text;
                    client.LastName = txtLastName.Text;
                    client.PhoneNumber = txtPhoneNr.Text;
                    client.Email = txtEmail.Text;
                    client.Address = txtAddress.Text;
                    client.LUB = 1;
                    if (clientBll.Update(client))
                    {
                        RadMessageBox.Show(MessageTexts.successUpdateClient);
                        Clear();
                        InitiateData();
                        this.radValidationProvider1.ClearErrorStatus();
                    }
                    else RadMessageBox.Show(MessageTexts.somethingWrong);
                }            
            }
            else RadMessageBox.Show(MessageTexts.selectMessageClient);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                if (RadMessageBox.Show(MessageTexts.deleteMessage, "", MessageBoxButtons.YesNo, RadMessageIcon.Question) == DialogResult.Yes)
                {
                    if (clientBll.Delete(int.Parse(lblID.Text)))
                    {
                        RadMessageBox.Show(MessageTexts.successDeleteClient);
                        InitiateData();
                        Clear();
                    }
                    else RadMessageBox.Show(MessageTexts.somethingWrong);
                }
            }
            else
                RadMessageBox.Show(MessageTexts.selectMessageClient);
        }

        private void Clear()
        {
            this.radValidationProvider1.ClearErrorStatus();
            txtName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhoneNr.Text = "";
            txtAddress.Text = "";
            lblID.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
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
                            if (string.IsNullOrEmpty(i.AccessibilityObject.Value))
                                valid = false;
                        }
                    }
                }
            }
            return valid;
        }

        private void clientGridView1_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            this.radValidationProvider1.ClearErrorStatus();
            int rowindex = e.RowIndex;
            if (!rowindex.Equals(-1))
            {
                client = (Clients)clientGridView1.Rows[rowindex].DataBoundItem;
                if (client != null)
                {
                    lblID.Text = client.ClientID.ToString();
                    txtName.Text = client.Name;
                    txtLastName.Text = client.LastName;
                    txtAddress.Text = client.Address;
                    txtEmail.Text = client.Email;
                    txtPhoneNr.Text = client.PhoneNumber;
                }
            }
        }
    }
}
