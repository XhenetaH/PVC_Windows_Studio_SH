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
    public partial class Menu_ : Telerik.WinControls.UI.RadForm
    {
        public Menu_()
        {
            InitializeComponent();
        }
        private void openChildForm(Form chilForm)
        {
            Form activeForm = null;
            if (activeForm != null)
            {
                activeForm.Close();

            }
            activeForm = chilForm;
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(activeForm);
            panelChildForm.Tag = activeForm;
            activeForm.BringToFront();
            activeForm.Left = (this.ClientSize.Width - activeForm.Width) / 2;
            activeForm.Top = (this.ClientSize.Height - activeForm.Height) / 2;
            activeForm.Show();
            panelChildForm.Visible = true;

        }
        private void materialMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new MaterialsForm());
        }

        private void windowPaneMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new WindowPanesForm());
        }

        private void blindMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new BlindsForm());
        }

        private void profileMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new ProfilesForm());
        }

        private void productMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductsForm());
        }

        private void productItemMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductItemsForm());
        }

        private void formulaMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new FormulaForm());
        }

        private void priceListMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new PriceListForm());
        }

        private void handWorkMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new HandiWorkForm());
        }

        private void orderMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm());
        }

        private void orderDetailsMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderDetailsForm());
        }

        private void invoiceMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new InvoiceForm());
        }

        private void clientsMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new ClientsForm());
        }

        private void calculatorMenuBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new CalculatorForm());
        }
    }
}
