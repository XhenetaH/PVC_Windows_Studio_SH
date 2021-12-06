using PVCWindowsStudio.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PVCWindowsStudio.Session
{
    public static class Methods
    {
       
        public static decimal CalcPrice(int productId, string width,string height, int profileId,int blindId, decimal blindPrice, decimal panePrice, int paneId, List<PriceCalculation> details)
        { 

            for (int i = 0; i < details.Count; i++)
            {
                if (details[i].Formula.Contains("Price"))
                {
                    details[i].Formula = details[i].Formula.Replace("Price", details[i].Price);
                }
                if (details[i].Formula.Contains("Width"))
                {
                    details[i].Formula = details[i].Formula.Replace("Width", width);
                }
                if (details[i].Formula.Contains("Height"))
                {
                    details[i].Formula = details[i].Formula.Replace("Height", height);
                }
            }
            string total = "";

            for (int i = 0; i < details.Count; i++)
            {
                total = total + "+" + details[i].Formula;
            }

            decimal price = Convert.ToDecimal(new DataTable().Compute(total, null));

            if (blindId > -1)
            {
                var pr = blindPrice;
                price += pr;
            }
            if (paneId > -1)
            {
                price += panePrice;
            }
            return price;

        }
    }
}
