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
    public partial class AdminMenu : Telerik.WinControls.UI.RadForm
    {
        private OrderDetailsBLL orderdetailbll = new OrderDetailsBLL();
        private OrderBLL orderBll = new OrderBLL();
        private InvoiceBLL invoiceBLL = new InvoiceBLL();
        private ClientBLL clientBLL = new ClientBLL();
        private ProductBLL productBLL = new ProductBLL();
        private HandiWorkBLL workBLL = new HandiWorkBLL();
        private ProfileBLL ProfileBLL = new ProfileBLL();
        public AdminMenu()
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

            activeForm.BringToFront();
            activeForm.Left = (this.ClientSize.Width - activeForm.Width) / 2;
            activeForm.Top = (this.ClientSize.Height - activeForm.Height) / 2;
            activeForm.Show();
      
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

            lblOrderNr.Text = orderBll.GetNr().ToString();
            lblNewOrders.Text = orderBll.GetNrByDate().ToString() + " New Orders";
            lblInvoiceNr.Text = invoiceBLL.GetNr().ToString();
            lblNewInvoice.Text = invoiceBLL.GetNrByDate().ToString() + " New Invoices";
            lblClientNr.Text = clientBLL.GetNr().ToString();
            lblNewClients.Text = clientBLL.GetNrByDate().ToString() + " New Clients";
            lblProductNr.Text = productBLL.GetNr().ToString();
            lblNewProduct.Text = productBLL.GetNrByDate().ToString() + " New Products";

         

            List<string> yValues = new List<string>() { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            var monthlist = new List<string>();
            for (int i = 0; i < yValues.Count; i++)
            {
                if (i < DateTime.Now.Month)
                {
                    monthlist.Add(yValues[i]);
                }
            }
            List<decimal> profitValues = new List<decimal>();
            for (int i = 1; i < DateTime.Now.Month+1; i++)
            {
                profitValues.Add(workBLL.GetPriceByDate(i, DateTime.Now.Year));
            }

            List<decimal> materialValues = new List<decimal>();
            for(int i=1; i<DateTime.Now.Month+1;i++)
            {
                materialValues.Add(orderdetailbll.GetPriceByDate(i, DateTime.Now.Year));
            }

            var profileList = ProfileBLL.Get();

            var profileName = new List<string>();
            var profileNr = new List<int>();

            if (profileList != null)
            {
                for (int i = 0; i < profileList.Count; i++)
                {
                    profileName.Add(profileList[i].NameProf);
                    profileNr.Add(profileList[i].ProfileID);
                }
            }

            chart1.Series["Profit"].Points.DataBindXY(monthlist, profitValues);
            chart3.Series["Materials"].IsValueShownAsLabel = true;
            chart3.Series["Materials"].Points.DataBindXY(monthlist, materialValues);
            chart2.Series["Series1"].IsValueShownAsLabel = true;
            chart2.Series["Series1"].Points.DataBindXY(profileName, profileNr);
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void invoicesMenuItem_Click(object sender, EventArgs e)
        {
           
            openChildForm(new InvoiceForm());
            
        }


        

        private void clientsMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new ClientsForm());
        }

        private void orderMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm());
        }

        private void orderDetailsMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderDetailsForm());
        }

        private void calculatorMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new CalculatorForm());
        }

        private void handworkMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new HandiWorkForm());
        }

        private void pricelistMenuItem1_Click(object sender, EventArgs e)
        {
            openChildForm(new PriceListForm());
        }

        private void radMenuItem2_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductsForm());
        }

        private void productItemMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductItemsForm());
        }

        private void formulaMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FormulaForm());
        }

        private void materialMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new MaterialsForm());
        }

        private void paneMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new WindowPanesForm());
        }

        private void blindMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new BlindsForm());
        }

        private void profileMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new ProfilesForm());
        }

     

        private void helpBtn_Click_1(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "C:\\Users\\Lenovo\\Documents\\My HelpAndManual Projects\\NewProject.chm", HelpNavigator.Topic, "Dashboard.htm");

        }

        private void btnAmerican_Click_1(object sender, EventArgs e)
        {
            ChangeLanguage change = new ChangeLanguage();
            change.UpdateConfig("language", "en");
            Application.Restart();
        }

        private void btnAlbania_Click_1(object sender, EventArgs e)
        {
            ChangeLanguage change = new ChangeLanguage();
            change.UpdateConfig("language", "sq");
            Application.Restart();
        }
    }
}
